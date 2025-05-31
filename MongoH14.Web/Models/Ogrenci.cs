using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoH14.Web.Models
{
	public class Ogrenci
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string OgrenciId { get; set; }

		[BsonElement("isim")]
		public string OgrenciAdi { get; set; }

		[BsonElement("yas")]
		public int OgrenciYas { get; set; }

		[BsonElement("bolum")]
		public string OgrenciBolumu { get; set; }

		[BsonElement("dogumTarihi")]
		public DateTime OgrenciDogumTarihi { get; set; }
		
		[BsonElement("hobiler")]
		public List<string> OgrenciHobiler { get; set; }
		[BsonElement("notlar")]
		public List<Not> OgrenciNotlar { get; set; }

		[BsonElement("adres")]
		public Adres Adres { get; set; }

	}
}
