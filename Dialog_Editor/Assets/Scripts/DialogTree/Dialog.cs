using UnityEngine;
using System.Collections;

[System.Serializable]
public class Dialog : MonoBehaviour {

    public DialogTreeManager dialogInterface;

    public DialogNode root;

    public void StartDialog()
    {
        // temporary for testing
        var r = new DialogResponse("Dialog Response 1!");
        var rs = new DialogResponses(r);
        var d = new DialogNode("I am an NPC", rs);

        root = d;

        print("Opening the dialog.");
        dialogInterface.ShowDialogScreen(root);
    }
}
