using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using FORMS = ENUMS.FORMS;
using MATERIALGROUPS = ENUMS.MATERIALGROUPS;
using MATERIALS = ENUMS.MATERIALS;
using WEAPONTYPE = ENUMS.WEAPONTYPES;

public class StorageContainer : MonoBehaviour {


    public int pigskinAmount = 0;
    public int crocodilLeatherAmount = 0;
    public int unicornLeatherAmount = 0;
    public int beechAmount = 0;
    public int cherryAmount = 0;
    public int mahagoniAmount = 0;
    public int ironAmount = 0;
    public int steelAmount = 0;
    public int mithrilAmount = 0;
    public int goldAmount = 0;
    public int fameAmount = 0;

    public List<MATERIALS> materialsType = new List<MATERIALS>();
    public List<GameObject> materialsObject = new List<GameObject>();


    void Start ()
    {
	
	} // END Start
	
	void Update ()
    {
	
	} // END Update

    public StorageRessource GetStorageRessource(MATERIALS material)
    {
        int resIndex = materialsType.FindIndex(x => x == material);
        if (resIndex == -1) return null;
        else return materialsObject[resIndex].GetComponent<StorageRessource>();
    }

} // END Class