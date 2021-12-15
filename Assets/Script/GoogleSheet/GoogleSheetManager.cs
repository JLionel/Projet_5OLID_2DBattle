using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class GoogleSheetManager : MonoBehaviour
{
    private GoogleSheetClient _clientToConnect;
    [SerializeField] private List<GoogleSheetReadValue> _dataToCatch;
    [SerializeField] private List<LinkSheetFloatData> _linkData;
    
    // Start is called before the first frame update
    void Start()
    {
        StartSheet();
    }


    private async void StartSheet()
    {
        _clientToConnect = GoogleSheetClient.Instance;
        bool connected = await _clientToConnect.Connect();
        if (connected)
        {
            for ( int i = 0; i < _dataToCatch.Count; i++)
            {
                var reader = _dataToCatch[i];
                bool valueReaded = await reader.ReadValueExe();

                if (valueReaded)
                {
                    _linkData[i].Init();
                    _linkData[i].LinkData();
                }
            }
        }
    }
}
