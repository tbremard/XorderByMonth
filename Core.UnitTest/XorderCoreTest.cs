using NUnit.Framework;
using System;

namespace Core.UnitTest
{
    public class XorderCoreTest
    {
        XorderCore _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new XorderCore();
        }

        [TestCase(2020, 02, 01, "IMG_20200201_110410.jpg")]
        [TestCase(2020, 04, 08, "IMG_20200408_195401.jpg")]
        [TestCase(2017, 12, 19, "VID_20171219_104435.mp4")]
        [TestCase(2021, 12, 08, "VID_20211208_220844.mp4")]
        [TestCase(2020, 08, 04, "SL_MO_VID_20200804_190358.mp4")]
        [TestCase(2020, 08, 20, "DSC_1599.JPG")]
        public void GetDate_WhenValidFileName_ThenDateIsParsed(int year, int month, int day, string fileName)
        {

            var ret = _sut.GetDate(fileName);

            DateTime expected = new DateTime(year, month, day);
            Assert.AreEqual(expected, ret);
        }

        [Test]
        public void GenerateSubFolderName_WhenValidDate_ThenValidFolderName()
        {
            var date = new DateTime(2021, 05, 06);

            var ret = _sut.GenerateSubFolderName(date);

            string expected = "2021-05";
            Assert.AreEqual(expected, ret);
        }
    }
}
