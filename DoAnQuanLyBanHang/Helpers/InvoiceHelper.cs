using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using DoAnQuanLyBanHang.DTO;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace DoAnQuanLyBanHang.Helpers
{
    public static class InvoiceHelper
    {
        public static void GenerateAndShowInvoice(OrderDTO order, List<OrderDetailDTO> details, string customerName, string employeeName)
        {
            // Set license type to Community (free for <$1M revenue)
            QuestPDF.Settings.License = LicenseType.Community;

            string fileName = $"Invoice_{order.OrderCode}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
            string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Invoices");
            
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            string filePath = Path.Combine(folderPath, fileName);

            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(11).FontFamily("Arial"));

                    page.Header().Element(ComposeHeader);
                    page.Content().Element(x => ComposeContent(x, order, details, customerName, employeeName));
                    page.Footer().Element(ComposeFooter);
                });
            })
            .GeneratePdf(filePath);

            // Open the generated PDF automatically
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = filePath,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine("Could not open PDF automatically: " + ex.Message);
            }
        }

        static void ComposeHeader(IContainer container)
        {
            container.Row(row =>
            {
                row.RelativeItem().Column(column =>
                {
                    column.Item().Text("HÓA ĐƠN BÁN HÀNG").FontSize(24).SemiBold().FontColor(Colors.Blue.Darken2);
                    column.Item().Text("Cửa hàng tiện lợi ABC").FontSize(14).Medium();
                    column.Item().Text("456 Đường Lê Lợi, TP. HCM");
                    column.Item().Text("Điện thoại: 0987.654.321");
                });
            });
        }

        static void ComposeContent(IContainer container, OrderDTO order, List<OrderDetailDTO> details, string customerName, string employeeName)
        {
            container.PaddingVertical(1, Unit.Centimetre).Column(column =>
            {
                column.Spacing(15);

                column.Item().Row(row =>
                {
                    row.RelativeItem().Column(col =>
                    {
                        col.Item().Text($"Khách hàng: {customerName}").Bold();
                        col.Item().Text($"Nhân viên bán: {employeeName}");
                        col.Item().Text($"Phương thức TT: {order.PaymentMethod}");
                    });

                    row.RelativeItem().Column(col =>
                    {
                        col.Item().Text($"Mã hóa đơn: {order.OrderCode}").AlignRight().Bold();
                        col.Item().Text($"Ngày lập: {DateTime.Now:dd/MM/yyyy HH:mm}").AlignRight();
                    });
                });

                column.Item().Element(x => ComposeTable(x, details));

                var totalPrice = order.TotalAmount;
                var discount = order.Discount;
                var finalAmount = order.FinalAmount;

                column.Item().AlignRight().Column(col => 
                {
                    col.Item().Text($"Tổng tiền: {totalPrice:N0} VNĐ").FontSize(12);
                    if (discount > 0)
                    {
                        col.Item().Text($"Giảm giá: -{discount:N0} VNĐ").FontSize(12).FontColor(Colors.Red.Medium);
                    }
                    col.Item().Text($"THANH TOÁN: {finalAmount:N0} VNĐ").FontSize(14).Bold().FontColor(Colors.Green.Darken2);
                });
                
                if (!string.IsNullOrEmpty(order.Notes))
                {
                     column.Item().PaddingTop(15).Text("Ghi chú: " + order.Notes).Italic();
                }
            });
        }

        static void ComposeTable(IContainer container, List<OrderDetailDTO> details)
        {
            container.Table(table =>
            {
                // step 1
                table.ColumnsDefinition(columns =>
                {
                    columns.ConstantColumn(30);
                    columns.RelativeColumn(3);
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                });

                // step 2
                table.Header(header =>
                {
                    header.Cell().Element(CellStyle).Text("STT");
                    header.Cell().Element(CellStyle).Text("Tên sản phẩm");
                    header.Cell().Element(CellStyle).AlignRight().Text("Số lượng");
                    header.Cell().Element(CellStyle).AlignRight().Text("Đơn giá");
                    header.Cell().Element(CellStyle).AlignRight().Text("Thành tiền");

                    static IContainer CellStyle(IContainer container)
                    {
                        return container.DefaultTextStyle(x => x.SemiBold()).PaddingVertical(5).BorderBottom(1).BorderColor(Colors.Black);
                    }
                });

                // step 3
                foreach (var item in details)
                {
                    table.Cell().Element(CellStyle).Text((details.IndexOf(item) + 1).ToString());
                    table.Cell().Element(CellStyle).Text(item.ProductName);
                    table.Cell().Element(CellStyle).AlignRight().Text(item.Quantity.ToString());
                    table.Cell().Element(CellStyle).AlignRight().Text($"{item.UnitPrice:N0}");
                    table.Cell().Element(CellStyle).AlignRight().Text($"{(item.Quantity * item.UnitPrice):N0}");

                    static IContainer CellStyle(IContainer container)
                    {
                        return container.BorderBottom(1).BorderColor(Colors.Grey.Lighten2).PaddingVertical(5);
                    }
                }
            });
        }

        static void ComposeFooter(IContainer container)
        {
            container.AlignCenter().Text(x =>
            {
                x.Span("Xin chân thành cảm ơn quý khách! ").FontSize(10);
            });
        }
    }
}
