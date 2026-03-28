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
            try {
                DataTable dt = inventoryBUS.LayTonKho();
                if (filter == "low")
                {
                    DataView dv = new DataView(dt);
                    dv.RowFilter = "TrangThai = 'Sắp hết' OR TrangThai = 'Hết hàng'";
                    dt = dv.ToTable();
                }
                dgvTonKho.DataSource = dt;
                
                if (dgvTonKho.Columns["ProductID"] != null) dgvTonKho.Columns["ProductID"].Visible = false;
                
                // Format column headers
                if (dgvTonKho.Columns["ProductCode"] != null) dgvTonKho.Columns["ProductCode"].HeaderText = "Mã SP";
                if (dgvTonKho.Columns["ProductName"] != null) dgvTonKho.Columns["ProductName"].HeaderText = "Tên Sản Phẩm";
                if (dgvTonKho.Columns["CategoryName"] != null) dgvTonKho.Columns["CategoryName"].HeaderText = "Loại";
                if (dgvTonKho.Columns["SupplierName"] != null) dgvTonKho.Columns["SupplierName"].HeaderText = "Nhà Cung Cấp";
                if (dgvTonKho.Columns["TonKho"] != null) dgvTonKho.Columns["TonKho"].HeaderText = "Số Lượng";
                if (dgvTonKho.Columns["TonToiThieu"] != null) dgvTonKho.Columns["TonToiThieu"].HeaderText = "Tối Thiểu";
                if (dgvTonKho.Columns["TrangThai"] != null) dgvTonKho.Columns["TrangThai"].HeaderText = "Trạng Thái";

                ToCauHinhMauHang();
                
                decimal tongGiaTri = 0;
                foreach (DataRow r in dt.Rows)
                {
                    tongGiaTri += Convert.ToDecimal(r["TonKho"]) * Convert.ToDecimal(r["SellPrice"]);
                }

                lblThongKe.Text = $"📊 Tổng: {dt.Rows.Count} SP | Trị giá tồn kho ước tính: {tongGiaTri:N0} VNĐ";
            } catch (Exception ex) { }
        }

        private void ToCauHinhMauHang()
        {
            foreach (DataGridViewRow row in dgvTonKho.Rows)
            {
                if (row.Cells["TrangThai"] != null) {
                    string tt = row.Cells["TrangThai"].Value?.ToString();
                    if (tt == "Hết hàng")
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 200, 200);
                    else if (tt == "Sắp hết")
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 240, 180);
                    else
                        row.DefaultCellStyle.BackColor = Color.FromArgb(200, 240, 200);
                }
            }
        }

        private void txtTimKiem_KeyUp(object sender, KeyEventArgs e)
        {
            string kw = txtTimKiem.Text.Trim().ToLower();
            DataTable dt = inventoryBUS.LayTonKho();
            DataView dv = new DataView(dt);
            dv.RowFilter = $"ProductName LIKE '%{kw}%' OR ProductCode LIKE '%{kw}%'";
            dgvTonKho.DataSource = dv.ToTable();
            ToCauHinhMauHang();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (dgvTonKho.Rows.Count == 0) return;
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx", FileName = "BaoCaoTonKho.xlsx" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try {
                        using (var workbook = new ClosedXML.Excel.XLWorkbook()) {
                            var ws = workbook.Worksheets.Add("Inventory");
                            int colIdx = 1;
                            for (int i = 0; i < dgvTonKho.Columns.Count; i++)
                                if (dgvTonKho.Columns[i].Visible) {
                                    ws.Cell(1, colIdx).Value = dgvTonKho.Columns[i].HeaderText;
                                    colIdx++;
                                }
                            for (int i = 0; i < dgvTonKho.Rows.Count; i++) {
                                colIdx = 1;
                                for (int j = 0; j < dgvTonKho.Columns.Count; j++)
                                    if (dgvTonKho.Columns[j].Visible) {
                                        ws.Cell(i + 2, colIdx).Value = dgvTonKho.Rows[i].Cells[j].Value?.ToString();
                                        colIdx++;
                                    }
                            }
                            ws.Columns().AdjustToContents();
                            workbook.SaveAs(sfd.FileName);
                        }
                        MessageBox.Show("Xuất thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    } catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
                }
            }
        }

        private void btnTatCa_Click(object sender, EventArgs e) => HienThiTonKho("all");
        private void btnSapHet_Click(object sender, EventArgs e) => HienThiTonKho("low");

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

        private void dgvTonKho_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) { }
    }
}
