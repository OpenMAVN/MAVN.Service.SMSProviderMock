using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Log;
using Lykke.Common.Log;
using MAVN.Persistence.PostgreSQL.Legacy;
using MAVN.Service.SmsProviderMock.Domain.Entities;
using MAVN.Service.SmsProviderMock.Domain.Models;
using MAVN.Service.SmsProviderMock.Domain.Repositories;
using MAVN.Service.SmsProviderMock.MsSqlRepositories.Entities;
using Microsoft.EntityFrameworkCore;

namespace MAVN.Service.SmsProviderMock.MsSqlRepositories.Repositories
{
    public class SmsRepository : ISmsRepository
    {
        private readonly PostgreSQLContextFactory<SmsContext> _contextFactory;
        private readonly ILog _log;

        public SmsRepository(PostgreSQLContextFactory<SmsContext> contextFactory, ILogFactory logFactory)
        {
            _contextFactory = contextFactory;
            _log = logFactory.CreateLog(this);
        }

        public async Task<bool> CreateAsync(Guid messageId, string phoneNumber, string message)
        {
            using (var context = _contextFactory.CreateDataContext())
            {
                try
                {
                    var entity = new SmsEntity(messageId, phoneNumber, message);

                    context.Sms.Add(entity);

                    await context.SaveChangesAsync();

                    return true;
                }
                catch (DbUpdateException e)
                {
                    _log.Warning("Error creating sms entry", e);
                    return false;
                }
            }
        }

        public async Task<PaginatedSmsModel> RetrievePaginatedSmsAsync(int skip, int take, string phoneNumber, string messageId)
        {
            using (var context = _contextFactory.CreateDataContext())
            {
                var smsQuery = context.Sms.AsQueryable();

                if (!string.IsNullOrWhiteSpace(messageId))
                {
                    smsQuery = smsQuery.Where(sms => sms.MessageId.ToString() == messageId);
                }

                if (!string.IsNullOrWhiteSpace(phoneNumber))
                {
                    smsQuery = smsQuery.Where(sms => sms.PhoneNumber == phoneNumber);
                }

                var result = await smsQuery
                    .OrderByDescending(sms => sms.Timestamp)
                    .Skip(skip)
                    .Take(take)
                    .ToArrayAsync();

                var totalCount = await smsQuery.CountAsync();

                return new PaginatedSmsModel
                {
                    Sms = result,
                    TotalPageCount = Convert.ToInt32(Math.Ceiling(totalCount / (decimal)take))
                };
            }
        }

        public async Task<bool> DeleteAsync(Guid messageId)
        {
            using (var context = _contextFactory.CreateDataContext())
            {
                var entity = await context.Sms.FirstOrDefaultAsync(sms =>
                    sms.MessageId == messageId);

                if (entity == null)
                    return false;

                context.Remove(entity);

                await context.SaveChangesAsync();

                return true;
            }
        }

        public async Task<IEnumerable<ISms>> GetLastFiftyTodaySmsAsync()
        {
            using (var context = _contextFactory.CreateDataContext())
            {
                var today = DateTime.UtcNow.Date;
                var list = await context.Sms
                    .Where(i => i.Timestamp >= today)
                    .OrderByDescending(e => e.Timestamp)
                    .Take(50)
                    .ToListAsync();

                return list;
            }
        }

        public async Task<ISms> GetMessageByMessageIdAsync(Guid messageId)
        {
            using (var context = _contextFactory.CreateDataContext())
            {
                var entity = await context.Sms
                    .FirstOrDefaultAsync(e => e.MessageId == messageId);

                return entity;
            }
        }
    }
}
