using System;
using System.Data;
using System.Windows.Forms;
using DoAnQuanLyBanHang.BUS;

namespace DoAnQuanLyBanHang
{
    public partial class frmDonHang : Form
    {
        private readonly OrderBUS orderBUS = new OrderBUS();

        public frmDonHang()
        {
            InitializeComponent();
        }

        private void frmDonHang_Load(object sender, EventArgs e)
        {
            dtpTuNgay.Value = DateTime.Today.AddDays(-30);
            dtpDenNgay.Value = DateTime.Today;
            HienThiDanhSach();
        }

        private void HienThiDanhSach()
        {
            dgvDonHang.DataSource = orderBUS.LayDanhSachDonHang();
            if (dgvDonHang.Columns["OrderID"] != null)
                dgvDonHang.Columns["OrderID"].Visible = false;
            if (dgvDonHang.Columns["CustomerID"] != null)
                dgvDonHang.Columns["CustomerID"].Visible = false;
            if (dgvDonHang.Columns["UserID"] != null)
                dgvDonHang.Columns["UserID"].Visible = false;
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            dgvDonHang.DataSource = orderBUS.LayDonHangTheoNgay(dtpTuNgay.Value, dtpDenNgay.Value);
        }

        private void btnTatCa_Click(object sender, EventArgs e)
        {
            HienThiDanhSach();
        }

        private void btnXemChiTiet_Click(object sender, EventArgs e)
        {
            if (dgvDonHang.CurrentRow == null) return;
            int orderId = Convert.ToInt32(dgvDonHang.CurrentRow.Cells["OrderID"].Value);
            DataTable dt = orderBUS.LayChiTietDonHang(orderId);
            dgvChiTiet.DataSource = dt;
        }

        private void btnHuyDon_Click(object sender, EventArgs e)
        {
            if (dgvDonHang.CurrentRow == null) return;
            string status = dgvDonHang.CurrentRow.Cells["OrderStatus"].Value?.ToString();
            if (status == "Hủy") { MessageBox.Show("Đơn hàng này đã bị hủy rồi!"); return; }
            int orderId = Convert.ToInt32(dgvDonHang.CurrentRow.Cells["OrderID"].Value);
            if (MessageBox.Show("Bạn có chắc muốn hủy đơn hàng này?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (orderBUS.HuyDonHang(orderId))
                { MessageBox.Show("Hủy đơn thành công!"); HienThiDanhSach(); }
                else
                    MessageBox.Show("Hủy đơn thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDonHang_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            // Tự động load chi tiết khi chọn dòng
            if (dgvDonHang.CurrentRow == null) return;
            try
            {
                int orderId = Convert.ToInt32(dgvDonHang.CurrentRow.Cells["OrderID"].Value);
                dgvChiTiet.DataSource = orderBUS.LayChiTietDonHang(orderId);
            }
            catch { }
        }
    }
}
