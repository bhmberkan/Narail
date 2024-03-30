using Narail.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Narail.Controllers
{
    public class AuthorAdminController : Controller
    {
        // GET: AuthorAdmin
        NarailDBEntities db = new NarailDBEntities();
        public ActionResult Index()
        {
            return View(db.Author.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost] // post metodu gonderilenleri url de gizler
        public ActionResult Create(Author author, HttpPostedFileBase File)
        {
            var authorExist = db.Author.Any(m => m.Email == author.Email);
            if (authorExist==false)
            {
                author.AddedDate = DateTime.Now;
                author.AddedBy = "Berkan Burak Turgut";  // session ile kımın eklediğini çekerız daha sonra şu anlık bu şekilde yazdım
                //author.Email = author.Email;
                //author.About = author.About;
                //author.NameSurname = author.NameSurname;

                if(File != null)
                {
                    FileInfo fileinfo = new FileInfo(File.FileName); // file adındaki nesnein adını aldık 
                    WebImage img = new WebImage(File.InputStream); // file adlı nesnein inputstream ile içeriğini okuduk
                    string uzanti = (Guid.NewGuid().ToString() + fileinfo.Extension).ToLower(); // // dosya uzantısını yeni bir guid ile birleştirdik sorna da küçük harflere dönüştürdük
                    img.Resize(225,180,false,false);  // resime boyut verdik false false kısmı ise kırpma olmasın diye 
                    string tamyol = "~/images/users/"+ uzanti ; //  yüklenecek dosyanın tam yolunu belirledik

                    img.Save(Server.MapPath(tamyol));  // yolu sever'a kaydettik/ dönderdik. 

                    author.Image = "/images/users/" + uzanti; // resmi de aldık 
                }
                db.Author.Add(author); // aldığımız şeyleri veri tabanına ekledik
                db.SaveChanges(); // kaydettik
            }

            return RedirectToAction("Index"); // kaydettikten sonra index sayfasına gittik
        }

        public ActionResult Delete(int? ID) // buradaki soru işareti int ya da null olabilir anlamında kullanılmaktadır.
                                            // sadece int yazarsak null geldiğinde hata verecek.
        {
            if (ID == null)
            {
                return HttpNotFound();
            }

            Author author = db.Author.Find(ID); // ilgili kişiyi bulduk find ettik 
            db.Author.Remove(author); // sildik 
            db.SaveChanges(); // burada yaptıklarımızı kaydettik
            return RedirectToAction("Index"); // redirect ile index sayfasına gönderdik
            // silme kısmındaki hatayı çözdüm sebebi veri tabanında primary key atamamış olmamız.
        }


        public ActionResult Details(int? Id)
        {
            if(Id==null  ||   Id==0)
            {
                return HttpNotFound();
            }


            Author author = db.Author.Find(Id);
            return PartialView(author);
        }


        public ActionResult Edit(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return HttpNotFound();
            }


            Author author = db.Author.Find(Id);
            return View(author);
        }

        [HttpPost]
        public ActionResult Edit(Author author, HttpPostedFileBase File)
        {
            db.Entry(author).State = System.Data.Entity.EntityState.Modified; // gelen modeli düzenleme veya değişiklik yapma hakkı tanıyor entity de 
            db.Entry(author).Property(m => m.AddedBy).IsModified = false;
            db.Entry(author).Property(m => m.AddedDate).IsModified = false;



            if (author != null )
            {
                if (File != null)
                {
                    FileInfo fileinfo = new FileInfo(File.FileName); // file adındaki nesnein adını aldık 
                    WebImage img = new WebImage(File.InputStream); // file adlı nesnein inputstream ile içeriğini okuduk
                    string uzanti = (Guid.NewGuid().ToString() + fileinfo.Extension).ToLower(); // // dosya uzantısını yeni bir guid ile birleştirdik sorna da küçük harflere dönüştürdük
                    img.Resize(225, 180, false, false);  // resime boyut verdik false false kısmı ise kırpma olmasın diye 
                    string tamyol = "~/images/users/" + uzanti; //  yüklenecek dosyanın tam yolunu belirledik

                    img.Save(Server.MapPath(tamyol));  // yolu sever'a kaydettik/ dönderdik. 

                    author.Image = "/images/users/" + uzanti; // resmi de aldık 
                }
                else
                {
                    db.Entry(author).Property(m => m.Image).IsModified = false;
                }
                author.ModifyBy = "Berkan Burak TURGUT";
                author.ModifyDate = DateTime.Now; 

            }
            db.SaveChanges(); 

            return RedirectToAction("Index","AuthorAdmin");
        }

    }
}
