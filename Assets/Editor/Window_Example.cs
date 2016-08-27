using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class Window_Example : EditorWindow{
        
    //
    // ~~~~~~ ShowWindow ~~~~~~
    //
    [MenuItem("TDP/Window_Example", false, 10)]
    public static void ShowWindow()
    {

        EditorWindow.GetWindow(typeof(Window_Example));

    } // END ShowWindow


    void OnGUI()
    {
       
    } // END OnGui



    
} // END Class
