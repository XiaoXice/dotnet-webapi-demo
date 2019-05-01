using System.Collections.Generic;
using dotnet_webapi_1.Models;
using dotnet_webapi_1.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace dotnet_webapi_1.Controllers
{
    /// <summary>
    /// /api/books的控制器
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : Controller
    {
        private readonly BookService _bookService;
        /// <summary>
        /// Books的控制器生成
        /// </summary>
        /// <param name="bookService"></param>
        public BooksController(BookService bookService)
        {
            _bookService = bookService;
        }
        /// <summary>
        /// GET请求: api/books 获得所有的图书
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<Book>> Get()
        {
            return _bookService.Get();
        }
        /// <summary>
        /// GET请求: aip/books/{ID} 获得一本书
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:length(24)}", Name = "GetBook")]
        public ActionResult<Book> Get([FromQuery]string id)
        {
            var book = _bookService.Get(id);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }
        /// <summary>
        /// POST请求: api/books 创建一本书
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<Book> Create([FromBody]Book book)
        {
            _bookService.Create(book);

            return CreatedAtRoute("GetBook", new { id = book.Id.ToString() }, book);
        }
        /// <summary>
        /// PUT请求: api/books/{ID} 更新请求
        /// </summary>
        /// <param name="id"></param>
        /// <param name="bookIn"></param>
        /// <returns></returns>
        [HttpPut("{id:length(24)}")]
        public IActionResult Update([FromQuery]string id,[FromBody] Book bookIn)
        {
            var book = _bookService.Get(id);

            if (book == null)
            {
                return NotFound();
            }

            _bookService.Update(id, bookIn);

            return NoContent();
        }
        /// <summary>
        /// DELET请求: api/books/{ID}
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete([FromQuery]string id)
        {
            var book = _bookService.Get(id);

            if (book == null)
            {
                return NotFound();
            }

            _bookService.Remove(book.Id);

            return NoContent();
        }
    }
}
