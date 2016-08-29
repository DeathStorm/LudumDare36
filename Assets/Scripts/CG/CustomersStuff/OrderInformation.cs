using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OrderInformation : MonoBehaviour {

    CustomerContainer cContainer;
    GameObject currentCustomerObject;
    Customer currentCustomer;

    public Text customerNameVAR;
    public Text goldVAR;
    public Text fameVAR;
    public Text productVAR;
    public Text mat1VAR;
    public Text mat2VAR;
    public Text mat3VAR;
    public Text qualityVAR;

    public GameObject butAccept;
    public GameObject butDecline;

    void Start ()
    {

        cContainer = GameObject.Find("CustomerContainer").GetComponent<CustomerContainer>();


	} // END Start
	
	void Update ()
    {
	
	} // END Update

    public void SendInformationFromOrderList(int buttonID)
    {

        currentCustomer = cContainer.phase1[buttonID].GetComponent<Customer>();
        currentCustomerObject = currentCustomer.gameObject;
        customerNameVAR.text = currentCustomer.customerName;
        goldVAR.text = currentCustomer.gold.ToString();
        fameVAR.text = currentCustomer.fame.ToString();
        switch (currentCustomer.product)
        {
            case 0:
                productVAR.text = "Broad Sword";
                break;
            case 1:
                productVAR.text = "Dagger";
                break;
            case 2:
                productVAR.text = "Long Sword";
                break;
            case 3:
                productVAR.text = "Short Sword";
                break;
        }
        for (int i = 0; i < 3; i++)
        {
            switch (i)
            {
                case 0:
                    string thisLeather = "";

                    int leather = currentCustomer.materials[0];

                    switch (leather)
                    {
                        case 1:
                            thisLeather = "Pigskin";
                            break;
                        case 2:
                            thisLeather = "Crocodile Leather";
                            break;
                        case 3:
                            thisLeather = "Unicorn Leather";
                            break;
                    }

                    mat1VAR.text = thisLeather;
                    break;
                case 1:
                    string thisWood = "";

                    int wood = currentCustomer.materials[1];

                    switch (wood)
                    {
                        case 1:
                            thisWood = "Birch Wood";
                            break;
                        case 2:
                            thisWood = "Cherry Wood";
                            break;
                        case 3:
                            thisWood = "Mahaghoni";
                            break;
                    }

                    mat2VAR.text = thisWood;

                    break;
                case 2:
                    string thisIron = "";

                    int iron = currentCustomer.materials[2];

                    switch (iron)
                    {
                        case 1:
                            thisIron = "Iron";
                            break;
                        case 2:
                            thisIron = "Steel";
                            break;
                        case 3:
                            thisIron = "Mythril";
                            break;
                    }

                    mat3VAR.text = thisIron;
                    break;
            }
        }
        qualityVAR.text = currentCustomer.quality.ToString();

        butAccept.SetActive(true);
        butDecline.SetActive(true);

    } // END SendInformationFromOrderList

    public void SendInformationFromWaitlist(int buttonID)
    {
        butAccept.SetActive(false);
        butDecline.SetActive(false);

        currentCustomer = cContainer.phase2[buttonID].GetComponent<Customer>();
        currentCustomerObject = currentCustomer.gameObject;
        customerNameVAR.text = currentCustomer.customerName;
        goldVAR.text = currentCustomer.gold.ToString();
        fameVAR.text = currentCustomer.fame.ToString();
        switch (currentCustomer.product)
        {
            case 0:
                productVAR.text = "Broad Sword";
                break;
            case 1:
                productVAR.text = "Dagger";
                break;
            case 2:
                productVAR.text = "Long Sword";
                break;
            case 3:
                productVAR.text = "Short Sword";
                break;
        }
        for (int i = 0; i < 3; i++)
        {
            switch (i)
            {
                case 0:
                    string thisLeather = "";

                    int leather = currentCustomer.materials[0];

                    switch (leather)
                    {
                        case 1:
                            thisLeather = "Pigskin";
                            break;
                        case 2:
                            thisLeather = "Crocodile Leather";
                            break;
                        case 3:
                            thisLeather = "Unicorn Leather";
                            break;
                    }

                    mat1VAR.text = thisLeather;
                    break;
                case 1:
                    string thisWood = "";

                    int wood = currentCustomer.materials[1];

                    switch (wood)
                    {
                        case 1:
                            thisWood = "Beech Wood";
                            break;
                        case 2:
                            thisWood = "Cherry Wood";
                            break;
                        case 3:
                            thisWood = "Mahaghoni";
                            break;
                    }

                    mat2VAR.text = thisWood;

                    break;
                case 2:
                    string thisIron = "";

                    int iron = currentCustomer.materials[2];

                    switch (iron)
                    {
                        case 1:
                            thisIron = "Iron";
                            break;
                        case 2:
                            thisIron = "Steel";
                            break;
                        case 3:
                            thisIron = "Mythril";
                            break;
                    }

                    mat3VAR.text = thisIron;
                    break;
            }
        }
        qualityVAR.text = currentCustomer.quality.ToString();


    } // END SendInformationFromWaitlist

    void CleanOrderInformation()
    {

        customerNameVAR.text = "-";
        goldVAR.text = "-";
        fameVAR.text = "-";
        productVAR.text = "-";
        mat1VAR.text = "-";
        mat2VAR.text = "-";
        mat3VAR.text = "-";
        qualityVAR.text = "-";
        currentCustomer = null;

} // END CleanOrderInformation

    public void PressAccept()
    {
        currentCustomer.ChangePhase(2);
        CleanOrderInformation();
        butAccept.SetActive(false);
        butDecline.SetActive(false);
    } // END PressAccept

    public void PressDecline()
    {
        currentCustomer.ChangePhase(0);
        CleanOrderInformation();
        butAccept.SetActive(false);
        butDecline.SetActive(false);
    } // END PressDecline

} // END Class