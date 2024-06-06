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
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void btnDangnhap_Click(object sender, EventArgs e)

        {   
            if(txtTendangnhap.Text == ""||txtMatkhau.Text=="")
            {
                MessageBox.Show("Bạn cần nhập tài khoản và mật khẩu", "Thông báo");
                txtTendangnhap.Focus();
            }
            else { 
            Ketnoi.Connect();
            string sql = "select MaNV from tbl_TaiKhoan where MaNV=N'" + txtTendangnhap.Text.Trim() + "' and MatKhau=N'" + txtMatkhau.Text.Trim() + "'";
            if (Ketnoi.checkey(sql))
            { 
                
                    this.Hide();
                    Menu frm = new Menu();
                    frm.Show();
                
            }
            
            else
            {
                MessageBox.Show("không đúng tên người dùng / mật khẩu!!!", "Thông báo");
                this.txtTendangnhap.Focus();
                    txtMatkhau.Text = "";
                    txtTendangnhap.Text = "";
            }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Bạn có chắc muốn thoát không?", "Trả lời",MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK)
                Application.Exit();
        }
    }
}
