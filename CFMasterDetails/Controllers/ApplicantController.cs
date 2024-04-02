using CFMasterDetails.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CFMasterDetails.Controllers
{
    public class ApplicantController : Controller
    {
        dpApplicant db = new dpApplicant();
        // GET: Applicant
        public ActionResult Index()
        {
            var database = db.Applicants.Include("ApplicantExpriences").ToList();
            return View(database);
        }
        [HttpGet]
        public ActionResult Create()
        {
            Applicant applicant = new Applicant();
            applicant.ApplicantExpriences.Add(new ApplicantExprience
            {
                CompanyName = "",
                Designation = "",
                YearOfExprience = 0
            }) ;
            return View(applicant);
        }
        [HttpPost]
        public ActionResult Create(Applicant applicant, string btn)
        {
            if (btn == "Add")
            {
                applicant.ApplicantExpriences.Add(new ApplicantExprience());
            }

            if (btn == "Create")
            {

                if (applicant.Picture != null)
                {
                    string ext = Path.GetExtension(applicant.Picture.FileName);
                    if (ext == ".jpg" || ext == ".png")
                    {
                        applicant.TotalExp = applicant.ApplicantExpriences.Sum(m => m.YearOfExprience);

                        //Root SavePath
                        string rootPath = Server.MapPath("~/");
                        string FileToSave = Path.Combine(rootPath, "Pictures", applicant.Picture.FileName);
                        applicant.Picture.SaveAs(FileToSave);
                        applicant.PicPath = "~/Pictures/" + applicant.Picture.FileName;
                        db.Applicants.Add(applicant);   
                        if (db.SaveChanges() > 0)
                        {
                            return RedirectToAction("Index");
                        }

                    }
                    else
                    {
                        ModelState.AddModelError("", "Provide Valid Image");
                        return View(applicant);
                    }
                }
            
            }
            return View(applicant);
        }

        public ActionResult Delete(int id)
        {
            Applicant applicant = new Applicant();
            if (id != null)
            {
                var user = db.Applicants.Find(id);
                db.Applicants.Remove(user);
                db.SaveChanges();
                string rootPath = Server.MapPath("~/");
                if (System.IO.File.Exists(Path.Combine(rootPath, "Pictures", applicant.Picture.FileName)))
                {
                    System.IO.File.Delete(Path.Combine(rootPath, "Pictures", applicant.Picture.FileName));
                }

            }

            return RedirectToAction("Index");
        }
    }
}