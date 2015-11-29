using Microsoft.AspNet.Mvc;
using Paylocity.CodeExam.App.Models;
using System.Collections.Generic;
using Paylocity.CodeExam.App.Services;

namespace Paylocity.CodeExam.App.Controllers
{
    [Produces("application/json")]
    [Route("api/PremiumQuotes")]
    public class PremiumQuotesController : Controller
    {
        // GET: api/PremiumQuotes
        [HttpGet]
        public IEnumerable<PremiumQuote> GetFamily()
        {
            return PremiumService.Instance.GetAll();
        }

        [HttpPost]
        public IEnumerable<PremiumQuote> AddPremiumQuote([FromBody]Person person)
        {
            var premiumService = PremiumService.Instance;
            premiumService.AddPerson(person);

            return premiumService.GetAll();
        }

        [HttpPut]
        public IEnumerable<PremiumQuote> ResetPremiumQuotes()
        {
            var premiumService = PremiumService.Instance;
            premiumService.Reset();

            return premiumService.GetAll();
        }

    }
}