using Azure.Data.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Table;
using TableEntity = Microsoft.WindowsAzure.Storage.Table.TableEntity;
using ITableEntity = Microsoft.WindowsAzure.Storage.Table.ITableEntity;

namespace Models
{
    public class LogInStatus : ITableEntity
    {
        public string GuidKey { get; set; }
        public string Status => RowKey;
        public string StatusCode { get; set; }
        public string Time => PartitionKey;

        public LogInStatus(string status, int statusCode)
        {
            PartitionKey = DateTime.Now.ToString();
            GuidKey = Guid.NewGuid().ToString();
            RowKey = status;
            StatusCode = statusCode.ToString();
        }

        public LogInStatus() { }

        public override string ToString()
        {
            return $"Status: {Status} Status code: {StatusCode} Request time: {Time} Guid: {GuidKey}";
        }
    }
}
