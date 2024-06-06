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
    public partial class TKnhacungcap : Form
    {
        public TKnhacungcap()
        {
            InitializeComponent();
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {   if(txtmancc.Text!="")
            {
                Ketnoi.Connect();
                dgvtkncc.DataSource = Ketnoi.Getdatatotable("select * from tbl_NhaCCungCap where MaNCC = '" + txtmancc.Text.Trim() + "'");
            }
            if(txttenncc.Text!="")
            {
                Ketnoi.Connect();
                dgvtkncc.DataSource = Ketnoi.Getdatatotable("select * from tbl_NhaCungCap where TenNCC = '" + txttenncc.Text.Trim() + "'");
            }

            
        }

        private void txtmancc_TextChanged(object sender, EventArgs e)
        {
            Ketnoi.Connect();
            dgvtkncc.DataSource = Ketnoi.Getdatatotable("select * from tbl_NhaCungCap where MaNCC = '" + txtmancc.Text.Trim() + "'");

        }

        private void txttenncc_TextChanged(object sender, EventArgs e)
        {
            Ketnoi.Connect();
            dgvtkncc.DataSource = Ketnoi.Getdatatotable("select * from tbl_NhaCungCap where TenNCC like '" + txttenncc.Text.Trim() + "%'");
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

        private void txtmancc_MouseClick(object sender, MouseEventArgs e)
        {
            txtmancc.Clear();
        }

        private void txttenncc_MouseClick(object sender, MouseEventArgs e)
        {
            txttenncc.Clear();
        }
    }
}

