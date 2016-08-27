using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(BluePrintCreator))]
class BluePrintCreator_Extension : Editor
{
    public override void OnInspectorGUI()
    {
        BluePrintCreator bluePrintCreator = (BluePrintCreator)target;
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("New Blueprint")) bluePrintCreator.CreateNewBluePrint();
        if (GUILayout.Button("New Grid")) bluePrintCreator.CreateNewGrid();

        if (GUILayout.Button("Save BluePrint")) bluePrintCreator.SaveBluePrint();
        if (GUILayout.Button("Load BluePrint")) bluePrintCreator.LoadBluePrint();
        
        GUILayout.EndHorizontal();

        base.OnInspectorGUI();
    }
}
