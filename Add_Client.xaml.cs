using System;
using System.Windows;
using System.Data;
using MySql.Data.MySqlClient;

namespace WpfApp1
{

    public partial class Add_Client : Window
    {
        public Add_Client()
        {
            InitializeComponent();
        }

        MySqlConnection con = new MySqlConnection("server=localhost;port=3306;user=root;password=;database=store");
        private MySqlCommand cmd;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (NameBox.Text == string.Empty | PhoneBox.Text == string.Empty | NameBox.Text == string.Empty | SecondNBox.Text == string.Empty | MailBox.Text == string.Empty | CardBox.Text == string.Empty)
            {
                MessageBox.Show("Будь ласка, заповніть всі рядки!!!");
            }
            else
            {
                try
                {
                    string FirstName = NameBox.Text;
                    string SecondName = SecondNBox.Text;
                    string Email = MailBox.Text;
                    string phone = PhoneBox.Text;
                    string card = CardBox.Text;
                    con.Open();
                    cmd = new MySqlCommand("Insert into clients values(\"" + phone + "\",\"" + FirstName + "\",\"" + SecondName + "\", \""+ Email+"\",\""+card+"\");", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    con.Close();
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
}
