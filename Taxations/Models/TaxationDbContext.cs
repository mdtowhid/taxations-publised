using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Taxations.Controllers;
using Taxations.Dtos;
using Taxations.Models;

namespace Taxations.Models
{
    public class TaxationDbContext : DbContext
    {
        public DbSet<AppExpiration> AppExpirations { get; set; }
        public DbSet<BasicInformation> BasicInformations { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<Invesment> Invesments { get; set; }
        public DbSet<RebateCalculation> RebateCalculations { get; set; }
        public DbSet<SalaryAndAllowance> SalaryAndAllowances { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserInformation> UserInformations { get; set; }
        public DbSet<StatementOfAsset> StatementOfAssets { get; set; }
        public DbSet<StatementOfExpense> StatementOfExpense { get; set; }
        public DbSet<ParticularsOfTaxCredit> ParticularsOfTaxCredits { get; set; }
        public DbSet<ParticularsOfIncomeFromSalary> ParticularsOfIncomeFromSalaries { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<DPSInfo> DPSInfoes { get; set; }
        public DbSet<TotalInfo> TotalInfoes { get; set; }
        public DbSet<TaxableIncomeTax> TaxableIncomeTaxes { get; set; }
        public DbSet<FinalCalculation> FinalCalculations { get; set; }
        public DbSet<TaxExempted> TaxExempteds { get; set; }
        public DbSet<Surcharge> Surcharges { get; set; }
        public DbSet<Insurance> Insurances { get; set; }
        public DbSet<ParticularsOfIncomeAmount> ParticularsOfIncomeAmounts { get; set; }
    }
}