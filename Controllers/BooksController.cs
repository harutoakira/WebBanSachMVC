using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuanLyThuVien.Data;
using QuanLyThuVien.Method;
using QuanLyThuVien.Models;

namespace QuanLyThuVien.Controllers
{
    public class BooksController : Controller
    {
        private readonly BookDBContext _context;

        public BooksController(BookDBContext context)
        {
            _context = context;
        }

        // GET: Books
        public async Task<IActionResult> Index()
        {
            var bookDBContext = _context.books.Include(b => b.Author).Include(b => b.Category).Include(b => b.Publisher);
            return View(await bookDBContext.ToListAsync());
        }
        public async Task<IActionResult> catalogue()
        {
            return View(await _context.books.ToListAsync());
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.books == null)
            {
                return NotFound();
            }

            var book = await _context.books
                .Include(b => b.Author)
                .Include(b => b.Category)
                .Include(b => b.Publisher)
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            ViewData["AuthorId"] = new SelectList(_context.authors, "AuthorId", "AuthorId");
            ViewData["CategoryId"] = new SelectList(_context.categories, "CategoryId", "CategoryId");
            ViewData["PublisherId"] = new SelectList(_context.publishers, "PublisherId", "PublisherId");
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookId,BookName,Prices,Description,Picture,DateUpdate,Quantity,PublisherId,CategoryId,AuthorId,Viewed,Saled")] Book book, IFormFile uploadFile)
        {
            if(uploadFile != null)
            {
                string fileName = Path.GetFileName(uploadFile.FileName).ToString();
                var filePath = Path.Combine("wwwroot/img/books/", fileName);
                using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await uploadFile.CopyToAsync(fileStream);
                }
                if (book.Author == null && book.Category == null && book.Publisher == null)
                {
                    book.Picture = fileName;
                    _context.Add(book);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            ViewData["AuthorId"] = new SelectList(_context.authors, "AuthorId", "AuthorId", book.AuthorId);
            ViewData["CategoryId"] = new SelectList(_context.categories, "CategoryId", "CategoryId", book.CategoryId);
            ViewData["PublisherId"] = new SelectList(_context.publishers, "PublisherId", "PublisherId", book.PublisherId);
            return View(book);
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.books == null)
            {
                return NotFound();
            }

            var book = await _context.books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            ViewData["AuthorId"] = new SelectList(_context.authors, "AuthorId", "AuthorId", book.AuthorId);
            ViewData["CategoryId"] = new SelectList(_context.categories, "CategoryId", "CategoryId", book.CategoryId);
            ViewData["PublisherId"] = new SelectList(_context.publishers, "PublisherId", "PublisherId", book.PublisherId);
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookId,BookName,Prices,Description,Picture,DateUpdate,Quantity,PublisherId,CategoryId,AuthorId,Viewed,Saled")] Book book)
        {
            if (id != book.BookId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(book);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.BookId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuthorId"] = new SelectList(_context.authors, "AuthorId", "AuthorId", book.AuthorId);
            ViewData["CategoryId"] = new SelectList(_context.categories, "CategoryId", "CategoryId", book.CategoryId);
            ViewData["PublisherId"] = new SelectList(_context.publishers, "PublisherId", "PublisherId", book.PublisherId);
            return View(book);
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.books == null)
            {
                return NotFound();
            }

            var book = await _context.books
                .Include(b => b.Author)
                .Include(b => b.Category)
                .Include(b => b.Publisher)
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.books == null)
            {
                return Problem("Entity set 'BookDBContext.books'  is null.");
            }
            var book = await _context.books.FindAsync(id);
            if (book != null)
            {
                _context.books.Remove(book);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Books/Duplicate/5
        public async Task<IActionResult> Duplicate(int? id)
        {
            if (id == null || _context.books == null)
            {
                return NotFound();
            }

            var book = await _context.books
                .Include(b => b.Author)
                .Include(b => b.Category)
                .Include(b => b.Publisher)
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Duplicate")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DuplicateConfirmed(int id)
        {
            if (_context.books == null)
            {
                return Problem("Entity set 'BookDBContext.books'  is null.");
            }
            var book = await _context.books.FindAsync(id);
            if (book != null)
            {
                var cloneBook = book.Clone();
                _context.Add(cloneBook);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
          return _context.books.Any(e => e.BookId == id);
        }
    }
}
