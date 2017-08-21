using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinanceBreakDown.Models;

namespace FinanceBreakDown.Controllers
{
    public class FinanceController : Controller
    {
        public ActionResult IncomeName()
        {
            return View();
        }

        [HttpPost]
        public ActionResult IncomeName(Income model)
        {
            return RedirectToAction("IncomeAmount", model);
        }

        public ActionResult IncomeAmount(Income model)
        {
            ModelState.Clear();
            return View(model);
        }

        [HttpPost]
        public ActionResult IncomeAmountPost(Income model)
        {
            return RedirectToAction("Bills", model);
        }

        public ActionResult Bills(Income model)
        {
            var person = new Person() { income = model, bill = new List<Bill>() };

            var bill1 = new Bill { name = "Mortgage/Rent" , amount = 0.0m };
            var bill2 = new Bill { name = "Car payment", amount = 0.0m };
            var bill3 = new Bill { name = "Gas", amount = 0.0m };
            var bill4 = new Bill { name = "Car insurence", amount = 0.0m };
            var bill5 = new Bill { name = "Food", amount = 0.0m };
            var bill6 = new Bill { name = "Phone bill", amount = 0.0m };
            var bill7 = new Bill { name = "Savings", amount = 0.0m };

            person.bill.Add(bill1);
            person.bill.Add(bill2);
            person.bill.Add(bill3);
            person.bill.Add(bill4);
            person.bill.Add(bill5);
            person.bill.Add(bill6);
            person.bill.Add(bill7);

            return View(person);
        }

        public ActionResult Display(Person person)
        {
            var billAmounts = new List<decimal>();

            decimal total = 0.0m;

            foreach (var item in person.bill)
            {
                total += item.amount;
                
                billAmounts.Add(item.amount); 
            }

            ViewBag.total = total;
            ViewBag.Difference = person.income.amount - total;
            ViewBag.bill1 = ((billAmounts[0] / total) * 100).ToString("0.##");
            ViewBag.bill2 = ((billAmounts[1] / total) * 100).ToString("0.##");
            ViewBag.bill3 = ((billAmounts[2] / total) * 100).ToString("0.##");
            ViewBag.bill4 = ((billAmounts[3] / total) * 100).ToString("0.##");
            ViewBag.bill5 = ((billAmounts[4] / total) * 100).ToString("0.##");
            ViewBag.bill6 = ((billAmounts[5] / total) * 100).ToString("0.##");
            ViewBag.bill7 = ((billAmounts[6] / total) * 100).ToString("0.##");

            return View(person);
        }
    }
}