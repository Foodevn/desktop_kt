using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2212442_HoangPhuc
{
    internal class QuanLyDocGia
    {
        public List<DocGia> dsDocGia = new List<DocGia>();
        
        public void XoaDS()
        {
            dsDocGia.Clear();
        }
        public void Them1DG(DocGia dg)
        {
            dsDocGia.Add(dg);
        }
        public void DocFileTXT()
        {
            string path = "DS.txt";
            string t;
            string[] s;
            using (StreamReader sr = new StreamReader(path))
            {
                while ((t = sr.ReadLine()) != null)
                {
                    DocGia dg = new DocGia();
                    s=t.Split(';');
                    dg.MaDocGia = s[0];
                    dg.TenDocGia = s[1];
                    dg.SDT = s[2];
                    dg.DiaChi = s[3];
                    Them1DG(dg);
                }
            }
        }
        public override string ToString()
        {
            string x="";
            foreach (DocGia s in dsDocGia)
            {
                x += s.ToString();
            }
            return string.Format(x);
        }
    }
}
