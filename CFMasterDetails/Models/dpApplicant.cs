using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CFMasterDetails.Models
{
    public class dpApplicant:DbContext
    {
        public dpApplicant():base ("name=dpApplicant") {}
            //public DbSet<Applicant> Applicants { get; set; }
            //public DbSet<ApplicantExprience> ApplicantEXP { get; set; }
            public DbSet<Employee> Employees { get; set; }
        public DbSet<Applicant> Applicants { get; set; }
        public DbSet<ApplicantExprience> ApplicantsExpriences { get;set; }

    }
}