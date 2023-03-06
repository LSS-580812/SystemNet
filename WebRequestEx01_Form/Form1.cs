using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace WebRequestEx01_Form
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        { //How to Call External API in C# https://www.youtube.com/watch?v=gW507cOiTRw
            string strHttp = string.Format("http://192.168.1.100");
            //string strHttp = string.Format("https://jsonplaceholder.typicode.com/posts/1/comments");
            WebRequest request = WebRequest.Create(strHttp);
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (Stream stream= response.GetResponseStream())
            {
                StreamReader sr = new StreamReader(stream);
                string strResult = sr.ReadToEnd();
                label1.Text = strResult;
                sr.Close();
            }

        }
    }
}
