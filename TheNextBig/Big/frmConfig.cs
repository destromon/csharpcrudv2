using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Big
{
    public partial class frmConfig : Form
    {
        public frmConfig()
        {
            InitializeComponent();
        }

        private void GetServerSettings()
        {
            txtDSN.Text = Big.Config.DSN;
            txtHost.Text = Big.Config.DB_HOST;
            txtName.Text = Big.Config.DB_NAME;
            txtUser.Text = Big.Config.DB_USER;
            txtPassword.Text = Big.Config.DB_PASSWORD;
        }

        private void btnSaveConfiguration_Click(object sender, EventArgs e)
        {
           
                //set properties
                Big.Config.DSN = txtDSN.Text;
                Big.Config.DB_HOST = txtHost.Text;
                Big.Config.DB_NAME = txtName.Text;
                Big.Config.DB_USER = txtUser.Text;
                Big.Config.DB_PASSWORD = txtPassword.Text;

                //save settings
                Big.Config.saveSettings();

                if (Big.Config.TestConnection())
                {
                    MessageBox.Show("Server database configuration has been successfully updated", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
          

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void frmConfig_Load(object sender, EventArgs e)
        {
            this.GetServerSettings();
        }
    }
}
