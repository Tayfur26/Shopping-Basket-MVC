using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StajMvc.Models;
using StajMvc.ViewModels;
namespace StajMvc.Controllers
{
    public class HomeController : Controller
    {

        SepetViewItem ıtem = new SepetViewItem();
        
        public double toplamtutar = 0;
        public int sepetsayi = 0;



        public ActionResult Index()
        {


        SepetViewModels viewItems = new SepetViewModels();
        viewItems.Add(ıtem);

            
            TempData["sepetsayac"] = sepetsayi;
            TempData.Keep("sepetsayac");



            TempData["SepetViewModels"] = new SepetViewModels();
            TempData["SepetViewModels"] = viewItems;
            int idbaslat = 0;
            TempData["idbaslat"] = idbaslat;
            TempData.Keep("idbaslat");

            TempData.Keep("SepetViewModels");
            return View("Index");
        }

        
            [HttpPost]
        public JsonResult Sepetsilj(string id)
        {
            
            try
            {
                //silimek istenen ürün tempdata var mı ?

                SepetViewModels viewItems = new SepetViewModels();
                viewItems.Clear();
                viewItems = (SepetViewModels)TempData["SepetViewModels"];
                var st = viewItems.Find(c => c.Id == Convert.ToInt32(id));
                viewItems.Remove(st);

                TempData["SepetViewModels"] = viewItems;
                TempData.Keep("SepetViewModels");

                toplamtutar = Convert.ToDouble(TempData["ToplamTutar"]);
                toplamtutar = toplamtutar - (st.adet * st.fiyat);
                TempData["ToplamTutar"] = toplamtutar;
                TempData.Keep("ToplamTutar");
                
                sepetsayi = (int)TempData["sepetsayac"];
                sepetsayi = sepetsayi - 1;
                TempData["sepetsayac"] = sepetsayi;
                TempData.Keep("sepetsayac");


                return Json(toplamtutar, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                //tempdata da silinmek istenen ürün yoksa


                var dt = (SepetViewModels)TempData["SepetViewModels"];
                return Json(id, JsonRequestBehavior.AllowGet);
            }
             
            
        }



        [HttpPost]
        public JsonResult Sepeteklej(string isim, string fiyat, string adet)
        {
            SepetViewModels viewItems = new SepetViewModels();
            SepetViewItem ıtem = new SepetViewItem();

            viewItems = (SepetViewModels)TempData["SepetViewModels"];
            toplamtutar = Convert.ToDouble(TempData["ToplamTutar"]);

            try
            {
                //daha önce eklenen ürün

                viewItems.Find(m => m.yemek == isim).adet +=  Convert.ToInt32(adet);
                
                toplamtutar = toplamtutar + Convert.ToInt32(adet) * viewItems.Find(m => m.yemek == isim).fiyat;
                TempData["ToplamTutar"] = toplamtutar;
                TempData.Keep("ToplamTutar");

                //tekrar eden ürün var olduğunu html e aktarmak için

                string tekraritem = "tekrar";

                sepetsayi = (int)TempData["sepetsayac"];
                TempData.Keep("sepetsayac");
                
                


                string[] datalist1 =
                {
                isim=viewItems.Find(m => m.yemek == isim).yemek,
                fiyat= viewItems.Find(m => m.yemek == isim).fiyat.ToString(),
                adet= viewItems.Find(m => m.yemek == isim).adet.ToString(),
                 viewItems.Find(m => m.yemek == isim).Id.ToString(),
                 toplamtutar.ToString(),
                 tekraritem,
                 sepetsayi.ToString()
                 

            };
                TempData["SepetViewModels"] = viewItems;
                TempData.Keep("SepetViewModels");

                return Json(datalist1, JsonRequestBehavior.AllowGet);

            }
            catch
            {
                //ilk kez eklenen ürün
                string tekraritem = "yeni";

                ıtem.yemek = isim;
                double d1 = double.Parse(fiyat, CultureInfo.InvariantCulture);
                ıtem.fiyat = d1;
                ıtem.adet = Convert.ToInt32(adet);

                int idbaslat = (int)TempData["idbaslat"];
                idbaslat = idbaslat + 1;
                ıtem.Id = idbaslat;
                TempData["idbaslat"] = idbaslat;
                TempData.Keep("idbaslat");
                viewItems.Add(ıtem);
                
                TempData["SepetViewModels"] = viewItems;
                TempData.Keep("SepetViewModels");

                sepetsayi = (int)TempData["sepetsayac"];
                sepetsayi = sepetsayi + 1;
                TempData["sepetsayac"] = sepetsayi;
                TempData.Keep("sepetsayac");

                toplamtutar = toplamtutar+(ıtem.fiyat * ıtem.adet);
                TempData["ToplamTutar"] = toplamtutar;
                TempData.Keep("ToplamTutar");

               string[] datalist = { isim, fiyat, adet,(ıtem.Id).ToString(),toplamtutar.ToString(), tekraritem, sepetsayi.ToString() };
            
            return Json(datalist, JsonRequestBehavior.AllowGet);
            }
            
        }

        [HttpPost]
        public JsonResult Sepetbosaltj()
        {
            int idbaslat = (int)TempData["idbaslat"];
            idbaslat = 0;
            TempData["idbaslat"] = idbaslat;
            TempData.Keep("idbaslat");

            sepetsayi = 0;
            TempData["sepetsayac"] = sepetsayi;
            TempData.Keep("sepetsayac");

            toplamtutar = 0;
            TempData["ToplamTutar"] = toplamtutar;
            TempData.Keep("ToplamTutar");

            var Sepetdata = (SepetViewModels)TempData["SepetViewModels"];
            Sepetdata.Clear();
            TempData["SepetViewModels"] = Sepetdata;
            TempData.Keep("SepetViewModels");



            return Json(toplamtutar.ToString(),JsonRequestBehavior.AllowGet);
        }

            public ActionResult SiparisEkrani()
        {
            var Sepetdata =(SepetViewModels) TempData["SepetViewModels"];
            TempData.Keep("SepetViewModels");
            return View("Siparis",Sepetdata);
        }

    }
}