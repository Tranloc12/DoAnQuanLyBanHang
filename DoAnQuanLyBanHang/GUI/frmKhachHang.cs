using System;
using System.Data;
using System.Windows.Forms;
using DoAnQuanLyBanHang.BUS;
using DoAnQuanLyBanHang.DTO;

namespace DoAnQuanLyBanHang
{
    public partial class frmKhachHang : Form
    {
        private readonly CustomerBUS customerBUS = new CustomerBUS();
        private int bien = 0;

        public frmKhachHang()
        {
            InitializeComponent();
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            HienThiDanhSach();
            SetControls(false);
        }

        private void HienThiDanhSach()
        {
            dgvKhachHang.DataSource = customerBUS.LayDanhSachKhachHang();
            if (dgvKhachHang.Columns["CustomerID"] != null)
                dgvKhachHang.Columns["CustomerID"].Visible = false;
        }

        private void SetControls(bool edit)
        {
            txtTenKH.Enabled  = edit;
            txtSDT.Enabled    = edit && (bien == 1); // SĐT chỉ nhập khi Thêm
            txtEmail.Enabled  = edit;
            txtDiaChi.Enabled = edit;

            btnThem.Enabled = !edit;
            btnSua.Enabled  = !edit;
            btnXoa.Enabled  = !edit;
            btnLuu.Enabled  = edit;
            btnHuy.Enabled  = edit;
        }

        private void XoaForm()
        {
            txtTenKH.Clear();
            txtSDT.Clear();
            txtEmail.Clear();
            txtDiaChi.Clear();
        }

        private bool KiemTraNhap()
        {
            if (string.IsNullOrWhiteSpace(txtTenKH.Text))
            {
                MessageBox.Show("Vui lòng nhập Tên khách hàng!", "Thiếu thông tin",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtSDT.Text) || txtSDT.Text.Length < 9)
            {
                MessageBox.Show("Số điện thoại không hợp lệ!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            XoaForm();
            bien = 1;
            SetControls(true);
            txtTenKH.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvKhachHang.CurrentRow == null) return;
            bien = 2;
            SetControls(true);
            txtSDT.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvKhachHang.CurrentRow == null) return;
            int id = Convert.ToInt32(dgvKhachHang.CurrentRow.Cells["CustomerID"].Value);

            if (MessageBox.Show("Bạn có chắc muốn xóa khách hàng này?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (customerBUS.XoaKhachHang(id))
                {
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HienThiDanhSach();
                }
                else
                    MessageBox.Show("Xóa thất bại! Khách hàng có thể đang có đơn hàng.", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!KiemTraNhap()) return;

            CustomerDTO kh = new CustomerDTO
            {
                CustomerName = txtTenKH.Text.Trim(),
                Phone        = txtSDT.Text.Trim(),
                Email        = txtEmail.Text.Trim(),
                Address      = txtDiaChi.Text.Trim()
            };

            bool ketQua = false;
            if (bien == 1)
            {
                ketQua = customerBUS.ThemKhachHang(kh);
                if (!ketQua) { MessageBox.Show("SĐT đã tồn tại hoặc thêm thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            }
            else if (bien == 2)
            {
                kh.CustomerID = Convert.ToInt32(dgvKhachHang.CurrentRow.Cells["CustomerID"].Value);
                ketQua = customerBUS.SuaKhachHang(kh);
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

        private void btnHuy_Click(object sender, EventArgs e) => SetControls(false);

        private void dgvKhachHang_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;
            if (r < 0 || r >= dgvKhachHang.Rows.Count) return;
            var row = dgvKhachHang.Rows[r];
            try
            {
                txtTenKH.Text  = row.Cells["CustomerName"].Value?.ToString();
                txtSDT.Text    = row.Cells["Phone"].Value?.ToString();
                txtEmail.Text  = row.Cells["Email"].Value?.ToString();
                txtDiaChi.Text = row.Cells["Address"].Value?.ToString();
            }
            catch { }
        }

        private void txtTimKiem_KeyUp(object sender, KeyEventArgs e)
        {
            string kw = txtTimKiem.Text.Trim();
            dgvKhachHang.DataSource = string.IsNullOrEmpty(kw)
                ? customerBUS.LayDanhSachKhachHang()
                : customerBUS.TimKiemKhachHang(kw);
        }
    }
}
