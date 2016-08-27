using UnityEngine;
using UnityEditor;
using System.Collections;

public class BluePrintCreator_Window : EditorWindow
{

    public int spriteSize = 64;

    public int width = 9;
    public int height = 9;

    public Texture2D spriteEmpty;

    public string[,] bluePrintGrid;

    [MenuItem("TDP/Blue Print Creator", false, 10)]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(BluePrintCreator_Window));
    }

    void OnGUI()
    {
        GUILayout.BeginVertical();
        
        if (GUILayout.Button("Reset"))
        {
            Awake();
        }
//        GUILayout.Space(100);
        
        GUIStyle style = new GUIStyle();
        
        GUILayout.BeginArea(new Rect(0,0,width*spriteSize,height*spriteSize));
        
        //GUILayout.BeginVertical();
        for (int h = 0; h < height; h++)
        {
            break;
            
            
            GUILayout.BeginHorizontal();
            for (int w = 0; w < width; w++)
            {

                //GUI.Button(new Rect(w * spriteSize, h * spriteSize, spriteSize, spriteSize), spriteEmpty);
                if (GUILayout.Button(bluePrintGrid[w, h]))
                {
                    bluePrintGrid[w, h] = "BLA";
                }
                //GUILayout.Button(spriteEmpty);
            }
            GUILayout.EndHorizontal();
        }
        //GUILayout.EndVertical();
        GUILayout.EndArea();
        GUILayout.EndVertical();
    }

    void Awake()
    {
        bluePrintGrid = new string[width, height];

        for (int w = 0; w < width; w++)
        {
            for (int h = 0; h < height; h++)
            {
                bluePrintGrid[w, h] = "EMPTY";
            }
        }
    }

    // Use this for initialization
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnDrawGizmos()
    {

    }

}
