using Library.Data;
using Library.Data.Models;
using Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Library.Controllers
{
    public class BookController : BaseController
    {
        private readonly LibraryDbContext db;

        public BookController(LibraryDbContext context)
        {
             db = context;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var books = await db.Books
                .AsNoTracking()
                .Select(b => new AllBookViewModel
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    ImageUrl = b.ImageUrl,
                    Rating = b.Rating,
                    Category = b.Category.Name
                })
                .ToListAsync();
            
            return View(books);
        }

        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            string userId = GetUserId();

            var mybooks = await db.IdentityUserBook
                .Where(ub => ub.CollectorId == userId)
                .Select(b => new AllBookViewModel
                {
                    Id = b.BookId,
                    Title = b.Book.Title,
                    Author = b.Book.Author,
                    ImageUrl = b.Book.ImageUrl,
                    Description = b.Book.Description,
                    Category = b.Book.Category.Name
                })
                .ToListAsync();

            return View(mybooks);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCollection(int id)
        {
            var book = await db.Books
                .Where(b => b.Id == id)
                .Include(b => b.UsersBooks)
                .FirstOrDefaultAsync();

            if (book == null)
            {
                return BadRequest();
            }

            string userId = GetUserId();

            if (!book.UsersBooks.Any(b => b.CollectorId == userId))
            {
                book.UsersBooks.Add(new IdentityUserBook()
                {
                    BookId = book.Id,
                    CollectorId = userId
                });

                await db.SaveChangesAsync();
            }

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new BookViewModel();

            model.Categories = await GetCategories();

            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> Add(BookViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = await GetCategories();

                return View(model);
            }

            var entity = new Book()
            {
                Title = model.Title,
                Author = model.Author,
                Description = model.Description,
                Rating = model.Rating,
                CategoryId = model.CategoryId,
                ImageUrl = model.Url
            };

            await db.Books.AddAsync(entity);

            await db.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCollection(int id)
        {
            var userId = GetUserId();

            var bookToRemove = await db.IdentityUserBook
                .FirstOrDefaultAsync(ub => ub.CollectorId == userId && ub.BookId == id);

            if (bookToRemove != null)
            {
                db.IdentityUserBook.Remove(bookToRemove);
                await db.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Mine));
        }

        private string GetUserId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
        }

        private async Task<IEnumerable<CategoryViewModel>> GetCategories()
        {
            return await db.Categories
                .AsNoTracking()
                .Select(c => new CategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();
        }
    }
}
