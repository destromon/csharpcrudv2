using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Big
{
    class Order
    {
        /****************************************
         * Private Properties
         * ***************************************/

        /****************************************
         * Protected Properties
         * ***************************************/
        protected int id;
        protected string nickname;
        protected string type;

        List<Order> orders = new List<Order>();

        /****************************************
         * Public Properties
         * ***************************************/
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Nickname
        {
            get { return nickname; }
            set { nickname = value; }
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        /****************************************
         * Constructor
         * ***************************************/

        /****************************************
         * Private Methods
         * ***************************************/

        /****************************************
         * Protected Methods
         * ***************************************/

        /****************************************
         * Public Methods
         * ***************************************/
        /// <summary>
        /// Insert the record on the table Order
        /// </summary>
        public void Save()
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(Big.Config.GetConnectionString()))
                {
                    //open connection
                    con.Open();

                    //set query string
                    string sql = "INSERT INTO order_taker(nickname, type) VALUES(@nick, @type)";

                    MySqlCommand cmd = new MySqlCommand(sql, con);

                    //set parameters
                    cmd.Parameters.AddWithValue("nick", this.nickname);
                    cmd.Parameters.AddWithValue("type", this.type);

                    //execute query

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Ang galing non a");

                }
            }
            catch(MySqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        public List<Order> Read()
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(Big.Config.GetConnectionString()))
                {
                    //open the conneciton
                    con.Open();

                    //set query string
                    string sql = "SELECT * FROM order_taker WHERE active = 1";

                    //prepare connection and query string
                    MySqlCommand cmd = new MySqlCommand(sql, con);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Order order = new Order();

                        order.id = int.Parse(reader["id"].ToString());
                        order.nickname = reader["nickname"].ToString();
                        order.type = reader["type"].ToString();

                        orders.Add(order);
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            return orders;
        }

        public void Delete()
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(Big.Config.GetConnectionString()))
                {
                    //open the conneciton
                    con.Open();

                    //set query string
                    string sql = "UPDATE order_taker set active = 0 WHERE id = @id";

                    //prepare connection and query string
                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    
                    //set parameters
                    cmd.Parameters.AddWithValue("id", id);

                    //execute command
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Na-delete na.");
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        public List<Order> GetById()
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(Big.Config.GetConnectionString()))
                {
                    //open the conneciton
                    con.Open();

                    //set query string
                    string sql = "SELECT * FROM order_taker WHERE id = @id";

                    //prepare connection and query string
                    MySqlCommand cmd = new MySqlCommand(sql, con);

                    //add parameters
                    cmd.Parameters.AddWithValue("id", id);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Order order = new Order();

                        order.id = int.Parse(reader["id"].ToString());
                        order.nickname = reader["nickname"].ToString();
                        order.type = reader["type"].ToString();

                        orders.Add(order);
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            return orders;
        }
    }
}
