using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebBrowserEx02_Form_ChromiumBrowser
{
    /// <summary>
    /// cefsharp
    /// C# Tutorial - Chromium Browser with Tabs using CefSharp | FoxLearn
    ///     https://www.youtube.com/watch?v=itpEj1yB_Tg
    ///     https://cefsharp.github.io/api/75.1.x/html/T_CefSharp_WinForms_ChromiumWebBrowser.htm
    ///     https://github.com/cefsharp/CefSharp
    /// [食譜好菜] CefSharp 把 Google Chrome 的核心 Chromium 變成了 WinForms/WPF 的控制項
    ///     https://dotblogs.com.tw/supershowwei/2022/06/06/cefsharp-turns-google-chrome_s-core-chromium-into-a-winforms-wpf-control
    /// 失敗
    /// </summary>
    public partial class frmChromiumBrowser : Form
    {
        public frmChromiumBrowser()
        {
            InitializeComponent();
        }

        private void frmChromiumBrowser_Load(object sender, EventArgs e)
        {
            txt_Url.Text = "https://www.google.com";
            chromiumWebBrowser = new CefSharp.WinForms.ChromiumWebBrowser(txt_Url.Text);
            chromiumWebBrowser.Dock = DockStyle.Fill;
            //chromiumWebBrowser.TitleChanged += ChromiumWebBrowser_TitleChanged;
            //chromiumWebBrowser.Load(txt_Url.Text);
            chromiumWebBrowser.LoadUrl(txt_Url.Text);
        }

        private void ChromiumWebBrowser_TitleChanged(object sender, CefSharp.TitleChangedEventArgs e)
        {
            this.Invoke(new MethodInvoker(()=> {
                txt_Url.Text = e.Title;
            }));
        }

        private void btnGo_Google_Click(object sender, EventArgs e)
        {
            txt_Url.Text = "https://www.youtube.com/";
            //chromiumWebBrowser.Load(txt_Url.Text);
            chromiumWebBrowser.LoadUrl(txt_Url.Text);
           
        }
    }
}
