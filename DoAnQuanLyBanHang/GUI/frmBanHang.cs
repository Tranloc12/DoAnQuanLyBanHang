using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DoAnQuanLyBanHang.BUS;
using DoAnQuanLyBanHang.DTO;
using DoAnQuanLyBanHang.Helpers;

namespace DoAnQuanLyBanHang
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
            cbPhuongThucTT.SelectedIndex = 0;
        }

        private void cbSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSanPham.SelectedValue != null && cbSanPham.SelectedValue is int)
            {
                int productId = (int)cbSanPham.SelectedValue;
                DataRowView drv = (DataRowView)cbSanPham.SelectedItem;
                txtDonGia.Text = Convert.ToDecimal(drv["SellPrice"]).ToString("N0");
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
            if (string.IsNullOrEmpty(sdt)) return;

            CustomerDTO kh = customerBUS.TimTheoSoDienThoai(sdt);
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
                lblTenKhachHang.Text = $"Tên khách (⭐ {kh.LoyaltyPoints}):";
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
                    if (dt.Rows[0]["ProductCode"].ToString().Equals(kw, StringComparison.OrdinalIgnoreCase))
                    {
                        btnThemVaoGio_Click(null, null);
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

            int orderId = orderBUS.TaoDonHang(donHang, danhSachChiTiet);
            if (orderId > 0)
            {
                if (soDiemDung > 0 && customerId.HasValue)
                {
                    customerBUS.TruDiemKhachHang(customerId.Value, soDiemDung);
                }

                int diemTich = (int)(thanhToan / 100000);
                string thongBaoDiem = customerId.HasValue && diemTich > 0 ? $"\n⭐ Điểm tích lũy: +{diemTich} điểm" : "";
                string thongBaoDungDiem = soDiemDung > 0 ? $"\n✨ Đã dùng: {soDiemDung} điểm (-{giamDiem:N0} VNĐ)" : "";

                var dhFull = orderBUS.LayDonHangTheoID(orderId);
                if (dhFull != null) donHang = dhFull;

                MessageBox.Show(
                    $"✅ Thanh toán thành công!\nMã đơn: {donHang.OrderCode}\nThành tiền: {thanhToan:N0} VNĐ{thongBaoDungDiem}{thongBaoDiem}",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                lastOrder = donHang;
                lastOrderDetails = new List<OrderDetailDTO>(danhSachChiTiet);
                lastCustomerName = txtTenKhachHang.Text.Trim();
                lastEmployeeName = SessionUser.CurrentUser?.FullName ?? "POS System";

                if (donHang.CustomerID.HasValue)
                {
                    CustomerDTO? khCapNhat = customerBUS.TimTheoSoDienThoai(sdtLuu);
                    if (khCapNhat != null)
                    {
                        khachHangHienTai = khCapNhat;
                        txtTenKhachHang.Text = khCapNhat.CustomerName;
                        txtTenKhachHang.ReadOnly = true;
                        lblTenKhachHang.Text = $"Tên khách (⭐ {khCapNhat.LoyaltyPoints}):";
                    }
                }

                if (btnInHoaDon != null) btnInHoaDon.Enabled = true;
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
