using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WebBrowserEx01_Form
{
    public partial class frmWebBrowser : Form
    {
        /// <summary>
        /// C# Tutorial - How to create a Web Browser https://www.youtube.com/watch?v=l66AAoBf6yE
        /// </summary>
        public frmWebBrowser()
        {
            InitializeComponent();
        }

        private void txt_Url_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                GoUrl();
            }
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            webBrowser.GoBack();
        }

        private void btn_Forward_Click(object sender, EventArgs e)
        {
            webBrowser.GoForward();
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            webBrowser.Refresh();
        }

        private void btn_Go_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_Url.Text))
            {
                GoUrl();
            }
        }

        private void btnGo_Google_Click(object sender, EventArgs e)
        {
            txt_Url.Text = "https://www.youtube.com/";
            GoUrl();
        }

      
        private void GoUrl()
        {
            
            webBrowser.Navigate(txt_Url.Text);
        }
    }
}
