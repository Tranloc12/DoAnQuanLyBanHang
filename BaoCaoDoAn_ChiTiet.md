# BÁO CÁO ĐỒ ÁN MÔN HỌC: XÂY DỰNG PHẦN MỀM QUẢN LÝ BÁN HÀNG

---

## Chương 1: Khảo sát hệ thống và Phân tích hệ thống

### 1.1. Mô tả hệ thống
Sự bùng nổ của công nghệ thông tin đã mang lại nhiều bước tiến vượt bậc trong việc tự động hóa và tối ưu hóa quản trị doanh nghiệp. Với các cơ sở kinh doanh, cửa hàng bán lẻ truyền thống, quản lý thủ công qua sổ sách không những tiêu tốn chi phí nhân sự mà còn dễ xảy ra sai sót, mất mát dữ liệu và khó khăn trong việc kiểm kê, báo cáo thống kê.

Xuất phát từ thực trạng đó, **Phần mềm Quản lý Bán hàng** ra đời với mục tiêu tin học hóa quy trình cốt lõi của một hệ thống bán lẻ. Hệ thống này bao quát toàn bộ vòng đời kinh doanh: từ việc số hóa danh mục hàng hóa trong kho, nhập thông tin nhà cung cấp, đến nghiệp vụ bán hàng hàng ngày (Point of Sale) và quản lý chăm sóc khách hàng.

**Mục tiêu của hệ thống:**
1. **Dễ sử dụng và hiệu quả:** Cho phép thu ngân thiết lập hóa đơn trong vài giây.
2. **Quản trị an toàn:** Phân định rõ ràng quyền của Quản trị viên (Admin) và Nhân viên (Staff).
3. **Quản trị dữ liệu nhất quán:** Từ hóa đơn, hàng hóa, đến xuất nhập tồn đều đảm bảo đồng bộ hóa tuyệt đối thông qua cơ chế tự trừ lỗi và tự động tích điểm.
4. **Hỗ trợ Ra quyết định:** Báo cáo dưới dạng số liệu trực quan, chính xác (Dashboard).

### 1.2. Mô hình hóa hệ thống

#### 1.2.1. Phân tích chức năng nghiệp vụ

**1.2.1.1. Mô hình hóa chức năng nghiệp vụ**
Theo như quy trình vận hành, hệ thống được cấu trúc bởi 4 phân hệ tính năng nghiệp vụ chính sau đây:
- **Phân hệ Hệ thống và Người dùng:**
  - Chức năng Đăng nhập.
  - Chức năng đổi/lấy lại mật khẩu.
  - Chức năng Quản lý Nhân viên (Dành riêng cho Admin): Thêm, Sửa, Xóa mềm, Đặt lại mật khẩu.
- **Phân hệ Quản lý Danh mục (Master Data):**
  - Chức năng Quản lý Cấp Nhóm sản phẩm (Category).
  - Chức năng Quản lý Nhà cung cấp phụ trách trực tiếp.
  - Chức năng Quản lý Sản phẩm (Kho hàng): Gắn kèm giá nhập, giá bán lẻ và số lượng hiện tại.
- **Phân hệ Bán hàng & Khách hàng:**
  - Chức năng Lập đơn hàng (Bán hàng POS): Xử lý toàn diện giỏ hàng, thông tin thanh toán.
  - Chức năng Quản lý Khách hàng: Phân loại theo điểm tích lũy, tra cứu lịch sử tích điểm và tổng chi tiêu.
- **Phân hệ B
**1.2.1.2. Mô hình hóa tiến trình nghiệp vụ**
*(Sinh viên tự chèn Sơ đồ Use-Case của hệ thống và các Actor (Adáo cáo Doanh thu:**
  - Xem lượng hóa đơn, số dư, và phân loại tăng trưởng (Dashboard).
min, Staff) vào đây)*
Tiến trình tổng quan của hệ thống bao gồm: 
1. `Tiến trình Khởi tạo dữ liệu`: Được thực thi bởi Admin lúc mới thiết lập cửa hàng.
2. `Tiến trình Duy trì kinh doanh`: Xảy ra mỗi khi có khách hàng tới mua. Nhân viên chỉ cần khởi chạy nghiệp vụ Bán hàng. Nếu thông tin khách hàng sai thì cập nhật; mới thì tạo mới.
3. `Tiến trình Cập nhật Tồn kho và Tích điểm`: Diễn ra ở backend (CSDL) một cách tự động, liền mạch song song với tiến trình của thu ngân.

**1.2.1.3. Đặc tả tiến trình nghiệp vụ**
**A. Đặc tả tiến trình Lập Hóa đơn (Bán hàng):**
1. **Khởi chạy:** Thu ngân (Staff) mở giao diện Bán hàng.
2. **Chọn Sản phẩm:** Thu ngân quét thông tin hoặc chọn thủ công Sản phẩm từ danh sách. Hệ thống kiểm tra số lượng tồn kho tự động. (Báo lỗi nếu vượt số lượng tồn).
3. **Cập nhật Khách hàng:** Nhập số điện thoại. Hệ thống trích xuất thông tin khách hàng, số điểm tích lũy của khách hàng đó.
4. **Lưu hóa đơn và Cập nhật Base dữ liệu:** Thu ngân xác nhận thu tiền khách. Hệ thống lập tức trừ đi lượng kho tương ứng với list sản phẩm bán, song song đó ghi log xuất kho, cộng điểm tích lũy mới và tổng chi tiêu của Khách hàng đó trên Database.

#### 1.2.2. Phân tích dữ liệu nghiệp vụ

**1.2.2.1. Mô hình hóa dữ liệu ban đầu**
Hệ thống quản lý lượng lớn những đối tượng thực thể:
- Thực thể Quản lý: **Nhân viên (Users)**
- Thực thể Lưu trữ: **Sản phẩm (Products), Nhóm (Categories), Đối tác (Suppliers)**
- Thực thể Giao dịch: **Khởi tạo Đơn, Chi tiết đơn hàng (Orders, OrderDetails), Khách hàng (Customers).**
- Lịch sử theo dõi kho: **Kho vận (InventoryLogs).**

**1.2.2.2. Chuẩn hóa dữ liệu**
Toàn bộ sơ đồ dữ liệu được thiết kế đạt dạng chuẩn 3 (3NF Normal Form):
- Không có bất kỳ cột nào chứa nhóm thuộc tính lặp lại (1NF).
- Mọi thuộc tính không khóa đều phụ thuộc toàn phần vào khóa chính (2NF).
- Không có thuộc tính không khóa nào phụ thuộc gián tiếp/bắc cầu qua thuộc tính không khóa khác. Tất cả các dữ liệu dư thừa đều được tách sang các bảng liên kết `FK`. Cụ thể: `OrderDetails` sinh ra với mục đích lưu lượng bán, trong khi thông tin Khách Hàng đặt hàng được phân rã ra ở `Customers` table thông qua khóa `CustomerID`.

**1.2.2.3. Đặc tả bảng dữ liệu (Tóm tắt sơ bộ)**
1. **Bảng Danh Mục Cơ Bản:** Lưu trữ tĩnh như Nhà cung cấp, Loại Hàng (Rất ít biến đổi).
2. **Bảng Khách Hàng & Hệ Thống:** Người dùng Admin/Staff đăng nhập bằng `UserName` + `Password`. Khách hàng tích lũy được theo cấp số chi tiêu `TotalSpent`.
3. **Bảng Xử Lý Giao dịch:** `Orders` (Phần đầu hóa đơn) liên kết 1 - Nhiều (1:N) với `OrderDetails` (Nội dung từng dòng hóa đơn). Bù lại nó cũng tạo thêm 1 log ở `InventoryLogs`.

---

## Chương 2: Thiết kế hệ thống

### 2.1. Xác định tiến trình hệ thống
#### 2.1.1. Xác định tiến trình hệ thống
Hệ thống vận hành vòng lặp thao tác Event-Driven (Hướng sự kiện WinForms).
- Mọi tiến trình từ người dùng sẽ thông quan `Lớp Tầng View (GUI)`, xác thực và kiểm chuẩn. 
- Sau đó đưa vào `Lớp Nghiệp Vụ (BUS)`. Dữ liệu di chuyển trong hệ thống thông qua các gói `DTO` truyền tải Data Model tĩnh.
- Cuối hành trình sẽ tiếp xúc `Data Access (DAL)` - Lớp truy xuất hệ cơ sở dữ liệu để Create/Read/Update/Delete (Trao đổi qua ADO.NET SQL Connection).

#### 2.1.2. Xác định bảng dữ liệu hệ thống
Lưu trữ trên SQL Server Instance nội bộ hoặc On-premise. Connect String sẽ nối thẳng tới CSDL `Quanlybanhang`. Tránh kết nối đa luồng gây chết Pool bằng cơ chế using resource giải phóng liên tục.

#### 2.1.3. Vẽ DFD hệ thống
*(Sinh viên sử dụng phần mềm Visio để vẽ DFD Mức Ngữ Cảnh, Mức 0 và Phân rã Mức 1 dựa trên các mô tả đã nêu).*

### 2.2. Thiết kế kiểm soát
#### 2.2.1. Xác định nhóm người dùng
Hệ thống sử dụng ma trận kiểm soát vai trò (RBAC - Role Based Access Control) thông qua duy nhất 1 bảng `Users` với cấp độ Enum phân 2 mức:
1. `Admin` (Giám đốc, Cửa hàng trưởng, Chủ tiệm).
2. `Staff` (Nhân sự bán thời gian, Thu ngân, Marketing đứng quầy).

#### 2.2.2. Phân định quyền hạn nhóm người dùng
- `Vòng quản trị:` `Admin` toàn quyền trong việc chi phối chức năng. Được mở ròng quyền thiết lập Users, Cài đặt lại mật khẩu cho Nhân viên khi họ lỡ đăng xuất và quên mật khẩu. Thay thế và định đoạt giá bán, giá nhập hàng hóa.
- `Vòng hoạt động:` `Staff` được rào quyền khắt khe. Chỉ nhìn thấy Danh sách Khách hàng của bộ phận để chăm sóc. Được gọi ra Form bán hàng. Giao diện Danh mục, Kho Bãi sẽ bị làm ẩn đi hoặc báo Lỗi từ chối.

### 2.3. Thiết kế cơ sở dữ liệu
#### 2.3.1. Thiết kế bảng dữ liệu phục vụ bảo mật
- **IsActive (Cờ kích hoạt xoá mềm):** Thay vì Delete dữ liệu (Sẽ dẫn đến hỏng toàn bộ Hóa đơn được tạo bởi nhân viên đó trong quá khứ - Lỗi Cascade), hệ thống chuyển cột IsActive (BIT) về giá trị 0. Nhân viên lập tức bị chặn quyền đăng nhập vào hệ thống mãi mãi nhưng lịch sử xuất sứ biên lai vẫn hiển thị hợp lệ, vẹn toàn.

#### 2.3.2. Xác định thuộc tính kiểm soát, bảng kiểm soát
`Users` là bảng kiểm soát định hình session (phiên làm việc) trên WinForms `SessionUser.CurrentUser`. 

#### 2.3.4. Xây dựng mô hình hệ thống và Đặc tả bảng dữ liệu
*(Thêm Cấu trúc ERD của SQL Schema Database vào đây)*
**1. Users (Bảng Hệ Thống)**
- `UserID` [INT] (PK Identity).
- `UserName`, `PasswordHash`, `FullName`, `Email`, `Phone` [Varchar/NVarchar].
- `Role` [Nvarchar(20)].
**2. Products (Kho Giao Dịch)**
- `ProductID` [INT].
- Liên kết khóa ngoại: `CategoryID`, `SupplierID`.
- `CostPrice`, `SellPrice` (DECIMAL): Ràng buộc số tiền không âm (>0).
- `Quantity` [INT] : Tồn lượng hiện đại.
**3. Customers (Khách hàng)**
- Có khóa nội `LoyaltyPoints` được T-SQL Trigger tự động Trigger nhồi thêm `1 Điểm` mỗi khi `FinalAmount` của 1 hóa đơn tăng thêm `>= 100,000 VND`. 

---

## Chương 3: Xây dựng hệ thống

### 3.1. Thiết kế giao diện người máy
#### 3.1.1. Thiết kế hệ thống đơn chọn
- Được định hình thành dạng thiết kế UX/UI hiện đại MDI Container (Parent). Giao diện Sidebar với hệ khung phẳng (Flat Design) kết hợp những màu sắc chủ đạo xanh thiên nhiên thân thiện với mắt. Thanh Sidebar đóng mở động tùy chỉnh theo nhu cầu không gian lập hóa đơn.

#### 3.1.2. Thiết kế giao diện nhập liệu cho danh mục
- Mọi Form danh sách đều được tối đa hóa sử dụng `DataGridView`. Header hiển thị phân chia rõ nội dung tiếng việt có dấu (`Họ Tên`, `Người Lập` ...). Dữ liệu được Binding cực nhanh và thông minh.
- Khi người dùng `Click Row` (Sự kiện Row_Enter) các Textbox hiển thị dưới GroupBox "Thông tin" sẽ tự động cập nhật khớp, giúp chỉnh sửa tốc độ không cần nhập lại nhiều lần phím. Nút Sửa, Xóa đều báo Notification Confirm an toàn. 

#### 3.1.3. Thiết kế giao diện xử lý nghiệp vụ
- **Giao diện làm việc (POS Terminal):** Thiết kế cho mục đích tối đa không gian màn hình độ phân giải tiêu chuẩn. Bố cục 2 phần Trái (View Cart DataGridView) và Phải (Input Layout).
- Thao tác giảm giá, tính tiền tự trả lời kết quả thối lại cực nhạy mà không lag luồng giao diện (Không bị giật app).

#### 3.1.4. Thiết kế báo cáo
Tự động dựng biểu đồ số liệu Dashboard trực quan ở trung tâm (Main Form Area) sau khi Login, đo lường toàn diện các biến động dữ liệu.

### 3.2. Hiện thực chương trình
- **Ngôn ngữ lập trình cốt lõi:** C# .NET (Phiên bản FrameWork / .NET tối thiểu 8.0)
- **Công nghệ lưu trữ DB:** Microsoft SQL Server T-SQL Management.
- **Trigger DB:** Viết SQL Server Trigger `AFTER INSERT` trên bảng `OrderDetails`. Đây là nghệ thuật giảm thiểu gánh nặng cho Tool C#. Thay vì WinForm kéo data `UPDATE Quantity`, Database tự lắng nghe lệnh sinh ra dòng Hóa Đơn Mới và từ phía server nội bộ: tự trừ đi lượng `Stock`, tự cộng `LoyaltyPoints` của Người Mua rồi tự rải `Log Kho` bảo toàn mọi lỗi logic đường truyền mạng và lỗi bất ngờ của RAM.

---

## ĐÁNH GIÁ VÀ KẾT LUẬN
**Tính năng Đạt được:**
- Mô hình Quản Lý Bán Hàng khép kín được hiện thực hóa xuất sắc. Chạy ổn định không crash (xung đột).
- Cấu trúc Design Pattern (3 Layer) phân rã rõ: GUI -> BUS -> DAL. Tránh phụ thuộc chồng chéo code.
- Cơ chế bảo mật và Backup hoàn hảo với Cờ Xóa Soft-Delete. Giải quyết nguyên lý tham chiếu cứng constraint của SQL.
- Quản trị giao diện thông minh, chặn lỗi nhập liệu Null / Rỗng ở Level View bằng MessageBox. Có sự phân chia quyền Admin và Staff tuyệt tuân thủ tính RBAC.

**Hạn chế và Hướng phát triển cho Tương Lai:**
- Hiện tại, việc bảo mật mật khẩu tuy được quan tâm ở giao diện nhưng dưới hạ tầng SQL, Passwords vẫn bị lưu Text. Cần Hash (Băm mật khẩu) thuật toán như SHA256 hoặc BCrypt để triệt để rủi ro tấn công hệ thống cấp cao.
- Chức năng Backup Database (Xuất .bak) ra ở C# GUI dành cho Admin chưa được cung cấp.

## TÀI LIỆU THAM KHẢO
1. Microsoft Documentation: Tài liệu lập trình Hệ thống C# Desktop với WinForms (.NET 8.0).
2. Các giáo trình về Thiết kế Phân tích Hệ Thống Thông Tin tại trường.
3. Giáo trình quản trị SQL Server, Cơ sở Dữ Liệu và Transaction-Trigger Logic (ĐH ... / Khoa học tự nhiên).
