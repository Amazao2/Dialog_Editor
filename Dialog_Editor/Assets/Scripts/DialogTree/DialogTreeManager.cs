using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DialogTreeManager : MonoBehaviour {

    public Canvas dialogScreen;

    public Text NPCText;

    public Text PlayerTextOne;
    public Button PlayerButtonOne;
    
    public Text PlayerTextTwo;
    public Button PlayerButtonTwo;

    public Text PlayerTextThree;
    public Button PlayerButtonThree;

    private DialogNode currentNode;

	// Use this for initialization
	void Start () {
        // hide the whole canvas when started
        dialogScreen.enabled = false;

        // listen to the buttons supplied
        RegisterButtonListeners();
	}

    public void ShowDialogScreen(DialogNode dialogTree) {
        currentNode = dialogTree; // this is the root
        dialogScreen.enabled = true;

        SetDialogText(dialogTree);
    }
    void HideDialogScreen() { dialogScreen.enabled = false; }

    public void SelectOptionOne() {
        DialogNode next = currentNode.responses.responseOne.nextNode;

        ContinueIfMoreNodes(next);
    }
    public void SelectOptionTwo() {
        DialogNode next = currentNode.responses.responseTwo.nextNode;

        ContinueIfMoreNodes(next);
    }
    public void SelectOptionThree() {
        DialogNode next = currentNode.responses.responseThree.nextNode;

        ContinueIfMoreNodes(next);
    }

    private void ContinueIfMoreNodes(DialogNode next)
    {
        if (next != null && next.getNPCDialog() != "" && next.responses.responseOne.getResponse() != "")
        {
            currentNode = next;
            SetDialogText(currentNode);
        }
        else
        {
            // dialog tree has been completed, close the interface
            HideDialogScreen();
        }
    }

    private void EnableAllText()
    {
        PlayerTextOne.enabled = true;
        PlayerTextTwo.enabled = true;
        PlayerTextThree.enabled = true;
    }
    private void SetDialogText(DialogNode dialogTree)
    {
        var responses = dialogTree.responses;

        EnableAllText(); // ensure all the text boxes will be seen

        NPCText.text = dialogTree.getNPCDialog();
        PlayerTextOne.text = responses.responseOne.getResponse();

        // the next two responses may not exist
        if( responses.responseTwo != null )
        {
            PlayerTextTwo.text = responses.responseTwo.getResponse();
        }
        else
            PlayerTextTwo.enabled = false;

        if (responses.responseThree != null)
        {
            PlayerTextThree.text = responses.responseThree.getResponse();
        }
        else
            PlayerTextThree.enabled = false;
    }

    private void RegisterButtonListeners()
    {
        PlayerButtonOne.onClick.AddListener(() => SelectOptionOne());
        PlayerButtonTwo.onClick.AddListener(() => SelectOptionTwo());
        PlayerButtonThree.onClick.AddListener(() => SelectOptionThree());
    }
}
