using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.IO;
using UnityEngine;

public class TwitchChatConnected : MonoBehaviour
{
    private static TwitchChatConnected _tccInstance;

    public static TwitchChatConnected Instance()
    {
        if(!_tccInstance)
            _tccInstance = new TwitchChatConnected();
        return _tccInstance;
    }

    [SerializeField] private CommandsCollection _commandsCollection;

    private TcpClient _twitchClient;
    
    private StreamReader _reader;
    private StreamWriter _writer;


    private void Awake()
    {
        _tccInstance = this;
        
        _commandsCollection.Init();

        //TODO put this on another script, here just for test
        Application.runInBackground = true;
    }

    private void Start()
    {
        ConnectClient(new TwitchAcountCredentials());
    }

    private void Update()
    {
        if (_twitchClient != null && _twitchClient.Connected)
        {
            Debug.Log("Read Chat");
            ReadChat();
        }
    }


    public void ConnectClient(TwitchAcountCredentials twitchAcountCredentials)
    {
        _twitchClient = new TcpClient("irc.chat.twitch.tv", 6667);
        _reader = new StreamReader(_twitchClient.GetStream());
        _writer = new StreamWriter(_twitchClient.GetStream());
        
        _writer.WriteLine($"PASS {twitchAcountCredentials.OauthPassword}");
        _writer.WriteLine($"NICK {twitchAcountCredentials.Username}");
        _writer.WriteLine($"USER {twitchAcountCredentials.Username} 8 * {twitchAcountCredentials.Username}");
        _writer.WriteLine($"JOIN #{twitchAcountCredentials.TwitchAcountName}");
        _writer.Flush();
    }
    
    public void ReadChat()
    {
        if (_twitchClient.Available > 0)
        {
            Debug.Log("Available");
            string chatMessage = _reader.ReadLine();
            Debug.Log(chatMessage);

            if (chatMessage.Contains("PING"))
            {
                _writer.WriteLine("PONG");
                _writer.Flush();
                return;
            }

            if (chatMessage.Contains("PRIVMSG"))
            {
                var splitPoint = chatMessage.IndexOf("!", 1, StringComparison.Ordinal);
                var author = chatMessage.Substring(0, splitPoint);
                author = author.Substring(1);

                splitPoint = chatMessage.IndexOf(":", 1, StringComparison.Ordinal);
                chatMessage = chatMessage.Substring(splitPoint + 1);

                if (chatMessage.StartsWith(CommandsPrefix.Prefix))
                {
                    Debug.Log("It's a command !");
                    int index = chatMessage.IndexOf(" ");
                    string command = index > -1 ? chatMessage.Substring(0, index) : chatMessage;
                    
                    _commandsCollection.ExecuteCommands(command, new MessageData
                    {
                        Author = author,
                        Message = chatMessage
                    });
                }
            }
            
        }
        else
        {
            Debug.Log("not Available");
        }
    }
    
}
