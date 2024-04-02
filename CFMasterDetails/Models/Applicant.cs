using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CFMasterDetails.Models
{
    public class Applicant
    {
        public Applicant()
        {
            ApplicantExpriences = new List<ApplicantExprience>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }
        public int TotalExp { get; set; }
        public string PicPath { get; set; }
        [NotMapped]
        public HttpPostedFileBase Picture { get; set; }
        public bool IsAvilable { get; set; }
        public List<ApplicantExprience> ApplicantExpriences { get; set; }
    }

    public class ApplicantExprience
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Designation { get; set; }
        public int YearOfExprience { get; set; }
        [ForeignKey("Applicant")]
        public int ApplicantId { get; set; }
        public virtual Applicant Applicant { get; set; }
    }
}