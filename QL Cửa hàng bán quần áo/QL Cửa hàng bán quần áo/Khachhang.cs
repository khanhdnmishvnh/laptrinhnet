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
    public partial class Khachhang : Form
    {
        public Khachhang()
        {
            InitializeComponent();
        }

        private void Khachhang_Load(object sender, EventArgs e)
        {
            Ketnoi.Connect();
            txtmakh.Enabled = false;
            LoadData();
        }
        DataTable tblc1;
        public void LoadData()
        {
            string sql;
            sql = "select*from tbl_KhachHang";
            tblc1 = Ketnoi.Getdatatotable(sql);
            dgvkhachhang.DataSource = tblc1;
            dgvkhachhang.Columns[0].HeaderText = "Mã khách hàng";
            dgvkhachhang.Columns[1].HeaderText = "Tên khách hàng";
            dgvkhachhang.Columns[2].HeaderText = "Giới tính";
            dgvkhachhang.Columns[3].HeaderText = "Địa chỉ";
            dgvkhachhang.Columns[4].HeaderText = "Số điện thoại";
            dgvkhachhang.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void dgvkhachhang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            txtmakh.Text = dgvkhachhang.Rows[i].Cells[0].Value.ToString().Trim();
            txttenkh.Text = dgvkhachhang.Rows[i].Cells[1].Value.ToString().Trim();
            txtgioitinh.Text = dgvkhachhang.Rows[i].Cells[2].Value.ToString().Trim();
            txtdiachi.Text = dgvkhachhang.Rows[i].Cells[3].Value.ToString().Trim();
            txtsodienthoai.Text = dgvkhachhang.Rows[i].Cells[4].Value.ToString().Trim();
        }
        private void reset_data()
        {

            txtmakh.Text = "";
            txttenkh.Text = "";
            txtgioitinh.Text = "";
            txtdiachi.Text = "";
            txtsodienthoai.Text = "";

        }

        private void btnlammoi_Click(object sender, EventArgs e)
        {
            reset_data();
            txtmakh.Enabled = true;
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            if (txtmakh.Text=="")
            {
                MessageBox.Show("Bạn chưa nhập mã khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtmakh.Focus();
                return;
            }
            if (txttenkh.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txttenkh.Focus();
                return;
            }
            if (txtgioitinh.Text =="")
            {
                MessageBox.Show("Bạn chưa nhập giới tính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtgioitinh.Focus();
                return;
            }
            if (txtsodienthoai.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtsodienthoai.Focus();
                return;
            }
            if (txtdiachi.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtdiachi.Focus();
                return;
            }
            // kiem tra trung ma
            string sql = "select MaKH from tbl_KhachHang where MaKH=N'"+txtmakh.Text.Trim()+"'";
            if (Ketnoi.checkey(sql))
            {
                MessageBox.Show("Mã khách hàng này đã có", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtmakh.Focus();
                txtmakh.Text = "";
                return;
            }
            string sqlthem = "insert into tbl_KhachHang(MaKH,tenKH,gioitinh,diachi,sdt)values(N'" + txtmakh.Text.Trim() + "',N'" + txttenkh.Text.Trim() + "',N'" + txtgioitinh.Text.Trim() + "',N'" + txtdiachi.Text.Trim() + "',N'" + txtsodienthoai.Text.Trim() + "')";

            Ketnoi.runsql(sqlthem);
            LoadData();
            Khachhang_Load(sender, e);
            reset_data();
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            if (tblc1.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtmakh.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtmakh.Focus();
                return;
            }
            if (txttenkh.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txttenkh.Focus();
                return;
            }
            if (txtgioitinh.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập giới tính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtgioitinh.Focus();
                return;
            }
            if (txtsodienthoai.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtsodienthoai.Focus();
                return;
            }
            if (txtdiachi.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtdiachi.Focus();
                return;
            }
            string sqlsua = "update tbl_KhachHang set TenKH=N'" + txttenkh.Text.Trim() + "',gioitinh=N'" + txtgioitinh.Text.Trim() + "',diachi=N'" + txtdiachi.Text.Trim() + "',sdt=N'" + txtsodienthoai.Text.Trim() + "' where MaKH=N'" + txtmakh.Text + "'";
            Ketnoi.runsql(sqlsua);
            LoadData();
            reset_data();
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblc1.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtmakh.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                sql = "delete tbl_KhachHang where MaKH=N'"+txtmakh.Text+"'";
                Ketnoi.runsql(sql);
                LoadData();
                reset_data();
            }
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
    }
}
