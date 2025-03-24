using System;
using System.Collections.Generic;
using System.Data;
using Word = Microsoft.Office.Interop.Word;

namespace QLMamNon
{
    class WordExport
    {
        private Word.Application _app;
        Word.Document _doc;
        private object _pathFile;
        public WordExport(string vPath, bool vCreateApp)
        {
            _pathFile = vPath;
            _app = new Word.Application();
            _app.Visible = vCreateApp;
            object ob = System.Reflection.Missing.Value;
            _doc = _app.Documents.Add(ref _pathFile, ref ob, ref ob, ref ob);
        }
        public void WriteFields(Dictionary<string, string> vValues)
        {
            if (_doc.Fields.Count == 0)
            {
                throw new InvalidOperationException("No fields found in the document.");
            }
            foreach (Word.Field field in _doc.Fields)
            {
                string fieldName = field.Code.Text.Substring(11, field.Code.Text.IndexOf("\\") - 12).Trim();
                if (vValues.ContainsKey(fieldName))
                {
                    field.Select();
                    _app.Selection.TypeText(vValues[fieldName]);
                }
            }
        }

        //public void WriteTable(DataTable vDataTable, int vIndexTable)
        //{
        //    // Lấy bảng cuối trong tài liệu Word
        //    Word.Table tbl = _doc.Tables[_doc.Tables.Count];

        //    int lenrow = vDataTable.Rows.Count;
        //    int lencol = vDataTable.Columns.Count;

        //    // Đảm bảo bảng có đủ số hàng và cột
        //    while (tbl.Rows.Count < lenrow + 1) // +1 vì hàng đầu tiên thường là tiêu đề
        //    {
        //        tbl.Rows.Add();
        //    }
        //    while (tbl.Columns.Count < lencol)
        //    {
        //        tbl.Columns.Add();
        //    }

        //    // Điền dữ liệu vào bảng
        //    for (int i = 0; i < lenrow; ++i)
        //    {
        //        for (int j = 0; j < lencol; ++j)
        //        {
        //            string cellValue = vDataTable.Rows[i][j].ToString();

        //            // Kiểm tra xem giá trị có phải là số không
        //            if (decimal.TryParse(cellValue, out decimal moneyValue))
        //            {
        //                // Định dạng giá trị tiền
        //                cellValue = moneyValue.ToString("#,##0", System.Globalization.CultureInfo.InvariantCulture);
        //            }

        //            tbl.Cell(i + 2, j + 1).Range.Text = cellValue; // i + 2: bỏ qua tiêu đề
        //        }
        //    }
        //}


        public void WriteTable(DataTable vDataTable, int vIndexTable)
        {
            Word.Table tbl = _doc.Tables[vIndexTable];
            int lenrow = vDataTable.Rows.Count;
            int lencol = vDataTable.Columns.Count;

            // Đảm bảo bảng có đủ số hàng và cột
            while (tbl.Rows.Count < lenrow + 1) // +1 vì hàng đầu tiên thường là tiêu đề
            {
                tbl.Rows.Add();
            }
            while (tbl.Columns.Count < lencol)
            {
                tbl.Columns.Add();
            }

            // Điền dữ liệu vào bảng
            for (int i = 0; i < lenrow; ++i)
            {
                for (int j = 0; j < lencol; ++j)
                {
                    string cellValue = vDataTable.Rows[i][j].ToString();

                    // Kiểm tra xem giá trị có phải là số không
                    if (decimal.TryParse(cellValue, out decimal moneyValue))
                    {
                        // Định dạng giá trị tiền
                        cellValue = moneyValue.ToString("#,##0", System.Globalization.CultureInfo.InvariantCulture);
                    }

                    tbl.Cell(i + 2, j + 1).Range.Text = cellValue; // i + 2: bỏ qua tiêu đề
                }
            }
        }


        //public void WriteTable(DataTable vDataTable, int vIndexTable)
        //{
        //    Word.Table tbl = _doc.Tables[vIndexTable];
        //    int lenrow = vDataTable.Rows.Count;
        //    int lencol = vDataTable.Columns.Count;
        //    for (int i = 0; i < lenrow; ++i)
        //    {
        //        object ob = System.Reflection.Missing.Value;
        //        tbl.Rows.Add(ref ob);
        //        for (int j = 0; j < lencol; ++j)
        //        {
        //            string cellValue = vDataTable.Rows[i][j].ToString();

        //            // Kiểm tra xem giá trị có phải là số không
        //            if (decimal.TryParse(cellValue, out decimal moneyValue))
        //            {
        //                // Định dạng giá trị tiền
        //                cellValue = moneyValue.ToString("#,##0", System.Globalization.CultureInfo.InvariantCulture);
        //            }

        //            tbl.Cell(i + 2, j + 1).Range.Text = cellValue;
        //        }
        //    }
        //}
    }
}
