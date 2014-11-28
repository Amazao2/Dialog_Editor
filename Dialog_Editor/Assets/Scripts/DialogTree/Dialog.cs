using UnityEngine;
using System.Collections;

[System.Serializable]
public class Dialog : MonoBehaviour {

    public LocalizationController localizationController;
    public DialogTreeManager dialogInterface;

    public DialogNode root;

    public void StartDialog()
    {
        print("Opening the dialog.");
        dialogInterface.ShowDialogScreen(root);
    }
}
