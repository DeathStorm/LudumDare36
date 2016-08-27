using UnityEngine;
using System.Collections;

using FORMS = ENUMS.FORMS;
using MATERIALGROUPS = ENUMS.MATERIALGROUPS;
using MATERIALS = ENUMS.MATERIALS;

public class Stage2_GridManager : MonoBehaviour {

    public GameObject prefabTileStage2;

    public int gridWidth = 13;
    public int gridHeight = 13;
    public float tileSize = 0.645f;

    public GameObject[,] stage2TileObjects;

	// Use this for initialization
	void Start () 
    {
        stage2TileObjects = new GameObject[gridWidth, gridHeight];

        for (int width = 0; width < gridWidth; width++)
        {
            for (int height = 0; height < gridHeight; height++)
            {
                // if ((FORMS)bluePrint_Dagger[0, width, height] != FORMS.Empty)
                {
                    GameObject tmpObject = (GameObject)Instantiate(prefabTileStage2, new Vector3(width * tileSize, height * tileSize, 0), prefabTileStage2.transform.rotation, transform);
                    tmpObject.name = "Stage2Tile_W" + width.ToString() + "_H" + height.ToString();

                    Stage2Tile stage2Tile = tmpObject.GetComponent<Stage2Tile>();
                    stage2Tile.gridManager = this;

                    stage2TileObjects[width, height] = tmpObject;
                }

            }
        }

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
