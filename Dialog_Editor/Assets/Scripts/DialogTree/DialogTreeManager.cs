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

    private DialogNode root;

	// Use this for initialization
	void Start () {
        // hide the whole canvas when started
        dialogScreen.enabled = false;

        // listen to the buttons supplied
        RegisterButtonListeners();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ShowDialogScreen(DialogNode dialogTree) { 
        dialogScreen.enabled = true;

        SetDialogText(dialogTree);
    }
    void HideDialogScreen() { dialogScreen.enabled = false; }

    public void SelectOptionOne() { }
    public void SelectOptionTwo() { }
    public void SelectOptionThree() { }

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

        NPCText.text = dialogTree.NPCDialog;
        PlayerTextOne.text = responses.responseOne.response;

        // the next two responses may not exist
        if( responses.responseTwo != null )
        {
            PlayerTextTwo.text = responses.responseTwo.response;
        }
        else
            PlayerTextTwo.enabled = false;

        if (responses.responseThree != null)
        {
            PlayerTextThree.text = responses.responseThree.response;
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
