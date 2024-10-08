using _2212442_HoangPhuc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2212442_Cau2
{
    public partial class Cau2 : Form
    {
        public Cau2()
        {
            InitializeComponent();
        }

        private void btnChonNguoi_Click(object sender, EventArgs e)
        {
            Cau1 form= new Cau1();
         
            if(form.ShowDialog() == DialogResult.OK )
            {
                txtNguoimuon.Text=form.chonDocGia[0];
                
            }
        }
    }
}
