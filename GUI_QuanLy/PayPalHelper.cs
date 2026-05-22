using System;
using System.Drawing;
using ZXing;
using ZXing.Common;
using ZXing.Windows.Compatibility;

namespace GUI_QuanLy
{
    public class PayPalHelper
    {
        public static Bitmap? TaoMaQRPayPal(string email, decimal amountVnd, string orderCode)
        {
            try
            {
                // Convert VND to USD (approximate rate, e.g., 25000 VND = 1 USD)
                decimal amountUsd = amountVnd / 25000;
                string paypalUrl = $"https://www.paypal.com/cgi-bin/webscr?cmd=_xclick&business={email}&amount={amountUsd:F2}&currency_code=USD&item_name={orderCode}";

                BarcodeWriter writer = new BarcodeWriter
                {
                    Format = BarcodeFormat.QR_CODE,
                    Options = new EncodingOptions
                    {
                        Height = 250,
                        Width = 250,
                        Margin = 1
                    }
                };

                return writer.Write(paypalUrl);
            }
            catch
            {
                return null;
            }
        }
    }
}
