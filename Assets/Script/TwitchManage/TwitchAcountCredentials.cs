using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Twitch/Credentials")]
public class TwitchAcountCredentials : ScriptableObject
{
    public string Username { get; set; }
    public string TwitchAcountName{ get; set; }
    public string OauthPassword{ get; set; }

    public TwitchAcountCredentials()
    {
        Username = "testjeuchattwitch";
        TwitchAcountName = "testjeuchattwitch";
        OauthPassword = "oauth:t6g5wagmm9yk9r0zuyquh1q1mlysgp";
    }
}
