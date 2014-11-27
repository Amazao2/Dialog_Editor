using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class DialogResponse
{
    public string response;
    public DialogNode nextNode = null;

    public DialogResponse(string playerResponse, DialogNode nextDialogNode) { response = playerResponse; nextNode = nextDialogNode; }
    public DialogResponse(string playerResponse) { response = playerResponse; }

    public bool hasNextNode() { if (nextNode != null) return true; else return false; }

    public bool isLeaf() { if (nextNode == null) return true; else return false; }
}