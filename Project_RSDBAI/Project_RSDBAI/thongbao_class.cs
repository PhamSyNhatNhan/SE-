using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_RSDBAI
{
    internal class thongbao_class
    {
        string id, tieude, phanloai;

        ObservableCollection<thongbao_noidung_class> thongbao_danhsach = new ObservableCollection<thongbao_noidung_class>();

        public thongbao_class(string id, string tieude, string phanloai, ObservableCollection<thongbao_noidung_class> thongbao_danhsach)
        {
            this.id = id;
            this.tieude = tieude;
            this.phanloai = phanloai;
            this.thongbao_danhsach = thongbao_danhsach;
        }

        public thongbao_class(string id, string tieude, string phanloai)
        {
            this.id = id;
            this.tieude = tieude;
            this.phanloai = phanloai;           
        }

        public string Id { get => id; set => id = value; }
        public string Tieude { get => tieude; set => tieude = value; }
        public string Phanloai { get => phanloai; set => phanloai = value; }
        internal ObservableCollection<thongbao_noidung_class> Thongbao_danhsach { get => thongbao_danhsach; set => thongbao_danhsach = value; }

        public override string ToString()
        {
            return id + tieude + phanloai;
        }
    }
}
