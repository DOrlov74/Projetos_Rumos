using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace MongoDB_WebAPI.Models
{
    public class Store
    {
        [BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string StoreName { get; set; }

        [BsonElement("address")]
        public string StoreAddress { get; set; }

        public bool? Active { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local, Representation = BsonType.Document)]
        public DateTime? ModifiedDate { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local, Representation = BsonType.Document)]
        public DateTime? CreatedDate { get; set; }

        public virtual ICollection<Pos> Pos { get; set; } = new List<Pos>();

        public virtual ICollection<Stock> Stocks { get; set; } = new List<Stock>();
    }
}
