using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExamProject2015.Tests
{
    [TestClass]
    public class FolderTest
    {
        [TestMethod]
        public void CreateFolderTest()
        {
            DatabaseFacade dbf = new DatabaseFacade();
            string expected = dbf.CreateFolderDB("CreateFolderTest", 152);
            
            string answer = "Filen er oploaded";

            Assert.AreEqual(expected, answer);
        }

        [TestMethod]
        public void CreateFolderTestExist()
        {
            DatabaseFacade dbf = new DatabaseFacade();
            string expected = dbf.CreateFolderDB("CreateFolderTest", 152);

            string answer = "Navnet er allerede brugt";

            Assert.AreEqual(expected, answer);
        }

        [TestMethod]
        public void DeleteFolderTest()
        {
            DatabaseFacade dbf = new DatabaseFacade();

            string expected = dbf.DeleteFolderDB(168);
            string answer = "Filen er oploaded";

            Assert.AreEqual(expected, answer);
        }
    }
}
