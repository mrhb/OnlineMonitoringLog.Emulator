using CoAP.Examples.Resources;
using CoAP.Server;
using Emulator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoAp_Server
{
    public partial class ServerForm : Form
    {
        CoapServer server;
        public ServerForm()
        {
            InitializeComponent();

            var sdf = new IEC104ServerEmulator();
            // create a new server
             server = new CoapServer();


             for (int i = 0; i < 3;i++ )
             {
                 server.Add(new TimeOfDayResource("TimeOfDay"+i.ToString()));
             }
                 // add the resource to share
                 server.Add(new HelloWorldResource());
            server.Add(new TimeResource("ServerTime"));
            server.Add(new TimeOfDayResource("TimeOfDay"));

            // let the server fly
            server.Start();
        }

        private void ServerForm_Load(object sender, EventArgs e)
        {

        }
    }
}
