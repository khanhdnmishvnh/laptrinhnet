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
    public partial class TKthongtinquanao : Form
    {
        public TKthongtinquanao()
        {
            InitializeComponent();
        }

        private void txttktheoten_TextChanged(object sender, EventArgs e)
        {
            Ketnoi.Connect();
            dgvtkthongtinquanao.DataSource = Ketnoi.Getdatatotable("select * from tbl_ThongTinQuanAo where TENQA like '" + txttktheoten.Text.Trim() + "%'");
        }

        private void txttktheoma_TextChanged(object sender, EventArgs e)
        {
            Ketnoi.Connect();
            dgvtkthongtinquanao.DataSource = Ketnoi.Getdatatotable("select * from tbl_ThongTinQuanAo where MaQA = '" + txttktheoma.Text.Trim() + "'");
        }

        private void txttktheoten_MouseClick(object sender, MouseEventArgs e)
        {
            txttktheoten.Clear();
        }

        private void txttktheoma_MouseClick(object sender, MouseEventArgs e)
        {
            txttktheoma.Clear();
        }

        private void btnquaylai_Click(object sender, EventArgs e)
        {
            Menu tc = new Menu();
            tc.Show();
            this.Hide();
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Bạn có chắc muốn thoát không?", "Trả lời",
           MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK)
                Application.Exit();
        }

        private void btntktheoten_Click(object sender, EventArgs e)
        {
            Ketnoi.Connect();
            dgvtkthongtinquanao.DataSource = Ketnoi.Getdatatotable("select * from tbl_ThongTinQuanAo where TENQA = '" + txttktheoten.Text.Trim() + "'");
        }

        private void btntktheoma_Click(object sender, EventArgs e)
        {
            Ketnoi.Connect();
            dgvtkthongtinquanao.DataSource = Ketnoi.Getdatatotable("select * from tbl_ThongTinQuanAo where MaQA = '" + txttktheoma.Text.Trim() + "'");
        }
    }
}
