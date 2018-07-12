using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace KeytorcSeleniumProject
{
    class Program
    {
        static IWebDriver driver;
        
        static string link = @"https://www.n11.com/";
        static void Main(string[] args)
        {
            driver = new FirefoxDriver();
            driver.Navigate().GoToUrl(link);

            Program pg = new Program();
            driver.FindElement(By.ClassName("btnSignIn")).Click();
            driver.FindElement(By.XPath("//*[@id='email']")).SendKeys("-email-"); //Kayıtlı bir e mail adresi yazilmalidir
            driver.FindElement(By.Id("password")).SendKeys("-password-"); //Kayitli bir password yazilmalidir.
            driver.FindElement(By.Id("loginButton")).Click();
            pg.SearchSamsung();
            pg.ShowSecondPage();
            pg.AddToFavorite();
            pg.OpenFavoriteList();
            pg.DeleteProductToFavoriteList();
           
        }
      
        public void SearchSamsung()
        {
            driver.FindElement(By.Id("searchData")).SendKeys("samsung"); //SAMSUNG TEXT ARAMA
            Console.WriteLine("SAMSUNG için bulunan sonuçlar gosteriliyor...");
            driver.FindElement(By.ClassName("searchBtn")).Click();  //SAMSUNG ARAMA TIKLAMA
        }

        public void ShowSecondPage()
        {
            driver.FindElement(By.XPath(".//*[@id= 'contentListing']/div/div/div[2]/div[3]/a[2]")).Click();//2.SAYFA ACILMASI ICIN CALISAN SATIR
            Console.WriteLine("2.Sayfa sonuçları gosteriliyor");
        }

        public void AddToFavorite()
        {
            driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div[2]/section[2]/div[2]/ul/li[3]/div/div[2]/span")).Click(); //FAVORILERE EKLEME ICIN CALISAN SATIR
        }

        public void OpenFavoriteList()
        {
            driver.FindElement(By.XPath("/html/body/div[1]/header/div/div/div[2]/div[2]/div[2]/div[1]/a[1]")).Click();//HESABIM A TIKLAMA OLAYI
            driver.FindElement(By.XPath("/html/body/div[1]/div/div/div[2]/div[1]/div[1]/div[2]/ul/li[6]/a")).Click();//FAVORI SEKMESINI AÇMA

            driver.FindElement(By.XPath("/html/body/div[1]/div/div/div[2]/div[3]/ul/li[1]/div/a/h4")).Click(); //FAVORI LISTESINI AÇMA
            Console.WriteLine("FAVORİLERE eklenen ürün listenin başında gosterilmektedir.");
        }

        public void DeleteProductToFavoriteList()
        {
            
            driver.FindElement(By.XPath("/html/body/div[1]/div/div/div[2]/div[3]/div[1]/div[2]/ul/li[1]/div/div[3]/span")).Click(); //FAVORI SILME
            Console.WriteLine("Urun Favorilerden silindi");
            driver.FindElement(By.XPath("/html/body/div[5]/div/div/span")).Click();//SILINEN URUN ICIN GELEN ONAY KUTUCUGUNDAKI TAMAM A TIKLAMA OLAYI
            Console.WriteLine("Sİlinen urun artık Favorilerde değil");
        }

    }
}
