using Microsoft.AspNetCore.Mvc;
using MongoH14.Web.Models;
using MongoH14.Web.Services;

namespace MongoH14.Web.Controllers
{
	public class OgrenciController : Controller
	{
		OgrenciService service;
		public OgrenciController(OgrenciService srv)
		{
			service = srv;
		}
		public IActionResult Index()
		{
			var ogrenciler = service.Getir();
			return View(ogrenciler);
		}

		public IActionResult Detay(string id)
		{
			Ogrenci ogr = service.Getir(id);
			return View(ogr);
		}

		public IActionResult Duzenle(string id)
		{
			Ogrenci duzenlenecekOgrenci = service.Getir(id);

			return View(duzenlenecekOgrenci);
		}

		[HttpPost]
		public IActionResult Duzenle(Ogrenci ogr)
		{
			string id = Request.RouteValues["id"].ToString();
			Ogrenci duzenlenecekOgrenci = service.Getir(id);
			duzenlenecekOgrenci.OgrenciAdi = ogr.OgrenciAdi;
			duzenlenecekOgrenci.OgrenciYas = ogr.OgrenciYas;
			duzenlenecekOgrenci.OgrenciDogumTarihi = ogr.OgrenciDogumTarihi;
			duzenlenecekOgrenci.Adres.Sehir = ogr.Adres.Sehir;
			duzenlenecekOgrenci.Adres.Ulke = ogr.Adres.Ulke;
			service.Duzenle(duzenlenecekOgrenci);
			return View();
		}

		public IActionResult Sil(string id)
		{
			service.Sil(id);
			return RedirectToAction("Index");
		}
	}
}
