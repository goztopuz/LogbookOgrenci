using Azure.Storage.Blobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ogrenci4.src.Services
{
    public class UploadFileService
    {

        string connectionString = "DefaultEndpointsProtocol=https;AccountName=bulutarge;AccountKey=FqP4BZn346LzqVh1hmbjcrqK0yMMCooqUsKOUc/Wt+jSMQRm0stUIRaKPU4dNnaYFmu5lnuNsoDI+AStGGoQww==;EndpointSuffix=core.windows.net";
        string containerName = "bulutargedosyalar";



        public void FileUpload(string _filePath, string _blobName)
        {
            BlobContainerClient container = new BlobContainerClient(connectionString, containerName);
            container.CreateIfNotExists();

            // Upload a few blobs so we have something to list
            container.UploadBlob(_blobName, File.OpenRead(_filePath));

        }

    }
}
