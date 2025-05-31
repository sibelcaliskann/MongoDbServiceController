using MongoDB.Bson;
using MongoDB.Driver;
using MongoH14.Web.Models;

namespace MongoH14.Web.Services
{
	public class OgrenciService
	{
		private readonly IMongoCollection<Ogrenci> kisiCollection;

		public OgrenciService(IConfiguration config)
		{
			var client = new MongoClient(config.GetConnectionString("MongoDb"));
			var database = client.GetDatabase("ShellDbOrnek");
			kisiCollection = database.GetCollection<Ogrenci>("ogrenciler");
		}

		public List<Ogrenci> Getir()
		{
			var ogrenciler = kisiCollection.Find(_ => true).ToList();
			return ogrenciler;
		}
		public Ogrenci Getir(string id)
		{
			var ogrenci = kisiCollection.Find(a => a.OgrenciId == id).FirstOrDefault();
			return ogrenci;
		}
		public List<Ogrenci> Ara(string ara)
		{
			var ogrenciler = kisiCollection.Find(a => a.OgrenciAdi.ToLower() == ara.ToLower()).ToList();
			return ogrenciler;
		}

		public void Ekle(Ogrenci ogr)
		{
			kisiCollection.InsertOne(ogr);
		}

		public void Duzenle(Ogrenci ogr)
		{
			kisiCollection.ReplaceOne(a => a.OgrenciId == ogr.OgrenciId, ogr);
		}

		public void Sil(string id)
		{
			//BsonDocument<Ogrenci>.
			FilterDefinition<Ogrenci> filtre = Builders<Ogrenci>.Filter.Eq("_id", ObjectId.Parse(id));
			kisiCollection.DeleteOne(filtre);
		}




	}
}
