using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

public class GoogleSheetProgram : MonoBehaviour
{
    // If modifying these scopes, delete your previously saved credentials
    // at ~/.credentials/sheets.googleapis.com-dotnet-quickstart.json
    static string[] Scopes = { SheetsService.Scope.SpreadsheetsReadonly };
    static string ApplicationName = "Projet5 Groupe3 Data";

    void Start()
    {
        UserCredential credential;

        using (var stream =
            new FileStream("Assets/GoogleSheetInfo/credentials.json", FileMode.Open, FileAccess.Read))
        {
            // The file token.json stores the user's access and refresh tokens, and is created
            // automatically when the authorization flow completes for the first time.
            string credPath = "Assets/GoogleSheetInfo/token.json";
            credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                GoogleClientSecrets.Load(stream).Secrets,
                Scopes,
                "user",
                CancellationToken.None,
                new FileDataStore(credPath, true)).Result;
            Debug.Log("Credential file saved to: " + credPath);
        }

        // Create Google Sheets API service.
        var service = new SheetsService(new BaseClientService.Initializer()
        {
            HttpClientInitializer = credential,
            ApplicationName = ApplicationName,
        });

        // Define request parameters.
        String spreadsheetId = "16yNi5BqMcS1-dxvEcqpfvYAs-NGWg9OS6TCQbsL_mB8";
        String range = "Twitch Game Parameter!A2:E";
        SpreadsheetsResource.ValuesResource.GetRequest request =
                service.Spreadsheets.Values.Get(spreadsheetId, range);

        // Prints the names and majors of students in a sample spreadsheet:
        // https://docs.google.com/spreadsheets/d/16yNi5BqMcS1-dxvEcqpfvYAs-NGWg9OS6TCQbsL_mB8/edit#gid=0
        ValueRange response = request.Execute();
        IList<IList<object>> values = response.Values;
        if (values != null && values.Count > 0)
        {
            Debug.Log("SpreadSheet Data :");
            Debug.Log("DataName, Value");
            foreach (var row in values)
            {
                // Print columns A and E, which correspond to indices 0 and 4.
                Debug.Log($"{row[0]}, {row[1]}");
            }
        }
        else
        {
            Debug.Log("No data found.");
        }
    }
}
