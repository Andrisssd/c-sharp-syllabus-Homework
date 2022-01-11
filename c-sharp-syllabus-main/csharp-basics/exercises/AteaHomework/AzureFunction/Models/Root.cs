using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure;
using Azure.Data.Tables;
using Azure.Data.Tables.Models;

namespace Models
{
    public class Root
    {
        public int count { get; set; }
        public List<Entry> entries { get; set; }
    }
}
