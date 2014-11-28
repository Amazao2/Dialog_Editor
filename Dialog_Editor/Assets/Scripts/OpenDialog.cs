using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OpenDialog : MonoBehaviour {

    public Button button;
    public Dialog dialog;

	// Use this for initialization
	void Start () {

        button.onClick.AddListener(() => dialog.StartDialog());
	
	}

}
