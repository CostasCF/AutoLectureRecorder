using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Net;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using System.Windows.Forms;
using OpenQA.Selenium.Interactions;

namespace Auto_Lecture_Recorder.BotController
{
    partial class ChromeBot
    {
        const string cookieFileName = "profile.alr";

        public string teamsHomePagetUrl = "https://teams.microsoft.com/_#/school//?ctx=teamsGrid";
        public bool onMeeting = false;

        public void AuthenticateUser(string AM, string password)
        {
            try
            {
                HideBrowser = true;
                StartDriver();

                //-----------------------------------Microsoft's Login Page-----------------------------------
                driver.Url = "https://login.microsoftonline.com/common/oauth2/authorize?response_type=id_token&client_id=5e3ce6c0-2b1f-4285-8d4b-75ee78787346&redirect_uri=https%3A%2F%2Fteams.microsoft.com%2Fgo&state=19b0dc60-3d5f-467f-9ee1-3849f5ae7e58&&client-request-id=75367383-e3e7-480f-a14f-faf664ccea61&x-client-SKU=Js&x-client-Ver=1.0.9&nonce=29792698-73cd-457e-977e-e23d8843a8f0&domain_hint=";

                // Turn everything to lower case because capital letters create problems
                string temp = AM.ToLower();
                AM = temp;

                //Filling email at Microsoft's login page
                IWebElement emailInputBox = driver.FindElement(By.Id("i0116"));
                emailInputBox.SendKeys(AM + "@unipi.gr");

                //Click NextBtn at Microsoft's login page
                IWebElement nextEmailBtn = driver.FindElement(By.Id("idSIButton9"));
                nextEmailBtn.Click();

                SaveCookiesToList();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

                //-----------------------------------Unipi page-----------------------------------
                //Filling UNIPI form
                IWebElement usernameUnipiInputBox = driver.FindElement(By.Id("username"));
                usernameUnipiInputBox.SendKeys(AM);
                IWebElement passwordUnipiInputBox = driver.FindElement(By.Id("password"));
                passwordUnipiInputBox.SendKeys(password);

                //Login button
                IWebElement loginUnipiBtn = driver.FindElement(By.Id("submitForm"));
                loginUnipiBtn.Click();

                SaveCookiesToList();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

                //Stay sign in page
                IWebElement NoStaySignInBtn = driver.FindElement(By.Id("idSIButton9"));
                NoStaySignInBtn.Click();

                SaveCookiesToList();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

                //Serialize cookieList
                SaveCookiesToFile(cookiesList);

                TerminateDriver();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occured while authenticating user: " + ex.Message);
            }
        }

        public void ConnectToMeetingByName(string name)
        {
            try
            {
                if (driver == null || !isDriverRunning)
                {
                    StartDriver();
                    LoadCookies(null, cookieFileName);
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                }
                else
                {
                    if (!driver.Url.Equals(teamsHomePagetUrl))
                    {
                        if (onMeeting) LeaveMeeting();
                        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                        driver.Url = teamsHomePagetUrl;
                    }
                }
                Thread.Sleep(3000);

                //Clicking to specific team
                IWebElement lessonCardBtn = driver.FindElement(By.XPath("//div[contains(@data-tid, '" + name + "')]"));
                lessonCardBtn.Click();

                //Loop until Join button appears
                /*bool isJoined = false;
                while (!isJoined)
                {
                    try
                    {
                        IWebElement joinCallBtn = driver.FindElement(By.XPath("//button[contains(@data-tid, 'join-btn')]"));
                        joinCallBtn.Click();
                        isJoined = true;
                    }
                    catch
                    {
                        Console.WriteLine("Should refresh");
                        isJoined = false;
                        RefreshCurrentPage();
                    }
                }

                IWebElement noAudioMicBtn = driver.FindElement(By.XPath("//button[contains(@track-summary, 'Continue in call/meetup without device access')]"));
                noAudioMicBtn.Click();

                IWebElement preJoinCallBtn = driver.FindElement(By.XPath("//button[contains(@data-tid, 'prejoin-join-button')]"));
                preJoinCallBtn.Click();*/

                onMeeting = true;
            }   
            catch (Exception ex)
            {            
                TerminateDriver();
                Console.WriteLine("An error occured while authenticating user: " + ex.Message);
                throw ex;
            }
        }

        public void LeaveMeeting()
        {
            if (!onMeeting) return;
            onMeeting = false;
        }

        public int GetParticipantsNumber()
        {
            if (!onMeeting) return 0;

            int participants = 0;
            IWebElement showParticipantsBtn = driver.FindElement(By.Id("roster-button"));
            try
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

                var participantsList = driver.FindElements(By.XPath("//li[contains(@data-tid, 'participantsInCall')]"));
                foreach (var p in participantsList)
                    participants++;

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(waitTime);

                return participants;
            }
            catch
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(waitTime);

                //Simulating the mouse hover to toggle the toolbar
                Actions actions = new Actions(driver);
                actions.MoveToElement(showParticipantsBtn).Perform();
                showParticipantsBtn.Click();

                //Creating a list with all the participants
                var participantsList = driver.FindElements(By.XPath("//li[contains(@data-tid, 'participantsInCall')]"));
                foreach (var p in participantsList)
                    participants++;

                return participants;
            }      
        }

        public List<string> GetMeetings()
        {
            if (driver == null || !isDriverRunning)
            {
                HideBrowser = true;
                StartDriver();
                LoadCookies(null, cookieFileName);
            }
            else
            {
                if (!driver.Url.Equals(teamsHomePagetUrl))
                {                    
                    driver.Url = teamsHomePagetUrl;
                }
            }
            Thread.Sleep(10000);

            List<string> meetingsList = new List<string>();            
            //Locate card's grid
            IWebElement masterBlock = driver.FindElement(By.XPath("//div[contains(@data-tid, 'team-favorite-group')]"));
            //Get all cards
            var cardBlocks = masterBlock.FindElements(By.ClassName("team-card"));
            foreach(var card in cardBlocks)
            {                
                var tempList = card.FindElement(By.ClassName("team-name-text"));
                meetingsList.Add(tempList.Text);
            }
            TerminateDriver();

            return meetingsList;
        }
    }
}