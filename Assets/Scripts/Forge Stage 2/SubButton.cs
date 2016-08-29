using UnityEngine;
using System.Collections;

using SUBBUTTONTYPE = ENUMS.SUBBUTTONTYPES;
public class SubButton : MonoBehaviour
{
    
    

    public Color activeColor;
    public Color standardColor;

    private SpriteRenderer spriteRenderer;
    private PolygonCollider2D polygonCollider;

    public Stage2Tile stage2Tile;
    private Stage2_GridManager gridManager;

    public SUBBUTTONTYPE buttonType;


    // Use this for initialization
    void Start()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        polygonCollider = this.GetComponent<PolygonCollider2D>();
        gridManager = stage2Tile.gridManager;

        standardColor = spriteRenderer.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (stage2Tile.isActive && (!spriteRenderer.enabled || !polygonCollider.enabled))
        { 
            spriteRenderer.enabled = true;
            polygonCollider.enabled = true;
        }
        else if (!stage2Tile.isActive && (spriteRenderer.enabled || polygonCollider.enabled))
        { 
            spriteRenderer.enabled = false;
            polygonCollider.enabled = false;
        }
    }


    void OnMouseEnter()
    {
        
        if (stage2Tile.isActive)
        {
            stage2Tile.ShowValues();
            //Debug.Log("ENTER");
            spriteRenderer.color = activeColor;
        }
    }

    void OnMouseExit()
    {
        stage2Tile.ClearValues();
        //Debug.Log("EXIT");
        spriteRenderer.color = standardColor;
    }

    void OnMouseDown()
    {
        if (stage2Tile.isActive)
        {
            stage2Tile.Smithy(buttonType);
            Debug.Log("Clicked "+buttonType.ToString());
        }
    }

}
