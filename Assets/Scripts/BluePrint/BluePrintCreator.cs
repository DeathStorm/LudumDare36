using UnityEngine;
using UnityEditor;
using System.Collections;

using System.Collections.Generic;


[ExecuteInEditMode]
public class BluePrintCreator : MonoBehaviour
{

    public enum TILEOPTIONS { Empty, Block, HalfLeft, HalfRight, HalfUp, HalfDown, EdgeLD, EdgeDR, EdgeRU, EdgeUL, SpikeTop, SpikeLeft, SpikeDown, SpikeRight };
    public enum TILEMATERIAL { Wood, Leather, Iron };

    public List<TILEOPTIONS> TileSpriteOptionsList = new List<TILEOPTIONS>();
    public List<Sprite> TileSpriteSpriteList = new List<Sprite>();


    public GameObject bluePrintCreatorTileObject;

    public int gridWith = 9;
    public int gridHeight = 9;
    public float tilesize = 0.8f;

    public string prefabPath = "Assets/PreFabs/BluePrints/";
    public string prefabExtension = ".prefab";
    public GameObject bluePrintObject;
    private BluePrint bluePrint;

    public string bluePrintName;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (bluePrintObject != null && bluePrintName != "")
        {
            //  bluePrintObject.name = bluePrintName;

        }
    }

    public void CreateNewGrid()
    {
        GameObject containerObject = GameObject.Find("TileContainer");
        if (containerObject != null)
        { DestroyImmediate(containerObject); }

        containerObject = new GameObject();
        containerObject.transform.position = new Vector3(0, 0, 0);
        containerObject.name = "TileContainer";

        //while (transform.childCount > 0 &&  transform.GetChild(0) != null)
        //{

        //    Destroy(transform.GetChild(0));
        //}

        for (int w = 0; w < gridWith; w++)
        {
            for (int h = 0; h < gridHeight; h++)
            {
                GameObject tile = (GameObject)Instantiate(bluePrintCreatorTileObject, new Vector3(w * tilesize, h * tilesize, 0), bluePrintCreatorTileObject.transform.rotation, containerObject.transform);
                BluePrintCreatorTile bluePrintCreatorTile = tile.GetComponent<BluePrintCreatorTile>();
                bluePrintCreatorTile.bluePrintCreator = this;
                bluePrintCreatorTile.xPos = w;
                bluePrintCreatorTile.yPos = h;
            }
        }
    }

    public void CreateNewBluePrint()
    {

        GameObject tmpObject = new GameObject();
        tmpObject.AddComponent<BluePrint>();

        bluePrintObject = PrefabUtility.CreatePrefab(prefabPath + bluePrintName + prefabExtension, tmpObject);
        bluePrint = bluePrintObject.GetComponent<BluePrint>();

        DestroyImmediate(tmpObject);

    }

    public void SaveBluePrint()
    {
        GameObject tileContainer = GameObject.Find("TileContainer");
        if (tileContainer != null && bluePrintObject != null)
        {
            bluePrint = bluePrintObject.GetComponent<BluePrint>();
            bluePrint.bluePrintGrid = new BluePrint.TileDefinition[gridWith, gridHeight];
            bluePrint.gridWidth = gridWith;
            bluePrint.gridHeight = gridHeight;
            foreach (Transform tile in tileContainer.transform)
            {
                BluePrintCreatorTile bluePrintCreatorTile = tile.GetComponent<BluePrintCreatorTile>();

                BluePrint.TileDefinition tileDefinition = new BluePrint.TileDefinition();
                tileDefinition.xPos = bluePrintCreatorTile.xPos;
                tileDefinition.yPos = bluePrintCreatorTile.yPos;
                tileDefinition.tileMaterial = bluePrintCreatorTile.tileMaterial;
                tileDefinition.tileOption = bluePrintCreatorTile.tileOption;

                bluePrint.bluePrintGrid[tileDefinition.xPos, tileDefinition.yPos] = tileDefinition;
            }
        }

    }

    public void LoadBluePrint()
    {
        if (bluePrintObject != null)
        {
            bluePrint = bluePrintObject.GetComponent<BluePrint>();

            gridWith = bluePrint.gridWidth;
            gridHeight = bluePrint.gridHeight;
            bluePrintName = bluePrintObject.name;

            CreateNewGrid();
            GameObject tileContainer = GameObject.Find("TileContainer");

            foreach (Transform tile in tileContainer.transform)
            {
                BluePrintCreatorTile bluePrintCreatorTile = tile.GetComponent<BluePrintCreatorTile>();

                BluePrint.TileDefinition tileDefinition = bluePrint.bluePrintGrid[bluePrintCreatorTile.xPos, bluePrintCreatorTile.yPos];

                bluePrintCreatorTile.tileMaterial = tileDefinition.tileMaterial;
                bluePrintCreatorTile.tileOption = tileDefinition.tileOption;

                

                    
            }
            UnityEditorInternal.InternalEditorUtility.RepaintAllViews();
            SaveBluePrint();
            

        }

    }


}
