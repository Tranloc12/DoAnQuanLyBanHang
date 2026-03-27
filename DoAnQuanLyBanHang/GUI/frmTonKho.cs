using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DoAnQuanLyBanHang.BUS;

namespace DoAnQuanLyBanHang
{
    public partial class frmTonKho : Form
    {
        private readonly InventoryBUS inventoryBUS = new InventoryBUS();

        public frmTonKho() { InitializeComponent(); }

        private void frmTonKho_Load(object sender, EventArgs e)
        {
            HienThiTonKho();
        }

        private void HienThiTonKho(string filter = "all")
        {
            DataTable dt = inventoryBUS.LayTonKho();
            if (filter == "low")
            {
                DataView dv = new DataView(dt);
                dv.RowFilter = $"TrangThai = 'Sắp hết' OR TrangThai = 'Hết hàng'";
                dt = dv.ToTable();
            }
            dgvTonKho.DataSource = dt;
            if (dgvTonKho.Columns["ProductID"] != null)
                dgvTonKho.Columns["ProductID"].Visible = false;
            ToCauHinhMauHang();
            lblThongKe.Text = $"Tổng: {dgvTonKho.Rows.Count} sản phẩm";
        }

        // Tô màu theo trạng thái tồn kho
        private void ToCauHinhMauHang()
        {
            foreach (DataGridViewRow row in dgvTonKho.Rows)
            {
                string tt = row.Cells["TrangThai"].Value?.ToString();
                if (tt == "Hết hàng")
                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 200, 200);
                else if (tt == "Sắp hết")
                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 240, 180);
                else
                    row.DefaultCellStyle.BackColor = Color.FromArgb(200, 240, 200);
            }
        }

        private void btnTatCa_Click(object sender, EventArgs e) => HienThiTonKho("all");
        private void btnSapHet_Click(object sender, EventArgs e) => HienThiTonKho("low");

        // Nhập thêm hàng vào kho
        private void btnNhapKho_Click(object sender, EventArgs e)
        {
            if (dgvTonKho.CurrentRow == null) return;
            int productId   = Convert.ToInt32(dgvTonKho.CurrentRow.Cells["ProductID"].Value);
            string tenSP    = dgvTonKho.CurrentRow.Cells["ProductName"].Value?.ToString();
            int tonHienTai  = Convert.ToInt32(dgvTonKho.CurrentRow.Cells["TonKho"].Value);

            string input = Microsoft.VisualBasic.Interaction.InputBox(
                $"Sản phẩm: {tenSP}\nTồn kho hiện tại: {tonHienTai}\n\nNhập số lượng thêm:",
                "Nhập Kho", "0");

            if (int.TryParse(input, out int soLuong) && soLuong > 0)
            {
                if (inventoryBUS.NhapKho(productId, soLuong))
                {
                    MessageBox.Show($"✅ Nhập kho thành công!\n{tenSP}: +{soLuong} → Tổng {tonHienTai + soLuong}",
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HienThiTonKho();
                }
                else
                    MessageBox.Show("Nhập kho thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!string.IsNullOrEmpty(input))
                MessageBox.Show("Số lượng không hợp lệ! Phải > 0.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void dgvTonKho_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Không cần làm gì thêm ở đây — màu đã set ở ToCauHinhMauHang
        }
    }
}
