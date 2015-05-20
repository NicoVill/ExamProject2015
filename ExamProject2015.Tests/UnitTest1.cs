using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExamProject2015.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AuthenticateLogin()
        {
            DatabaseFacade _dbf = new DatabaseFacade();

            bool answer = _dbf.LogIn("Test", "1234");
            int priv = _dbf.PrivLevel;

            Assert.AreEqual(true, answer);


        }
        [TestMethod]
        public void AuthenticatePrivLevel()
        {
            DatabaseFacade _dbf = new DatabaseFacade();

            bool answer = _dbf.LogIn("Test", "1234");
            int priv = _dbf.PrivLevel;

            Assert.AreEqual(1, priv);


        }
    }
}
