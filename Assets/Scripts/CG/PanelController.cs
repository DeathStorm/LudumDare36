using UnityEngine;
using System.Collections;

public class PanelController : MonoBehaviour {

    public AudioSource audio;

    public GameObject panelMainShop;
    public GameObject panelUpgrade;
    public GameObject panelSell;
    public GameObject panelPurchase;
    public GameObject panelStorage;
    public GameObject panelForge;
    public GameObject panelCustomers;

    
    void Start () {
	
	} // END Start
	
	void Update ()
    {


        if (Input.GetKeyDown(KeyCode.F1) == true)
        {
            GetChange(0);
        }

	} // END Update

    public void GetChange(int panelID)
    {

        switch (panelID)
        {
            case 0:                                     // Main Shop
                panelMainShop.SetActive(true);
                panelUpgrade.SetActive(false);
                panelSell.SetActive(false);
                panelPurchase.SetActive(false);
                panelStorage.SetActive(false);
                panelForge.SetActive(false);
                panelCustomers.SetActive(false);
                audio.Play();
                break;
            case 1:                                     // Upgrade
                panelMainShop.SetActive(false);
                panelUpgrade.SetActive(true);
                panelSell.SetActive(false);
                panelPurchase.SetActive(false);
                panelStorage.SetActive(false);
                panelForge.SetActive(false);
                panelCustomers.SetActive(false);
                audio.Play();
                break;
            case 2:                                     // Sell
                panelMainShop.SetActive(false);
                panelUpgrade.SetActive(false);
                panelSell.SetActive(true);
                panelPurchase.SetActive(false);
                panelStorage.SetActive(false);
                panelForge.SetActive(false);
                panelCustomers.SetActive(false);
                audio.Play();
                break;
            case 3:                                     // Purchase
                panelMainShop.SetActive(false);
                panelUpgrade.SetActive(false);
                panelSell.SetActive(false);
                panelPurchase.SetActive(true);
                panelStorage.SetActive(false);
                panelForge.SetActive(false);
                panelCustomers.SetActive(false);
                audio.Play();
                break;
            case 4:                                     // Storage
                panelMainShop.SetActive(false);
                panelUpgrade.SetActive(false);
                panelSell.SetActive(false);
                panelPurchase.SetActive(false);
                panelStorage.SetActive(true);
                panelForge.SetActive(false);
                panelCustomers.SetActive(false);
                audio.Play();
                break;
            case 5:                                     // Forge
                panelMainShop.SetActive(false);
                panelUpgrade.SetActive(false);
                panelSell.SetActive(false);
                panelPurchase.SetActive(false);
                panelStorage.SetActive(false);
                panelForge.SetActive(true);
                panelCustomers.SetActive(false);
                audio.Play();
                break;
            case 6:                                     // Customer
                panelMainShop.SetActive(false);
                panelUpgrade.SetActive(false);
                panelSell.SetActive(false);
                panelPurchase.SetActive(false);
                panelStorage.SetActive(false);
                panelForge.SetActive(false);
                panelCustomers.SetActive(true);
                audio.Play();
                break;
        }

    } // END GetChange
} // END Class