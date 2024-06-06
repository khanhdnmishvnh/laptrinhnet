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
    public partial class Hoadonban : Form
    {
        public Hoadonban()
        {
            InitializeComponent();
        }

        private void Hoadonban_Load(object sender, EventArgs e)
        {
            Ketnoi.Connect();
            txtmahoadon.Enabled = false;
            LoadData();
            cbomasp.DataSource = Ketnoi.Getdatatotable("select* from tbl_ThongTinQuanAo");
            cbomasp.ValueMember = "MaQA";
            cbomasp.DisplayMember = "MaQA";
            cbomanv.DataSource = Ketnoi.Getdatatotable("select* from tbl_NhanVien");
            cbomanv.ValueMember = "MaNV";
            cbomanv.DisplayMember = "MaNV";
            cbomakh.DataSource = Ketnoi.Getdatatotable("select* from tbl_KhachHang");
            cbomakh.ValueMember = "MaKH";
            cbomakh.DisplayMember = "MaKH";

        }
        DataTable tblc1;
        public void LoadData()
        {
            string sql;
            sql = "select hdb. MaHDB,hdb.MaNV,hdb.MaKH,cthdb.MaQA,cthdb.SoLuong,hdb.NgayBan,hdb.DiaChi,hdb.SDT,cthdb.DonGia,cthdb.TongTien from tbl_HoaDonBan hdb join tbl_ChiTietHoaDonBan cthdb on hdb.MaHDB=hdb.MaHDB";
            tblc1 = Ketnoi.Getdatatotable(sql);
            dgvhoadonban.DataSource = tblc1;
            dgvhoadonban.Columns[0].HeaderText = "Mã hóa đơn";
            dgvhoadonban.Columns[1].HeaderText = "Mã nhân viên";
            dgvhoadonban.Columns[2].HeaderText = "Mã khách hàng";
            dgvhoadonban.Columns[3].HeaderText = "Mã sản phẩm";
            dgvhoadonban.Columns[4].HeaderText = "Số lượng";
            dgvhoadonban.Columns[5].HeaderText = "Ngày bán";
            dgvhoadonban.Columns[6].HeaderText = "Địa chỉ";
            dgvhoadonban.Columns[7].HeaderText = "Số điện thoại";
            dgvhoadonban.Columns[8].HeaderText = "Đơn giá";
            dgvhoadonban.Columns[9].HeaderText = "Tổng tiền";
            dgvhoadonban.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void dgvhoadonban_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            txtmahoadon.Text = dgvhoadonban.Rows[i].Cells[0].Value.ToString().Trim();
            cbomanv.Text = dgvhoadonban.Rows[i].Cells[1].Value.ToString().Trim();
            cbomakh.Text = dgvhoadonban.Rows[i].Cells[2].Value.ToString().Trim();
            cbomasp.Text = dgvhoadonban.Rows[i].Cells[3].Value.ToString().Trim();
            txtsoluong.Text = dgvhoadonban.Rows[i].Cells[4].Value.ToString().Trim();
            mtbngayban.Text = dgvhoadonban.Rows[i].Cells[5].Value.ToString().Trim();
            txtdiachi.Text = dgvhoadonban.Rows[i].Cells[6].Value.ToString().Trim();
            txtsodienthoai.Text = dgvhoadonban.Rows[i].Cells[7].Value.ToString().Trim();
            txtdongia.Text = dgvhoadonban.Rows[i].Cells[8].Value.ToString().Trim();
            txttongtien.Text = dgvhoadonban.Rows[i].Cells[9].Value.ToString().Trim();
        }
        private void reset_data()
        {

            txtmahoadon.Text = "";
            cbomanv.Text = "";
            txtsoluong.Text = "";
            txtdongia.Text = "";
            cbomasp.Text = "";
            mtbngayban.Text = "";
            txttongtien.Text = "";
            txtsodienthoai.Text = "";
            cbomakh.Text = "";
            txtdiachi.Text = "";

        }

        private void btnLammoi_Click(object sender, EventArgs e)
        {
            reset_data();
            txtmahoadon.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {   
            // Không thể thêm nhiều sản phẩm vào 1 hóa đơn 
            // muốn tự động cập nhật ở textbox tương ứng ( không bắt buộc)
            if (txtmahoadon.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã hóa đơn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtmahoadon.Focus();
                return;
            }
            if (cbomanv.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbomanv.Focus();
                return;
            }
            if (txtsoluong.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtsoluong.Focus();
                return;
            }
            if (cbomasp.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn mã sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbomasp.Focus();
                return;
            }
            if (cbomakh.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn mã khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbomakh.Focus();
                return;
            }
            if (mtbngayban.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập ngày bán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mtbngayban.Focus();
                return;
            }
            if (txtdiachi.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtdiachi.Focus();
                return;
            }
            if (txtsodienthoai.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtsodienthoai.Focus();
                return;
            }
            if (txtdongia.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập đơn giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtdongia.Focus();
                return;
            }
            if (txttongtien.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tổng tiền", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txttongtien.Focus();
                return;
            }
            // kiem tra trung ma
            string sql = "select hdb.MaHDB from tbl_HoaDonBan hdb join tbl_ChiTietHoaDonBan cthdb on hdb.MaHDB=cthdb.MaHDB where hdb.MaHDB=N'" + txtmahoadon.Text.Trim() + "'";
            if (Ketnoi.checkey(sql))
            {
                MessageBox.Show("Mã hóa đơn này đã có", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtmahoadon.Focus();
                txtmahoadon.Text = "";
                return;
            }
            string sqlthem1 = "insert into tbl_HoaDonBan(MaHDB,manv,makh,ngayban,diachi,sdt)values(N'" + txtmahoadon.Text.Trim() + "',N'" + cbomanv.Text.Trim() + "',N'" + cbomakh.Text.Trim() + "',N'" + mtbngayban.Text.Trim() + "',N'" + txtdiachi.Text.Trim() + "',N'" + txtsodienthoai.Text.Trim() + "') ";
            string sqlthem2 = "insert into tbl_ChiTietHoaDonBan(MaHDB,MaQA,soluong,dongia,tongtien)values(N'" + txtmahoadon.Text.Trim() + "',N'" + cbomasp.Text.Trim() + "',N'" + txtsoluong.Text.Trim() + "',N'" + txtdongia.Text.Trim() + "',N'" + txttongtien.Text.Trim() + "')";
            Ketnoi.runsql(sqlthem1);
            Ketnoi.runsql(sqlthem2);
            LoadData();
            Hoadonban_Load(sender, e);
            reset_data();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (tblc1.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtmahoadon.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã hóa đơn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtmahoadon.Focus();
                return;
            }
            if (cbomanv.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbomanv.Focus();
                return;
            }
            if (txtsoluong.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtsoluong.Focus();
                return;
            }
            if (cbomasp.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn mã sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbomasp.Focus();
                return;
            }
            if (cbomakh.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbomakh.Focus();
                return;
            }
            if (mtbngayban.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập ngày bán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mtbngayban.Focus();
                return;
            }
            if (txtdiachi.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtdiachi.Focus();
                return;
            }
            if (txtsodienthoai.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtsodienthoai.Focus();
                return;
            }
            if (txtdongia.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập đơn giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtdongia.Focus();
                return;
            }
            if (txttongtien.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tổng tiền", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txttongtien.Focus();
                return;
            }
            string sqlsua1 = "update tbl_HoaDonBan set MaKH=N'" + cbomakh.Text.Trim() + "',MaNV=N'" + cbomanv.Text.Trim() + "',ngayban=N'" + mtbngayban.Text.Trim() + "',diachi=N'" + txtdiachi.Text.Trim() + "',sdt=N'" + txtsodienthoai.Text.Trim() + "' where MaHDB=N'" + txtmahoadon.Text + "'";
            string sqlsua2 = "update tbl_ChiTietHoaDonBan set MaQA=N'" + cbomasp.Text.Trim() + "',soluong=N'" + txtsoluong.Text.Trim() + "',dongia=N'" + txtdongia.Text.Trim() + "',tongtien=N'" + txttongtien.Text.Trim() + "' where MaHDB=N'" + txtmahoadon.Text + "'";
            Ketnoi.runsql(sqlsua1);
            Ketnoi.runsql(sqlsua2);
            LoadData();
            reset_data();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblc1.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtmahoadon.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                string sqlxoa1 = "delete tbl_HoaDonBan where MaHDB=N'" + txtmahoadon.Text + "'";
                string sqlxoa2 = "delete tbl_ChiTietHoaDonBan where MaHDB=N'" + txtmahoadon.Text + "'";
                Ketnoi.runsql(sqlxoa1);
                Ketnoi.runsql(sqlxoa2);
                LoadData();
                reset_data();
            }
        }

        private void btnQuaylai_Click(object sender, EventArgs e)
        {
            Menu tc = new Menu();
            tc.Show();
            this.Hide();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Bạn có chắc muốn thoát không?", "Trả lời",
           MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK)
                Application.Exit();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Bạn có chắc muốn in không?", "Trả lời",
           MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK)
                MessageBox.Show("In thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void txtsoluong_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtsoluong.Text) && !string.IsNullOrEmpty(txtdongia.Text))
            {
                // Thực hiện tính toán tổng tiền


                int soLuong = int.Parse(txtsoluong.Text);
                decimal donGia = decimal.Parse(txtdongia.Text);
                decimal tongTien = soLuong * donGia;
                // Hiển thị tổng tiền trong TextBox tổng tiền
                txttongtien.Text = tongTien.ToString();
            }
        }
    }
}
