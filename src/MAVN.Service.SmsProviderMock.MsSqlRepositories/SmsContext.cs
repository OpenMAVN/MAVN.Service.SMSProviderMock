using System.Data.Common;
using JetBrains.Annotations;
using Lykke.Common.MsSql;
using Lykke.Service.SmsProviderMock.MsSqlRepositories.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lykke.Service.SmsProviderMock.MsSqlRepositories
{
    public class SmsContext : MsSqlContext
    {
        private const string Schema = "sms";

        internal DbSet<SmsEntity> Sms { get; set; }

        // C-tor for EF migrations
        [UsedImplicitly]
        public SmsContext()
            : base(Schema)
        {
        }

        public SmsContext(string connectionString, bool isTraceEnabled)
            : base(Schema, connectionString, isTraceEnabled)
        {
        }

        public SmsContext(DbConnection dbConnection)
            : base(Schema, dbConnection)
        {
        }

        protected override void OnLykkeModelCreating(ModelBuilder modelBuilder)
        {
            var smsEntityBuilder = modelBuilder.Entity<SmsEntity>();

            smsEntityBuilder.HasIndex(c => c.PhoneNumber).IsUnique(false);
            smsEntityBuilder.HasIndex(c => c.MessageId).IsUnique();
        }
    }
}
