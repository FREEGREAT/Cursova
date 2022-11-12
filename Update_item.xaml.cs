using System;
using System.Windows;
using System.Data;
using MySql.Data.MySqlClient;

namespace WpfApp1
{

    public partial class Update_item : Window
    {

        public Update_item()
        {
            InitializeComponent();
        }
        private MySqlConnection con = new MySqlConnection("server=localhost;port=3306;user=root;password=;database=store");
        private MySqlCommand cmd;

        private void addRecord_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                string ID = IdBox.Text;
                string Name = NameBox.Text;
                string License = LicenseBox.Text;
                string fprice = PriceBox.Text;
                if(IdBox.Text == string.Empty)
                {
                    MessageBox.Show("Вам потрібно заповнити поле ID!!!!");
                }
                else
                {
                    if (NameBox.Text != string.Empty)
                    {
                        con.Open();
                        cmd = new MySqlCommand("update item set Name = \"" + Name + "\" where ID = " + ID + " ;", con);
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    if (PriceBox.Text != string.Empty)
                    {
                        con.Open();
                        cmd = new MySqlCommand("update item set Price = " + fprice + " where ID = " + ID + " ;", con);
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    if (LicenseBox.Text != string.Empty)
                    {
                        con.Open();
                        cmd = new MySqlCommand("update item set License =\"" + License + "\" where ID =" + ID + ";", con);
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }

                    if (PriceBox.Text != string.Empty && NameBox.Text != string.Empty && LicenseBox.Text != string.Empty)
                    {
                        con.Open();
                        cmd = new MySqlCommand("update item set Name =\"" + Name + "\" , Price = " + fprice + " , License =\"" + License + "\" where ID = " + ID + " ;", con);
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    MessageBox.Show("Успішно!");
                }
  
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
        }
        }
    }

