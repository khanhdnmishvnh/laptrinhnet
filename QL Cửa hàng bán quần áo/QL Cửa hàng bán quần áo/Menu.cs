using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_Cửa_hàng_bán_quần_áo
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }
        public int i = 8;

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Left += i;
            if (label1.Left >= this.Width - label1.Width-pictureBox2.Width || label1.Left <= 0)
                i = -i;
        }

        private void thôngTinQuanAoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QLthongtinquanao frm = new QLthongtinquanao();
            frm.Show();
            this.Hide();
        }

        private void thôngTinNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Nhanvien frm = new Nhanvien();
            frm.Show();
            this.Hide();
        }

        private void thôngTinNhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Nhacungcap frm = new Nhacungcap();
            frm.Show();
            this.Hide();
        }

        private void hóaĐơnNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hoadonnhap frm = new Hoadonnhap();
            frm.Show();
            this.Hide();
        }

        private void hóaĐơnBánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hoadonban frm = new Hoadonban();
            frm.Show();
            this.Hide();
        }

        private void thôngTinKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Khachhang frm = new Khachhang();
            frm.Show();
            this.Hide();
        }

        private void thốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thongke frm = new Thongke();
            frm.Show();
            this.Hide();
        }

        private void quayLaiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDangNhap frm = new frmDangNhap();
            frm.Show();
            this.Hide();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Bạn có chắc muốn thoát không?", "Trả lời",MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK)
                Application.Exit();
        }

        private void thôngTinQuanAOToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TKthongtinquanao frm = new TKthongtinquanao();
            frm.Show();
            this.Hide();
        }

        private void thôngTinNhânViênToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TKnhanvien frm = new TKnhanvien();
            frm.Show();
            this.Hide();
        }

        private void thôngTinNhàCungCấpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TKnhacungcap frm = new TKnhacungcap();
            frm.Show();
            this.Hide();
        }

        private void thôngTinKháchHàngToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TKkhachhang frm = new TKkhachhang();
            frm.Show();
            this.Hide();
        }
    }
}
