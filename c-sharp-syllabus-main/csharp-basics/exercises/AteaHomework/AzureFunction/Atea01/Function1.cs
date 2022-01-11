using System;
using System.IO;
using System.Net;
using System.Text;
using Azure.Storage.Blobs;
using Azure.Storage.Queues;
using Azure.Data.Tables;
using Azure.Data.Tables.Models;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Models;
using Newtonsoft.Json;
using Microsoft.Azure.Cosmos.Table;
using System.Net.Http;
using ITableEntity = Microsoft.Azure.Cosmos.Table.ITableEntity;

namespace Atea01
{
    public class Function1
    {
        private string _URL = @"https://api.publicapis.org/random?auth=null";

        [FunctionName("Function1")]
        public void Run([TimerTrigger("0 * * * * *")]TimerInfo myTimer, ILogger log)
        {
            string containerNameAndDateTime = "sample-container " + DateTime.Now;
            using (WebClient client = new WebClient())
            {
                bool connectionStatus = true;
                try
                {
                    HttpResponseMessage responseMessage = new HttpResponseMessage();

                    byte[] raw = client.DownloadData(_URL);
                    string webData = System.Text.Encoding.UTF8.GetString(raw);
                    Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(webData);
                    log.LogInformation("1");
                    BlobContainerClient container = new BlobContainerClient("UseDevelopmentStorage=true", "sample-container");
                    container.CreateIfNotExists();
                    BlobClient blobClient = container.GetBlobClient(containerNameAndDateTime);
                    using (var ms = new MemoryStream(raw))
                    {
                        blobClient.Upload(ms);
                    }

                    TableClient tableClient = new TableClient(new Uri("UseDevelopmentStorage=true"));
                    tableClient.CreateIfNotExists();
                    string statusCode = responseMessage.StatusCode.ToString();
                    int statusCodeInt = (int)responseMessage.StatusCode;
                    Console.WriteLine(statusCodeInt);
                    //tableClient.AddEntity((ITableEntity)new LogInStatus(statusCode, statusCodeInt));
                    tableClient.AddEntity(new LogInStatus(statusCode,statusCodeInt));
                }
                catch
                {
                    connectionStatus = false;
                }
            }
        }
    }
}
