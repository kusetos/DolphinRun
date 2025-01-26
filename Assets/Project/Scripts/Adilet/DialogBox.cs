using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogBox : MonoBehaviour
{
    public Message[] messages;
    public Actor[] actors;
    public Dialogs Box;

    public void Start()
    {
        Box.OpenDialogue(messages, actors);
    }
}

[System.Serializable]
public class Message {
    public int actorId;
    public string message;
}

[System.Serializable]
public class Actor {
    public string name;
}