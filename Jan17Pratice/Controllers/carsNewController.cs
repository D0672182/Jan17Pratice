using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Jan17Pratice.Models;

namespace Jan17Pratice.Controllers
{
    public class carsNewController : Controller
    {
        private carContext db = new carContext();   //初始化EntityFramework的DbContext

        // GET: cars
        public ActionResult Index()
        {
            return View(db.cars.ToList());
        }

        // GET: cars/Details/5
        public ActionResult carsDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            car car = db.cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // GET: cars/Create              Create(顯示用)
        public ActionResult Create()
        {
            return View();
        }

        // POST: cars/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]//Create, Edit, Delete"異動資料"須搭配POST方法         
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,brand,model,hp,price")] car car) //Create新增資料-->form表單資料回寫用
        {
            if (ModelState.IsValid)
            {
                db.cars.Add(car);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(car);
        }

        // GET: cars/Edit/5
        public ActionResult Edit(int? id)    //Edit編輯資料, 需傳入參數id, 顯示用
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            car car = db.cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // POST: cars/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,brand,model")] car car)  //Edit編輯資料, form表單資料回寫用
        {
            if (ModelState.IsValid)
            {
                db.Entry(car).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(car);
        }

        // GET: cars/Delete/5
        public ActionResult Delete(int? id)  //Delete 需傳入參數, 顯示用
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            car car = db.cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // POST: cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)  //Delete刪除資料的最後確認
        {
            car car = db.cars.Find(id);
            db.cars.Remove(car);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();  //釋放db占用資源
            }
            base.Dispose(disposing);
        }
    }
}
