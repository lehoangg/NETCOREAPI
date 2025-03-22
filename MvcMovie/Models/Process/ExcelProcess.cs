using System;
using System.Data;
using System.IO;
using OfficeOpenXml;

namespace MvcMovie.Models.Process
{
    public class ExcelProcess
    {
        public DataTable ExcelToDataTable(string filePath)
        {
            DataTable dt = new DataTable();
            try
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial; // Chỉ định giấy phép sử dụng

                using (var package = new ExcelPackage(new FileInfo(filePath)))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0]; // Lấy sheet đầu tiên
                    if (worksheet == null)
                    {
                        throw new Exception("No worksheet found in Excel file.");
                    }

                    int colCount = worksheet.Dimension.End.Column; // Số cột
                    int rowCount = worksheet.Dimension.End.Row;   // Số dòng

                    // Thêm cột vào DataTable (lấy từ dòng đầu tiên)
                    for (int col = 1; col <= colCount; col++)
                    {
                        dt.Columns.Add(worksheet.Cells[1, col].Value?.ToString() ?? $"Column{col}");
                    }

                    // Đọc dữ liệu từ dòng thứ 2 trở đi
                    for (int row = 2; row <= rowCount; row++)
                    {
                        DataRow dr = dt.NewRow();
                        for (int col = 1; col <= colCount; col++)
                        {
                            dr[col - 1] = worksheet.Cells[row, col].Value?.ToString() ?? string.Empty;
                        }
                        dt.Rows.Add(dr);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error while processing Excel file: " + ex.Message);
            }
            return dt;
        }
    }
}
