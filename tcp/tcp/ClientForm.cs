using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;

namespace tcp
{
    public partial class ClientForm : Form
    {
        Socket client;
        byte[] buffer = new byte[1024];


        public ClientForm()
        {
            InitializeComponent();

            SetIPAddress();
        }

        private void SetIPAddress()
        {
            string hostName = Dns.GetHostName();
            IPHostEntry ipHost = Dns.GetHostEntry(hostName);
            txtIP.Text = ipHost.AddressList[ipHost.AddressList.Length - 1].ToString();
        }


        private void UpdateGUI(bool IsConnected)
        {
            btnConnect.Enabled = !IsConnected;
            btnSend.Enabled = IsConnected;
            lblStatus.Text = IsConnected ? "Connected" : "Disconnected";
            lblStatus.ForeColor = IsConnected ? Color.Green : Color.Red;
        }


        private void btnConnect_Click(object sender, EventArgs e)
        {
            // Connect to server
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            int portNum = int.Parse(txtPort.Text);
            IPAddress ip = IPAddress.Parse(txtIP.Text);
            client.Connect(new IPEndPoint(ip, portNum));

            UpdateGUI(true);

            WriteToLog("Connected to Server..." + Environment.NewLine);

            WaitingForData(client);
        }


        private void WaitingForData(Socket client)
        {
            client.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(OnReceive), null);
        }


        private void OnReceive(IAsyncResult ar)
        {
            client.EndReceive(ar);

            string msg = Encoding.Unicode.GetString(buffer);

            WriteToLog(msg);

            WaitingForData(client);
        }

        private void WriteToLog(string msg)
        {
            MethodInvoker invoker = new MethodInvoker(delegate { txtLog.AppendText("Server said: " + msg + Environment.NewLine); });
            this.BeginInvoke(invoker);
        }


        private void btnSend_Click(object sender, EventArgs e)
        {
            string msg = txtMsg.Text;
            buffer = Encoding.Unicode.GetBytes(msg);

            client.Send(buffer);
        }
    }
}
