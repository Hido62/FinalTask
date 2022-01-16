using AventStack.ExtentReports;
using MarsCompTask2022.Pages;
using MarsCompTask2022.Utils;
using NUnit.Framework;
using System;

namespace MarsCompTask2022.NUnitTests
{
    [TestFixture]
    class ShareSkillTest : CommonDriver
    {
        [Test, Order(1), Description("Create the empty Share Skill record")]
        public void AddwithoutShareSkillTest()
        {
            test = extent.CreateTest("Create no Share Skill with Service Enabled");
            test.Log(Status.Info, "Browser Initialisation");

            // Login Page object initialization and definition
            LoginPage loginPageObj = new LoginPage(driver);

            loginPageObj.LoginSteps(driver);
            TestContext.WriteLine(loginPageObj);

            // Home Page object initialization and definition
            HomePage homePageObj = new HomePage();
            homePageObj.ShareSkillBtn(driver);

            //SaveScreenShotClass.SaveScreenshot1(testDriver, "TestShareSkill");
            test.Log(Status.Info, "Share Skill Page is Opened");

            // Share Skill Page object initialization and definition
            ShareSkill shareSkillObj = new ShareSkill(driver);

            shareSkillObj.AddwithoutData(driver);
            shareSkillObj.SaveShareSkill();
            test.Log(Status.Info, "ShareSkill is not Saved");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(35);
        }

        [Test, Order(2), Description("Create the invalid Share Skill record")]
        public void AddInvaildShareSkillTest()
        {
            test = extent.CreateTest("Create invalid Share Skill with Service Enabled");
            test.Log(Status.Info, "Browser Initialisation");

            // Login Page object initialization and definition
            LoginPage loginPageObj = new LoginPage(driver);

            loginPageObj.LoginSteps(driver);
            TestContext.WriteLine(loginPageObj);

            // Home Page object initialization and definition
            HomePage homePageObj = new HomePage();
            homePageObj.ShareSkillBtn(driver);

            //SaveScreenShotClass.SaveScreenshot1(testDriver, "TestShareSkill");
            test.Log(Status.Info, "Share Skill Page is Opened");

            // Share Skill Page object initialization and definition
            ShareSkill shareSkillObj = new ShareSkill(driver);

            shareSkillObj.AddInvaildTitle(driver);
            shareSkillObj.AddInvaildDescription(driver);
            shareSkillObj.AddInvalidEnterTags(driver);
            shareSkillObj.ServiceTypeHourly();
            shareSkillObj.LocationTypeOnline();
            shareSkillObj.AddInvalidAvailDays(driver);
            shareSkillObj.AddInvalidSkillExchange(driver);
            shareSkillObj.ActiveShareSkill();
            shareSkillObj.SaveShareSkill();
            test.Log(Status.Info, "ShareSkill is not Saved");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(35);
        }

        [Test, Order(3), Description("Create the valid Share Skill record")]
        public void CreateShareSkillTest()
        {
            test = extent.CreateTest("Create Share Skill with Service Enabled");
            test.Log(Status.Info, "Browser Initialisation");

            // Login Page object initialization and definition
            LoginPage loginPageObj = new LoginPage(driver);

            loginPageObj.LoginSteps(driver);
            TestContext.WriteLine(loginPageObj);

            // Home Page object initialization and definition
            HomePage homePageObj = new HomePage();
            homePageObj.ShareSkillBtn(driver);

            //SaveScreenShotClass.SaveScreenshot1(testDriver, "TestShareSkill");
            test.Log(Status.Info, "Share Skill Page is Opened");

            // Share Skill Page object initialization and definition
            ShareSkill shareSkillObj = new ShareSkill(driver);

            shareSkillObj.AddTitle(driver);
            shareSkillObj.AddDescription(driver);
            shareSkillObj.SelectAddCategory(driver);
            shareSkillObj.SelectAddSubCategory(driver);
            shareSkillObj.AddEnterTags(driver);
            shareSkillObj.ServiceTypeHourly();
            shareSkillObj.LocationTypeOnline();
            shareSkillObj.AddAvailableDays(driver);
            shareSkillObj.SkillExchange(driver);
            shareSkillObj.ActiveShareSkill();
            shareSkillObj.SaveShareSkill();
            test.Log(Status.Info, "ShareSkill is Saved");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(35);

            // Manage Listings Page object initialization and definition
            ManageListings manageListsObj = new ManageListings(driver);
            manageListsObj.AddManageListingsActive(driver);
            test.Log(Status.Pass, "Assert Pass as condition is True & Manage listing is active");
        }

        [Test, Order(4), Description("Edit the valid Share Skill record")]
        public void EditShareSkillTest()
        {
            test = extent.CreateTest("Edit Share Skill with Skill Trade as Skill Exchange and change it to Credit");
            test.Log(Status.Info, "Browser Initialisation");

            // Login Page object initialization and definition
            LoginPage loginPageObj = new LoginPage(driver);
            loginPageObj.LoginSteps(driver);

            // Manage Listings Page object initialization and definition
            ManageListings manageListsObj = new ManageListings(driver);
            manageListsObj.NavigateManageListings();
            manageListsObj.EditManageListings();

            // Share Skill Page object initialization and definition
            ShareSkill shareSkillObj = new ShareSkill(driver);

            test.Log(Status.Info, "Share Skill Page is Opened");

            shareSkillObj.EditTitle(driver);
            shareSkillObj.EditDescription(driver);
            shareSkillObj.SelectEditCategory(driver);
            shareSkillObj.SelectEditSubCategory(driver);
            shareSkillObj.EditTags(driver);
            shareSkillObj.ServiceTypeOne_off();
            shareSkillObj.LocationTypeOnsite();
            shareSkillObj.EditAvailableDays(driver);
            shareSkillObj.EditCreditExchange(driver);
            shareSkillObj.HiddenShareSkill();
            shareSkillObj.SaveShareSkill();
            test.Log(Status.Info, "ShareSkill is Saved");

            manageListsObj.EditManageListingsHidden(driver);
            test.Log(Status.Pass, "Assert Pass as condition is True and Manage listing is Hidden");
        }
    }
}
