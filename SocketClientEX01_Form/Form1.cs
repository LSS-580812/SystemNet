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
using System.Net.Sockets;
using System.IO;

namespace SocketClientEX01_Form
{
    public partial class Form1 : Form
    {
        Client client;
        public Form1()
        {
            InitializeComponent();
            btnDisconnect.Click += BtnDisconnect_Click;
            btnImage.Click += BtnImage_Click;
            btnSendText.Click += BtnSendText_Click;
            btnConnect.Click += BtnConnect_Click;
            client = new Client();
            client.OnConnect += Client_OnConnect;
            client.OnSend += Client_OnSend;
            client.OnDisconnect += Client_OnDisconnect;
        }

        private void Client_OnDisconnect(Client sender)
        {
            MessageBox.Show("Disconnected:");
        }

        private void Client_OnSend(Client sender, int sent)
        {
            Invoke((MethodInvoker)delegate
            {
                lblDataSent.Text = string.Format("Data Sent{0}", sent);
            });
        }

        private void Client_OnConnect(Client sender, bool connected)
        {
            if (connected)
            {
                MessageBox.Show("Connected Accepted");
            }
        }

        private void BtnConnect_Click(object sender, EventArgs e)
        {
            if (!client.Connected)
            {
                client.Connect("127.0.0.1", 6666);
            }
        }

        private void BtnSendText_Click(object sender, EventArgs e)
        {
            SendText(txtBox1.Text);
            txtBox1.Text = "Ok";
        }

        private void BtnImage_Click(object sender, EventArgs e)
        {
            using(OpenFileDialog o = new OpenFileDialog())
            {
                o.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                if (o.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    SendImage(o.FileName);
                }
            }
        }

        private void BtnDisconnect_Click(object sender, EventArgs e)
        {
            client.Disconnect();
        }

        void SendText(string text)
        {
            BinaryWriter bw = new BinaryWriter(new MemoryStream());
            bw.Write((int)Commands.String);
            bw.Write(text);
            bw.Close();
            byte[] data = ((MemoryStream)bw.BaseStream).ToArray();
            bw.BaseStream.Dispose();
            client.Send(data, 0, data.Length);
            data = null;
            lblDataSent.Text = text;
        }

        void SendImage(string path)
        {
            MemoryStream ms = new MemoryStream();
            BinaryWriter bw = new BinaryWriter(ms);
            byte[] b = File.ReadAllBytes(path);
            bw.Write((int)Commands.Image);
            bw.Write((int)b.Length);
            bw.Close();
            b = ms.ToArray();
            ms.Dispose();

            client.Send(b, 0, b.Length);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
