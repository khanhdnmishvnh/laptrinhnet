using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QL_Cửa_hàng_bán_quần_áo
{
    public partial class Hoadonnhap : Form
    {
        public Hoadonnhap()
        {
            InitializeComponent();
        }

        private void Hoadonnhap_Load(object sender, EventArgs e)
        {
            Ketnoi.Connect();
            txtmahoadon.Enabled = false;
            LoadData();
            

        }
        DataTable tblc1;
        public void LoadData()
        {
            string sql;
            sql = "select hdn.mahdn,hdn.manv,cthdn.mancc,cthdn.MaQA,cthdn.SoLuong,hdn.NgayNhap,hdn.DiaChi,hdn.SDT,cthdn.DonGia,cthdn.TongTien from tbl_HoaDonNhap hdn join tbl_ChiTietHoaDonNhap cthdn on hdn.MaHDN=cthdn.MaHDN;";
            tblc1 = Ketnoi.Getdatatotable(sql);
            dgvhoadonnhap.DataSource = tblc1;
            dgvhoadonnhap.Columns[0].HeaderText = "Mã hóa đơn";
            dgvhoadonnhap.Columns[1].HeaderText = "Mã nhân viên";
            dgvhoadonnhap.Columns[2].HeaderText = "Mã nhà cung cấp";
            dgvhoadonnhap.Columns[3].HeaderText = "Mã sản phẩm";
            dgvhoadonnhap.Columns[4].HeaderText = "Số lượng";
            dgvhoadonnhap.Columns[5].HeaderText = "Ngày nhập";
            dgvhoadonnhap.Columns[6].HeaderText = "Địa chỉ";
            dgvhoadonnhap.Columns[7].HeaderText = "Số điện thoại";
            dgvhoadonnhap.Columns[8].HeaderText = "Đơn giá";
            dgvhoadonnhap.Columns[9].HeaderText = "Tổng tiền";
            dgvhoadonnhap.EditMode = DataGridViewEditMode.EditProgrammatically;

        }

        private void dgvhoadonnhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            txtmahoadon.Text = dgvhoadonnhap.Rows[i].Cells[0].Value.ToString().Trim();
            cbomanv.Text = dgvhoadonnhap.Rows[i].Cells[1].Value.ToString().Trim();
            cbomancc.Text = dgvhoadonnhap.Rows[i].Cells[2].Value.ToString().Trim();
            cbomasp.Text = dgvhoadonnhap.Rows[i].Cells[3].Value.ToString().Trim();
            txtsoluong.Text = dgvhoadonnhap.Rows[i].Cells[4].Value.ToString().Trim();
            mtbngaynhap.Text = dgvhoadonnhap.Rows[i].Cells[5].Value.ToString().Trim();
            txtdiachi.Text = dgvhoadonnhap.Rows[i].Cells[6].Value.ToString().Trim();
            txtsodienthoai.Text = dgvhoadonnhap.Rows[i].Cells[7].Value.ToString().Trim();
            txtdongia.Text = dgvhoadonnhap.Rows[i].Cells[8].Value.ToString().Trim();
            txttongtien.Text = dgvhoadonnhap.Rows[i].Cells[9].Value.ToString().Trim();
            txtsodienthoai.Enabled = true;
            txtdiachi.Enabled= true;
            mtbngaynhap.Enabled = true;

        }
        private void reset_data()
        {

            txtmahoadon.Text = "";
            cbomanv.Text = "";
            txtsoluong.Text = "";
            txtdongia.Text = "";
            cbomasp.Text = "";
            mtbngaynhap.Text = "";
            txttongtien.Text = "";
            txtsodienthoai.Text = "";
            cbomancc.Text = "";
            txtdiachi.Text = "";

            

        }

        private void btnLammoi_Click(object sender, EventArgs e)
        {
            
            txtmahoadon.Enabled = true;
            cbomasp.DataSource = Ketnoi.Getdatatotable("select* from tbl_ThongTinQuanAo");
            cbomasp.ValueMember = "MaQA";
            cbomasp.DisplayMember = "MaQA";
            cbomanv.DataSource = Ketnoi.Getdatatotable("select* from tbl_NhanVien");
            cbomanv.ValueMember = "MaNV";
            cbomanv.DisplayMember = "MaNV";
            cbomancc.DataSource = Ketnoi.Getdatatotable("select* from tbl_NhaCungCap");
            cbomancc.ValueMember = "MaNCC";
            cbomancc.DisplayMember = "MaNCC";
            reset_data();

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string sql = "select hdn.MaHDN from tbl_HoaDonNhap hdn join tbl_ChiTietHoaDonNhap cthdn on hdn.MaHDN=cthdn.MaHDN where hdn.MaHDN=N'" + txtmahoadon.Text.Trim() + "'";
            if (Ketnoi.checkey(sql))
            {
                /*MessageBox.Show("Mã hóa đơn này đã có", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtmahoadon.Focus();
                txtmahoadon.Text = "";
                return;*/
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
                
                /*cbomanv.DataSource = Ketnoi.Getdatatotable("select MaNV from tbl_HoaDonNhap where MaHDN=N'" + txtmahoadon.Text.Trim() + "'");
                cbomanv.ValueMember = "MaNV";
                cbomanv.DisplayMember = "MaNV";*/
                string sql1 = "select MaQA from tbl_ChiTietHoaDonNhap  where MaQA=N'" + cbomasp.Text.Trim() + "'and MaHDN=N'" + txtmahoadon.Text + "'";
                if (Ketnoi.checkey(sql1))
                {
                    MessageBox.Show("Mã sản phẩm trong hóa đơn này đã có", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cbomasp.Focus();
                    cbomasp.Text = "";
                    return;
                }
                else
                {
                    string s = "insert into tbl_ChiTietHoaDonNhap(MaHDN,MaQA,MaNCC,soluong,dongia,tongtien)values(N'" + txtmahoadon.Text.Trim() + "',N'" + cbomasp.Text.Trim() + "',N'" + cbomancc.Text.Trim() + "',N'" + txtsoluong.Text.Trim() + "',N'" + txtdongia.Text.Trim() + "',N'" + txttongtien.Text.Trim() + "')";
                    Ketnoi.runsql(s);
                    LoadData();
                    Hoadonnhap_Load(sender, e);
                    reset_data();
                    
                }
            }
            else
            {
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
                if (cbomancc.Text == "")
                {
                    MessageBox.Show("Bạn chưa chọn mã nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cbomancc.Focus();
                    return;
                }
                if (mtbngaynhap.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập ngày nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    mtbngaynhap.Focus();
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
                string sql1 = "insert into tbl_HoaDonNhap(MaHDN,manv,ngaynhap,diachi,sdt)values(N'" + txtmahoadon.Text.Trim() + "',N'" + cbomanv.Text.Trim() + "',N'" + mtbngaynhap.Text.Trim() + "',N'" + txtdiachi.Text.Trim() + "',N'" + txtsodienthoai.Text.Trim() + "') ";
                string sql2 = "insert into tbl_ChiTietHoaDonNhap(MaHDN,MaQA,MaNCC,soluong,dongia,tongtien)values(N'" + txtmahoadon.Text.Trim() + "',N'" + cbomasp.Text.Trim() + "',N'" + cbomancc.Text.Trim() + "',N'" + txtsoluong.Text.Trim() + "',N'" + txtdongia.Text.Trim() + "',N'" + txttongtien.Text.Trim() + "')";
                Ketnoi.runsql(sql1);
                Ketnoi.runsql(sql2);
                LoadData();
                Hoadonnhap_Load(sender, e);
                reset_data();

            }
            
            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

            if (tblc1.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtmahoadon.Text=="")
            {
                MessageBox.Show("Bạn chưa nhập mã hóa đơn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtmahoadon.Focus();
                return;
            }
            if (cbomanv.Text=="")
            {
                MessageBox.Show("Bạn chưa nhập mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbomanv.Focus();
                return;
            }
            if (txtsoluong.Text=="")
            {
                MessageBox.Show("Bạn chưa nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtsoluong.Focus();
                return;
            }
            if (cbomasp.Text=="")
            {
                MessageBox.Show("Bạn chưa chọn mã sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbomasp.Focus();
                return;
            }
            if (cbomancc.Text=="")
            {
                MessageBox.Show("Bạn chưa nhập mã nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbomancc.Focus();
                return;
            }
            if (mtbngaynhap.Text=="")
            {
                MessageBox.Show("Bạn chưa nhập ngày nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mtbngaynhap.Focus();
                return;
            }
            if (txtdiachi.Text=="")
            {
                MessageBox.Show("Bạn chưa nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtdiachi.Focus();
                return;
            }
            if (txtsodienthoai.Text=="")
            {
                MessageBox.Show("Bạn chưa nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtsodienthoai.Focus();
                return;
            }
            if (txtdongia.Text=="")
            {
                MessageBox.Show("Bạn chưa nhập đơn giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtdongia.Focus();
                return;
            }
            if (txttongtien.Text=="")
            {
                MessageBox.Show("Bạn chưa nhập tổng tiền", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txttongtien.Focus();
                return;
            }
            string sqlsua1 = "update tbl_HoaDonNhap set MaNV=N'" + cbomanv.Text.Trim() + "',ngaynhap=N'" + mtbngaynhap.Text.Trim() + "',diachi=N'" + txtdiachi.Text.Trim() + "',sdt=N'" + txtsodienthoai.Text.Trim() + "' where MaHDN=N'" + txtmahoadon.Text + "'";
            string sqlsua2 = "update tbl_ChiTietHoaDonNhap set MaQA=N'" + cbomasp.Text.Trim() + "',MaNCC=N'" + cbomancc.Text.Trim() + "',soluong=N'" + txtsoluong.Text.Trim() + "',dongia=N'" + txtdongia.Text.Trim() + "',tongtien=N'" + txttongtien.Text.Trim() + "' where MaQA=N'" + cbomasp.Text + "'";
            Ketnoi.runsql(sqlsua1);
            Ketnoi.runsql(sqlsua2);
            LoadData();
            reset_data();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            
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
            else if (MessageBox.Show("Bạn có muốn xóa không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                
                DataTable a = Ketnoi.Getdatatotable("select hdn.mahdn,hdn.manv,cthdn.mancc,cthdn.MaQA,cthdn.SoLuong,hdn.NgayNhap,hdn.DiaChi,hdn.SDT,cthdn.DonGia,cthdn.TongTien from tbl_HoaDonNhap hdn join tbl_ChiTietHoaDonNhap cthdn on hdn.MaHDN=cthdn.MaHDN where hdn.MaHDN=N'" + txtmahoadon.Text + "'");
                if (a.Rows.Count == 1)
                {
                    string sqlxoa1 = "delete tbl_HoaDonNhap where MaHDN=N'" + txtmahoadon.Text + "'";
                    string sqlxoa2 = "delete tbl_ChiTietHoaDonNhap where MaHDN=N'" + txtmahoadon.Text + "'";
                    Ketnoi.runsql(sqlxoa2);
                    Ketnoi.runsql(sqlxoa1);
                    LoadData();
                    reset_data();
                }
                else
                {
                        string sqlxoa2 = "delete tbl_ChiTietHoaDonNhap where MaQA=N'" + cbomasp.Text + "' and MaHDN=N'" + txtmahoadon.Text + "'";
                        Ketnoi.runsql(sqlxoa2);
                        LoadData();
                        reset_data();
                }
                
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

        private void txtmahoadon_TextChanged(object sender, EventArgs e)
        {
            string sql = "select hdn.MaHDN from tbl_HoaDonNhap hdn join tbl_ChiTietHoaDonNhap cthdn on hdn.MaHDN=cthdn.MaHDN where hdn.MaHDN=N'" + txtmahoadon.Text.Trim() + "'";
            if (Ketnoi.checkey(sql))
            {
                cbomancc.DataSource = Ketnoi.Getdatatotable("select MaNCC from tbl_ChiTietHoaDonNhap where MaHDN=N'" + txtmahoadon.Text.Trim() + "'");
                cbomancc.ValueMember = "MaNCC";
                cbomancc.DisplayMember = "MaNCC";
                cbomanv.DataSource = Ketnoi.Getdatatotable("select MaNV from tbl_HoaDonNhap where MaHDN=N'" + txtmahoadon.Text.Trim() + "'");
                cbomanv.ValueMember = "MaNV";
                cbomanv.DisplayMember = "MaNV";
                txtdiachi.Enabled = false;
                txtsodienthoai.Enabled = false;
                mtbngaynhap.Enabled = false;
            }
        }

        private void txtsoluong_TextChanged(object sender, EventArgs e)
        {
            if ((txtsoluong.Text != "") && (txtdongia.Text!=""))
            {
                double soluong = double.Parse(txtsoluong.Text);
                double dongia = double.Parse(txtdongia.Text);
                double tongtien = soluong * dongia;
                txttongtien.Text = tongtien.ToString();
            }
        }
        private void txtdongia_TextChanged(object sender, EventArgs e)
        {
            if ((txtsoluong.Text != "") && (txtdongia.Text != ""))
            {
                double soluong = double.Parse(txtsoluong.Text);
                double dongia = double.Parse(txtdongia.Text);
                double tongtien = soluong * dongia;
                txttongtien.Text = tongtien.ToString();
            }
        }
    }
}
