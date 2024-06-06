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
    public partial class QLthongtinquanao : Form
    {
        public QLthongtinquanao()
        {
            InitializeComponent();
        }
        private void QLthongtinquanao_Load(object sender, EventArgs e)
        {
            Ketnoi.Connect();
            txtmasanpham.Enabled = false;
            LoadData();
            cbomancc.DataSource = Ketnoi.Getdatatotable("select * from tbl_NhaCungCap");
            cbomancc.ValueMember = "MaNCC";
            cbomancc.DisplayMember = "MaNCC";

        }
        DataTable tblc1;
        public void LoadData()
        {
            string sql;
            sql = "select * from tbl_ThongTinQuanAo";
            tblc1 = Ketnoi.Getdatatotable(sql);
            dgvSanpham.DataSource = tblc1;
            dgvSanpham.Columns[0].HeaderText = "Mã sản phẩm";
            dgvSanpham.Columns[1].HeaderText = "Tên sản phẩm";
            dgvSanpham.Columns[2].HeaderText = "Mã nhà cung cấp";
            dgvSanpham.Columns[3].HeaderText = "Số lượng";
            dgvSanpham.Columns[4].HeaderText = "Gíá bán";
            dgvSanpham.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        
        private void dgvSanpham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            txtmasanpham.Text = dgvSanpham.Rows[i].Cells[0].Value.ToString().Trim();
            txttensanpham.Text = dgvSanpham.Rows[i].Cells[1].Value.ToString().Trim();
            cbomancc.Text = dgvSanpham.Rows[i].Cells[2].Value.ToString().Trim();
            txtsoluong.Text = dgvSanpham.Rows[i].Cells[3].Value.ToString().Trim();
            txtgiaban.Text = dgvSanpham.Rows[i].Cells[4].Value.ToString().Trim();
        }
        private void reset_data()
        {

            txtmasanpham.Text = "";
            txttensanpham.Text = "";
            txtsoluong.Text = "";
            txtgiaban.Text = "";
            cbomancc.Text = "";

        }

        private void btnlammoi_Click(object sender, EventArgs e)
        {
            reset_data();
            txtmasanpham.Enabled = true;
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            if (txtmasanpham.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtmasanpham.Focus();
                return;
            }
            if (txttensanpham.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txttensanpham.Focus();
                return;
            }
            if (txtsoluong.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtsoluong.Focus();
                return;
            }
            if (cbomancc.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn mã nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbomancc.Focus();
                return;
            }
            if (txtgiaban.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập giá bán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtgiaban.Focus();
                return;
            }
            // kiem tra trung ma
             string sql = "select MaQA from tbl_ThongTinQuanAo where MaQA=N'"+txtmasanpham.Text.Trim()+"'";
            if (Ketnoi.checkey(sql))
            {
                MessageBox.Show("Mã sản phẩm này đã có", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtmasanpham.Focus();
                txtmasanpham.Text = "";
                return;
            }
            string sqlthem = "insert into tbl_ThongTInQuanAo(MaQA,tenQA,MaNCC,SoLuong,GiaBan)values(N'" + txtmasanpham.Text.Trim() + "',N'" + txttensanpham.Text.Trim() + "',N'" + cbomancc.Text.Trim() + "',N'" + txtsoluong.Text.Trim() + "',N'" + txtgiaban.Text.Trim() + "')";

            Ketnoi.runsql(sqlthem);
            LoadData();
            QLthongtinquanao_Load(sender, e);
            reset_data();
            
            
        }

       

        private void btnsua_Click(object sender, EventArgs e)
        {
            if (tblc1.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtmasanpham.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtmasanpham.Focus();
                return;
            }
            if (txttensanpham.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txttensanpham.Focus();
                return;
            }
            if (txtsoluong.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtsoluong.Focus();
                return;
            }
            if (cbomancc.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn mã nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbomancc.Focus();
                return;
            }
            if (txtgiaban.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập giá bán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtgiaban.Focus();
                return;
            }
            string sqlsua = "update tbl_ThongTinQuanAo set TenQA=N'" + txttensanpham.Text.Trim() + "',MaNCC=N'" + cbomancc.Text.Trim() + "',SoLuong=N'" + txtsoluong.Text.Trim() + "',GiaBan=N'" + txtgiaban.Text.Trim() + "' where MaQA=N'" + txtmasanpham.Text + "'";
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
            if (txtmasanpham.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                sql = "delete tbl_ThongTinQuanAo where MaQA=N'"+txtmasanpham.Text+"'";
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
