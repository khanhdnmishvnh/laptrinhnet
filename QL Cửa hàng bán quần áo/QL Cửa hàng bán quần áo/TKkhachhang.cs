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
    public partial class TKkhachhang : Form
    {
        public TKkhachhang()
        {
            InitializeComponent();
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            if(txtmakh.Text !="")
            {
                Ketnoi.Connect();
                dgvtkkhachhang.DataSource = Ketnoi.Getdatatotable("select * from tbl_KhachHang where MaKH = '" + txtmakh.Text.Trim() + "'");
            }    
            if(txttenkh.Text!="")
            {
                Ketnoi.Connect();
                dgvtkkhachhang.DataSource = Ketnoi.Getdatatotable("select * from tbl_KhachHang where TenKH='" + txttenkh.Text.Trim() + "'");
            }    
            
            
        }

        private void txttenkh_TextChanged(object sender, EventArgs e)
        {
            Ketnoi.Connect();
            dgvtkkhachhang.DataSource = Ketnoi.Getdatatotable("select * from tbl_KhachHang where TenKH like '" + txttenkh.Text.Trim() + "%'");
        }

        private void txtmakh_TextChanged(object sender, EventArgs e)
        {

            Ketnoi.Connect();
            dgvtkkhachhang.DataSource = Ketnoi.Getdatatotable("select * from tbl_KhachHang where MaKH = '" + txtmakh.Text.Trim() + "'");
        }

        private void txtmakh_MouseClick(object sender, MouseEventArgs e)
        {
            txtmakh.Clear();
        }

        private void txttenkh_MouseClick(object sender, MouseEventArgs e)
        {
            txttenkh.Clear();
        }

        private void btnquaylai_Click(object sender, EventArgs e)
        {
            Menu frm = new Menu();
            frm.Show();
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
    }
}
