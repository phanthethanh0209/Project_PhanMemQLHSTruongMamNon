-- Create database [QLMAMNON_CHUALAPKEHOACH]
USE [QLMAMNON_CHUALAPKEHOACH]
GO
/****** Object:  Table [dbo].[CTPhieuHocPhi]    Script Date: 20/12/2024 12:26:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CTPhieuHocPhi](
	[MaPhieuHP] [varchar](25) NOT NULL,
	[MaKhoanThu] [varchar](25) NOT NULL,
 CONSTRAINT [PK_CTPHIEUHOCPHI] PRIMARY KEY CLUSTERED 
(
	[MaPhieuHP] ASC,
	[MaKhoanThu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DanhGiaThang]    Script Date: 20/12/2024 12:26:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DanhGiaThang](
	[MaDanhGiaThang] [varchar](25) NOT NULL,
	[MaHS] [varchar](25) NOT NULL,
	[MaLop] [varchar](25) NOT NULL,
	[Thang] [int] NOT NULL,
	[DatPhieuChauNgoanBH] [int] NULL,
	[NoiDung] [nvarchar](250) NULL,
 CONSTRAINT [PK_DanhGiaThang] PRIMARY KEY CLUSTERED 
(
	[MaDanhGiaThang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DanhGiaTuan]    Script Date: 20/12/2024 12:26:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DanhGiaTuan](
	[MaDanhGiaTuan] [varchar](35) NOT NULL,
	[MaHS] [varchar](25) NOT NULL,
	[MaLop] [varchar](25) NOT NULL,
	[Tuan] [int] NOT NULL,
	[DatPhieuBeNgoan] [int] NULL,
	[NoiDung] [nvarchar](250) NULL,
	[Thang] [int] NOT NULL,
	[NgayDG] [datetime] NULL,
 CONSTRAINT [PK_Table_1] PRIMARY KEY CLUSTERED 
(
	[MaDanhGiaTuan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DiemDanh]    Script Date: 20/12/2024 12:26:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DiemDanh](
	[MaDiemDanh] [varchar](35) NOT NULL,
	[MaLop] [varchar](25) NULL,
	[MaHS] [varchar](25) NULL,
	[NgayDiemDanh] [date] NULL,
	[VangKPhep] [int] NOT NULL,
	[GhiChu] [nvarchar](250) NULL,
 CONSTRAINT [PK_DiemDanh] PRIMARY KEY CLUSTERED 
(
	[MaDiemDanh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DMManHinh]    Script Date: 20/12/2024 12:26:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DMManHinh](
	[MaMH] [varchar](25) NOT NULL,
	[TenMH] [nvarchar](50) NULL,
 CONSTRAINT [PK_DMManHinh] PRIMARY KEY CLUSTERED 
(
	[MaMH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GiaoVien]    Script Date: 20/12/2024 12:26:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GiaoVien](
	[MaGV] [varchar](25) NOT NULL,
	[TrinhDo] [nvarchar](50) NOT NULL,
	[ChuyenMon] [nvarchar](50) NULL,
	[NoiDaoTao] [nvarchar](50) NULL,
 CONSTRAINT [PK_GiaoVien] PRIMARY KEY CLUSTERED 
(
	[MaGV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HoatDongNgoaiKhoa]    Script Date: 20/12/2024 12:26:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoatDongNgoaiKhoa](
	[MaHD] [varchar](25) NOT NULL,
	[TenHDNK] [nvarchar](50) NOT NULL,
	[NgayTG] [date] NOT NULL,
	[SoTien] [money] NOT NULL,
	[MaNamHoc] [varchar](25) NOT NULL,
	[TrangThaiDK] [nvarchar](50) NULL,
 CONSTRAINT [PK_HoatDongNgoaiKhoa] PRIMARY KEY CLUSTERED 
(
	[MaHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HocSinh]    Script Date: 20/12/2024 12:26:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HocSinh](
	[MaHS] [varchar](25) NOT NULL,
	[MaPH1] [varchar](25) NOT NULL,
	[MaPH2] [varchar](25) NOT NULL,
	[HoTen] [nvarchar](50) NOT NULL,
	[GioiTinh] [nvarchar](5) NOT NULL,
	[NgaySinh] [date] NOT NULL,
	[DiaChi] [nvarchar](100) NOT NULL,
	[ChieuCao] [int] NOT NULL,
	[HinhAnh] [varchar](50) NOT NULL,
	[CanNang] [varchar](10) NOT NULL,
	[NgayNhapHoc] [date] NOT NULL,
	[GhiChu] [nvarchar](200) NULL,
	[TinhTrang] [nvarchar](50) NOT NULL,
	[NgayKetThuc] [date] NULL,
 CONSTRAINT [PK_HocSinh] PRIMARY KEY CLUSTERED 
(
	[MaHS] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HoSoHocSinh]    Script Date: 20/12/2024 12:26:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoSoHocSinh](
	[MaHS] [varchar](25) NOT NULL,
	[MaDinhDanh] [varchar](50) NOT NULL,
	[QuocTich] [nvarchar](50) NOT NULL,
	[DanToc] [nvarchar](50) NOT NULL,
	[TonGiao] [nvarchar](50) NOT NULL,
	[QueQuan] [nvarchar](100) NOT NULL,
	[NoiSinh] [nvarchar](50) NOT NULL,
	[TinhTrangSucKhoe] [nvarchar](200) NOT NULL,
	[GiayKhaiSinh] [varchar](50) NOT NULL,
	[DonXinNhapHoc] [varchar](50) NOT NULL,
 CONSTRAINT [PK_HoSoHocSinh] PRIMARY KEY CLUSTERED 
(
	[MaHS] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KeHoach]    Script Date: 20/12/2024 12:26:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KeHoach](
	[MaNamHoc] [varchar](25) NOT NULL,
	[MaKhoi] [varchar](25) NOT NULL,
	[SoLopMo] [int] NOT NULL,
	[TongHS] [int] NOT NULL,
	[SiSoToiThieu] [int] NOT NULL,
	[SiSoToiDa] [int] NOT NULL,
 CONSTRAINT [PK_KeHoach] PRIMARY KEY CLUSTERED 
(
	[MaNamHoc] ASC,
	[MaKhoi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhoanThu]    Script Date: 20/12/2024 12:26:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhoanThu](
	[MaKhoanThu] [varchar](25) NOT NULL,
	[MaNamHoc] [varchar](25) NOT NULL,
	[TenKhoanThu] [nvarchar](50) NOT NULL,
	[SoTien] [money] NOT NULL,
 CONSTRAINT [PK_KHOANTHU] PRIMARY KEY CLUSTERED 
(
	[MaKhoanThu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhoiLop]    Script Date: 20/12/2024 12:26:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhoiLop](
	[MaKhoi] [varchar](25) NOT NULL,
	[TenKhoi] [nvarchar](50) NOT NULL,
	[DoTuoi] [varchar](5) NOT NULL,
 CONSTRAINT [PK_KhoiLop] PRIMARY KEY CLUSTERED 
(
	[MaKhoi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LopHoc]    Script Date: 20/12/2024 12:26:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LopHoc](
	[MaLop] [varchar](25) NOT NULL,
	[MaKhoi] [varchar](25) NULL,
	[MaNamHoc] [varchar](25) NULL,
	[TenLop] [nvarchar](50) NOT NULL,
	[SiSo] [int] NULL,
	[MaPhong] [varchar](10) NULL,
 CONSTRAINT [PK_LopHoc] PRIMARY KEY CLUSTERED 
(
	[MaLop] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NamHoc]    Script Date: 20/12/2024 12:26:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NamHoc](
	[MaNamHoc] [varchar](25) NOT NULL,
	[TenNamHoc] [nvarchar](25) NOT NULL,
	[NgayDB] [date] NOT NULL,
	[NgayKT] [date] NOT NULL,
 CONSTRAINT [PK_NamHoc] PRIMARY KEY CLUSTERED 
(
	[MaNamHoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NguoiDung]    Script Date: 20/12/2024 12:26:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NguoiDung](
	[MaND] [varchar](25) NOT NULL,
	[TenTK] [nvarchar](50) NOT NULL,
	[MatKhau] [nvarchar](50) NOT NULL,
	[TrangThai] [int] NOT NULL,
	[HoTen] [nvarchar](70) NOT NULL,
	[DienThoai] [varchar](11) NOT NULL,
	[DiaChi] [nvarchar](100) NOT NULL,
	[GioiTinh] [nvarchar](50) NOT NULL,
	[NgaySinh] [datetime] NOT NULL,
	[ChucVu] [nvarchar](100) NOT NULL,
	[Email] [varchar](100) NOT NULL,
 CONSTRAINT [PK_NHANVIEN] PRIMARY KEY CLUSTERED 
(
	[MaND] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NguoiDung_NhomNguoiDung]    Script Date: 20/12/2024 12:26:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NguoiDung_NhomNguoiDung](
	[MaND] [varchar](25) NOT NULL,
	[MaNhomNguoiDung] [varchar](25) NOT NULL,
	[GhiChu] [nvarchar](50) NULL,
 CONSTRAINT [PK_NguoiDung_NhomNguoiDung] PRIMARY KEY CLUSTERED 
(
	[MaND] ASC,
	[MaNhomNguoiDung] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhomNguoiDung]    Script Date: 20/12/2024 12:26:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhomNguoiDung](
	[MaNhom] [varchar](25) NOT NULL,
	[TenNhom] [nvarchar](50) NULL,
	[GhiChu] [nvarchar](50) NULL,
 CONSTRAINT [PK_NhomNguoiDung] PRIMARY KEY CLUSTERED 
(
	[MaNhom] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhanCong]    Script Date: 20/12/2024 12:26:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhanCong](
	[MaLop] [varchar](25) NOT NULL,
	[MaGV] [varchar](25) NOT NULL,
	[VaiTro] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_PhanCong] PRIMARY KEY CLUSTERED 
(
	[MaLop] ASC,
	[MaGV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhanLop]    Script Date: 20/12/2024 12:26:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhanLop](
	[MaHS] [varchar](25) NOT NULL,
	[MaLop] [varchar](25) NOT NULL,
	[DanhGia] [nvarchar](100) NULL,
	[XepLoai] [nvarchar](20) NULL,
 CONSTRAINT [PK_PhanLop_1] PRIMARY KEY CLUSTERED 
(
	[MaHS] ASC,
	[MaLop] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhanQuyen]    Script Date: 20/12/2024 12:26:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhanQuyen](
	[MaNhom] [varchar](25) NOT NULL,
	[MaMH] [varchar](25) NOT NULL,
 CONSTRAINT [PK_PhanQuyen] PRIMARY KEY CLUSTERED 
(
	[MaNhom] ASC,
	[MaMH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhieuHocPhi]    Script Date: 20/12/2024 12:26:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuHocPhi](
	[MaPhieuHP] [varchar](25) NOT NULL,
	[MaHS] [varchar](25) NOT NULL,
	[MaLop] [varchar](25) NOT NULL,
	[MaND] [varchar](25) NOT NULL,
	[NgayLapPhieu] [datetime] NOT NULL,
	[TrangThaiThanhToan] [int] NOT NULL,
	[Thang] [int] NOT NULL,
	[SoNgayHSVang] [int] NOT NULL,
	[SoNgayHSHoc] [int] NOT NULL,
	[TongTien] [money] NOT NULL,
	[TienNhan] [money] NULL,
	[NgayThanhToan] [datetime] NULL,
	[SoBuoiHocTrongThang] [int] NULL,
 CONSTRAINT [PK_PHIEUHOCPHI] PRIMARY KEY CLUSTERED 
(
	[MaPhieuHP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhongHoc]    Script Date: 20/12/2024 12:26:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhongHoc](
	[MaPhong] [varchar](10) NOT NULL,
	[TenPhong] [nvarchar](50) NOT NULL,
	[SucChua] [int] NULL,
	[ViTri] [nvarchar](50) NULL,
	[TinhTrang] [nvarchar](50) NULL,
 CONSTRAINT [PK_PhongHoc] PRIMARY KEY CLUSTERED 
(
	[MaPhong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhuHuynh]    Script Date: 20/12/2024 12:26:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhuHuynh](
	[MaPH] [varchar](25) NOT NULL,
	[HoTen] [nvarchar](50) NOT NULL,
	[GioiTinh] [nvarchar](10) NOT NULL,
	[NamSinh] [int] NOT NULL,
	[DiaChiCQ] [nvarchar](100) NOT NULL,
	[NgheNghiep] [nvarchar](50) NOT NULL,
	[DienThoai] [varchar](10) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[QuanHe] [nvarchar](50) NULL,
 CONSTRAINT [PK_PhuHuynh] PRIMARY KEY CLUSTERED 
(
	[MaPH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ThamGiaNgoaiKhoa]    Script Date: 20/12/2024 12:26:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThamGiaNgoaiKhoa](
	[MaTTHD] [varchar](25) NOT NULL,
	[NgayDK] [datetime] NOT NULL,
	[MaHD] [varchar](25) NOT NULL,
	[MaHS] [varchar](25) NOT NULL,
	[TienNhan] [money] NOT NULL,
	[MaND] [varchar](25) NULL,
 CONSTRAINT [PK_ThamGiaNgoaiKhoa] PRIMARY KEY CLUSTERED 
(
	[MaTTHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[CTPhieuHocPhi] ([MaPhieuHP], [MaKhoanThu]) VALUES (N'HP2324T12_HSNH23240001', N'KT232401')
INSERT [dbo].[CTPhieuHocPhi] ([MaPhieuHP], [MaKhoanThu]) VALUES (N'HP2324T12_HSNH23240001', N'KT232402')
INSERT [dbo].[CTPhieuHocPhi] ([MaPhieuHP], [MaKhoanThu]) VALUES (N'HP2324T12_HSNH23240002', N'KT232401')
INSERT [dbo].[CTPhieuHocPhi] ([MaPhieuHP], [MaKhoanThu]) VALUES (N'HP2324T12_HSNH23240002', N'KT232402')
INSERT [dbo].[CTPhieuHocPhi] ([MaPhieuHP], [MaKhoanThu]) VALUES (N'HP2324T12_HSNH23240003', N'KT232401')
INSERT [dbo].[CTPhieuHocPhi] ([MaPhieuHP], [MaKhoanThu]) VALUES (N'HP2324T12_HSNH23240003', N'KT232402')
INSERT [dbo].[CTPhieuHocPhi] ([MaPhieuHP], [MaKhoanThu]) VALUES (N'HP2324T12_HSNH23240004', N'KT232401')
INSERT [dbo].[CTPhieuHocPhi] ([MaPhieuHP], [MaKhoanThu]) VALUES (N'HP2324T12_HSNH23240004', N'KT232402')
INSERT [dbo].[CTPhieuHocPhi] ([MaPhieuHP], [MaKhoanThu]) VALUES (N'HP2324T12_HSNH23240005', N'KT232401')
INSERT [dbo].[CTPhieuHocPhi] ([MaPhieuHP], [MaKhoanThu]) VALUES (N'HP2324T12_HSNH23240005', N'KT232402')
INSERT [dbo].[CTPhieuHocPhi] ([MaPhieuHP], [MaKhoanThu]) VALUES (N'HP2324T12_HSNH23240006', N'KT232401')
INSERT [dbo].[CTPhieuHocPhi] ([MaPhieuHP], [MaKhoanThu]) VALUES (N'HP2324T12_HSNH23240006', N'KT232402')
INSERT [dbo].[CTPhieuHocPhi] ([MaPhieuHP], [MaKhoanThu]) VALUES (N'HP2324T12_HSNH23240007', N'KT232401')
INSERT [dbo].[CTPhieuHocPhi] ([MaPhieuHP], [MaKhoanThu]) VALUES (N'HP2324T12_HSNH23240007', N'KT232402')
INSERT [dbo].[CTPhieuHocPhi] ([MaPhieuHP], [MaKhoanThu]) VALUES (N'HP2324T12_HSNH23240008', N'KT232401')
INSERT [dbo].[CTPhieuHocPhi] ([MaPhieuHP], [MaKhoanThu]) VALUES (N'HP2324T12_HSNH23240008', N'KT232402')
INSERT [dbo].[CTPhieuHocPhi] ([MaPhieuHP], [MaKhoanThu]) VALUES (N'HP2324T12_HSNH23240009', N'KT232401')
INSERT [dbo].[CTPhieuHocPhi] ([MaPhieuHP], [MaKhoanThu]) VALUES (N'HP2324T12_HSNH23240009', N'KT232402')
INSERT [dbo].[CTPhieuHocPhi] ([MaPhieuHP], [MaKhoanThu]) VALUES (N'HP2324T12_HSNH23240010', N'KT232401')
INSERT [dbo].[CTPhieuHocPhi] ([MaPhieuHP], [MaKhoanThu]) VALUES (N'HP2324T12_HSNH23240010', N'KT232402')
INSERT [dbo].[CTPhieuHocPhi] ([MaPhieuHP], [MaKhoanThu]) VALUES (N'HP2324T12_HSNH23240011', N'KT232401')
INSERT [dbo].[CTPhieuHocPhi] ([MaPhieuHP], [MaKhoanThu]) VALUES (N'HP2324T12_HSNH23240011', N'KT232402')
INSERT [dbo].[CTPhieuHocPhi] ([MaPhieuHP], [MaKhoanThu]) VALUES (N'HP2324T12_HSNH23240012', N'KT232401')
INSERT [dbo].[CTPhieuHocPhi] ([MaPhieuHP], [MaKhoanThu]) VALUES (N'HP2324T12_HSNH23240012', N'KT232402')
INSERT [dbo].[CTPhieuHocPhi] ([MaPhieuHP], [MaKhoanThu]) VALUES (N'HP2324T12_HSNH23240013', N'KT232401')
INSERT [dbo].[CTPhieuHocPhi] ([MaPhieuHP], [MaKhoanThu]) VALUES (N'HP2324T12_HSNH23240013', N'KT232402')
INSERT [dbo].[CTPhieuHocPhi] ([MaPhieuHP], [MaKhoanThu]) VALUES (N'HP2324T12_HSNH23240014', N'KT232401')
INSERT [dbo].[CTPhieuHocPhi] ([MaPhieuHP], [MaKhoanThu]) VALUES (N'HP2324T12_HSNH23240014', N'KT232402')
INSERT [dbo].[CTPhieuHocPhi] ([MaPhieuHP], [MaKhoanThu]) VALUES (N'HP2324T12_HSNH23240015', N'KT232401')
INSERT [dbo].[CTPhieuHocPhi] ([MaPhieuHP], [MaKhoanThu]) VALUES (N'HP2324T12_HSNH23240015', N'KT232402')
INSERT [dbo].[CTPhieuHocPhi] ([MaPhieuHP], [MaKhoanThu]) VALUES (N'HP2324T12_HSNH23240016', N'KT232401')
INSERT [dbo].[CTPhieuHocPhi] ([MaPhieuHP], [MaKhoanThu]) VALUES (N'HP2324T12_HSNH23240016', N'KT232402')
INSERT [dbo].[CTPhieuHocPhi] ([MaPhieuHP], [MaKhoanThu]) VALUES (N'HP2324T12_HSNH23240017', N'KT232401')
INSERT [dbo].[CTPhieuHocPhi] ([MaPhieuHP], [MaKhoanThu]) VALUES (N'HP2324T12_HSNH23240017', N'KT232402')
INSERT [dbo].[CTPhieuHocPhi] ([MaPhieuHP], [MaKhoanThu]) VALUES (N'HP2324T12_HSNH23240018', N'KT232401')
INSERT [dbo].[CTPhieuHocPhi] ([MaPhieuHP], [MaKhoanThu]) VALUES (N'HP2324T12_HSNH23240018', N'KT232402')
INSERT [dbo].[CTPhieuHocPhi] ([MaPhieuHP], [MaKhoanThu]) VALUES (N'HP2324T12_HSNH23240019', N'KT232401')
INSERT [dbo].[CTPhieuHocPhi] ([MaPhieuHP], [MaKhoanThu]) VALUES (N'HP2324T12_HSNH23240019', N'KT232402')
INSERT [dbo].[CTPhieuHocPhi] ([MaPhieuHP], [MaKhoanThu]) VALUES (N'HP2324T12_HSNH23240020', N'KT232401')
INSERT [dbo].[CTPhieuHocPhi] ([MaPhieuHP], [MaKhoanThu]) VALUES (N'HP2324T12_HSNH23240020', N'KT232402')
INSERT [dbo].[CTPhieuHocPhi] ([MaPhieuHP], [MaKhoanThu]) VALUES (N'HP2324T12_HSNH23240022', N'KT232401')
INSERT [dbo].[CTPhieuHocPhi] ([MaPhieuHP], [MaKhoanThu]) VALUES (N'HP2324T12_HSNH23240022', N'KT232402')
INSERT [dbo].[CTPhieuHocPhi] ([MaPhieuHP], [MaKhoanThu]) VALUES (N'HP2324T12_HSNH23240023', N'KT232401')
INSERT [dbo].[CTPhieuHocPhi] ([MaPhieuHP], [MaKhoanThu]) VALUES (N'HP2324T12_HSNH23240023', N'KT232402')
INSERT [dbo].[CTPhieuHocPhi] ([MaPhieuHP], [MaKhoanThu]) VALUES (N'HP2324T12_HSNH23240025', N'KT232401')
INSERT [dbo].[CTPhieuHocPhi] ([MaPhieuHP], [MaKhoanThu]) VALUES (N'HP2324T12_HSNH23240025', N'KT232402')
INSERT [dbo].[CTPhieuHocPhi] ([MaPhieuHP], [MaKhoanThu]) VALUES (N'HP2324T12_HSNH23240026', N'KT232401')
INSERT [dbo].[CTPhieuHocPhi] ([MaPhieuHP], [MaKhoanThu]) VALUES (N'HP2324T12_HSNH23240026', N'KT232402')
INSERT [dbo].[CTPhieuHocPhi] ([MaPhieuHP], [MaKhoanThu]) VALUES (N'HP2324T12_HSNH23240027', N'KT232401')
INSERT [dbo].[CTPhieuHocPhi] ([MaPhieuHP], [MaKhoanThu]) VALUES (N'HP2324T12_HSNH23240027', N'KT232402')
INSERT [dbo].[CTPhieuHocPhi] ([MaPhieuHP], [MaKhoanThu]) VALUES (N'HP2324T12_HSNH23240028', N'KT232401')
INSERT [dbo].[CTPhieuHocPhi] ([MaPhieuHP], [MaKhoanThu]) VALUES (N'HP2324T12_HSNH23240028', N'KT232402')
INSERT [dbo].[CTPhieuHocPhi] ([MaPhieuHP], [MaKhoanThu]) VALUES (N'HP2324T12_HSNH23240031', N'KT232401')
INSERT [dbo].[CTPhieuHocPhi] ([MaPhieuHP], [MaKhoanThu]) VALUES (N'HP2324T12_HSNH23240031', N'KT232402')
INSERT [dbo].[CTPhieuHocPhi] ([MaPhieuHP], [MaKhoanThu]) VALUES (N'HP2324T12_HSNH23240032', N'KT232401')
INSERT [dbo].[CTPhieuHocPhi] ([MaPhieuHP], [MaKhoanThu]) VALUES (N'HP2324T12_HSNH23240032', N'KT232402')
INSERT [dbo].[CTPhieuHocPhi] ([MaPhieuHP], [MaKhoanThu]) VALUES (N'HP2324T12_HSNH23240033', N'KT232401')
INSERT [dbo].[CTPhieuHocPhi] ([MaPhieuHP], [MaKhoanThu]) VALUES (N'HP2324T12_HSNH23240033', N'KT232402')
INSERT [dbo].[CTPhieuHocPhi] ([MaPhieuHP], [MaKhoanThu]) VALUES (N'HP2324T12_HSNH23240036', N'KT232401')
INSERT [dbo].[CTPhieuHocPhi] ([MaPhieuHP], [MaKhoanThu]) VALUES (N'HP2324T12_HSNH23240036', N'KT232402')
INSERT [dbo].[CTPhieuHocPhi] ([MaPhieuHP], [MaKhoanThu]) VALUES (N'HP2324T12_HSNH23240037', N'KT232401')
INSERT [dbo].[CTPhieuHocPhi] ([MaPhieuHP], [MaKhoanThu]) VALUES (N'HP2324T12_HSNH23240037', N'KT232402')
INSERT [dbo].[CTPhieuHocPhi] ([MaPhieuHP], [MaKhoanThu]) VALUES (N'HP2324T12_HSNH23240038', N'KT232401')
INSERT [dbo].[CTPhieuHocPhi] ([MaPhieuHP], [MaKhoanThu]) VALUES (N'HP2324T12_HSNH23240038', N'KT232402')
GO
INSERT [dbo].[DanhGiaThang] ([MaDanhGiaThang], [MaHS], [MaLop], [Thang], [DatPhieuChauNgoanBH], [NoiDung]) VALUES (N'DGT01NH2324_HSNH23240011', N'HSNH23240011', N'LLA2324001', 1, 1, N'Bé vâng lời')
INSERT [dbo].[DanhGiaThang] ([MaDanhGiaThang], [MaHS], [MaLop], [Thang], [DatPhieuChauNgoanBH], [NoiDung]) VALUES (N'DGT02NH2324_HSNH23240011', N'HSNH23240011', N'LLA2324001', 2, 1, N'Bé vâng lời')
INSERT [dbo].[DanhGiaThang] ([MaDanhGiaThang], [MaHS], [MaLop], [Thang], [DatPhieuChauNgoanBH], [NoiDung]) VALUES (N'DGT03NH2324_HSNH23240011', N'HSNH23240011', N'LLA2324001', 3, 1, N'Bé vâng lời')
INSERT [dbo].[DanhGiaThang] ([MaDanhGiaThang], [MaHS], [MaLop], [Thang], [DatPhieuChauNgoanBH], [NoiDung]) VALUES (N'DGT04NH2324_HSNH23240011', N'HSNH23240011', N'LLA2324001', 4, 1, N'Bé vâng lời')
INSERT [dbo].[DanhGiaThang] ([MaDanhGiaThang], [MaHS], [MaLop], [Thang], [DatPhieuChauNgoanBH], [NoiDung]) VALUES (N'DGT05NH2324_HSNH23240011', N'HSNH23240011', N'LLA2324001', 5, 1, N'Bé vâng lời')
INSERT [dbo].[DanhGiaThang] ([MaDanhGiaThang], [MaHS], [MaLop], [Thang], [DatPhieuChauNgoanBH], [NoiDung]) VALUES (N'DGT09NH2324_HSNH23240011', N'HSNH23240011', N'LLA2324001', 9, 1, N'Bé vâng lời')
INSERT [dbo].[DanhGiaThang] ([MaDanhGiaThang], [MaHS], [MaLop], [Thang], [DatPhieuChauNgoanBH], [NoiDung]) VALUES (N'DGT10NH2324_HSNH23240011', N'HSNH23240011', N'LLA2324001', 10, 1, N'Bé vâng lời')
INSERT [dbo].[DanhGiaThang] ([MaDanhGiaThang], [MaHS], [MaLop], [Thang], [DatPhieuChauNgoanBH], [NoiDung]) VALUES (N'DGT11NH2324_HSNH23240011', N'HSNH23240011', N'LLA2324001', 11, 1, N'Bé vâng lời')
INSERT [dbo].[DanhGiaThang] ([MaDanhGiaThang], [MaHS], [MaLop], [Thang], [DatPhieuChauNgoanBH], [NoiDung]) VALUES (N'DGT12NH2324_HSNH23240011', N'HSNH23240011', N'LLA2324001', 12, 1, N'Bé vâng lời')
INSERT [dbo].[DanhGiaThang] ([MaDanhGiaThang], [MaHS], [MaLop], [Thang], [DatPhieuChauNgoanBH], [NoiDung]) VALUES (N'DGT12NH2324_HSNH23240012', N'HSNH23240012', N'LLA2324001', 12, 0, N'Bé chăm')
INSERT [dbo].[DanhGiaThang] ([MaDanhGiaThang], [MaHS], [MaLop], [Thang], [DatPhieuChauNgoanBH], [NoiDung]) VALUES (N'DGT12NH2324_HSNH23240013', N'HSNH23240013', N'LLA2324001', 12, 0, N'Bé giỏi')
INSERT [dbo].[DanhGiaThang] ([MaDanhGiaThang], [MaHS], [MaLop], [Thang], [DatPhieuChauNgoanBH], [NoiDung]) VALUES (N'DGT12NH2324_HSNH23240014', N'HSNH23240014', N'LLA2324001', 12, 0, N'Bé không nói')
GO
INSERT [dbo].[DanhGiaTuan] ([MaDanhGiaTuan], [MaHS], [MaLop], [Tuan], [DatPhieuBeNgoan], [NoiDung], [Thang], [NgayDG]) VALUES (N'DGT12T1NH2324_HSNH23240001', N'HSNH23240001', N'LMN2324001', 1, 1, N'Bé ham chơi', 12, CAST(N'2023-11-24T00:00:00.000' AS DateTime))
INSERT [dbo].[DanhGiaTuan] ([MaDanhGiaTuan], [MaHS], [MaLop], [Tuan], [DatPhieuBeNgoan], [NoiDung], [Thang], [NgayDG]) VALUES (N'DGT12T1NH2324_HSNH23240002', N'HSNH23240002', N'LMN2324001', 1, 0, N'Bé lỳ', 12, CAST(N'2023-11-24T00:00:00.000' AS DateTime))
INSERT [dbo].[DanhGiaTuan] ([MaDanhGiaTuan], [MaHS], [MaLop], [Tuan], [DatPhieuBeNgoan], [NoiDung], [Thang], [NgayDG]) VALUES (N'DGT12T1NH2324_HSNH23240003', N'HSNH23240003', N'LMN2324001', 1, 1, N'Bé hay hát', 12, CAST(N'2023-11-24T00:00:00.000' AS DateTime))
INSERT [dbo].[DanhGiaTuan] ([MaDanhGiaTuan], [MaHS], [MaLop], [Tuan], [DatPhieuBeNgoan], [NoiDung], [Thang], [NgayDG]) VALUES (N'DGT12T1NH2324_HSNH23240004', N'HSNH23240004', N'LMN2324001', 1, 0, N'Bé khỏe', 12, CAST(N'2023-11-24T00:00:00.000' AS DateTime))
INSERT [dbo].[DanhGiaTuan] ([MaDanhGiaTuan], [MaHS], [MaLop], [Tuan], [DatPhieuBeNgoan], [NoiDung], [Thang], [NgayDG]) VALUES (N'DGT12T1NH2324_HSNH23240006', N'HSNH23240006', N'LLC2324001', 1, 0, N'Bé ham chơi', 12, CAST(N'2023-11-24T00:00:00.000' AS DateTime))
INSERT [dbo].[DanhGiaTuan] ([MaDanhGiaTuan], [MaHS], [MaLop], [Tuan], [DatPhieuBeNgoan], [NoiDung], [Thang], [NgayDG]) VALUES (N'DGT12T1NH2324_HSNH23240007', N'HSNH23240007', N'LLC2324001', 1, 0, N'Bé giỏi', 12, CAST(N'2023-11-24T00:00:00.000' AS DateTime))
INSERT [dbo].[DanhGiaTuan] ([MaDanhGiaTuan], [MaHS], [MaLop], [Tuan], [DatPhieuBeNgoan], [NoiDung], [Thang], [NgayDG]) VALUES (N'DGT12T1NH2324_HSNH23240008', N'HSNH23240008', N'LLC2324001', 1, 1, N'Bé hay hát', 12, CAST(N'2023-11-24T00:00:00.000' AS DateTime))
INSERT [dbo].[DanhGiaTuan] ([MaDanhGiaTuan], [MaHS], [MaLop], [Tuan], [DatPhieuBeNgoan], [NoiDung], [Thang], [NgayDG]) VALUES (N'DGT12T1NH2324_HSNH23240009', N'HSNH23240009', N'LLC2324001', 1, 1, N'Bé chăm học', 12, CAST(N'2023-11-24T00:00:00.000' AS DateTime))
INSERT [dbo].[DanhGiaTuan] ([MaDanhGiaTuan], [MaHS], [MaLop], [Tuan], [DatPhieuBeNgoan], [NoiDung], [Thang], [NgayDG]) VALUES (N'DGT12T1NH2324_HSNH23240011', N'HSNH23240011', N'LLA2324001', 1, 1, N'Bé hay mút tay', 12, CAST(N'2023-11-24T00:00:00.000' AS DateTime))
INSERT [dbo].[DanhGiaTuan] ([MaDanhGiaTuan], [MaHS], [MaLop], [Tuan], [DatPhieuBeNgoan], [NoiDung], [Thang], [NgayDG]) VALUES (N'DGT12T1NH2324_HSNH23240012', N'HSNH23240012', N'LLA2324001', 1, 1, N'Bé hay cười', 12, CAST(N'2023-11-24T00:00:00.000' AS DateTime))
INSERT [dbo].[DanhGiaTuan] ([MaDanhGiaTuan], [MaHS], [MaLop], [Tuan], [DatPhieuBeNgoan], [NoiDung], [Thang], [NgayDG]) VALUES (N'DGT12T1NH2324_HSNH23240013', N'HSNH23240013', N'LLA2324001', 1, 1, N'Bé giỏi', 12, CAST(N'2023-11-24T00:00:00.000' AS DateTime))
INSERT [dbo].[DanhGiaTuan] ([MaDanhGiaTuan], [MaHS], [MaLop], [Tuan], [DatPhieuBeNgoan], [NoiDung], [Thang], [NgayDG]) VALUES (N'DGT12T1NH2324_HSNH23240014', N'HSNH23240014', N'LLA2324001', 1, 1, N'Bé hay đánh bạn', 12, CAST(N'2023-11-24T00:00:00.000' AS DateTime))
INSERT [dbo].[DanhGiaTuan] ([MaDanhGiaTuan], [MaHS], [MaLop], [Tuan], [DatPhieuBeNgoan], [NoiDung], [Thang], [NgayDG]) VALUES (N'DGT12T1NH2324_HSNH23240016', N'HSNH23240016', N'LNT2324001', 1, 1, N'Bé chăm ngoan', 12, CAST(N'2023-11-24T00:00:00.000' AS DateTime))
INSERT [dbo].[DanhGiaTuan] ([MaDanhGiaTuan], [MaHS], [MaLop], [Tuan], [DatPhieuBeNgoan], [NoiDung], [Thang], [NgayDG]) VALUES (N'DGT12T1NH2324_HSNH23240017', N'HSNH23240017', N'LNT2324001', 1, 0, N'Bé còn quậy quá', 12, CAST(N'2023-11-24T00:00:00.000' AS DateTime))
INSERT [dbo].[DanhGiaTuan] ([MaDanhGiaTuan], [MaHS], [MaLop], [Tuan], [DatPhieuBeNgoan], [NoiDung], [Thang], [NgayDG]) VALUES (N'DGT12T1NH2324_HSNH23240018', N'HSNH23240018', N'LNT2324001', 1, 1, N'Bé chăm ngoan', 12, CAST(N'2023-11-24T00:00:00.000' AS DateTime))
INSERT [dbo].[DanhGiaTuan] ([MaDanhGiaTuan], [MaHS], [MaLop], [Tuan], [DatPhieuBeNgoan], [NoiDung], [Thang], [NgayDG]) VALUES (N'DGT12T1NH2324_HSNH23240019', N'HSNH23240019', N'LNT2324001', 1, 1, N'Bé ăn chậm', 12, CAST(N'2023-11-24T00:00:00.000' AS DateTime))
INSERT [dbo].[DanhGiaTuan] ([MaDanhGiaTuan], [MaHS], [MaLop], [Tuan], [DatPhieuBeNgoan], [NoiDung], [Thang], [NgayDG]) VALUES (N'DGT12T2NH2324_HSNH23240011', N'HSNH23240011', N'LLA2324001', 2, 1, N'Bé vui vẻ', 12, CAST(N'2023-12-01T00:00:00.000' AS DateTime))
INSERT [dbo].[DanhGiaTuan] ([MaDanhGiaTuan], [MaHS], [MaLop], [Tuan], [DatPhieuBeNgoan], [NoiDung], [Thang], [NgayDG]) VALUES (N'DGT12T2NH2324_HSNH23240012', N'HSNH23240012', N'LLA2324001', 2, 0, N'Bé biếng ăn', 12, CAST(N'2023-12-01T00:00:00.000' AS DateTime))
INSERT [dbo].[DanhGiaTuan] ([MaDanhGiaTuan], [MaHS], [MaLop], [Tuan], [DatPhieuBeNgoan], [NoiDung], [Thang], [NgayDG]) VALUES (N'DGT12T2NH2324_HSNH23240013', N'HSNH23240013', N'LLA2324001', 2, 1, N'Bé lỳ quá', 12, CAST(N'2023-12-01T00:00:00.000' AS DateTime))
INSERT [dbo].[DanhGiaTuan] ([MaDanhGiaTuan], [MaHS], [MaLop], [Tuan], [DatPhieuBeNgoan], [NoiDung], [Thang], [NgayDG]) VALUES (N'DGT12T2NH2324_HSNH23240014', N'HSNH23240014', N'LLA2324001', 2, 0, N'Bé biếng ăn', 12, CAST(N'2023-12-01T00:00:00.000' AS DateTime))
INSERT [dbo].[DanhGiaTuan] ([MaDanhGiaTuan], [MaHS], [MaLop], [Tuan], [DatPhieuBeNgoan], [NoiDung], [Thang], [NgayDG]) VALUES (N'DGT12T3NH2324_HSNH23240011', N'HSNH23240011', N'LLA2324001', 3, 1, N'Bé siêng năng', 12, CAST(N'2023-12-08T00:00:00.000' AS DateTime))
INSERT [dbo].[DanhGiaTuan] ([MaDanhGiaTuan], [MaHS], [MaLop], [Tuan], [DatPhieuBeNgoan], [NoiDung], [Thang], [NgayDG]) VALUES (N'DGT12T3NH2324_HSNH23240012', N'HSNH23240012', N'LLA2324001', 3, 0, N'Bé giỏi', 12, CAST(N'2023-12-08T00:00:00.000' AS DateTime))
INSERT [dbo].[DanhGiaTuan] ([MaDanhGiaTuan], [MaHS], [MaLop], [Tuan], [DatPhieuBeNgoan], [NoiDung], [Thang], [NgayDG]) VALUES (N'DGT12T3NH2324_HSNH23240013', N'HSNH23240013', N'LLA2324001', 3, 1, N'Bé lỳ', 12, CAST(N'2023-12-08T00:00:00.000' AS DateTime))
INSERT [dbo].[DanhGiaTuan] ([MaDanhGiaTuan], [MaHS], [MaLop], [Tuan], [DatPhieuBeNgoan], [NoiDung], [Thang], [NgayDG]) VALUES (N'DGT12T3NH2324_HSNH23240014', N'HSNH23240014', N'LLA2324001', 3, 0, N'Bé chăm chỉ', 12, CAST(N'2023-12-08T00:00:00.000' AS DateTime))
INSERT [dbo].[DanhGiaTuan] ([MaDanhGiaTuan], [MaHS], [MaLop], [Tuan], [DatPhieuBeNgoan], [NoiDung], [Thang], [NgayDG]) VALUES (N'DGT12T4NH2324_HSNH23240011', N'HSNH23240011', N'LLA2324001', 4, 1, N'Bé vâng lời', 12, CAST(N'2023-12-08T00:00:00.000' AS DateTime))
INSERT [dbo].[DanhGiaTuan] ([MaDanhGiaTuan], [MaHS], [MaLop], [Tuan], [DatPhieuBeNgoan], [NoiDung], [Thang], [NgayDG]) VALUES (N'DGT12T4NH2324_HSNH23240012', N'HSNH23240012', N'LLA2324001', 4, 0, N'Bé chăm', 12, CAST(N'2023-12-15T00:00:00.000' AS DateTime))
INSERT [dbo].[DanhGiaTuan] ([MaDanhGiaTuan], [MaHS], [MaLop], [Tuan], [DatPhieuBeNgoan], [NoiDung], [Thang], [NgayDG]) VALUES (N'DGT12T4NH2324_HSNH23240013', N'HSNH23240013', N'LLA2324001', 4, 0, N'Bé giỏi', 12, CAST(N'2023-12-15T00:00:00.000' AS DateTime))
INSERT [dbo].[DanhGiaTuan] ([MaDanhGiaTuan], [MaHS], [MaLop], [Tuan], [DatPhieuBeNgoan], [NoiDung], [Thang], [NgayDG]) VALUES (N'DGT12T4NH2324_HSNH23240014', N'HSNH23240014', N'LLA2324001', 4, 0, N'Bé không nói', 12, CAST(N'2023-12-15T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[DiemDanh] ([MaDiemDanh], [MaLop], [MaHS], [NgayDiemDanh], [VangKPhep], [GhiChu]) VALUES (N'DDLLA2324001241223_HSNH23240011', N'LLA2324001', N'HSNH23240011', CAST(N'2023-11-24' AS Date), 1, N'Bé sốt')
INSERT [dbo].[DiemDanh] ([MaDiemDanh], [MaLop], [MaHS], [NgayDiemDanh], [VangKPhep], [GhiChu]) VALUES (N'DDLLA2324001241223_HSNH23240012', N'LLA2324001', N'HSNH23240012', CAST(N'2023-11-24' AS Date), 0, NULL)
INSERT [dbo].[DiemDanh] ([MaDiemDanh], [MaLop], [MaHS], [NgayDiemDanh], [VangKPhep], [GhiChu]) VALUES (N'DDLLA2324001241223_HSNH23240013', N'LLA2324001', N'HSNH23240013', CAST(N'2023-11-24' AS Date), 1, N'Nhà có việc')
INSERT [dbo].[DiemDanh] ([MaDiemDanh], [MaLop], [MaHS], [NgayDiemDanh], [VangKPhep], [GhiChu]) VALUES (N'DDLLA2324002011223_HSNH23240037', N'LLA2324002', N'HSNH23240037', CAST(N'2023-12-01' AS Date), 0, N'')
INSERT [dbo].[DiemDanh] ([MaDiemDanh], [MaLop], [MaHS], [NgayDiemDanh], [VangKPhep], [GhiChu]) VALUES (N'DDLLA2324002011223_HSNH23240038', N'LLA2324002', N'HSNH23240038', CAST(N'2023-12-01' AS Date), 0, N'')
INSERT [dbo].[DiemDanh] ([MaDiemDanh], [MaLop], [MaHS], [NgayDiemDanh], [VangKPhep], [GhiChu]) VALUES (N'DDLLA2324002021223_HSNH23240015', N'LLA2324002', N'HSNH23240015', CAST(N'2023-12-02' AS Date), 0, N'')
INSERT [dbo].[DiemDanh] ([MaDiemDanh], [MaLop], [MaHS], [NgayDiemDanh], [VangKPhep], [GhiChu]) VALUES (N'DDLLA2324002021223_HSNH23240038', N'LLA2324002', N'HSNH23240038', CAST(N'2023-12-02' AS Date), 1, N'Bé bệnh')
INSERT [dbo].[DiemDanh] ([MaDiemDanh], [MaLop], [MaHS], [NgayDiemDanh], [VangKPhep], [GhiChu]) VALUES (N'DDLLA2324002291123_HSNH23240015', N'LLA2324002', N'HSNH23240015', CAST(N'2023-11-29' AS Date), 1, N'Bệnh dạ dày')
INSERT [dbo].[DiemDanh] ([MaDiemDanh], [MaLop], [MaHS], [NgayDiemDanh], [VangKPhep], [GhiChu]) VALUES (N'DDLLA2324002291123_HSNH23240036', N'LLA2324002', N'HSNH23240036', CAST(N'2023-11-29' AS Date), 0, N'')
INSERT [dbo].[DiemDanh] ([MaDiemDanh], [MaLop], [MaHS], [NgayDiemDanh], [VangKPhep], [GhiChu]) VALUES (N'DDLLA2324002301123_HSNH23240015', N'LLA2324002', N'HSNH23240015', CAST(N'2023-11-30' AS Date), 1, N'Bệnh dạ dày')
INSERT [dbo].[DiemDanh] ([MaDiemDanh], [MaLop], [MaHS], [NgayDiemDanh], [VangKPhep], [GhiChu]) VALUES (N'DDLLC2324001011224_HSNH23240008', N'LLC2324001', N'HSNH23240008', CAST(N'2024-12-01' AS Date), 1, N'Về quê')
INSERT [dbo].[DiemDanh] ([MaDiemDanh], [MaLop], [MaHS], [NgayDiemDanh], [VangKPhep], [GhiChu]) VALUES (N'DDLLC2324001011224_HSNH23240009', N'LLC2324001', N'HSNH23240009', CAST(N'2024-12-01' AS Date), 0, N'')
INSERT [dbo].[DiemDanh] ([MaDiemDanh], [MaLop], [MaHS], [NgayDiemDanh], [VangKPhep], [GhiChu]) VALUES (N'DDLLC2324001021224_HSNH23240008', N'LLC2324001', N'HSNH23240008', CAST(N'2024-12-02' AS Date), 0, N'')
INSERT [dbo].[DiemDanh] ([MaDiemDanh], [MaLop], [MaHS], [NgayDiemDanh], [VangKPhep], [GhiChu]) VALUES (N'DDLLC2324001021224_HSNH23240009', N'LLC2324001', N'HSNH23240009', CAST(N'2024-12-02' AS Date), 0, N'')
INSERT [dbo].[DiemDanh] ([MaDiemDanh], [MaLop], [MaHS], [NgayDiemDanh], [VangKPhep], [GhiChu]) VALUES (N'DDLLC2324001241223_HSNH23240007', N'LLC2324001', N'HSNH23240007', CAST(N'2023-11-24' AS Date), 1, N'Bé đi du lịch')
INSERT [dbo].[DiemDanh] ([MaDiemDanh], [MaLop], [MaHS], [NgayDiemDanh], [VangKPhep], [GhiChu]) VALUES (N'DDLLC2324001241223_HSNH23240008', N'LLC2324001', N'HSNH23240008', CAST(N'2023-11-24' AS Date), 0, NULL)
INSERT [dbo].[DiemDanh] ([MaDiemDanh], [MaLop], [MaHS], [NgayDiemDanh], [VangKPhep], [GhiChu]) VALUES (N'DDLLC2324001241223_HSNH23240009', N'LLC2324001', N'HSNH23240009', CAST(N'2023-12-24' AS Date), 1, N'Bé sốt')
INSERT [dbo].[DiemDanh] ([MaDiemDanh], [MaLop], [MaHS], [NgayDiemDanh], [VangKPhep], [GhiChu]) VALUES (N'DDLLC2324001251123_HSNH23240007', N'LLC2324001', N'HSNH23240007', CAST(N'2023-11-25' AS Date), 1, N'Bé đi đám')
INSERT [dbo].[DiemDanh] ([MaDiemDanh], [MaLop], [MaHS], [NgayDiemDanh], [VangKPhep], [GhiChu]) VALUES (N'DDLLC2324001251223_HSNH23240009', N'LLC2324001', N'HSNH23240009', CAST(N'2023-12-25' AS Date), 0, NULL)
INSERT [dbo].[DiemDanh] ([MaDiemDanh], [MaLop], [MaHS], [NgayDiemDanh], [VangKPhep], [GhiChu]) VALUES (N'DDLLC2324001291124_HSNH23240006', N'LLC2324001', N'HSNH23240006', CAST(N'2024-11-29' AS Date), 0, N'')
INSERT [dbo].[DiemDanh] ([MaDiemDanh], [MaLop], [MaHS], [NgayDiemDanh], [VangKPhep], [GhiChu]) VALUES (N'DDLLC2324001291124_HSNH23240008', N'LLC2324001', N'HSNH23240008', CAST(N'2024-11-29' AS Date), 1, N'Ăn đám cưới')
INSERT [dbo].[DiemDanh] ([MaDiemDanh], [MaLop], [MaHS], [NgayDiemDanh], [VangKPhep], [GhiChu]) VALUES (N'DDLLC2324001301124_HSNH23240007', N'LLC2324001', N'HSNH23240007', CAST(N'2024-11-30' AS Date), 0, N'')
INSERT [dbo].[DiemDanh] ([MaDiemDanh], [MaLop], [MaHS], [NgayDiemDanh], [VangKPhep], [GhiChu]) VALUES (N'DDLLC2324001301124_HSNH23240008', N'LLC2324001', N'HSNH23240008', CAST(N'2024-11-30' AS Date), 0, N'')
INSERT [dbo].[DiemDanh] ([MaDiemDanh], [MaLop], [MaHS], [NgayDiemDanh], [VangKPhep], [GhiChu]) VALUES (N'DDLMN2324001241223_HSNH23240001', N'LMN2324001', N'HSNH23240001', CAST(N'2023-11-24' AS Date), 1, N'Bé đi khám bệnh')
INSERT [dbo].[DiemDanh] ([MaDiemDanh], [MaLop], [MaHS], [NgayDiemDanh], [VangKPhep], [GhiChu]) VALUES (N'DDLMN2324001241223_HSNH23240002', N'LMN2324001', N'HSNH23240002', CAST(N'2023-11-24' AS Date), 0, NULL)
INSERT [dbo].[DiemDanh] ([MaDiemDanh], [MaLop], [MaHS], [NgayDiemDanh], [VangKPhep], [GhiChu]) VALUES (N'DDLNT2324001241223_HSNH23240016', N'LNT2324001', N'HSNH23240016', CAST(N'2023-11-24' AS Date), 1, N'Bé sốt')
GO
INSERT [dbo].[DMManHinh] ([MaMH], [TenMH]) VALUES (N'MH01', N'Lập phiếu học phí')
INSERT [dbo].[DMManHinh] ([MaMH], [TenMH]) VALUES (N'MH02', N'Thanh toán học phí')
INSERT [dbo].[DMManHinh] ([MaMH], [TenMH]) VALUES (N'MH03', N'Đăng ký hoạt động')
INSERT [dbo].[DMManHinh] ([MaMH], [TenMH]) VALUES (N'MH04', N'Hồ sơ học sinh')
INSERT [dbo].[DMManHinh] ([MaMH], [TenMH]) VALUES (N'MH05', N'Phân lớp')
INSERT [dbo].[DMManHinh] ([MaMH], [TenMH]) VALUES (N'MH06', N'Điểm danh')
INSERT [dbo].[DMManHinh] ([MaMH], [TenMH]) VALUES (N'MH07', N'Đánh giá tuần')
INSERT [dbo].[DMManHinh] ([MaMH], [TenMH]) VALUES (N'MH08', N'Đánh giá tháng')
INSERT [dbo].[DMManHinh] ([MaMH], [TenMH]) VALUES (N'MH09', N'Kế hoạch')
INSERT [dbo].[DMManHinh] ([MaMH], [TenMH]) VALUES (N'MH10', N'Giáo viên')
INSERT [dbo].[DMManHinh] ([MaMH], [TenMH]) VALUES (N'MH11', N'Phân công')
INSERT [dbo].[DMManHinh] ([MaMH], [TenMH]) VALUES (N'MH12', N'Hoạt động')
INSERT [dbo].[DMManHinh] ([MaMH], [TenMH]) VALUES (N'MH13', N'Phòng học')
INSERT [dbo].[DMManHinh] ([MaMH], [TenMH]) VALUES (N'MH14', N'Nhân viên')
INSERT [dbo].[DMManHinh] ([MaMH], [TenMH]) VALUES (N'MH15', N'Nhóm người dùng')
INSERT [dbo].[DMManHinh] ([MaMH], [TenMH]) VALUES (N'MH16', N'Màn hình')
INSERT [dbo].[DMManHinh] ([MaMH], [TenMH]) VALUES (N'MH17', N'Phân quyền')
INSERT [dbo].[DMManHinh] ([MaMH], [TenMH]) VALUES (N'MH18', N'Vai Trò')
INSERT [dbo].[DMManHinh] ([MaMH], [TenMH]) VALUES (N'MH19', N'Đánh giá năm học')
INSERT [dbo].[DMManHinh] ([MaMH], [TenMH]) VALUES (N'MH20', N'Danh sách học sinh')
INSERT [dbo].[DMManHinh] ([MaMH], [TenMH]) VALUES (N'MH21', N'Lớp học')
INSERT [dbo].[DMManHinh] ([MaMH], [TenMH]) VALUES (N'MH22', N'Học phí')
INSERT [dbo].[DMManHinh] ([MaMH], [TenMH]) VALUES (N'MH23', N'Doanh thu hoạt động')
INSERT [dbo].[DMManHinh] ([MaMH], [TenMH]) VALUES (N'MH24', N'Học phí tháng')
INSERT [dbo].[DMManHinh] ([MaMH], [TenMH]) VALUES (N'MH25', N'Thống kê khen thưởng')
INSERT [dbo].[DMManHinh] ([MaMH], [TenMH]) VALUES (N'MH26', N'Thống kê theo khu vực')
GO
INSERT [dbo].[GiaoVien] ([MaGV], [TrinhDo], [ChuyenMon], [NoiDaoTao]) VALUES (N'ND004', N'Cử nhân Sư phạm Mầm non', N'Giáo viên mầm non', N'Trường Cao đẳng Sư phạm TP.HCM')
INSERT [dbo].[GiaoVien] ([MaGV], [TrinhDo], [ChuyenMon], [NoiDaoTao]) VALUES (N'ND005', N'Cử nhân Sư phạm Mầm non', N'Giáo viên mầm non', N'Trường Đại học Sư phạm Đà Nẵng')
INSERT [dbo].[GiaoVien] ([MaGV], [TrinhDo], [ChuyenMon], [NoiDaoTao]) VALUES (N'ND006', N'Cử nhân Sư phạm Mầm non', N'Giáo viên mầm non', N'Trường Đại học Sư phạm Nghệ An')
INSERT [dbo].[GiaoVien] ([MaGV], [TrinhDo], [ChuyenMon], [NoiDaoTao]) VALUES (N'ND007', N'Cử nhân Sư phạm Mầm non', N'Giáo viên mầm non', N'Trường Đại học Sư phạm Thái Nguyên')
INSERT [dbo].[GiaoVien] ([MaGV], [TrinhDo], [ChuyenMon], [NoiDaoTao]) VALUES (N'ND008', N'Cử nhân Sư phạm Mầm non', N'Giáo viên mầm non', N'Trường Đại học Cần Thơ')
INSERT [dbo].[GiaoVien] ([MaGV], [TrinhDo], [ChuyenMon], [NoiDaoTao]) VALUES (N'ND009', N'Cử nhân Sư phạm Mầm non', N'Giáo viên mầm non', N'Trường Đại học Sư phạm Hà Nội 2')
INSERT [dbo].[GiaoVien] ([MaGV], [TrinhDo], [ChuyenMon], [NoiDaoTao]) VALUES (N'ND010', N'Cử nhân Sư phạm Mầm non', N'Giáo viên mầm non', N'Trường Cao đẳng Sư phạm Đà Nẵng')
INSERT [dbo].[GiaoVien] ([MaGV], [TrinhDo], [ChuyenMon], [NoiDaoTao]) VALUES (N'ND011', N'Cử nhân Sư phạm Mầm non', N'Giáo viên mầm non', N'Trường Đại học Sư phạm TP.HCM')
INSERT [dbo].[GiaoVien] ([MaGV], [TrinhDo], [ChuyenMon], [NoiDaoTao]) VALUES (N'ND012', N'Cử nhân Sư phạm Mầm non', N'Giáo viên mầm non', N'Trường Đại học Sư phạm Thái Nguyên')
INSERT [dbo].[GiaoVien] ([MaGV], [TrinhDo], [ChuyenMon], [NoiDaoTao]) VALUES (N'ND013', N'Cử nhân Sư phạm Mầm non', N'Giáo viên mầm non', N'Trường Đại học Sư phạm Hải Phòng')
INSERT [dbo].[GiaoVien] ([MaGV], [TrinhDo], [ChuyenMon], [NoiDaoTao]) VALUES (N'ND014', N'Cử nhân Sư phạm Mầm non', N'Giáo viên mầm non', N'Trường Đại học Sư phạm TP.HCM')
INSERT [dbo].[GiaoVien] ([MaGV], [TrinhDo], [ChuyenMon], [NoiDaoTao]) VALUES (N'ND015', N'Cử nhân Sư phạm Mầm non', N'Giáo viên mầm non', N'Trường Đại học Sư phạm Quảng Ngãi')
INSERT [dbo].[GiaoVien] ([MaGV], [TrinhDo], [ChuyenMon], [NoiDaoTao]) VALUES (N'ND016', N'Cử nhân Sư phạm Mầm non', N'Giáo viên mầm non', N'Trường Cao đẳng Sư phạm Bà Rịa Vũng Tàu')
INSERT [dbo].[GiaoVien] ([MaGV], [TrinhDo], [ChuyenMon], [NoiDaoTao]) VALUES (N'ND017', N'Cử nhân Sư phạm Mầm non', N'Giáo viên mầm non', N'Trường Đại học Sư phạm Kiên Giang')
INSERT [dbo].[GiaoVien] ([MaGV], [TrinhDo], [ChuyenMon], [NoiDaoTao]) VALUES (N'ND018', N'Cử nhân Sư phạm Mầm non', N'Giáo viên mầm non', N'Trường Đại học Sư phạm Vinh')
INSERT [dbo].[GiaoVien] ([MaGV], [TrinhDo], [ChuyenMon], [NoiDaoTao]) VALUES (N'ND019', N'Cử nhân Sư phạm Mầm non', N'Giáo viên mầm non', N'Trường Đại học Sư phạm Bắc Giang')
INSERT [dbo].[GiaoVien] ([MaGV], [TrinhDo], [ChuyenMon], [NoiDaoTao]) VALUES (N'ND020', N'Cử nhân Sư phạm Mầm non', N'Giáo viên mầm non', N'Trường Đại học Sư phạm Hà Nội')
GO
INSERT [dbo].[HoatDongNgoaiKhoa] ([MaHD], [TenHDNK], [NgayTG], [SoTien], [MaNamHoc], [TrangThaiDK]) VALUES (N'HD001', N'Chương trình Tình nguyện Mùa hè', CAST(N'2023-08-15' AS Date), 500000.0000, N'NH2324', N'Đang diễn ra')
INSERT [dbo].[HoatDongNgoaiKhoa] ([MaHD], [TenHDNK], [NgayTG], [SoTien], [MaNamHoc], [TrangThaiDK]) VALUES (N'HD002', N'Hội thao thể thao học sinh', CAST(N'2023-09-05' AS Date), 300000.0000, N'NH2324', N'Đã hết hạn đăng ký')
INSERT [dbo].[HoatDongNgoaiKhoa] ([MaHD], [TenHDNK], [NgayTG], [SoTien], [MaNamHoc], [TrangThaiDK]) VALUES (N'HD003', N'Chuyến dã ngoại về nguồn', CAST(N'2023-10-12' AS Date), 350000.0000, N'NH2324', N'Đang diễn ra')
INSERT [dbo].[HoatDongNgoaiKhoa] ([MaHD], [TenHDNK], [NgayTG], [SoTien], [MaNamHoc], [TrangThaiDK]) VALUES (N'HD004', N'Cuộc thi khoa học kỹ thuật', CAST(N'2023-11-20' AS Date), 400000.0000, N'NH2324', N'Đã hết hạn đăng ký')
INSERT [dbo].[HoatDongNgoaiKhoa] ([MaHD], [TenHDNK], [NgayTG], [SoTien], [MaNamHoc], [TrangThaiDK]) VALUES (N'HD005', N'Liên hoan văn nghệ mùa thu', CAST(N'2024-01-10' AS Date), 250000.0000, N'NH2324', N'Đang diễn ra')
GO
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH23240001', N'PHHSNH232400011', N'PHHSNH232400012', N'Nguyễn Thị Mai', N'Nữ', CAST(N'2020-07-01' AS Date), N'123 Phan Đình Phùng, Q.1', 90, N'HSNH23240001.jpg', N'15.5', CAST(N'2024-12-16' AS Date), N'', N'Đang học', CAST(N'1900-01-01' AS Date))
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH23240002', N'PHHSNH232400021', N'PHHSNH232400022', N'Trần Văn Minh', N'Nam', CAST(N'2020-06-15' AS Date), N'456 Lê Văn Sỹ, Q.3', 95, N'HSNH23240002.jpg', N'16', CAST(N'2023-07-01' AS Date), NULL, N'Đang học', NULL)
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH23240003', N'PHHSNH232400031', N'PHHSNH232400032', N'Lê Thị Lan Anh', N'Nữ', CAST(N'2020-08-20' AS Date), N'789 Nguyễn Trãi, Q.5', 92, N'HSNH23240003.jpg', N'14.8', CAST(N'2023-06-15' AS Date), NULL, N'Đang học', NULL)
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH23240004', N'PHHSNH232400041', N'PHHSNH232400042', N'Đỗ Minh Hoàng', N'Nam', CAST(N'2020-05-10' AS Date), N'123 Nguyễn Thái Học, Q.6', 98, N'HSNH23240004.jpg', N'17.2', CAST(N'2023-07-10' AS Date), NULL, N'Đang học', NULL)
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH23240005', N'PHHSNH232400051', N'PHHSNH232400052', N'Phạm Minh Thư', N'Nữ', CAST(N'2020-02-25' AS Date), N'456 Nguyễn Hữu Cảnh, Q.2', 88, N'HSNH23240005.jpg', N'15.2', CAST(N'2023-08-01' AS Date), NULL, N'Đang học', NULL)
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH23240006', N'PHHSNH232400061', N'PHHSNH232400062', N'Nguyễn Văn Đức', N'Nam', CAST(N'2019-08-10' AS Date), N'123 Trường Chinh, Q.10', 100, N'HSNH23240006.jpg', N'17.5', CAST(N'2023-07-20' AS Date), NULL, N'Đang học', NULL)
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH23240007', N'PHHSNH232400071', N'PHHSNH232400072', N'Lê Thị Thanh', N'Nữ', CAST(N'2019-07-05' AS Date), N'456 Nguyễn Cư Trinh, Q.1', 102, N'HSNH23240007.jpg', N'18', CAST(N'2023-06-25' AS Date), NULL, N'Đang học', NULL)
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH23240008', N'PHHSNH232400081', N'PHHSNH232400082', N'Trần Quốc Anh', N'Nam', CAST(N'2019-06-10' AS Date), N'789 Trần Hưng Đạo, Q.8', 99, N'HSNH23240008.jpg', N'16.7', CAST(N'2023-06-30' AS Date), NULL, N'Đang học', NULL)
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH23240009', N'PHHSNH232400091', N'PHHSNH232400092', N'Phan Thị Lan', N'Nữ', CAST(N'2019-04-01' AS Date), N'123 Võ Thị Sáu, Q.3', 95, N'HSNH23240009.jpg', N'15.9', CAST(N'2023-08-10' AS Date), NULL, N'Đang học', NULL)
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH23240010', N'PHHSNH232400101', N'PHHSNH232400102', N'Bùi Minh Tân', N'Nam', CAST(N'2019-09-17' AS Date), N'456 Lê Quang Đạo, Q.7', 97, N'HSNH23240010.jpg', N'16.6', CAST(N'2023-06-28' AS Date), NULL, N'Đang học', NULL)
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH23240011', N'PHHSNH232400111', N'PHHSNH232400112', N'Nguyễn Minh Anh', N'Nam', CAST(N'2018-07-12' AS Date), N'123 Lý Thường Kiệt, Q.11', 104, N'HSNH23240011.jpg', N'18.2', CAST(N'2023-06-10' AS Date), NULL, N'Tốt nghiệp', NULL)
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH23240012', N'PHHSNH232400121', N'PHHSNH232400122', N'Trần Thanh Hương', N'Nữ', CAST(N'2018-05-05' AS Date), N'456 Đinh Tiên Hoàng, Q.5', 110, N'HSNH23240012.jpg', N'18.5', CAST(N'2023-07-01' AS Date), NULL, N'Đang học', NULL)
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH23240013', N'PHHSNH232400131', N'PHHSNH232400132', N'Lê Thanh Bình', N'Nam', CAST(N'2018-09-20' AS Date), N'789 Phạm Ngọc Thạch, Q.6', 106, N'HSNH23240013.jpg', N'19', CAST(N'2023-06-15' AS Date), NULL, N'Đang học', NULL)
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH23240014', N'PHHSNH232400141', N'PHHSNH232400142', N'Đặng Thị Minh', N'Nữ', CAST(N'2018-11-25' AS Date), N'123 Nguyễn Tất Thành, Q.2', 98, N'HSNH23240014.jpg', N'17.8', CAST(N'2023-07-12' AS Date), NULL, N'Đang học', NULL)
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH23240015', N'PHHSNH232400151', N'PHHSNH232400152', N'Bùi Minh Thi', N'Nữ', CAST(N'2018-03-30' AS Date), N'456 Phan Văn Trị, Q.7', 102, N'HSNH23240015.jpg', N'17', CAST(N'2023-08-20' AS Date), NULL, N'Đang học', NULL)
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH23240016', N'PHHSNH232400161', N'PHHSNH232400162', N'Nguyễn Thị Ngọc', N'Nữ', CAST(N'2022-04-10' AS Date), N'123 Hồ Văn Huê, Q.4', 112, N'HSNH23240016.jpg', N'20', CAST(N'2023-06-05' AS Date), NULL, N'Đang học', NULL)
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH23240017', N'PHHSNH232400171', N'PHHSNH232400172', N'Trần Thị Lan', N'Nữ', CAST(N'2022-06-14' AS Date), N'456 Lê Đại Hành, Q.1', 115, N'HSNH23240017.jpg', N'20.5', CAST(N'2023-07-07' AS Date), NULL, N'Đang học', NULL)
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH23240018', N'PHHSNH232400181', N'PHHSNH232400182', N'Lê Quốc Duy', N'Nam', CAST(N'2022-01-01' AS Date), N'789 Phan Huy Ích, Q.10', 110, N'HSNH23240018.jpg', N'19.8', CAST(N'2023-06-18' AS Date), NULL, N'Đang học', NULL)
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH23240019', N'PHHSNH232400191', N'PHHSNH232400192', N'Đỗ Thị Quỳnh', N'Nữ', CAST(N'2022-02-11' AS Date), N'123 Nguyễn Văn Cừ, Q.5', 108, N'HSNH23240019.jpg', N'19.3', CAST(N'2024-12-09' AS Date), NULL, N'Đang học', NULL)
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH23240020', N'PHHSNH232400201', N'PHHSNH232400202', N'Phan Quốc Hoàng', N'Nam', CAST(N'2022-12-20' AS Date), N'456 Phạm Ngọc Thạch, Q.4', 109, N'HSNH23240020.jpg', N'20', CAST(N'2024-12-09' AS Date), NULL, N'Đang học', NULL)
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH23240021', N'PHHSNH232400211', N'PHHSNH232400212', N'Nguyễn Đình Lâm', N'Nam', CAST(N'2021-10-13' AS Date), N'123 Nguyễn Văn Lượng, Q.12', 115, N'HSNH23240021.jpg', N'21', CAST(N'2024-12-09' AS Date), NULL, N'Đang học', NULL)
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH23240022', N'PHHSNH232400221', N'PHHSNH232400222', N'Trần Thiết Hòa', N'Nam', CAST(N'2021-05-25' AS Date), N'456 Cách Mạng Tháng 8, Q.10', 118, N'HSNH23240022.jpg', N'21.5', CAST(N'2024-12-09' AS Date), NULL, N'Đang học', NULL)
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH23240023', N'PHHSNH232400231', N'PHHSNH232400232', N'Lê Minh Khuê', N'Nữ', CAST(N'2021-03-10' AS Date), N'789 Nguyễn Tri Phương, Q.11', 120, N'HSNH23240023.jpg', N'22', CAST(N'2024-12-09' AS Date), NULL, N'Đang học', NULL)
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH23240024', N'PHHSNH232400241', N'PHHSNH232400242', N'Đỗ Minh Quân', N'Nam', CAST(N'2021-08-15' AS Date), N'123 Quang Trung, Q.3', 122, N'HSNH23240024.jpg', N'22.5', CAST(N'2024-12-09' AS Date), NULL, N'Đang học', NULL)
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH23240025', N'PHHSNH232400251', N'PHHSNH232400252', N'Bùi Thị Mai', N'Nữ', CAST(N'2021-11-30' AS Date), N'456 Tân Sơn Nhì, Q.6', 118, N'HSNH23240025.jpg', N'21.8', CAST(N'2024-12-09' AS Date), NULL, N'Đang học', NULL)
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH23240026', N'PHHSNH232400261', N'PHHSNH232400262', N'Nguyễn Thị Hồng', N'Nữ', CAST(N'2020-01-15' AS Date), N'123 Trần Phú, Q.6', 93, N'HSNH23240026.jpg', N'15.1', CAST(N'2024-12-09' AS Date), NULL, N'Đang học', NULL)
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH23240027', N'PHHSNH232400271', N'PHHSNH232400272', N'Trần Quang Hieu', N'Nam', CAST(N'2020-04-05' AS Date), N'456 Tân Bình, Q.1', 94, N'HSNH23240027.jpg', N'15.4', CAST(N'2024-12-09' AS Date), NULL, N'Đang học', NULL)
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH23240028', N'PHHSNH232400281', N'PHHSNH232400282', N'Lê Minh Hoàng', N'Nam', CAST(N'2020-09-30' AS Date), N'789 Quang Trung, Q.5', 91, N'HSNH23240028.jpg', N'14.9', CAST(N'2024-12-09' AS Date), NULL, N'Đang học', NULL)
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH23240029', N'PHHSNH232400291', N'PHHSNH232400292', N'Đỗ Thị Mai', N'Nữ', CAST(N'2020-12-25' AS Date), N'123 Lê Thị Riêng, Q.3', 92, N'HSNH23240029.jpg', N'15', CAST(N'2024-12-09' AS Date), NULL, N'Đang học', NULL)
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH23240030', N'PHHSNH232400301', N'PHHSNH232400302', N'Phan Thanh Sơn', N'Nam', CAST(N'2020-11-10' AS Date), N'456 Phan Đình Phùng, Q.10', 95, N'HSNH23240030.jpg', N'15.3', CAST(N'2024-12-09' AS Date), NULL, N'Đang học', NULL)
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH23240031', N'PHHSNH232400311', N'PHHSNH232400312', N'Nguyễn Thị Bích', N'Nữ', CAST(N'2019-02-20' AS Date), N'123 Lý Tự Trọng, Q.2', 105, N'HSNH23240031.jpg', N'17.6', CAST(N'2024-12-09' AS Date), NULL, N'Đang học', NULL)
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH23240032', N'PHHSNH232400321', N'PHHSNH232400322', N'Trần Minh Duy', N'Nam', CAST(N'2019-03-15' AS Date), N'456 Hoàng Sa, Q.7', 107, N'HSNH23240032.jpg', N'18', CAST(N'2024-12-09' AS Date), NULL, N'Đang học', NULL)
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH23240033', N'PHHSNH232400331', N'PHHSNH232400332', N'Lê Hoàng Nam', N'Nam', CAST(N'2019-06-01' AS Date), N'789 Bình Thạnh, Q.3', 106, N'HSNH23240033.jpg', N'17.8', CAST(N'2024-12-09' AS Date), NULL, N'Đang học', NULL)
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH23240034', N'PHHSNH232400341', N'PHHSNH232400342', N'Đỗ Minh Thu', N'Nữ', CAST(N'2019-07-30' AS Date), N'123 Nguyễn Chí Thanh, Q.4', 104, N'HSNH23240034.jpg', N'17.5', CAST(N'2024-12-09' AS Date), NULL, N'Đang học', NULL)
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH23240035', N'PHHSNH232400351', N'PHHSNH232400352', N'Phan Thị Ngọc', N'Nữ', CAST(N'2019-05-18' AS Date), N'456 Lê Văn Tám, Q.10', 103, N'HSNH23240035.jpg', N'17.4', CAST(N'2024-12-09' AS Date), NULL, N'Đang học', NULL)
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH23240036', N'PHHSNH232400361', N'PHHSNH232400362', N'Nguyễn Minh Tiến', N'Nam', CAST(N'2018-02-15' AS Date), N'123 Hòa Hưng, Q.5', 110, N'HSNH23240036.jpg', N'18.8', CAST(N'2024-12-09' AS Date), NULL, N'Đang học', NULL)
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH23240037', N'PHHSNH232400371', N'PHHSNH232400372', N'Trần Thiếu Anh', N'Nữ', CAST(N'2018-03-10' AS Date), N'456 Nguyễn Đình Chiểu, Q.3', 111, N'HSNH23240037.jpg', N'19', CAST(N'2024-12-09' AS Date), NULL, N'Đang học', NULL)
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH23240038', N'PHHSNH232400381', N'PHHSNH232400382', N'Lê Minh Thảo', N'Nữ', CAST(N'2018-08-05' AS Date), N'789 Phạm Hùng, Q.6', 112, N'HSNH23240038.jpg', N'19.2', CAST(N'2024-12-09' AS Date), NULL, N'Đang học', NULL)
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH23240039', N'PHHSNH232400391', N'PHHSNH232400392', N'Đỗ Hữu Quang', N'Nam', CAST(N'2018-12-02' AS Date), N'123 Nguyễn Bình, Q.10', 113, N'HSNH23240039.jpg', N'19.5', CAST(N'2024-12-09' AS Date), NULL, N'Đang học', NULL)
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH23240040', N'PHHSNH232400401', N'PHHSNH232400402', N'Phan Thị Lê', N'Nữ', CAST(N'2018-06-10' AS Date), N'456 Trường Sa, Q.2', 114, N'HSNH23240040.jpg', N'19.7', CAST(N'2024-12-09' AS Date), NULL, N'Đang học', NULL)
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH24250001', N'PHHSNH242500011', N'PHHSNH242500012', N'Lê Thị Trân', N'Nữ', CAST(N'2023-05-15' AS Date), N'Số 1, Đường X, Quận A', 80, N'HSNH24250001.jpg', N'10.5', CAST(N'2024-12-09' AS Date), NULL, N'Đang học', NULL)
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH24250002', N'PHHSNH242500021', N'PHHSNH242500022', N'Huỳnh Lập Mai', N'Nữ', CAST(N'2023-08-22' AS Date), N'Số 2, Đường Y, Quận B', 82, N'HSNH24250002.jpg', N'11', CAST(N'2024-09-01' AS Date), NULL, N'Đang học', NULL)
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH24250003', N'PHHSNH242500031', N'PHHSNH242500032', N'Mai Ánh Đào', N'Nữ', CAST(N'2022-03-10' AS Date), N'Số 3, Đường Z, Quận C', 85, N'HSNH24250003.jpg', N'12.5', CAST(N'2024-12-09' AS Date), NULL, N'Đang học', NULL)
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH24250004', N'PHHSNH242500041', N'PHHSNH242500042', N'Nguyễn Văn Minh', N'Nam', CAST(N'2022-07-18' AS Date), N'Số 4, Đường A, Quận D', 87, N'HSNH24250004.jpg', N'12.8', CAST(N'2024-12-09' AS Date), NULL, N'Đang học', NULL)
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH24250005', N'PHHSNH242500051', N'PHHSNH242500052', N'Trần Quốc Bảo', N'Nam', CAST(N'2022-11-05' AS Date), N'Số 5, Đường B, Quận E', 88, N'HSNH24250005.jpg', N'13', CAST(N'2024-12-09' AS Date), NULL, N'Đang học', NULL)
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH24250006', N'PHHSNH242500061', N'PHHSNH242500062', N'Phạm Thị Thu', N'Nữ', CAST(N'2021-01-20' AS Date), N'Số 6, Đường C, Quận F', 90, N'HSNH24250006.jpg', N'14', CAST(N'2024-12-09' AS Date), NULL, N'Đang học', NULL)
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH24250007', N'PHHSNH242500071', N'PHHSNH242500072', N'Hoàng Hải Đăng', N'Nam', CAST(N'2021-04-15' AS Date), N'Số 7, Đường D, Quận G', 92, N'HSNH24250007.jpg', N'14.5', CAST(N'2024-12-09' AS Date), NULL, N'Đang học', NULL)
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH24250008', N'PHHSNH242500081', N'PHHSNH242500082', N'Nguyễn Thị Thuỳ', N'Nữ', CAST(N'2021-09-10' AS Date), N'Số 8, Đường E, Quận H', 95, N'HSNH24250008.jpg', N'15.2', CAST(N'2024-12-09' AS Date), NULL, N'Đang học', NULL)
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH24250009', N'PHHSNH242500091', N'PHHSNH242500092', N'Lâm Minh Tú', N'Nam', CAST(N'2021-05-30' AS Date), N'Số 9, Đường F, Quận I', 98, N'HSNH24250009.jpg', N'16', CAST(N'2024-12-09' AS Date), NULL, N'Đang học', NULL)
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH24250010', N'PHHSNH242500101', N'PHHSNH242500102', N'Đặng Ngọc Mai', N'Nữ', CAST(N'2021-12-25' AS Date), N'Số 10, Đường G, Quận J', 100, N'HSNH24250010.jpg', N'16.5', CAST(N'2024-12-09' AS Date), NULL, N'Đang học', NULL)
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH24250011', N'PHHSNH242500111', N'PHHSNH242500112', N'Nguyễn Nhật Nam', N'Nam', CAST(N'2020-02-14' AS Date), N'Số 11, Đường H, Quận K', 105, N'HSNH24250011.jpg', N'18', CAST(N'2024-12-09' AS Date), NULL, N'Đang học', NULL)
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH24250012', N'PHHSNH242500121', N'PHHSNH242500122', N'Lê Hoàng Anh', N'Nam', CAST(N'2020-05-05' AS Date), N'Số 12, Đường I, Quận L', 110, N'HSNH24250012.jpg', N'18.2', CAST(N'2024-12-09' AS Date), NULL, N'Đang học', NULL)
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH24250013', N'PHHSNH242500131', N'PHHSNH242500132', N'Trần Thanh Phong', N'Nam', CAST(N'2020-09-12' AS Date), N'Số 13, Đường J, Quận M', 115, N'HSNH24250013.jpg', N'19', CAST(N'2024-12-09' AS Date), NULL, N'Đang học', NULL)
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH24250014', N'PHHSNH242500141', N'PHHSNH242500142', N'Nguyễn Hữu Phúc', N'Nam', CAST(N'2020-03-01' AS Date), N'Số 14, Đường K, Quận N', 120, N'HSNH24250014.jpg', N'20.5', CAST(N'2024-12-09' AS Date), NULL, N'Đang học', NULL)
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH24250015', N'PHHSNH242500151', N'PHHSNH242500152', N'Ngô Thanh Hùng', N'Nam', CAST(N'2020-09-23' AS Date), N'Số 15, Đường L, Quận O', 125, N'HSNH24250015.jpg', N'21', CAST(N'2024-12-09' AS Date), NULL, N'Đang học', NULL)
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH24250016', N'PHHSNH242500161', N'PHHSNH242500162', N'Phạm Ngọc Anh', N'Nữ', CAST(N'2019-12-14' AS Date), N'Số 16, Đường M, Quận P', 130, N'HSNH24250016.jpg', N'22', CAST(N'2024-12-09' AS Date), NULL, N'Đang học', NULL)
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH24250017', N'PHHSNH242500171', N'PHHSNH242500172', N'Hoàng Văn Dũng', N'Nam', CAST(N'2019-01-07' AS Date), N'Số 17, Đường N, Quận Q', 135, N'HSNH24250017.jpg', N'23', CAST(N'2024-12-09' AS Date), NULL, N'Đang học', NULL)
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH24250018', N'PHHSNH242500181', N'PHHSNH242500182', N'Nguyễn Văn Toàn', N'Nam', CAST(N'2019-06-16' AS Date), N'Số 18, Đường O, Quận R', 140, N'HSNH24250018.jpg', N'24', CAST(N'2024-12-09' AS Date), NULL, N'Đang học', NULL)
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH24250019', N'PHHSNH242500191', N'PHHSNH242500192', N'Lê Thị Ánh', N'Nữ', CAST(N'2019-10-05' AS Date), N'Số 19, Đường P, Quận S', 145, N'HSNH24250019.jpg', N'25', CAST(N'2024-12-09' AS Date), NULL, N'Đang học', NULL)
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH24250020', N'PHHSNH242500201', N'PHHSNH242500202', N'Nguyễn Thanh Bình', N'Nam', CAST(N'2019-12-30' AS Date), N'Số 20, Đường Q, Quận T', 150, N'HSNH24250020.jpg', N'26', CAST(N'2024-09-01' AS Date), NULL, N'Đang học', NULL)
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH24250022', N'PHHSNH242500221', N'PHHSNH242500222', N'Nguyễn Thị Bảo Ngọc', N'Nữ', CAST(N'2023-01-12' AS Date), N'Số 21, Đường A, Long An', 90, N'HSNH24250022.jpg', N'11', CAST(N'2024-12-16' AS Date), N'', N'Đang học', CAST(N'1900-01-01' AS Date))
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH24250023', N'PHHSNH242500231', N'PHHSNH242500232', N'Lê Thị Kim Chi', N'Nữ', CAST(N'2023-02-22' AS Date), N'Số 22, Đường B, Long An', 95, N'HSNH24250023.jpg', N'12', CAST(N'2024-12-16' AS Date), N'', N'Đang học', CAST(N'1900-01-01' AS Date))
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH24250024', N'PHHSNH242500241', N'PHHSNH242500242', N'Nguyễn Thị Lan', N'Nữ', CAST(N'2023-03-10' AS Date), N'Số 23, Đường C, Long An', 100, N'HSNH24250024.jpg', N'13', CAST(N'2024-12-16' AS Date), N'', N'Đang học', CAST(N'1900-01-01' AS Date))
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH24250025', N'PHHSNH242500251', N'PHHSNH242500252', N'Ngô Thanh Hoàng', N'Nam', CAST(N'2023-04-17' AS Date), N'Số 24, Đường D, Long An', 105, N'HSNH24250025.jpg', N'14', CAST(N'2024-12-16' AS Date), N'', N'Đang học', CAST(N'1900-01-01' AS Date))
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH24250026', N'PHHSNH242500261', N'PHHSNH242500262', N'Lê Minh Thúy', N'Nữ', CAST(N'2023-05-04' AS Date), N'Số 25, Đường E, Long An', 110, N'HSNH24250026.jpg', N'15', CAST(N'2024-12-16' AS Date), N'', N'Đang học', CAST(N'1900-01-01' AS Date))
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH24250027', N'PHHSNH242500271', N'PHHSNH242500272', N'Nguyễn Thị Mai', N'Nữ', CAST(N'2022-03-15' AS Date), N'Số 26, Đường F, Long An', 120, N'HSNH24250027.jpg', N'16', CAST(N'2024-12-16' AS Date), N'', N'Đang học', CAST(N'1900-01-01' AS Date))
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH24250028', N'PHHSNH242500281', N'PHHSNH242500282', N'Nguyễn Thị Thảo', N'Nữ', CAST(N'2022-04-20' AS Date), N'Số 27, Đường G, Long An', 125, N'HSNH24250028.jpg', N'17', CAST(N'2024-12-16' AS Date), N'', N'Đang học', CAST(N'1900-01-01' AS Date))
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH24250029', N'PHHSNH242500291', N'PHHSNH242500292', N'Lê Minh Tâm', N'Nam', CAST(N'2022-06-12' AS Date), N'Số 28, Đường H, Long An', 130, N'HSNH24250029.jpg', N'18', CAST(N'2024-12-16' AS Date), N'', N'Đang học', CAST(N'1900-01-01' AS Date))
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH24250030', N'PHHSNH242500301', N'PHHSNH242500302', N'Nguyễn Hoàng Bảo', N'Nam', CAST(N'2022-07-25' AS Date), N'Số 29, Đường I, Long An', 135, N'HSNH24250030.jpg', N'19', CAST(N'2024-12-16' AS Date), N'', N'Đang học', CAST(N'1900-01-01' AS Date))
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH24250031', N'PHHSNH242500311', N'PHHSNH242500312', N'Lê Minh Thái', N'Nam', CAST(N'2022-09-30' AS Date), N'Số 30, Đường J, Long An', 140, N'HSNH24250031.jpg', N'20', CAST(N'2024-12-16' AS Date), N'', N'Đang học', CAST(N'1900-01-01' AS Date))
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH24250032', N'PHHSNH242500321', N'PHHSNH242500322', N'Nguyễn Thị Quỳnh', N'Nữ', CAST(N'2021-01-05' AS Date), N'Số 31, Đường K, Long An', 145, N'HSNH24250032.jpg', N'21', CAST(N'2024-12-16' AS Date), N'', N'Đang học', CAST(N'1900-01-01' AS Date))
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH24250033', N'PHHSNH242500331', N'PHHSNH242500332', N'Lê Thị Thanh', N'Nữ', CAST(N'2021-02-18' AS Date), N'Số 32, Đường L, Long An', 150, N'HSNH24250033.jpg', N'22', CAST(N'2024-12-16' AS Date), N'', N'Đang học', CAST(N'1900-01-01' AS Date))
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH24250034', N'PHHSNH242500341', N'PHHSNH242500342', N'Nguyễn Minh Châu', N'Nữ', CAST(N'2021-03-10' AS Date), N'Số 33, Đường M, Long An', 155, N'HSNH24250034.jpg', N'23', CAST(N'2024-12-16' AS Date), N'', N'Đang học', CAST(N'1900-01-01' AS Date))
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH24250035', N'PHHSNH242500351', N'PHHSNH242500352', N'Phạm Ngọc Liên', N'Nữ', CAST(N'2021-04-22' AS Date), N'Số 34, Đường N, Long An', 160, N'HSNH24250035.jpg', N'24', CAST(N'2024-12-16' AS Date), N'', N'Đang học', CAST(N'1900-01-01' AS Date))
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH24250036', N'PHHSNH242500361', N'PHHSNH242500362', N'Trần Thị Lan', N'Nữ', CAST(N'2021-05-10' AS Date), N'Số 35, Đường P, Long An', 165, N'HSNH24250036.jpg', N'25', CAST(N'2024-12-16' AS Date), N'', N'Đang học', CAST(N'1900-01-01' AS Date))
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH24250037', N'PHHSNH242500371', N'PHHSNH242500372', N'Lê Thanh Bình', N'Nam', CAST(N'2021-06-20' AS Date), N'Số 36, Đường Q, Long An', 170, N'HSNH24250037.jpg', N'26', CAST(N'2024-12-16' AS Date), N'', N'Đang học', CAST(N'1900-01-01' AS Date))
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH24250038', N'PHHSNH242500381', N'PHHSNH242500382', N'Nguyễn Thị Thanh', N'Nữ', CAST(N'2021-07-10' AS Date), N'Số 37, Đường R, Long An', 175, N'HSNH24250038.jpg', N'27', CAST(N'2024-12-16' AS Date), N'', N'Đang học', CAST(N'1900-01-01' AS Date))
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH24250039', N'PHHSNH242500391', N'PHHSNH242500392', N'Phan Thị Mai', N'Nữ', CAST(N'2021-08-02' AS Date), N'Số 38, Đường S, Long An', 180, N'HSNH24250039.jpg', N'28', CAST(N'2024-12-16' AS Date), N'', N'Đang học', CAST(N'1900-01-01' AS Date))
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH24250040', N'PHHSNH242500401', N'PHHSNH242500402', N'Nguyễn Phúc Hậu', N'Nam', CAST(N'2021-09-12' AS Date), N'Số 39, Đường T, Long An', 185, N'HSNH24250040.jpg', N'29', CAST(N'2024-12-16' AS Date), N'', N'Đang học', CAST(N'1900-01-01' AS Date))
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH24250041', N'PHHSNH242500411', N'PHHSNH242500412', N'Hoàng Minh Trí', N'Nam', CAST(N'2021-10-03' AS Date), N'Số 40, Đường U, Long An', 190, N'HSNH24250041.jpg', N'30', CAST(N'2024-12-16' AS Date), N'', N'Đang học', CAST(N'1900-01-01' AS Date))
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH24250042', N'PHHSNH242500421', N'PHHSNH242500422', N'Nguyễn Thị Bích', N'Nữ', CAST(N'2020-01-10' AS Date), N'Số 41, Đường V, Long An', 155, N'HSNH24250042.jpg', N'22', CAST(N'2024-12-16' AS Date), N'', N'Đang học', CAST(N'1900-01-01' AS Date))
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH24250043', N'PHHSNH242500431', N'PHHSNH242500432', N'Phan Quang Huy', N'Nam', CAST(N'2020-02-15' AS Date), N'Số 42, Đường W, Long An', 160, N'HSNH24250043.jpg', N'23', CAST(N'2024-12-16' AS Date), N'', N'Đang học', CAST(N'1900-01-01' AS Date))
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH24250044', N'PHHSNH242500441', N'PHHSNH242500442', N'Trần Minh Lý', N'Nữ', CAST(N'2020-03-22' AS Date), N'Số 43, Đường X, Long An', 165, N'HSNH24250044.jpg', N'24', CAST(N'2024-12-16' AS Date), N'', N'Đang học', CAST(N'1900-01-01' AS Date))
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH24250045', N'PHHSNH242500451', N'PHHSNH242500452', N'Nguyễn Ngọc Mai', N'Nữ', CAST(N'2020-04-10' AS Date), N'Số 44, Đường Y, Long An', 170, N'HSNH24250045.jpg', N'25', CAST(N'2024-12-16' AS Date), N'', N'Đang học', CAST(N'1900-01-01' AS Date))
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH24250046', N'PHHSNH242500461', N'PHHSNH242500462', N'Lê Thị Quỳnh Anh', N'Nữ', CAST(N'2020-05-12' AS Date), N'Số 45, Đường Z, Long An', 175, N'HSNH24250046.jpg', N'26', CAST(N'2024-12-16' AS Date), N'', N'Đang học', CAST(N'1900-01-01' AS Date))
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH24250047', N'PHHSNH242500471', N'PHHSNH242500472', N'Phan Anh Tú', N'Nam', CAST(N'2020-06-17' AS Date), N'Số 46, Đường A, Long An', 180, N'HSNH24250047.jpg', N'27', CAST(N'2024-12-16' AS Date), N'', N'Đang học', CAST(N'1900-01-01' AS Date))
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH24250048', N'PHHSNH242500481', N'PHHSNH242500482', N'Trần Thị Bích', N'Nữ', CAST(N'2020-07-09' AS Date), N'Số 47, Đường B, Long An', 185, N'HSNH24250048.jpg', N'28', CAST(N'2024-12-16' AS Date), N'', N'Đang học', CAST(N'1900-01-01' AS Date))
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH24250049', N'PHHSNH242500491', N'PHHSNH242500492', N'Nguyễn Quang Duy', N'Nam', CAST(N'2020-08-20' AS Date), N'Số 48, Đường C, Long An', 190, N'HSNH24250049.jpg', N'29', CAST(N'2024-12-16' AS Date), N'', N'Đang học', CAST(N'1900-01-01' AS Date))
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH24250050', N'PHHSNH242500501', N'PHHSNH242500502', N'Phạm Thanh Vân', N'Nữ', CAST(N'2020-09-15' AS Date), N'Số 49, Đường D, Long An', 195, N'HSNH24250050.jpg', N'30', CAST(N'2024-12-16' AS Date), N'', N'Đang học', CAST(N'1900-01-01' AS Date))
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH24250051', N'PHHSNH242500511', N'PHHSNH242500512', N'Nguyễn Thị Lan', N'Nữ', CAST(N'2020-10-10' AS Date), N'Số 50, Đường E, Long An', 160, N'HSNH24250051.jpg', N'31', CAST(N'2024-12-16' AS Date), N'', N'Đang học', CAST(N'1900-01-01' AS Date))
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH24250052', N'PHHSNH242500521', N'PHHSNH242500522', N'Nguyễn Thị Bình', N'Nữ', CAST(N'2019-01-15' AS Date), N'Số 21, Đường M, Long An', 155, N'HSNH24250052.jpg', N'24', CAST(N'2024-12-16' AS Date), N'', N'Đang học', CAST(N'1900-01-01' AS Date))
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH24250053', N'PHHSNH242500531', N'PHHSNH242500532', N'Lê Thị Kim', N'Nữ', CAST(N'2019-02-08' AS Date), N'Số 22, Đường N, Long An', 158, N'HSNH24250053.jpg', N'25', CAST(N'2024-12-16' AS Date), N'', N'Đang học', CAST(N'1900-01-01' AS Date))
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH24250054', N'PHHSNH242500541', N'PHHSNH242500542', N'Phạm Thị Hồng', N'Nữ', CAST(N'2019-03-20' AS Date), N'Số 23, Đường P, Long An', 162, N'HSNH24250054.jpg', N'26', CAST(N'2024-12-16' AS Date), N'', N'Đang học', CAST(N'1900-01-01' AS Date))
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH24250055', N'PHHSNH242500551', N'PHHSNH242500552', N'Vũ Thị Thanh', N'Nữ', CAST(N'2019-04-10' AS Date), N'Số 24, Đường Q, Long An', 161, N'HSNH24250055.jpg', N'27', CAST(N'2024-12-16' AS Date), N'', N'Đang học', CAST(N'1900-01-01' AS Date))
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH24250056', N'PHHSNH242500561', N'PHHSNH242500562', N'Nguyễn Văn An', N'Nam', CAST(N'2023-02-01' AS Date), N'Số 25, Đường R, Long An', 85, N'HSNH24250056.jpg', N'9', CAST(N'2024-08-15' AS Date), N'', N'Đang học', NULL)
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH24250057', N'PHHSNH242500571', N'PHHSNH242500572', N'Lê Thị Thảo', N'Nữ', CAST(N'2023-03-12' AS Date), N'Số 26, Đường S, Long An', 82, N'HSNH24250057.jpg', N'8', CAST(N'2024-12-18' AS Date), N'', N'Đang học', CAST(N'1900-01-01' AS Date))
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH24250058', N'PHHSNH242500581', N'PHHSNH242500582', N'Trần Minh Đức', N'Nam', CAST(N'2023-04-25' AS Date), N'Số 27, Đường T, Long An', 83, N'HSNH24250058.jpg', N'8.5', CAST(N'2024-12-18' AS Date), N'', N'Đang học', CAST(N'1900-01-01' AS Date))
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH24250059', N'PHHSNH242500591', N'PHHSNH242500592', N'Phạm Quỳnh Anh', N'Nữ', CAST(N'2022-06-10' AS Date), N'Số 28, Đường U, Long An', 100, N'HSNH24250059.jpg', N'15', CAST(N'2024-12-18' AS Date), N'', N'Đang học', CAST(N'1900-01-01' AS Date))
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH24250060', N'PHHSNH242500601', N'PHHSNH242500602', N'Nguyễn Văn Bình', N'Nam', CAST(N'2022-11-15' AS Date), N'Số 29, Đường V, Long An', 105, N'HSNH24250060.jpg', N'16', CAST(N'2024-12-18' AS Date), N'', N'Đang học', CAST(N'1900-01-01' AS Date))
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH24250061', N'PHHSNH242500611', N'PHHSNH242500612', N'Vũ Hoài Nam', N'Nam', CAST(N'2020-02-05' AS Date), N'Số 30, Đường X, Long An', 120, N'HSNH24250061.jpg', N'20', CAST(N'2024-12-18' AS Date), N'', N'Đang học', CAST(N'1900-01-01' AS Date))
GO
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH24250062', N'PHHSNH242500621', N'PHHSNH242500622', N'Nguyễn Minh Tú', N'Nữ', CAST(N'2020-06-20' AS Date), N'Số 31, Đường Y, Long An', 115, N'HSNH24250062.jpg', N'18', CAST(N'2024-12-18' AS Date), N'', N'Đang học', CAST(N'1900-01-01' AS Date))
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH24250063', N'PHHSNH242500631', N'PHHSNH242500632', N'Phạm Thanh Tâm', N'Nữ', CAST(N'2020-09-10' AS Date), N'Số 32, Đường Z, Long An', 117, N'HSNH24250063.jpg', N'19', CAST(N'2024-12-18' AS Date), N'', N'Đang học', CAST(N'1900-01-01' AS Date))
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH24250064', N'PHHSNH242500641', N'PHHSNH242500642', N'Lê Văn Khánh', N'Nam', CAST(N'2020-12-30' AS Date), N'Số 33, Đường A, Long An', 122, N'HSNH24250064.jpg', N'21', CAST(N'2024-12-18' AS Date), N'', N'Đang học', CAST(N'1900-01-01' AS Date))
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH24250065', N'PHHSNH242500651', N'PHHSNH242500652', N'Trần Hoàng Lâm', N'Nam', CAST(N'2020-07-12' AS Date), N'Số 34, Đường B, Long An', 123, N'HSNH24250065.jpg', N'22', CAST(N'2024-12-18' AS Date), N'', N'Đang học', CAST(N'1900-01-01' AS Date))
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH24250066', N'PHHSNH242500661', N'PHHSNH242500662', N'Nguyễn Thị Hương', N'Nữ', CAST(N'2019-03-15' AS Date), N'Số 35, Đường C, Long An', 125, N'HSNH24250066.jpg', N'23', CAST(N'2024-12-18' AS Date), N'', N'Đang học', CAST(N'1900-01-01' AS Date))
INSERT [dbo].[HocSinh] ([MaHS], [MaPH1], [MaPH2], [HoTen], [GioiTinh], [NgaySinh], [DiaChi], [ChieuCao], [HinhAnh], [CanNang], [NgayNhapHoc], [GhiChu], [TinhTrang], [NgayKetThuc]) VALUES (N'HSNH24250067', N'PHHSNH242500671', N'PHHSNH242500672', N'Lê Quốc Huy', N'Nam', CAST(N'2019-06-22' AS Date), N'Số 36, Đường D, Long An', 128, N'HSNH24250067.jpg', N'24', CAST(N'2024-12-18' AS Date), N'', N'Đang học', CAST(N'1900-01-01' AS Date))
GO
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH23240001', N'234701200001', N'Việt Nam', N'Kinh', N'Không', N'Hà Nội', N'Hà Nội', N'Khỏe mạnh', N'GiayKhaiSinh_HSNH2324001.pdf', N'DonXinNhapHoc_HSNH2324001.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH23240002', N'234701200002', N'Việt Nam', N'Kinh', N'Không', N'Hà Nội', N'Hà Nội', N'Khỏe mạnh', N'GiayKhaiSinh_HSNH2324002.pdf', N'DonXinNhapHoc_HSNH2324002.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH23240003', N'234701200003', N'Việt Nam', N'Kinh', N'Không', N'Hà Nội', N'Hà Nội', N'Khỏe mạnh', N'GiayKhaiSinh_HSNH2324003.pdf', N'DonXinNhapHoc_HSNH2324003.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH23240004', N'234701200004', N'Việt Nam', N'Kinh', N'Không', N'Hà Nội', N'Hà Nội', N'Khỏe mạnh', N'GiayKhaiSinh_HSNH2324004.pdf', N'DonXinNhapHoc_HSNH2324004.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH23240005', N'234701200005', N'Việt Nam', N'Kinh', N'Không', N'Hà Nội', N'Hà Nội', N'Khỏe mạnh', N'GiayKhaiSinh_HSNH2324005.pdf', N'DonXinNhapHoc_HSNH2324005.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH23240006', N'234701200006', N'Việt Nam', N'Kinh', N'Không', N'Hồ Chí Minh', N'Hồ Chí Minh', N'Khỏe mạnh', N'GiayKhaiSinh_HSNH2324006.pdf', N'DonXinNhapHoc_HSNH2324006.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH23240007', N'234701200007', N'Việt Nam', N'Kinh', N'Không', N'Hồ Chí Minh', N'Hồ Chí Minh', N'Khỏe mạnh', N'GiayKhaiSinh_HSNH2324007.pdf', N'DonXinNhapHoc_HSNH2324007.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH23240008', N'234701200008', N'Việt Nam', N'Kinh', N'Không', N'Hồ Chí Minh', N'Hồ Chí Minh', N'Khỏe mạnh', N'GiayKhaiSinh_HSNH2324008.pdf', N'DonXinNhapHoc_HSNH2324008.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH23240009', N'234701200009', N'Việt Nam', N'Kinh', N'Không', N'Hồ Chí Minh', N'Hồ Chí Minh', N'Khỏe mạnh', N'GiayKhaiSinh_HSNH2324009.pdf', N'DonXinNhapHoc_HSNH2324009.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH23240010', N'234701200010', N'Việt Nam', N'Kinh', N'Không', N'Hồ Chí Minh', N'Hồ Chí Minh', N'Khỏe mạnh', N'GiayKhaiSinh_HSNH23240010.pdf', N'DonXinNhapHoc_HSNH23240010.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH23240011', N'234701200011', N'Việt Nam', N'Kinh', N'Không', N'Đà Nẵng', N'Đà Nẵng', N'Khỏe mạnh', N'GiayKhaiSinh_HSNH23240011.pdf', N'DonXinNhapHoc_HSNH23240011.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH23240012', N'234701200012', N'Việt Nam', N'Kinh', N'Không', N'Đà Nẵng', N'Đà Nẵng', N'Khỏe mạnh', N'GiayKhaiSinh_HSNH23240012.pdf', N'DonXinNhapHoc_HSNH23240012.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH23240013', N'234701200013', N'Việt Nam', N'Kinh', N'Không', N'Đà Nẵng', N'Đà Nẵng', N'Khỏe mạnh', N'GiayKhaiSinh_HSNH23240013.pdf', N'DonXinNhapHoc_HSNH23240013.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH23240014', N'234701200014', N'Việt Nam', N'Kinh', N'Không', N'Đà Nẵng', N'Đà Nẵng', N'Khỏe mạnh', N'GiayKhaiSinh_HSNH23240014.pdf', N'DonXinNhapHoc_HSNH23240014.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH23240015', N'234701200015', N'Việt Nam', N'Kinh', N'Không', N'Đà Nẵng', N'Đà Nẵng', N'Khỏe mạnh', N'GiayKhaiSinh_HSNH23240015.pdf', N'DonXinNhapHoc_HSNH23240015.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH23240016', N'234701200016', N'Việt Nam', N'Kinh', N'Không', N'Hà Nội', N'Hà Nội', N'Khỏe mạnh', N'GiayKhaiSinh_HSNH23240016.pdf', N'DonXinNhapHoc_HSNH23240016.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH23240017', N'234701200017', N'Việt Nam', N'Kinh', N'Không', N'Hà Nội', N'Hà Nội', N'Khỏe mạnh', N'GiayKhaiSinh_HSNH23240017.pdf', N'DonXinNhapHoc_HSNH23240017.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH23240018', N'234701200018', N'Việt Nam', N'Kinh', N'Không', N'Hà Nội', N'Hà Nội', N'Khỏe mạnh', N'GiayKhaiSinh_HSNH23240018.pdf', N'DonXinNhapHoc_HSNH23240018.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH23240019', N'234701200019', N'Việt Nam', N'Kinh', N'Không', N'Hà Nội', N'Hà Nội', N'Khỏe mạnh', N'GiayKhaiSinh_HSNH23240019.pdf', N'DonXinNhapHoc_HSNH23240019.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH23240020', N'234701200020', N'Việt Nam', N'Kinh', N'Không', N'Hà Nội', N'Hà Nội', N'Khỏe mạnh', N'GiayKhaiSinh_HSNH23240020.pdf', N'DonXinNhapHoc_HSNH23240020.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH23240021', N'234701200021', N'Việt Nam', N'Kinh', N'Không', N'Hồ Chí Minh', N'Hồ Chí Minh', N'Khỏe mạnh', N'GiayKhaiSinh_HSNH23240021.pdf', N'DonXinNhapHoc_HSNH23240021.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH23240022', N'234701200022', N'Việt Nam', N'Kinh', N'Không', N'Hồ Chí Minh', N'Hồ Chí Minh', N'Khỏe mạnh', N'GiayKhaiSinh_HSNH23240022.pdf', N'DonXinNhapHoc_HSNH23240022.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH23240023', N'234701200023', N'Việt Nam', N'Kinh', N'Không', N'Hồ Chí Minh', N'Hồ Chí Minh', N'Khỏe mạnh', N'GiayKhaiSinh_HSNH23240023.pdf', N'DonXinNhapHoc_HSNH23240023.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH23240024', N'234701200024', N'Việt Nam', N'Kinh', N'Không', N'Hồ Chí Minh', N'Hồ Chí Minh', N'Khỏe mạnh', N'GiayKhaiSinh_HSNH23240024.pdf', N'DonXinNhapHoc_HSNH23240024.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH23240025', N'234701200025', N'Việt Nam', N'Kinh', N'Không', N'Hồ Chí Minh', N'Hồ Chí Minh', N'Khỏe mạnh', N'GiayKhaiSinh_HSNH23240025.pdf', N'DonXinNhapHoc_HSNH23240025.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH23240026', N'234701200026', N'Việt Nam', N'Kinh', N'Không', N'Đà Nẵng', N'Đà Nẵng', N'Khỏe mạnh', N'GiayKhaiSinh_HSNH23240026.pdf', N'DonXinNhapHoc_HSNH23240026.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH23240027', N'234701200027', N'Việt Nam', N'Kinh', N'Không', N'Đà Nẵng', N'Đà Nẵng', N'Khỏe mạnh', N'GiayKhaiSinh_HSNH23240027.pdf', N'DonXinNhapHoc_HSNH23240027.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH23240028', N'234701200028', N'Việt Nam', N'Kinh', N'Không', N'Đà Nẵng', N'Đà Nẵng', N'Khỏe mạnh', N'GiayKhaiSinh_HSNH23240028.pdf', N'DonXinNhapHoc_HSNH23240028.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH23240029', N'234701200029', N'Việt Nam', N'Kinh', N'Không', N'Đà Nẵng', N'Đà Nẵng', N'Khỏe mạnh', N'GiayKhaiSinh_HSNH23240029.pdf', N'DonXinNhapHoc_HSNH23240029.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH23240030', N'234701200030', N'Việt Nam', N'Kinh', N'Không', N'Đà Nẵng', N'Đà Nẵng', N'Khỏe mạnh', N'GiayKhaiSinh_HSNH23240030.pdf', N'DonXinNhapHoc_HSNH23240030.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH23240031', N'234701200031', N'Việt Nam', N'Kinh', N'Không', N'Đà Nẵng', N'Đà Nẵng', N'Khỏe mạnh', N'GiayKhaiSinh_HSNH23240031.pdf', N'DonXinNhapHoc_HSNH23240031.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH23240032', N'234701200032', N'Việt Nam', N'Kinh', N'Không', N'Đà Nẵng', N'Đà Nẵng', N'Khỏe mạnh', N'GiayKhaiSinh_HSNH23240032.pdf', N'DonXinNhapHoc_HSNH23240032.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH23240033', N'234701200033', N'Việt Nam', N'Kinh', N'Không', N'Đà Nẵng', N'Đà Nẵng', N'Khỏe mạnh', N'GiayKhaiSinh_HSNH23240033.pdf', N'DonXinNhapHoc_HSNH23240033.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH23240034', N'234701200034', N'Việt Nam', N'Kinh', N'Không', N'Đà Nẵng', N'Đà Nẵng', N'Khỏe mạnh', N'GiayKhaiSinh_HSNH23240034.pdf', N'DonXinNhapHoc_HSNH23240034.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH23240035', N'234701200035', N'Việt Nam', N'Kinh', N'Không', N'Đà Nẵng', N'Đà Nẵng', N'Khỏe mạnh', N'GiayKhaiSinh_HSNH23240035.pdf', N'DonXinNhapHoc_HSNH23240035.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH23240036', N'234701200036', N'Việt Nam', N'Kinh', N'Không', N'Hồ Chí Minh', N'Hồ Chí Minh', N'Khỏe mạnh', N'GiayKhaiSinh_HSNH23240036.pdf', N'DonXinNhapHoc_HSNH23240036.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH23240037', N'234701200037', N'Việt Nam', N'Kinh', N'Không', N'Hồ Chí Minh', N'Hồ Chí Minh', N'Khỏe mạnh', N'GiayKhaiSinh_HSNH23240037.pdf', N'DonXinNhapHoc_HSNH23240037.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH23240038', N'234701200038', N'Việt Nam', N'Kinh', N'Không', N'Hồ Chí Minh', N'Hồ Chí Minh', N'Khỏe mạnh', N'GiayKhaiSinh_HSNH23240038.pdf', N'DonXinNhapHoc_HSNH23240038.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH23240039', N'234701200039', N'Việt Nam', N'Kinh', N'Không', N'Hồ Chí Minh', N'Hồ Chí Minh', N'Khỏe mạnh', N'GiayKhaiSinh_HSNH23240039.pdf', N'DonXinNhapHoc_HSNH23240039.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH23240040', N'234701200040', N'Việt Nam', N'Kinh', N'Không', N'Hồ Chí Minh', N'Hồ Chí Minh', N'Khỏe mạnh', N'GiayKhaiSinh_HSNH23240040.pdf', N'DonXinNhapHoc_HSNH23240040.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH24250001', N'123456789012', N'Nước Việt Nam', N'Nữ', N'Kinh', N'Nghệ An', N'Nghệ An', N'Tốt', N'GiayKhaiSinh_HSNH24250001.pdf', N'DonXinNhapHoc_HSNH24250001.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH24250002', N'234567890123', N'Nước Việt Nam', N'Nam', N'Kinh', N'Thái Bình', N'Thái Bình', N'Tốt', N'GiayKhaiSinh_HSNH24250002.pdf', N'DonXinNhapHoc_HSNH24250002.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH24250003', N'345678901234', N'Nước Việt Nam', N'Nữ', N'Kinh', N'Hà Nội', N'Hà Nội', N'Khỏe mạnh', N'GiayKhaiSinh_HSNH24250003.pdf', N'DonXinNhapHoc_HSNH24250003.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH24250004', N'456789012345', N'Nước Việt Nam', N'Nam', N'Kinh', N'Quảng Nam', N'Quảng Nam', N'Tốt', N'GiayKhaiSinh_HSNH24250004.pdf', N'DonXinNhapHoc_HSNH24250004.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH24250005', N'567890123456', N'Nước Việt Nam', N'Nữ', N'Kinh', N'Hồ Chí Minh', N'Hồ Chí Minh', N'Tốt', N'GiayKhaiSinh_HSNH24250005.pdf', N'DonXinNhapHoc_HSNH24250005.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH24250006', N'678901234567', N'Nước Việt Nam', N'Nam', N'Kinh', N'Hải Phòng', N'Hải Phòng', N'Tốt', N'GiayKhaiSinh_HSNH24250006.pdf', N'DonXinNhapHoc_HSNH24250006.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH24250007', N'789012345678', N'Nước Việt Nam', N'Nữ', N'Kinh', N'Bắc Giang', N'Bắc Giang', N'Tốt', N'GiayKhaiSinh_HSNH24250007.pdf', N'DonXinNhapHoc_HSNH24250007.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH24250008', N'890123456789', N'Nước Việt Nam', N'Nam', N'Kinh', N'Bắc Ninh', N'Bắc Ninh', N'Khỏe mạnh', N'GiayKhaiSinh_HSNH24250008.pdf', N'DonXinNhapHoc_HSNH24250008.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH24250009', N'901234567890', N'Nước Việt Nam', N'Nữ', N'Kinh', N'Đà Nẵng', N'Đà Nẵng', N'Tốt', N'GiayKhaiSinh_HSNH24250009.pdf', N'DonXinNhapHoc_HSNH24250009.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH24250010', N'012345678901', N'Nước Việt Nam', N'Nam', N'Kinh', N'Bình Dương', N'Bình Dương', N'Tốt', N'GiayKhaiSinh_HSNH24250010.pdf', N'DonXinNhapHoc_HSNH24250010.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH24250011', N'123456789123', N'Nước Việt Nam', N'Nữ', N'Kinh', N'Vĩnh Long', N'Vĩnh Long', N'Tốt', N'GiayKhaiSinh_HSNH24250011.pdf', N'DonXinNhapHoc_HSNH24250011.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH24250012', N'234567890234', N'Nước Việt Nam', N'Nam', N'Kinh', N'Thừa Thiên Huế', N'Thừa Thiên Huế', N'Tốt', N'GiayKhaiSinh_HSNH24250012.pdf', N'DonXinNhapHoc_HSNH24250012.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH24250013', N'345678901345', N'Nước Việt Nam', N'Nữ', N'Kinh', N'Long An', N'Long An', N'Tốt', N'GiayKhaiSinh_HSNH24250013.pdf', N'DonXinNhapHoc_HSNH24250013.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH24250014', N'456789012456', N'Nước Việt Nam', N'Nam', N'Kinh', N'Tây Ninh', N'Tây Ninh', N'Tốt', N'GiayKhaiSinh_HSNH24250014.pdf', N'DonXinNhapHoc_HSNH24250014.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH24250015', N'567890123567', N'Nước Việt Nam', N'Nữ', N'Kinh', N'Quảng Bình', N'Quảng Bình', N'Tốt', N'GiayKhaiSinh_HSNH24250015.pdf', N'DonXinNhapHoc_HSNH24250015.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH24250016', N'678901234678', N'Nước Việt Nam', N'Nam', N'Kinh', N'Kiên Giang', N'Kiên Giang', N'Tốt', N'GiayKhaiSinh_HSNH24250016.pdf', N'DonXinNhapHoc_HSNH24250016.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH24250017', N'789012345789', N'Nước Việt Nam', N'Nữ', N'Kinh', N'Phú Thọ', N'Phú Thọ', N'Tốt', N'GiayKhaiSinh_HSNH24250017.pdf', N'DonXinNhapHoc_HSNH24250017.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH24250018', N'890123456890', N'Nước Việt Nam', N'Nam', N'Kinh', N'Hà Nam', N'Hà Nam', N'Tốt', N'GiayKhaiSinh_HSNH24250018.pdf', N'DonXinNhapHoc_HSNH24250018.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH24250019', N'901234567901', N'Nước Việt Nam', N'Nữ', N'Kinh', N'Hải Dương', N'Hải Dương', N'Tốt', N'GiayKhaiSinh_HSNH24250019.pdf', N'DonXinNhapHoc_HSNH24250019.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH24250020', N'012345678012', N'Nước Việt Nam', N'Nam', N'Kinh', N'Quảng Ninh', N'Quảng Ninh', N'Tốt', N'GiayKhaiSinh_HSNH24250020.pdf', N'DonXinNhapHoc_HSNH24250020.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH24250022', N'123456789012', N'Việt Nam', N'Kinh', N'Không', N'Hà Nội', N'Hà Nội', N'Tốt', N'GiayKhaiSinh_HSNH24250022.pdf', N'DonXinNhapHoc_HSNH24250022.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH24250023', N'234567890123', N'Việt Nam', N'Kinh', N'Không', N'Hải Phòng', N'Hải Phòng', N'Tốt', N'GiayKhaiSinh_HSNH24250023.pdf', N'DonXinNhapHoc_HSNH24250023.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH24250024', N'345678901234', N'Việt Nam', N'Kinh', N'Không', N'Hưng Yên', N'Hưng Yên', N'Tốt', N'GiayKhaiSinh_HSNH24250024.pdf', N'DonXinNhapHoc_HSNH24250024.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH24250025', N'456789012345', N'Việt Nam', N'Kinh', N'Không', N'Ninh Bình', N'Ninh Bình', N'Tốt', N'GiayKhaiSinh_HSNH24250025.pdf', N'DonXinNhapHoc_HSNH24250025.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH24250026', N'567890123456', N'Việt Nam', N'Kinh', N'Không', N'Thái Bình', N'Thái Bình', N'Tốt', N'GiayKhaiSinh_HSNH24250026.pdf', N'DonXinNhapHoc_HSNH24250026.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH24250027', N'678901234567', N'Việt Nam', N'Kinh', N'Không', N'Nam Định', N'Nam Định', N'Tốt', N'GiayKhaiSinh_HSNH24250027.pdf', N'DonXinNhapHoc_HSNH24250027.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH24250028', N'789012345678', N'Việt Nam', N'Kinh', N'Không', N'Bắc Ninh', N'Bắc Ninh', N'Tốt', N'GiayKhaiSinh_HSNH24250028.pdf', N'DonXinNhapHoc_HSNH24250028.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH24250029', N'890123456789', N'Việt Nam', N'Kinh', N'Không', N'Bắc Giang', N'Bắc Giang', N'Tốt', N'GiayKhaiSinh_HSNH24250029.pdf', N'DonXinNhapHoc_HSNH24250029.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH24250030', N'901234567890', N'Việt Nam', N'Kinh', N'Không', N'Hòa Bình', N'Hòa Bình', N'Tốt', N'GiayKhaiSinh_HSNH24250030.pdf', N'DonXinNhapHoc_HSNH24250030.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH24250031', N'012345678901', N'Việt Nam', N'Kinh', N'Không', N'Yên Bái', N'Yên Bái', N'Tốt', N'GiayKhaiSinh_HSNH24250031.pdf', N'DonXinNhapHoc_HSNH24250031.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH24250032', N'234567890123', N'Việt Nam', N'Kinh', N'Không', N'Lào Cai', N'Lào Cai', N'Tốt', N'GiayKhaiSinh_HSNH24250032.pdf', N'DonXinNhapHoc_HSNH24250032.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH24250033', N'345678901234', N'Việt Nam', N'Kinh', N'Không', N'Tuyên Quang', N'Tuyên Quang', N'Tốt', N'GiayKhaiSinh_HSNH24250033.pdf', N'DonXinNhapHoc_HSNH24250033.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH24250034', N'456789012345', N'Việt Nam', N'Kinh', N'Không', N'Cao Bằng', N'Cao Bằng', N'Tốt', N'GiayKhaiSinh_HSNH24250034.pdf', N'DonXinNhapHoc_HSNH24250034.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH24250035', N'567890123456', N'Việt Nam', N'Kinh', N'Không', N'Lạng Sơn', N'Lạng Sơn', N'Tốt', N'GiayKhaiSinh_HSNH24250035.pdf', N'DonXinNhapHoc_HSNH24250035.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH24250036', N'678901234567', N'Việt Nam', N'Kinh', N'Không', N'Hà Giang', N'Hà Giang', N'Tốt', N'GiayKhaiSinh_HSNH24250036.pdf', N'DonXinNhapHoc_HSNH24250036.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH24250037', N'789012345678', N'Việt Nam', N'Kinh', N'Không', N'Sơn La', N'Sơn La', N'Tốt', N'GiayKhaiSinh_HSNH24250037.pdf', N'DonXinNhapHoc_HSNH24250037.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH24250038', N'890123456789', N'Việt Nam', N'Kinh', N'Không', N'Lai Châu', N'Lai Châu', N'Tốt', N'GiayKhaiSinh_HSNH24250038.pdf', N'DonXinNhapHoc_HSNH24250038.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH24250039', N'901234567890', N'Việt Nam', N'Kinh', N'Không', N'Điện Biên', N'Điện Biên', N'Tốt', N'GiayKhaiSinh_HSNH24250039.pdf', N'DonXinNhapHoc_HSNH24250039.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH24250040', N'012345678901', N'Việt Nam', N'Kinh', N'Không', N'Quảng Bình', N'Quảng Bình', N'Tốt', N'GiayKhaiSinh_HSNH24250040.pdf', N'DonXinNhapHoc_HSNH24250040.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH24250041', N'234567890123', N'Việt Nam', N'Kinh', N'Không', N'Quảng Trị', N'Quảng Trị', N'Tốt', N'GiayKhaiSinh_HSNH24250041.pdf', N'DonXinNhapHoc_HSNH24250041.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH24250042', N'345678901234', N'Việt Nam', N'Kinh', N'Không', N'Quảng Ngãi', N'Quảng Ngãi', N'Tốt', N'GiayKhaiSinh_HSNH24250042.pdf', N'DonXinNhapHoc_HSNH24250042.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH24250043', N'456789012345', N'Việt Nam', N'Kinh', N'Không', N'Bình Định', N'Bình Định', N'Tốt', N'GiayKhaiSinh_HSNH24250043.pdf', N'DonXinNhapHoc_HSNH24250043.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH24250044', N'567890123456', N'Việt Nam', N'Kinh', N'Không', N'Khánh Hòa', N'Khánh Hòa', N'Tốt', N'GiayKhaiSinh_HSNH24250044.pdf', N'DonXinNhapHoc_HSNH24250044.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH24250045', N'678901234567', N'Việt Nam', N'Kinh', N'Không', N'Gia Lai', N'Gia Lai', N'Tốt', N'GiayKhaiSinh_HSNH24250045.pdf', N'DonXinNhapHoc_HSNH24250045.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH24250046', N'789012345678', N'Việt Nam', N'Kinh', N'Không', N'Kon Tum', N'Kon Tum', N'Tốt', N'GiayKhaiSinh_HSNH24250046.pdf', N'DonXinNhapHoc_HSNH24250046.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH24250047', N'890123456789', N'Việt Nam', N'Kinh', N'Không', N'Bình Thuận', N'Bình Thuận', N'Tốt', N'GiayKhaiSinh_HSNH24250047.pdf', N'DonXinNhapHoc_HSNH24250047.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH24250048', N'901234567890', N'Việt Nam', N'Kinh', N'Không', N'Bình Phước', N'Bình Phước', N'Tốt', N'GiayKhaiSinh_HSNH24250048.pdf', N'DonXinNhapHoc_HSNH24250048.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH24250049', N'012345678901', N'Việt Nam', N'Kinh', N'Không', N'Tiền Giang', N'Tiền Giang', N'Tốt', N'GiayKhaiSinh_HSNH24250049.pdf', N'DonXinNhapHoc_HSNH24250049.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH24250050', N'234567890123', N'Việt Nam', N'Kinh', N'Không', N'An Giang', N'An Giang', N'Tốt', N'GiayKhaiSinh_HSNH24250050.pdf', N'DonXinNhapHoc_HSNH24250050.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH24250051', N'345678901234', N'Việt Nam', N'Kinh', N'Không', N'Cần Thơ', N'Cần Thơ', N'Tốt', N'GiayKhaiSinh_HSNH24250051.pdf', N'DonXinNhapHoc_HSNH24250051.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH24250052', N'456789012345', N'Việt Nam', N'Kinh', N'Không', N'Sóc Trăng', N'Sóc Trăng', N'Tốt', N'GiayKhaiSinh_HSNH24250052.pdf', N'DonXinNhapHoc_HSNH24250052.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH24250053', N'567890123456', N'Việt Nam', N'Kinh', N'Không', N'Kiên Giang', N'Kiên Giang', N'Tốt', N'GiayKhaiSinh_HSNH24250053.pdf', N'DonXinNhapHoc_HSNH24250053.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH24250054', N'678901234567', N'Việt Nam', N'Kinh', N'Không', N'Bạc Liêu', N'Bạc Liêu', N'Tốt', N'GiayKhaiSinh_HSNH24250054.pdf', N'DonXinNhapHoc_HSNH24250054.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH24250055', N'789012345678', N'Việt Nam', N'Kinh', N'Không', N'Cà Mau', N'Cà Mau', N'Tốt', N'GiayKhaiSinh_HSNH24250055.pdf', N'DonXinNhapHoc_HSNH24250055.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH24250056', N'123456789012', N'Việt Nam', N'Kinh', N'Không', N'Tiền Giang', N'Tiền Giang', N'Tốt', N'GiayKhaiSinh_HSNH24250056.pdf', N'DonXinNhapHoc_HSNH24250056.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH24250057', N'234567890123', N'Việt Nam', N'Kinh', N'Không', N'Đồng Tháp', N'Đồng Tháp', N'Tốt', N'GiayKhaiSinh_HSNH24250057.pdf', N'DonXinNhapHoc_HSNH24250057.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH24250058', N'345678901234', N'Việt Nam', N'Kinh', N'Không', N'An Giang', N'An Giang', N'Tốt', N'GiayKhaiSinh_HSNH24250058.pdf', N'DonXinNhapHoc_HSNH24250058.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH24250059', N'456789012345', N'Việt Nam', N'Kinh', N'Không', N'Vĩnh Long', N'Vĩnh Long', N'Tốt', N'GiayKhaiSinh_HSNH24250059.pdf', N'DonXinNhapHoc_HSNH24250059.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH24250060', N'567890123456', N'Việt Nam', N'Kinh', N'Không', N'Kiên Giang', N'Kiên Giang', N'Tốt', N'GiayKhaiSinh_HSNH24250060.pdf', N'DonXinNhapHoc_HSNH24250060.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH24250061', N'678901234567', N'Việt Nam', N'Kinh', N'Không', N'Bạc Liêu', N'Bạc Liêu', N'Tốt', N'GiayKhaiSinh_HSNH24250061.pdf', N'DonXinNhapHoc_HSNH24250061.pdf')
GO
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH24250062', N'789012345678', N'Việt Nam', N'Kinh', N'Không', N'Cà Mau', N'Cà Mau', N'Tốt', N'GiayKhaiSinh_HSNH24250062.pdf', N'DonXinNhapHoc_HSNH24250062.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH24250063', N'890123456789', N'Việt Nam', N'Kinh', N'Không', N'Sóc Trăng', N'Sóc Trăng', N'Tốt', N'GiayKhaiSinh_HSNH24250063.pdf', N'DonXinNhapHoc_HSNH24250063.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH24250064', N'901234567890', N'Việt Nam', N'Kinh', N'Không', N'Long An', N'Long An', N'Tốt', N'GiayKhaiSinh_HSNH24250064.pdf', N'DonXinNhapHoc_HSNH24250064.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH24250065', N'012345678901', N'Việt Nam', N'Kinh', N'Không', N'Tây Ninh', N'Tây Ninh', N'Tốt', N'GiayKhaiSinh_HSNH24250065.pdf', N'DonXinNhapHoc_HSNH24250065.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH24250066', N'123456780001', N'Việt Nam', N'Kinh', N'Không', N'Bình Dương', N'Bình Dương', N'Tốt', N'GiayKhaiSinh_HSNH24250066.pdf', N'DonXinNhapHoc_HSNH24250066.pdf')
INSERT [dbo].[HoSoHocSinh] ([MaHS], [MaDinhDanh], [QuocTich], [DanToc], [TonGiao], [QueQuan], [NoiSinh], [TinhTrangSucKhoe], [GiayKhaiSinh], [DonXinNhapHoc]) VALUES (N'HSNH24250067', N'123456780002', N'Việt Nam', N'Kinh', N'Không', N'Hồ Chí Minh', N'Hồ Chí Minh', N'Tốt', N'GiayKhaiSinh_HSNH24250067.pdf', N'DonXinNhapHoc_HSNH24250067.pdf')
GO
INSERT [dbo].[KeHoach] ([MaNamHoc], [MaKhoi], [SoLopMo], [TongHS], [SiSoToiThieu], [SiSoToiDa]) VALUES (N'NH2324', N'KLA', 2, 10, 3, 6)
INSERT [dbo].[KeHoach] ([MaNamHoc], [MaKhoi], [SoLopMo], [TongHS], [SiSoToiThieu], [SiSoToiDa]) VALUES (N'NH2324', N'KLC', 2, 10, 3, 6)
INSERT [dbo].[KeHoach] ([MaNamHoc], [MaKhoi], [SoLopMo], [TongHS], [SiSoToiThieu], [SiSoToiDa]) VALUES (N'NH2324', N'KMN', 2, 10, 3, 6)
INSERT [dbo].[KeHoach] ([MaNamHoc], [MaKhoi], [SoLopMo], [TongHS], [SiSoToiThieu], [SiSoToiDa]) VALUES (N'NH2324', N'KNT', 2, 10, 3, 6)
GO
INSERT [dbo].[KhoanThu] ([MaKhoanThu], [MaNamHoc], [TenKhoanThu], [SoTien]) VALUES (N'KT232401', N'NH2324', N'Tiền ăn', 40000.0000)
INSERT [dbo].[KhoanThu] ([MaKhoanThu], [MaNamHoc], [TenKhoanThu], [SoTien]) VALUES (N'KT232402', N'NH2324', N'Học phí', 200000.0000)
GO
INSERT [dbo].[KhoiLop] ([MaKhoi], [TenKhoi], [DoTuoi]) VALUES (N'KLA', N'Lớp Lá', N'5')
INSERT [dbo].[KhoiLop] ([MaKhoi], [TenKhoi], [DoTuoi]) VALUES (N'KLC', N'Lớp Chồi', N'4')
INSERT [dbo].[KhoiLop] ([MaKhoi], [TenKhoi], [DoTuoi]) VALUES (N'KMN', N'Lớp Mầm', N'3')
INSERT [dbo].[KhoiLop] ([MaKhoi], [TenKhoi], [DoTuoi]) VALUES (N'KNT', N'Nhà Trẻ', N'1-2')
GO
INSERT [dbo].[LopHoc] ([MaLop], [MaKhoi], [MaNamHoc], [TenLop], [SiSo], [MaPhong]) VALUES (N'LLA2324001', N'KLA', N'NH2324', N'LỚP LÁ 1', 4, N'PH007')
INSERT [dbo].[LopHoc] ([MaLop], [MaKhoi], [MaNamHoc], [TenLop], [SiSo], [MaPhong]) VALUES (N'LLA2324002', N'KLA', N'NH2324', N'LỚP LÁ 2', 4, N'PH008')
INSERT [dbo].[LopHoc] ([MaLop], [MaKhoi], [MaNamHoc], [TenLop], [SiSo], [MaPhong]) VALUES (N'LLC2324001', N'KLC', N'NH2324', N'LỚP CHỒI 1', 4, N'PH005')
INSERT [dbo].[LopHoc] ([MaLop], [MaKhoi], [MaNamHoc], [TenLop], [SiSo], [MaPhong]) VALUES (N'LLC2324002', N'KLC', N'NH2324', N'LỚP CHỒI 2', 4, N'PH006')
INSERT [dbo].[LopHoc] ([MaLop], [MaKhoi], [MaNamHoc], [TenLop], [SiSo], [MaPhong]) VALUES (N'LMN2324001', N'KMN', N'NH2324', N'LỚP MẦM 1', 4, N'PH003')
INSERT [dbo].[LopHoc] ([MaLop], [MaKhoi], [MaNamHoc], [TenLop], [SiSo], [MaPhong]) VALUES (N'LMN2324002', N'KMN', N'NH2324', N'LỚP MẦM 2', 4, N'PH004')
INSERT [dbo].[LopHoc] ([MaLop], [MaKhoi], [MaNamHoc], [TenLop], [SiSo], [MaPhong]) VALUES (N'LNT2324001', N'KNT', N'NH2324', N'NHÀ TRẺ 1', 4, N'PH001')
INSERT [dbo].[LopHoc] ([MaLop], [MaKhoi], [MaNamHoc], [TenLop], [SiSo], [MaPhong]) VALUES (N'LNT2324002', N'KNT', N'NH2324', N'NHÀ TRẺ 2', 4, N'PH002')
GO
INSERT [dbo].[NamHoc] ([MaNamHoc], [TenNamHoc], [NgayDB], [NgayKT]) VALUES (N'NH2324', N'2023-2024', CAST(N'2023-07-15' AS Date), CAST(N'2024-06-05' AS Date))
GO
INSERT [dbo].[NguoiDung] ([MaND], [TenTK], [MatKhau], [TrangThai], [HoTen], [DienThoai], [DiaChi], [GioiTinh], [NgaySinh], [ChucVu], [Email]) VALUES (N'ND001', N'nguyen.tuan', N'EC2B48944919BDADB7215B0331C62F97', 1, N'Nguyễn Tuấn Anh', N'0901234567', N'Hà Nội, Việt Nam', N'Nam', CAST(N'1990-01-01T00:00:00.000' AS DateTime), N'Hiệu trưởng', N'nguyen.tuan@school.com')
INSERT [dbo].[NguoiDung] ([MaND], [TenTK], [MatKhau], [TrangThai], [HoTen], [DienThoai], [DiaChi], [GioiTinh], [NgaySinh], [ChucVu], [Email]) VALUES (N'ND002', N'pham.quy', N'0D397A5CDA49426EF505C2C7926FADBF', 1, N'Phạm Quỳnh Như', N'0901234568', N'Hà Nội, Việt Nam', N'Nữ', CAST(N'1992-03-14T00:00:00.000' AS DateTime), N'Nhân Viên Văn Phòng', N'pham.quy@school.com')
INSERT [dbo].[NguoiDung] ([MaND], [TenTK], [MatKhau], [TrangThai], [HoTen], [DienThoai], [DiaChi], [GioiTinh], [NgaySinh], [ChucVu], [Email]) VALUES (N'ND003', N'le.hoang', N'520A53A3F4B8C06AF467449997F4633F', 1, N'Lê Hoàng Nam', N'0901234569', N'Hồ Chí Minh, Việt Nam', N'Nam', CAST(N'1991-05-20T00:00:00.000' AS DateTime), N'Kế Toán', N'le.hoang@school.com')
INSERT [dbo].[NguoiDung] ([MaND], [TenTK], [MatKhau], [TrangThai], [HoTen], [DienThoai], [DiaChi], [GioiTinh], [NgaySinh], [ChucVu], [Email]) VALUES (N'ND004', N'nguyen.tuyet', N'181BA0FFDC9C276EA4032EC86470AAA4', 1, N'Nguyễn Tuyết Lan', N'0901234570', N'Hà Nội, Việt Nam', N'Nữ', CAST(N'1993-08-30T00:00:00.000' AS DateTime), N'Giáo Viên', N'nguyen.tuyet@school.com')
INSERT [dbo].[NguoiDung] ([MaND], [TenTK], [MatKhau], [TrangThai], [HoTen], [DienThoai], [DiaChi], [GioiTinh], [NgaySinh], [ChucVu], [Email]) VALUES (N'ND005', N'tran.hai', N'5AFF8B2E3E13ABDEC6AC74B1B787E9AE', 1, N'Trần Hải Đăng', N'0901234571', N'Đà Nẵng, Việt Nam', N'Nam', CAST(N'1989-06-15T00:00:00.000' AS DateTime), N'Giáo Viên', N'tran.hai@school.com')
INSERT [dbo].[NguoiDung] ([MaND], [TenTK], [MatKhau], [TrangThai], [HoTen], [DienThoai], [DiaChi], [GioiTinh], [NgaySinh], [ChucVu], [Email]) VALUES (N'ND006', N'hoang.dung', N'482c811da5d5b4bc6d497ffa98491e38', 1, N'Hoàng Dung', N'0901234572', N'Hà Nội, Việt Nam', N'Nữ', CAST(N'1994-02-25T00:00:00.000' AS DateTime), N'Giáo Viên', N'hoang.dung@school.com')
INSERT [dbo].[NguoiDung] ([MaND], [TenTK], [MatKhau], [TrangThai], [HoTen], [DienThoai], [DiaChi], [GioiTinh], [NgaySinh], [ChucVu], [Email]) VALUES (N'ND007', N'nguyen.kieu', N'482c811da5d5b4bc6d497ffa98491e38', 1, N'Nguyễn Kiều Trang', N'0901234573', N'Hồ Chí Minh, Việt Nam', N'Nữ', CAST(N'1995-07-08T00:00:00.000' AS DateTime), N'Giáo Viên', N'nguyen.kieu@school.com')
INSERT [dbo].[NguoiDung] ([MaND], [TenTK], [MatKhau], [TrangThai], [HoTen], [DienThoai], [DiaChi], [GioiTinh], [NgaySinh], [ChucVu], [Email]) VALUES (N'ND008', N'le.hieu', N'482c811da5d5b4bc6d497ffa98491e38', 1, N'Lê Hiếu Quang', N'0901234574', N'Hà Nội, Việt Nam', N'Nam', CAST(N'1992-09-17T00:00:00.000' AS DateTime), N'Giáo Viên', N'le.hieu@school.com')
INSERT [dbo].[NguoiDung] ([MaND], [TenTK], [MatKhau], [TrangThai], [HoTen], [DienThoai], [DiaChi], [GioiTinh], [NgaySinh], [ChucVu], [Email]) VALUES (N'ND009', N'pham.han', N'482c811da5d5b4bc6d497ffa98491e38', 1, N'Phạm Hân', N'0901234575', N'Đà Nẵng, Việt Nam', N'Nữ', CAST(N'1990-04-10T00:00:00.000' AS DateTime), N'Giáo Viên', N'pham.han@school.com')
INSERT [dbo].[NguoiDung] ([MaND], [TenTK], [MatKhau], [TrangThai], [HoTen], [DienThoai], [DiaChi], [GioiTinh], [NgaySinh], [ChucVu], [Email]) VALUES (N'ND010', N'trinh.son', N'482c811da5d5b4bc6d497ffa98491e38', 1, N'Trịnh Sơn Tùng', N'0901234576', N'Hồ Chí Minh, Việt Nam', N'Nam', CAST(N'1988-12-12T00:00:00.000' AS DateTime), N'Giáo Viên', N'trinh.son@school.com')
INSERT [dbo].[NguoiDung] ([MaND], [TenTK], [MatKhau], [TrangThai], [HoTen], [DienThoai], [DiaChi], [GioiTinh], [NgaySinh], [ChucVu], [Email]) VALUES (N'ND011', N'hoang.khanh', N'482c811da5d5b4bc6d497ffa98491e38', 1, N'Hoàng Khánh Vy', N'0901234577', N'Hà Nội, Việt Nam', N'Nữ', CAST(N'1996-03-20T00:00:00.000' AS DateTime), N'Giáo Viên', N'hoang.khanh@school.com')
INSERT [dbo].[NguoiDung] ([MaND], [TenTK], [MatKhau], [TrangThai], [HoTen], [DienThoai], [DiaChi], [GioiTinh], [NgaySinh], [ChucVu], [Email]) VALUES (N'ND012', N'nguyen.minh', N'482c811da5d5b4bc6d497ffa98491e38', 1, N'Nguyễn Minh Hoàng', N'0901234578', N'Hồ Chí Minh, Việt Nam', N'Nam', CAST(N'1994-06-18T00:00:00.000' AS DateTime), N'Giáo Viên', N'nguyen.minh@school.com')
INSERT [dbo].[NguoiDung] ([MaND], [TenTK], [MatKhau], [TrangThai], [HoTen], [DienThoai], [DiaChi], [GioiTinh], [NgaySinh], [ChucVu], [Email]) VALUES (N'ND013', N'tran.bao', N'482c811da5d5b4bc6d497ffa98491e38', 1, N'Trần Bảo Lâm', N'0901234579', N'Đà Nẵng, Việt Nam', N'Nam', CAST(N'1991-05-25T00:00:00.000' AS DateTime), N'Giáo Viên', N'tran.bao@school.com')
INSERT [dbo].[NguoiDung] ([MaND], [TenTK], [MatKhau], [TrangThai], [HoTen], [DienThoai], [DiaChi], [GioiTinh], [NgaySinh], [ChucVu], [Email]) VALUES (N'ND014', N'pham.bich', N'482c811da5d5b4bc6d497ffa98491e38', 1, N'Phạm Bích Ngọc', N'0901234580', N'Hà Nội, Việt Nam', N'Nữ', CAST(N'1993-07-03T00:00:00.000' AS DateTime), N'Giáo Viên', N'pham.bich@school.com')
INSERT [dbo].[NguoiDung] ([MaND], [TenTK], [MatKhau], [TrangThai], [HoTen], [DienThoai], [DiaChi], [GioiTinh], [NgaySinh], [ChucVu], [Email]) VALUES (N'ND015', N'le.duong', N'482c811da5d5b4bc6d497ffa98491e38', 1, N'Lê Dương Tình', N'0901234581', N'Hồ Chí Minh, Việt Nam', N'Nam', CAST(N'1992-10-27T00:00:00.000' AS DateTime), N'Giáo Viên', N'le.duong@school.com')
INSERT [dbo].[NguoiDung] ([MaND], [TenTK], [MatKhau], [TrangThai], [HoTen], [DienThoai], [DiaChi], [GioiTinh], [NgaySinh], [ChucVu], [Email]) VALUES (N'ND016', N'hoang.nhat', N'482c811da5d5b4bc6d497ffa98491e38', 1, N'Hoàng Nhật Anh', N'0901234582', N'Hà Nội, Việt Nam', N'Nam', CAST(N'1995-08-05T00:00:00.000' AS DateTime), N'Giáo Viên', N'hoang.nhat@school.com')
INSERT [dbo].[NguoiDung] ([MaND], [TenTK], [MatKhau], [TrangThai], [HoTen], [DienThoai], [DiaChi], [GioiTinh], [NgaySinh], [ChucVu], [Email]) VALUES (N'ND017', N'nguyen.yen', N'482c811da5d5b4bc6d497ffa98491e38', 1, N'Nguyễn Yến Nhi', N'0901234583', N'Hồ Chí Minh, Việt Nam', N'Nữ', CAST(N'1994-12-14T00:00:00.000' AS DateTime), N'Giáo Viên', N'nguyen.yen@school.com')
INSERT [dbo].[NguoiDung] ([MaND], [TenTK], [MatKhau], [TrangThai], [HoTen], [DienThoai], [DiaChi], [GioiTinh], [NgaySinh], [ChucVu], [Email]) VALUES (N'ND018', N'tran.thao', N'482c811da5d5b4bc6d497ffa98491e38', 1, N'Trần Thảo Ly', N'0901234584', N'Đà Nẵng, Việt Nam', N'Nữ', CAST(N'1992-01-22T00:00:00.000' AS DateTime), N'Giáo Viên', N'tran.thao@school.com')
INSERT [dbo].[NguoiDung] ([MaND], [TenTK], [MatKhau], [TrangThai], [HoTen], [DienThoai], [DiaChi], [GioiTinh], [NgaySinh], [ChucVu], [Email]) VALUES (N'ND019', N'pham.tam', N'482c811da5d5b4bc6d497ffa98491e38', 1, N'Phạm Tâm Anh', N'0901234585', N'Hà Nội, Việt Nam', N'Nam', CAST(N'1989-11-11T00:00:00.000' AS DateTime), N'Giáo Viên', N'pham.tam@school.com')
INSERT [dbo].[NguoiDung] ([MaND], [TenTK], [MatKhau], [TrangThai], [HoTen], [DienThoai], [DiaChi], [GioiTinh], [NgaySinh], [ChucVu], [Email]) VALUES (N'ND020', N'le.truc', N'482c811da5d5b4bc6d497ffa98491e38', 1, N'Lê Trúc Anh', N'0901234586', N'Hồ Chí Minh, Việt Nam', N'Nữ', CAST(N'1990-08-30T00:00:00.000' AS DateTime), N'Giáo Viên', N'le.truc@school.com')
GO
INSERT [dbo].[NguoiDung_NhomNguoiDung] ([MaND], [MaNhomNguoiDung], [GhiChu]) VALUES (N'ND001', N'NHOM01', NULL)
INSERT [dbo].[NguoiDung_NhomNguoiDung] ([MaND], [MaNhomNguoiDung], [GhiChu]) VALUES (N'ND002', N'NHOM02', NULL)
INSERT [dbo].[NguoiDung_NhomNguoiDung] ([MaND], [MaNhomNguoiDung], [GhiChu]) VALUES (N'ND003', N'NHOM03', NULL)
INSERT [dbo].[NguoiDung_NhomNguoiDung] ([MaND], [MaNhomNguoiDung], [GhiChu]) VALUES (N'ND004', N'NHOM05', NULL)
INSERT [dbo].[NguoiDung_NhomNguoiDung] ([MaND], [MaNhomNguoiDung], [GhiChu]) VALUES (N'ND005', N'NHOM04', NULL)
GO
INSERT [dbo].[NhomNguoiDung] ([MaNhom], [TenNhom], [GhiChu]) VALUES (N'NHOM01', N'HIệu trưởng', N'Quản lý toàn trường')
INSERT [dbo].[NhomNguoiDung] ([MaNhom], [TenNhom], [GhiChu]) VALUES (N'NHOM02    ', N'Nhân viên văn phòng', N'Quản lý học sinh')
INSERT [dbo].[NhomNguoiDung] ([MaNhom], [TenNhom], [GhiChu]) VALUES (N'NHOM03', N'Kế toán', N'Quản lý thu chi')
INSERT [dbo].[NhomNguoiDung] ([MaNhom], [TenNhom], [GhiChu]) VALUES (N'NHOM04', N'Giáo viên phụ trách', N'Quản lý học tập')
INSERT [dbo].[NhomNguoiDung] ([MaNhom], [TenNhom], [GhiChu]) VALUES (N'NHOM05', N'Giáo viên hỗ trợ', N'Quản lý học tập')
GO
INSERT [dbo].[PhanCong] ([MaLop], [MaGV], [VaiTro]) VALUES (N'LLA2324001', N'ND005', N'Giáo viên phụ trách')
INSERT [dbo].[PhanCong] ([MaLop], [MaGV], [VaiTro]) VALUES (N'LLA2324001', N'ND020', N'Giáo viên hỗ trợ')
INSERT [dbo].[PhanCong] ([MaLop], [MaGV], [VaiTro]) VALUES (N'LLA2324002', N'ND004', N'Giáo viên hỗ trợ')
INSERT [dbo].[PhanCong] ([MaLop], [MaGV], [VaiTro]) VALUES (N'LLA2324002', N'ND017', N'Giáo viên phụ trách')
INSERT [dbo].[PhanCong] ([MaLop], [MaGV], [VaiTro]) VALUES (N'LLC2324001', N'ND006', N'Giáo viên hỗ trợ')
INSERT [dbo].[PhanCong] ([MaLop], [MaGV], [VaiTro]) VALUES (N'LLC2324001', N'ND019', N'Giáo viên phụ trách')
INSERT [dbo].[PhanCong] ([MaLop], [MaGV], [VaiTro]) VALUES (N'LLC2324002', N'ND007', N'Giáo viên phụ trách')
INSERT [dbo].[PhanCong] ([MaLop], [MaGV], [VaiTro]) VALUES (N'LLC2324002', N'ND008', N'Giáo viên hỗ trợ')
INSERT [dbo].[PhanCong] ([MaLop], [MaGV], [VaiTro]) VALUES (N'LMN2324001', N'ND009', N'Giáo viên phụ trách')
INSERT [dbo].[PhanCong] ([MaLop], [MaGV], [VaiTro]) VALUES (N'LMN2324001', N'ND010', N'Giáo viên hỗ trợ')
INSERT [dbo].[PhanCong] ([MaLop], [MaGV], [VaiTro]) VALUES (N'LMN2324002', N'ND011', N'Giáo viên phụ trách')
INSERT [dbo].[PhanCong] ([MaLop], [MaGV], [VaiTro]) VALUES (N'LMN2324002', N'ND012', N'Giáo viên hỗ trợ')
INSERT [dbo].[PhanCong] ([MaLop], [MaGV], [VaiTro]) VALUES (N'LNT2324001', N'ND013', N'Giáo viên phụ trách')
INSERT [dbo].[PhanCong] ([MaLop], [MaGV], [VaiTro]) VALUES (N'LNT2324001', N'ND014', N'Giáo viên hỗ trợ')
INSERT [dbo].[PhanCong] ([MaLop], [MaGV], [VaiTro]) VALUES (N'LNT2324002', N'ND015', N'Giáo viên phụ trách')
INSERT [dbo].[PhanCong] ([MaLop], [MaGV], [VaiTro]) VALUES (N'LNT2324002', N'ND016', N'Giáo viên hỗ trợ')
GO
INSERT [dbo].[PhanLop] ([MaHS], [MaLop], [DanhGia], [XepLoai]) VALUES (N'HSNH23240001', N'LMN2324001', NULL, NULL)
INSERT [dbo].[PhanLop] ([MaHS], [MaLop], [DanhGia], [XepLoai]) VALUES (N'HSNH23240002', N'LMN2324001', NULL, NULL)
INSERT [dbo].[PhanLop] ([MaHS], [MaLop], [DanhGia], [XepLoai]) VALUES (N'HSNH23240003', N'LMN2324001', NULL, NULL)
INSERT [dbo].[PhanLop] ([MaHS], [MaLop], [DanhGia], [XepLoai]) VALUES (N'HSNH23240004', N'LMN2324001', NULL, NULL)
INSERT [dbo].[PhanLop] ([MaHS], [MaLop], [DanhGia], [XepLoai]) VALUES (N'HSNH23240005', N'LMN2324002', NULL, NULL)
INSERT [dbo].[PhanLop] ([MaHS], [MaLop], [DanhGia], [XepLoai]) VALUES (N'HSNH23240006', N'LLC2324001', NULL, NULL)
INSERT [dbo].[PhanLop] ([MaHS], [MaLop], [DanhGia], [XepLoai]) VALUES (N'HSNH23240007', N'LLC2324001', NULL, NULL)
INSERT [dbo].[PhanLop] ([MaHS], [MaLop], [DanhGia], [XepLoai]) VALUES (N'HSNH23240008', N'LLC2324001', NULL, NULL)
INSERT [dbo].[PhanLop] ([MaHS], [MaLop], [DanhGia], [XepLoai]) VALUES (N'HSNH23240009', N'LLC2324001', NULL, NULL)
INSERT [dbo].[PhanLop] ([MaHS], [MaLop], [DanhGia], [XepLoai]) VALUES (N'HSNH23240010', N'LLC2324002', NULL, NULL)
INSERT [dbo].[PhanLop] ([MaHS], [MaLop], [DanhGia], [XepLoai]) VALUES (N'HSNH23240011', N'LLA2324001', N'bé giỏi chăm ngoan', N'Bé ngoan')
INSERT [dbo].[PhanLop] ([MaHS], [MaLop], [DanhGia], [XepLoai]) VALUES (N'HSNH23240012', N'LLA2324001', NULL, NULL)
INSERT [dbo].[PhanLop] ([MaHS], [MaLop], [DanhGia], [XepLoai]) VALUES (N'HSNH23240013', N'LLA2324001', NULL, NULL)
INSERT [dbo].[PhanLop] ([MaHS], [MaLop], [DanhGia], [XepLoai]) VALUES (N'HSNH23240014', N'LLA2324001', NULL, NULL)
INSERT [dbo].[PhanLop] ([MaHS], [MaLop], [DanhGia], [XepLoai]) VALUES (N'HSNH23240015', N'LLA2324002', NULL, NULL)
INSERT [dbo].[PhanLop] ([MaHS], [MaLop], [DanhGia], [XepLoai]) VALUES (N'HSNH23240016', N'LNT2324001', NULL, NULL)
INSERT [dbo].[PhanLop] ([MaHS], [MaLop], [DanhGia], [XepLoai]) VALUES (N'HSNH23240017', N'LNT2324001', NULL, NULL)
INSERT [dbo].[PhanLop] ([MaHS], [MaLop], [DanhGia], [XepLoai]) VALUES (N'HSNH23240018', N'LNT2324001', NULL, NULL)
INSERT [dbo].[PhanLop] ([MaHS], [MaLop], [DanhGia], [XepLoai]) VALUES (N'HSNH23240019', N'LNT2324001', NULL, NULL)
INSERT [dbo].[PhanLop] ([MaHS], [MaLop], [DanhGia], [XepLoai]) VALUES (N'HSNH23240020', N'LNT2324002', NULL, NULL)
INSERT [dbo].[PhanLop] ([MaHS], [MaLop], [DanhGia], [XepLoai]) VALUES (N'HSNH23240022', N'LNT2324002', NULL, NULL)
INSERT [dbo].[PhanLop] ([MaHS], [MaLop], [DanhGia], [XepLoai]) VALUES (N'HSNH23240023', N'LNT2324002', NULL, NULL)
INSERT [dbo].[PhanLop] ([MaHS], [MaLop], [DanhGia], [XepLoai]) VALUES (N'HSNH23240025', N'LNT2324002', NULL, NULL)
INSERT [dbo].[PhanLop] ([MaHS], [MaLop], [DanhGia], [XepLoai]) VALUES (N'HSNH23240026', N'LMN2324002', NULL, NULL)
INSERT [dbo].[PhanLop] ([MaHS], [MaLop], [DanhGia], [XepLoai]) VALUES (N'HSNH23240027', N'LMN2324002', NULL, NULL)
INSERT [dbo].[PhanLop] ([MaHS], [MaLop], [DanhGia], [XepLoai]) VALUES (N'HSNH23240028', N'LMN2324002', NULL, NULL)
INSERT [dbo].[PhanLop] ([MaHS], [MaLop], [DanhGia], [XepLoai]) VALUES (N'HSNH23240031', N'LLC2324002', NULL, NULL)
INSERT [dbo].[PhanLop] ([MaHS], [MaLop], [DanhGia], [XepLoai]) VALUES (N'HSNH23240032', N'LLC2324002', NULL, NULL)
INSERT [dbo].[PhanLop] ([MaHS], [MaLop], [DanhGia], [XepLoai]) VALUES (N'HSNH23240033', N'LLC2324002', NULL, NULL)
INSERT [dbo].[PhanLop] ([MaHS], [MaLop], [DanhGia], [XepLoai]) VALUES (N'HSNH23240036', N'LLA2324002', NULL, NULL)
INSERT [dbo].[PhanLop] ([MaHS], [MaLop], [DanhGia], [XepLoai]) VALUES (N'HSNH23240037', N'LLA2324002', NULL, NULL)
INSERT [dbo].[PhanLop] ([MaHS], [MaLop], [DanhGia], [XepLoai]) VALUES (N'HSNH23240038', N'LLA2324002', NULL, NULL)
GO
INSERT [dbo].[PhanQuyen] ([MaNhom], [MaMH]) VALUES (N'NHOM01', N'MH09')
INSERT [dbo].[PhanQuyen] ([MaNhom], [MaMH]) VALUES (N'NHOM01', N'MH10')
INSERT [dbo].[PhanQuyen] ([MaNhom], [MaMH]) VALUES (N'NHOM01', N'MH11')
INSERT [dbo].[PhanQuyen] ([MaNhom], [MaMH]) VALUES (N'NHOM01', N'MH13')
INSERT [dbo].[PhanQuyen] ([MaNhom], [MaMH]) VALUES (N'NHOM01', N'MH14')
INSERT [dbo].[PhanQuyen] ([MaNhom], [MaMH]) VALUES (N'NHOM01', N'MH15')
INSERT [dbo].[PhanQuyen] ([MaNhom], [MaMH]) VALUES (N'NHOM01', N'MH16')
INSERT [dbo].[PhanQuyen] ([MaNhom], [MaMH]) VALUES (N'NHOM01', N'MH17')
INSERT [dbo].[PhanQuyen] ([MaNhom], [MaMH]) VALUES (N'NHOM01', N'MH18')
INSERT [dbo].[PhanQuyen] ([MaNhom], [MaMH]) VALUES (N'NHOM01', N'MH21')
INSERT [dbo].[PhanQuyen] ([MaNhom], [MaMH]) VALUES (N'NHOM02', N'MH04')
INSERT [dbo].[PhanQuyen] ([MaNhom], [MaMH]) VALUES (N'NHOM02', N'MH05')
INSERT [dbo].[PhanQuyen] ([MaNhom], [MaMH]) VALUES (N'NHOM02', N'MH13')
INSERT [dbo].[PhanQuyen] ([MaNhom], [MaMH]) VALUES (N'NHOM02', N'MH21')
INSERT [dbo].[PhanQuyen] ([MaNhom], [MaMH]) VALUES (N'NHOM03', N'MH01')
INSERT [dbo].[PhanQuyen] ([MaNhom], [MaMH]) VALUES (N'NHOM03', N'MH02')
INSERT [dbo].[PhanQuyen] ([MaNhom], [MaMH]) VALUES (N'NHOM03', N'MH03')
INSERT [dbo].[PhanQuyen] ([MaNhom], [MaMH]) VALUES (N'NHOM03', N'MH12')
INSERT [dbo].[PhanQuyen] ([MaNhom], [MaMH]) VALUES (N'NHOM03', N'MH22')
INSERT [dbo].[PhanQuyen] ([MaNhom], [MaMH]) VALUES (N'NHOM03', N'MH23')
INSERT [dbo].[PhanQuyen] ([MaNhom], [MaMH]) VALUES (N'NHOM03', N'MH24')
INSERT [dbo].[PhanQuyen] ([MaNhom], [MaMH]) VALUES (N'NHOM03', N'MH25')
INSERT [dbo].[PhanQuyen] ([MaNhom], [MaMH]) VALUES (N'NHOM03', N'MH26')
INSERT [dbo].[PhanQuyen] ([MaNhom], [MaMH]) VALUES (N'NHOM04', N'MH06')
INSERT [dbo].[PhanQuyen] ([MaNhom], [MaMH]) VALUES (N'NHOM04', N'MH07')
INSERT [dbo].[PhanQuyen] ([MaNhom], [MaMH]) VALUES (N'NHOM04', N'MH08')
INSERT [dbo].[PhanQuyen] ([MaNhom], [MaMH]) VALUES (N'NHOM04', N'MH19')
INSERT [dbo].[PhanQuyen] ([MaNhom], [MaMH]) VALUES (N'NHOM04', N'MH20')
INSERT [dbo].[PhanQuyen] ([MaNhom], [MaMH]) VALUES (N'NHOM05', N'MH06')
INSERT [dbo].[PhanQuyen] ([MaNhom], [MaMH]) VALUES (N'NHOM05', N'MH20')
GO
INSERT [dbo].[PhieuHocPhi] ([MaPhieuHP], [MaHS], [MaLop], [MaND], [NgayLapPhieu], [TrangThaiThanhToan], [Thang], [SoNgayHSVang], [SoNgayHSHoc], [TongTien], [TienNhan], [NgayThanhToan], [SoBuoiHocTrongThang]) VALUES (N'HP2324T12_HSNH23240001', N'HSNH23240001', N'LMN2324001', N'ND003', CAST(N'2024-12-02T11:54:13.000' AS DateTime), 1, 12, 0, 30, 1400000.0000, 1400000.0000, CAST(N'2024-12-02T00:00:00.000' AS DateTime), 30)
INSERT [dbo].[PhieuHocPhi] ([MaPhieuHP], [MaHS], [MaLop], [MaND], [NgayLapPhieu], [TrangThaiThanhToan], [Thang], [SoNgayHSVang], [SoNgayHSHoc], [TongTien], [TienNhan], [NgayThanhToan], [SoBuoiHocTrongThang]) VALUES (N'HP2324T12_HSNH23240002', N'HSNH23240002', N'LMN2324001', N'ND003', CAST(N'2024-12-02T11:54:13.000' AS DateTime), 1, 12, 0, 30, 1400000.0000, 1400000.0000, CAST(N'2024-12-02T00:00:00.000' AS DateTime), 30)
INSERT [dbo].[PhieuHocPhi] ([MaPhieuHP], [MaHS], [MaLop], [MaND], [NgayLapPhieu], [TrangThaiThanhToan], [Thang], [SoNgayHSVang], [SoNgayHSHoc], [TongTien], [TienNhan], [NgayThanhToan], [SoBuoiHocTrongThang]) VALUES (N'HP2324T12_HSNH23240003', N'HSNH23240003', N'LMN2324001', N'ND003', CAST(N'2024-12-02T11:54:13.000' AS DateTime), 1, 12, 0, 30, 1400000.0000, 1400000.0000, CAST(N'2024-12-02T00:00:00.000' AS DateTime), 30)
INSERT [dbo].[PhieuHocPhi] ([MaPhieuHP], [MaHS], [MaLop], [MaND], [NgayLapPhieu], [TrangThaiThanhToan], [Thang], [SoNgayHSVang], [SoNgayHSHoc], [TongTien], [TienNhan], [NgayThanhToan], [SoBuoiHocTrongThang]) VALUES (N'HP2324T12_HSNH23240004', N'HSNH23240004', N'LMN2324001', N'ND003', CAST(N'2024-12-02T11:54:13.000' AS DateTime), 1, 12, 0, 30, 1400000.0000, 1400000.0000, CAST(N'2024-12-02T00:00:00.000' AS DateTime), 30)
INSERT [dbo].[PhieuHocPhi] ([MaPhieuHP], [MaHS], [MaLop], [MaND], [NgayLapPhieu], [TrangThaiThanhToan], [Thang], [SoNgayHSVang], [SoNgayHSHoc], [TongTien], [TienNhan], [NgayThanhToan], [SoBuoiHocTrongThang]) VALUES (N'HP2324T12_HSNH23240005', N'HSNH23240005', N'LMN2324002', N'ND003', CAST(N'2024-12-02T11:54:13.000' AS DateTime), 1, 12, 0, 30, 1400000.0000, 1400000.0000, CAST(N'2024-12-02T00:00:00.000' AS DateTime), 30)
INSERT [dbo].[PhieuHocPhi] ([MaPhieuHP], [MaHS], [MaLop], [MaND], [NgayLapPhieu], [TrangThaiThanhToan], [Thang], [SoNgayHSVang], [SoNgayHSHoc], [TongTien], [TienNhan], [NgayThanhToan], [SoBuoiHocTrongThang]) VALUES (N'HP2324T12_HSNH23240006', N'HSNH23240006', N'LLC2324001', N'ND003', CAST(N'2024-12-02T11:54:13.000' AS DateTime), 1, 12, 0, 30, 1400000.0000, 1400000.0000, CAST(N'2024-12-02T00:00:00.000' AS DateTime), 30)
INSERT [dbo].[PhieuHocPhi] ([MaPhieuHP], [MaHS], [MaLop], [MaND], [NgayLapPhieu], [TrangThaiThanhToan], [Thang], [SoNgayHSVang], [SoNgayHSHoc], [TongTien], [TienNhan], [NgayThanhToan], [SoBuoiHocTrongThang]) VALUES (N'HP2324T12_HSNH23240007', N'HSNH23240007', N'LLC2324001', N'ND003', CAST(N'2024-12-02T11:54:13.000' AS DateTime), 1, 12, 0, 30, 1400000.0000, 1400000.0000, CAST(N'2024-12-02T00:00:00.000' AS DateTime), 30)
INSERT [dbo].[PhieuHocPhi] ([MaPhieuHP], [MaHS], [MaLop], [MaND], [NgayLapPhieu], [TrangThaiThanhToan], [Thang], [SoNgayHSVang], [SoNgayHSHoc], [TongTien], [TienNhan], [NgayThanhToan], [SoBuoiHocTrongThang]) VALUES (N'HP2324T12_HSNH23240008', N'HSNH23240008', N'LLC2324001', N'ND003', CAST(N'2024-12-02T11:54:13.000' AS DateTime), 1, 12, 2, 28, 1320000.0000, 1320000.0000, CAST(N'2024-12-02T00:00:00.000' AS DateTime), 30)
INSERT [dbo].[PhieuHocPhi] ([MaPhieuHP], [MaHS], [MaLop], [MaND], [NgayLapPhieu], [TrangThaiThanhToan], [Thang], [SoNgayHSVang], [SoNgayHSHoc], [TongTien], [TienNhan], [NgayThanhToan], [SoBuoiHocTrongThang]) VALUES (N'HP2324T12_HSNH23240009', N'HSNH23240009', N'LLC2324001', N'ND003', CAST(N'2024-12-02T11:54:13.000' AS DateTime), 1, 12, 4, 26, 1240000.0000, 1240000.0000, CAST(N'2024-12-02T00:00:00.000' AS DateTime), 30)
INSERT [dbo].[PhieuHocPhi] ([MaPhieuHP], [MaHS], [MaLop], [MaND], [NgayLapPhieu], [TrangThaiThanhToan], [Thang], [SoNgayHSVang], [SoNgayHSHoc], [TongTien], [TienNhan], [NgayThanhToan], [SoBuoiHocTrongThang]) VALUES (N'HP2324T12_HSNH23240010', N'HSNH23240010', N'LLC2324002', N'ND003', CAST(N'2024-12-02T11:54:13.000' AS DateTime), 1, 12, 0, 30, 1400000.0000, 1400000.0000, CAST(N'2024-12-02T00:00:00.000' AS DateTime), 30)
INSERT [dbo].[PhieuHocPhi] ([MaPhieuHP], [MaHS], [MaLop], [MaND], [NgayLapPhieu], [TrangThaiThanhToan], [Thang], [SoNgayHSVang], [SoNgayHSHoc], [TongTien], [TienNhan], [NgayThanhToan], [SoBuoiHocTrongThang]) VALUES (N'HP2324T12_HSNH23240011', N'HSNH23240011', N'LLA2324001', N'ND003', CAST(N'2024-12-02T11:54:13.000' AS DateTime), 1, 12, 0, 30, 1400000.0000, 1400000.0000, CAST(N'2024-12-02T00:00:00.000' AS DateTime), 30)
INSERT [dbo].[PhieuHocPhi] ([MaPhieuHP], [MaHS], [MaLop], [MaND], [NgayLapPhieu], [TrangThaiThanhToan], [Thang], [SoNgayHSVang], [SoNgayHSHoc], [TongTien], [TienNhan], [NgayThanhToan], [SoBuoiHocTrongThang]) VALUES (N'HP2324T12_HSNH23240012', N'HSNH23240012', N'LLA2324001', N'ND003', CAST(N'2024-12-02T11:54:13.000' AS DateTime), 1, 12, 0, 30, 1400000.0000, 1400000.0000, CAST(N'2024-12-02T00:00:00.000' AS DateTime), 30)
INSERT [dbo].[PhieuHocPhi] ([MaPhieuHP], [MaHS], [MaLop], [MaND], [NgayLapPhieu], [TrangThaiThanhToan], [Thang], [SoNgayHSVang], [SoNgayHSHoc], [TongTien], [TienNhan], [NgayThanhToan], [SoBuoiHocTrongThang]) VALUES (N'HP2324T12_HSNH23240013', N'HSNH23240013', N'LLA2324001', N'ND003', CAST(N'2024-12-02T11:54:13.000' AS DateTime), 1, 12, 0, 30, 1400000.0000, 1400000.0000, CAST(N'2024-12-02T00:00:00.000' AS DateTime), 30)
INSERT [dbo].[PhieuHocPhi] ([MaPhieuHP], [MaHS], [MaLop], [MaND], [NgayLapPhieu], [TrangThaiThanhToan], [Thang], [SoNgayHSVang], [SoNgayHSHoc], [TongTien], [TienNhan], [NgayThanhToan], [SoBuoiHocTrongThang]) VALUES (N'HP2324T12_HSNH23240014', N'HSNH23240014', N'LLA2324001', N'ND003', CAST(N'2024-12-02T11:54:13.000' AS DateTime), 0, 12, 0, 30, 1400000.0000, NULL, NULL, 30)
INSERT [dbo].[PhieuHocPhi] ([MaPhieuHP], [MaHS], [MaLop], [MaND], [NgayLapPhieu], [TrangThaiThanhToan], [Thang], [SoNgayHSVang], [SoNgayHSHoc], [TongTien], [TienNhan], [NgayThanhToan], [SoBuoiHocTrongThang]) VALUES (N'HP2324T12_HSNH23240015', N'HSNH23240015', N'LLA2324002', N'ND003', CAST(N'2024-12-02T11:54:13.000' AS DateTime), 1, 12, 1, 29, 1360000.0000, 1360000.0000, CAST(N'2024-12-02T00:00:00.000' AS DateTime), 30)
INSERT [dbo].[PhieuHocPhi] ([MaPhieuHP], [MaHS], [MaLop], [MaND], [NgayLapPhieu], [TrangThaiThanhToan], [Thang], [SoNgayHSVang], [SoNgayHSHoc], [TongTien], [TienNhan], [NgayThanhToan], [SoBuoiHocTrongThang]) VALUES (N'HP2324T12_HSNH23240016', N'HSNH23240016', N'LNT2324001', N'ND003', CAST(N'2024-12-02T11:54:13.000' AS DateTime), 1, 12, 0, 30, 1400000.0000, 1400000.0000, CAST(N'2024-12-02T00:00:00.000' AS DateTime), 30)
INSERT [dbo].[PhieuHocPhi] ([MaPhieuHP], [MaHS], [MaLop], [MaND], [NgayLapPhieu], [TrangThaiThanhToan], [Thang], [SoNgayHSVang], [SoNgayHSHoc], [TongTien], [TienNhan], [NgayThanhToan], [SoBuoiHocTrongThang]) VALUES (N'HP2324T12_HSNH23240017', N'HSNH23240017', N'LNT2324001', N'ND003', CAST(N'2024-12-02T11:54:13.000' AS DateTime), 1, 12, 0, 30, 1400000.0000, 1400000.0000, CAST(N'2024-12-02T00:00:00.000' AS DateTime), 30)
INSERT [dbo].[PhieuHocPhi] ([MaPhieuHP], [MaHS], [MaLop], [MaND], [NgayLapPhieu], [TrangThaiThanhToan], [Thang], [SoNgayHSVang], [SoNgayHSHoc], [TongTien], [TienNhan], [NgayThanhToan], [SoBuoiHocTrongThang]) VALUES (N'HP2324T12_HSNH23240018', N'HSNH23240018', N'LNT2324001', N'ND003', CAST(N'2024-12-02T11:54:13.000' AS DateTime), 1, 12, 0, 30, 1400000.0000, 1400000.0000, CAST(N'2024-12-02T00:00:00.000' AS DateTime), 30)
INSERT [dbo].[PhieuHocPhi] ([MaPhieuHP], [MaHS], [MaLop], [MaND], [NgayLapPhieu], [TrangThaiThanhToan], [Thang], [SoNgayHSVang], [SoNgayHSHoc], [TongTien], [TienNhan], [NgayThanhToan], [SoBuoiHocTrongThang]) VALUES (N'HP2324T12_HSNH23240019', N'HSNH23240019', N'LNT2324001', N'ND003', CAST(N'2024-12-02T11:54:13.000' AS DateTime), 1, 12, 0, 30, 1400000.0000, 1400000.0000, CAST(N'2024-12-02T00:00:00.000' AS DateTime), 30)
INSERT [dbo].[PhieuHocPhi] ([MaPhieuHP], [MaHS], [MaLop], [MaND], [NgayLapPhieu], [TrangThaiThanhToan], [Thang], [SoNgayHSVang], [SoNgayHSHoc], [TongTien], [TienNhan], [NgayThanhToan], [SoBuoiHocTrongThang]) VALUES (N'HP2324T12_HSNH23240020', N'HSNH23240020', N'LNT2324002', N'ND003', CAST(N'2024-12-02T11:54:13.000' AS DateTime), 1, 12, 0, 30, 1400000.0000, 1400000.0000, CAST(N'2024-12-02T00:00:00.000' AS DateTime), 30)
INSERT [dbo].[PhieuHocPhi] ([MaPhieuHP], [MaHS], [MaLop], [MaND], [NgayLapPhieu], [TrangThaiThanhToan], [Thang], [SoNgayHSVang], [SoNgayHSHoc], [TongTien], [TienNhan], [NgayThanhToan], [SoBuoiHocTrongThang]) VALUES (N'HP2324T12_HSNH23240022', N'HSNH23240022', N'LNT2324002', N'ND003', CAST(N'2024-12-02T11:54:13.000' AS DateTime), 1, 12, 0, 30, 1400000.0000, 1400000.0000, CAST(N'2024-12-02T00:00:00.000' AS DateTime), 30)
INSERT [dbo].[PhieuHocPhi] ([MaPhieuHP], [MaHS], [MaLop], [MaND], [NgayLapPhieu], [TrangThaiThanhToan], [Thang], [SoNgayHSVang], [SoNgayHSHoc], [TongTien], [TienNhan], [NgayThanhToan], [SoBuoiHocTrongThang]) VALUES (N'HP2324T12_HSNH23240023', N'HSNH23240023', N'LNT2324002', N'ND003', CAST(N'2024-12-02T11:54:13.000' AS DateTime), 1, 12, 0, 30, 1400000.0000, 1400000.0000, CAST(N'2024-12-02T00:00:00.000' AS DateTime), 30)
INSERT [dbo].[PhieuHocPhi] ([MaPhieuHP], [MaHS], [MaLop], [MaND], [NgayLapPhieu], [TrangThaiThanhToan], [Thang], [SoNgayHSVang], [SoNgayHSHoc], [TongTien], [TienNhan], [NgayThanhToan], [SoBuoiHocTrongThang]) VALUES (N'HP2324T12_HSNH23240025', N'HSNH23240025', N'LNT2324002', N'ND003', CAST(N'2024-12-02T11:54:13.000' AS DateTime), 1, 12, 0, 30, 1400000.0000, 1400000.0000, CAST(N'2024-12-02T00:00:00.000' AS DateTime), 30)
INSERT [dbo].[PhieuHocPhi] ([MaPhieuHP], [MaHS], [MaLop], [MaND], [NgayLapPhieu], [TrangThaiThanhToan], [Thang], [SoNgayHSVang], [SoNgayHSHoc], [TongTien], [TienNhan], [NgayThanhToan], [SoBuoiHocTrongThang]) VALUES (N'HP2324T12_HSNH23240026', N'HSNH23240026', N'LMN2324002', N'ND003', CAST(N'2024-12-02T11:54:13.000' AS DateTime), 1, 12, 0, 30, 1400000.0000, 1400000.0000, CAST(N'2024-12-02T00:00:00.000' AS DateTime), 30)
INSERT [dbo].[PhieuHocPhi] ([MaPhieuHP], [MaHS], [MaLop], [MaND], [NgayLapPhieu], [TrangThaiThanhToan], [Thang], [SoNgayHSVang], [SoNgayHSHoc], [TongTien], [TienNhan], [NgayThanhToan], [SoBuoiHocTrongThang]) VALUES (N'HP2324T12_HSNH23240027', N'HSNH23240027', N'LMN2324002', N'ND003', CAST(N'2024-12-02T11:54:13.000' AS DateTime), 1, 12, 0, 30, 1400000.0000, 1400000.0000, CAST(N'2024-12-02T00:00:00.000' AS DateTime), 30)
INSERT [dbo].[PhieuHocPhi] ([MaPhieuHP], [MaHS], [MaLop], [MaND], [NgayLapPhieu], [TrangThaiThanhToan], [Thang], [SoNgayHSVang], [SoNgayHSHoc], [TongTien], [TienNhan], [NgayThanhToan], [SoBuoiHocTrongThang]) VALUES (N'HP2324T12_HSNH23240028', N'HSNH23240028', N'LMN2324002', N'ND003', CAST(N'2024-12-02T11:54:13.000' AS DateTime), 1, 12, 0, 30, 1400000.0000, 1400000.0000, CAST(N'2024-12-02T00:00:00.000' AS DateTime), 30)
INSERT [dbo].[PhieuHocPhi] ([MaPhieuHP], [MaHS], [MaLop], [MaND], [NgayLapPhieu], [TrangThaiThanhToan], [Thang], [SoNgayHSVang], [SoNgayHSHoc], [TongTien], [TienNhan], [NgayThanhToan], [SoBuoiHocTrongThang]) VALUES (N'HP2324T12_HSNH23240031', N'HSNH23240031', N'LLC2324002', N'ND003', CAST(N'2024-12-02T11:54:13.000' AS DateTime), 1, 12, 0, 30, 1400000.0000, 1400000.0000, CAST(N'2024-12-02T00:00:00.000' AS DateTime), 30)
INSERT [dbo].[PhieuHocPhi] ([MaPhieuHP], [MaHS], [MaLop], [MaND], [NgayLapPhieu], [TrangThaiThanhToan], [Thang], [SoNgayHSVang], [SoNgayHSHoc], [TongTien], [TienNhan], [NgayThanhToan], [SoBuoiHocTrongThang]) VALUES (N'HP2324T12_HSNH23240032', N'HSNH23240032', N'LLC2324002', N'ND003', CAST(N'2024-12-02T11:54:13.000' AS DateTime), 1, 12, 0, 30, 1400000.0000, 1400000.0000, CAST(N'2024-12-02T00:00:00.000' AS DateTime), 30)
INSERT [dbo].[PhieuHocPhi] ([MaPhieuHP], [MaHS], [MaLop], [MaND], [NgayLapPhieu], [TrangThaiThanhToan], [Thang], [SoNgayHSVang], [SoNgayHSHoc], [TongTien], [TienNhan], [NgayThanhToan], [SoBuoiHocTrongThang]) VALUES (N'HP2324T12_HSNH23240033', N'HSNH23240033', N'LLC2324002', N'ND003', CAST(N'2024-12-02T11:54:13.000' AS DateTime), 1, 12, 0, 30, 1400000.0000, 1400000.0000, CAST(N'2024-12-02T00:00:00.000' AS DateTime), 30)
INSERT [dbo].[PhieuHocPhi] ([MaPhieuHP], [MaHS], [MaLop], [MaND], [NgayLapPhieu], [TrangThaiThanhToan], [Thang], [SoNgayHSVang], [SoNgayHSHoc], [TongTien], [TienNhan], [NgayThanhToan], [SoBuoiHocTrongThang]) VALUES (N'HP2324T12_HSNH23240036', N'HSNH23240036', N'LLA2324002', N'ND003', CAST(N'2024-12-02T11:54:13.000' AS DateTime), 1, 12, 0, 30, 1400000.0000, 1400000.0000, CAST(N'2024-12-02T00:00:00.000' AS DateTime), 30)
INSERT [dbo].[PhieuHocPhi] ([MaPhieuHP], [MaHS], [MaLop], [MaND], [NgayLapPhieu], [TrangThaiThanhToan], [Thang], [SoNgayHSVang], [SoNgayHSHoc], [TongTien], [TienNhan], [NgayThanhToan], [SoBuoiHocTrongThang]) VALUES (N'HP2324T12_HSNH23240037', N'HSNH23240037', N'LLA2324002', N'ND003', CAST(N'2024-12-02T11:54:13.000' AS DateTime), 1, 12, 1, 29, 1360000.0000, 1360000.0000, CAST(N'2024-12-02T00:00:00.000' AS DateTime), 30)
INSERT [dbo].[PhieuHocPhi] ([MaPhieuHP], [MaHS], [MaLop], [MaND], [NgayLapPhieu], [TrangThaiThanhToan], [Thang], [SoNgayHSVang], [SoNgayHSHoc], [TongTien], [TienNhan], [NgayThanhToan], [SoBuoiHocTrongThang]) VALUES (N'HP2324T12_HSNH23240038', N'HSNH23240038', N'LLA2324002', N'ND003', CAST(N'2024-12-02T11:54:13.000' AS DateTime), 1, 12, 2, 28, 1320000.0000, 1320000.0000, CAST(N'2024-12-02T00:00:00.000' AS DateTime), 30)
GO
INSERT [dbo].[PhongHoc] ([MaPhong], [TenPhong], [SucChua], [ViTri], [TinhTrang]) VALUES (N'PH001', N'A109', 30, N'Lầu 1', N'Đang dùng')
INSERT [dbo].[PhongHoc] ([MaPhong], [TenPhong], [SucChua], [ViTri], [TinhTrang]) VALUES (N'PH002', N'A110', 20, N'Lầu 1', N'Đang dùng')
INSERT [dbo].[PhongHoc] ([MaPhong], [TenPhong], [SucChua], [ViTri], [TinhTrang]) VALUES (N'PH003', N'A011', 20, N'Tầng trệt', N'Đang dùng')
INSERT [dbo].[PhongHoc] ([MaPhong], [TenPhong], [SucChua], [ViTri], [TinhTrang]) VALUES (N'PH004', N'A012', 20, N'Tầng trệt', N'Đang dùng')
INSERT [dbo].[PhongHoc] ([MaPhong], [TenPhong], [SucChua], [ViTri], [TinhTrang]) VALUES (N'PH005', N'A213', 20, N'Lầu 2', N'Đang dùng')
INSERT [dbo].[PhongHoc] ([MaPhong], [TenPhong], [SucChua], [ViTri], [TinhTrang]) VALUES (N'PH006', N'A214', 10, N'Lầu 2', N'Đang dùng')
INSERT [dbo].[PhongHoc] ([MaPhong], [TenPhong], [SucChua], [ViTri], [TinhTrang]) VALUES (N'PH007', N'A215', 30, N'Lầu 2', N'Đang dùng')
INSERT [dbo].[PhongHoc] ([MaPhong], [TenPhong], [SucChua], [ViTri], [TinhTrang]) VALUES (N'PH008', N'A116', 30, N'Lầu 1', N'Đang dùng')
INSERT [dbo].[PhongHoc] ([MaPhong], [TenPhong], [SucChua], [ViTri], [TinhTrang]) VALUES (N'PH009', N'A301', 30, N'Tầng trệt', N'Đang dùng')
INSERT [dbo].[PhongHoc] ([MaPhong], [TenPhong], [SucChua], [ViTri], [TinhTrang]) VALUES (N'PH010', N'A302', 30, N'Tầng trệt', N'Đang dùng')
GO
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH232400011', N'Nguyễn Văn An', N'Nam', 1980, N'123 Lê Lợi, Q.1', N'Nhân viên văn phòng', N'0901234567', N'an.nguyen@example.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH232400012', N'Lê Thị Bích', N'Nam', 1982, N'456 Trần Hưng Đạo, Q.5', N'Giáo viên', N'0902234567', N'an.nguyen@example.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH232400021', N'Trần Văn Cường', N'Nam', 1979, N'789 Nguyễn Huệ, Q.7', N'Kinh doanh', N'0903234567', N'cuong.tran@example.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH232400022', N'Phạm Thị Dung', N'Nữ', 1983, N'123 Lý Thường Kiệt, Q.10', N'Bác sĩ', N'0904234567', N'dung.pham@example.com', N'Mẹ')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH232400031', N'Võ Huy Hoàng', N'Nam', 1981, N'567 Pasteur, Q.3', N'Kỹ sư', N'0905234567', N'hoang.vo@example.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH232400032', N'Đỗ Thị Hoa', N'Nữ', 1984, N'234 Hai Bà Trưng, Q.3', N'Kế toán', N'0906234567', N'hoa.do@example.com', N'Mẹ')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH232400041', N'Ngô Văn Hải', N'Nam', 1978, N'890 Điện Biên Phủ, Q.5', N'Công nhân', N'0907234567', N'hai.ngo@example.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH232400042', N'Trương Thị Hồng', N'Nữ', 1985, N'456 Phạm Ngũ Lão, Q.3', N'Y tá', N'0908234567', N'hong.truong@example.com', N'Mẹ')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH232400051', N'Lý Minh Đức', N'Nam', 1977, N'567 Nguyễn Trãi, Q.1', N'Lập trình viên', N'0909234567', N'duc.ly@example.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH232400052', N'Nguyễn Thị Lan', N'Nữ', 1986, N'789 Lê Văn Sỹ, Q.3', N'Luật sư', N'0910234567', N'lan.nguyen@example.com', N'Mẹ')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH232400061', N'Phan Văn Khang', N'Nam', 1980, N'123 Hùng Vương, Q.5', N'Kiến trúc sư', N'0911234567', N'khang.phan@example.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH232400062', N'Hoàng Thị Mai', N'Nữ', 1987, N'456 Cách Mạng Tháng 8, Q.10', N'Nhà báo', N'0912234567', N'mai.hoang@example.com', N'Mẹ')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH232400071', N'Đặng Văn Lâm', N'Nam', 1979, N'789 Võ Văn Tần, Q.3', N'Giám đốc', N'0913234567', N'lam.dang@example.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH232400072', N'Phạm Thị Ngọc', N'Nữ', 1984, N'123 Nam Kỳ Khởi Nghĩa, Q.1', N'Biên tập viên', N'0914234567', N'ngoc.pham@example.com', N'Mẹ')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH232400081', N'Trịnh Công Sơn', N'Nam', 1981, N'456 Lê Lợi, Q.7', N'Nhạc sĩ', N'0915234567', N'son.trinh@example.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH232400082', N'Ngô Thị Hạnh', N'Nữ', 1985, N'789 Trần Quốc Thảo, Q.3', N'Nhân viên văn phòng', N'0916234567', N'hanh.ngo@example.com', N'Mẹ')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH232400091', N'Nguyễn Văn Phát', N'Nam', 1983, N'567 Điện Biên Phủ, Q.5', N'Thợ mộc', N'0917234567', N'phat.nguyen@example.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH232400092', N'Lê Thị Xuân', N'Nữ', 1982, N'234 Nguyễn Đình Chiểu, Q.10', N'Nhân viên marketing', N'0918234567', N'xuan.le@example.com', N'Mẹ')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH232400101', N'Hoàng Minh Tâm', N'Nam', 1980, N'123 Nguyễn Thái Học, Q.1', N'Kỹ sư xây dựng', N'0919234567', N'tam.hoang@example.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH232400102', N'Đặng Thị Hoa', N'Nữ', 1987, N'789 Phan Đăng Lưu, Q.3', N'Nhân viên kế toán', N'0920234567', N'hoa.dang@example.com', N'Mẹ')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH232400111', N'Phạm Văn Hùng', N'Nam', 1978, N'456 Lý Chính Thắng, Q.5', N'Quản lý kho', N'0921234567', N'hung.pham@example.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH232400112', N'Nguyễn Thị Bình', N'Nữ', 1986, N'789 Lê Văn Lương, Q.7', N'Giảng viên', N'0922234567', N'binh.nguyen@example.com', N'Mẹ')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH232400121', N'Trần Minh Quân', N'Nam', 1981, N'123 Nguyễn Văn Trỗi, Q.3', N'Công nhân', N'0923234567', N'quan.tran@example.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH232400122', N'Lê Thị Nguyệt', N'Nữ', 1985, N'456 Trường Chinh, Q.10', N'Nhân viên ngân hàng', N'0924234567', N'nguyet.le@example.com', N'Mẹ')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH232400131', N'Ngô Văn Dũng', N'Nam', 1983, N'789 Hoàng Diệu, Q.1', N'Kỹ thuật viên', N'0925234567', N'dung.ngo@example.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH232400132', N'Phạm Thị Tuyết', N'Nữ', 1984, N'123 Cách Mạng Tháng 8, Q.3', N'Nhân viên bán hàng', N'0926234567', N'tuyet.pham@example.com', N'Mẹ')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH232400141', N'Lý Văn Minh', N'Nam', 1979, N'456 Phan Văn Trị, Q.5', N'Thợ cơ khí', N'0927234567', N'minh.ly@example.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH232400142', N'Trần Thị Ngân', N'Nữ', 1982, N'789 Lê Hồng Phong, Q.7', N'Nhân viên văn thư', N'0928234567', N'ngan.tran@example.com', N'Mẹ')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH232400151', N'Đỗ Văn Khánh', N'Nam', 1981, N'123 Trần Cao Vân, Q.1', N'Tài xế', N'0929234567', N'khanh.do@example.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH232400152', N'Nguyễn Thị Thảo', N'Nữ', 1987, N'456 Nguyễn Trãi, Q.10', N'Nhân viên quản lý', N'0930234567', N'thao.nguyen@example.com', N'Mẹ')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH232400161', N'Lê Văn Trí', N'Nam', 1978, N'789 Hồng Bàng, Q.3', N'Thợ sửa điện', N'0931234567', N'phanthethanh0209@gmail.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH232400162', N'Phạm Thị Yến', N'Nữ', 1985, N'123 Nguyễn Huệ, Q.5', N'Cán bộ xã hội', N'0932234567', N'yen.pham@example.com', N'Mẹ')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH232400171', N'Đinh Văn Toàn', N'Nam', 1983, N'234 Lê Lợi, Q.1', N'Kỹ sư phần mềm', N'0933234567', N'truonglebaotran12a192021@gmail.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH232400172', N'Trần Thị Kim Anh', N'Nữ', 1986, N'567 Hùng Vương, Q.5', N'Nhân viên truyền thông', N'0934234567', N'anh.kim@example.com', N'Mẹ')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH232400181', N'Ngô Văn An', N'Nam', 1982, N'789 Trường Sơn, Q.10', N'Thợ điện lạnh', N'0935234567', N'minhquang85213@gmail.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH232400182', N'Lê Thị Hoa Mai', N'Nữ', 1984, N'123 Nam Kỳ Khởi Nghĩa, Q.1', N'Nhân viên nhân sự', N'0936234567', N'mai.le@example.com', N'Mẹ')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH232400191', N'Phạm Văn Quý', N'Nam', 1980, N'456 Võ Văn Kiệt, Q.7', N'Lái xe taxi', N'0937234567', N'quy.pham@example.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH232400192', N'Nguyễn Thị Ngọc Hạnh', N'Nữ', 1985, N'789 Nguyễn Văn Linh, Q.3', N'Nhân viên chăm sóc khách hàng', N'0938234567', N'quy.pham@example.com', N'Mẹ')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH232400201', N'Hoàng Văn Huy', N'Nam', 1981, N'123 Lý Thái Tổ, Q.5', N'Giảng viên đại học', N'0939234567', N'huy.hoang@example.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH232400202', N'Nguyễn Thị Thu Thủy', N'Nữ', 1987, N'456 Nguyễn Thị Minh Khai, Q.10', N'Nhân viên thiết kế', N'0940234567', N'huy.hoang@example.com', N'Mẹ')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH232400211', N'Trần Văn Phúc', N'Nam', 1979, N'789 Lê Hồng Phong, Q.3', N'Kỹ thuật viên', N'0941234567', N'phuc.tran@example.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH232400212', N'Lê Thị Thanh', N'Nữ', 1986, N'123 Phạm Ngọc Thạch, Q.1', N'Nhân viên văn phòng', N'0942234567', N'phuc.tran@example.com', N'Mẹ')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH232400221', N'Đặng Văn Hải', N'Nam', 1980, N'456 Lê Văn Sỹ, Q.5', N'Nhân viên quản lý dự án', N'0943234567', N'hai.dang@example.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH232400222', N'Ngô Thị Yến', N'Nữ', 1983, N'789 Lý Chính Thắng, Q.10', N'Nhân viên tư vấn', N'0944234567', N'hai.dang@example.com', N'Mẹ')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH232400231', N'Nguyễn Văn Hoàng', N'Nam', 1984, N'123 Trần Hưng Đạo, Q.7', N'Kỹ sư cơ khí', N'0945234567', N'hoang.nguyen@example.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH232400232', N'Lý Thị Hồng', N'Nữ', 1982, N'456 Nguyễn Thị Định, Q.1', N'Nhân viên pháp chế', N'0946234567', N'hoang.nguyen@example.com', N'Mẹ')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH232400241', N'Đỗ Văn Sơn', N'Nam', 1978, N'789 Phan Đăng Lưu, Q.5', N'Nhân viên IT', N'0947234567', N'son.do@example.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH232400242', N'Phạm Thị Loan', N'Nữ', 1987, N'123 Võ Thị Sáu, Q.10', N'Nhân viên hỗ trợ kỹ thuật', N'0948234567', N'son.do@example.com', N'Mẹ')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH232400251', N'Trịnh Văn Hoài', N'Nam', 1981, N'456 Nguyễn Huệ, Q.3', N'Quản lý chất lượng', N'0949234567', N'hoai.trinh@example.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH232400252', N'Lê Thị Thủy', N'Nữ', 1985, N'789 Cách Mạng Tháng 8, Q.7', N'Chuyên viên phân tích', N'0950234567', N'hoai.trinh@example.com', N'Mẹ')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH232400261', N'Nguyễn Thị Kim', N'Nữ', 1983, N'123 Bùi Viện, Q.1', N'Nhân viên hành chính', N'0951234567', N'kim.nguyen@example.com', N'Mẹ')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH232400262', N'Trần Hồng Sơn', N'Nam', 1980, N'456 Đỗ Quang, Q.5', N'Quản lý sản xuất', N'0952234567', N'kim.nguyen@example.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH232400271', N'Lê Thanh Hải', N'Nam', 1986, N'789 Nguyễn Duy Trinh, Q.7', N'Nhân viên tài chính', N'0953234567', N'hai.le@example.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH232400272', N'Phạm Quỳnh Mai', N'Nữ', 1984, N'123 Lê Văn Lương, Q.3', N'Giám đốc marketing', N'0954234567', N'hai.le@example.com', N'Mẹ')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH232400281', N'Nguyễn Duy Khang', N'Nam', 1982, N'456 Phan Đình Phùng, Q.10', N'Thư ký', N'0955234567', N'khang.nguyen@example.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH232400282', N'Trần Lan Anh', N'Nữ', 1981, N'789 Trường Sơn, Q.5', N'Giảng viên đại học', N'0956234567', N'khang.nguyen@example.com', N'Mẹ')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH232400291', N'Lý Văn Toàn', N'Nam', 1985, N'123 Cống Quỳnh, Q.1', N'Chuyên viên HR', N'0957234567', N'toan.ly@example.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH232400292', N'Nguyễn Thị Quế', N'Nữ', 1986, N'456 Nguyễn Kiệm, Q.3', N'Nhân viên kế toán', N'0958234567', N'toan.ly@example.com', N'Mẹ')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH232400301', N'Phan Thiện Hương', N'Nữ', 1980, N'789 Nguyễn Trãi, Q.5', N'Lập trình viên', N'0959234567', N'huong.phan@example.com', N'Mẹ')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH232400302', N'Trương Bảo Châu', N'Nam', 1984, N'123 Bà Triệu, Q.7', N'Cố vấn tài chính', N'0960234567', N'huong.phan@example.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH232400311', N'Lê Hữu Tín', N'Nam', 1983, N'456 Trần Hưng Đạo, Q.3', N'Nhân viên phát triển phần mềm', N'0961234567', N'tin.le@example.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH232400312', N'Phạm Ngọc Vân', N'Nữ', 1982, N'789 Lý Thái Tổ, Q.1', N'Giám đốc điều hành', N'0962234567', N'tin.le@example.com', N'Mẹ')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH232400321', N'Trần Lê Duy', N'Nam', 1981, N'123 Trường Chinh, Q.10', N'Chuyên viên marketing', N'0963234567', N'duy.tran@example.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH232400322', N'Lý Minh Nhật', N'Nữ', 1986, N'456 Hồng Bàng, Q.5', N'Thư ký tổng giám đốc', N'0964234567', N'duy.tran@example.com', N'Mẹ')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH232400331', N'Nguyễn Phan Khoa', N'Nam', 1984, N'789 Võ Thị Sáu, Q.3', N'Chuyên viên phân tích dữ liệu', N'0965234567', N'khoa.nguyen@example.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH232400332', N'Hoàng Thị Xuân', N'Nữ', 1985, N'123 Cách Mạng Tháng 8, Q.7', N'Trợ lý giám đốc', N'0966234567', N'khoa.nguyen@example.com', N'Mẹ')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH232400341', N'Phạm Anh Khoa', N'Nam', 1982, N'456 Lê Quang Định, Q.1', N'Giám sát viên', N'0967234567', N'khoa.pham@example.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH232400342', N'Trương Minh Tâm', N'Nữ', 1986, N'789 Nguyễn Huệ, Q.5', N'Bác sĩ', N'0968234567', N'khoa.pham@example.com', N'Mẹ')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH232400351', N'Nguyễn Ngọc Thi', N'Nam', 1984, N'123 Nam Kỳ Khởi Nghĩa, Q.3', N'Phát triển sản phẩm', N'0969234567', N'thi.nguyen@example.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH232400352', N'Trần Lê Mai', N'Nữ', 1983, N'456 Trần Phú, Q.10', N'Lập trình viên', N'0970234567', N'thi.nguyen@example.com', N'Mẹ')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH232400361', N'Lý Thanh Hà', N'Nam', 1980, N'789 Phan Đăng Lưu, Q.1', N'Giám đốc kinh doanh', N'0971234567', N'ha.ly@example.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH232400362', N'Nguyễn Hữu Quyết', N'Nữ', 1985, N'123 Bùi Thị Xuân, Q.5', N'Nhân viên hỗ trợ khách hàng', N'0972234567', N'ha.ly@example.com', N'Mẹ')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH232400371', N'Trương Thanh Lâm', N'Nam', 1983, N'456 Điện Biên Phủ, Q.7', N'Giảng viên', N'0973234567', N'lam.truong@example.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH232400372', N'Lê Bảo Châu', N'Nữ', 1982, N'789 Cách Mạng Tháng 8, Q.3', N'Nhân viên kỹ thuật', N'0974234567', N'lam.truong@example.com', N'Mẹ')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH232400381', N'Nguyễn Quang Duy', N'Nam', 1984, N'123 Nguyễn Thị Minh Khai, Q.1', N'Lãnh đạo phòng ban', N'0975234567', N'duy.nguyen@example.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH232400382', N'Trần Thị Yến', N'Nữ', 1987, N'456 Võ Thị Sáu, Q.5', N'Nhân viên ngân hàng', N'0976234567', N'duy.nguyen@example.com', N'Mẹ')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH232400391', N'Trần Minh Khoa', N'Nam', 1983, N'123 Nguyễn Tri Phương, Q.5', N'Nhân viên nghiên cứu', N'0951234567', N'khoa.tran@example.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH232400392', N'Nguyễn Thị Lan Anh', N'Nữ', 1986, N'456 Lê Văn Sỹ, Q.1', N'Chuyên viên marketing', N'0952234567', N'khoa.tran@example.com', N'Mẹ')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH232400401', N'Lê Thị Bảo Ngọc', N'Nam', 1982, N'789 Phạm Hồng Thái, Q.3', N'Giám đốc nhân sự', N'0953234567', N'baongoc.le@example.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH232400402', N'Đặng Thị Lan', N'Nữ', 1984, N'123 Trường Chinh, Q.10', N'Nhân viên thiết kế', N'0954234567', N'baongoc.le@example.com', N'Mẹ')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500011', N'Nguyễn Văn A', N'Nam', 1980, N'Số 10, Đường A, Quận B', N'Giáo viên', N'0912345678', N'nva@gmail.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500012', N'Trần Thị B', N'Nữ', 1985, N'Số 20, Đường B, Quận C', N'Nhân viên văn phòng', N'0923456789', N'nva@gmail.com', N'Mẹ')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500021', N'Lê Văn C', N'Nam', 1978, N'Số 30, Đường C, Quận D', N'Kỹ sư', N'0934567890', N'lvc@gmail.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500022', N'Phạm Thị D', N'Nữ', 1982, N'Số 40, Đường D, Quận E', N'Nội trợ', N'0945678901', N'ptd@gmail.com', N'Mẹ')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500031', N'Hoàng Văn E', N'Nam', 1975, N'Số 50, Đường E, Quận F', N'Bác sĩ', N'0956789012', N'hve@gmail.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500032', N'Vũ Thị F', N'Nữ', 1980, N'Số 60, Đường F, Quận G', N'Công nhân', N'0967890123', N'hve@gmail.com', N'Mẹ')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500041', N'Ngô Văn G', N'Nam', 1983, N'Số 70, Đường G, Quận H', N'Lái xe', N'0978901234', N'nvg@gmail.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500042', N'Doãn Thị H', N'Nữ', 1986, N'Số 80, Đường H, Quận I', N'Kinh doanh', N'0989012345', N'nvg@gmail.com', N'Mẹ')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500051', N'Đỗ Văn I', N'Nam', 1979, N'Số 90, Đường I, Quận J', N'Kỹ thuật viên', N'0990123456', N'dvi@gmail.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500052', N'Bùi Thị K', N'Nữ', 1984, N'Số 100, Đường J, Quận K', N'Nhân viên kế toán', N'0912345671', N'dvi@gmail.com', N'Mẹ')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500061', N'Nguyễn Văn L', N'Nam', 1981, N'Số 110, Đường K, Quận L', N'Chuyên gia IT', N'0923456712', N'nvl@gmail.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500062', N'Trần Thị M', N'Nữ', 1987, N'Số 120, Đường L, Quận M', N'Quản lý dự án', N'0934567123', N'nvl@gmail.com', N'Mẹ')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500071', N'Lê Văn N', N'Nam', 1977, N'Số 130, Đường M, Quận N', N'Giảng viên', N'0945671234', N'lvn@gmail.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500072', N'Phạm Thị O', N'Nữ', 1982, N'Số 140, Đường N, Quận O', N'Kỹ sư xây dựng', N'0956712345', N'lvn@gmail.com', N'Mẹ')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500081', N'Hoàng Văn P', N'Nam', 1976, N'Số 150, Đường O, Quận P', N'Chuyên viên tài chính', N'0967123456', N'hvp@gmail.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500082', N'Vũ Thị Q', N'Nữ', 1981, N'Số 160, Đường P, Quận Q', N'Giáo viên mầm non', N'0971234567', N'hvp@gmail.com', N'Mẹ')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500091', N'Ngô Văn R', N'Nam', 1983, N'Số 170, Đường Q, Quận R', N'Nhân viên kinh doanh', N'0982345678', N'nvr@gmail.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500092', N'Doãn Thị S', N'Nữ', 1985, N'Số 180, Đường R, Quận S', N'Nhân viên hành chính', N'0993456789', N'nvr@gmail.com', N'Mẹ')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500101', N'Đỗ Văn T', N'Nam', 1980, N'Số 190, Đường S, Quận T', N'Giám đốc', N'0914567890', N'dvt@gmail.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500102', N'Bùi Thị U', N'Nữ', 1986, N'Số 200, Đường T, Quận U', N'Kế toán trưởng', N'0925678901', N'dvt@gmail.com', N'Mẹ')
GO
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500111', N'Nguyễn Văn V', N'Nam', 1982, N'Số 210, Đường U, Quận V', N'Luật sư', N'0936789012', N'nvv@gmail.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500112', N'Trần Thị W', N'Nữ', 1984, N'Số 220, Đường V, Quận W', N'Nhân viên ngân hàng', N'0947890123', N'nvv@gmail.com', N'Mẹ')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500121', N'Lê Văn X', N'Nam', 1978, N'Số 230, Đường W, Quận X', N'Kiến trúc sư', N'0958901234', N'lvx@gmail.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500122', N'Phạm Thị Y', N'Nữ', 1983, N'Số 240, Đường X, Quận Y', N'Nhà báo', N'0969012345', N'lvx@gmail.com', N'Mẹ')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500131', N'Hoàng Văn Z', N'Nam', 1977, N'Số 250, Đường Y, Quận Z', N'Nhà nghiên cứu', N'0970123456', N'hvz@gmail.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500132', N'Vũ Thị AA', N'Nữ', 1985, N'Số 260, Đường Z, Quận AA', N'Chuyên viên PR', N'0981234567', N'hvz@gmail.com', N'Mẹ')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500141', N'Ngô Văn AB', N'Nam', 1981, N'Số 270, Đường AA, Quận AB', N'Nhân viên kỹ thuật', N'0992345678', N'nvab@gmail.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500142', N'Doãn Thị AC', N'Nữ', 1984, N'Số 280, Đường AB, Quận AC', N'Trợ lý giám đốc', N'0913456789', N'nvab@gmail.com', N'Mẹ')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500151', N'Đỗ Văn AD', N'Nam', 1979, N'Số 290, Đường AC, Quận AD', N'Nhân viên bảo trì', N'0924567890', N'dvad@gmail.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500152', N'Bùi Thị AE', N'Nữ', 1986, N'Số 300, Đường AD, Quận AE', N'Thư ký', N'0935678901', N'dvad@gmail.com', N'Mẹ')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500161', N'Nguyễn Văn AF', N'Nam', 1982, N'Số 310, Đường AE, Quận AF', N'Tài xế', N'0946789012', N'nvaf@gmail.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500162', N'Trần Thị AG', N'Nữ', 1987, N'Số 320, Đường AF, Quận AG', N'Nhân viên pháp lý', N'0957890123', N'nvaf@gmail.com', N'Mẹ')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500171', N'Lê Văn AH', N'Nam', 1976, N'Số 330, Đường AG, Quận AH', N'Chuyên viên hoạch định', N'0968901234', N'lvah@gmail.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500172', N'Phạm Thị AI', N'Nữ', 1980, N'Số 340, Đường AH, Quận AI', N'Chuyên viên tuyển dụng', N'0979012345', N'lvah@gmail.com', N'Mẹ')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500181', N'Hoàng Văn AJ', N'Nam', 1978, N'Số 350, Đường AI, Quận AJ', N'Chuyên viên CNTT', N'0980123456', N'hvaj@gmail.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500182', N'Vũ Thị AK', N'Nữ', 1983, N'Số 360, Đường AJ, Quận AK', N'Chuyên viên marketing', N'0991234567', N'hvaj@gmail.com', N'Mẹ')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500191', N'Ngô Văn AL', N'Nam', 1981, N'Số 370, Đường AK, Quận AL', N'Quản lý dự án', N'0912345678', N'nval@gmail.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500192', N'Doãn Thị AM', N'Nữ', 1984, N'Số 380, Đường AL, Quận AM', N'Nhân viên xuất nhập khẩu', N'0923456789', N'nval@gmail.com', N'Mẹ')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500201', N'Đỗ Văn AN', N'Nam', 1979, N'Số 390, Đường AM, Quận AN', N'Trưởng phòng kinh doanh', N'0934567890', N'dvan@gmail.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500202', N'Bùi Thị AO', N'Nữ', 1986, N'Số 400, Đường AN, Quận AO', N'Trưởng phòng nhân sự', N'0945678901', N'btao@gmail.com', N'Mẹ')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500221', N'Nguyễn Văn Minh', N'Nam', 1980, N'123 Nguyễn Trãi', N'Kỹ sư xây dựng', N'0934567800', N'minh@gmail.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500222', N'Phạm Thị Hồng', N'Nữ', 1982, N'456 Trần Hưng Đạo', N'Giáo viên', N'0945678902', N'minh@gmail.com', N'Mẹ')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500231', N'Hoàng Văn Hùng', N'Nam', 1975, N'789 Hai Bà Trưng', N'Trưởng phòng kế toán', N'0934567801', N'hung@gmail.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500232', N'Lê Thị Lan', N'Nữ', 1990, N'567 Lý Thường Kiệt', N'Nhân viên văn phòng', N'0945678903', N'hung@gmail.com', N'Mẹ')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500241', N'Vũ Văn Hải', N'Nam', 1983, N'234 Phạm Ngũ Lão', N'Kỹ sư phần mềm', N'0934567802', N'hai@gmail.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500242', N'Nguyễn Thị Bích', N'Nữ', 1985, N'890 Cách Mạng Tháng Tám', N'Trưởng phòng nhân sự', N'0945678904', N'hai@gmail.com', N'Mẹ')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500251', N'Trần Văn Hòa', N'Nam', 1992, N'321 Tôn Đức Thắng', N'Tài xế', N'0934567803', N'hoa@gmail.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500252', N'Đặng Thị Hoa', N'Nữ', 1995, N'654 Phan Đình Phùng', N'Nội trợ', N'0945678905', N'hoa@gmail.com', N'Mẹ')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500261', N'Phan Văn Nam', N'Nam', 1987, N'987 Nguyễn Văn Cừ', N'Chủ doanh nghiệp', N'0934567804', N'nam@gmail.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500262', N'Tạ Thị Mai', N'Nữ', 1989, N'321 Lạc Long Quân', N'Bác sĩ', N'0945678906', N'nam@gmail.com', N'Mẹ')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500271', N'Lưu Văn Dũng', N'Nam', 1981, N'234 Võ Thị Sáu', N'Giảng viên đại học', N'0934567805', N'dung@gmail.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500272', N'Thái Thị Hồng', N'Nữ', 1993, N'123 Hoàng Hoa Thám', N'Nhân viên kế toán', N'0945678907', N'dung@gmail.com', N'Mẹ')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500281', N'Tô Văn An', N'Nam', 1978, N'890 Bạch Đằng', N'Kỹ thuật viên', N'0934567806', N'an@gmail.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500282', N'Vương Thị Lan', N'Nữ', 1986, N'567 Đống Đa', N'Nông dân', N'0945678908', N'an@gmail.com', N'Mẹ')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500291', N'Hồ Văn Hải', N'Nam', 1990, N'345 Điện Biên Phủ', N'Công nhân', N'0934567807', N'hohai@gmail.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500292', N'Lý Thị Cúc', N'Nữ', 1992, N'234 Trường Chinh', N'Nội trợ', N'0945678909', N'hohai@gmail.com', N'Mẹ')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500301', N'Nguyễn Văn Tùng', N'Nam', 1984, N'123 Cao Thắng', N'Chuyên viên marketing', N'0934567808', N'tung@gmail.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500302', N'Phạm Thị Loan', N'Nữ', 1991, N'456 Hùng Vương', N'Kinh doanh tự do', N'0945678910', N'tung@gmail.com', N'Mẹ')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500311', N'Trịnh Văn Phong', N'Nam', 1982, N'789 Phan Văn Trị', N'Nhân viên ngân hàng', N'0934567809', N'phong@gmail.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500312', N'Lê Thị Hà', N'Nữ', 1988, N'234 Hoàng Diệu', N'Nội trợ', N'0945678911', N'phong@gmail.com', N'Mẹ')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500321', N'Võ Văn Lộc', N'Nam', 1979, N'345 Bà Triệu', N'Thợ điện', N'0934567810', N'loc@gmail.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500322', N'Ngô Thị Thủy', N'Nữ', 1983, N'678 Ngô Gia Tự', N'Trợ lý giám đốc', N'0945678912', N'loc@gmail.com', N'Mẹ')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500331', N'Tôn Thất Quang', N'Nam', 1985, N'456 Võ Văn Kiệt', N'Thợ cơ khí', N'0934567811', N'quang@gmail.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500332', N'Phan Thị Tuyết', N'Nữ', 1987, N'789 Tân Bình', N'Nhân viên y tế', N'0945678913', N'quang@gmail.com', N'Mẹ')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500341', N'Trần Văn Thành', N'Nam', 1989, N'123 Ba Vì', N'Chủ doanh nghiệp', N'0934567812', N'thanh@gmail.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500342', N'Lý Thị Hương', N'Nữ', 1993, N'234 Cầu Giấy', N'Nội trợ', N'0945678914', N'thanh@gmail.com', N'Mẹ')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500351', N'Nguyễn Văn Khánh', N'Nam', 1980, N'456 Kim Mã', N'Trưởng phòng kỹ thuật', N'0934567813', N'khanh@gmail.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500352', N'Tô Thị Lệ', N'Nữ', 1986, N'789 Lý Sơn', N'Nhân viên bán hàng', N'0945678915', N'khanh@gmail.com', N'Mẹ')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500361', N'Vũ Văn Sơn', N'Nam', 1981, N'321 Tây Sơn', N'Công nhân kỹ thuật', N'0934567814', N'son@gmail.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500362', N'Phạm Thị Ngọc', N'Nữ', 1985, N'654 Hà Đông', N'Nhân viên hành chính', N'0945678916', N'son@gmail.com', N'Mẹ')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500371', N'Trịnh Văn Lâm', N'Nam', 1977, N'234 Vĩnh Tuy', N'Thợ sửa chữa', N'0934567815', N'lam@gmail.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500372', N'Lê Thị Hoa', N'Nữ', 1988, N'123 Long Biên', N'Nhân viên tư vấn', N'0945678917', N'lam@gmail.com', N'Mẹ')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500381', N'Hà Văn Minh', N'Nam', 1983, N'345 Đống Đa', N'Tài xế', N'0934567816', N'minhha@gmail.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500382', N'Thái Thị Ánh', N'Nữ', 1990, N'678 Cầu Giấy', N'Giáo viên mầm non', N'0945678918', N'minhha@gmail.com', N'Mẹ')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500391', N'Tôn Văn Tài', N'Nam', 1976, N'456 Nam Từ Liêm', N'Công nhân cơ khí', N'0934567817', N'tai@gmail.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500392', N'Vương Thị Ngân', N'Nữ', 1991, N'789 Bắc Từ Liêm', N'Nhân viên tiếp thị', N'0945678919', N'tai@gmail.com', N'Mẹ')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500401', N'Trương Văn Cường', N'Nam', 1984, N'234 Thanh Xuân', N'Kỹ thuật viên', N'0934567818', N'cuong@gmail.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500402', N'Lê Thị Yến', N'Nữ', 1994, N'123 Hai Bà Trưng', N'Nhân viên văn phòng', N'0945678920', N'cuong@gmail.com', N'Mẹ')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500411', N'Nguyễn Văn Đạt', N'Nam', 1982, N'567 Hoàn Kiếm', N'Nhân viên kỹ thuật', N'0934567820', N'dat@gmail.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500412', N'Phạm Thị Nhung', N'Nữ', 1988, N'890 Cầu Giấy', N'Giảng viên đại học', N'0945678921', N'dat@gmail.com', N'Mẹ')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500421', N'Lê Văn Trọng', N'Nam', 1980, N'123 Mỹ Đình', N'Quản lý dự án', N'0934567821', N'trong@gmail.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500422', N'Ngô Thị Hạnh', N'Nữ', 1985, N'456 Tân Phú', N'Bác sĩ nha khoa', N'0945678922', N'trong@gmail.com', N'Mẹ')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500431', N'Phan Văn Toàn', N'Nam', 1979, N'789 Tây Hồ', N'Kế toán trưởng', N'0934567822', N'toanphan@gmail.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500432', N'Trịnh Thị Vân', N'Nữ', 1986, N'567 Hoàng Mai', N'Nội trợ', N'0945678923', N'toanphan@gmail.com', N'Mẹ')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500441', N'Vũ Văn Phú', N'Nam', 1983, N'234 Long Biên', N'Chuyên viên pháp lý', N'0934567823', N'phu@gmail.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500442', N'Tôn Thị Thanh', N'Nữ', 1990, N'123 Nam Từ Liêm', N'Nhân viên ngân hàng', N'0945678924', N'phu@gmail.com', N'Mẹ')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500451', N'Ngô Văn Bình', N'Nam', 1987, N'345 Bắc Từ Liêm', N'Trưởng nhóm phát triển phần mềm', N'0934567824', N'binhngo@gmail.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500452', N'Trần Thị Hiền', N'Nữ', 1992, N'789 Cầu Giấy', N'Chuyên viên nhân sự', N'0945678925', N'binhngo@gmail.com', N'Mẹ')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500461', N'Phạm Văn Kiên', N'Nam', 1978, N'456 Thanh Xuân', N'Giảng viên', N'0934567825', N'kienpham@gmail.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500462', N'Lý Thị Tuyền', N'Nữ', 1989, N'234 Hoàn Kiếm', N'Kinh doanh tự do', N'0945678926', N'kienpham@gmail.com', N'Mẹ')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500471', N'Trương Văn Hữu', N'Nam', 1985, N'123 Đống Đa', N'Trưởng phòng sản xuất', N'0934567826', N'huutruong@gmail.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500472', N'Vương Thị Mai', N'Nữ', 1993, N'567 Hai Bà Trưng', N'Nhân viên tư vấn', N'0945678927', N'huutruong@gmail.com', N'Mẹ')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500481', N'Tôn Thất Dũng', N'Nam', 1981, N'789 Hoàng Mai', N'Trợ lý giám đốc', N'0934567827', N'dungton@gmail.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500482', N'Lê Thị Cẩm', N'Nữ', 1995, N'890 Ba Đình', N'Nội trợ', N'0945678928', N'dungton@gmail.com', N'Mẹ')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500491', N'Nguyễn Văn Thanh', N'Nam', 1990, N'321 Cầu Giấy', N'Tài xế', N'0934567828', N'thanhnguyen@gmail.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500492', N'Trần Thị Lý', N'Nữ', 1992, N'654 Hai Bà Trưng', N'Giáo viên', N'0945678929', N'thanhnguyen@gmail.com', N'Mẹ')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500501', N'Tôn Văn Cảnh', N'Nam', 1984, N'567 Tân Bình', N'Công nhân kỹ thuật', N'0934567829', N'canhton@gmail.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500502', N'Phạm Thị Quyên', N'Nữ', 1991, N'890 Bắc Từ Liêm', N'Nhân viên chăm sóc khách hàng', N'0945678930', N'canhton@gmail.com', N'Mẹ')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500511', N'Lý Văn Lập', N'Nam', 1982, N'345 Thanh Xuân', N'Nhân viên văn phòng', N'0934567830', N'laply@gmail.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500512', N'Nguyễn Thị Thảo', N'Nữ', 1990, N'456 Đống Đa', N'Chuyên viên tài chính', N'0945678931', N'laply@gmail.com', N'Mẹ')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500521', N'Trần Văn Hoàn', N'Nam', 1985, N'789 Hai Bà Trưng', N'Kỹ sư xây dựng', N'0934567831', N'hoantran@gmail.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500522', N'Lê Thị Nhàn', N'Nữ', 1993, N'567 Cầu Giấy', N'Nhân viên ngân hàng', N'0945678932', N'hoantran@gmail.com', N'Mẹ')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500531', N'Phạm Văn Duy', N'Nam', 1988, N'345 Hoàn Kiếm', N'Thợ sửa chữa', N'0934567832', N'phamd@gmail.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500532', N'Trịnh Thị Vui', N'Nữ', 1992, N'234 Thanh Xuân', N'Nhân viên bán hàng', N'0945678933', N'phamd@gmail.com', N'Mẹ')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500541', N'Trương Văn Khoa', N'Nam', 1987, N'123 Tân Bình', N'Trưởng phòng', N'0934567833', N'khoa@gmail.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500542', N'Ngô Thị Nhàn', N'Nữ', 1991, N'567 Bắc Từ Liêm', N'Nội trợ', N'0945678934', N'khoa@gmail.com', N'Mẹ')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500551', N'Lê Văn Hữu', N'Nam', 1989, N'789 Cầu Giấy', N'Trợ lý dự án', N'0934567834', N'huule@gmail.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500552', N'Trần Thị Thu', N'Nữ', 1995, N'890 Hoàng Mai', N'Chuyên viên kế toán', N'0945678935', N'huule@gmail.com', N'Mẹ')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500561', N'Nguyễn Văn Bình', N'Nam', 1988, N'123 Đống Đa', N'Kỹ sư xây dựng', N'0978123456', N'binh@gmail.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500562', N'Phạm Thị Lan', N'Nữ', 1992, N'456 Hai Bà Trưng', N'Giáo viên', N'0934567890', N'lan@gmail.com', N'Mẹ')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500571', N'Hoàng Văn Minh', N'Nam', 1985, N'789 Ba Đình', N'Tài xế', N'0987654321', N'minh@gmail.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500572', N'Vũ Thị Hạnh', N'Nữ', 1990, N'321 Thanh Xuân', N'Nhân viên văn phòng', N'0901234567', N'minh@gmail.com', N'Mẹ')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500581', N'Trần Văn An', N'Nam', 1987, N'234 Hoàn Kiếm', N'Kỹ thuật viên', N'0912345678', N'an@gmail.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500582', N'Bùi Thị Hoa', N'Nữ', 1994, N'678 Nam Từ Liêm', N'Trợ lý kinh doanh', N'0923456789', N'an@gmail.com', N'Mẹ')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500591', N'Lê Văn Hùng', N'Nam', 1986, N'987 Hoàng Cầu', N'Quản lý dự án', N'0932345678', N'hung@gmail.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500592', N'Đặng Thị Tuyết', N'Nữ', 1993, N'543 Tây Hồ', N'Nhân viên ngân hàng', N'0941234567', N'hung@gmail.com', N'Mẹ')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500601', N'Phan Văn Tùng', N'Nam', 1989, N'123 Hoàng Mai', N'Nhân viên logistics', N'0953456789', N'tung@gmail.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500602', N'Nguyễn Thị Mai', N'Nữ', 1991, N'456 Long Biên', N'Kế toán trưởng', N'0961234567', N'tung@gmail.com', N'Mẹ')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500611', N'Doãn Văn Khôi', N'Nam', 1985, N'678 Gia Lâm', N'Trưởng phòng kinh doanh', N'0971234567', N'khoi@gmail.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500612', N'Phạm Thị Ngọc', N'Nữ', 1995, N'987 Hà Đông', N'Chuyên viên nhân sự', N'0984567890', N'khoi@gmail.com', N'Mẹ')
GO
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500621', N'Trần Văn Lộc', N'Nam', 1983, N'123 Sơn Tây', N'Trưởng phòng IT', N'0991234567', N'loc@gmail.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500622', N'Nguyễn Thị Hiền', N'Nữ', 1992, N'456 Hà Đông', N'Chuyên viên tư vấn', N'0916789456', N'loc@gmail.com', N'Mẹ')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500631', N'Lê Văn Tiến', N'Nam', 1990, N'789 Mỹ Đình', N'Kỹ sư phần mềm', N'0904567891', N'tien@gmail.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500632', N'Trần Thị Bích', N'Nữ', 1993, N'234 Từ Liêm', N'Chuyên viên pháp lý', N'0921345678', N'tien@gmail.com', N'Mẹ')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500641', N'Hoàng Văn Cường', N'Nam', 1988, N'567 Thường Tín', N'Trưởng phòng tài chính', N'0913456782', N'cuong@gmail.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500642', N'Lê Thị Loan', N'Nữ', 1994, N'789 Thanh Trì', N'Chuyên viên marketing', N'0936789451', N'cuong@gmail.com', N'Mẹ')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500651', N'Vũ Văn Phúc', N'Nam', 1987, N'890 Chương Mỹ', N'Nhân viên bảo hiểm', N'0973456789', N'phuc@gmail.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500652', N'Phạm Thị Hương', N'Nữ', 1990, N'678 Hoài Đức', N'Chuyên viên tài chính', N'0945678912', N'phuc@gmail.com', N'Mẹ')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500661', N'Nguyễn Văn An', N'Nam', 1985, N'456 Thanh Xuân', N'Kỹ sư phần mềm', N'0981234567', N'anan@gmail.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500662', N'Lê Thị Bích Ngọc', N'Nữ', 1988, N'123 Cầu Giấy', N'Giảng viên', N'0912345678', N'anan@gmail.com', N'Mẹ')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500671', N'Hoàng Văn Hùng', N'Nam', 1982, N'789 Hoàng Mai', N'Lái xe', N'0934567891', N'hung@gmail.com', N'Ba')
INSERT [dbo].[PhuHuynh] ([MaPH], [HoTen], [GioiTinh], [NamSinh], [DiaChiCQ], [NgheNghiep], [DienThoai], [Email], [QuanHe]) VALUES (N'PHHSNH242500672', N'Trần Thị Minh Châu', N'Nữ', 1993, N'321 Hai Bà Trưng', N'Nhân viên ngân hàng', N'0909876543', N'hung@gmail.com', N'Mẹ')
GO
INSERT [dbo].[ThamGiaNgoaiKhoa] ([MaTTHD], [NgayDK], [MaHD], [MaHS], [TienNhan], [MaND]) VALUES (N'HD001_HSNH23240001', CAST(N'2024-12-02T00:00:00.000' AS DateTime), N'HD001', N'HSNH23240001', 500000.0000, N'ND003')
INSERT [dbo].[ThamGiaNgoaiKhoa] ([MaTTHD], [NgayDK], [MaHD], [MaHS], [TienNhan], [MaND]) VALUES (N'HD001_HSNH23240002', CAST(N'2024-12-02T00:00:00.000' AS DateTime), N'HD001', N'HSNH23240002', 500000.0000, N'ND003')
INSERT [dbo].[ThamGiaNgoaiKhoa] ([MaTTHD], [NgayDK], [MaHD], [MaHS], [TienNhan], [MaND]) VALUES (N'HD001_HSNH23240003', CAST(N'2024-12-02T00:00:00.000' AS DateTime), N'HD001', N'HSNH23240003', 500000.0000, N'ND003')
INSERT [dbo].[ThamGiaNgoaiKhoa] ([MaTTHD], [NgayDK], [MaHD], [MaHS], [TienNhan], [MaND]) VALUES (N'HD001_HSNH23240004', CAST(N'2024-12-02T00:00:00.000' AS DateTime), N'HD001', N'HSNH23240004', 500000.0000, N'ND003')
INSERT [dbo].[ThamGiaNgoaiKhoa] ([MaTTHD], [NgayDK], [MaHD], [MaHS], [TienNhan], [MaND]) VALUES (N'HD001_HSNH23240005', CAST(N'2024-12-02T00:00:00.000' AS DateTime), N'HD001', N'HSNH23240005', 500000.0000, N'ND003')
INSERT [dbo].[ThamGiaNgoaiKhoa] ([MaTTHD], [NgayDK], [MaHD], [MaHS], [TienNhan], [MaND]) VALUES (N'HD001_HSNH23240006', CAST(N'2024-12-02T00:00:00.000' AS DateTime), N'HD001', N'HSNH23240006', 500000.0000, N'ND003')
INSERT [dbo].[ThamGiaNgoaiKhoa] ([MaTTHD], [NgayDK], [MaHD], [MaHS], [TienNhan], [MaND]) VALUES (N'HD001_HSNH23240007', CAST(N'2024-12-02T00:00:00.000' AS DateTime), N'HD001', N'HSNH23240007', 500000.0000, N'ND003')
INSERT [dbo].[ThamGiaNgoaiKhoa] ([MaTTHD], [NgayDK], [MaHD], [MaHS], [TienNhan], [MaND]) VALUES (N'HD001_HSNH23240008', CAST(N'2024-12-02T00:00:00.000' AS DateTime), N'HD001', N'HSNH23240008', 500000.0000, N'ND003')
INSERT [dbo].[ThamGiaNgoaiKhoa] ([MaTTHD], [NgayDK], [MaHD], [MaHS], [TienNhan], [MaND]) VALUES (N'HD001_HSNH23240009', CAST(N'2024-12-02T00:00:00.000' AS DateTime), N'HD001', N'HSNH23240009', 500000.0000, N'ND003')
INSERT [dbo].[ThamGiaNgoaiKhoa] ([MaTTHD], [NgayDK], [MaHD], [MaHS], [TienNhan], [MaND]) VALUES (N'HD001_HSNH23240010', CAST(N'2024-12-02T00:00:00.000' AS DateTime), N'HD001', N'HSNH23240010', 500000.0000, N'ND003')
INSERT [dbo].[ThamGiaNgoaiKhoa] ([MaTTHD], [NgayDK], [MaHD], [MaHS], [TienNhan], [MaND]) VALUES (N'HD001_HSNH23240011', CAST(N'2024-12-02T00:00:00.000' AS DateTime), N'HD001', N'HSNH23240011', 500000.0000, N'ND003')
INSERT [dbo].[ThamGiaNgoaiKhoa] ([MaTTHD], [NgayDK], [MaHD], [MaHS], [TienNhan], [MaND]) VALUES (N'HD001_HSNH23240012', CAST(N'2024-12-02T00:00:00.000' AS DateTime), N'HD001', N'HSNH23240012', 500000.0000, N'ND003')
INSERT [dbo].[ThamGiaNgoaiKhoa] ([MaTTHD], [NgayDK], [MaHD], [MaHS], [TienNhan], [MaND]) VALUES (N'HD001_HSNH23240013', CAST(N'2024-12-02T00:00:00.000' AS DateTime), N'HD001', N'HSNH23240013', 500000.0000, N'ND003')
INSERT [dbo].[ThamGiaNgoaiKhoa] ([MaTTHD], [NgayDK], [MaHD], [MaHS], [TienNhan], [MaND]) VALUES (N'HD001_HSNH23240015', CAST(N'2024-12-02T00:00:00.000' AS DateTime), N'HD001', N'HSNH23240015', 500000.0000, N'ND003')
INSERT [dbo].[ThamGiaNgoaiKhoa] ([MaTTHD], [NgayDK], [MaHD], [MaHS], [TienNhan], [MaND]) VALUES (N'HD001_HSNH23240016', CAST(N'2024-12-02T00:00:00.000' AS DateTime), N'HD001', N'HSNH23240016', 500000.0000, N'ND003')
INSERT [dbo].[ThamGiaNgoaiKhoa] ([MaTTHD], [NgayDK], [MaHD], [MaHS], [TienNhan], [MaND]) VALUES (N'HD001_HSNH23240017', CAST(N'2024-12-02T00:00:00.000' AS DateTime), N'HD001', N'HSNH23240017', 500000.0000, N'ND003')
INSERT [dbo].[ThamGiaNgoaiKhoa] ([MaTTHD], [NgayDK], [MaHD], [MaHS], [TienNhan], [MaND]) VALUES (N'HD001_HSNH23240018', CAST(N'2024-12-02T00:00:00.000' AS DateTime), N'HD001', N'HSNH23240018', 500000.0000, N'ND003')
INSERT [dbo].[ThamGiaNgoaiKhoa] ([MaTTHD], [NgayDK], [MaHD], [MaHS], [TienNhan], [MaND]) VALUES (N'HD001_HSNH23240019', CAST(N'2024-12-02T00:00:00.000' AS DateTime), N'HD001', N'HSNH23240019', 500000.0000, N'ND003')
INSERT [dbo].[ThamGiaNgoaiKhoa] ([MaTTHD], [NgayDK], [MaHD], [MaHS], [TienNhan], [MaND]) VALUES (N'HD001_HSNH23240022', CAST(N'2024-12-02T00:00:00.000' AS DateTime), N'HD001', N'HSNH23240022', 500000.0000, N'ND003')
INSERT [dbo].[ThamGiaNgoaiKhoa] ([MaTTHD], [NgayDK], [MaHD], [MaHS], [TienNhan], [MaND]) VALUES (N'HD001_HSNH23240025', CAST(N'2024-12-02T00:00:00.000' AS DateTime), N'HD001', N'HSNH23240025', 500000.0000, N'ND003')
INSERT [dbo].[ThamGiaNgoaiKhoa] ([MaTTHD], [NgayDK], [MaHD], [MaHS], [TienNhan], [MaND]) VALUES (N'HD001_HSNH23240026', CAST(N'2024-12-02T00:00:00.000' AS DateTime), N'HD001', N'HSNH23240026', 500000.0000, N'ND003')
INSERT [dbo].[ThamGiaNgoaiKhoa] ([MaTTHD], [NgayDK], [MaHD], [MaHS], [TienNhan], [MaND]) VALUES (N'HD001_HSNH23240027', CAST(N'2024-12-02T00:00:00.000' AS DateTime), N'HD001', N'HSNH23240027', 500000.0000, N'ND003')
INSERT [dbo].[ThamGiaNgoaiKhoa] ([MaTTHD], [NgayDK], [MaHD], [MaHS], [TienNhan], [MaND]) VALUES (N'HD001_HSNH23240028', CAST(N'2024-12-02T00:00:00.000' AS DateTime), N'HD001', N'HSNH23240028', 500000.0000, N'ND003')
INSERT [dbo].[ThamGiaNgoaiKhoa] ([MaTTHD], [NgayDK], [MaHD], [MaHS], [TienNhan], [MaND]) VALUES (N'HD001_HSNH23240031', CAST(N'2024-12-02T00:00:00.000' AS DateTime), N'HD001', N'HSNH23240031', 500000.0000, N'ND003')
INSERT [dbo].[ThamGiaNgoaiKhoa] ([MaTTHD], [NgayDK], [MaHD], [MaHS], [TienNhan], [MaND]) VALUES (N'HD001_HSNH23240032', CAST(N'2024-12-02T00:00:00.000' AS DateTime), N'HD001', N'HSNH23240032', 500000.0000, N'ND003')
INSERT [dbo].[ThamGiaNgoaiKhoa] ([MaTTHD], [NgayDK], [MaHD], [MaHS], [TienNhan], [MaND]) VALUES (N'HD001_HSNH23240033', CAST(N'2024-12-02T00:00:00.000' AS DateTime), N'HD001', N'HSNH23240033', 500000.0000, N'ND003')
INSERT [dbo].[ThamGiaNgoaiKhoa] ([MaTTHD], [NgayDK], [MaHD], [MaHS], [TienNhan], [MaND]) VALUES (N'HD001_HSNH23240036', CAST(N'2024-12-02T00:00:00.000' AS DateTime), N'HD001', N'HSNH23240036', 500000.0000, N'ND003')
INSERT [dbo].[ThamGiaNgoaiKhoa] ([MaTTHD], [NgayDK], [MaHD], [MaHS], [TienNhan], [MaND]) VALUES (N'HD001_HSNH23240037', CAST(N'2024-12-02T00:00:00.000' AS DateTime), N'HD001', N'HSNH23240037', 500000.0000, N'ND003')
INSERT [dbo].[ThamGiaNgoaiKhoa] ([MaTTHD], [NgayDK], [MaHD], [MaHS], [TienNhan], [MaND]) VALUES (N'HD001_HSNH23240038', CAST(N'2024-12-02T00:00:00.000' AS DateTime), N'HD001', N'HSNH23240038', 500000.0000, N'ND003')
INSERT [dbo].[ThamGiaNgoaiKhoa] ([MaTTHD], [NgayDK], [MaHD], [MaHS], [TienNhan], [MaND]) VALUES (N'HD003_HSNH23240011', CAST(N'2024-12-02T00:00:00.000' AS DateTime), N'HD003', N'HSNH23240011', 500000.0000, N'ND003')
INSERT [dbo].[ThamGiaNgoaiKhoa] ([MaTTHD], [NgayDK], [MaHD], [MaHS], [TienNhan], [MaND]) VALUES (N'HD003_HSNH23240012', CAST(N'2024-12-02T00:00:00.000' AS DateTime), N'HD003', N'HSNH23240012', 500000.0000, N'ND003')
INSERT [dbo].[ThamGiaNgoaiKhoa] ([MaTTHD], [NgayDK], [MaHD], [MaHS], [TienNhan], [MaND]) VALUES (N'HD003_HSNH23240013', CAST(N'2024-12-02T00:00:00.000' AS DateTime), N'HD003', N'HSNH23240013', 350000.0000, N'ND003')
INSERT [dbo].[ThamGiaNgoaiKhoa] ([MaTTHD], [NgayDK], [MaHD], [MaHS], [TienNhan], [MaND]) VALUES (N'HD003_HSNH23240014', CAST(N'2024-12-02T00:00:00.000' AS DateTime), N'HD003', N'HSNH23240014', 350000.0000, N'ND003')
GO
ALTER TABLE [dbo].[CTPhieuHocPhi]  WITH CHECK ADD  CONSTRAINT [FK_CTPHIEUHOCPHI_KHOANTHU] FOREIGN KEY([MaKhoanThu])
REFERENCES [dbo].[KhoanThu] ([MaKhoanThu])
GO
ALTER TABLE [dbo].[CTPhieuHocPhi] CHECK CONSTRAINT [FK_CTPHIEUHOCPHI_KHOANTHU]
GO
ALTER TABLE [dbo].[CTPhieuHocPhi]  WITH CHECK ADD  CONSTRAINT [FK_CTPHIEUHOCPHI_PHIEUHOCPHI] FOREIGN KEY([MaPhieuHP])
REFERENCES [dbo].[PhieuHocPhi] ([MaPhieuHP])
GO
ALTER TABLE [dbo].[CTPhieuHocPhi] CHECK CONSTRAINT [FK_CTPHIEUHOCPHI_PHIEUHOCPHI]
GO
ALTER TABLE [dbo].[DanhGiaThang]  WITH CHECK ADD  CONSTRAINT [FK_DanhGiaThang_PhanLop] FOREIGN KEY([MaHS], [MaLop])
REFERENCES [dbo].[PhanLop] ([MaHS], [MaLop])
GO
ALTER TABLE [dbo].[DanhGiaThang] CHECK CONSTRAINT [FK_DanhGiaThang_PhanLop]
GO
ALTER TABLE [dbo].[DanhGiaTuan]  WITH CHECK ADD  CONSTRAINT [FK_DanhGiaTuan_PhanLop] FOREIGN KEY([MaHS], [MaLop])
REFERENCES [dbo].[PhanLop] ([MaHS], [MaLop])
GO
ALTER TABLE [dbo].[DanhGiaTuan] CHECK CONSTRAINT [FK_DanhGiaTuan_PhanLop]
GO
ALTER TABLE [dbo].[DiemDanh]  WITH CHECK ADD  CONSTRAINT [FK_DiemDanh_PhanLop] FOREIGN KEY([MaHS], [MaLop])
REFERENCES [dbo].[PhanLop] ([MaHS], [MaLop])
GO
ALTER TABLE [dbo].[DiemDanh] CHECK CONSTRAINT [FK_DiemDanh_PhanLop]
GO
ALTER TABLE [dbo].[GiaoVien]  WITH CHECK ADD  CONSTRAINT [FK_GiaoVien_NguoiDung1] FOREIGN KEY([MaGV])
REFERENCES [dbo].[NguoiDung] ([MaND])
GO
ALTER TABLE [dbo].[GiaoVien] CHECK CONSTRAINT [FK_GiaoVien_NguoiDung1]
GO
ALTER TABLE [dbo].[HoatDongNgoaiKhoa]  WITH CHECK ADD  CONSTRAINT [FK_HoatDongNgoaiKhoa_NamHoc] FOREIGN KEY([MaNamHoc])
REFERENCES [dbo].[NamHoc] ([MaNamHoc])
GO
ALTER TABLE [dbo].[HoatDongNgoaiKhoa] CHECK CONSTRAINT [FK_HoatDongNgoaiKhoa_NamHoc]
GO
ALTER TABLE [dbo].[HocSinh]  WITH CHECK ADD  CONSTRAINT [FK_HocSinh_PhuHuynh] FOREIGN KEY([MaPH1])
REFERENCES [dbo].[PhuHuynh] ([MaPH])
GO
ALTER TABLE [dbo].[HocSinh] CHECK CONSTRAINT [FK_HocSinh_PhuHuynh]
GO
ALTER TABLE [dbo].[HocSinh]  WITH CHECK ADD  CONSTRAINT [FK_HocSinh_PhuHuynh1] FOREIGN KEY([MaPH2])
REFERENCES [dbo].[PhuHuynh] ([MaPH])
GO
ALTER TABLE [dbo].[HocSinh] CHECK CONSTRAINT [FK_HocSinh_PhuHuynh1]
GO
ALTER TABLE [dbo].[HoSoHocSinh]  WITH CHECK ADD  CONSTRAINT [FK_HoSoHocSinh_HocSinh] FOREIGN KEY([MaHS])
REFERENCES [dbo].[HocSinh] ([MaHS])
GO
ALTER TABLE [dbo].[HoSoHocSinh] CHECK CONSTRAINT [FK_HoSoHocSinh_HocSinh]
GO
ALTER TABLE [dbo].[KeHoach]  WITH CHECK ADD  CONSTRAINT [FK_KeHoach_KhoiLop] FOREIGN KEY([MaKhoi])
REFERENCES [dbo].[KhoiLop] ([MaKhoi])
GO
ALTER TABLE [dbo].[KeHoach] CHECK CONSTRAINT [FK_KeHoach_KhoiLop]
GO
ALTER TABLE [dbo].[KeHoach]  WITH CHECK ADD  CONSTRAINT [FK_KeHoach_NamHoc] FOREIGN KEY([MaNamHoc])
REFERENCES [dbo].[NamHoc] ([MaNamHoc])
GO
ALTER TABLE [dbo].[KeHoach] CHECK CONSTRAINT [FK_KeHoach_NamHoc]
GO
ALTER TABLE [dbo].[KhoanThu]  WITH CHECK ADD  CONSTRAINT [FK_KHOANTHU_NamHoc] FOREIGN KEY([MaNamHoc])
REFERENCES [dbo].[NamHoc] ([MaNamHoc])
GO
ALTER TABLE [dbo].[KhoanThu] CHECK CONSTRAINT [FK_KHOANTHU_NamHoc]
GO
ALTER TABLE [dbo].[LopHoc]  WITH CHECK ADD  CONSTRAINT [FK_LopHoc_KeHoach] FOREIGN KEY([MaNamHoc], [MaKhoi])
REFERENCES [dbo].[KeHoach] ([MaNamHoc], [MaKhoi])
GO
ALTER TABLE [dbo].[LopHoc] CHECK CONSTRAINT [FK_LopHoc_KeHoach]
GO
ALTER TABLE [dbo].[LopHoc]  WITH CHECK ADD  CONSTRAINT [FK_LopHoc_PhongHoc] FOREIGN KEY([MaPhong])
REFERENCES [dbo].[PhongHoc] ([MaPhong])
GO
ALTER TABLE [dbo].[LopHoc] CHECK CONSTRAINT [FK_LopHoc_PhongHoc]
GO
ALTER TABLE [dbo].[NguoiDung_NhomNguoiDung]  WITH CHECK ADD  CONSTRAINT [FK_NguoiDung_NhomNguoiDung_NguoiDung] FOREIGN KEY([MaND])
REFERENCES [dbo].[NguoiDung] ([MaND])
GO
ALTER TABLE [dbo].[NguoiDung_NhomNguoiDung] CHECK CONSTRAINT [FK_NguoiDung_NhomNguoiDung_NguoiDung]
GO
ALTER TABLE [dbo].[NguoiDung_NhomNguoiDung]  WITH CHECK ADD  CONSTRAINT [FK_NguoiDung_NhomNguoiDung_NhomNguoiDung] FOREIGN KEY([MaNhomNguoiDung])
REFERENCES [dbo].[NhomNguoiDung] ([MaNhom])
GO
ALTER TABLE [dbo].[NguoiDung_NhomNguoiDung] CHECK CONSTRAINT [FK_NguoiDung_NhomNguoiDung_NhomNguoiDung]
GO
ALTER TABLE [dbo].[PhanCong]  WITH CHECK ADD  CONSTRAINT [FK_PhanCong_GiaoVien] FOREIGN KEY([MaGV])
REFERENCES [dbo].[GiaoVien] ([MaGV])
GO
ALTER TABLE [dbo].[PhanCong] CHECK CONSTRAINT [FK_PhanCong_GiaoVien]
GO
ALTER TABLE [dbo].[PhanCong]  WITH CHECK ADD  CONSTRAINT [FK_PhanCong_LopHoc] FOREIGN KEY([MaLop])
REFERENCES [dbo].[LopHoc] ([MaLop])
GO
ALTER TABLE [dbo].[PhanCong] CHECK CONSTRAINT [FK_PhanCong_LopHoc]
GO
ALTER TABLE [dbo].[PhanLop]  WITH CHECK ADD  CONSTRAINT [FK_PhanLop_HocSinh] FOREIGN KEY([MaHS])
REFERENCES [dbo].[HocSinh] ([MaHS])
GO
ALTER TABLE [dbo].[PhanLop] CHECK CONSTRAINT [FK_PhanLop_HocSinh]
GO
ALTER TABLE [dbo].[PhanLop]  WITH CHECK ADD  CONSTRAINT [FK_PhanLop_LopHoc] FOREIGN KEY([MaLop])
REFERENCES [dbo].[LopHoc] ([MaLop])
GO
ALTER TABLE [dbo].[PhanLop] CHECK CONSTRAINT [FK_PhanLop_LopHoc]
GO
ALTER TABLE [dbo].[PhanQuyen]  WITH CHECK ADD  CONSTRAINT [FK_PhanQuyen_DMManHinh] FOREIGN KEY([MaMH])
REFERENCES [dbo].[DMManHinh] ([MaMH])
GO
ALTER TABLE [dbo].[PhanQuyen] CHECK CONSTRAINT [FK_PhanQuyen_DMManHinh]
GO
ALTER TABLE [dbo].[PhanQuyen]  WITH CHECK ADD  CONSTRAINT [FK_PhanQuyen_NhomNguoiDung] FOREIGN KEY([MaNhom])
REFERENCES [dbo].[NhomNguoiDung] ([MaNhom])
GO
ALTER TABLE [dbo].[PhanQuyen] CHECK CONSTRAINT [FK_PhanQuyen_NhomNguoiDung]
GO
ALTER TABLE [dbo].[PhieuHocPhi]  WITH CHECK ADD  CONSTRAINT [FK_PhieuHocPhi_NguoiDung] FOREIGN KEY([MaND])
REFERENCES [dbo].[NguoiDung] ([MaND])
GO
ALTER TABLE [dbo].[PhieuHocPhi] CHECK CONSTRAINT [FK_PhieuHocPhi_NguoiDung]
GO
ALTER TABLE [dbo].[PhieuHocPhi]  WITH CHECK ADD  CONSTRAINT [FK_PHIEUHOCPHI_PhanLop] FOREIGN KEY([MaHS], [MaLop])
REFERENCES [dbo].[PhanLop] ([MaHS], [MaLop])
GO
ALTER TABLE [dbo].[PhieuHocPhi] CHECK CONSTRAINT [FK_PHIEUHOCPHI_PhanLop]
GO
ALTER TABLE [dbo].[ThamGiaNgoaiKhoa]  WITH CHECK ADD  CONSTRAINT [FK_ThamGiaNgoaiKhoa_HoatDongNgoaiKhoa] FOREIGN KEY([MaHD])
REFERENCES [dbo].[HoatDongNgoaiKhoa] ([MaHD])
GO
ALTER TABLE [dbo].[ThamGiaNgoaiKhoa] CHECK CONSTRAINT [FK_ThamGiaNgoaiKhoa_HoatDongNgoaiKhoa]
GO
ALTER TABLE [dbo].[ThamGiaNgoaiKhoa]  WITH CHECK ADD  CONSTRAINT [FK_ThamGiaNgoaiKhoa_HocSinh] FOREIGN KEY([MaHS])
REFERENCES [dbo].[HocSinh] ([MaHS])
GO
ALTER TABLE [dbo].[ThamGiaNgoaiKhoa] CHECK CONSTRAINT [FK_ThamGiaNgoaiKhoa_HocSinh]
GO
ALTER TABLE [dbo].[ThamGiaNgoaiKhoa]  WITH CHECK ADD  CONSTRAINT [FK_ThamGiaNgoaiKhoa_NguoiDung] FOREIGN KEY([MaND])
REFERENCES [dbo].[NguoiDung] ([MaND])
GO
ALTER TABLE [dbo].[ThamGiaNgoaiKhoa] CHECK CONSTRAINT [FK_ThamGiaNgoaiKhoa_NguoiDung]
GO
