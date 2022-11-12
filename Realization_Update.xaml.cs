using System;
using System.Windows;
using System.Data;
using MySql.Data.MySqlClient;
namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Realization_Update.xaml
    /// </summary>
    public partial class Realization_Update : Window
    {
        public Realization_Update()
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
                int Item = Convert.ToInt32(ItemIDBox.Text);
                string Phone = PhoneBox.Text;
                string Email = EmailBox.Text;
                float fprice = (float)Convert.ToDouble(PriceBox.Text);
                if (IdBox.Text == string.Empty)
                {
                    MessageBox.Show("Вам потрібно заповнити поле ID!!!!");
                }
                else
                {
                    if (ItemIDBox.Text != string.Empty)
                    {
                        con.Open();
                        cmd = new MySqlCommand("update realization set Item_ID =\"" + Item + "\" where ID =" + ID + ";", con);
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    if (PriceBox.Text != string.Empty)
                    {
                        con.Open();
                        cmd = new MySqlCommand("update realization set Price = " + fprice + " where ID = " + ID + " ;", con);
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    if (PhoneBox.Text != string.Empty)
                    {
                        con.Open();
                        cmd = new MySqlCommand("update realization set Phone_num  =\"" + Phone + "\" where ID =" + ID + ";", con);
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    if(EmailBox.Text != string.Empty)
                    {
                        con.Open();
                        cmd = new MySqlCommand("update realization set Email =\"" + Email + "\" where ID =" + ID + ";", con);
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                        con.Close();

                    }
                    if (PriceBox.Text != string.Empty && ItemIDBox.Text != string.Empty && PhoneBox.Text != string.Empty && EmailBox.Text != string.Empty)
                    {
                        con.Open();
                        cmd = new MySqlCommand("update realization set Item_ID = " + Item + " , Price = " + fprice + " , Phone_num =\"" + Phone + "\", Email = \""+ Email+"\" where ID = " + ID + " ;", con);
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }

                }
                MessageBox.Show("Успішно!");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }

        }
    }
}
