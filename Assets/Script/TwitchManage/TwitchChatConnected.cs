using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.IO;
using UnityEngine;

public class TwitchChatConnected : MySingleton<TwitchChatConnected>
{
    [SerializeField] private CommandsCollection _commandsCollection;

    private TcpClient _twitchClient;
    
    private StreamReader _reader;
    private StreamWriter _writer;

    [SerializeField] private TwitchAcountCredentials twitchAcountCredentials;


    protected override bool DoDestroyOnLoad => true;
    

    private void Start()
    {
        //TODO put this on another script, here just for test
        Application.runInBackground = true;
        Debug.Log($"init TwitchConnection {Instance == null}");
    }

    private void Update()
    {
        if (_twitchClient != null && _twitchClient.Connected)
        {
            Debug.Log("Read Chat");
            ReadChat();
        }
    }


    public void ConnectClient()
    {
        Debug.Log("Connect client");
        if(_twitchClient == null)
        {
            _twitchClient = new TcpClient("irc.chat.twitch.tv", 6667);
            _reader = new StreamReader(_twitchClient.GetStream());
            _writer = new StreamWriter(_twitchClient.GetStream());

            _writer.WriteLine($"PASS {twitchAcountCredentials.OauthPassword}");
            Debug.Log(twitchAcountCredentials.OauthPassword);
            _writer.WriteLine($"NICK {twitchAcountCredentials.Username}");
            Debug.Log(twitchAcountCredentials.Username);
            _writer.WriteLine($"USER {twitchAcountCredentials.Username} 8 * {twitchAcountCredentials.Username}");
            _writer.WriteLine($"JOIN #{twitchAcountCredentials.TwitchAcountName}");
            Debug.Log(twitchAcountCredentials.TwitchAcountName);
            _writer.Flush();
        }
    }

    public void DisconnectClient()
    {
        if (_twitchClient == null)
            return;
        
        if(_twitchClient.Connected)
        {
            _twitchClient.Close();
            _twitchClient = null;
        }
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
                        Message = chatMessage.Substring($"{CommandsPrefix.Prefix}{command}".Length - 1)
                    });
                }
            }
            
        }
        else
        {
            Debug.Log("not Available");
        }
    }


    public void WriteMessage(string Message)
    {
        if (_twitchClient.Connected)
        {
            _writer.WriteLine($"PRIVMSG #{twitchAcountCredentials.TwitchAcountName} :{Message}");
            _writer.Flush();
        }
    }
    
}
