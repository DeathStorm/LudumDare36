using UnityEngine;
using System.Collections;

using FORMS = ENUMS.FORMS;
using MATERIALGROUPS = ENUMS.MATERIALGROUPS;
using MATERIALS = ENUMS.MATERIALS;

using WEAPONTYPE = ENUMS.WEAPONTYPES;
public class StorageRessource : MonoBehaviour {

    public MATERIALS material = MATERIALS.NONE;
    public int storedAmount = 0;
    public float qualityModifer = 0.0f;
    public float materialMass = 0.0f;

    public float purchaseCost = 0.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
