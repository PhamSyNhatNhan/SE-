using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Project_RSDBAI
{
    internal class thongbao_noidung_class
    {
        string id, id_nd;
        int thutu;
        string noidung;
        BitmapImage anh;

        public thongbao_noidung_class() { }
        public thongbao_noidung_class(string id, string id_nd, int thutu, string noidung, BitmapImage anh)
        {
            this.id = id;
            this.id_nd = id_nd;
            this.thutu = thutu;
            this.noidung = noidung;
            this.anh = anh;
        }

        public string Id { get => id; set => id = value; }
        public string Id_nd { get => id_nd; set => id_nd = value; }
        public int Thutu { get => thutu; set => thutu = value; }
        public string Noidung { get => noidung; set => noidung = value; }
        public BitmapImage Anh { get => anh; set => anh = value; }
    }
}
