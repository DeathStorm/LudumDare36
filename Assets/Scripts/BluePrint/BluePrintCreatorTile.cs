using UnityEngine;
using System.Collections;

using TILEOPTIONS = BluePrintCreator.TILEOPTIONS;
using TILEMATERIAL = BluePrintCreator.TILEMATERIAL;
public class BluePrintCreatorTile : MonoBehaviour {

    public BluePrintCreator bluePrintCreator;

    public TILEOPTIONS tileOption = TILEOPTIONS.Empty;
    public TILEMATERIAL tileMaterial = TILEMATERIAL.Iron;

    public int xPos;
    public int yPos;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
