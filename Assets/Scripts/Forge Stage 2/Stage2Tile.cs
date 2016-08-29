using UnityEngine;
using System.Collections;


using FORMS = ENUMS.FORMS;
using MATERIALGROUPS = ENUMS.MATERIALGROUPS;
using MATERIALS = ENUMS.MATERIALS;

using SUBBUTTONTYPE = ENUMS.SUBBUTTONTYPES;

public class Stage2Tile : MonoBehaviour
{

    public Stage2_GridManager gridManager;
    public SpriteRenderer templateSpriteRenderer;
    public FORMS templateForm;

    public bool isActive = false;

    public int posX;
    public int posY;

    public float heat;
    public float materialMass;

    private float materialMassLostPerHit = 5.0f;
    private float heatLostPerHit = 10.0f;
    private float materialMassPerBlock = 10.0f;


    public bool isChanged = false;

    public FORMS currentForm = FORMS.Empty;
    private SpriteRenderer spriteRenderer;

    // Use this for initialization
    void Start()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        int spriteIndex = gridManager.listForms.FindIndex(x => x == currentForm);
        if (spriteIndex > -1)
        {
            if (spriteRenderer.sprite != gridManager.listSprites[spriteIndex])
            { spriteRenderer.sprite = gridManager.listSprites[spriteIndex]; }
        }
    }

    public void Smithy(SUBBUTTONTYPE buttonType)
    {
        if (heat >= heatLostPerHit)
        {
            GameObject leftObject = null;
            GameObject rightObject = null;
            GameObject upObject = null;
            GameObject downObject = null;

            if (posX - 1 >= 0) leftObject = gridManager.stage2TileObjects[posX - 1, posY];
            if (posY - 1 >= 0) downObject = gridManager.stage2TileObjects[posX, posY - 1];
            if (posX + 1 <= gridManager.stage2TileObjects.GetUpperBound(0)) rightObject = gridManager.stage2TileObjects[posX + 1, posY];
            if (posY + 1 <= gridManager.stage2TileObjects.GetUpperBound(1)) upObject = gridManager.stage2TileObjects[posX, posY + 1];

            float materialMassForEach = 0.0f;

            AddMaterialMass(-materialMassLostPerHit);
            //quality = Mathf.Clamp(quality - qualityLostPerHit, 0, quality);
            AddHeat(-heatLostPerHit);
            isChanged = true;
            if (materialMass > 0)
            {
                GameObject tmpObject = null;
                Stage2Tile tmpTile = null;

                if (buttonType == SUBBUTTONTYPE.Center)
                {
                    materialMassForEach = Mathf.Clamp(4 * materialMassPerBlock, 0, materialMass);
                    AddMaterialMass(-materialMassForEach);
                    materialMassForEach = materialMassForEach / 4;


                    //if (leftObject != null) leftObject.GetComponent<Stage2Tile>().isActive = true;
                    //if (rightObject != null) rightObject.GetComponent<Stage2Tile>().isActive = true;
                    //if (upObject != null) upObject.GetComponent<Stage2Tile>().isActive = true;
                    //if (downObject != null) downObject.GetComponent<Stage2Tile>().isActive = true;
                    for (int side = 0; side < 4; side++)
                    {
                        switch (side)
                        {
                            case (0): tmpObject = leftObject; break;
                            case (1): tmpObject = rightObject; break;
                            case (2): tmpObject = upObject; break;
                            case (3): tmpObject = downObject; break;
                        }
                        if (tmpObject != null)
                        {
                            tmpTile = tmpObject.GetComponent<Stage2Tile>();
                            if (tmpTile.materialMass > 0)
                            { tmpTile.AddHeat(-heatLostPerHit); }
                            else
                            { tmpTile.SetHeat(heat); }
                            tmpTile.AddMaterialMass(materialMassForEach);
                            tmpTile.isChanged = true;
                            if (tmpTile.currentForm == FORMS.Empty) tmpTile.currentForm = FORMS.Block;
                        }
                        //if (rightObject != null) rightObject.GetComponent<Stage2Tile>().AddQuality(qualityForEach);
                        //if (upObject != null) upObject.GetComponent<Stage2Tile>().AddQuality(qualityForEach);
                        //if (downObject != null) downObject.GetComponent<Stage2Tile>().AddQuality(qualityForEach);
                    }
                }
                else if (buttonType == SUBBUTTONTYPE.Left ||
                    buttonType == SUBBUTTONTYPE.Down ||
                    buttonType == SUBBUTTONTYPE.Right ||
                    buttonType == SUBBUTTONTYPE.Up)
                {
                    materialMassForEach = Mathf.Clamp(materialMassPerBlock, 0, materialMass);
                    AddMaterialMass(-materialMassForEach);

                    switch (buttonType)
                    {
                        case (SUBBUTTONTYPE.Left): tmpObject = rightObject; break;
                        case (SUBBUTTONTYPE.Right): tmpObject = leftObject; break;
                        case (SUBBUTTONTYPE.Up): tmpObject = downObject; break;
                        case (SUBBUTTONTYPE.Down): tmpObject = upObject; break;
                    }

                    if (tmpObject != null)
                    {
                        tmpTile = tmpObject.GetComponent<Stage2Tile>();
                        if (tmpTile.materialMass > 0)
                        { tmpTile.AddHeat(-heatLostPerHit); }
                        else
                        { tmpTile.SetHeat(heat); }
                        tmpTile.AddMaterialMass(materialMassForEach);
                        tmpTile.isChanged = true;
                        if (tmpTile.currentForm == FORMS.Empty) tmpTile.currentForm = FORMS.Block;
                    }
                }

            }
            ShowValues();
            gridManager.AfterHammerHit();
        }
    }

    public void AddHeat(float heatChange)
    {
        heat = Mathf.Clamp(heat + heatChange, 0, 100);
    }

    public void SetHeat(float heatToSet)
    {
        heat = Mathf.Clamp(heatToSet, 0, 100);
    }

    public void AddMaterialMass(float materialMassChange)
    {
        materialMass = Mathf.Clamp(materialMass + materialMassChange, 0, 99999);
        if (materialMass <= 0)
        {
            materialMass = 0;
            isActive = false;
            currentForm = FORMS.Empty;
        }
        else if (materialMass > 0)
        {
            isActive = true;
        }
    }

    void OnMouseDown()
    {
          Debug.Log("Stage 2 Tile - OnMouseDown");
        if (gridManager.activeForm != FORMS.Empty)
        {
            GameObject objectOne = null;
            GameObject objectTwo = null;

            switch (gridManager.activeForm)
            {
                case FORMS.SpikeDown:
                    if (posY <= 0) return;
                    objectOne = gridManager.stage2TileObjects[posX, posY - 1];
                    break;
                case FORMS.SpikeLeft:
                    if (posX <= 0) return;
                    objectOne = gridManager.stage2TileObjects[posX - 1, posY];
                    break;
                case FORMS.SpikeRight:
                    if (posX >= gridManager.stage2TileObjects.GetUpperBound(0)) return;
                    objectOne = gridManager.stage2TileObjects[posX + 1, posY];
                    break;
                case FORMS.SpikeTop:
                    if (posY >= gridManager.stage2TileObjects.GetUpperBound(1)) return;
                    objectOne = gridManager.stage2TileObjects[posX, posY + 1];
                    break;

                case FORMS.HalfDown:
                    if (posY <= 0) return;
                    objectOne = gridManager.stage2TileObjects[posX, posY - 1];
                    break;
                case FORMS.HalfLeft:
                    if (posX <= 0) return;
                    objectOne = gridManager.stage2TileObjects[posX - 1, posY];
                    break;
                case FORMS.HalfRight:
                    if (posX >= gridManager.stage2TileObjects.GetUpperBound(0)) return;
                    objectOne = gridManager.stage2TileObjects[posX + 1, posY];
                    break;
                case FORMS.HalfUp:
                    if (posY >= gridManager.stage2TileObjects.GetUpperBound(1)) return;
                    objectOne = gridManager.stage2TileObjects[posX, posY + 1];
                    break;

                case FORMS.EdgeDR:
                    if (posY <= 0) return;
                    if (posX >= gridManager.stage2TileObjects.GetUpperBound(0)) return;
                    objectOne = gridManager.stage2TileObjects[posX, posY - 1];
                    objectTwo = gridManager.stage2TileObjects[posX + 1, posY];
                    break;
                case FORMS.EdgeLD:
                    if (posX <= 0) return;
                    if (posY <= 0) return;
                    objectOne = gridManager.stage2TileObjects[posX - 1, posY];
                    objectTwo = gridManager.stage2TileObjects[posX, posY - 1];
                    break;
                case FORMS.EdgeRU:
                    if (posX >= gridManager.stage2TileObjects.GetUpperBound(0)) return;
                    if (posY >= gridManager.stage2TileObjects.GetUpperBound(1)) return;
                    objectOne = gridManager.stage2TileObjects[posX + 1, posY];
                    objectTwo = gridManager.stage2TileObjects[posX, posY + 1];
                    break;
                case FORMS.EdgeUL:
                    if (posY >= gridManager.stage2TileObjects.GetUpperBound(1)) return;
                    if (posY <= 0) return;
                    objectOne = gridManager.stage2TileObjects[posX, posY + 1];
                    objectTwo = gridManager.stage2TileObjects[posX, posY - 1];
                    break;

            }

            Stage2Tile tmpTile = null;
            bool isValid = true;

            //Check if everything is available
            for (int i = 0; i < 2; i++)
            {
                if (i == 0 && objectOne != null) tmpTile = objectOne.GetComponent<Stage2Tile>();
                else if (i == 1 && objectTwo != null) tmpTile = objectTwo.GetComponent<Stage2Tile>();
                else continue;
                if (tmpTile == null || tmpTile.currentForm != FORMS.Block || tmpTile.heat < tmpTile.heatLostPerHit || tmpTile.materialMass <= tmpTile.materialMassLostPerHit) isValid = false;
            }

            if (isValid)
            {
                float newMaterialMass = 0.0f;
                float newHeat = 0.0f;
                int countRelevantTiles = 0;

                for (int i = 0; i < 2; i++)
                {
                    if (i == 0 && objectOne != null) tmpTile = objectOne.GetComponent<Stage2Tile>();
                    else if (i == 1 && objectTwo != null) tmpTile = objectTwo.GetComponent<Stage2Tile>();
                    else continue;

                    tmpTile.AddHeat(-tmpTile.heatLostPerHit);
                    tmpTile.AddMaterialMass(-tmpTile.materialMassLostPerHit);

                    float materialMassToShare = Mathf.Clamp(tmpTile.materialMassPerBlock, 0, tmpTile.materialMassPerBlock);
                    newMaterialMass = materialMassToShare;
                    tmpTile.AddMaterialMass(-materialMassToShare);
                    tmpTile.isChanged = true;

                    newHeat = tmpTile.heat;
                    countRelevantTiles++;
                }

                SetHeat(Mathf.Clamp(newHeat / countRelevantTiles, 0f, 100f));
                AddMaterialMass(newMaterialMass);
                currentForm = gridManager.activeForm;

                ShowValues();
                gridManager.AfterHammerHit();
            }
        }

    }

    public void ShowValues()
    {
        gridManager.heatValue.text = heat.ToString("0") + "%";
        gridManager.materialMassValue.text = materialMass.ToString("0.##");
    }

    public void ClearValues()
    {
        gridManager.heatValue.text = "";
        gridManager.materialMassValue.text = "";
    }



}
