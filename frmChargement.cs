using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GP
{
    public partial class frmChargement : Form
    {
        public frmChargement()
        {
            InitializeComponent();
        }

        public frmChargement(int i)
        {
            InitializeComponent();
            progressBar1.Visible = false;
            timer1.Enabled = false;
            this.KeyUp += delegate
            {
                this.Close();
            };
            this.Click += delegate
            {
                this.Close();
            };
            pictureBox1.Click += delegate
            {
                this.Close();
            };
        }

        private void frmChargement_Load(object sender, EventArgs e)
        {
            string connString = ConfigSettings.ReadSetting("connString");
            string PrefixFacture = ConfigSettings.ReadSetting("prefixFacutre");
            string PremierFacture = ConfigSettings.ReadSetting("firstFacutre");
            string PrefixClient = ConfigSettings.ReadSetting("prefixClient");
            string Printer = ConfigSettings.ReadSetting("Printer");
            string Page = ConfigSettings.ReadSetting("Page");
            string NbTicket = ConfigSettings.ReadSetting("NbTicket");
            string maxPressing = ConfigSettings.ReadSetting("MaxPressing");
            string maxRepassage = ConfigSettings.ReadSetting("MaxRepassage");
            string maxTenture = ConfigSettings.ReadSetting("MaxTenture");
            string maxAutre = ConfigSettings.ReadSetting("MaxAutre");
            GlobalVars.maxAutre = maxAutre != null ? maxAutre : "#";
            GlobalVars.maxPressing = maxPressing != null ? maxPressing : "#";
            GlobalVars.maxRepassage = maxRepassage != null ? maxRepassage : "#";
            GlobalVars.maxTenture = maxTenture != null ? maxTenture : "#";
            GlobalVars.connString = connString != null ? connString : string.Empty;
            GlobalVars.PrefixFacture = PrefixFacture != null ? PrefixFacture : "F";
            GlobalVars.PremierFacture = PremierFacture != null ? PremierFacture : "0";
            GlobalVars.PrefixClient = PrefixClient != null ? PrefixClient : "C";
            GlobalVars.namePrinter = Printer != null ? Printer : string.Empty;
            GlobalVars.page = Page != null ? Page : string.Empty;
            GlobalVars.nombreCopieTicket = NbTicket != null ? NbTicket : string.Empty;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < 100)
            {
                this.progressBar1.Value += 5;
            }
            else
            {
                this.timer1.Enabled = false;
                this.Close();
            }
        }
    }
}