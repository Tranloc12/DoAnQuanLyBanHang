using System;
using System.Data;
using System.Windows.Forms;
using DoAnQuanLyBanHang.BUS;
using DoAnQuanLyBanHang.DTO;
using ClosedXML.Excel;
using System.IO;

namespace DoAnQuanLyBanHang
{
    public partial class frmSanPham : Form
    {
        private readonly ProductBUS productBUS = new ProductBUS();
        private int bien = 0; // 1 = Thêm, 2 = Sửa

        private string searchKeyword = "";

        public frmSanPham()
        {
            InitializeComponent();
        }

        public frmSanPham(string keyword) : this()
        {
            this.searchKeyword = keyword;
        }

        private void frmSanPham_Load(object sender, EventArgs e)
        {
            NapComboBox();
            HienThiDanhSach();
            SetControls(false);

            if (!string.IsNullOrEmpty(searchKeyword))
            {
                txtTimKiem.Text = searchKeyword;
                ThucHienTimKiem(searchKeyword);
            }
        }

        private void ThucHienTimKiem(string kw)
        {
            dgvSanPham.DataSource = productBUS.TimKiemSanPham(kw);
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (dgvSanPham.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel Workbook|*.xlsx";
                sfd.FileName = "DanhSachSanPham_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (var workbook = new XLWorkbook())
                        {
                            var worksheet = workbook.Worksheets.Add("Products");

                            // Xuất tiêu đề cột
                            for (int i = 0; i < dgvSanPham.Columns.Count; i++)
                            {
                                if (dgvSanPham.Columns[i].Visible)
                                {
                                    worksheet.Cell(1, i + 1).Value = dgvSanPham.Columns[i].HeaderText;
                                    worksheet.Cell(1, i + 1).Style.Font.Bold = true;
                                    worksheet.Cell(1, i + 1).Style.Fill.BackgroundColor = XLColor.LightGray;
                                }
                            }

                            // Xuất dữ liệu
                            for (int i = 0; i < dgvSanPham.Rows.Count; i++)
                            {
                                for (int j = 0; j < dgvSanPham.Columns.Count; j++)
                                {
                                    if (dgvSanPham.Columns[j].Visible)
                                    {
                                        worksheet.Cell(i + 2, j + 1).Value = dgvSanPham.Rows[i].Cells[j].Value?.ToString();
                                    }
                                }
                            }

                            worksheet.Columns().AdjustToContents();
                            workbook.SaveAs(sfd.FileName);
                        }
                        MessageBox.Show("Xuất Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xuất Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // ──────────────── Hiển thị ────────────────
        private void HienThiDanhSach()
        {
            dgvSanPham.DataSource = productBUS.LayDanhSachSanPham();
            dgvSanPham.Columns["ProductID"].Visible   = false;
            dgvSanPham.Columns["CategoryID"].Visible  = false;
            dgvSanPham.Columns["SupplierID"].Visible  = false;
            dgvSanPham.Columns["IsActive"].Visible    = false;
        }

        private void NapComboBox()
        {
            // Danh mục
            DataTable dtCat = productBUS.LayDanhMuc();
            cbDanhMuc.DataSource    = dtCat;
            cbDanhMuc.DisplayMember = "CategoryName";
            cbDanhMuc.ValueMember   = "CategoryID";

            // Nhà cung cấp
            DataTable dtSup = productBUS.LayNhaCungCap();
            cbNhaCungCap.DataSource    = dtSup;
            cbNhaCungCap.DisplayMember = "SupplierName";
            cbNhaCungCap.ValueMember   = "SupplierID";
        }

        private void SetControls(bool edit)
        {
            txtMaSP.Enabled       = edit && (bien == 1); // Chỉ cho nhập mã khi Thêm
            txtTenSP.Enabled      = edit;
            cbDanhMuc.Enabled     = edit;
            cbNhaCungCap.Enabled  = edit;
            txtGiaNhap.Enabled    = edit;
            txtGiaBan.Enabled     = edit;
            txtSoLuong.Enabled    = edit;
            txtSoLuongMin.Enabled = edit;
            txtDonVi.Enabled      = edit;

            btnThem.Enabled   = !edit;
            btnSua.Enabled    = !edit;
            btnXoa.Enabled    = !edit;
            btnLuu.Enabled    = edit;
            btnHuy.Enabled    = edit;
            btnExcel.Enabled  = !edit;
        }

        private void XoaForm()
        {
            txtMaSP.Clear();
            txtTenSP.Clear();
            txtGiaNhap.Clear();
            txtGiaBan.Clear();
            txtSoLuong.Clear();
            txtSoLuongMin.Clear();
            txtDonVi.Clear();
            if (cbDanhMuc.Items.Count > 0)    cbDanhMuc.SelectedIndex   = 0;
            if (cbNhaCungCap.Items.Count > 0) cbNhaCungCap.SelectedIndex = 0;
        }

        private bool KiemTraNhap()
        {
            if (string.IsNullOrWhiteSpace(txtMaSP.Text) ||
                string.IsNullOrWhiteSpace(txtTenSP.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã SP và Tên SP!", "Thiếu thông tin",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!decimal.TryParse(txtGiaNhap.Text, out decimal gn) || gn < 0 ||
                !decimal.TryParse(txtGiaBan.Text,  out decimal gb) || gb < 0)
            {
                MessageBox.Show("Giá nhập / giá bán phải là số không âm!", "Lỗi nhập liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!int.TryParse(txtSoLuong.Text,    out int sl) || sl < 0 ||
                !int.TryParse(txtSoLuongMin.Text,  out int mn) || mn < 0)
            {
                MessageBox.Show("Số lượng phải là số không âm!", "Lỗi nhập liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        // ──────────────── Sự kiện nút ────────────────
        private void btnThem_Click(object sender, EventArgs e)
        {
            XoaForm();
            bien = 1;
            SetControls(true);
            txtMaSP.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvSanPham.CurrentRow == null) return;
            bien = 2;
            SetControls(true);
            txtMaSP.Enabled = false;
            txtTenSP.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvSanPham.CurrentRow == null) return;
            int id = Convert.ToInt32(dgvSanPham.CurrentRow.Cells["ProductID"].Value);

            if (MessageBox.Show("Bạn có chắc muốn xóa sản phẩm này?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (productBUS.XoaSanPham(id))
                {
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HienThiDanhSach();
                }
                else
                    MessageBox.Show("Xóa thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!KiemTraNhap()) return;

            ProductDTO sp = new ProductDTO
            {
                ProductCode = txtMaSP.Text.Trim(),
                ProductName = txtTenSP.Text.Trim(),
                CategoryID  = Convert.ToInt32(cbDanhMuc.SelectedValue),
                SupplierID  = Convert.ToInt32(cbNhaCungCap.SelectedValue),
                CostPrice   = decimal.Parse(txtGiaNhap.Text),
                SellPrice   = decimal.Parse(txtGiaBan.Text),
                Quantity    = int.Parse(txtSoLuong.Text),
                MinQuantity = int.Parse(txtSoLuongMin.Text),
                Unit        = txtDonVi.Text.Trim()
            };

            bool ketQua = false;
            if (bien == 1)
            {
                ketQua = productBUS.ThemSanPham(sp);
                if (!ketQua)
                {
                    MessageBox.Show("Thêm thất bại! Mã SP có thể đã tồn tại.", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else if (bien == 2)
            {
                sp.ProductID = Convert.ToInt32(dgvSanPham.CurrentRow.Cells["ProductID"].Value);
                ketQua = productBUS.SuaSanPham(sp);
            }

            if (ketQua)
            {
                MessageBox.Show("Lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                HienThiDanhSach();
                SetControls(false);
            }
            else
                MessageBox.Show("Lưu thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            SetControls(false);
        }

        private void dgvSanPham_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;
            if (r < 0 || r >= dgvSanPham.Rows.Count) return;
            var row = dgvSanPham.Rows[r];
            try
            {
                txtMaSP.Text        = row.Cells["ProductCode"].Value?.ToString();
                txtTenSP.Text       = row.Cells["ProductName"].Value?.ToString();
                txtGiaNhap.Text     = row.Cells["CostPrice"].Value?.ToString();
                txtGiaBan.Text      = row.Cells["SellPrice"].Value?.ToString();
                txtSoLuong.Text     = row.Cells["Quantity"].Value?.ToString();
                txtSoLuongMin.Text  = row.Cells["MinQuantity"].Value?.ToString();
                txtDonVi.Text       = row.Cells["Unit"].Value?.ToString();
                cbDanhMuc.Text      = row.Cells["CategoryName"].Value?.ToString();
                cbNhaCungCap.Text   = row.Cells["SupplierName"].Value?.ToString();
            }
            catch { }
        }

        private void txtTimKiem_KeyUp(object sender, KeyEventArgs e)
        {
            string kw = txtTimKiem.Text.Trim();
            dgvSanPham.DataSource = string.IsNullOrEmpty(kw)
                ? productBUS.LayDanhSachSanPham()
                : productBUS.TimKiemSanPham(kw);
        }
    }
}
