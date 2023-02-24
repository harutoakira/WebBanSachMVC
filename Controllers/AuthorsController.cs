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
using System.Web;

namespace QuanLyThuVien.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly BookDBContext _context;

        public AuthorsController(BookDBContext context)
        {
            _context = context;
        }

        // GET: Authors
        public async Task<IActionResult> Index()
        {
              return View(await _context.authors.ToListAsync());
        }
        //GET: Authors Male
        public async Task<IActionResult> MaleAuthor()
        {
            AuthorFactory authorFactory;
            var items = await _context.authors.ToListAsync();
            List<Author> authorList = new List<Author>();
            foreach(var item in items)
            {
                if(item.Sex == "Male")
                {
                    authorFactory = new MaleAuthorFactory();
                    authorList.Add(authorFactory.GetAuthor(item.AuthorId, item.AuthorName, item.Address, item.History, item.PhoneNumber));
                }
                
            }
            return View(authorList);
        }
        //GET: Authors Female
        public async Task<IActionResult> FemaleAuthor()
        {
            AuthorFactory authorFactory;
            var items = await _context.authors.ToListAsync();
            List<Author> authorList = new List<Author>();
            foreach (var item in items)
            {
                if (item.Sex == "Female")
                {
                    authorFactory = new FemaleAuthorFactory();
                    authorList.Add(authorFactory.GetAuthor(item.AuthorId, item.AuthorName, item.Address, item.History, item.PhoneNumber));
                }

            }
            return View(authorList);
        }
        // GET: Authors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.authors == null)
            {
                return NotFound();
            }

            var author = await _context.authors
                .FirstOrDefaultAsync(m => m.AuthorId == id);
            if (author == null)
            {
                return NotFound();
            }

            return View(author);
        }

        // GET: Authors/Create
        public IActionResult MaleCreate()
        {
            return View();
        }

        // POST: Authors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("MaleCreate")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MalePost([Bind("AuthorName,Address,History,PhoneNumber")] MaleAuthor author)
        {
            AuthorFactory authorFactory;
            authorFactory = new MaleAuthorFactory();
            var item = authorFactory.PostAuthor(author.AuthorName, author.Address, author.History, author.PhoneNumber);
            if (item != null)
            {
                _context.Add(item);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(author);
        }

        public IActionResult FemaleCreate()
        {
            return View();
        }

        // POST: Authors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("FemaleCreate")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> FemalePost([Bind("AuthorName,Address,History,PhoneNumber")] FemaleAuthor author)
        {
            AuthorFactory authorFactory;
            authorFactory = new FemaleAuthorFactory();
            var item = authorFactory.PostAuthor(author.AuthorName, author.Address, author.History, author.PhoneNumber);
            if (item != null)
            {
                _context.Add(item);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(author);
        }

        // GET: Authors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.authors == null)
            {
                return NotFound();
            }

            var author = await _context.authors.FindAsync(id);
            if (author == null)
            {
                return NotFound();
            }
            return View(author);
        }

        // POST: Authors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AuthorId,AuthorName,Address,History,Sex,PhoneNumber")] Author author)
        {
            if (id != author.AuthorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(author);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AuthorExists(author.AuthorId))
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
            return View(author);
        }

        // GET: Authors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.authors == null)
            {
                return NotFound();
            }

            var author = await _context.authors
                .FirstOrDefaultAsync(m => m.AuthorId == id);
            if (author == null)
            {
                return NotFound();
            }

            return View(author);
        }

        // POST: Authors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.authors == null)
            {
                return Problem("Entity set 'BookDBContext.authors'  is null.");
            }
            var author = await _context.authors.FindAsync(id);
            if (author != null)
            {
                _context.authors.Remove(author);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AuthorExists(int id)
        {
          return _context.authors.Any(e => e.AuthorId == id);
        }
    }
}
