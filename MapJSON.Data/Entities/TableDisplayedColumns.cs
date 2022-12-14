using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapJSON.Data.Entities
{
    public class TableDisplayedColumns
    {
        public string Table { get; set; }
        public List<TableColumn> Columns { get; set; }
    }
}
