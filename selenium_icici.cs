/*
 * Open visual studio new project, search for xUnit project with c# and create
 * check required packages are installed 
 * 
 * <Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>net6.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>

    <IsPackable>false</IsPackable>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Microsoft.NET.Test.Sdk" Version="17.1.0" />
    <PackageReference Include="Selenium.WebDriver" Version="4.3.0" />
    <PackageReference Include="Selenium.WebDriver.ChromeDriver" Version="103.0.5060.5300" />
    <PackageReference Include="xunit" Version="2.4.1" />
    <PackageReference Include="xunit.runner.visualstudio" Version="2.4.3">
      <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
      <PrivateAssets>all</PrivateAssets>
    </PackageReference>
    <PackageReference Include="coverlet.collector" Version="3.1.2">
      <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
      <PrivateAssets>all</PrivateAssets>
    </PackageReference>
  </ItemGroup>

</Project>
 */






using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace IciciBankProject
{
    public class UnitTest1 : IDisposable
    {
        private IWebDriver _driver;
        // Got a build error when below constructor name is not same as class name
        public UnitTest1()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
        }

        [Fact]
        public void ToOpen_IciciBankMainPage()
        {
            _driver.Navigate().GoToUrl("https://www.icicibank.com/");
            Assert.Equal("Personal Banking & Netbanking Services Online - ICICI Bank", _driver.Title);
            
            var clickLaterButton = _driver.FindElement(By.Id("push-modal-close"));
            clickLaterButton.Click();

            var clickLoginButton = _driver.FindElement(By.Id("login-btn"));
            clickLoginButton.Click();
            Assert.Equal("Log in to Internet Banking", _driver.Title);
        }
        
        public void Dispose()
        {
            _driver.Quit();
        }
    }
}
