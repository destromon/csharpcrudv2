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
    public partial class Form1 : Form
    {
        //instantiate model
        Order order = new Order();

        List<Order> orders = new List<Order>();

        public void Edit(int id)
        {
            //set property
            order.Id = id;

            //issue a query
            orders = order.GetById();

            //display the details on the textboxes
            textBox2.Text = orders[0].Nickname;
            textBox3.Text = orders[0].Type;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            order.Nickname = textBox2.Text;
            order.Type = textBox3.Text;

            order.Save();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmConfig frmConfig = new frmConfig();
            frmConfig.Show();
        }
    }
}
