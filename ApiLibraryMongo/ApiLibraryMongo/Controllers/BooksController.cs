using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using ApiLibraryMongo.Repository;
using ApiLibraryMongo.Models;
using MongoDB.Bson;

namespace ApiLibraryMongo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookProvider db = new BookProvider();

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            return Ok(await db.GetAllBooks());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(string id)
        {
            return Ok(await db.GetBookById(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] Book book)
        {
            if (book == null)
                return BadRequest("Hubo un error, BadRequest executed!");

            if (book.Title == string.Empty)
                ModelState.AddModelError("Title", "El libro debe tener un titulo.");

            await db.InsertBook(book);
            return Created("Creado", true);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook([FromBody] Book book, string id)
        {
            if (book == null)
                return BadRequest("Hubo un error, BadRequest executed!");

            if (book.Title == string.Empty)
                ModelState.AddModelError("Title", "El libro debe tener un titulo.");

            book.Id = new ObjectId(id);
            await db.UpdateBook(book);
            return Created("Created", true);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(string id)
        {
            await db.DeleteBook(id);
            return NoContent();
        }
    }
}
