using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

using FORMS = ENUMS.FORMS;
using MATERIALGROUPS = ENUMS.MATERIALGROUPS;
using MATERIALS = ENUMS.MATERIALS;
using WEAPONTYPE = ENUMS.WEAPONTYPES;

public class Stage2_GridManager : MonoBehaviour
{
    public GameObject prefabTileStage2;

    public int gridWidth = 13;
    public int gridHeight = 13;
    public float tileSize = 0.645f;

    public GameObject[,] stage2TileObjects;
    public GameObject panelWrongForm;

    public Text heatValue;
    public Text materialMassValue;

    //Temp Variables
    private int initStartX = 6;
    private int initStartY = 6;

    private float materialMassLostNotParticipated = 0.0f;
    private float materialMassLostPerHeating = 10.0f;
    private float heatLostNotParticipated = 5.0f;

    public FORMS activeForm = FORMS.Empty;

    public List<FORMS> listForms = new List<FORMS>();
    public List<Sprite> listSprites = new List<Sprite>();

    public WEAPONTYPE selectedWeapon;
    public int[, ,] selectedWeaponTemplate;

    // Use this for initialization
    void Start()
    {

        CreateGrid();
    }

    public void CreateGrid()
    {
        GameObject gridHolder = GameObject.Find("Stage2GridHolder");
        if (gridHolder != null) DestroyImmediate(gridHolder);

        gridHolder = new GameObject("Stage2GridHolder");
        gridHolder.transform.SetParent(this.transform);

        stage2TileObjects = new GameObject[gridWidth, gridHeight];

        for (int width = 0; width < gridWidth; width++)
        {
            for (int height = 0; height < gridHeight; height++)
            {
                // if ((FORMS)bluePrint_Dagger[0, width, height] != FORMS.Empty)
                {
                    GameObject tmpObject = (GameObject)Instantiate(prefabTileStage2, new Vector3(width * tileSize, height * tileSize, 0), prefabTileStage2.transform.rotation, gridHolder.transform);
                    tmpObject.name = "Stage2Tile_W" + width.ToString() + "_H" + height.ToString();

                    Stage2Tile stage2Tile = tmpObject.GetComponent<Stage2Tile>();
                    stage2Tile.gridManager = this;
                    stage2Tile.posX = width;
                    stage2Tile.posY = height;

                    if ((FORMS)selectedWeaponTemplate[0, width, height] != FORMS.Empty)
                    {
                        int spriteInt = listForms.FindIndex(x => x == (FORMS)selectedWeaponTemplate[0, width, height]);
                        if (spriteInt >= 0)
                        {
                            stage2Tile.templateSpriteRenderer.sprite = listSprites[spriteInt];
                            stage2Tile.templateForm = (FORMS)selectedWeaponTemplate[0, width, height];
                        }
                    }

                    //TMP
                    if (width == initStartX && height == initStartY)
                    {
                        stage2Tile.isActive = true;
                        stage2Tile.heat = 100f;
                        stage2Tile.materialMass = 400f;
                        stage2Tile.currentForm = FORMS.Block;
                    }

                    stage2TileObjects[width, height] = tmpObject;
                }

            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AfterHammerHit()
    {
        for (int w = 0; w < gridWidth; w++)
        {
            for (int h = 0; h < gridHeight; h++)
            {
                Stage2Tile tmpTile = stage2TileObjects[w, h].GetComponent<Stage2Tile>();
                if (tmpTile.isChanged)
                {
                    tmpTile.isChanged = false;
                }
                else
                {
                    tmpTile.AddMaterialMass(-materialMassLostNotParticipated);
                    tmpTile.AddHeat(-heatLostNotParticipated);
                }
            }
        }
    }

    public void HeatTheIron()
    {
        for (int w = 0; w < gridWidth; w++)
        {
            for (int h = 0; h < gridHeight; h++)
            {
                Stage2Tile tmpTile = stage2TileObjects[w, h].GetComponent<Stage2Tile>();
                tmpTile.AddMaterialMass(-materialMassLostPerHeating);
                tmpTile.SetHeat(100);
            }
        }
    }

    public void SelectForm(FORMS selectedForm)
    {
        if (selectedForm == activeForm)
        { activeForm = FORMS.Empty; }
        else
        { activeForm = selectedForm; }
    }

    public void ClickFinishWeapon()
    {
        bool isValid = true;
        for (int w = 0; w < gridWidth; w++)
        {
            for (int h = 0; h < gridHeight; h++)
            {
                Stage2Tile tmpTile = stage2TileObjects[w, h].GetComponent<Stage2Tile>();
                if (tmpTile.templateForm != tmpTile.currentForm)
                {
                    isValid = false;
                    panelWrongForm.SetActive(true);
                    return;
                }                
            }
        }
    }

}
