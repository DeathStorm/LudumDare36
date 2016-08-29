using UnityEngine;
using System.Collections;

public class ButtonReaction : MonoBehaviour {

    public GameObject panelHolder;
    PanelController pController;
    public int panelUID;
    void Start ()
    {
        pController = GameObject.Find("PanelContainer").GetComponent<PanelController>();
	} // END Start
	
	void Update ()
    {
	
	} // END Update

    public void ButtonPress(int panelID)
    {
        pController.GetChange(panelID);
        //Debug.Log(this.gameObject.name);
    } // END ButtonPress


    public void OnMouseDown()
    {
       // pController.GetChange(panelUID);
    } // END OnMouseDown



} // END Class
