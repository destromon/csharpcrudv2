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
    public partial class frmOrder : Form
    {
        //instantiate model
        Order order = new Order();

        //list
        List<Order> orders = new List<Order>();


        public void Render()
        {
            //clear the list
            orders.Clear();

            //fire the load method from the order object
            orders = order.Read();

            //clear listview
            listView1.Items.Clear();

            foreach (Order item in orders)
            {
                listView1.Items.Add(item.Id.ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(item.Nickname);
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(item.Type);
            }
        }
        public frmOrder()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.ShowDialog();

            Render();
        }

        private void frmOrder_Load(object sender, EventArgs e)
        {
            Render();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //set object id
            order.Id = int.Parse(listView1.SelectedItems[0].Text);

            order.Delete();

            this.Render();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Edit(int.Parse(listView1.SelectedItems[0].Text));
            form1.ShowDialog();
        }
    }
}
