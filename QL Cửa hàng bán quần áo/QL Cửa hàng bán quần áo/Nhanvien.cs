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
    public partial class Nhanvien : Form
    {
        public Nhanvien()
        {
            InitializeComponent();
        }

        private void Nhanvien_Load(object sender, EventArgs e)
        {
            Ketnoi.Connect();
            txtmanv.Enabled = false;
            LoadData();
        }
        DataTable tblc1;
        public void LoadData()
        {
            string sql;
            sql = "select*from tbl_NhanVien";
            tblc1 = Ketnoi.Getdatatotable(sql);
            dgvnhanvien.DataSource = tblc1;
            dgvnhanvien.Columns[0].HeaderText = "Mã nhân viên";
            dgvnhanvien.Columns[1].HeaderText = "Tên nhân viên";
            dgvnhanvien.Columns[2].HeaderText = "Giới tính";
            dgvnhanvien.Columns[3].HeaderText = "Địa chỉ";
            dgvnhanvien.Columns[4].HeaderText = "Số điện thoại";
            dgvnhanvien.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void dgvnhanvien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            txtmanv.Text = dgvnhanvien.Rows[i].Cells[0].Value.ToString().Trim();
            txttennv.Text = dgvnhanvien.Rows[i].Cells[1].Value.ToString().Trim();
            txtgioitinh.Text = dgvnhanvien.Rows[i].Cells[2].Value.ToString().Trim();
            txtdiachi.Text = dgvnhanvien.Rows[i].Cells[3].Value.ToString().Trim();
            txtsdt.Text = dgvnhanvien.Rows[i].Cells[4].Value.ToString().Trim();
        }
        private void reset_data()
        {

            txtmanv.Text = "";
            txttennv.Text = "";
            txtgioitinh.Text = "";
            txtdiachi.Text = "";
            txtsdt.Text = "";

        }

        private void btnlammoi_Click(object sender, EventArgs e)
        {
            reset_data();
            txtmanv.Enabled = true;
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            if (txtmanv.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtmanv.Focus();
                return;
            }
            if (txttennv.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txttennv.Focus();
                return;
            }
            if (txtgioitinh.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập giới tính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtgioitinh.Focus();
                return;
            }
            if (txtsdt.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtsdt.Focus();
                return;
            }
            if (txtdiachi.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtdiachi.Focus();
                return;
            }
            // kiem tra trung ma
            string sql = "select MaNV from tbl_NhanVien where MaNV=N'"+txtmanv.Text.Trim()+"'";
            if (Ketnoi.checkey(sql))
            {
                MessageBox.Show("Mã nhân viên này đã có", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtmanv.Focus();
                txtmanv.Text = "";
                return;
            }
            string sqlthem = "insert into tbl_NhanVien(MaNV,tenNV,gioitinh,diachi,sdt)values(N'" + txtmanv.Text.Trim() + "',N'" + txttennv.Text.Trim() + "',N'" + txtgioitinh.Text.Trim() + "',N'" + txtdiachi.Text.Trim() + "',N'" + txtsdt.Text.Trim() + "')";

            Ketnoi.runsql(sqlthem);
            LoadData();
            Nhanvien_Load(sender, e);
            reset_data();
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            if (tblc1.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtmanv.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtmanv.Focus();
                return;
            }
            if (txttennv.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txttennv.Focus();
                return;
            }
            if (txtgioitinh.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập giới tính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtgioitinh.Focus();
                return;
            }
            if (txtsdt.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtsdt.Focus();
                return;
            }
            if (txtdiachi.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtdiachi.Focus();
                return;
            }
            string sqlsua = "update tbl_NhanVien set TenNV=N'" + txttennv.Text.Trim() + "',gioitinh=N'" + txtgioitinh.Text.Trim() + "',diachi=N'" + txtdiachi.Text.Trim() + "',sdt=N'" + txtsdt.Text.Trim() + "' where MaNV=N'" + txtmanv.Text + "'";
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
            if (txtmanv.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                sql = "delete tbl_NhanVien where MaNV=N'"+txtmanv.Text+"'";
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
