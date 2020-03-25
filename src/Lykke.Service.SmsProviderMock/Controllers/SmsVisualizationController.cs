using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lykke.Service.SmsProviderMock.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Lykke.Service.SmsProviderMock.Controllers
{
    [Route("/sentsms")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class SmsVisualizationController : Controller
    {
        private readonly ISmsRepository _smsRepository;

        public SmsVisualizationController(ISmsRepository smsRepository)
        {
            _smsRepository = smsRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var mails = await _smsRepository.GetLastFiftyTodaySmsAsync();

            return View(mails.ToList());
        }

        [HttpGet("details")]
        public async Task<IActionResult> Details(Guid messageId)
        {
            var mail = await _smsRepository.GetMessageByMessageIdAsync(messageId);

            return View(mail);
        }

    }
}
