using System;
using System.Drawing;
using System.Windows.Forms;
// Removed using DoAnQuanLyBanHang.Utils

namespace GUI_QuanLy
{
    public partial class frmPaymentQR : Form
    {
        private string email = "loc.tran@example.com"; // Thay bằng email PayPal thật của bạn
        private decimal amount;
        private string orderCode;

        public frmPaymentQR(decimal totalVND, string orderCode)
        {
            InitializeComponent();
            this.amount = totalVND;
            this.orderCode = orderCode;
        }

        private void frmPaymentQR_Load(object sender, EventArgs e)
        {
            lblInfo.Text = $"Đơn hàng: {orderCode}\nSố tiền: {amount:N0} VNĐ";
            try
            {
                Bitmap? qr = PayPalHelper.TaoMaQRPayPal(email, amount, orderCode);
                if (qr != null)
                {
                    picQR.Image = qr;
                }
                else
                {
                    MessageBox.Show("Không thể tạo mã QR!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
