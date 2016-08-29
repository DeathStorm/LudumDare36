using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

using FORMS = ENUMS.FORMS;
using MATERIALGROUPS = ENUMS.MATERIALGROUPS;
using MATERIALS = ENUMS.MATERIALS;
using WEAPONTYPE = ENUMS.WEAPONTYPES;

public class Stage1_GridManager : MonoBehaviour
{
    public GameObject activeButton = null;
    public Sprite activeSprite;

    public Stage2_GridManager stage2GridManager;
    public GameObject stage2GUI;
    public GameObject stage1GUI;

    public GameObject panelMissingAssignment;

    public Dictionary<WEAPONTYPE, int[, ,]> weaponDictionary = new Dictionary<WEAPONTYPE, int[, ,]>();


    public GameObject prefabTileStage1;

    public int gridWidth = 13;
    public int gridHeight = 13;
    public float tileSize = 0.645f;

    public List<FORMS> TileSpriteOptionsList = new List<FORMS>();
    public List<Sprite> TileSpriteSpriteList = new List<Sprite>();
    public GameObject[,] stage1TileObjects;

    public Dictionary<string, WEAPONTYPE> stringToWeaponType = new Dictionary<string, WEAPONTYPE>();

    public WEAPONTYPE selectedWeapon;
    public GameObject weaponChoosePanel;

    //  int[, ,] bluePrint_Dagger;

    // Use this for initialization
    void Awake()
    {
        foreach (WEAPONTYPE weaponType in System.Enum.GetValues(typeof(WEAPONTYPE)))
        {
            stringToWeaponType.Add(weaponType.ToString(), weaponType);
        }
        SetupBluePrints();
        weaponChoosePanel.SetActive(true);
        //CreateNewGrid();

    }

    public void CreateNewGrid()
    {
        GameObject gridHolder = GameObject.Find("Stage1GridHolder");
        if (gridHolder != null) { DestroyImmediate(gridHolder); }

        gridHolder = new GameObject("Stage1GridHolder");
        gridHolder.transform.SetParent(this.transform);

        stage1TileObjects = new GameObject[gridWidth, gridHeight];
        for (int width = 0; width < gridWidth; width++)
        {
            for (int height = 0; height < gridHeight; height++)
            {
                // if ((FORMS)bluePrint_Dagger[0, width, height] != FORMS.Empty)
                {
                    GameObject tmpObject = (GameObject)Instantiate(prefabTileStage1, new Vector3(width * tileSize, height * tileSize, 0), prefabTileStage1.transform.rotation, gridHolder.transform);
                    tmpObject.name = "Stage1Tile_W" + width.ToString() + "_H" + height.ToString();

                    Stage1Tile stage1Tile = tmpObject.GetComponent<Stage1Tile>();
                    stage1Tile.form = (FORMS)weaponDictionary[WEAPONTYPE.Dagger][0, width, height];
                    stage1Tile.materialGroup = (MATERIALGROUPS)weaponDictionary[WEAPONTYPE.Dagger][1, width, height];
                    stage1Tile.gridManager = this;

                    int spriteNumber = TileSpriteOptionsList.FindIndex(x => x == stage1Tile.form);
                    tmpObject.GetComponent<SpriteRenderer>().sprite = TileSpriteSpriteList[spriteNumber];

                    stage1TileObjects[width, height] = tmpObject;
                }

            }
        }
    }

    public void ClickConfirmButton()
    {
        bool missingAssignment = false;
        Stage1Tile tmpTile = null;
        for (int w = 0; w < gridWidth; w++)
        {
            for (int h = 0; h < gridHeight; h++)
            {
                tmpTile = stage1TileObjects[w, h].GetComponent<Stage1Tile>();
                if (tmpTile.form != FORMS.Empty && tmpTile.material == MATERIALS.NONE)
                {
                    Debug.Log("Missing Assignment");
                    Debug.Log("Width = " + w.ToString() + " || Height = " + h.ToString());
                    missingAssignment = true;
                    panelMissingAssignment.SetActive(true);
                    return;
                }
            }
        }
        if (missingAssignment == false)
        {
            stage1GUI.SetActive(false);
            stage2GUI.SetActive(true);
            stage2GridManager.selectedWeapon = selectedWeapon;
            stage2GridManager.selectedWeaponTemplate = weaponDictionary[selectedWeapon];            
            stage2GridManager.gameObject.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {


    }





    void SetupBluePrints()
    {
        weaponDictionary = new Dictionary<WEAPONTYPE, int[, ,]>();
        //    0     1       2          3        4         5        6       7       8       9       10         11        12         13
        // Empty, Block, HalfLeft, HalfRight, HalfUp, HalfDown, EdgeLD, EdgeDR, EdgeRU, EdgeUL, SpikeTop, SpikeLeft, SpikeDown, SpikeRight };
        //  0      1       2     3
        //NONE, Wood, Leather, Iron };

        weaponDictionary.Add(WEAPONTYPE.Dagger, new int[2, 13, 13]
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
                { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 2, 2, 1, 3, 3, 3, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
            }
        });

        //    0     1       2          3        4         5        6       7       8       9       10         11        12         13
        // Empty, Block, HalfLeft, HalfRight, HalfUp, HalfDown, EdgeLD, EdgeDR, EdgeRU, EdgeUL, SpikeTop, SpikeLeft, SpikeDown, SpikeRight };
        //  0      1       2     3
        //NONE, Wood, Leather, Iron };
        weaponDictionary.Add(WEAPONTYPE.ShortSword, new int[2, 13, 13]
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
                { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 2, 2, 1, 3, 3, 3, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
            }
        });

        //    0     1       2          3        4         5        6       7       8       9       10         11        12         13
        // Empty, Block, HalfLeft, HalfRight, HalfUp, HalfDown, EdgeLD, EdgeDR, EdgeRU, EdgeUL, SpikeTop, SpikeLeft, SpikeDown, SpikeRight };
        //  0      1       2     3
        //NONE, Wood, Leather, Iron };
        weaponDictionary.Add(WEAPONTYPE.LongSword, new int[2, 13, 13]
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
                { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 2, 2, 1, 3, 3, 3, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
            }
        });

        //    0     1       2          3        4         5        6       7       8       9       10         11        12         13
        // Empty, Block, HalfLeft, HalfRight, HalfUp, HalfDown, EdgeLD, EdgeDR, EdgeRU, EdgeUL, SpikeTop, SpikeLeft, SpikeDown, SpikeRight };
        //  0      1       2     3
        //NONE, Wood, Leather, Iron };
        weaponDictionary.Add(WEAPONTYPE.BroadSword, new int[2, 13, 13]
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
                { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 2, 2, 1, 3, 3, 3, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
            }
        });
    }
}
