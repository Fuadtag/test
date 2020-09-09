using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Day13.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Day13.Controllers
{
    public class CreditsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CreditsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var credits = _context.Contracts
                                  .Include(c => c.Person)
                                  .Include(c => c.Product)
                                  .OrderByDescending(c => c.Date)
                                  .ToList();

            return View(credits);
        }

        public IActionResult Details(int id)
        {
            var contract = _context.Contracts
                                   .Include(c => c.Person)
                                   .Include(c => c.Product)
                                   .Include(c=>c.Payments)
                                   .FirstOrDefault(c => c.Id == id);

            if (contract == null) return NotFound();

            return PartialView("_CreditInfoModal",contract);
        }

        public IActionResult DetailsJson(int id)
        {
            var contract = _context.Contracts
                                   .Include(c => c.Person)
                                   .Include(c => c.Product)
                                   .Include(c => c.Payments)
                                   .FirstOrDefault(c => c.Id == id);

            if (contract == null) return NotFound();

            var response = new
            {
                contract.Id,
                date = contract.Date.ToString("dd.MM.yyyy"),
                contract.Month,
                cost = contract.Cost.ToString("#.00"),
                person = new
                {
                    contract.Person.Id,
                    contract.Person.Name,
                    contract.Person.Surname,
                    contract.Person.Phone
                },
                product = new
                {
                    contract.Product.Id,
                    contract.Product.Name,
                    contract.Product.Photo
                },
                payments = contract.Payments.Select(p => new
                {
                    p.Id,
                    amount = p.Value.ToString("#.00"),
                    date = p.Date.ToString("dd.MM.yyyy"),
                    p.IsPaid,
                    payDate = p.PayDate?.ToString("dd.MM.yyyy")
                }).ToList()
            };

            return Ok(response);
        }
    }
}
