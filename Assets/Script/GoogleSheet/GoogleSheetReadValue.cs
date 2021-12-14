using System;
using System.Collections;
using System.Collections.Generic;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using UnityEngine;

public class GoogleSheetReadValue : MonoBehaviour
{
    [SerializeField] private string spreadSheetID;
    [SerializeField] private string rangeData;
    [SerializeField] private string sheetName;
    [SerializeField] private string applicationName;

    [SerializeField] private TupleSheetData sheetData;
    [SerializeField] private GoogleSheetClient userCredentials;

    [ContextMenu("ReadValue")]
    public async void Execute()
    {
        ReadValue();
    }
    
    
    public async void ReadValue()
    {  
        // Create Google Sheets API service.
        var service = new SheetsService(new BaseClientService.Initializer()
        {
            HttpClientInitializer = userCredentials.userCredential,
            ApplicationName = applicationName,
        });

        // Define request parameters.
        SpreadsheetsResource.ValuesResource.GetRequest request =
            service.Spreadsheets.Values.Get(spreadSheetID, $"{sheetName}{rangeData}");
        // Prints the names and majors of students in a sample spreadsheet:
        // https://docs.google.com/spreadsheets/d/16yNi5BqMcS1-dxvEcqpfvYAs-NGWg9OS6TCQbsL_mB8/edit#gid=0
        ValueRange response = await request.ExecuteAsync();
        IList<IList<object>> values = response.Values;
        if (values != null && values.Count > 0)
        {
            Debug.Log("SpreadSheet Data :");
            Debug.Log("DataName, Value");
            foreach (var row in values)
            {
                // Print columns A and E, which correspond to indices 0 and 4.
                //sheetData.Value.Add(((string) row[0], (float) row[1]));
                Debug.Log($"{row[0]}, {row[1]}");
            }
        }
        else
        {
            Debug.Log("No data found.");
        }
    }
}
