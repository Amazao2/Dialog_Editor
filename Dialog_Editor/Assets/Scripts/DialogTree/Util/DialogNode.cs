using System;
using System.Text;
using UnityEditor;
using UnityEngine;

[System.Serializable]
public class DialogNode : MonoBehaviour
{
    public LocalizationController localizationController;
    // what variable in the messages file corresponds to what the NPC will say?
    public string NPCDialogVariable;

    // optional player choices
    public DialogResponses responses;

    public DialogNode(string npcDialog, DialogResponses playerResponses)
    {
        NPCDialogVariable = npcDialog;
        responses = playerResponses;
    }

    public string getNPCDialog()
    {
        return localizationController.get(NPCDialogVariable);
    }

    public int numberOfResponses(){return responses.numberOfResponses;}

    public DialogResponse getResponseOne() { return responses.responseOne; }
    public DialogResponse getResponseTwo() { return responses.responseTwo; }
    public DialogResponse getResponseThree() { return responses.responseThree; }

}

