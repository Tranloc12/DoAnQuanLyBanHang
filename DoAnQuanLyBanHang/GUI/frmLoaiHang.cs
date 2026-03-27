using System;
using System.Data;
using System.Windows.Forms;
using DoAnQuanLyBanHang.BUS;

namespace DoAnQuanLyBanHang
{
    public partial class frmLoaiHang : Form
    {
        private readonly CategoryBUS categoryBUS = new CategoryBUS();
        private int bien = 0;

        public frmLoaiHang() { InitializeComponent(); }

        private void frmLoaiHang_Load(object sender, EventArgs e) { HienThiDanhSach(); SetControls(false); }

        private void HienThiDanhSach()
        {
            dgvLoaiHang.DataSource = categoryBUS.LayDanhSachLoaiHang();
            if (dgvLoaiHang.Columns["CategoryID"] != null)
                dgvLoaiHang.Columns["CategoryID"].Visible = false;
        }

        private void SetControls(bool edit)
        {
            txtTenLoai.Enabled = edit;
            txtMoTa.Enabled    = edit;
            btnThem.Enabled    = !edit;
            btnSua.Enabled     = !edit;
            btnXoa.Enabled     = !edit;
            btnLuu.Enabled     = edit;
            btnHuy.Enabled     = edit;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtTenLoai.Clear(); txtMoTa.Clear();
            bien = 1; SetControls(true); txtTenLoai.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvLoaiHang.CurrentRow == null) return;
            bien = 2; SetControls(true); txtTenLoai.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvLoaiHang.CurrentRow == null) return;
            int id = Convert.ToInt32(dgvLoaiHang.CurrentRow.Cells["CategoryID"].Value);
            if (MessageBox.Show("Xóa loại hàng này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (categoryBUS.XoaLoaiHang(id))
                { MessageBox.Show("Xóa thành công!"); HienThiDanhSach(); }
                else
                    MessageBox.Show("Không thể xóa! Loại hàng đang có sản phẩm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenLoai.Text)) { MessageBox.Show("Vui lòng nhập tên loại hàng!"); return; }
            bool ketQua = false;
            if (bien == 1)
            {
                ketQua = categoryBUS.ThemLoaiHang(txtTenLoai.Text.Trim(), txtMoTa.Text.Trim());
                if (!ketQua) { MessageBox.Show("Tên loại đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            }
            else if (bien == 2)
            {
                int id = Convert.ToInt32(dgvLoaiHang.CurrentRow.Cells["CategoryID"].Value);
                ketQua = categoryBUS.SuaLoaiHang(id, txtTenLoai.Text.Trim(), txtMoTa.Text.Trim());
            }
            if (ketQua) { MessageBox.Show("Lưu thành công!"); HienThiDanhSach(); SetControls(false); }
            else MessageBox.Show("Lưu thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnHuy_Click(object sender, EventArgs e) => SetControls(false);

        private void dgvLoaiHang_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;
            if (r < 0 || r >= dgvLoaiHang.Rows.Count) return;
            try
            {
                txtTenLoai.Text = dgvLoaiHang.Rows[r].Cells["CategoryName"].Value?.ToString();
                txtMoTa.Text    = dgvLoaiHang.Rows[r].Cells["Description"].Value?.ToString();
            }
            catch { }
        }
    }
}
