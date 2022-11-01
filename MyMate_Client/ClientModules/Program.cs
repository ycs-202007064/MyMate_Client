// See https://aka.ms/new-console-template for more information
using ClientModules.Classes;
using ClientModules.Services;
using ClientModules.Controllers;
using ClientToServer;
using Protocol;
using System.IO;
using System.Net.Sockets;
using System.Security.Cryptography;
using ClientModules.Models;
using System.Runtime.CompilerServices;
using static Protocol.UserInfoProtocol;
using System.Collections.Generic;
using System.Reflection.Metadata;
using ClientModules.Containers;
using ClientModules.Models.Chat;

MdlLogIn signininfo = new();

//Server server = Server.Instance;
SvcDistributor d = SvcDistributor.Instance;

while (true) {

    if (Console.ReadLine() == "do")
    {
        SvcDistributor.Instance.putServer(new MdlServer());
        SvcDistributor.Instance.putChatroom(new MdlChatroom());
        SvcDistributor.Instance.putMessage(new MdlMessage());
    }
    Thread.Sleep(500);
}