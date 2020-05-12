using System;
using System.Linq;
using System.Threading.Tasks;
using MAVN.Service.SmsProviderMock.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MAVN.Service.SmsProviderMock.Controllers
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
