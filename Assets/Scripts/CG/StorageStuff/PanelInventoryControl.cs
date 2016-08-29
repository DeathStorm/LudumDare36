using UnityEngine;
using UnityEngine.UI;
using System.Collections;

using MATERIALS = ENUMS.MATERIALS;
public class PanelInventoryControl : MonoBehaviour {

    public StorageContainer sContainer;
    public Text varPigskin;
    public Text varCrocoLeather;
    public Text varUniLeather;
    public Text varBeech;
    public Text varCherry;
    public Text varMahagoni;
    public Text varIron;
    public Text varSteel;
    public Text varMithril;
    public Text varGold;
    public Text varFame;


    void Start ()
    {
	
	} // END Start
	
	void Update ()
    {
        UpdateInventoryInformation();

    } // END Update

    void UpdateInventoryInformation()
    {
        varPigskin.text = sContainer.GetStorageRessource(MATERIALS.PigLeather).storedAmount.ToString();
        varCrocoLeather.text = sContainer.GetStorageRessource(MATERIALS.CrocodileLeather).storedAmount.ToString();
        varUniLeather.text = sContainer.GetStorageRessource(MATERIALS.UnicornLeather).storedAmount.ToString();
        varBeech.text = sContainer.GetStorageRessource(MATERIALS.Beech).storedAmount.ToString();
        varCherry.text = sContainer.GetStorageRessource(MATERIALS.Cherry).storedAmount.ToString();
        varMahagoni.text = sContainer.GetStorageRessource(MATERIALS.Mahagoni).storedAmount.ToString();
        varIron.text = sContainer.GetStorageRessource(MATERIALS.Iron).storedAmount.ToString();
        varSteel.text = sContainer.GetStorageRessource(MATERIALS.Steel).storedAmount.ToString();
        varMithril.text = sContainer.GetStorageRessource(MATERIALS.Mithril).storedAmount.ToString();
        varGold.text = sContainer.goldAmount.ToString();
        varFame.text = sContainer.fameAmount.ToString();

    } // END UpdateInventoryInformation

} // END Class