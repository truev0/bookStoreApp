using bookStoreApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using bookStoreApp.Models.Entities;

namespace bookStoreApp.Controllers
{
    public class SalesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SalesController(ApplicationDbContext context)
        { 
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var sales = _context.Sales
                .Include(s => s.Book)
                .Include(s => s.Customer);
            return View(await sales.ToListAsync());
        }

        public IActionResult Create()
        {
            ViewData["Books"] = _context.Books.ToList();
            ViewData["Customers"] = _context.Customers.Where(c => c.Status == "Activo").ToList();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(List<Sale> sales)
        {
            if (ModelState.IsValid)
            {
                foreach (var sale in sales)
                {
                    var book = await _context.Books.FindAsync(sale.BookId);
                    if (book == null || book.Quantity < sale.Quantity)
                    {
                        ModelState.AddModelError(string.Empty, "No hay suficiente cantidad del libro.");
                        ViewData["Books"] = _context.Books.ToList();
                        ViewData["Customers"] = _context.Customers.Where(c => c.Status == "Activo").ToList();
                        return View(sales);
                    }

                    sale.Total = sale.Quantity * book.Price;
                    _context.Add(sale);
                    book.Quantity -= sale.Quantity;
                    _context.Update(book);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["Books"] = _context.Books.ToList();
            ViewData["Customers"] = _context.Customers.Where(c => c.Status == "Activo").ToList();
            return View(sales);
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var sale = await _context.Sales
                .Include(s => s.Book)
                .Include(s => s.Customer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sale == null) return NotFound();

            return View(sale);
        }

    }
}
