using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.Localization;

[CustomEditor(typeof(DialogNode))]
class DialogNodeEditor : Editor
{
    private string defaultText;

    public override void OnInspectorGUI()
    {
        DialogNode myTarget = (DialogNode)target;
        Lang defaultLanguage;

        DrawDefaultInspector();

        // once the variable name has been filled in provide the option to add text to the default language
        if (myTarget.NPCDialogVariable != null && myTarget.NPCDialogVariable != "")
        {
            defaultLanguage = myTarget.localizationController.defaultLanguage;

            // provides the ability to add a variable to the default messages file automatically
            EditorGUILayout.PrefixLabel("Add a new Variable:");
            EditorGUI.indentLevel++;

            defaultText = EditorGUILayout.TextField("Default Lang Text", defaultText);
            EditorGUILayout.HelpBox(
                "The variable with name: " + myTarget.NPCDialogVariable +
                " and the provided text will be added to the default language: " +
                defaultLanguage.language,
                MessageType.Info
                );
            if (GUILayout.Button("Add"))
            {
                LocalizedTextEditor.addVariableToDefaultLanguageFile(
                    myTarget.localizationController,
                    defaultLanguage,
                    myTarget.NPCDialogVariable,
                    defaultText
                    );
            }
        }
        
    }

}

