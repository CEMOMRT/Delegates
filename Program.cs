using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Delegates
{
    class Program
    {
        public delegate void MyDelegate();//Parametre almayan void yapılara delegate ediyor.
        public delegate void MyDelegate2(string text);
        public delegate int MyDelegate3(int number1, int number2);
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            //customerManager.SendMessage();
            //customerManager.ShowAlert();

            MyDelegate myDelegate = customerManager.SendMessage;
            myDelegate += customerManager.ShowAlert;
            //myDelegate -= customerManager.SendMessage; //Yapılan işlemi geri alıyor.
            myDelegate();

            MyDelegate2 myDelegate2 = customerManager.SendMessage2;
            myDelegate2 += customerManager.ShowAlert2;
            myDelegate2("Hallo");//İkisine birden atar

            MathClass mathClass = new MathClass();
            MyDelegate3 myDelegate3 = mathClass.Toplam;
            myDelegate3 += mathClass.Carpım;//Bu işlemi göstermesinin sebebi son atanan return değer budur.
            int sonuc = myDelegate3(4, 5);
            Console.WriteLine(sonuc);

            //Action delegates örneğini exception ile kullanıldı.

            Func<int, int, int> add = Toplam;//Son parametre her zaman out bilgiyi temsil eder.
            Console.WriteLine(add(8, 14));

            /*Func<int> getRandomNumber = delegate ()//Parametresiz int sonuç döndüren işlemler için
            {
                Random random = new Random();
                random.Next(1, 100);
            };*/
            Func<int> getRandomNumber = () => new Random().Next(1, 100);
            Thread.Sleep(1000);//Sistemin bili bir saniye beklemesini sağlıyor.
            Console.WriteLine(getRandomNumber());

            Console.ReadLine();
        }
        static int Toplam(int sayi1,int sayi2)
        {
            return sayi1 + sayi2;
        }
    }
    public class CustomerManager
    {
        public void SendMessage()
        {
            Console.WriteLine("Hello guys!");
        }
        public void ShowAlert()
        {
            Console.WriteLine("Attention!");
        }
        public void SendMessage2(string message)
        {
            Console.WriteLine(message);
        }
        public void ShowAlert2(string alert)
        {
            Console.WriteLine(alert);
        }
    }
    public class MathClass
    {
        public int Toplam(int sayi1, int sayi2)
        {
            return sayi1 + sayi2;
        }
        public int Fark(int sayi1, int sayi2)
        {
            return sayi1 - sayi2;
        }
        public int Carpım(int sayi1, int sayi2)
        {
            return sayi1 * sayi2;
        }
    }    
}
