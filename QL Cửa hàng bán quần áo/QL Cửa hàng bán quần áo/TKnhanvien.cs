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
    public partial class TKnhanvien : Form
    {
        public TKnhanvien()
        {
            InitializeComponent();
        }

        private void txttennv_TextChanged(object sender, EventArgs e)
        {
            Ketnoi.Connect();
            dgvtknhanvien.DataSource = Ketnoi.Getdatatotable("select * from tbl_NhanVien where TenNV like '" + txttennv.Text.Trim() + "%'");
        }

        private void txtmanv_TextChanged(object sender, EventArgs e)
        {
            Ketnoi.Connect();
            dgvtknhanvien.DataSource = Ketnoi.Getdatatotable("select * from tbl_NhanVien where MaNV = '" + txtmanv.Text.Trim() + "'");
        }

        private void txtmanv_MouseClick(object sender, MouseEventArgs e)
        {
            txtmanv.Clear();
        }

        private void txttennv_MouseClick(object sender, MouseEventArgs e)
        {
            txttennv.Clear();
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {   // khi max nv của 1 người và tên nv của người khác , ta bấm tìm kiếm vẫn ra dữ liệu theo tên ta nhập . Ta phải sửa thành không có dữ liệu tồn
            if(txtmanv.Text!="")
            {
                Ketnoi.Connect();
                dgvtknhanvien.DataSource = Ketnoi.Getdatatotable("select * from tbl_NhanVien where MaNV = '" + txtmanv.Text.Trim() + "'");
            }
            if(txttennv.Text!="")
            {
                Ketnoi.Connect();
                dgvtknhanvien.DataSource = Ketnoi.Getdatatotable("select * from tbl_NhanVien where TenNV = '" + txttennv.Text.Trim() + "'");
            }
            
            
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
