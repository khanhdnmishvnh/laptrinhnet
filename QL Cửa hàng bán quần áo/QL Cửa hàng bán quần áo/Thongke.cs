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
    public partial class Thongke : Form
    {
        public Thongke()
        {
            InitializeComponent();
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

        private void btnThongke_Click(object sender, EventArgs e)
        {
            // Đang bị lỗi khi không nhập ngày tháng mà vẫn chạy câu lệnh tìm kiếm.
            if (mtbThoiGian.Text== "  /  /"|| mtbThoiGian.MaskFull == false )
            {
                MessageBox.Show("Bạn chưa nhập thời gian", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mtbThoiGian.Focus();
                return;
            }
            else
            {
                if (rdbHDB.Checked == true)
                {
                    Ketnoi.Connect();
                    string sqlTK = "select hdb.MaHDB,hdb.MaNV,hdb.MaKH,cthdb.MaQA,cthdb.SoLuong,hdb.NgayBan,hdb.DiaChi,hdb.SDT,cthdb.DonGia,cthdb.TongTien from tbl_HoaDonBan hdb join tbl_ChiTietHoaDonBan cthdb on hdb.MaHDB=hdb.MaHDB where Ngayban = '" + mtbThoiGian.Text + "'";
                    dgvTimkiem.DataSource = Ketnoi.Getdatatotable(sqlTK);
                }
                if (rdbHDN.Checked == true)
                {
                    Ketnoi.Connect();
                    string sqlTK = "select hdn.mahdn,hdn.manv,cthdn.mancc,cthdn.MaQA,cthdn.SoLuong,hdn.NgayNhap,hdn.DiaChi,hdn.SDT,cthdn.DonGia,cthdn.TongTien from tbl_HoaDonNhap hdn join tbl_ChiTietHoaDonNhap cthdn on hdn.MaHDN=cthdn.MaHDN where hdn.ngaynhap = '" + mtbThoiGian.Text + "'";
                    dgvTimkiem.DataSource = Ketnoi.Getdatatotable(sqlTK);
                }
                if (rdbHDB.Checked == false && rdbHDN.Checked == false)
                {
                    MessageBox.Show("Bạn chưa chọn loại hóa đơn cần thống kê", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

        }
    }
}
