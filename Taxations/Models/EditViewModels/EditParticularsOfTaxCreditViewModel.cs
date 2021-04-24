using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Taxations.Models.EditViewModels
{
    public class EditParticularsOfTaxCreditViewModel
    {
        public static ParticularsOfTaxCredit EditParticularsOfTaxCredit(ParticularsOfTaxCredit model, ParticularsOfTaxCredit updatingModel)
        {
            updatingModel.AssessmentYear = model.AssessmentYear;
            updatingModel.ContributionToBenevolentFund = model.ContributionToBenevolentFund;
            updatingModel.ContributionToDeposit = model.ContributionToDeposit;
            updatingModel.ContributionToProvidentFund = model.ContributionToProvidentFund;
            updatingModel.ContributionToSuperAnnuationFund = model.ContributionToSuperAnnuationFund;
            updatingModel.ContributionToZakatFund = model.ContributionToZakatFund;
            updatingModel.Crore14C = model.Crore14C;
            updatingModel.EligibleAmountForRebate = model.EligibleAmountForRebate;
            updatingModel.InvestmentInApprovedDebenture = model.InvestmentInApprovedDebenture;
            updatingModel.InvestmentInApprovedSavings = model.InvestmentInApprovedSavings;
            updatingModel.LifeInsurance = model.LifeInsurance;
            updatingModel.Name = model.Name;
            updatingModel.OthersIfAny = model.OthersIfAny;
            updatingModel.SelfContributionAndEmployer = model.SelfContributionAndEmployer;
            updatingModel.SignatureAndDatePhoto = model.SignatureAndDatePhoto;
            updatingModel.TIN = model.TIN;
            updatingModel.TotalAllowableInvestment = model.TotalAllowableInvestment;
            updatingModel.TotalAllowableInvestmentContribution = model.TotalAllowableInvestmentContribution;
            updatingModel.TotalIncome14B = model.TotalIncome14B;
            updatingModel.AmountOfTaxRebateCalculated = model.AmountOfTaxRebateCalculated;
            return updatingModel;
        }
    }
}