using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Taxations.Models;
using System.Web.Mvc;

namespace Taxations.DataAccessLayer
{
    public class UserHandling
    {
        private readonly static TaxationDbContext db = new TaxationDbContext();
        public static User GetUserById(long id) => db.Users.FirstOrDefault(x => x.Id == id);
    }
}