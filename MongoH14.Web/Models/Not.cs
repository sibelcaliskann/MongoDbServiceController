using MongoDB.Bson.Serialization.Attributes;

namespace MongoH14.Web.Models
{
	public class Not
	{
		[BsonElement("ders")]
		public string DersAdi { get; set; }

		[BsonElement("not")]
		public int NotDegeri { get; set; }
	}
}
