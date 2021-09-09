using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class StatisticsController : Controller
    {
        Context c = new Context();
        // GET: Statistics
        public ActionResult Index()
        {

            var query1 = c.Categories.Count();//toplam kategori sayısı
            var query2 = c.Headings.Count(x => x.Category.CategoryName =="yazılım" );//Başlık tablosunda "yazılım" kategorisine ait başlık sayısı
            var query3 = c.Writers.Count(x => x.WriterName.Contains("a"));// Yazar adında 'a' harfi geçen yazar sayısı
            var query4 = c.Headings.Max(x => x.Category.CategoryName);// En fazla başlığa sahip kategori adı
            var query5 = c.Categories.Count(x => x.CategoryStatus == false);//Status ü false olanlar
            var query6 = c.Categories.Count(x => x.CategoryStatus == true);//Status ü true olanlar (çıkarma işlemi ile aralarındaki farkı bulmak için bu şekilde yaptım)

            ViewBag.Categories = query1;
            ViewBag.Headings = query2;
            ViewBag.Writers = query3;
            ViewBag.HeadingMax = query4;
            ViewBag.CategoryStatus = (query5 - query6);

            return View();
        }
       
    }
}