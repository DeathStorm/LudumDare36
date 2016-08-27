using UnityEngine;
using System.Collections;

using TILEOPTIONS = BluePrintCreator.TILEOPTIONS;
using TILEMATERIAL = BluePrintCreator.TILEMATERIAL;

public class BluePrint : MonoBehaviour {

    public struct TileDefinition
    {
        public int xPos;
        public int yPos;
        public TILEOPTIONS tileOption;
        public TILEMATERIAL tileMaterial;
    }

    public TileDefinition[,] bluePrintGrid;
    public int gridWidth;
    public int gridHeight;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
