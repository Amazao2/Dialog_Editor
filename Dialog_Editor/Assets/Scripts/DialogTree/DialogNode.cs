using System;
using System.Text;
using UnityEditor;


class DialogNode
{
    // what will the NPC say?
    public string NPCDialog;

    // optional player choices
    public DialogResponses responses;

    public DialogNode(string npcDialog, DialogResponses playerResponses)
    {
        NPCDialog = npcDialog;
        responses = playerResponses;
    }

    public int numberOfResponses(){return responses.numberOfResponses;}

    public DialogResponse getResponseOne() { return responses.responseOne; }
    public DialogResponse getResponseTwo() { return responses.responseTwo; }
    public DialogResponse getResponseThree() { return responses.responseThree; }

}

