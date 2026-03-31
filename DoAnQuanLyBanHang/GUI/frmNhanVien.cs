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

            // 1. Kiểm tra Email format cơ bản
            string email = txtEmail.Text.Trim();
            if (!string.IsNullOrEmpty(email) && (!email.Contains("@") || !email.Contains(".")))
            {
                MessageBox.Show("Định dạng Email không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }

            // 2. Kiểm tra SĐT (chỉ là số)
            string phone = txtSDT.Text.Trim();
            if (!string.IsNullOrEmpty(phone) && !System.Text.RegularExpressions.Regex.IsMatch(phone, "^[0-9]+$"))
            {
                MessageBox.Show("Số điện thoại chỉ được chứa ký số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }

            // 3. Kiểm tra tính duy nhất (Validate ở GUI để đưa ra thông báo cụ thể)
            int currentId = (bien == 2 && dgvNhanVien.CurrentRow != null) 
                            ? Convert.ToInt32(dgvNhanVien.CurrentRow.Cells["UserID"].Value) : 0;

            if (bien == 1 && userBUS.KiemTraUserName(txtTenDangNhap.Text.Trim()))
            {
                MessageBox.Show("Tên đăng nhập này đã tồn tại!", "Trùng lặp", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }
            // Gọi DAL trực tiếp thông qua BUS hoặc thêm hàm vào BUS. Ở đây ta thêm logic vào BUS là chuẩn nhất.
            // Để đơn giản, ta sẽ dựa vào kết quả trả về của BUS. Nhưng BUS hiện tại chỉ trả về bool.
            // Để tốt nhất, ta check trực tiếp qua 1 helper hoặc bổ sung BUS.
            
            UserDTO user = new UserDTO
            {
                UserID   = currentId,
                UserName = txtTenDangNhap.Text.Trim(),
                FullName = txtHoTen.Text.Trim(),
                Email    = email,
                Phone    = phone,
                Role     = cbQuyen.Text
            };

            bool ketQua = false;
            if (bien == 1) // Thêm mới
            {
                if (string.IsNullOrWhiteSpace(user.UserName) || string.IsNullOrWhiteSpace(txtMatKhau.Text))
                { MessageBox.Show("Vui lòng nhập Tên đăng nhập và Mật khẩu!"); return; }

                ketQua = userBUS.ThemNhanVien(user, txtMatKhau.Text.Trim());
            }
            else if (bien == 2) // Sửa
            {
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
            else 
            {
                MessageBox.Show("Lưu thất bại! Có thể do trùng Tên đăng nhập, Email hoặc Số điện thoại với nhân viên khác.", 
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
