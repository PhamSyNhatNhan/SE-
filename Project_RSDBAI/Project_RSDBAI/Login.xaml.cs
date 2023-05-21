using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Project_RSDBAI
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        string ConnStr = @"Data Source=LAPTOP-16BETLGM\SQLEXPRESS;Initial Catalog=btl_ktpm;Integrated Security=True;";
        SqlConnection Conn = new SqlConnection();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Conn.ConnectionString = ConnStr;

            try
            {
                Conn.Open();

            }
            catch (Exception ex)
            {
                if (Conn.State != ConnectionState.Open)
                    MessageBox.Show("Lỗi kết nối");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void forgot_password_Click(object sender, RoutedEventArgs e)
        {
            string url = "https://www.youtube.com/watch?v=dQw4w9WgXcQ";
            System.Diagnostics.Process.Start(url);
        }

        private void Login_MS_bt_Click(object sender, RoutedEventArgs e)
        {
            if (Conn.State != ConnectionState.Open) return;

            if (username.Text == "" || password.Password == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ mật khẩu và tài khoản");
                return;
            }

            MessageBox.Show("Tính năng này tạm thời chưa thể sử dụng");
        }

        private void Login_bt_Click(object sender, RoutedEventArgs e)
        {
            if (Conn.State != ConnectionState.Open) return;

            if (username.Text == "" || password.Password == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ mật khẩu và tài khoản");
                return;
            }

            int check = 0;

            try
            {
                string sql = "Select count(*) from account where username_ = '" + username.Text + "' and password_ = '" + password.Password + "'";

                SqlCommand query = new SqlCommand(sql, Conn);
                SqlDataReader Reader = query.ExecuteReader();

                Reader.Read();
                check = Reader.GetInt32(0);
                Reader.Close();
            }
            catch
            {
                MessageBox.Show("Lỗi kết nối");
                return;
            }
            

            if (check == 1)
            {
                try
                {
                    string sql = "Select id from account where username_ = '" + username.Text + "' and password_ = '" + password.Password + "'";

                    SqlCommand query = new SqlCommand(sql, Conn);
                    SqlDataReader Reader = query.ExecuteReader();

                    Reader.Read();
                    string id = Reader.GetString(0);
                    Reader.Close();

                    Main_app index_ = new Main_app(id);
                    this.Hide();
                    index_.Show();
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("Có lỗi xảy ra");
                }
            }
            else
            {
                MessageBox.Show("Sai mật khẩu hoặc tài khoản");
            }
        }
    }
}
