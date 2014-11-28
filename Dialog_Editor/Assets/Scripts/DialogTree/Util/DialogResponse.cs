using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Assets.Scripts.Localization;

[System.Serializable]
public class DialogResponse : MonoBehaviour
{
    public LocalizationController localizationController;
    public string responseVariable; // the variable that will be found in the messages file
    public DialogNode nextNode = null;

    public string getResponse()
    {
        if (responseVariable == null || responseVariable == "")
            return null;
        else
            return localizationController.get(responseVariable);
    }

    public DialogResponse(string playerResponseVar, DialogNode nextDialogNode) { responseVariable = playerResponseVar; nextNode = nextDialogNode; }
    public DialogResponse(string playerResponseVar) { responseVariable = playerResponseVar; }

    public bool hasNextNode() { if (nextNode != null) return true; else return false; }

    public bool isLeaf() { if (nextNode == null) return true; else return false; }
}