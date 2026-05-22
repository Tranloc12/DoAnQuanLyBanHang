using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BUS_QuanLy;
using DTO_QuanLy;
using DoAnQuanLyBanHang.Helpers;
using GUI_QuanLy;

namespace GUI_QuanLy
{
    public partial class frmBanHang : Form
    {
        private readonly ProductBUS productBUS = new ProductBUS();
        private readonly CustomerBUS customerBUS = new CustomerBUS();
        private readonly OrderBUS orderBUS = new OrderBUS();

        private CustomerDTO? khachHangHienTai = null;
        private readonly List<OrderDetailDTO> danhSachChiTiet = new List<OrderDetailDTO>();

        // Lưu thông tin đơn lùi để in lại
        private OrderDTO? lastOrder = null;
        private List<OrderDetailDTO>? lastOrderDetails = null;
        private string lastCustomerName = "";
        private string lastEmployeeName = "";

        private const decimal GIA_TRI_MOT_DIEM = 1000; // 1 điểm = 1000 VNĐ

        public frmBanHang()
        {
            InitializeComponent();
        }

        private void frmBanHang_Load(object sender, EventArgs e)
        {
            LoadComboboxSanPham();
            LoadComboboxPTTT();
            LamMoiDonHang();
            
            // Khóa nút in khi mới mở
            if (btnInHoaDon != null) btnInHoaDon.Enabled = false;
        }

        private void LoadComboboxSanPham()
        {
            DataTable dt = productBUS.LayDanhSachSanPham();
            cbSanPham.DataSource = dt;
            cbSanPham.DisplayMember = "ProductName";
            cbSanPham.ValueMember = "ProductID";
            cbSanPham.SelectedIndex = -1;
        }

        private void LoadComboboxPTTT()
        {
            cbPhuongThucTT.Items.Clear();
            cbPhuongThucTT.Items.Add("Tiền mặt");
            cbPhuongThucTT.Items.Add("Thẻ ngân hàng");
            cbPhuongThucTT.Items.Add("Chuyển khoản / Ví điện tử");
            cbPhuongThucTT.Items.Add("PayPal (QR)");
            cbPhuongThucTT.SelectedIndex = 0;
        }

        private void cbSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSanPham.SelectedValue != null && cbSanPham.SelectedValue is int)
            {
                int productId = (int)cbSanPham.SelectedValue;
                DataRowView? drv = cbSanPham.SelectedItem as DataRowView;
                if (drv != null) {
                    txtDonGia.Text = Convert.ToDecimal(drv["SellPrice"]).ToString("N0");
                }
            }
        }

        private void btnTimKH_Click(object sender, EventArgs e) => TimKhachHang();

        private void txtSDTKhachHang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { TimKhachHang(); e.SuppressKeyPress = true; }
        }

        private void TimKhachHang()
        {
            string sdt = txtSDTKhachHang.Text.Trim();
            if (string.IsNullOrEmpty(sdt)) {
                khachHangHienTai = null;
                txtTenKhachHang.Text = "";
                txtTenKhachHang.ReadOnly = false;
                txtTenKhachHang.BackColor = System.Drawing.Color.White;
                lblTenKhachHang.Text = "Tên khách hàng:";
                return;
            }

            CustomerDTO? kh = customerBUS.TimTheoSoDienThoai(sdt);
            if (kh != null)
            {
                khachHangHienTai = kh;
                txtTenKhachHang.Text = kh.CustomerName;
                txtTenKhachHang.ReadOnly = true; 
                txtTenKhachHang.BackColor = System.Drawing.Color.LightGray;
                
                chkDungDiem.Enabled = kh.LoyaltyPoints > 0;
                chkDungDiem.Checked = false;
                txtSoDiem.Text = "0";
                lblQuyDoi.Text = "= 0 VNĐ";
                
                string rankShort = kh.CustomerRank;
                if (rankShort == "Kim Cương") rankShort = "KC";
                else if (rankShort == "Vàng") rankShort = "V";
                else if (rankShort == "Bạc") rankShort = "B";
                else if (rankShort == "Đồng") rankShort = "Đ";
                
                lblTenKhachHang.Text = $"KH ({kh.LoyaltyPoints}đ - {rankShort}):";
            }
            else
            {
                khachHangHienTai = null;
                txtTenKhachHang.Text = "";
                txtTenKhachHang.ReadOnly = false;
                txtTenKhachHang.BackColor = System.Drawing.Color.White;
                txtTenKhachHang.Focus();

                lblTenKhachHang.Text = "Khách mới (nhập tên):";
                chkDungDiem.Enabled = false;
                chkDungDiem.Checked = false;
            }
        }

        private void txtTimSanPham_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Ngăn tiếng beep
                string kw = txtTimSanPham.Text.Trim();
                if (string.IsNullOrEmpty(kw)) return;

                DataTable dt = productBUS.TimKiemSanPham(kw);
                if (dt.Rows.Count > 0)
                {
                    // Nếu tìm thấy, lấy sản phẩm đầu tiên (ưu tiên khớp chính xác hoặc khớp top)
                    int firstProductId = (int)dt.Rows[0]["ProductID"];
                    cbSanPham.SelectedValue = firstProductId;
                    
                    // Nếu gõ đúng mã SP (giống như quét mã vạch), thêm luôn vào giỏ
                    if (dt.Rows[0]["ProductCode"]?.ToString()?.Equals(kw, StringComparison.OrdinalIgnoreCase) == true)
                    {
                        btnThemVaoGio_Click(this, EventArgs.Empty);
                        txtTimSanPham.Clear();
                        txtTimSanPham.Focus();
                    }
                    else {
                        txtSoLuong.Focus();
                        txtSoLuong.SelectAll();
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTimSanPham.Focus();
                    txtTimSanPham.SelectAll();
                }
            }
        }

        private void btnThemVaoGio_Click(object sender, EventArgs e)
        {
            if (cbSanPham.SelectedValue == null) return;
            int productId = (int)cbSanPham.SelectedValue;
            string productName = cbSanPham.Text;
            int soLuong = int.Parse(txtSoLuong.Text);
            decimal donGia = decimal.Parse(txtDonGia.Text.Replace(",", ""));

            // Kiểm tra xem sản phẩm đã có trong giỏ chưa
            var existing = danhSachChiTiet.Find(x => x.ProductID == productId);
            if (existing != null)
            {
                existing.Quantity += soLuong;
            }
            else
            {
                danhSachChiTiet.Add(new OrderDetailDTO
                {
                    ProductID = productId,
                    ProductName = productName,
                    Quantity = soLuong,
                    UnitPrice = donGia
                });
            }

            CapNhatBangGioHang();
            TinhTongTien();
        }

        private void CapNhatBangGioHang()
        {
            dgvGioHang.Rows.Clear();
            foreach (var item in danhSachChiTiet)
            {
                dgvGioHang.Rows.Add(item.ProductID, item.ProductName, item.Quantity, item.UnitPrice.ToString("N0"), (item.Quantity * item.UnitPrice).ToString("N0"));
            }
        }

        private void btnTangSL_Click(object sender, EventArgs e)
        {
            if (dgvGioHang.CurrentRow == null) return;
            int productId = (int)dgvGioHang.CurrentRow.Cells[0].Value;
            var item = danhSachChiTiet.Find(x => x.ProductID == productId);
            if (item != null) { item.Quantity++; CapNhatBangGioHang(); TinhTongTien(); }
        }

        private void btnGiamSL_Click(object sender, EventArgs e)
        {
            if (dgvGioHang.CurrentRow == null) return;
            int productId = (int)dgvGioHang.CurrentRow.Cells[0].Value;
            var item = danhSachChiTiet.Find(x => x.ProductID == productId);
            if (item == null) return;
            if (item.Quantity <= 1)
            {
                // Khi số lượng = 1 mà giảm nữa → hỏi xóa luôn
                if (MessageBox.Show($"Xóa '{item.ProductName}' khỏi giỏ hàng?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    danhSachChiTiet.Remove(item);
                    CapNhatBangGioHang();
                    TinhTongTien();
                }
            }
            else
            {
                item.Quantity--;
                CapNhatBangGioHang();
                TinhTongTien();
            }
        }

        private void btnXoaDong_Click(object sender, EventArgs e)
        {
            if (dgvGioHang.CurrentRow != null)
            {
                int productId = (int)dgvGioHang.CurrentRow.Cells[0].Value;
                danhSachChiTiet.RemoveAll(x => x.ProductID == productId);
                CapNhatBangGioHang();
                TinhTongTien();
            }
        }

        private void TinhTongTien()
        {
            decimal tongTien = 0;
            foreach (var item in danhSachChiTiet) tongTien += item.Quantity * item.UnitPrice;
            lblTongTien.Text = tongTien.ToString("N0") + " VNĐ";
            
            decimal giamGia = string.IsNullOrEmpty(txtGiamGia.Text) ? 0 : decimal.Parse(txtGiamGia.Text.Replace(",", ""));
            
            int soDiemDung = 0;
            decimal giamDiem = 0;
            if (chkDungDiem.Checked && int.TryParse(txtSoDiem.Text, out soDiemDung))
            {
                giamDiem = soDiemDung * GIA_TRI_MOT_DIEM;
            }

            decimal thanhToan = tongTien - giamGia - giamDiem;
            if (thanhToan < 0) thanhToan = 0;
            lblThanhToan.Text = thanhToan.ToString("N0") + " VNĐ";
        }

        private void txtGiamGia_TextChanged(object sender, EventArgs e) => TinhTongTien();

        private void chkDungDiem_CheckedChanged(object sender, EventArgs e)
        {
            txtSoDiem.Enabled = chkDungDiem.Checked;
            if (!chkDungDiem.Checked)
            {
                txtSoDiem.Text = "0";
                lblQuyDoi.Text = "= 0 VNĐ";
            }
            TinhTongTien();
        }

        private void txtSoDiem_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txtSoDiem.Text, out int diem))
            {
                if (khachHangHienTai != null && diem > khachHangHienTai.LoyaltyPoints)
                {
                    diem = khachHangHienTai.LoyaltyPoints;
                    txtSoDiem.Text = diem.ToString();
                }
                lblQuyDoi.Text = "= " + (diem * GIA_TRI_MOT_DIEM).ToString("N0") + " VNĐ";
            }
            TinhTongTien();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (danhSachChiTiet.Count == 0)
            {
                MessageBox.Show("Giỏ hàng trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal tongTien = 0;
            foreach (var item in danhSachChiTiet) tongTien += item.Quantity * item.UnitPrice;
            decimal giamGia = string.IsNullOrEmpty(txtGiamGia.Text) ? 0 : decimal.Parse(txtGiamGia.Text.Replace(",", ""));
            
            int soDiemDung = 0;
            decimal giamDiem = 0;
            if (chkDungDiem.Checked && int.TryParse(txtSoDiem.Text, out soDiemDung))
            {
                giamDiem = soDiemDung * GIA_TRI_MOT_DIEM;
            }

            decimal thanhToan = tongTien - giamGia - giamDiem;
            if (thanhToan < 0) thanhToan = 0;

            // --- XỬ LÝ TỰ ĐỘNG PHÁT HIỆN HOẶC THÊM KHÁCH HÀNG ---
            int? customerId = null;
            string sdtLuu = txtSDTKhachHang.Text.Trim();
            string tenLuu = txtTenKhachHang.Text.Trim();

            if (khachHangHienTai != null)
            {
                customerId = khachHangHienTai.CustomerID;
            }
            else if (!string.IsNullOrEmpty(sdtLuu))
            {
                var khCheck = customerBUS.TimTheoSoDienThoai(sdtLuu);
                if (khCheck != null)
                {
                    customerId = khCheck.CustomerID;
                    khachHangHienTai = khCheck;
                }
                else if (!string.IsNullOrEmpty(tenLuu))
                {
                    CustomerDTO newKH = new CustomerDTO { CustomerName = tenLuu, Phone = sdtLuu };
                    if (customerBUS.ThemKhachHang(newKH))
                    {
                        var createdKH = customerBUS.TimTheoSoDienThoai(sdtLuu);
                        if (createdKH != null) 
                        {
                            customerId = createdKH.CustomerID;
                            khachHangHienTai = createdKH;
                        }
                    }
                }
            }

            OrderDTO donHang = new OrderDTO
            {
                CustomerID    = customerId,
                UserID        = SessionUser.CurrentUser?.UserID ?? 1,
                TotalAmount   = tongTien,
                Discount      = giamGia + giamDiem,
                FinalAmount   = thanhToan,
                PaymentMethod = cbPhuongThucTT.Text,
                Notes         = txtGhiChu.Text.Trim() + (soDiemDung > 0 ? $" [Dùng {soDiemDung} điểm]" : "")
            };

            // --- GIẢ LẬP LUỒNG THANH TOÁN PAYPAL / CHUYỂN KHOẢN ---
            // Phải đưa QR ra thu tiền TRƯỚC khi ghi nhận hóa đơn vào DB
            if (cbPhuongThucTT.Text.Contains("PayPal"))
            {
                // Tạo mã dự kiến để in ra QR (chưa lưu vào DB)
                string tempOrderCode = "DH_" + DateTime.Now.ToString("yyMMddHHmmss");
                frmPaymentQR qrForm = new frmPaymentQR(thanhToan, tempOrderCode);
                qrForm.ShowDialog(); // App sẽ tạm dừng ở đây đợi thu ngân tắt form QR

                // Thu ngân tắt form QR xong, phần mềm sẽ hỏi xác nhận tiền đã vào tài khoản chưa
                var xacNhan = MessageBox.Show(
                    "Khách hàng đã quét mã và thanh toán thành công chưa?", 
                    "Xác nhận nhận tiền", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (xacNhan != DialogResult.Yes)
                {
                    MessageBox.Show("Giao dịch đã bị hủy do chưa nhận được tiền thanh toán.", "Hủy thanh toán", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Kết thúc, không lưu DB
                }
                donHang.OrderCode = tempOrderCode; // Lấy đúng mã trên QR để lưu
            }

            int orderId = orderBUS.TaoDonHang(donHang, danhSachChiTiet);
            if (orderId > 0)
            {
                if (soDiemDung > 0 && customerId.HasValue)
                {
                    customerBUS.TruDiemKhachHang(customerId.Value, soDiemDung);
                }

                int diemTich = (int)(thanhToan / 100000);
                string thongBaoDiem = customerId.HasValue && diemTich > 0 ? $"\n- Điểm tích lũy: +{diemTich} điểm" : "";
                string thongBaoDungDiem = soDiemDung > 0 ? $"\n- Đã dùng: {soDiemDung} điểm (-{giamDiem:N0} VNĐ)" : "";

                var dhFull = orderBUS.LayDonHangTheoID(orderId);
                if (dhFull != null) donHang = dhFull;

                lastOrder = donHang;
                lastOrderDetails = new List<OrderDetailDTO>(danhSachChiTiet);
                lastCustomerName = txtTenKhachHang.Text.Trim();
                lastEmployeeName = SessionUser.CurrentUser?.FullName ?? "POS System";

                if (btnInHoaDon != null) btnInHoaDon.Enabled = true;

                // TỰ ĐỘNG HỎI IN HÓA ĐƠN
                var result = MessageBox.Show(
                    $"Thanh toán thành công!\nMã đơn: {donHang.OrderCode}\nThành tiền: {thanhToan:N0} VNĐ{thongBaoDungDiem}{thongBaoDiem}\n\nBạn có muốn in hóa đơn cho khách không?",
                    "Thành công", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (result == DialogResult.Yes)
                {
                    btnInHoaDon_Click(this, EventArgs.Empty);
                }

                LamMoiDonHang();
            }
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            if (lastOrder != null && lastOrderDetails != null)
            {
                InvoiceHelper.GenerateAndShowInvoice(lastOrder!, lastOrderDetails!, lastCustomerName, lastEmployeeName);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e) => LamMoiDonHang();

        private void LamMoiDonHang()
        {
            danhSachChiTiet.Clear();
            dgvGioHang.Rows.Clear();
            lblTongTien.Text          = "0 VNĐ";
            lblThanhToan.Text         = "0 VNĐ";
            txtGiamGia.Text           = "0";
            txtSDTKhachHang.Clear();
            txtTimSanPham.Clear();
            txtTenKhachHang.Clear();
            txtTenKhachHang.ReadOnly = false;
            txtTenKhachHang.BackColor = System.Drawing.Color.White;
            txtGhiChu.Clear();
            lblTenKhachHang.Text      = "Tên khách hàng:";
            khachHangHienTai          = null;
            chkDungDiem.Checked       = false;
            chkDungDiem.Enabled       = false;
            txtSoDiem.Text            = "0";
            txtSoDiem.Enabled         = false;
            lblQuyDoi.Text            = "= 0 VNĐ";
            cbPhuongThucTT.SelectedIndex = 0;
            txtSoLuong.Text           = "1";
        }
    }
}
