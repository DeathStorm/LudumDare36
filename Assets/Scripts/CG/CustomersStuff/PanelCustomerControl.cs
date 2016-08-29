using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PanelCustomerControl : MonoBehaviour {

    CustomerContainer cContainer;

    public GameObject orderButtton1;
    public GameObject orderButtton2;
    public GameObject orderButtton3;
    public GameObject orderButtton4;
    public GameObject orderButtton5;
    public GameObject orderButtton6;
    public GameObject orderButtton7;
    public GameObject orderButtton8;


    public GameObject waitButtton1;
    public GameObject waitButtton2;
    public GameObject waitButtton3;
    public GameObject waitButtton4;
    public GameObject waitButtton5;
    public GameObject waitButtton6;
    public GameObject waitButtton7;
    public GameObject waitButtton8;

    void Start ()
    {
        cContainer = GameObject.Find("CustomerContainer").GetComponent<CustomerContainer>();
        

    } // END Start
	
	void Update ()
    {
        CheckOrderButton();
        CheckEmptyOrderButton();

        CheckWaitButton();
        CheckEmptyWaitButton();

    } // END Update

    void CheckOrderButton()
    {
        if (cContainer.phase1.Count > 0)
        {
            if (cContainer.phase1.Count <= 8)
            {
                for (int i = 0; i < cContainer.phase1.Count; i++)
                {
                    switch (i)
                    {
                        case 0:
                            orderButtton1.SetActive(true);
                            break;
                        case 1:
                            orderButtton2.SetActive(true);
                            break;
                        case 2:
                            orderButtton3.SetActive(true);
                            break;
                        case 3:
                            orderButtton4.SetActive(true);
                            break;
                        case 4:
                            orderButtton5.SetActive(true);
                            break;
                        case 5:
                            orderButtton6.SetActive(true);
                            break;
                        case 6:
                            orderButtton7.SetActive(true);
                            break;
                        case 7:
                            orderButtton8.SetActive(true);
                            break;
                    }
                }
            }
            else
            {
                for (int i = 0; i < 8; i++)
                {
                    switch (i)
                    {
                        case 0:
                            orderButtton1.SetActive(true);
                            break;
                        case 1:
                            orderButtton2.SetActive(true);
                            break;
                        case 2:
                            orderButtton3.SetActive(true);
                            break;
                        case 3:
                            orderButtton4.SetActive(true);
                            break;
                        case 4:
                            orderButtton5.SetActive(true);
                            break;
                        case 5:
                            orderButtton6.SetActive(true);
                            break;
                        case 6:
                            orderButtton7.SetActive(true);
                            break;
                        case 7:
                            orderButtton8.SetActive(true);
                            break;
                    }

                }
            }
        }
    } // END CHeckOrderButton

    void CheckEmptyOrderButton()
    {
        for (int i = 0; i < 8; i++)
        {
            switch (i)
            {
                case 0:
                    if (cContainer.phase1.Count == 0)
                    {
                        orderButtton1.SetActive(false);
                       // Debug.Log("Me, its me!");
                    }
                    break;
                case 1:
                    if (cContainer.phase1.Count == 1)
                    {
                        orderButtton2.SetActive(false);

                    }
                    break;
                case 2:
                    if (cContainer.phase1.Count == 2)
                    {
                        orderButtton3.SetActive(false);

                    }
                    break;
                case 3:
                    if (cContainer.phase1.Count == 3)
                    {
                        orderButtton4.SetActive(false);

                    }
                    break;
                case 4:
                    if (cContainer.phase1.Count == 4)
                    {
                        orderButtton5.SetActive(false);

                    }
                    break;
                case 5:
                    if (cContainer.phase1.Count == 5)
                    {
                        orderButtton6.SetActive(false);

                    }
                    break;
                case 6:
                    if (cContainer.phase1.Count == 6)
                    {
                        orderButtton7.SetActive(false);

                    }
                    break;
                case 7:
                    if (cContainer.phase1.Count == 7)
                    {
                        orderButtton8.SetActive(false);

                    }
                    break;
                
            }


        }
    } // END CheckEmptyOrderButton

    void CheckWaitButton()
    {
        if (cContainer.phase2.Count > 0)
        {
            if (cContainer.phase2.Count <= 8)
            {
                for (int i = 0; i < cContainer.phase2.Count; i++)
                {
                    switch (i)
                    {
                        case 0:
                            waitButtton1.SetActive(true);
                            break;
                        case 1:
                            waitButtton2.SetActive(true);
                            break;
                        case 2:
                            waitButtton3.SetActive(true);
                            break;
                        case 3:
                            waitButtton4.SetActive(true);
                            break;
                        case 4:
                            waitButtton5.SetActive(true);
                            break;
                        case 5:
                            waitButtton6.SetActive(true);
                            break;
                        case 6:
                            waitButtton7.SetActive(true);
                            break;
                        case 7:
                            waitButtton8.SetActive(true);
                            break;
                    }



                }
            }
            else
            {
                for (int i = 0; i < 8; i++)
                {
                    switch (i)
                    {
                        case 0:
                            waitButtton1.SetActive(true);
                            break;
                        case 1:
                            waitButtton2.SetActive(true);
                            break;
                        case 2:
                            waitButtton3.SetActive(true);
                            break;
                        case 3:
                            waitButtton4.SetActive(true);
                            break;
                        case 4:
                            waitButtton5.SetActive(true);
                            break;
                        case 5:
                            waitButtton6.SetActive(true);
                            break;
                        case 6:
                            waitButtton7.SetActive(true);
                            break;
                        case 7:
                            waitButtton8.SetActive(true);
                            break;
                    }

                }
            }
        }
    } // END CheckWaitButton

    void CheckEmptyWaitButton()
    {
        for (int i = 0; i < 8; i++)
        {
            switch (i)
            {
                case 0:
                    if (cContainer.phase2.Count == 0)
                    {
                        waitButtton1.SetActive(false);

                    }
                    break;
                case 1:
                    if (cContainer.phase2.Count == 1)
                    {
                        waitButtton2.SetActive(false);

                    }
                    break;
                case 2:
                    if (cContainer.phase2.Count == 2)
                    {
                        waitButtton3.SetActive(false);

                    }
                    break;
                case 3:
                    if (cContainer.phase2.Count == 3)
                    {
                        waitButtton4.SetActive(false);

                    }
                    break;
                case 4:
                    if (cContainer.phase2.Count == 4)
                    {
                        waitButtton5.SetActive(false);

                    }
                    break;
                case 5:
                    if (cContainer.phase2.Count == 5)
                    {
                        waitButtton6.SetActive(false);

                    }
                    break;
                case 6:
                    if (cContainer.phase2.Count == 6)
                    {
                        waitButtton7.SetActive(false);

                    }
                    break;
                case 7:
                    if (cContainer.phase2.Count == 7)
                    {
                        waitButtton1.SetActive(false);

                    }
                    break;

            }


        }


    } // END CheckEmptyWaitButton


} // END Class
