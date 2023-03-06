using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;


namespace SocketEX01
{
    class Listener
    {
        public delegate void SocketAcceptedHandler(Socket e);
        public event SocketAcceptedHandler Accepted;

        Socket listener;
        public int Port { get; set; }

        public bool Runing
        {
            get;
            private set;
        }

        public Listener() { Port = 0; }

        public void Start(int port)
        {
            if (Runing)
            {
                return;
            }
            listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            listener.Bind(new IPEndPoint(IPAddress.Any, port));
            listener.Listen(0);

            listener.BeginAccept(acceptedCallback, null);
            Runing = true;
        }

        public void Stop()
        {
            if (!Runing)
            {
                return;
            }
            listener.Close();
            Runing = false;
        }

        void acceptedCallback(IAsyncResult ar)
        {
            try
            {
                Socket s = listener.EndAccept(ar);
                if (Accepted != null)
                {
                    Accepted(s);
                }
            }
            catch (Exception)
            {

                //throw;
            }

            if (Runing)
            {
                try
                {
                    listener.BeginAccept(acceptedCallback, null);
                }
                catch (Exception)
                {

                    //throw;
                }
            }
        }

    }
}
