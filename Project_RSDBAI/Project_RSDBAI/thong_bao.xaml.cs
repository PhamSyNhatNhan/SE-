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
    /// Interaction logic for thong_bao.xaml
    /// </summary>
    public partial class thong_bao : UserControl
    {
        public thong_bao()
        {
            InitializeComponent();
        }

        public thong_bao(string tieude_, string phanloai_, string noidung_, BitmapImage anh_)
        {
            InitializeComponent();

            tieude.Text = tieude_;
            phanloai.Content = phanloai_;
            noidung.Text = noidung_;
            anh.Source = anh_;
        }

        public thong_bao(string tieude_, string phanloai_)
        {
            InitializeComponent();

            tieude.Text = tieude_;
            phanloai.Content = phanloai_;
        }
    }
}
