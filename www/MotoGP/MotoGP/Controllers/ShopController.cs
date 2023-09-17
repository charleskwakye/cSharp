using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MotoGP.Data;
using MotoGP.Models;
using MotoGP.Models.ViewModels;

namespace MotoGP.Controllers
{
    public class ShopController : Controller
    {
        private readonly GPContext _context;

        public ShopController(GPContext context)
        {
            _context = context;
        }

        public IActionResult ListTickets(int raceID)
        {
            ViewData["BannerNr"] = 3;
            var listTicketsVM = new ListTicketsViewModel();
            listTicketsVM.Races = new SelectList(_context.Races.OrderBy(r => r.Name), "RaceID", "Name");
            if (raceID != 0)
            {
                listTicketsVM.Tickets = _context.Tickets.OrderByDescending(d => d.OrderDate).Where(t => t.RaceID == raceID).ToList();
                return View(listTicketsVM);
            }


            listTicketsVM.Tickets = _context.Tickets.OrderByDescending(d => d.OrderDate).ToList();

            return View(listTicketsVM);
        }

        public IActionResult ConfirmOrder(int TicketID)
        {
            ViewData["BannerNr"] = 3;
            ViewData["Title"] = "Confirmation";
            Ticket ticket = _context.Tickets.Where(t => t.TicketID == TicketID).Include(t => t.Race).SingleOrDefault();
            return View(ticket);
        }

        //GET: Tickets/Create
        public IActionResult OrderTicket()
        {
            ViewData["BannerNr"] = 3;
            ViewData["Title"] = "Order Tickets";
            ViewData["Countries"] = new SelectList(_context.Countries.OrderBy(c => c.Name), "CountryID", "Name");
            ViewData["Races"] = _context.Races.OrderBy(c => c.Name);
            return View();
        }




        //POST: Tickets
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult OrderTicket([Bind("TicketID,Name,Email,Address,Number,CountryID,RaceID")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                ticket.Paid = false;
                _context.Add(ticket);
                _context.SaveChanges();
                return RedirectToAction("ConfirmOrder", new { ticketID = ticket.TicketID });
            }

            return View(ticket);

        }

        //Editicket

        public IActionResult EditTicket(int id)
        {
            ViewData["BannerNr"] = 3;
            ViewData["Title"] = "Edit Tickets";

            Ticket ticket = _context.Tickets.Include(t => t.Race).Include(t => t.Country).SingleOrDefault(t => t.TicketID == id);
            return View(ticket);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult EditTicket([Bind("TicketID,Paid,Email,Address,Name,CountryID,RaceID")] Ticket ticket)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(ticket);
        //            _context.SaveChanges();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            throw;
        //        }
        //        //ticket.Paid = false;
        //        //_context.Add(ticket);
        //        //_context.SaveChanges();
        //        return RedirectToAction("ListTickets");
        //    }
        //    var listTicketsVM = new ListTicketsViewModel();
        //    listTicketsVM.Tickets = _context.Tickets.OrderByDescending(d => d.OrderDate).ToList();
        //    listTicketsVM.Races = new SelectList(_context.Races.OrderBy(r => r.Name), "RaceID", "Name");
        //    return View(ticket);

        //}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditTicket([Bind("TicketID,Paid")] Ticket ticket)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Attach(ticket);
                    _context.Entry(ticket).Property(t => t.Paid).IsModified = true;
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                //ticket.Paid = false;
                //_context.Add(ticket);
                //_context.SaveChanges();
                return RedirectToAction("ListTickets");
            }
            var listTicketsVM = new ListTicketsViewModel();
            listTicketsVM.Tickets = _context.Tickets.OrderByDescending(d => d.OrderDate).ToList();
            listTicketsVM.Races = new SelectList(_context.Races.OrderBy(r => r.Name), "RaceID", "Name");
            return View(ticket);

        }


    }
}
