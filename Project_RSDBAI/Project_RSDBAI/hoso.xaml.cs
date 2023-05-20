using System;
using System.Collections.Generic;
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
    /// Interaction logic for hoso.xaml
    /// </summary>
    public partial class hoso : UserControl
    {
        public hoso()
        {
            InitializeComponent();
        }

        private bool isDataUpdated = false;
        SqlConnection conn = new SqlConnection();
        string Id = "";
        private TextBox[] textbox_ = new TextBox[9];

        private void EnableTextBox()
        {
            for(int i = 0; i<textbox_.Length; i++)
                textbox_[i].IsReadOnly = false;
            date.IsEnabled = true;

            string hexColor = "#FFFFD3CA"; 
            Color color = (Color)ColorConverter.ConvertFromString(hexColor);
            Brush brush = new SolidColorBrush(color);
            update_bt.Background = brush;
            hexColor = "#FFFF0013";
            color = (Color)ColorConverter.ConvertFromString(hexColor);
            brush = new SolidColorBrush(color);
            update_bt.BorderBrush = brush;

            update_bt.Content = "Lưu";
        }

        private void DisableTextBox()
        {
            for (int i = 0; i < textbox_.Length; i++)
                textbox_[i].IsReadOnly = true;
            date.IsEnabled = false;

            string hexColor = "#FFCAFFED"; 
            Color color = (Color)ColorConverter.ConvertFromString(hexColor);
            Brush brush = new SolidColorBrush(color);
            update_bt.Background = brush;
            hexColor = "#FF00FFFF";
            color = (Color)ColorConverter.ConvertFromString(hexColor);
            brush = new SolidColorBrush(color);
            update_bt.BorderBrush = brush;


            update_bt.Content = "Chỉnh sửa";
        }

        /*
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender == update_bt)
            {
                EnableTextBox(date, update_bt);

                EnableTextBox(cannang_txt, update_bt);

                EnableTextBox(chieucao_txt, update_bt);

                EnableTextBox(benhnen_txt, update_bt);

                EnableTextBox(thuoc_txt, update_bt);

                EnableTextBox(diung_txt, update_bt);

                EnableTextBox(diachi_txt, update_bt);

                EnableTextBox(ten_txt, update_bt);

                EnableTextBox(sdt_txt, update_bt);

                EnableTextBox(email_txt, update_bt);
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender == update_bt)
            {
                DisableTextBox(date, update_bt);

                DisableTextBox(cannang_txt, update_bt);

                DisableTextBox(chieucao_txt, update_bt);

                DisableTextBox(benhnen_txt, update_bt);

                DisableTextBox(thuoc_txt, update_bt);

                DisableTextBox(diung_txt, update_bt);

                DisableTextBox(diachi_txt, update_bt);

                DisableTextBox(ten_txt, update_bt);

                DisableTextBox(sdt_txt, update_bt);

                DisableTextBox(email_txt, update_bt);

                if (!isDataUpdated)
                {
                    UpdateData();
                    isDataUpdated = true;
                }
            }
        }
        */

        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                update_bt_Click(sender, e);
                e.Handled = true;
            }
        }

        private void getData()
        {
            try
            {
                string sql = "SELECT hs.ngaysinh, hs.cannang, hs.chieucao, hs.benhnen, hs.thuocdangdung, hs.diung, hs.diachi, hs.anh, u.ten, u.sdt, u.email FROM ho_so hs JOIN user_ u ON hs.id = u.id WHERE hs.id = @id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", Id);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    int ngaysinhOrdinal = reader.GetOrdinal("ngaysinh");
                    if (!reader.IsDBNull(ngaysinhOrdinal))
                    {
                        date.SelectedDate = reader.GetDateTime(ngaysinhOrdinal);
                    }

                    int cannangOrdinal = reader.GetOrdinal("cannang");
                    if (!reader.IsDBNull(cannangOrdinal))
                    {
                        cannang_txt.Text = reader.GetDouble(cannangOrdinal).ToString();
                    }

                    int chieucaoOrdinal = reader.GetOrdinal("chieucao");
                    if (!reader.IsDBNull(chieucaoOrdinal))
                    {
                        chieucao_txt.Text = reader.GetDouble(chieucaoOrdinal).ToString();
                    }

                    int benhnenOrdinal = reader.GetOrdinal("benhnen");
                    if (!reader.IsDBNull(benhnenOrdinal))
                    {
                        benhnen_txt.Text = reader.GetString(benhnenOrdinal);
                    }

                    int thuocdangdungOrdinal = reader.GetOrdinal("thuocdangdung");
                    if (!reader.IsDBNull(thuocdangdungOrdinal))
                    {
                        thuoc_txt.Text = reader.GetString(thuocdangdungOrdinal);
                    }

                    int diungOrdinal = reader.GetOrdinal("diung");
                    if (!reader.IsDBNull(diungOrdinal))
                    {
                        diung_txt.Text = reader.GetString(diungOrdinal);
                    }

                    int diachiOrdinal = reader.GetOrdinal("diachi");
                    if (!reader.IsDBNull(diachiOrdinal))
                    {
                        diachi_txt.Text = reader.GetString(diachiOrdinal);
                    }

                    string imagePath = reader.GetString(reader.GetOrdinal("anh"));
                    if (!reader.IsDBNull(reader.GetOrdinal("anh")))
                    {
                        avatarPic.Source = new BitmapImage(new Uri(imagePath));
                    }

                    ten_txt.Text = reader.GetString(reader.GetOrdinal("ten"));
                    if (!reader.IsDBNull(reader.GetOrdinal("sdt")))
                    {
                        sdt_txt.Text = reader.GetString(reader.GetOrdinal("sdt"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("email")))
                    {
                        email_txt.Text = reader.GetString(reader.GetOrdinal("email"));
                    }


                }

                reader.Close();
            }
            catch
            {
                MessageBox.Show("Có lỗi xảy ra");
            }
        }
        private void UpdateData()
        {
            try
            {
                string updateHoSoSql = "UPDATE ho_so SET ngaysinh = @ngaysinh, cannang = @cannang, chieucao = @chieucao, benhnen = @benhnen, thuocdangdung = @thuocdangdung, diung = @diung, diachi = @diachi WHERE id = @id";
                SqlCommand cmdHoSo = new SqlCommand(updateHoSoSql, conn);
                cmdHoSo.Parameters.AddWithValue("@ngaysinh", date.SelectedDate);
                cmdHoSo.Parameters.AddWithValue("@cannang", cannang_txt.Text);
                cmdHoSo.Parameters.AddWithValue("@chieucao", chieucao_txt.Text);
                cmdHoSo.Parameters.AddWithValue("@benhnen", benhnen_txt.Text);
                cmdHoSo.Parameters.AddWithValue("@thuocdangdung", thuoc_txt.Text);
                cmdHoSo.Parameters.AddWithValue("@diung", diung_txt.Text);
                cmdHoSo.Parameters.AddWithValue("@diachi", diachi_txt.Text);
                cmdHoSo.Parameters.AddWithValue("@id", Id);


                string updateUserInfoSql = "UPDATE user_ SET ten = @ten, sdt = @sdt, email = @email WHERE id = @id";
                SqlCommand cmdUserInfo = new SqlCommand(updateUserInfoSql, conn);
                cmdUserInfo.Parameters.AddWithValue("@ten", ten_txt.Text);
                cmdUserInfo.Parameters.AddWithValue("@sdt", sdt_txt.Text);
                cmdUserInfo.Parameters.AddWithValue("@email", email_txt.Text);
                cmdUserInfo.Parameters.AddWithValue("@id", Id);

                MessageBox.Show("Cập nhật thành công");
            }
            catch
            {
                MessageBox.Show("Có lỗi khi cập nhật");
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            textbox_[0] = cannang_txt;
            textbox_[1] = chieucao_txt;
            textbox_[2] = benhnen_txt;
            textbox_[3] = thuoc_txt;
            textbox_[4] = diung_txt;
            textbox_[5] = diachi_txt;
            textbox_[6] = ten_txt;
            textbox_[7] = sdt_txt;
            textbox_[8] = email_txt;

            conn = Main_app.getConn();
            Id = Main_app.getId();
            getData();
        }

        private void update_bt_Click(object sender, RoutedEventArgs e)
        {
            if (isDataUpdated)
            {
                UpdateData();
                DisableTextBox();
                isDataUpdated = false;
            }
            else
            {
                EnableTextBox();
                isDataUpdated = true;
            }
        }
    }
}
