using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace TeamCode.BusinessLogicLayer
{
    public static class CustomFilesGateway
    {

        public static IEnumerable<string>
            GetAllFilesNameFromFolder(string folderPath) => 
                        Directory.EnumerateFiles(HttpContext.Current.Server.MapPath(folderPath)).Select(Path.GetFileName);



        private static bool MoveFileFromDirectory(string targetFolder)
        {
            bool isMoved = false;
            string path = @"C:\Users\Admin\Desktop\Docs\MDN_JS";
            bool isDirectoryExist = System.IO.Directory.Exists(path);

            if (isDirectoryExist)
            {
                string targetFile = System.IO.Path.Combine(path, "i.png");
                bool isFileExist = System.IO.File.Exists(targetFile);
                if (isFileExist)
                {
                    DirectoryInfo directoryInfo = new DirectoryInfo(path);
                    FileInfo[] fis = directoryInfo.GetFiles();
                    foreach (FileInfo fi in fis)
                    {
                        if (!(fi.Extension.ToLower() == ".png"))
                            continue;
                        if (fi.Extension.ToLower() == ".png")
                        {
                            try
                            {
                                // string sourceFile = System.IO.Path.Combine(path, fi.FullName);
                                // string destFile = System.IO.Path.Combine(targetFolder, fi.FullName);
                                // System.IO.File.Copy(fi.DirectoryName, sourceFile, false);
                                // isMoved = true;
                            }
                            catch (System.IO.IOException e)
                            {
                                isMoved = false;
                                throw e;
                            }
                            finally
                            {
                                //
                            }
                        }
                    }
                }
            }

            return isMoved;
        }
    }
}