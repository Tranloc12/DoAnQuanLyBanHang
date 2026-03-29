using System;
using System.Data;
using System.Windows.Forms;
using DoAnQuanLyBanHang.BUS;
using DoAnQuanLyBanHang.DTO;

namespace DoAnQuanLyBanHang
{
    public partial class frmNhanVien : Form
    {
        private readonly UserBUS userBUS = new UserBUS();
        private int bien = 0;

        public frmNhanVien()
        {
            InitializeComponent();
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            // Chỉ Admin mới được vào màn hình này
            if (SessionUser.CurrentUser?.Role != "Admin")
            {
                MessageBox.Show("Bạn không có quyền truy cập!", "Từ chối", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }
            cbQuyen.Items.AddRange(new string[] { "Admin", "Staff" });
            cbQuyen.SelectedIndex = 1;
            HienThiDanhSach();
            SetControls(false);
        }

        private void HienThiDanhSach()
        {
            dgvNhanVien.DataSource = userBUS.LayDanhSachNhanVien();
            if (dgvNhanVien.Columns["PasswordHash"] != null)
                dgvNhanVien.Columns["PasswordHash"].Visible = false;
        }

        private void SetControls(bool edit)
        {
            txtTenDangNhap.Enabled = edit && (bien == 1);
            txtMatKhau.Enabled     = edit;
            txtHoTen.Enabled       = edit;
            txtEmail.Enabled       = edit;
            txtSDT.Enabled         = edit;
            cbQuyen.Enabled        = edit;

            btnThem.Enabled = !edit;
            btnSua.Enabled  = !edit;
            btnXoa.Enabled  = !edit;
            btnLuu.Enabled  = edit;
            btnHuy.Enabled  = edit;
        }

        private void XoaForm()
        {
            txtTenDangNhap.Clear(); txtMatKhau.Clear();
            txtHoTen.Clear(); txtEmail.Clear(); txtSDT.Clear();
            cbQuyen.SelectedIndex = 1;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            XoaForm(); bien = 1; SetControls(true); txtTenDangNhap.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvNhanVien.CurrentRow == null) return;
            bien = 2; SetControls(true); txtHoTen.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvNhanVien.CurrentRow == null) return;
            int id = Convert.ToInt32(dgvNhanVien.CurrentRow.Cells["UserID"].Value);
            if (id == SessionUser.CurrentUser?.UserID)
            {
                MessageBox.Show("Không thể xóa tài khoản đang đăng nhập!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("Bạn có chắc muốn xóa nhân viên này khỏi hệ thống?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (userBUS.XoaNhanVien(id))
                {
                    MessageBox.Show("Xóa thành công!");
                    HienThiDanhSach();
                }
                else MessageBox.Show("Không thể xóa hoàn toàn (đã có dữ liệu liên quan), nhân viên sẽ bị vô hiệu hóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            { MessageBox.Show("Vui lòng nhập Họ tên!"); return; }

            bool ketQua = false;
            if (bien == 1) // Thêm mới
            {
                if (string.IsNullOrWhiteSpace(txtTenDangNhap.Text) || string.IsNullOrWhiteSpace(txtMatKhau.Text))
                { MessageBox.Show("Vui lòng nhập Tên đăng nhập và Mật khẩu!"); return; }

                UserDTO user = new UserDTO
                {
                    UserName = txtTenDangNhap.Text.Trim(),
                    FullName = txtHoTen.Text.Trim(),
                    Email    = txtEmail.Text.Trim(),
                    Phone    = txtSDT.Text.Trim(),
                    Role     = cbQuyen.Text
                };
                ketQua = userBUS.ThemNhanVien(user, txtMatKhau.Text.Trim());
                if (!ketQua) { MessageBox.Show("Tên đăng nhập đã tồn tại hoặc thêm thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            }
            else if (bien == 2) // Sửa
            {
                UserDTO user = new UserDTO
                {
                    UserID   = Convert.ToInt32(dgvNhanVien.CurrentRow.Cells["UserID"].Value),
                    FullName = txtHoTen.Text.Trim(),
                    Email    = txtEmail.Text.Trim(),
                    Phone    = txtSDT.Text.Trim(),
                    Role     = cbQuyen.Text
                };
                ketQua = userBUS.SuaNhanVien(user);

                // Nếu có nhập mật khẩu mới vào ô mật khẩu thì tiến hành đổi luôn
                if (ketQua && !string.IsNullOrWhiteSpace(txtMatKhau.Text))
                {
                    userBUS.DoiMatKhau(user.UserID, txtMatKhau.Text.Trim());
                }
            }

            if (ketQua)
            {
                MessageBox.Show("Lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                HienThiDanhSach(); SetControls(false);
            }
            else MessageBox.Show("Lưu thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnHuy_Click(object sender, EventArgs e) => SetControls(false);

        private void dgvNhanVien_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;
            if (r < 0 || r >= dgvNhanVien.Rows.Count) return;
            try
            {
                var row = dgvNhanVien.Rows[r];
                txtTenDangNhap.Text = row.Cells["UserName"].Value?.ToString();
                txtHoTen.Text       = row.Cells["FullName"].Value?.ToString();
                txtEmail.Text       = row.Cells["Email"].Value?.ToString();
                txtSDT.Text         = row.Cells["Phone"].Value?.ToString();
                cbQuyen.Text        = row.Cells["Role"].Value?.ToString();
                txtMatKhau.Text     = "";
            }
            catch { }
        }
    }
}
