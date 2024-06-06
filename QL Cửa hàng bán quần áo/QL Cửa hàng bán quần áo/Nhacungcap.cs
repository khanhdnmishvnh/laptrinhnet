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
    public partial class Nhacungcap : Form
    {
        public Nhacungcap()
        {
            InitializeComponent();
        }

        private void Nhacungcap_Load(object sender, EventArgs e)
        {
            Ketnoi.Connect();
            txtmancc.Enabled = false;
            LoadData();
        }
        DataTable tblc1;
        public void LoadData()
        {
            string sql;
            sql = "select*from tbl_NhaCungCap";
            tblc1 = Ketnoi.Getdatatotable(sql);
            dgvnhacungcap.DataSource = tblc1;
            dgvnhacungcap.Columns[0].HeaderText = "Mã nhà cung cấp";
            dgvnhacungcap.Columns[1].HeaderText = "Tên nhà cung cấp";
            dgvnhacungcap.Columns[2].HeaderText = "Địa chỉ";
            dgvnhacungcap.Columns[3].HeaderText = "Số điện thoại";
            dgvnhacungcap.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void dgvnhacungcap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            txtmancc.Text = dgvnhacungcap.Rows[i].Cells[0].Value.ToString().Trim();
            txttenncc.Text = dgvnhacungcap.Rows[i].Cells[1].Value.ToString().Trim();
            txtdiachi.Text = dgvnhacungcap.Rows[i].Cells[2].Value.ToString().Trim();
            txtsdt.Text = dgvnhacungcap.Rows[i].Cells[3].Value.ToString().Trim();

        }
        private void reset_data()
        {

            txtmancc.Text = "";
            txttenncc.Text = "";
            txtdiachi.Text = "";
            txtsdt.Text = "";

        }

        private void btnlammoi_Click(object sender, EventArgs e)
        {
            reset_data();
            txtmancc.Enabled = true;
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            if (txtmancc.Text=="")
            {
                MessageBox.Show("Bạn chưa nhập mã nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtmancc.Focus();
                return;
            }
            if (txttenncc.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txttenncc.Focus();
                return;
            }
            if (txtdiachi.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtdiachi.Focus();
                return;
            }
            if (txtsdt.Text == "")
            {
                MessageBox.Show("Bạn chưa cnhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtsdt.Focus();
                return;
            }
          
            // kiem tra trung ma
            string sql = "select MaNCC from tbl_NhaCungCap where MaNCC=N'"+txtmancc.Text.Trim()+"'";
            if (Ketnoi.checkey(sql))
            {
                MessageBox.Show("Mã nhà cung cấp này đã có", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtmancc.Focus();
                txtmancc.Text = "";
                return;
            }
            string sqlthem = "insert into tbl_NhaCungCap(MaNCC,TenNCC,DiaChi,SDT)values(N'" + txtmancc.Text.Trim() + "',N'" + txttenncc.Text.Trim() + "',N'" + txtdiachi.Text.Trim() + "',N'" + txtsdt.Text.Trim() + "')";

            Ketnoi.runsql(sqlthem);
            LoadData();
            Nhacungcap_Load(sender, e);
            reset_data();
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            if (tblc1.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtmancc.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtmancc.Focus();
                return;
            }
            if (txttenncc.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txttenncc.Focus();
                return;
            }
            if (txtdiachi.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtdiachi.Focus();
                return;
            }
            if (txtsdt.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtsdt.Focus();
                return;
            }
            string sqlsua = "update tbl_NhaCungCap set TenNCC=N'" + txttenncc.Text.Trim() + "',DiaChi=N'" + txtdiachi.Text.Trim() + "',SDT=N'" + txtsdt.Text.Trim() + "' where MaNCC=N'" + txtmancc.Text + "'";
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
            if (txtmancc.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                sql = "delete tbl_NhaCungCap where MaNCC=N'"+txtmancc.Text+"'";
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
