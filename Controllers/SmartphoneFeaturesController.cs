using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SmartphoneShop.Models;

namespace SmartphoneShop.Controllers
{
    public class SmartphoneFeaturesController : Controller
    {
        private SmartphoneContext db = new SmartphoneContext();
        // GET: SmartphoneFeatures
        public ActionResult Index()
        {
            List<SmartphoneFeature> filteredList = db.SmartphoneFeatures.ToList().OrderByDescending(y => y.Rating).Take(5).ToList();
            return View(filteredList);
        }

        // GET: SmartphoneFeatures/Details/5
        public ActionResult Details(string id)
        {
            ViewBag.Message = "Order Placed Successfully !!! Your Bill Amount is Rs. ";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SmartphoneFeature smartphoneFeature = db.SmartphoneFeatures.Find(id);
            if (smartphoneFeature == null)
            {
                return HttpNotFound();
            }
            return View(smartphoneFeature);
        }
       
        public ActionResult SmartphoneList()
        {
            var phoneList = db.SmartphoneFeatures.ToList();
            return View("Filter",phoneList);
        }
        public ActionResult BrandFilter()
        {

            var phoneList = db.SmartphoneFeatures.ToList();
            List<SmartphoneFeature> brands = phoneList.GroupBy(m => m.Brand).Select(c => c.First()).ToList();
            return View(brands);
        }
        [HttpPost]
        public ActionResult BrandBasedModels(string brand)
        {
            var phoneList = db.SmartphoneFeatures.ToList();
            List<SmartphoneFeature> brands = new List<SmartphoneFeature>();
            foreach (SmartphoneFeature item in phoneList)
            {
                if(item.Brand==brand)
                {
                    brands.Add(item);
                }
            }
            return View("Filter",brands);
        }
        public ActionResult LowToHigh()
        {
            var mobileList = db.SmartphoneFeatures.ToList();
            List<SmartphoneFeature> filteredList = mobileList.OrderBy(ob => ob.Price).ToList();
            return View("Filter",filteredList);
        }

        public ActionResult HighToLow()
        {
            var mobileList = db.SmartphoneFeatures.ToList();
            List<SmartphoneFeature> filteredList = mobileList.OrderByDescending(ob => ob.Price).ToList();
            return View("Filter",filteredList);
        }
        public ActionResult Filter(List<SmartphoneFeature> mobileList)
        {
            List<SmartphoneFeature> phoneList=new List<SmartphoneFeature>();
            phoneList = mobileList;
            return View(phoneList);
        } 
        public ActionResult Compare()
        {
            var mobileList = db.SmartphoneFeatures.ToList();
            ViewBag.CompareList = new SelectList(mobileList, "Model", "Model");
            return View();
        }
        [HttpPost]
        public ActionResult Compare(string mobile1, string mobile2, string compareType)
        {
            string phone1 = mobile1;
            string phone2 = mobile2;
            var mobileList = db.SmartphoneFeatures.ToList();
            List<SmartphoneFeature> compareList = new List<SmartphoneFeature>();
            if (phone1 == phone2)
            {
                ViewBag.Message = "Please choose two different mobiles to compare!!!";
               
            }
                foreach (SmartphoneFeature item in mobileList)
                {
                    if (phone1 == item.Model)
                    {
                        compareList.Add(item);
                    }
                    else if (phone2 == item.Model)
                    {
                        compareList.Add(item);
                    }
                }
                if (compareType == "Compare Battery Capacity and Price")
                {
                    return View("Comparison1", compareList);
                }
                else if (compareType == "Compare Internal Storage and RAM")
                {
                    return View("Comparison2", compareList);
                }
                else
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
              }
       
        public ActionResult Comparison1(List<SmartphoneFeature> compareList)
        {
            List<SmartphoneFeature> comparisonList = compareList;
            return View(comparisonList);
        }
        public ActionResult Comparison2(List<SmartphoneFeature> compareList)
        {
            List<SmartphoneFeature> comparisonList = compareList;
            return View(comparisonList);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
