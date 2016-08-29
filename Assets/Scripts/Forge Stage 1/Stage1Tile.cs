using UnityEngine;
using System.Collections;


using FORMS = ENUMS.FORMS;
using MATERIALGROUPS = ENUMS.MATERIALGROUPS;
using MATERIALS = ENUMS.MATERIALS;

public class Stage1Tile : MonoBehaviour
{

    public FORMS form;
    public MATERIALGROUPS materialGroup;
    public MATERIALS material = MATERIALS.NONE;

    public Stage1_GridManager gridManager;
    

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        if (gridManager.activeButton != null && gridManager.activeButton.GetComponent<Ressource>().materialGroup == materialGroup)
        {
            material = gridManager.activeButton.GetComponent<Ressource>().material;
            this.GetComponent<SpriteRenderer>().sprite = gridManager.activeSprite;
        }
    }
}
