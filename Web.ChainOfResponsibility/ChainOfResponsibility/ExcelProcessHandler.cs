using ClosedXML.Excel;
using System.Data;

namespace Web.ChainOfResponsibility.ChainOfResponsibility
{
    public class ExcelProcessHandler<T>:ProcessHandler
    {

        public override object Handle(object o)
        {
            var wb = new XLWorkbook();
            var ds = new DataSet();
            var excelMemory = new MemoryStream();

            ds.Tables.Add(GetDataTable(o));
            wb.Worksheets.Add(ds);
            wb.SaveAs(excelMemory);

            return base.Handle(excelMemory);
        }


        private DataTable GetDataTable(object o)
        {
            var table = new DataTable();
            var type = typeof(T);
            var _list = o as List<T>;

            type.GetProperties().ToList().ForEach(x => { table.Columns.Add(x.Name, x.PropertyType); });

            _list.ForEach(x =>
            {
                var values = type.GetProperties().Select(propertyInfo => propertyInfo.GetValue(x, null)).ToArray();
                table.Rows.Add(values);
            });

            return table;
        }
    }
}
