using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListRazor.Pages.BookList
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Book Book { get; set; }
        public async Task OnGet(int id)
        {
            Book = await _db.Book.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (Book.Id == 0)
            {
                if (ModelState.IsValid)
                {
                    await _db.Book.AddAsync(Book);
                    await _db.SaveChangesAsync();
                    return RedirectToPage("Index");
                }
                else
                {
                    return Page();
                }
            }
            else
            {
                if (ModelState.IsValid)
                {
                    var BookToUpdate = await _db.Book.FindAsync(Book.Id);
                    BookToUpdate.Name = Book.Name;
                    BookToUpdate.Author = Book.Author;
                    BookToUpdate.ISBN = Book.ISBN;
                    await _db.SaveChangesAsync();
                    return RedirectToPage("Index");
                }
                else
                {
                    return Page();
                }
            }
            

        }
    }
}