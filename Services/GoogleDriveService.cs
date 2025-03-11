using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using System.IO;
using System.Threading.Tasks;
using GoogleFile = Google.Apis.Drive.v3.Data.File;

public class GoogleDriveService
{
    private static readonly string[] Scopes = { DriveService.Scope.DriveFile };
    private static readonly string ApplicationName = "Spanish";
    private DriveService _service;

    public GoogleDriveService()
    {
        InitializeService();
    }

    [Obsolete]
    private void InitializeService()
    {
        UserCredential credential;
        using (var stream = new FileStream("client_secrets.json", FileMode.Open, FileAccess.Read))
        {
            credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                GoogleClientSecrets.Load(stream).Secrets,
                Scopes,
                "user",
                CancellationToken.None,
                null,
                new LocalServerCodeReceiver()).Result;
        }

        _service = new DriveService(new BaseClientService.Initializer()
        {
            HttpClientInitializer = credential,
            ApplicationName = ApplicationName,
        });
    }

    public async Task<string> UploadFileAsync(Stream fileStream, string fileName, string mimeType)
    {
        var fileMetadata = new GoogleFile()
        {
            Name = fileName
        };

        FilesResource.CreateMediaUpload request;
        request = _service.Files.Create(fileMetadata, fileStream, mimeType);
        request.Fields = "id";
        await request.UploadAsync();

        var file = request.ResponseBody;
        return $"https://drive.google.com/uc?id={file.Id}";
    }

    public DriveService GetService()
    {
        return _service;
    }
}
