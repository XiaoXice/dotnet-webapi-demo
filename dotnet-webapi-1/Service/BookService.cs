using System.Collections.Generic;
using System.Linq;
using dotnet_webapi_1.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace dotnet_webapi_1.Services
{
    /// <summary>
    /// BookService
    /// </summary>
    public class BookService
    {
        private readonly IMongoCollection<Book> _books;

        /// <summary>
        /// BookService初始化
        /// 用来连接服务器啥的
        /// </summary>
        /// <param name="config"></param>
        public BookService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("BookstoreDb"));
            var database = client.GetDatabase("BookstoreDb");
            _books = database.GetCollection<Book>("Books");
        }
        /// <summary>
        /// 查询所有的图书
        /// </summary>
        /// <returns></returns>
        public List<Book> Get()
        {
            return _books.Find(book => true).ToList();
        }
        /// <summary>
        /// 根据ID查一本书
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Book Get(string id)
        {
            return _books.Find<Book>(book => book.Id == id).FirstOrDefault();
        }
        /// <summary>
        /// 创建一本书
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public Book Create(Book book)
        {
            _books.InsertOne(book);
            return book;
        }
        /// <summary>
        /// 更新一本书的信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="bookIn"></param>
        public void Update(string id, Book bookIn)
        {
            _books.ReplaceOne(book => book.Id == id, bookIn);
        }
        /// <summary>
        /// 根据对象删除一本书
        /// </summary>
        /// <param name="bookIn"></param>
        public void Remove(Book bookIn)
        {
            _books.DeleteOne(book => book.Id == bookIn.Id);
        }
        /// <summary>
        /// 根据ID删除一本书
        /// </summary>
        /// <param name="id"></param>
        public void Remove(string id)
        {
            _books.DeleteOne(book => book.Id == id);
        }
    }
}