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
    } // END ButtonPress


    public void OnMouseDown()
    {
        pController.GetChange(panelUID);
    } // END OnMouseDown



} // END Class
