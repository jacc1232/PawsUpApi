using Azure.Storage.Blobs;

namespace PetsManagerApi.Helpers.Blob
{
    public class Blob
    {
        public async Task<string> UploadToBlobAsync(IFormFile file)
        {
            var blobServiceClient = new BlobServiceClient("DefaultEndpointsProtocol=https;AccountName=blobpetmanager;AccountKey=FooLpbwi1xew61RKfjx2Y5Xi0fjzst4FyFlgDCGsuK7EPUHsGkqzB4W7FJeH6GgSZ3royfquPytD+AStr9oFCA==;EndpointSuffix=core.windows.net");
            var containerClient = blobServiceClient.GetBlobContainerClient("pets-images");
            await containerClient.CreateIfNotExistsAsync();

            var blobClient = containerClient.GetBlobClient(file.FileName);

            using (var stream = file.OpenReadStream())
            {
                await blobClient.UploadAsync(stream, overwrite: true);
            }

            return blobClient.Uri.ToString();
        }
    }
}
