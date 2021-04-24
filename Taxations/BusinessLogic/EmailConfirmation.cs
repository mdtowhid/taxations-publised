using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web.Hosting;
using System.Web.Mvc;

namespace Taxations.Models
{
    public class EmailConfirmation
    {
        private static readonly TaxationDbContext db = new TaxationDbContext();

        public static void BuildEmailTemplate(long id, string url, bool isPasswordRecovery)
        {
            string body = "";
            var regInfo = db.Users.Where(x => x.Id == id).FirstOrDefault();
            if (!isPasswordRecovery)
            {
                body =
                System.IO.File.ReadAllText(HostingEnvironment.MapPath("~/views/components/") + "EmailTemplate.cshtml");
                url = url + id;
                body = body.Replace("regUser", "Welcome! "+ regInfo.FirstName);
                body = body.Replace("@ViewBag.ConfirmationLink", url);
                body = body.ToString();
            }
            else
            {
                body = System.IO.File.ReadAllText(HostingEnvironment.MapPath("~/views/components/") + "RecoverEmailTemplate.cshtml");
                url = url + id + "&&recoverCode=" + regInfo.RecoveryCode;
                body = body.Replace("regUser", regInfo.FirstName + " " + regInfo.LastName);
                body = body.Replace("@ViewBag.RecoverAccountLink", url);

            }
            
            BuildEmailTemplate("Your Account is successfully created.", body, regInfo.Email);
        }

        public static void BuildEmailTemplate(string subjectText, string bodyText, string sendTo)
        {
            string from, to, bcc, cc, subject, body;
            from = "pencilic123@gmail.com";
            to = sendTo.Trim();
            bcc = "";
            cc = "";
            subject = subjectText;
            StringBuilder sb = new StringBuilder();
            sb.Append(bodyText);
            body = sb.ToString();
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(from);
            mail.To.Add(new MailAddress(to));
            if (!string.IsNullOrEmpty(bcc))
            {
                mail.Bcc.Add(new MailAddress(bcc));
            }

            if (!string.IsNullOrEmpty(cc))
            {
                mail.Bcc.Add(bcc);
            }

            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;
            SendEmail(mail);
        }


        public static void SendEmail(MailMessage mail)
        {
            SmtpClient client = new SmtpClient();
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.EnableSsl = true;
            client.UseDefaultCredentials = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Credentials = new NetworkCredential("pencilic123@gmail.com", "towhid109203");

            try
            {
                client.Send(mail);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}