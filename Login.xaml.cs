using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using MySql.Data.MySqlClient;
using System.Data; 

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        MySqlConnection con = new MySqlConnection("server = localhost;port =3306;username = root; password=;database=post");


        public Login()
        {
            InitializeComponent();
            ShowsNavigationUI = false;
        }
    private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            con.Open();
            string password = Password_Box.Text;
            string username = Username_Box.Text;
            string querry = "Select * from user where username = '" + username + "' and password = '" + password + "';";
            MySqlDataAdapter adapter = new MySqlDataAdapter(querry, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                NavigationService.Navigate(new Select_Table());
            }
            con.Close();

        }

    }
    }

