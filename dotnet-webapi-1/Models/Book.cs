using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace dotnet_webapi_1.Models
{
    /// <summary>
    /// Book的MongoDB.BSON结构
    /// </summary>
    public class Book
    {
        /// <summary>
        /// ID 对应MongoDB自带的主键
        /// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        /// <summary>
        /// 书名
        /// </summary>
        [BsonElement("Name")]
        public string BookName { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        [BsonElement("Price")]
        public decimal Price { get; set; }
        /// <summary>
        /// 类别
        /// </summary>
        [BsonElement("Category")]
        public string Category { get; set; }
        /// <summary>
        /// 作者
        /// </summary>
        [BsonElement("Author")]
        public string Author { get; set; }
    }
}