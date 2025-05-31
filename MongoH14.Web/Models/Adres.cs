using MongoDB.Bson.Serialization.Attributes;

namespace MongoH14.Web.Models
{
	public class Adres
	{
		[BsonElement("ulke")]
		public string Ulke { get; set; }

		[BsonElement("sehir")]
		public string Sehir { get; set; }
	}
}
