using System;
using System.Collections.Generic;
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
    /// Interaction logic for yte.xaml
    /// </summary>
    public partial class yte : UserControl
    {
        public yte()
        {
            InitializeComponent();
        }

        private void timkiem_bt_Click(object sender, RoutedEventArgs e)
        {
            if (timkiem_cbb.SelectedIndex == -1 || timkiem_tb.Text == "")
            {
                MessageBox.Show("Vui lòng cung cấp đầy đủ thông tin");
                return;
            }
            timkiem_image.Visibility = Visibility.Visible;
        }

        private void TabItem_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                goi_y goiy_ = new goi_y();
                goiy_sp.Children.Add(goiy_);
            }
        }

        private void TabItem_Loaded_1(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                lien_he lienhe_ = new lien_he();
                lienhe_sp.Children.Add(lienhe_);
            }
        }
    }
}
