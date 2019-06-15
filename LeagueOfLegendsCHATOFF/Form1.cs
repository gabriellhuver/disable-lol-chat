using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net.NetworkInformation;
namespace LeagueOfLegendsCHATOFF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            doCommand("netsh advfirewall firewall delete rule name=\"lolchat\"");
        }

        public static void doCommand(String cmd)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/c " +cmd;
            startInfo.Verb = "runas";
            process.StartInfo = startInfo;
            process.Start();
            
           
        }

    public static PingReply PingHost(string nameOrAddress)
    {
        bool pingable = false;
        Ping pinger = null;
            PingReply reply = null;
        try
        {
            pinger = new Ping();
                reply = pinger.Send(nameOrAddress);
            pingable = reply.Status == IPStatus.Success;
        }
        catch (PingException)
        {
            // Discard PingExceptions and return false;
        }
        finally
        {
            if (pinger != null)
            {
                pinger.Dispose();
            }
        }

        return reply;
    }

        private void button2_Click(object sender, EventArgs e)
        {
            doCommand("netsh advfirewall firewall add rule name=\"lolchat\" dir=out remoteip=66.151.33.22 protocol=TCP action=block");

        }
    }
}
