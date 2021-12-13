using NUnit.Framework;

namespace Core.UnitTest
{
    public class ClassCoreTest
    {
        ClassCore _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new ClassCore();
        }

        [Test]
        public void Hello_WhenCalled_ThenOk()
        {

            var actual = _sut.Hello();

            string expected = "blabla"; 
            Assert.AreEqual(expected, actual);
        }
    }
}
