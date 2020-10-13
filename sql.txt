Create Database QuanLyBanMyPham

use QuanLyBanMyPham
--tạo bảng loại mỹ phẩm
Create table tblLoaiMyPham(
	iMaLoaiMyPham int identity(1,1) Constraint PK_LoaiMyPham Primary Key,
	sTenLoaiMyPham nvarchar(50)
);	
--thêm dữ liệu bảng loại mỹ phẩm
INSERT into tblLoaiMyPham(sTenLoaiMyPham) values(N'Kem dưỡng da');
	Insert into tblLoaiMyPham(sTenLoaiMyPham) values(N'Sữa rửa mặt');
	
--tạo bảng hãng mỹ phẩm
Create table tblHangMyPham(
	iHangMyPham int identity(1,1) Constraint PK_HangMyPham Primary Key,
	sTenHang nvarchar(30),
	sDiaChi nvarchar(50)
);

--thêm dữ liệu bảng hãng mỹ phẩm
	Insert into tblHangMyPham(sTenHang,sDiaChi) values(N'Innisfree',N'Việt Nam');
	Insert into tblHangMyPham(sTenHang,sDiaChi) values(N'Perfect Whip',N'Hà Nội');
	Insert into tblHangMyPham(sTenHang,sDiaChi) values(N'Access',N'Hà Nội');
	Insert into tblHangMyPham(sTenHang,sDiaChi) values(N'Nivia Men',N'Hà Nội');
	Insert into tblHangMyPham(sTenHang,sDiaChi) values(N'Oxy',N'Hà Nội');
	Insert into tblHangMyPham(sTenHang,sDiaChi) values(N'NovAvg Men',N'Hà Nội');
--tạo bảng my pham

Create table tblMyPham(
	iID int identity(1,1) Constraint PK_MatHang Primary Key,
	sTenMyPham nvarchar(30),
	fGia float,
	iMaLoaiMyPham int Constraint FK_Giay_LoaiGiay Foreign Key References tblLoaiMyPham(iMaLoaiMyPham),
	iHangMyPham int Constraint FK_Giay_HangGiay Foreign Key References tblHangMyPham(iHangMyPham),
	bGioiTinh bit,
	sMoTa ntext,
	sLinkImg ntext
);
--thêm dữ liệu bảng mỹ phẩm
	Insert into tblMyPham(sTenMyPham,fGia,iMaLoaiMyPham,iHangMyPham,bGioiTinh,sMoTa,sLinkImg) 
		values(N'Innisfree',1500000,1,1,1,N'Cleanser ', N'4.png'),
			(N'Innisfree men',75000,1,1,1,N'Sach nhờn hết mụn', N'3.png'),
			(N'Ances',75000,1,1,1,N'Trị mụn dưỡng da', N'33.png'),
			(N'Perfect Whip',75000,2,2,0,N'Nâng tone da sạch mụn', N'1.png'),
			(N'NovAvg Men',75000,1,2,0,N'dưỡng ẩm ', N'22.png'),
			(N'Nivia Men',75000,1,1,0,N'Sữa rửa mặt sạch sâu', N'11.png'),
			(N'Access',75000,1,1,1,N'Trị mụn dưỡng da', N'2.png'),
			(N'Oxy Men',75000,1,1,0,N'Sữa rửa mặt sạch sâu', N'66.png');
--tạo bảng chi tiết my pham
Create table tblMyPham_ChiTiet(
	iSTT int identity(1,1),
	iID int Constraint FK_MyPhamChiTiet_MyPham Foreign Key References tblMyPham(iID),
	iSize int Constraint CheckSize Check(iSize>=250 and iSize <=500),
	iSoLuong int Constraint CheckSlg Check(iSoLuong>=0),
	Constraint PK_MyPhamChiTiet Primary Key(iID, iSize)
);
--thêm dữ liệu bảng chi tiết giày
Insert into tblMyPham_ChiTiet(iID, iSize, iSoLuong) values(1,250,55),(1,360,22),(1,380,69)
Insert into tblMyPham_ChiTiet(iID, iSize, iSoLuong) values(1,370,55),(1,390,50),(1,400,50),(1,410,50),(1,430,50),(1,440,50)
Insert into tblMyPham_ChiTiet(iID, iSize, iSoLuong) values(2,360,50),(2,370,50),(2,380,50),(2,390,50),(2,400,50),(2,410,50),(2,420,50),(2,430,50),(2,440,50),
(3,360,50),(3,370,50),(3,380,50),(3,390,50),(3,400,50),(3,410,50),(3,420,50),(3,430,50),(3,440,50),
(4,360,50),(4,370,50),(4,380,50),(4,390,50),(4,400,50),(4,410,50),(4,420,50),(4,430,50),(4,440,50),
(5,360,50),(5,370,50),(5,380,50),(7,390,50),(7,400,50),(7,410,50),(7,420,50),(7,430,50),(7,440,50),
(6,360,50),(6,370,50),(6,380,50),(8,390,50),(8,400,50),(8,410,50),(8,420,50),(8,430,50),(8,440,50)

--tạo dữ liệu bảng user
Create table tblUser(
	iID int identity(1,1) Constraint PK_User Primary Key,
	sUsername nvarchar(15),
	sPassword nvarchar(30),
	sTenKH nvarchar(50),
	sDiaChi nvarchar(50),
	sSDT nvarchar(12)
);
--thêm ràng buộc phải là duy nhất cho sUsername
Alter table tblUser
	Add Constraint UQ_Username Unique(sUsername)
--thêm dữ liệu bảng tblUser
	INSERT into tblUser (sUsername,sPassword,sTenKH,sDiaChi,sSDT) values('hahang','hahang',N'Hà Thị Hằng',N'Hà Nội','0973734495')
	Insert into tblUser (sUsername,sPassword,sTenKH,sDiaChi,sSDT) values('phamquynh','phamquynh',N'Phạm Thị Quỳnh',N'BN','016323456789')
--tạo bảng hóa đơn
Create table tblHoaDon(
	iMaHD int identity(1,1) Constraint PK_HD Primary Key,
	dNgayBan Datetime Constraint CheckDate Check (dNgayBan<=getDate()),
	iMaKH int Constraint FK_HD_KH Foreign Key References tblUser(iID),
	iThanhTien int
);

--tạo bảng chi tiết hóa đơn
CREATE table tblChiTietHoaDon(
	iMaHD int Constraint FK_CTHD_HD Foreign Key References tblHoaDon(iMaHD) NOT NULL,
	iID INT NOT NULL,
	iSize int NOT null,
	iSoLuong int Constraint CheckSoLuong Check(iSoLuong >0),
	fGia int,
	Constraint FK_CTHD_MyPhamCHITIET Foreign Key (iID, iSize) References tblMyPham_ChiTiet(iID, iSize),
	CONSTRAINT PK_CTHD PRIMARY KEY (iMaHD,iID,iSize) 
);
GO


--Thủ tục tìm my pham theo id 
CREATE Proc XemTTMyPham @id int
as
begin 
	Select tblMyPham.iID, tblMyPham.sTenMyPham, tblMyPham.fGia, tblLoaiMyPham.sTenLoaiMyPham, tblHangMyPham.sTenHang, tblMyPham.bGioiTinh, tblMyPham.sMoTa, tblMyPham.sLinkImg
		from tblMyPham, tblHangMyPham, tblLoaiMyPham
		where tblMyPham.iID = @id and tblMyPham.iMaLoaiMyPham = tblLoaiMyPham.iMaLoaiMyPham and tblMyPham.iHangMyPham = tblHangMyPham.iHangMyPham
end

XemTTMyPham 5

--Lọc ra loại my phẩm với bGioitinh: nam
Select DISTINCT tblMyPham.iMaLoaiMyPham, tblLoaiMyPham.sTenLoaiMyPham from tblMyPham, tblLoaiMyPham
 where tblMyPham.iMaLoaiMyPham = tblLoaiMyPham.iMaLoaiMyPham and tblMyPham.bGioiTinh=1
GO

--Lọc ra loại mỹ phẩm của Nam/Nữ theo giới tính truyền vào
Create Proc GetLoaiMyPham @bGioiTinh bit 
as Select DISTINCT tblMyPham.iMaLoaiMyPham, tblLoaiMyPham.sTenLoaiMyPham 
FROM tblMyPham, tblLoaiMyPham 
WHERE tblMyPham.iMaLoaiMyPham = tblLoaiMyPham.iMaLoaiMyPham and tblMyPham.bGioiTinh= @bGioiTinh
go


--Thủ tục xác thực đăng nhập: trả về bản ghi nếu đúng
Create Proc XacThucDangNhap @sUserName nvarchar(15), @sPass nvarchar(30)
as
	Begin
		Select tblUser.sTenKH from tblUser where tblUser.sUsername = @sUserName and tblUser.sPassword = @sPass
	END
    
--test đăng nhập
GO

EXEC XacThucDangNhap hahang,hahang;

GO

--Thủ tục đăng ký khách hàng (User)
Create Proc DangKyUser @sUserName nvarchar(15), @sPass nvarchar(30),@sTenKH nvarchar(50), @sDiaChi nvarchar(50),@sSDT nvarchar(12) as
Begin
	Insert into tblUser(sUsername, sPassword, sTenKH,sDiaChi, sSDT)
	Values(@sUserName, @sPass, @sTenKH, @sDiaChi, @sSDT)
END
--test đăng ký
GO

DangKyUser N'hahang1998','12345678',N'Hà Hằng',N'Hà Nội','0165123456'
GO

-- lấy toàn bộ danh sách mỹ phẩm nếu không có tham số truyền vào
-- lấy toàn bộ danh sách mỹ phẩm theo giới tính nếu có tham số giới tính truyền vào
-- ,....
 
create Proc GetSanPham @bGioiTinh bit = null, @iMaLoaiMyPham int = null, @iHangMyPham int = null, @min float = 0, @max float = 0 
AS
	begin
		declare @sSql as nvarchar(1000)
		declare @ParamList as nvarchar(1000)
		set @sSql = 'Select * from tblMyPham Where (1=1)' 
		if (@bGioiTinh is not null)
			set @sSql = @sSql + 'and (bGioiTinh = @bGioiTinh)'
		if (@iMaLoaiMyPham is not null)
			set @sSql = @sSql + 'and (iMaLoaiMyPham = @iMaLoaiMyPham)'
		if (@iHangMyPham is not null)
			set @sSql = @sSql + 'and (iHangMyPham = @iHangMyPham)'
		if (@max = 0) 
			set @sSql = @sSql + 'and fGia >= @min'
		if (@max != 0)
			set @sSql = @sSql + 'and fGia >=@min and fGia <= @max'
		set @ParamList = '@bGioiTinh bit,
						  @iMaLoaiMyPham int,
						  @iHangMyPham int,
						  @min float,
						  @max float';
		EXEC SP_EXECUTESQL  @sSql, 
						  @ParamList, 
						  @bGioiTinh,
						  @iMaLoaiMyPham,
						  @iHangMyPham,
						  @min,
						  @max;
	end 

	GO


---tìm kiếm mỹ phẩm theo value truyền vào
	CREATE Proc sp_TimKiem @value NVARCHAR(300)
	AS
Begin
	SELECT dbo.tblMyPham.iID,dbo.tblMyPham.sTenMyPham,dbo.tblMyPham.fGia,dbo.tblMyPham.iMaLoaiMyPham,dbo.tblMyPham.iHangMyPham
	,dbo.tblMyPham.bGioiTinh,dbo.tblMyPham.sMoTa,dbo.tblMyPham.sLinkImg
	FROM dbo.tblMyPham,dbo.tblHangMyPham,dbo.tblLoaiMyPham 
	WHERE tblMyPham.iMaLoaiMyPham=dbo.tblLoaiMyPham.iMaLoaiMyPham AND 
	tblMyPham.iHangMyPham=dbo.tblHangMyPham.iHangMyPham 
	AND dbo.tblMyPham.sTenMyPham  LIKE '%' + @value + '%' 
	OR
	(tblMyPham.iMaLoaiMyPham=dbo.tblLoaiMyPham.iMaLoaiMyPham AND 
	tblMyPham.iHangMyPham=dbo.tblHangMyPham.iHangMyPham 
	AND
	 dbo.tblHangMyPham.sTenHang  LIKE '%' + @value + '%'  )
	 OR
	 (tblMyPham.iMaLoaiMyPham=dbo.tblLoaiMyPham.iMaLoaiMyPham AND 
	tblMyPham.iHangMyPham=dbo.tblHangMyPham.iHangMyPham 
	AND
	  dbo.tblLoaiMyPham.sTenLoaiMyPham  LIKE '%' + @value + '%'  )
END
GO

sp_timKiem gg
--tạo bảng giỏ hàng
Create table tblGioHang(
	iMaGH int identity(1,1) Constraint PK_GioHang Primary Key,
	iMaKH int Constraint FK_GioHang_User Foreign Key References tblUser(iID),
	itongTien int
);
--tạo bảng chi tiết giỏ hàng


CREATE table tblChiTietGioHang(
	iMaGH int Constraint FK_CTGH_GH Foreign Key References tblGioHang(iMaGH) NOT NULL,
	iID INT NOT NULL,
	iSize int,
	iSoLuong int Constraint CheckSoLuongGH Check(iSoLuong >0),
	Constraint FK_CTGH_MYPHAMCHITIET Foreign Key (iID, iSize) References tblMyPham_ChiTiet(iID, iSize),
	Constraint PK_CTGH PRIMARY KEY (iMaGH,iID,iSize)

);
GO


--thêm dữ liệu bảng giỏ hàng
	INSERT INTO dbo.tblGioHang ( iMaKH, itongTien )VALUES  ( 1,  0)
	INSERT INTO dbo.tblGioHang ( iMaKH, itongTien )VALUES  ( 2,  0)
	INSERT INTO dbo.tblGioHang ( iMaKH, itongTien )VALUES  ( 3,  0)

---proc thêm giỏ hàng với mã khách hàng
Create Proc sp_ThemGioHang @iMaKH int
AS
BEGIN

	INSERT INTO dbo.tblGioHang
        ( iMaKH, itongTien )
VALUES  ( @iMaKH, -- iMaKH - int
          0  -- itongTien - int
 
         )


END
GO



---proc thêm chi tiết giỏ hàng theo mã giỏ hàng
CREATE Proc sp_ThemChiTietGioHang @iMaGH int,@iID int,@iSize INT,@isoluong INT
AS
BEGIN


INSERT INTO dbo.tblChiTietGioHang
        ( iMaGH, iID, iSize, iSoLuong )
VALUES  ( @iMaGH, -- iMaGH - int
          @iID, -- iID - int
          @iSize, -- iSize - int
          @isoluong -- iSoLuong - int
          )

END
GO
---triger khi 
/*
CREATE TRIGGER trg_ThemChiTietGioHang ON dbo.tblChiTietGioHang AFTER INSERT AS
BEGIN
UPDATE tblGiay_ChiTiet
SET tblGiay_ChiTiet.iSoLuong = tblGiay_ChiTiet.iSoLuong - (SELECT iSoLuong 
FROM tblChiTietGioHang 
WHERE tblGiay_ChiTiet.iID = tblChiTietGioHang.iID AND tblGiay_ChiTiet.iSize = tblChiTietGioHang.iSize )
FROM dbo.tblChiTietGioHang JOIN dbo.tblGiay_ChiTiet ON tblGiay_ChiTiet.iID = tblChiTietGioHang.iID AND tblGiay_ChiTiet.iSize = tblChiTietGioHang.iSize
END
GO
*/

GO


---proc xem chi tiết giỏ hàng theo mã giỏ hàng
CREATE Proc sp_XemChiTietGioHang @iMaGH int
AS
BEGIN
SELECT dbo.tblChiTietGioHang.iMaGH,dbo.tblChiTietGioHang.iID,
dbo.tblMyPham.sTenMyPham,dbo.tblMyPham.sLinkImg,dbo.tblMyPham.fGia,dbo.tblChiTietGioHang.iSize,dbo.tblChiTietGioHang.iSoLuong 
FROM tblChiTietGioHang,tblMyPham,tblMyPham_ChiTiet 
WHERE iMaGH = @iMaGH AND tblChiTietGioHang.iID=tblMyPham_ChiTiet.iID AND tblMyPham_ChiTiet.iID=tblMyPham.iID AND tblChiTietGioHang.iSize=tblMyPham_ChiTiet.iSize
END
GO


--Tạo bảng Admin
Create table tblAdmin(
	iID int identity(1,1) Constraint PK_Admin Primary Key,
	sUsername nvarchar(15) Constraint UQ_Name Unique,
	sPassword nvarchar(30),
	sTenAdmin nvarchar(50)
);
Insert into tblAdmin (sUsername, sPassword, sTenAdmin) values(N'hahang',N'hahang',N'admin')
Insert into tblAdmin (sUsername, sPassword, sTenAdmin) values(N'phamquynh',N'phamquynh',N'quynh Admin')

--Proc Xac Thuc dang nHap Admin

Create Proc XacThucAdmin @sUsername nvarchar(15), @sPassword nvarchar(30) as
Begin 
	Select sTenAdmin from tblAdmin where sUsername = @sUsername and sPassword = @sPassword
End
--Test dang nhap
XacThucAdmin hahang,hahang

SELECT dbo.tblAdmin.sTenAdmin FROM dbo.tblAdmin WHERE sUsername = 'hahang'


--Proc Lấy TT giày cho thằng admin
CREATE Proc GetSanPhamAdmin as begin
Select tblMyPham.iID, tblMyPham.sTenMyPham, tblMyPham.fGia,tblMyPham.iMaLoaiMyPham, 
		tblLoaiMyPham.sTenLoaiMyPham,tblMyPham.iHangMyPham, tblHangMyPham.sTenHang, tblMyPham.bGioiTinh, tblMyPham.sMoTa, tblMyPham.sLinkImg
		from tblMyPham, tblHangMyPham, tblLoaiMyPham
		where tblMyPham.iMaLoaiMyPham = tblLoaiMyPham.iMaLoaiMyPham and tblMyPham.iHangMyPham = tblHangMyPham.iHangMyPham
end


--Proc Update sản phẩm cho thằng admin

Create Proc UpdateSanPhamAdmin @iID int, @sTenMyPham nvarchar(30), @fGia float, 
			@iMaLoaiMyPham int, @iHangMyPham int, @bGioiTinh bit, @sMoTa nvarchar(500), @sLinkImg nvarchar(500)
as begin
	Update tblMyPham
	set sTenMyPham = @sTenMyPham, 
		fGia = @fGia,
		iMaLoaiMyPham = @iMaLoaiMyPham,
		iHangMyPham = @iHangMyPham,
		bGioiTinh = @bGioiTinh,
		sMoTa = @sMoTa,
		sLinkImg = @sLinkImg
	where iID = @iID
end



Create Proc InsertSanPhamAdmin @sTenMyPham nvarchar(30), @fGia float, @iMaLoaiMyPham int, @iHangMyPham int, 
			@bGioiTinh bit, @sMoTa nvarchar(500), @sLinkImg nvarchar(500)
as begin
	Insert into tblMyPham(sTenMyPham,fGia,iMaLoaiMyPham,iHangMyPham,bGioiTinh,sMoTa,sLinkImg) 
	Values(@sTenMyPham, @fGia, @iMaLoaiMyPham,@iHangMyPham,@bGioiTinh,@sMoTa,@sLinkImg)
	Select @@IDENTITY as iID;

	Insert into tblMyPham_ChiTiet(iID, iSize, iSoLuong)
	values(@@IDENTITY, 360,0),
		(@@IDENTITY, 370,0),
		(@@IDENTITY, 380,0),
		(@@IDENTITY, 390,0),
		(@@IDENTITY, 400,0),
		(@@IDENTITY, 410,0),
		(@@IDENTITY, 420,0),
		(@@IDENTITY, 430,0),
		(@@IDENTITY, 440,0)
end


Create Proc SuaSoLuongSanPhamAdmin @iID int, @iSoLuong360 int, @iSoLuong370 int, @iSoLuong380 int, @iSoLuong390 int, 
@iSoLuong400 int, @iSoLuong410 int, @iSoLuong420 int, @iSoLuong430 int, @iSoLuong440 int as
begin
	Update tblMyPham_ChiTiet
	set iSoLuong = @iSoLuong360
	where iID = @iID and iSize = 360;
	Update tblMyPham_ChiTiet
	set iSoLuong = @iSoLuong370
	where iID = @iID and iSize = 370;
	Update tblMyPham_ChiTiet
	set iSoLuong = @iSoLuong380
	where iID = @iID and iSize = 380;
	Update tblMyPham_ChiTiet
	set iSoLuong = @iSoLuong390
	where iID = @iID and iSize = 390;
	Update tblMyPham_ChiTiet
	set iSoLuong = @iSoLuong400
	where iID = @iID and iSize = 400;
	Update tblMyPham_ChiTiet
	set iSoLuong = @iSoLuong410
	where iID = @iID and iSize = 410;
	Update tblMyPham_ChiTiet
	set iSoLuong = @iSoLuong420
	where iID = @iID and iSize = 420;
	Update tblMyPham_ChiTiet
	set iSoLuong = @iSoLuong430
	where iID = @iID and iSize = 430;
	Update tblMyPham_ChiTiet
	set iSoLuong = @iSoLuong440
	where iID = @iID and iSize = 440;
end

SuaSoLuongSanPhamAdmin 1,10,50,50,50,50,50,50,50,51

--Proc Lấy Loại my pham
Create Proc GetLoaiMyPhamAdmin @iMaLoaiMyPham int = 0 as 
Begin
 if @iMaLoaiMyPham = 0
	Select * from tblLoaiMyPham 
 else Select * from tblLoaiMyPham where iMaLoaiMyPham = @iMaLoaiMyPham
end
--Proc update loại MyPham
Create Proc UpdateLoaiMyPhamAdmin @iMaLoaiMyPham int, @sTenLoaiMyPham nvarchar(50) as begin 
	Update tblLoaiMyPham set sTenLoaiMyPham = @sTenLoaiMyPham where tblLoaiMyPham.iMaLoaiMyPham = @iMaLoaiMyPham
end

--Proc insert loại MyPham

Create Proc InsertLoaiMyPhamAdmin @sTenLoaiMyPham nvarchar(50) as begin 
	Insert into tblLoaiMyPham (sTenLoaiMyPham) values(@sTenLoaiMyPham);
end


--Proc Lấy tblHangMyPham
Create Proc GetHangMyPhamAdmin @iHangMyPham int = 0 as 
Begin
 if @iHangMyPham = 0
	Select * from tblHangMyPham 
 else Select * from tblHangMyPham where iHangMyPham = @iHangMyPham
end

GetHangMyPhamAdmin 1

--Proc Update tblHangMyPham
Create Proc UpdateHangMyPhamAdmin @iHangMyPham int, @sTenHang nvarchar(50), @sDiaChi nvarchar(50) as 
begin
	Update tblHangMyPham set sTenHang = @sTenHang, sDiaChi = @sDiaChi where iHangMyPham = @iHangMyPham
end

--Proc Insert HAngMyPham
Create Proc InsertHangMyPhamAdmin @sTenHang nvarchar(50), @sDiaChi nvarchar(50) as 
begin
	Insert into tblHangMyPham(sTenHang, sDiaChi) values(@sTenHang, @sDiaChi)
end

--Proc Lay Danh sach khach hàng
Create Proc GetKhachHangAdmin @iID int = 0 as Begin
	if @iID = 0
		Select * from tblUser
	else
		Select * from tblUser where iID = @iID
End


--PROC UPDATE TT KHÁCH HÀNG
Create Proc UpdateKhachHangAdmin @iID int, @sUsername nvarchar(15), @sTenKH nvarchar(50),
								@sDiaChi nvarchar(50), @sSDT nvarchar(12) as
Begin
	Update tblUser set sUsername = @sUsername, sTenKH = @sTenKH, sDiaChi = @sDiaChi, sSDT = @sSDT
	where iID = @iID
ENd

Select top 10 * from tblMyPham where bGioiTinh = 1 order by iID DESC

SELECT * FROM dbo.tblChiTietGioHang WHERE iMaGH =1

--DELETE FROM dbo.tblChiTietGioHang WHERE iMaGH =1 AND iID = 1 AND iSize = 36

SELECT * FROM dbo.tblUser WHERE sUsername =N'hahang'

--UPDATE dbo.tblChiTietGioHang SET iSoLuong = 3 WHERE iMaGH = 1 AND iID =1 AND iSize =1

--INSERT INTO dbo.tblHoaDon( dNgayBan, iMaKH, iThanhTien )VALUES  ( GETDATE(),0,0)



--SELECT top 1 iMaHD FROM dbo.tblHoaDon WHERE iMaKH = 1 order by dNgayBan DESC 
--INSERT INTO dbo.tblChiTietHoaDon( iMaHD, iID, iSize, iSoLuong, fGia )VALUES  ( 0, 0,0,0, 0 )
SELECT * FROM dbo.tblHoaDon
--DELETE dbo.tblChiTietGioHang WHERE iMaGH =1

SELECT iMaGH FROM dbo.tblGioHang WHERE iMaKH = 1


--Tạo thêm cột địa chỉ nhận cho hóa đơn
Alter table tblHoaDon add sDiaChi nvarchar(100)

--Trigger giảm số lượng hàng khi thanh toán
Create trigger TG_GiamSoLuongHang on tblChiTietHoaDon for insert,update
as Begin
	Declare @iIDMyPham int, @iSize int, @iSoLuong int, @HangTon int
	Set @iIDMyPham = (Select iID from inserted)
	set @iSize = (Select iSize from inserted)
	Set @iSoLuong = (Select iSoLuong from inserted)
	Set @HangTon = (Select tblMyPham_ChiTiet.iSoLuong from tblMyPham_ChiTiet where tblMyPham_ChiTiet.iSoLuong = @iSoLuong and tblMyPham_ChiTiet.iSize = @iSize )
		if(@iSoLuong>@HangTon)
			begin
				Rollback tran
			end
		else
			begin
				Update tblMyPham_ChiTiet set tblMyPham_ChiTiet.iSoLuong = tblMyPham_ChiTiet.iSoLuong - @iSoLuong where tblMyPham_ChiTiet.iID = @iIDMyPham and 
				tblMyPham_ChiTiet.iSize = @iSize
			end
End




--Proc GEt thông tin hóa đơn
create Proc GetHoaDonAdmin @iMaHD int = 0 as Begin
	if @iMaHD = 0
		Select iMaHD, dNgayBan, tblUser.sTenKH, iThanhTien, tblHoaDon.sDiaChi from tblHoaDon, tblUser where tblHoaDon.iMaKH = tblUser.iID
	else
		Select iMaHD, dNgayBan, tblUser.sTenKH, iThanhTien, tblHoaDon.sDiaChi from tblHoaDon, tblUser where tblHoaDon.iMaKH = tblUser.iID and iMaHD = @iMaHD
End


GetHoaDonAdmin 2

--Proc upadte  hóa đơn

Create Proc UpdateHoaDonAdmin @iMaHD int, @sDiaChi nvarchar(50) as
Begin
	Update tblHoaDon set sDiaChi= @sDiaChi
	where iMaHD = @iMaHD
ENd

--Proc Lấy chi tiết hóa đơn
create Proc GetCTHDAdmin @iMaHD int as
Begin 
	Select tblChiTietHoaDon.iMaHD, tblChiTietHoaDon.iID, tblMyPham.sTenMyPham, tblChiTietHoaDon.iSize, tblMyPham.fGia ,tblChiTietHoaDon.iSoLuong, tblMyPham.sLinkImg
	from tblChiTietHoaDon, tblMyPham where tblMyPham.iID = tblChiTietHoaDon.iID and tblChiTietHoaDon.iMaHD = @iMaHD
End

GetCTHDAdmin 1