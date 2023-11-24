using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Chat;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.ParticleSystem;

public class ChatBox : MonoBehaviour
{

    public TextMeshProUGUI tmp;

    void Start()
    {
        TryGetComponent(out tmp);
        SayData data = new()
        {
            text = "¿Í #»÷Áî# ÄíÄí·ç »§»Ë",
            effect = new List<string>() { "color=red", "/color" },
            speed = new List<int>() { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }
        };
        StartCoroutine(Say(data));
    }
    
    IEnumerator Say(SayData chat)
    {
        string data;
        for (int i = 0; i < chat.text.Length; i++)
        {
            if (chat.text[i] == '#')
            {
                continue;
            }
            int ip = i + 1;
            data = chat.text[..ip];
            string newData = data;
            foreach (string type in chat.effect)
            {
                newData = ReplaceFirst(newData, "#", $"<{type}>");
            }
            tmp.text = newData;
            yield return new WaitForSeconds((float) chat.speed[i] / 10);
        }
    }

    public string ReplaceFirst(string text, string search, string replace)
    {
        int pos = text.IndexOf(search);
        if (pos < 0)
        {
            return text;
        }
        return text[..pos] + replace + text[(pos + search.Length)..];
    }
}