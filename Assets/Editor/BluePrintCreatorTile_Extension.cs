using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

using TILEOPTIONS = BluePrintCreator.TILEOPTIONS;

using TILEMATERIAL = BluePrintCreator.TILEMATERIAL;


[CustomEditor(typeof(BluePrintCreatorTile))]
class BluePrintCreatorTile_Extension : Editor
{
    public override void OnInspectorGUI()
    {
        BluePrintCreatorTile bluePrintCreatorTile = (BluePrintCreatorTile)target;

        GUILayout.BeginVertical();
        GUILayout.BeginHorizontal();
        int counter = 0;
        foreach (TILEOPTIONS tileOption in Enum.GetValues(typeof(TILEOPTIONS)))
        {

            int spriteNumber = bluePrintCreatorTile.bluePrintCreator.TileSpriteOptionsList.FindIndex(x => x == tileOption);
            Sprite sprite = bluePrintCreatorTile.bluePrintCreator.TileSpriteSpriteList[spriteNumber];

            if (GUILayout.Button(sprite.texture))
            {
                bluePrintCreatorTile.tileOption = tileOption;
            }

            spriteNumber = bluePrintCreatorTile.bluePrintCreator.TileSpriteOptionsList.FindIndex(x => x == bluePrintCreatorTile.tileOption);
            sprite = bluePrintCreatorTile.bluePrintCreator.TileSpriteSpriteList[spriteNumber];
            bluePrintCreatorTile.GetComponent<SpriteRenderer>().sprite = sprite;

            //tileOption.ToString());
            counter++;
            if (counter == 4)
            {
                GUILayout.EndHorizontal();
                GUILayout.BeginHorizontal();
                counter = 0;

            }
        }
        GUILayout.EndHorizontal();

        counter = 0;
        GUILayout.BeginHorizontal();
        foreach (TILEMATERIAL tileMaterial in Enum.GetValues(typeof(TILEMATERIAL)))
        {

            if (GUILayout.Button(tileMaterial.ToString()))
            {
                bluePrintCreatorTile.tileMaterial = tileMaterial;
            }

            //tileOption.ToString());
            counter++;
            if (counter == 4)
            {
                GUILayout.EndHorizontal();
                GUILayout.BeginHorizontal();
                counter = 0;

            }
        }
        GUILayout.EndHorizontal();
        GUILayout.EndVertical();

        base.OnInspectorGUI();
    }


}
