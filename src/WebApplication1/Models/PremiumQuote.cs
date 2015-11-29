using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paylocity.CodeExam.App.Models
{
    public class PremiumQuote: Person
    {
        public int ID { get; set; }
        public string Note { get; set; }
        public int Premium { get; set; }

    }
}
