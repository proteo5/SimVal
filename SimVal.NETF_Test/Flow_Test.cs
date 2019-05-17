using System;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimVal.NETF.Flow;

namespace SimVal.NETF_Test
{
    [TestClass]
    public class Flow_Test
    {
        [TestMethod]
        public void IsNotNull()
        {
            try
            {
                Validate.Begin()
                    .IsNotNull<String>("String", "FieldName")
                    .Check();

                Assert.IsTrue(true,"Test succeed");
            }
            catch (ArgumentException ex)
            {
                Assert.Fail("Test Fail");
            }
            catch (Exception)
            {

                Assert.Fail("Test Fail, an exeption has happend");
            }
        }

        [TestMethod]
        public void IsNotNull_Alternate()
        {
            try
            {
                Validate.Begin()
                    .IsNotNull<String>(null, "FieldName")
                    .Check();
                
                Assert.Fail("Test Fail");
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(true, "Test succeed");
            }
            catch (Exception)
            {

                Assert.Fail("Test Fail, an exeption has happend");
            }
        }

        [TestMethod]
        public void IsNotEmpty()
        {
            try
            {
                Validate.Begin()
                    .IsNotEmpty("String", "FieldName")
                    .Check();

                Assert.IsTrue(true, "Test succeed");
            }
            catch (ArgumentException ex)
            {
                Assert.Fail("Test Fail");
            }
            catch (Exception)
            {

                Assert.Fail("Test Fail, an exeption has happend");
            }
        }

        [TestMethod]
        public void IsNotEmpty_Alternate()
        {
            try
            {
                Validate.Begin()
                    .IsNotEmpty("", "FieldName")
                    .Check();

                Assert.Fail("Test Fail");
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(true, "Test succeed");
            }
            catch (Exception)
            {

                Assert.Fail("Test Fail, an exeption has happend");
            }
        }

        [TestMethod]
        public void IsEmail()
        {
            try
            {
                Validate.Begin()
                    .IsEmail("a@a.com", "FieldName")
                    .Check();

                Assert.IsTrue(true, "Test succeed");
            }
            catch (ArgumentException ex)
            {
                Assert.Fail("Test Fail");
            }
            catch (Exception)
            {

                Assert.Fail("Test Fail, an exeption has happend");
            }
        }

        [TestMethod]
        public void IsEmail_Alternate()
        {
            try
            {
                Validate.Begin()
                    .IsEmail("badEmail", "FieldName")
                    .Check();

                Assert.Fail("Test Fail");
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(true, "Test succeed");
            }
            catch (Exception)
            {

                Assert.Fail("Test Fail, an exeption has happend");
            }
        }

        [TestMethod]
        public void RegexTest()
        {
            try
            {
                //Letters Upercase and lower case and numbers and length from 8 to 16
                string regex = @"^[A-Za-z0-9]{8,16}$";
                Validate.Begin()
                    .RegexTest("ABCabc123", "FieldName",regex,"Regex Test Fail")
                    .Check();

                Assert.IsTrue(true, "Test succeed");
            }
            catch (ArgumentException ex)
            {
                Assert.Fail("Test Fail");
            }
            catch (Exception)
            {

                Assert.Fail("Test Fail, an exeption has happend");
            }
        }

        [TestMethod]
        public void RegexTest_Alternate()
        {
            try
            {
                //Letters Upercase and lower case and numbers and length from 8 to 16
                string regex = @"^[A-Za-z0-9]{8,16}$";
                Validate.Begin()
                    .RegexTest("ABCabc123!", "FieldName", regex, "Regex Test Fail")
                    .Check();

                Assert.Fail("Test Fail");
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(true, "Test succeed");
            }
            catch (Exception)
            {

                Assert.Fail("Test Fail, an exeption has happend");
            }
        }

        [TestMethod]
        public void IsEqual()
        {
            try
            {
                Validate.Begin()
                    .IsEqual("String Word", "String Word", "FieldName")
                    .Check();

                Assert.IsTrue(true, "Test succeed");
            }
            catch (ArgumentException ex)
            {
                Assert.Fail("Test Fail");
            }
            catch (Exception)
            {

                Assert.Fail("Test Fail, an exeption has happend");
            }
        }

        [TestMethod]
        public void IsEqual_Alternate()
        {
            try
            {
                Validate.Begin()
                    .IsEqual("String Word", "String Wordx", "FieldName")
                    .Check();

                Assert.Fail("Test Fail");
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(true, "Test succeed");
            }
            catch (Exception)
            {

                Assert.Fail("Test Fail, an exeption has happend");
            }
        }

       
    }
}
