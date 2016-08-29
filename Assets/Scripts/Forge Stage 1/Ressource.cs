using UnityEngine;
using UnityEngine.UI;
using System.Collections;

using FORMS = ENUMS.FORMS;
using MATERIALGROUPS = ENUMS.MATERIALGROUPS;
using MATERIALS = ENUMS.MATERIALS;

public class Ressource : MonoBehaviour
{

    public MATERIALGROUPS materialGroup;
    public MATERIALS material;

    public Stage1_GridManager gridManager;

    public Color activeColor;
    public Color standardColor;

    public StorageContainer storageContainer;

    public Text storageAmount;
    public Text massAmount;
    public Text qualityMod;

    // Use this for initialization
    void Start()
    {
        standardColor = this.GetComponent<Image>().color;
    }

    // Update is called once per frame
    void Update()
    {

    }



    public void ClickButton()
    {
       
        if (gridManager.activeButton != null && gridManager.activeButton != this.gameObject)
        {
            gridManager.activeButton.GetComponent<Image>().color = gridManager.activeButton.GetComponent<Ressource>().standardColor;
        }
        this.GetComponent<Image>().color = activeColor;
        gridManager.activeButton = this.gameObject;
        gridManager.activeSprite = this.GetComponent<Image>().sprite;
    
    }

    public void OnMouseEnter()
    {
        storageAmount.text = storageContainer.GetStorageRessource(material).storedAmount.ToString("0");
        massAmount.text = storageContainer.GetStorageRessource(material).materialMass.ToString("0.##");
        qualityMod.text = storageContainer.GetStorageRessource(material).qualityModifer.ToString("0.##");
    }

    public void OnMouseExit()
    {
        storageAmount.text = "0";
        massAmount.text = "0";
        qualityMod.text = "0";
    }
}
