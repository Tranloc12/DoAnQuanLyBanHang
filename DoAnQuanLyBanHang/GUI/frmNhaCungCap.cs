using System;
using System.Data;
using System.Windows.Forms;
using DoAnQuanLyBanHang.BUS;

namespace DoAnQuanLyBanHang
{
    public partial class frmNhaCungCap : Form
    {
        private readonly SupplierBUS supplierBUS = new SupplierBUS();
        private int bien = 0;

        public frmNhaCungCap() { InitializeComponent(); }
        private void frmNhaCungCap_Load(object sender, EventArgs e) { HienThiDanhSach(); SetControls(false); }

        private void HienThiDanhSach()
        {
            dgvNCC.DataSource = supplierBUS.LayDanhSachNhaCungCap();
            if (dgvNCC.Columns["SupplierID"] != null)
                dgvNCC.Columns["SupplierID"].Visible = false;
        }

        private void SetControls(bool edit)
        {
            txtTen.Enabled = txtSDT.Enabled = txtDiaChi.Enabled = edit;
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = !edit;
            btnLuu.Enabled  = btnHuy.Enabled = edit;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtTen.Clear(); txtSDT.Clear(); txtDiaChi.Clear();
            bien = 1; SetControls(true); txtTen.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvNCC.CurrentRow == null) return;
            bien = 2; SetControls(true); txtTen.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvNCC.CurrentRow == null) return;
            int id = Convert.ToInt32(dgvNCC.CurrentRow.Cells["SupplierID"].Value);
            if (MessageBox.Show("Xóa nhà cung cấp này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (supplierBUS.XoaNhaCungCap(id))
                { MessageBox.Show("Xóa thành công!"); HienThiDanhSach(); }
                else
                    MessageBox.Show("Không thể xóa! NCC đang có sản phẩm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTen.Text)) { MessageBox.Show("Vui lòng nhập tên nhà cung cấp!"); return; }
            bool ketQua = false;
            if (bien == 1)
            {
                ketQua = supplierBUS.ThemNhaCungCap(txtTen.Text.Trim(), txtSDT.Text.Trim(), txtDiaChi.Text.Trim());
                if (!ketQua) { MessageBox.Show("Tên NCC đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            }
            else if (bien == 2)
            {
                int id = Convert.ToInt32(dgvNCC.CurrentRow.Cells["SupplierID"].Value);
                ketQua = supplierBUS.SuaNhaCungCap(id, txtTen.Text.Trim(), txtSDT.Text.Trim(), txtDiaChi.Text.Trim());
            }
            if (ketQua) { MessageBox.Show("Lưu thành công!"); HienThiDanhSach(); SetControls(false); }
            else MessageBox.Show("Lưu thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnHuy_Click(object sender, EventArgs e) => SetControls(false);

        private void dgvNCC_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;
            if (r < 0 || r >= dgvNCC.Rows.Count) return;
            try
            {
                txtTen.Text    = dgvNCC.Rows[r].Cells["SupplierName"].Value?.ToString();
                txtSDT.Text    = dgvNCC.Rows[r].Cells["Phone"].Value?.ToString();
                txtDiaChi.Text = dgvNCC.Rows[r].Cells["Address"].Value?.ToString();
            }
            catch { }
        }
    }
}
