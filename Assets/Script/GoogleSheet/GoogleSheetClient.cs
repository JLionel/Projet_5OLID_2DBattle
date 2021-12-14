using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using Google.Apis.Util.Store;
using UnityEngine;

public class GoogleSheetClient : ScriptableObject
{
    
    private static string[] Scopes = { SheetsService.Scope.SpreadsheetsReadonly };
    private UserCredential userCredential;
    private bool connected;

    [ContextMenu("Connect")]
    public async  void Connect()
    {
        Debug.Log("Connect to sheet");
        connected = await ConnectToSheet();
        Debug.Log($"Connected to sheet {connected}");
    }
    
    public async Task<bool> ConnectToSheet()
    {
        using (var stream =
            new FileStream("Assets/GoogleSheetInfo/credentials.json", FileMode.Open, FileAccess.Read))
        {
            GoogleClientSecrets clientSecrets = await GoogleClientSecrets.FromStreamAsync(stream);
            
            // The file token.json stores the user's access and refresh tokens, and is created
            // automatically when the authorization flow completes for the first time.
            string credPath = "Assets/GoogleSheetInfo/token.json";
            userCredential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                clientSecrets.Secrets,
                Scopes,
                "user",
                CancellationToken.None,
                new FileDataStore(credPath, true)).Result;
            Debug.Log("Credential file saved to: " + credPath);
        }

        return true;
    }
}
