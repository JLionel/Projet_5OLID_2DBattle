using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Twitch/Credentials")]
public class TwitchAcountCredentials : ScriptableObject
{
    [SerializeField] private string username;
    [SerializeField] private string twitchAccountName;
    [SerializeField] private string oauthPassword;
    
    public string Username { get => username; set => username = value; }
    public string TwitchAccountName{ get => twitchAccountName; set => twitchAccountName = value; }
    public string OauthPassword{ get => oauthPassword ; set => oauthPassword = value; }

    public TwitchAcountCredentials()
    {
        Username = "testjeuchattwitch";
        TwitchAccountName = "testjeuchattwitch";
        OauthPassword = "oauth:t6g5wagmm9yk9r0zuyquh1q1mlysgp";
    }
}
