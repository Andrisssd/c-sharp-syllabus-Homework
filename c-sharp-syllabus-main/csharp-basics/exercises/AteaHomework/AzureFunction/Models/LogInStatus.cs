using Azure.Data.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Table;
using ITableEntity = Microsoft.WindowsAzure.Storage.Table.ITableEntity;
using Microsoft.WindowsAzure.Storage;

namespace Models
{
    public class LogInStatus : ITableEntity
    {
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public DateTimeOffset Timestamp { get; set; }
        public string ETag { get; set; }

        public LogInStatus(string partitionKey, string rowKey, DateTimeOffset timestamp, string ETag)
        {
            PartitionKey = partitionKey;
            RowKey = rowKey;
            Timestamp = timestamp;
            this.ETag = ETag;
        }

        public void ReadEntity(IDictionary<string, EntityProperty> properties, OperationContext operationContext)
        {
            throw new NotImplementedException();
        }

        public IDictionary<string, EntityProperty> WriteEntity(OperationContext operationContext)
        {
            throw new NotImplementedException();
        }
    }
}
