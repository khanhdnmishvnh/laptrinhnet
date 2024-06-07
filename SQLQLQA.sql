create table tbl_ThongTinQuanAo (
    MaQA char(10) primary key,
    TenQA varchar(50),
    MaNCC char(10),
    SoLuong int,
    GiaBan int,
    foreign key (MaNCC) references tbl_NhaCungCap(MaNCC) on delete cascade on update cascade
);

create table tbl_NhanVien (
    MaNV char(10) primary key,
    TenNV varchar(50),
    GioiTinh nvarchar(50),
    DiaChi nvarchar(50),
    SDT varchar(15)
);

create table tbl_NhaCungCap (
    MaNCC char(10) primary key,
    TenNCC varchar(50),
    DiaChi nvarchar(50),
    SDT varchar(15)
);

create table tbl_KhachHang (
    MaKH char(10) primary key,
    TenKH varchar(50),
    GioiTinh nvarchar(50),
    DiaChi nvarchar(50),
    SDT varchar(15)
);

create table tbl_HoaDonNhap (
    MaHDN char(10) primary key,
    MaNV char(10),
    NgayNhap date,
    DiaChi nvarchar(50),
    SDT varchar(15),
    foreign key (MaNV) references tbl_NhanVien(MaNV) on delete no action on update no action
);

create table tbl_ChiTietHoaDonNhap (
    MaHDN char(10),
    MaQA char(10),
    MaNCC char(10),
    SoLuong int,
    DonGia float,
    TongTien float,
    foreign key (MaHDN) references tbl_HoaDonNhap(MaHDN) on delete cascade on update cascade,
    foreign key (MaQA) references tbl_ThongTinQuanAo(MaQA) on delete no action on update no action,
    foreign key (MaNCC) references tbl_NhaCungCap(MaNCC) on delete no action on update no action
);

create table tbl_HoaDonBan (
    MaHDB char(10) primary key,
    MaNV char(10),
    MaKH char(10),
    NgayBan date,
    DiaChi nvarchar(50),
    SDT varchar(15),
    foreign key (MaNV) references tbl_NhanVien(MaNV) on delete cascade on update cascade,
    foreign key (MaKH) references tbl_KhachHang(MaKH) on delete cascade on update cascade
);

create table tbl_ChiTietHoaDonBan (
    MaHDB char(10),
    MaQA char(10),
    SoLuong int,
    DonGia float,
    TongTien float,
    foreign key (MaHDB) references tbl_HoaDonBan(MaHDB) on delete cascade on update cascade,
    foreign key (MaQA) references tbl_ThongTinQuanAo(MaQA) on delete cascade on update cascade
);

create table tbl_TaiKhoan (
    MaNV char(10) primary key,
    MatKhau varchar(50),
    foreign key (MaNV) references tbl_NhanVien(MaNV) on delete cascade on update cascade
);