using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace SocketEX01_Form
{
    /// <summary>
    /// C# Sockets Going Async - Server 1/2
    ///     https://www.youtube.com/watch?v=PCwS7F2uK3Q&list=PLAC179D21AF94D28F&index=10
    /// C# Sockets Going Async - Client 2/2
    ///     https://www.youtube.com/watch?v=bbT4IzCoQjs&list=PLAC179D21AF94D28F&index=10
    /// 
    /// </summary>
    public partial class Form1 : Form
    {
        Listener listener;
        Client client;

        public Form1()
        {
            InitializeComponent();

            btnListen.Click += BtnListen_Click;
            btnClose.Click += BtnClose_Click;
            FormClosing += Form1_FormClosing;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (client != null)
            {
                client.Close();
            }

            if (listener != null && listener.Runing)
            {
                listener.Stop();
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            if (client != null)
            {
                client.Close();
                client = null;
            }

            lblInfo.Text = "Connected: Null";
            lstText.Items.Clear();
            //pbImage.Image = null;
        }

        private void BtnListen_Click(object sender, EventArgs e)
        {
            listener = new Listener();
            listener.Accepted += new Listener.SocketAcceptedHandler(Listener_Accepted);
            listener.Start(6666);
        }

        private void Listener_Accepted(Socket e)
        {
            if (client != null)
            {
                e.Close();
                return;
            }
            client = new Client(e);
            client.DataRecieved += Client_DataRecieved;
            client.Disconnected += Client_Disconnected;
            client.ReceiveAsync();
            Invoke((MethodInvoker)delegate
            {
                lblInfo.Text = "Connected: " + client.EndPoint.ToString();
            });
        }

        private void Client_Disconnected(Client sender)
        { //連接客戶端關閉時
            client.Close();
            client = null;
            Invoke((MethodInvoker)delegate
            {
                lblInfo.Text = "Connected: NULL";
                DialogResult res = MessageBox.Show("Client Disconnected\nClear Data?", "", MessageBoxButtons.YesNo);
                if (res == System.Windows.Forms.DialogResult.Yes)
                {
                    lstText.Items.Clear();
                    pbImage.Image = null;
                }
            });
        }

        private void Client_DataRecieved(Client sender, ReceiveBuffer e)
        {
            BinaryReader r = new BinaryReader(e.BufStream);
            Commands header = (Commands)r.ReadInt32();
            switch (header)
            {
                case Commands.String:
                    {
                        string s = r.ReadString();
                        Invoke((MethodInvoker)delegate
                        {
                            lstText.Items.Add(s);
                        });
                    }
                    break;
                case Commands.Image:
                    {
                        /*
                        Invoke((MethodInvoker)delegate
                        {
                            
                            if (pbImage.Image != null)
                            {
                                pbImage.Dispose();
                            }
                        });*/

                        int imageBytesLen = r.ReadInt32();
                        byte[] iBytes = r.ReadBytes(imageBytesLen);
                        //*
                        Invoke((MethodInvoker)delegate
                        {
                            pbImage.Image = Image.FromStream(new MemoryStream(iBytes));
                        });//*/

                        iBytes = null;
                    }
                    break;
                default:

                    break;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

