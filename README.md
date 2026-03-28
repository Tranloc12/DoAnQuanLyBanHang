# 🛒 Hệ thống Quản lý Bán hàng (Sales Management System)

Chào mừng bạn đến với dự án **Hệ thống Quản lý Bán hàng**, một ứng dụng WinForms hiện đại được xây dựng trên nền tảng .NET 8, hướng tới sự chuyên nghiệp và ổn định trong quản lý kinh doanh.

## 🌟 Tính năng nổi bật

### 1. Dashboard Hiện đại
- **Thẻ KPI (KPI Cards)**: Tọa độ nhanh về Doanh thu hôm nay, Tổng đơn hàng, Số khách hàng và Cảnh báo sản phẩm sắp hết hạn/hết hàng.
- **Biểu đồ Doanh thu (LiveCharts)**: Trực quan hóa doanh thu 30 ngày qua bằng biểu đồ đường (Line Chart) mượt mà.
- **Thông tin nhân viên**: Hiển thị tên và quyền hạn nhân viên đang đăng nhập.

### 2. Quản lý Bán hàng (POS)
- Tạo hóa đơn bán hàng nhanh chóng.
- Tìm kiếm sản phẩm theo mã hoặc tên.
- Tính toán chiết khấu, tổng tiền tự động.
- In hóa đơn (hỗ trợ PDF).

### 3. Quản lý Danh mục & Sản phẩm
- Phân loại hàng hóa theo loại hàng, nhà cung cấp.
- Quản lý giá nhập, giá bán, tồn kho tối thiểu.
- Cảnh báo tồn kho thấp.

### 4. Quản lý Khách hàng & Nhà cung cấp
- Lưu trữ thông tin khách hàng và điểm tích lũy.
- Quản lý thông tin liên hệ nhà cung cấp.

### 5. Quản lý Kho hàng & Báo cáo
- Theo dõi lịch sử nhập xuất kho.
- Báo cáo doanh thu theo ngày, tháng, năm.
- Xuất dữ liệu báo cáo ra Excel (ClosedXML).

## 🛠️ Công nghệ sử dụng

- **Framework**: .NET 8.0 (Windows Desktop)
- **Ngôn ngữ**: C#
- **Cơ sở dữ liệu**: SQL Server (sử dụng `Microsoft.Data.SqlClient`)
- **Kiến trúc**: 3-Layer (DAL - BUS - GUI)
- **Thành phần UI**: Guna.UI2, LiveCharts (WinForms)
- **Xuất bản**: ClosedXML (Excel), QuestPDF (In ấn hóa đơn)

## 📁 Cấu trúc Thư mục

- `DoAnQuanLyBanHang.GUI`: Lớp giao diện người dùng (Forms, Dialogs).
- `DoAnQuanLyBanHang.BUS`: Lớp xử lý nghiệp vụ (Business Logic).
- `DoAnQuanLyBanHang.DAL`: Lớp truy xuất cơ sở dữ liệu (Data Access).
- `DoAnQuanLyBanHang.DTO`: Các đối tượng vận chuyển dữ liệu (Data Transfer Objects).
- `DoAnQuanLyBanHang.Utils`: Các hàm tiện ích dùng chung.

## 🚀 Hướng dấn Cài đặt & Chạy ứng dụng

1. **Yêu cầu hệ thống**:
   - Cài đặt [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0).
   - Cài đặt SQL Server (Express hoặc LocalDB).

2. **Cấu hình Cơ sở dữ liệu**:
   - Import file script SQL (nếu có) vào SQL Server.
   - Cập nhật chuỗi kết nối (Connection String) trong file `DAL/KetNoiChung.cs`.

3. **Chạy ứng dụng**:
   ```powershell
   dotnet run --project DoAnQuanLyBanHang/DoAnQuanLyBanHang.csproj
   ```

---
*Dự án được xây dựng với sự hỗ trợ của Antigravity AI Coding Assistant.*