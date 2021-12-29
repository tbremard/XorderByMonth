using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;

namespace Core
{
    public class XorderCore
    {
        public DateTime GetDate(string pathOfFile)
        {
            DateTime ret;
            string fileName = Path.GetFileName(pathOfFile);
            if (fileName.StartsWith("SL_MO_"))
            {
                fileName = fileName.Substring(6, fileName.Length - 6);
            }
            if(fileName.StartsWith("DSC_"))
            {
                if (!File.Exists(pathOfFile))
                {
                    throw new FileNotFoundException(pathOfFile);
                }
                using (FileStream fs = new FileStream(pathOfFile, FileMode.Open, FileAccess.Read))
                using (Image myImage = Image.FromStream(fs, false, false))
                {
                    PropertyItem propItem = myImage.GetPropertyItem(36867);
                    string propertyTaken = Encoding.UTF8.GetString(propItem.Value);
                    int spaceIndex = propertyTaken.IndexOf(' ');
                    string dateTaken = propertyTaken.Substring(0, spaceIndex).Replace(':', '-');
                    return DateTime.Parse(dateTaken);
                }
            }
            string substring = fileName.Substring(4, 8);
            string year = substring.Substring(0, 4);
            string month = substring.Substring(4, 2);
            string day = substring.Substring(6, 2);
            ret = new DateTime(int.Parse(year), int.Parse(month), int.Parse(day));
            return ret;
        }

        public bool IsValidFile(string fileName)
        {
            string[] validExtensions = { ".jpg", ".mp4", ".avi", ".mov" };
            string lower = fileName.ToLower();
            if (lower.Contains("snapchat"))
            {
                return false;
            }
            foreach (var xtension in validExtensions)
            {
                if (lower.EndsWith(xtension))
                {
                    return true;
                }
            }
            return false;
        }

        public string GenerateSubFolderName(DateTime date)
        {
            string ret = date.Year + "-" + date.Month.ToString("d2");
            return ret;
        }
    }
}
