using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using FORMS = ENUMS.FORMS;
using MATERIALGROUPS = ENUMS.MATERIALGROUPS;
using MATERIALS = ENUMS.MATERIALS;

public class Stage1_GridManager : MonoBehaviour
{
    public GameObject activeButton = null;


    public GameObject prefabTileStage1;

    public int gridWidth = 13;
    public int gridHeight = 13;
    public float tileSize = 0.645f;

    public List<FORMS> TileSpriteOptionsList = new List<FORMS>();
    public List<Sprite> TileSpriteSpriteList = new List<Sprite>();
    public GameObject[,] stage1TileObjects;

    int[, ,] bluePrint_Dagger;

    // Use this for initialization
    void Start()
    {
        SetupBluePrints();
        stage1TileObjects = new GameObject[gridWidth, gridHeight];

        for (int width = 0; width < gridWidth; width++)
        {
            for (int height = 0; height < gridHeight; height++)
            {
               // if ((FORMS)bluePrint_Dagger[0, width, height] != FORMS.Empty)
                {
                    GameObject tmpObject = (GameObject)Instantiate(prefabTileStage1, new Vector3(width * tileSize, height * tileSize, 0), prefabTileStage1.transform.rotation, transform);
                    tmpObject.name = "Stage1Tile_W" + width.ToString() + "_H" + height.ToString();

                    Stage1Tile stage1Tile = tmpObject.GetComponent<Stage1Tile>();
                    stage1Tile.form = (FORMS)bluePrint_Dagger[0, width, height];
                    stage1Tile.materialGroup = (MATERIALGROUPS)bluePrint_Dagger[1, width, height];
                    stage1Tile.gridManager = this;

                    int spriteNumber = TileSpriteOptionsList.FindIndex(x => x == stage1Tile.form);
                    tmpObject.GetComponent<SpriteRenderer>().sprite = TileSpriteSpriteList[spriteNumber];

                    stage1TileObjects[width, height] = tmpObject;
                }

            }
        }

    }

    // Update is called once per frame
    void Update()
    {


    }





    void SetupBluePrints()
    {
        //    0     1       2          3        4         5        6       7       8       9       10         11        12         13
        // Empty, Block, HalfLeft, HalfRight, HalfUp, HalfDown, EdgeLD, EdgeDR, EdgeRU, EdgeUL, SpikeTop, SpikeLeft, SpikeDown, SpikeRight };

        //  0      1       2
        //Wood, Leather, Iron };

        bluePrint_Dagger = new int[2, 13, 13]
        {
            {
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 1, 1, 1, 1, 1,12, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
            },
            {
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 1, 1, 0, 2, 2, 2, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
            }
        };

    }
}
