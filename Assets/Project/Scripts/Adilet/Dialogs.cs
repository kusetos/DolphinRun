using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using Unity.VisualScripting;

public class Dialogs : MonoBehaviour
{
    public bool isActive = false;

    public Box[] dialogBoxes;
    Message[] currentMessages;
    Actor[] currentActors;
    int activeMessage = 0;

    public void OpenDialogue(Message[] messages, Actor[] actors)
    {
        
        currentMessages = messages;
        currentActors = actors;
        for (int i = 0; i < currentActors.Length; i++)
                dialogBoxes[i].backGroundBox.transform.localScale = Vector3.zero;
        activeMessage = 0;
        DisplayMessage();
    }

    void DisplayMessage()
    {
        Message messageToDisplay = currentMessages[activeMessage];
        Box box = dialogBoxes[messageToDisplay.actorId];
        box.backGroundBox.DOScale(new Vector3(1f, 1f, 1f), 0.5f).SetEase(Ease.InOutExpo);
        box.messageText.text = messageToDisplay.message;

        Actor actorToDisplay = currentActors[messageToDisplay.actorId];
        box.actorName.text = actorToDisplay.name;
    }

    public void NextMessage()
    {
        activeMessage++;
        if (activeMessage < currentMessages.Length)
        {
            DisplayMessage();
        }
        else
        {
            for (int i = 0; i < currentActors.Length; i++)
                dialogBoxes[i].backGroundBox.DOScale(Vector3.zero, 0.5f).SetEase(Ease.InOutExpo);
        }
    }

    /*void Start()
    {
        for (int i = 0; i < currentActors.Length; i++)
                dialogBoxes[i].backGroundBox.transform.localScale = Vector3.zero;
    }*/

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            NextMessage();
        }
    }
}