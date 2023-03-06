using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace HttpClientEx01
{
    class Program
    {
        
        static void Main(string[] args)
        {
            httpEx01(); //讀取網頁原始碼-> 下載 JSON 檔內容(同 WebClient 製作)
            Console.ReadKey();
        }


        public static async void httpEx01()
        { //[異步]讀取網頁原始碼-> 下載 JSON 檔內容(同 WebClient 製作)
            /* C# Tutorial: Http Client https://www.youtube.com/watch?v=3d96CVSoSxM
            */
            await GetTodoItems();
        }
        public static async Task GetTodoItems()
        { //[異步]讀取網頁原始碼-> 下載 JSON 檔內容(同 WebClient 製作)
            HttpClient client = new HttpClient();
            string str = await client.GetStringAsync("http://192.168.1.100");
            //string str = await client.GetStringAsync("http://ip.jsontest.com/?callback=showMyIP");
            Console.WriteLine(str);
        }





    }
}
