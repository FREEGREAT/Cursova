using System;
using System.Windows;
using System.Data;
using MySql.Data.MySqlClient;


namespace WpfApp1
{
    public partial class Client_Update : Window
    {
        public Client_Update()
        {
            InitializeComponent();
        }
        private MySqlConnection con = new MySqlConnection("server=localhost;port=3306;user=root;password=;database=store");
        private MySqlCommand cmd;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string FirstName = NameBox.Text;
            string SecondName = SecondNBox.Text;
            string Email = MailBox.Text;
            string phone = PhoneBox.Text;
            string card = CardBox.Text;
            try
            {
                if (PhoneBox.Text == string.Empty)
                {
                    MessageBox.Show("Вам потрібно заповнити поле Номер телефону !!!!");
                }
                else
                {
                    if (NameBox.Text != string.Empty)
                    {
                        con.Open();
                        cmd = new MySqlCommand("update clients set First_n =\"" + FirstName + "\" where Phone =" + phone + ";", con);
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    if (SecondNBox.Text != string.Empty)
                    {
                        con.Open();
                        cmd = new MySqlCommand("update clients set Second_n =\"" + SecondName + "\" where Phone =" + phone + ";", con);
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                        con.Close();

                    }
                    if (MailBox.Text != string.Empty)
                    {
                        con.Open();
                        cmd = new MySqlCommand("update clients set Email =\"" + Email + "\" where Phone =" + phone + ";", con);
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                        con.Close();

                    }
                    if (CardBox.Text != string.Empty)
                    {
                        con.Open();
                        cmd = new MySqlCommand("update clients set Card = " + card + " where Phone =" + phone + ";", con);
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
