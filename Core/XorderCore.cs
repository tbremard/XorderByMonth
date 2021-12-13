using System;

namespace Core
{
    public class XorderCore
    {
        public DateTime GetDate(string fileName)
        {
            DateTime ret;
            string substring = fileName.Substring(4, 8);
            string year = substring.Substring(0, 4);
            string month = substring.Substring(4, 2);
            string day = substring.Substring(6, 2);
            ret = new DateTime(int.Parse(year), int.Parse(month), int.Parse(day));
            return ret;
        }

        public string GenerateSubFolderName(DateTime date)
        {
            string ret = date.Year + "-" + date.Month.ToString("d2");
            return ret;
        }
    }
}
