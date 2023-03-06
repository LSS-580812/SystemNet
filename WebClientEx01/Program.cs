using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace WebClientEx01
{
    /// <summary>
    /// System.Net 命名空間 https://learn.microsoft.com/zh-tw/dotnet/api/system.net?view=netframework-4.8
    /// WebClient 類別 https://learn.microsoft.com/zh-tw/dotnet/api/system.net.webclient?view=netframework-4.8
    /// 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            getWebCode("https://tw.piliapp.com/vat-calculator/tw/search/");
            //getWebCode("http://192.168.1.100");
            Console.ReadKey();
        }

        public static void getWebCode(string url)
        { //讀取網頁原始碼-> 下載 JSON 檔內容(建議使用 HttpClient)
            WebClient client = new WebClient();
            string strWebCode = client.DownloadString(url);
            Console.WriteLine(strWebCode);
        }
    }
}
