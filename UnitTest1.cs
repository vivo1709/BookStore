using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BookStoreLIB
{
    [TestClass]
    public class UnitTest1
    {
        UserData userData = new UserData();
        string inputName, inputpassword;
        int actualUserId;
        [TestMethod]
        public void TestMethod1()
        {
            //specify the value of test inputs
            inputName = "dclark";
            inputpassword = "dc1234";
            //specify the value of expected outputs
            Boolean expectedReturn = true;
            int expectedUserId = 1;
            //obtain the actual outputs by callig the methof under testing
            Boolean actualRetuen = userData.Login(inputName, inputpassword);
            actualUserId = userData.UserID;
            //verify the result
            Assert.AreEqual(expectedReturn, actualRetuen);
            Assert.AreEqual(expectedUserId, actualUserId);
        }
        [TestMethod]
        public void TestMethod2()
        {
            //specify the value of test inputs
            inputName = "";
            inputpassword = "js0138";
            //specify the value of expected outputs
            Boolean expectedReturn = false;
            int expectedUserId = -1;
            //obtain the actual outputs by callig the methof under testing
            Boolean actualRetuen = userData.Login(inputName, inputpassword);
            actualUserId = userData.UserID;
            //verify the result
            Assert.AreEqual(expectedReturn, actualRetuen);
            Assert.AreEqual(expectedUserId, actualUserId);
        }
        [TestMethod]
        public void TestMethod3()
        {
            //specify the value of test inputs
            inputName = "jclark";
            inputpassword = "js0138";
            //specify the value of expected outputs
            Boolean expectedReturn = false;
            int expectedUserId = -1;
            //obtain the actual outputs by callig the methof under testing
            Boolean actualRetuen = userData.Login(inputName, inputpassword);
            actualUserId = userData.UserID;
            //verify the result
            Assert.AreEqual(expectedReturn, actualRetuen);
            Assert.AreEqual(expectedUserId, actualUserId);
        }
        [TestMethod]
        public void TestMethod4()
        {
            //specify the value of test inputs
            inputName = "jsmith";
            inputpassword = "js1380";
            //specify the value of expected outputs
            Boolean expectedReturn = false;
            int expectedUserId = -1;
            //obtain the actual outputs by callig the methof under testing
            Boolean actualRetuen = userData.Login(inputName, inputpassword);
            actualUserId = userData.UserID;
            //verify the result
            Assert.AreEqual(expectedReturn, actualRetuen);
            Assert.AreEqual(expectedUserId, actualUserId);
        }
        [TestMethod]
        public void TestMethod5()
        {
            //specify the value of test inputs
            inputName = "jsmith";
            inputpassword = "jc013#";
            //specify the value of expected outputs
            Boolean expectedReturn = false;
            int expectedUserId = -1;
            //obtain the actual outputs by callig the methof under testing
            Boolean actualRetuen = userData.Login(inputName, inputpassword);
            actualUserId = userData.UserID;
            //verify the result
            Assert.AreEqual(expectedReturn, actualRetuen);
            Assert.AreEqual(expectedUserId, actualUserId);
        }
        [TestMethod]
        public void TestMethod6()
        {
            //specify the value of test inputs
            inputName = "jsmith";
            inputpassword = "";
            //specify the value of expected outputs
            Boolean expectedReturn = false;
            int expectedUserId = -1;
            //obtain the actual outputs by callig the methof under testing
            Boolean actualRetuen = userData.Login(inputName, inputpassword);
            actualUserId = userData.UserID;
            //verify the result
            Assert.AreEqual(expectedReturn, actualRetuen);
            Assert.AreEqual(expectedUserId, actualUserId);
        }
        [TestMethod]
        public void TestMethod7()
        {
            //specify the value of test inputs
            inputName = "jsmith";
            inputpassword = "jc01389";
            //specify the value of expected outputs
            Boolean expectedReturn = false;
            int expectedUserId = -1;
            //obtain the actual outputs by callig the methof under testing
            Boolean actualRetuen = userData.Login(inputName, inputpassword);
            actualUserId = userData.UserID;
            //verify the result
            Assert.AreEqual(expectedReturn, actualRetuen);
            Assert.AreEqual(expectedUserId, actualUserId);
        }

        [TestMethod]
        public void TestMethod8()
        {
            //need DALOrder to make the checkout button unit test
        }
    }
}
