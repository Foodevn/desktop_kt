using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _2212442_HoangPhuc
{
    public partial class Cau1 : Form
    {
        QuanLyDocGia quanLyDocGia = new QuanLyDocGia();
        public string[] chonDocGia = new string[4];
        public Cau1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            quanLyDocGia.DocFileTXT();

            LoadDSVaoListView();
        }
        void LoadDSVaoListView()
        {
            listViewDS.Items.Clear();
            for (int i = 0; i < quanLyDocGia.dsDocGia.Count; i++)
            {
                DocGia dg1 = quanLyDocGia.dsDocGia[i];
                string[] s = new string[4];
                s[0] = dg1.MaDocGia;
                s[1] = dg1.TenDocGia;
                s[2] = dg1.SDT;
                s[3] = dg1.DiaChi;
                ListViewItem item = new ListViewItem(s);
                listViewDS.Items.Add(item);
            }
            listViewDS.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            txtMaDocGia.Text = "";
            txtTenDocGia.Text = "";
            txtTiemKiem.Text = "";
            maskedTextBoxSDT.Text = "";
            txtDiaChi.Text = "";
        }

        private void listViewDS_Click(object sender, EventArgs e)
        {
            ListViewItem item = listViewDS.SelectedItems[0];
            txtMaDocGia.Text = item.SubItems[0].Text;
            txtTenDocGia.Text = item.SubItems[1].Text;
            maskedTextBoxSDT.Text = item.SubItems[2].Text;
            txtDiaChi.Text = item.SubItems[3].Text;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string[] s = new string[4];
            s[0] = txtMaDocGia.Text;
            s[1] = txtTenDocGia.Text;
            s[2] = maskedTextBoxSDT.Text;
            s[3] = txtDiaChi.Text;
            ListViewItem item = new ListViewItem(s);
            listViewDS.Items.Add(item);
        }
        public void LuuVaoFileXML()
        {
            foreach (DocGia dg in quanLyDocGia.dsDocGia)
            {
                string path = "DS.xml";
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(path);
                XmlElement newDocGia = xmlDocument.CreateElement("DocGia");
                XmlElement maDocGia = xmlDocument.CreateElement("MaDocGia");
                maDocGia.InnerText = dg.MaDocGia;
                newDocGia.AppendChild(maDocGia);

                XmlElement tenDocGia = xmlDocument.CreateElement("TenDocGia");
                tenDocGia.InnerText = dg.TenDocGia;
                newDocGia.AppendChild(tenDocGia);

                XmlElement SDTDocGia = xmlDocument.CreateElement("SDTDocGia");
                SDTDocGia.InnerText = dg.SDT;
                newDocGia.AppendChild(SDTDocGia);

                XmlElement diaChiDocGia = xmlDocument.CreateElement("DiaChiDocGia");
                diaChiDocGia.InnerText = dg.DiaChi;
                newDocGia.AppendChild(diaChiDocGia);

                XmlNode ds = xmlDocument.SelectSingleNode("/ds");
                if (ds != null)
                {
                    ds.AppendChild(newDocGia);
                }
                xmlDocument.Save(path);
            }
        }
        public void luuDS()
        {
            foreach (ListViewItem item in listViewDS.Items)
            {
                DocGia dg = new DocGia();
                dg.MaDocGia = item.SubItems[0].Text;
                dg.TenDocGia = item.SubItems[1].Text;
                dg.SDT = item.SubItems[2].Text;
                dg.DiaChi = item.SubItems[3].Text;
                quanLyDocGia.Them1DG(dg);
            }
        }

        private void btnXuatFile_Click(object sender, EventArgs e)
        {
            luuDS();
            LuuVaoFileXML();
        }

        private void listViewDS_DoubleClick(object sender, EventArgs e)
        {

            ListViewItem item = listViewDS.SelectedItems[0];
            chonDocGia[0] = item.SubItems[0].Text;
            chonDocGia[1] = item.SubItems[1].Text;
            chonDocGia[2] = item.SubItems[2].Text;
            chonDocGia[3] = item.SubItems[3].Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void txtTiemKiem_TextChanged(object sender, EventArgs e)
        {

            string keyword = txtTiemKiem.Text;
            TiemKiemDG(keyword);
        }
        void TiemKiemDG(string keyw)
        {
            listViewDS.Items.Clear();
            if (string.IsNullOrEmpty(keyw))
            {
                foreach (var dg in quanLyDocGia.dsDocGia)
                {
                    ListViewItem item = new ListViewItem(dg.MaDocGia);
                    item.SubItems.Add(dg.TenDocGia);
                    item.SubItems.Add(dg.SDT);
                    item.SubItems.Add(dg.DiaChi);
                    listViewDS.Items.Add(item);
                }
            }
            else
            {
                if (radioButtonTen.Checked)
                {
                    string searchText = txtTiemKiem.Text.Trim().ToLower();

                    foreach (var dg in quanLyDocGia.dsDocGia)
                    {

                        string ten = dg.TenDocGia.ToLower();


                        if (ten.Contains(searchText))
                        {

                            ListViewItem item = new ListViewItem(dg.MaDocGia);
                            item.SubItems.Add(dg.TenDocGia);
                            item.SubItems.Add(dg.SDT);
                            item.SubItems.Add(dg.DiaChi);
                            listViewDS.Items.Add(item);


                        }
                    }

                }
                else
                {
                    string searchText = txtTiemKiem.Text.Trim().ToLower();

                    foreach (var dg in quanLyDocGia.dsDocGia)
                    {


                        string sdt = dg.SDT.ToLower();

                        if (sdt.Contains(searchText))
                        {

                            ListViewItem item = new ListViewItem(dg.MaDocGia);
                            item.SubItems.Add(dg.TenDocGia);
                            item.SubItems.Add(dg.SDT);
                            item.SubItems.Add(dg.DiaChi);
                            listViewDS.Items.Add(item);


                        }
                    }
                }

            }

        }
    }
}
