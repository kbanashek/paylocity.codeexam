using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Paylocity.CodeExam.App.Models;

namespace Paylocity.CodeExam.App.Services
{
    public sealed class PremiumService
    {
        private static readonly PremiumService _instance = new PremiumService();
        private  List<PremiumQuote> _people;

        private PremiumService()
        {
            // Load list of available servers
            _people = new List<PremiumQuote>();
        }

        public static PremiumService Instance
        {
            get
            {
                return _instance;
            }
        }

        public void Reset()
        {
            _people = new List<PremiumQuote>();
        }

        public void AddPerson(Person person)
        {
            var applyDiscount = applyDiscountToPerson(person);

            _people.Add(new PremiumQuote
            {
                ID = _people.Count + 1,
                FirstName = person.FirstName,
                LastName = person.LastName,
                IsEmployee = person.IsEmployee,
                Premium = getMonthlyPremiumCost(person, applyDiscount),
                Note = getNote(person, applyDiscount),
            });
        }

        private int getMonthlyPremiumCost(Person person, bool applyDiscount)
        {
            var premiumCost = person.IsEmployee ? 1000/26 : 500/26;

            if (applyDiscount)
            {
                var discount = Convert.ToInt32((premiumCost * 10) * .01);
                premiumCost =  premiumCost - discount;
                person.Discount = discount;
            }

            return premiumCost;
        }

        private bool applyDiscountToPerson(Person person)
        {
            var applyDiscount = person.FirstName.Substring(0, 1).ToLower() == "a" ||
                                person.LastName.Substring(0, 1).ToLower() == "a";
            
            return applyDiscount;
        }

        private string getNote(Person person, bool applyDiscount)
        {
            return applyDiscount ? "First letter discount applied." + ": ($" + person.Discount +  ")": "";
        }

        public List<PremiumQuote> GetAll()
        {
            return _people;
        }

    }


}
