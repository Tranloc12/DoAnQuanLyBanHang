using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using DoAnQuanLyBanHang.BUS;
using DoAnQuanLyBanHang.DTO;

namespace DoAnQuanLyBanHang
{
    public partial class frmBanHang : Form
    {
        private readonly ProductBUS  productBUS  = new ProductBUS();
        private readonly CustomerBUS customerBUS = new CustomerBUS();
        private readonly OrderBUS    orderBUS    = new OrderBUS();

        // Danh sách các dòng đang chờ
        // Danh sách các dòng đang chờ
        private readonly List<OrderDetailDTO> danhSachChiTiet = new List<OrderDetailDTO>();

        // Lưu thông tin đơn lùi để in lại
        private OrderDTO lastOrder = null;
        private List<OrderDetailDTO> lastOrderDetails = null;
        private string lastCustomerName = "";
        private string lastEmployeeName = "";
        
        // Nút in hóa đơn động
        private Button btnInHoaDon;

        public frmBanHang()
        {
            InitializeComponent();
        }

        private void frmBanHang_Load(object sender, EventArgs e)
        {
            // Inject btnInHoaDon
            btnInHoaDon = new Button();
            btnInHoaDon.Text = "🖨 IN HÓA ĐƠN";
            btnInHoaDon.Size = new Size(255, 42);
            btnInHoaDon.Location = new System.Drawing.Point(10, btnThanhToan.Location.Y + 45);
            btnInHoaDon.BackColor = System.Drawing.Color.RoyalBlue;
            btnInHoaDon.ForeColor = System.Drawing.Color.White;
            btnInHoaDon.Font = new System.Drawing.Font("Segoe UI", 11, System.Drawing.FontStyle.Bold);
            btnInHoaDon.Enabled = false;
            btnInHoaDon.Click += (s, ev) => 
            {
                if (lastOrder != null) 
                {
                    try {
                        DoAnQuanLyBanHang.Helpers.InvoiceHelper.GenerateAndShowInvoice(lastOrder, lastOrderDetails, lastCustomerName, lastEmployeeName);
                    } catch (Exception ex) {
                        MessageBox.Show("Lỗi in PDF: " + ex.Message);
                    }
                }
            };
            grpThanhToan.Height += 50; 
            grpThanhToan.Controls.Add(btnInHoaDon);

            NapSanPham();
            cbPhuongThucTT.Items.AddRange(new string[] { "Tiền mặt", "Thẻ ngân hàng", "Chuyển khoản" });
            cbPhuongThucTT.SelectedIndex = 0;
            LamMoiDonHang();
        }

        // ─── Nạp sản phẩm vào ComboBox ───
        private void NapSanPham()
        {
            DataTable dt = productBUS.LayDanhSachSanPham();
            cbSanPham.DataSource    = dt;
            cbSanPham.DisplayMember = "ProductName";
            cbSanPham.ValueMember   = "ProductID";
        }

        // ─── Tìm khách hàng theo SĐT ───
        private void btnTimKH_Click(object sender, EventArgs e)
        {
            string sdt = txtSDTKhachHang.Text.Trim();
            if (string.IsNullOrEmpty(sdt)) return;

            CustomerDTO kh = customerBUS.TimTheoSoDienThoai(sdt);
            if (kh != null)
            {
                lblTenKhachHang.Text = kh.CustomerName + $"  (Điểm: {kh.LoyaltyPoints})";
                lblTenKhachHang.Tag  = kh.CustomerID;
            }
            else
            {
                lblTenKhachHang.Text = "Khách lẻ (không tìm thấy)";
                lblTenKhachHang.Tag  = null;
            }
        }

        // ─── Khi chọn SP → cập nhật đơn giá ───
        private void cbSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSanPham.SelectedItem is DataRowView row)
            {
                txtDonGia.Text  = row["SellPrice"].ToString();
                txtSoLuong.Text = "1";
            }
        }

        // ─── Thêm vào giỏ hàng ───
        private void btnThemVaoGio_Click(object sender, EventArgs e)
        {
            if (cbSanPham.SelectedValue == null) return;
            if (!decimal.TryParse(txtDonGia.Text, out decimal gia) || gia <= 0) { MessageBox.Show("Đơn giá không hợp lệ!"); return; }
            if (!int.TryParse(txtSoLuong.Text, out int sl) || sl <= 0) { MessageBox.Show("Số lượng phải > 0!"); return; }

            if (cbSanPham.SelectedItem is DataRowView row)
            {
                int    productID   = (int)cbSanPham.SelectedValue;
                string productName = row["ProductName"].ToString();
                string productCode = row["ProductCode"].ToString();
                int    tonKho      = Convert.ToInt32(row["Quantity"]);

                if (sl > tonKho) { MessageBox.Show($"Tồn kho chỉ còn {tonKho}!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

                // Kiểm tra nếu SP đã có trong giỏ thì cộng thêm SL
                var existing = danhSachChiTiet.Find(x => x.ProductID == productID);
                if (existing != null)
                    existing.Quantity += sl;
                else
                    danhSachChiTiet.Add(new OrderDetailDTO
                    {
                        ProductID   = productID,
                        ProductCode = productCode,
                        ProductName = productName,
                        Quantity    = sl,
                        UnitPrice   = gia
                    });

                CapNhatGioHang();
            }
        }

        // ─── Xóa dòng khỏi giỏ ───
        private void btnXoaDong_Click(object sender, EventArgs e)
        {
            if (dgvGioHang.CurrentRow == null) return;
            int idx = dgvGioHang.CurrentRow.Index;
            if (idx >= 0 && idx < danhSachChiTiet.Count)
            {
                danhSachChiTiet.RemoveAt(idx);
                CapNhatGioHang();
            }
        }

        // ─── Cập nhật hiển thị giỏ hàng & tổng tiền ───
        private void CapNhatGioHang()
        {
            dgvGioHang.Rows.Clear();
            decimal tongTien = 0;
            foreach (var ct in danhSachChiTiet)
            {
                decimal thanhtien = ct.Quantity * ct.UnitPrice;
                tongTien += thanhtien;
                dgvGioHang.Rows.Add(ct.ProductCode, ct.ProductName, ct.Quantity, ct.UnitPrice.ToString("N0"), thanhtien.ToString("N0"));
            }
            lblTongTien.Text    = tongTien.ToString("N0") + " VNĐ";
            TinhToanThanhToan();
        }

        private void TinhToanThanhToan()
        {
            if (!decimal.TryParse(lblTongTien.Text.Replace(" VNĐ", "").Replace(",", ""), out decimal tong)) return;
            if (!decimal.TryParse(txtGiamGia.Text, out decimal giam)) giam = 0;
            decimal cuoiCung = tong - giam;
            if (cuoiCung < 0) cuoiCung = 0;
            lblThanhToan.Text = cuoiCung.ToString("N0") + " VNĐ";
        }

        private void txtGiamGia_TextChanged(object sender, EventArgs e) => TinhToanThanhToan();

        // ─── Thanh toán ───
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (danhSachChiTiet.Count == 0) { MessageBox.Show("Giỏ hàng trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            decimal tongTien = 0;
            foreach (var ct in danhSachChiTiet) tongTien += ct.Quantity * ct.UnitPrice;
            decimal giamGia = decimal.TryParse(txtGiamGia.Text, out decimal g) ? g : 0;
            decimal thanhToan = tongTien - giamGia;

            OrderDTO donHang = new OrderDTO
            {
                CustomerID    = lblTenKhachHang.Tag != null ? (int?)Convert.ToInt32(lblTenKhachHang.Tag) : null,
                UserID        = SessionUser.CurrentUser?.UserID ?? 1,
                TotalAmount   = tongTien,
                Discount      = giamGia,
                FinalAmount   = thanhToan,
                PaymentMethod = cbPhuongThucTT.Text,
                Notes         = txtGhiChu.Text.Trim()
            };

            int orderId = orderBUS.TaoDonHang(donHang, danhSachChiTiet);
            if (orderId > 0)
            {
                MessageBox.Show($"✅ Thanh toán thành công!\nMã đơn: {donHang.OrderCode}\nThành tiền: {thanhToan:N0} VNĐ",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                // Lưu lại thông tin đơn hàng vừa thanh toán để in hóa đơn
                lastOrder = donHang;
                lastOrderDetails = new List<OrderDetailDTO>(danhSachChiTiet);
                lastCustomerName = lblTenKhachHang.Text;
                lastEmployeeName = SessionUser.CurrentUser?.FullName ?? "N/A";
                
                // Mở khóa nút In
                if (btnInHoaDon != null) btnInHoaDon.Enabled = true;

                LamMoiDonHang();
            }
            else
                MessageBox.Show("Thanh toán thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // ─── Làm mới toàn bộ đơn hàng ───
        private void btnLamMoi_Click(object sender, EventArgs e) => LamMoiDonHang();

        private void LamMoiDonHang()
        {
            danhSachChiTiet.Clear();
            dgvGioHang.Rows.Clear();
            lblTongTien.Text          = "0 VNĐ";
            lblThanhToan.Text         = "0 VNĐ";
            txtGiamGia.Text           = "0";
            txtSDTKhachHang.Clear();
            txtGhiChu.Clear();
            lblTenKhachHang.Text      = "Khách lẻ";
            lblTenKhachHang.Tag       = null;
            cbPhuongThucTT.SelectedIndex = 0;
            txtSoLuong.Text           = "1";
        }
    }
}
