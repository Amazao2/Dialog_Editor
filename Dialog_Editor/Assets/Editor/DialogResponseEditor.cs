using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.Localization;

[CustomEditor(typeof(DialogResponse))]
class DialogResponseEditor : Editor
{
    private string defaultText;

    public override void OnInspectorGUI()
    {
        DialogResponse myTarget = (DialogResponse)target;
        Lang defaultLanguage;

        DrawDefaultInspector();

        // once the variable name has been filled in provide the option to add text to the default language
        if (myTarget.responseVariable != null && myTarget.responseVariable != "")
        {
            defaultLanguage = myTarget.localizationController.defaultLanguage;

            // provides the ability to add a variable to the default messages file automatically
            EditorGUILayout.PrefixLabel("Add a new Variable:");
            EditorGUI.indentLevel++;

            defaultText = EditorGUILayout.TextField("Default Lang Text", defaultText);
            EditorGUILayout.HelpBox(
                "The variable with name: " + myTarget.responseVariable +
                " and the provided text will be added to the default language: " +
                defaultLanguage.language,
                MessageType.Info
                );
            if (GUILayout.Button("Add"))
            {
                LocalizedTextEditor.addVariableToDefaultLanguageFile(
                    myTarget.localizationController,
                    defaultLanguage,
                    myTarget.responseVariable,
                    defaultText
                    );
            }
        }

    }

}

