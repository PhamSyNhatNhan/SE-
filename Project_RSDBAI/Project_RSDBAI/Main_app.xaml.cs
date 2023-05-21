using Microsoft.Win32;
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
    /// Interaction logic for Main_app.xaml
    /// </summary>
    public partial class Main_app : Window
    {
        public Main_app(string id_tmp)
        {
            InitializeComponent();
            id_ = id_tmp;
        }

        string ConnStr_ = @"Data Source=LAPTOP-16BETLGM\SQLEXPRESS;Initial Catalog=btl_ktpm;Integrated Security=True;";
        static SqlConnection Conn = new SqlConnection();

        private Button[] buttons = new Button[5];
        private UserControl[] userControls = new UserControl[5];

        private static string id_ = "";

        public static string getId()
        {
            return id_;
        }

        public static SqlConnection getConn()
        {
            return Conn;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Conn.ConnectionString = ConnStr_;

            try
            {
                Conn.Open();
            }
            catch (Exception ex)
            {
                if (Conn.State != ConnectionState.Open)
                    MessageBox.Show("Lỗi kết nối");
            }

            string wallpaperPath = Registry.GetValue(@"HKEY_CURRENT_USER\Control Panel\Desktop", "Wallpaper", string.Empty).ToString();

            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.UriSource = new Uri(wallpaperPath, UriKind.Absolute);
            bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
            bitmapImage.EndInit();

            this.Background = new System.Windows.Media.ImageBrush(bitmapImage);

            userControls[0] = trangchu;
            userControls[1] = thongbao;
            userControls[2] = hoso;
            userControls[3] = chandoan;
            userControls[4] = yte;

            
            try
            {
                string sql = "Select ten from user_ where id = '" + id_ + "'";

                SqlCommand query = new SqlCommand(sql, Conn);
                SqlDataReader Reader = query.ExecuteReader();

                Reader.Read();
                name_lb.Content = Reader.GetString(0);
                Reader.Close();
            }
            catch { 
            
            }
            
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            buttons[0] = (Button)this.FindName("trangchu_bt");
            buttons[1] = (Button)this.FindName("thongbao_bt");
            buttons[2] = (Button)this.FindName("hoso_bt");
            buttons[3] = (Button)this.FindName("chandoan_bt");
            buttons[4] = (Button)this.FindName("yte_bt");

            bt_control(0);
            user_control(0);
        }

        private void bt_control(int n)
        {
            for (int i = 0; i < 5; i++)
            {
                if (i == n)
                {
                    Button button = buttons[i];
                    if (button != null)
                    {
                        button.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(20, 0, 0, 0));
                        button.BorderBrush = System.Windows.Media.Brushes.Aqua;
                        button.BorderThickness = new Thickness(5, 0, 0, 0);
                        Style style = new Style(typeof(Border));
                        style.Setters.Add(new Setter(Border.CornerRadiusProperty, new CornerRadius(10)));
                        button.Resources = new ResourceDictionary() { { typeof(Border), style } };
                    }
                }
                else
                {
                    Button button = buttons[i];
                    if (button != null)
                    {
                        button.Background = null;
                        button.BorderBrush = null;
                        button.BorderThickness = new Thickness(0);
                    }
                }
            }
        }
        private void user_control(int n)
        {
            for (int i = 0; i < 5; i++)
            {
                if (i == n)
                {
                    userControls[i].Visibility = Visibility.Visible;
                }
                else
                {
                    userControls[i].Visibility = Visibility.Collapsed;
                }
            }
        }

        private void trangchu_bt_Click(object sender, RoutedEventArgs e)
        {
            bt_control(0);
            user_control(0);
        }

        private void thongbao_bt_Click(object sender, RoutedEventArgs e)
        {
            bt_control(1);
            user_control(1);
        }

        private void hoso_bt_Click(object sender, RoutedEventArgs e)
        {
            bt_control(2);
            user_control(2);
        }

        private void chandoan_bt_Click(object sender, RoutedEventArgs e)
        {
            bt_control(3);
            user_control(3);
        }

        private void yte_bt_Click(object sender, RoutedEventArgs e)
        {
            bt_control(4);
            user_control(4);
        }
    }
}
