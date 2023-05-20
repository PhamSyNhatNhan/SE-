using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Project_RSDBAI
{
    /// <summary>
    /// Interaction logic for thongbao.xaml
    /// </summary>
    public partial class thongbao : UserControl
    {
        public thongbao()
        {
            InitializeComponent();
        }


        SqlConnection conn = Main_app.getConn();

        int thongbao_soluong = 0;
        int thongbao_hientai = 0;
        ObservableCollection<thongbao_class> danhsach_thongbao = new ObservableCollection<thongbao_class>();

        private void get_soluong_tb()
        {
            string sql = "select count(*) from thong_bao";
            SqlCommand query = new SqlCommand(sql, conn);
            SqlDataReader Reader = query.ExecuteReader();

            Reader.Read();
            thongbao_soluong = Reader.GetInt32(0);
            Reader.Close();

        }

        private void get_tb()
        {
            string sql = "select * from thong_bao order by id offset " + 
                                thongbao_hientai.ToString() + " rows fetch next 9 row only";
            SqlCommand query = new SqlCommand(sql, conn);
            SqlDataReader Reader = query.ExecuteReader();

            while (Reader.Read())
            {
                danhsach_thongbao.Add(new thongbao_class(Reader.GetString(0), Reader.GetString(1), Reader.GetString(2)));
            }

            Reader.Close();
        }

        private void giandong_sp()
        {
            double marginValue = 20;

            foreach (UIElement element in thongbao_sp.Children)
            {
                if (element is FrameworkElement frameworkElement)
                {
                    frameworkElement.Margin = new Thickness(0, marginValue, 0, 0);
                }
            }
        }
        private void load_tb()
        {
            int check = 0;
            for(int i = 0; i < danhsach_thongbao.Count; )
            {
                Grid grid = new Grid();

                ColumnDefinition column1 = new ColumnDefinition();
                column1.Width = new GridLength(1, GridUnitType.Auto);
                grid.ColumnDefinitions.Add(column1);

                ColumnDefinition column2 = new ColumnDefinition();
                column2.Width = new GridLength(1, GridUnitType.Auto);
                grid.ColumnDefinitions.Add(column2);

                ColumnDefinition column3 = new ColumnDefinition();
                column3.Width = new GridLength(1, GridUnitType.Auto);
                grid.ColumnDefinitions.Add(column3);

                double spacing = 20;

                thong_bao thongbao1 = new thong_bao(danhsach_thongbao[i].Tieude, danhsach_thongbao[i].Phanloai);
                grid.Children.Add(thongbao1);
                thongbao1.Margin = new Thickness(20, 0, spacing, 0);
                Grid.SetColumn(thongbao1, 0);
                i++;
                if (i == danhsach_thongbao.Count)
                {
                    if (check == 1)
                    {
                        thongbao_sp.Children.Insert(1, grid);
                        break;
                    }
                    thongbao_sp.Children.Insert(0, grid);
                    check = 1;
                    break;
                }

                thong_bao thongbao2 = new thong_bao(danhsach_thongbao[i].Tieude, danhsach_thongbao[i].Phanloai);
                grid.Children.Add(thongbao2);
                thongbao2.Margin = new Thickness(0, 0, spacing, 0);
                Grid.SetColumn(thongbao2, 1);
                i++;
                if (i == danhsach_thongbao.Count)
                {
                    if (check == 1)
                    {
                        thongbao_sp.Children.Insert(1, grid);
                        break;
                    }
                    thongbao_sp.Children.Insert(0, grid);
                    check = 1;
                    break;
                }

                thong_bao thongbao3 = new thong_bao(danhsach_thongbao[i].Tieude, danhsach_thongbao[i].Phanloai);
                grid.Children.Add(thongbao3);
                thongbao3.Margin = new Thickness(0, 0, spacing, 0);
                Grid.SetColumn(thongbao3, 2);
                i++;

                if (check == 1)
                {
                    thongbao_sp.Children.Insert(1, grid);
                    continue;
                }
                thongbao_sp.Children.Insert(0, grid);
                check = 1;
            }

            giandong_sp();
        }

        private void font_back_control()
        {
            if (thongbao_hientai >= (thongbao_soluong-9))
                font.IsEnabled = false;
            else
                font.IsEnabled = true;
            if (thongbao_hientai == 0)
                back.IsEnabled = false;
            else
                back.IsEnabled = true;
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            vitri_lb.Content = "1";
            get_soluong_tb();
            get_tb();
            load_tb();
            font_back_control();
        }

        private void font_Click(object sender, RoutedEventArgs e)
        {
            int lastIndex = thongbao_sp.Children.Count - 1;
            for (int i = 0; i < lastIndex; i++)
            {
                thongbao_sp.Children.RemoveAt(0);
            }
            danhsach_thongbao.Clear();


            int curent = int.Parse(vitri_lb.Content.ToString()) + 1;
            vitri_lb.Content = curent.ToString();

            thongbao_hientai += 9;
            get_tb();
            load_tb();

            font_back_control();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            int lastIndex = thongbao_sp.Children.Count - 1;
            for (int i = 0; i < lastIndex; i++)
            {
                thongbao_sp.Children.RemoveAt(0);
            }
            danhsach_thongbao.Clear();

            int curent = int.Parse(vitri_lb.Content.ToString()) - 1;
            vitri_lb.Content = curent.ToString();

            thongbao_hientai -= 9;
            get_tb();
            load_tb();

            font_back_control();
        }
    }
}
