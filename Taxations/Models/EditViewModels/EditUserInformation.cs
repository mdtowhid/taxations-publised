using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Taxations.Models;

namespace Taxations.Models.EditViewModels
{
    public class EditUserInformation
    {

        public static UserInformation SetUpdatingUserInformation(UserInformation model, UserInformation user)
        {
            user.AssessmentYear = model.AssessmentYear;
            user.BIN = model.BIN;
            user.Circle = model.Circle;
            user.ContactTelephone = model.ContactTelephone;
            user.DateOfBirth = model.DateOfBirth;
            user.Email = model.Email;
            user.EmployerName = model.EmployerName;
            user.FatherName = model.FatherName;
            user.Gender = model.Gender;
            user.IncomeYearFrom = model.IncomeYearFrom;
            user.IncomeYearTo = model.IncomeYearTo;
            user.MotherName = model.MotherName;
            user.NameOfAssessee = model.NameOfAssessee;
            user.NewTIN = model.NewTIN;
            user.NID = model.NID;
            user.OldTIN = model.OldTIN;
            user.PermanentAddress = model.PermanentAddress;
            user.PresentAddress = model.PresentAddress;
            user.ResidentStatus = model.ResidentStatus;
            user.ReturnSubmitted = model.ReturnSubmitted;
            user.SpouseName = model.SpouseName;
            user.SpouseTIN = model.SpouseTIN;
            user.TickOnBoxes = model.TickOnBoxes;
            user.UserId = model.UserId;
            user.Zone = model.Zone;
            return user;
        }
    }
}