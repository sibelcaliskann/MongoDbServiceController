using MongoH14.Web.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<OgrenciService>();

var app = builder.Build();

app.UseStaticFiles(new StaticFileOptions()
{
	RequestPath = "/wwwroot"
});


app.MapControllerRoute("main", "{controller=Ogrenci}/{action=Index}/{id?}");

app.Run();
