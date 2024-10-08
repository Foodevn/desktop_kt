using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2212442_HoangPhuc
{
    internal class DocGia
    {
        public string MaDocGia { get; set; }
        public string TenDocGia { get; set; }
        public string SDT { get; set; }
        public string DiaChi { get; set; }
        public DocGia()
        {

        }
        public DocGia(string ma, string ten, string sdt, string diachi)
        {
            this.MaDocGia = ma;
            this.TenDocGia = ten;
            this.SDT = sdt;
            this.DiaChi = diachi;
        }
        public override string ToString() { return string.Format($"{this.MaDocGia}, {this.TenDocGia}, {this.SDT}, {this.DiaChi}\n"); }
    }
}
