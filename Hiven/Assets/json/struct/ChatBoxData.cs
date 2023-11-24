using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chat
{

    [System.Serializable]
    public class ChatBoxData
    {
        public string scene;
        public List<ChatBoxInfo> chats;
    }

    [System.Serializable]
    public class ChatBoxInfo
    {
        public string obj;
        public SayData say;
    }

    [System.Serializable]
    public class SayData
    {
        public string text;
        public List<string> effect;
        public List<int> speed;
    }


}
