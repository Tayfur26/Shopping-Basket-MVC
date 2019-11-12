using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StajMvc.Models.EntityFramework;
using StajMvc.Models;
using System.Data;
using StajMvc.ViewModels;
namespace StajMvc.Controllers
{
    public class SiparisController : Controller
    {
        SepetViewItem ıtem = new SepetViewItem();
        public double toplamtutar = 0;
        


        // GET: Siparis



        public ActionResult Siparis()
        {
            SepetViewModels sepets = new SepetViewModels();
            sepets =(SepetViewModels)TempData["SepetViewModels"];
            TempData.Keep("SepetViewModels");
            double Toptutar =(Double) TempData["ToplamTutar"];
            if (TempData["ToplamTutar"]==null)
            {
                TempData["ToplamTutar"] =Convert.ToDouble(0);
            }
            TempData["ToplamTutar"] = Toptutar;
            TempData.Keep("ToplamTutar");
            return View();
        }

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
                
                return Json(toplamtutar, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                //tempdata da silinmek istenen ürün yoksa


                var dt = (SepetViewModels)TempData["SepetViewModels"];
                return Json(id, JsonRequestBehavior.AllowGet);
            }


        }

        public ActionResult SepetiOnayla()
        {
            return View("Index");
        }

    }
}