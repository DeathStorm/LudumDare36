using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using WEAPONTYPES = ENUMS.WEAPONTYPES;

public class CustomerContainer : MonoBehaviour {

    public GameObject customerPrefab;
    public GameObject panelCustomers;

    public List<GameObject> phase1 = new List<GameObject>();    // Anfrage Liste
    public List<GameObject> phase2 = new List<GameObject>();    // Angenommen Liste 
    public List<GameObject> phase3 = new List<GameObject>();    // In Bearbeitung

    public int customerCount = 0;

    int weaponAmount;

    int customerDifficultyCount;
    public int customerBeginnerCount = 3;
    public int customerEasyCount = 5;
    public int customerMiddleCount = 3;
    public int customerHardCount = 1;

    void Start ()
    {

        weaponAmount = Enum.GetValues(typeof(WEAPONTYPES)).Length;
        UpdateCustomerDifficultyCount();                     //customerDifficultyCount = customerBeginnerCount + customerEasyCount + customerMiddleCount + customerHardCount;

    } // END Start
	
	void Update ()
    {


        

	} // END Update


    public int GetDifficultyCheck()
    {
        // 0 = wähle Random | 1 = Beginner | 2 = Easy | 3 = Middle | 4 = Hard
        if (customerDifficultyCount >= 0)
        {
            if (customerBeginnerCount >= 0)
            {
                customerBeginnerCount--;
                customerCount++;
                return 1;
            }
            else if (customerEasyCount >= 0)
            {
                customerEasyCount--;
                customerCount++;
                return 2;
            }
            else if (customerMiddleCount >= 0)
            {
                customerMiddleCount--;
                customerCount++;
                return 3;
            }
            else if (customerHardCount >= 0)
            {
                customerHardCount--;
                customerCount++;
                return 4;
            }
        }

        customerCount++;
        return 0;

    } // END DifficultyCheck

    public int GetWeapon()
    {
        // WEAPONTYPES.BroadSword; WEAPONTYPES.Dagger; WEAPONTYPES.LongSword //ShortSword
        int i = UnityEngine.Random.Range(0, weaponAmount - 1);
        return i;
    } // END GetWeapon

    void UpdateCustomerDifficultyCount()
    {
        customerDifficultyCount = customerBeginnerCount + customerEasyCount + customerMiddleCount + customerHardCount;
    } // END UpdateCustomerDifficultyCount

    public void AddToList(GameObject newObject)
    {
        phase1.Add(newObject);


    } // END AddToList

    public void NewCustomer()
    {
        GameObject newCustom = GameObject.Instantiate(customerPrefab);
        newCustom.transform.position = new Vector3(0f, 0f, 0f);
    } // END NewCustomer
} // END Class
