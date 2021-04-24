using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;


namespace Taxations.BusinessLogic
{
    public class FileHandlingGateway
    {
        private static string uniqueFileName = "";
        public static string UploadFile(string targetFolderPath, HttpPostedFileBase file)
        {
            if (file != null)
            {
                uniqueFileName = Guid.NewGuid() + "_" + file.FileName;
                /*
                 ::SaveAs Method Uses RootedPath Or Absolute Path Like "C:\\Desktop\\"
                 ::PathCombine Method Returns the Physical Path like, "~/Areas"
                 */
                file.SaveAs(HttpContext.Current.Server.MapPath(targetFolderPath + uniqueFileName));
                return Path.Combine(targetFolderPath, uniqueFileName);
            }
            return "NOIMAGE_PATH";
        }

        public static string UpdateFile(string targetFolderPath, string oldPhotoPath, HttpPostedFileBase file)
        {
            /*
             ::oldFolderPath = physicalPath bacause its start with "~" symbol
             */
            if (file != null)
            {
                var physicalPath = HttpContext.Current.Request.MapPath(oldPhotoPath);
                if (File.Exists(physicalPath))
                {
                    File.Delete(physicalPath);
                }
                uniqueFileName = Guid.NewGuid() + "_" + file.FileName;
                file.SaveAs(HttpContext.Current.Request.MapPath(targetFolderPath + uniqueFileName));
                return Path.Combine(targetFolderPath, uniqueFileName);
            }
            else
            {
                return oldPhotoPath;
            }
        }

        public static void DeleteFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        public static bool IsImageFile(HttpPostedFileBase file) 
            => (file.ContentType != "image/jpg" && file.ContentType != "image/jpeg" && file.ContentType != "image/pjpeg" && file.ContentType != "image/gif" &&
                    file.ContentType != "image/x-png" && file.ContentType != "image/png") ? false : true;


        

    }
}