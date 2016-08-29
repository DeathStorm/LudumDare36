using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Customer : MonoBehaviour {

    /*
        -> Schwierigkeit
            **Qualitätswunsch
            *Materialwunsch
            **gibt Ruf
            **gibt Gold

     -> Produktwunsch
     -> hat Namen (Customer #001)
     -> befindet sich in Phase X
     -> braucht den Container zur Verlinkung
         
         */


    public CustomerContainer cContainer;
    public int phase = 0;               // 0 = Beim Generieren | 1 = Anfrage | 2 = Angenommen | 3 = In Bearbeitung
    public string customerName;

    public int difficulty;              // holt sich die Info aus dem Container
    public int quality;
    public List<int> materials = new List<int>();    // 1 = Leder | 2 = Holz | 3 = Eisen
    public int fame;
    public int gold;
    public int product;                    


    void Start()
    {

        this.gameObject.transform.parent = GameObject.Find("CustomerContainer").gameObject.transform;
        cContainer = GameObject.Find("CustomerContainer").GetComponent<CustomerContainer>();

        product = cContainer.GetWeapon();
        difficulty = cContainer.GetDifficultyCheck();
        DifficultySettings();
        
        customerName = "Customer #" + cContainer.customerCount;
        this.gameObject.name = customerName;
        ChangePhase(1);
    } // END Start

    void Update()
    {

    } // END Update

    void DifficultySettings()
    {

        switch (difficulty)
        {
            case 0:
                quality = 40;
                gold = 300;
                fame = 10;

                for (int i = 0; i < 3; i++)
                {
                    materials.Add(1);
                   // Debug.Log(i);
                }

                break;                      // #####
            case 1:
                int choiceDifficult;
                int choicePosition = 0;


                quality = UnityEngine.Random.Range(40,50);
                gold = UnityEngine.Random.Range(250, 350);
                fame = UnityEngine.Random.Range(10, 20); 

                choiceDifficult = UnityEngine.Random.Range(0, 1);   // 0 = Einfachste Materialien | 1 = ein mittleres mit dabei

                if (choiceDifficult == 1)
                {
                    choicePosition = UnityEngine.Random.Range(1, 3);    // 1 = Leder | 2 = Holz | 3 = Eisen

                }

                for (int i = 0; i < 3; i++)
                {
                    if (choiceDifficult == 0)
                    {
                        materials.Add(1);
                    }
                    else
                    {
                        if (choicePosition == (i + 1))
                        {
                            materials.Add(2);
                        }
                        else
                        {
                            materials.Add(1);
                        }
                    }                  
                }
                break;                      // #####
            case 2:
                int choiceDifficultEasy;
                int choicePositionEasy = 0;


                quality = UnityEngine.Random.Range(40, 50);
                gold = UnityEngine.Random.Range(250, 350);
                fame = UnityEngine.Random.Range(10, 20);

                choiceDifficultEasy = UnityEngine.Random.Range(0, 1);   // 0 = Einfachste Materialien | 1 = ein mittleres mit dabei

                if (choiceDifficultEasy == 1)
                {
                    choicePositionEasy = UnityEngine.Random.Range(1, 3);    // 1 = Leder | 2 = Holz | 3 = Eisen

                }

                for (int i = 0; i < 3; i++)
                {
                    if (choiceDifficultEasy == 0)
                    {
                        materials.Add(1);
                    }
                    else
                    {
                        if (choicePositionEasy == (i + 1))
                        {
                            materials.Add(2);
                        }
                        else
                        {
                            materials.Add(1);
                        }
                    }
                }
                break;                      // #####
            case 3:
                int choiceDifficultMiddle;
                int choicePositionMiddle = 0;


                quality = UnityEngine.Random.Range(55, 70);
                gold = UnityEngine.Random.Range(400, 700);
                fame = UnityEngine.Random.Range(20, 40);

                choiceDifficultMiddle = UnityEngine.Random.Range(1, 3);   // 1 = ein einfaches Material | 2 = alles mittleres Material | 3 = ein schweres Material

                if (choiceDifficultMiddle != 2)
                {
                    choicePositionMiddle = UnityEngine.Random.Range(1, 3);    // 1 = Leder | 2 = Holz | 3 = Eisen

                }

                for (int i = 0; i < 3; i++)
                {
                    if (choiceDifficultMiddle == 2)
                    {
                        materials.Add(2);
                    }
                    else if (choiceDifficultMiddle == 1)
                    {
                        if (choicePositionMiddle == (i + 1))
                        {
                            materials.Add(1);
                        }
                        else
                        {
                            materials.Add(2);
                        }
                    }
                    else
                    {
                        if (choicePositionMiddle == (i + 1))
                        {
                            materials.Add(3);
                        }
                        else
                        {
                            materials.Add(2);
                        }
                    }
                }
                break;                      // #####
            case 4:
                int choiceDifficultHard;
                int choicePositionHard = 0;
                int choicePositionHard1 = 0;
                int choicePositionHard2 = 0;

                quality = UnityEngine.Random.Range(75, 95);
                gold = UnityEngine.Random.Range(700, 1400);
                fame = UnityEngine.Random.Range(40, 75);

                choiceDifficultHard = UnityEngine.Random.Range(1, 3);   // 1 = ein schweres Material | 2 = zwei schwere Materialien | 3 = drei schwere Materialien

                if (choiceDifficultHard == 1)
                {
                    choicePositionHard = UnityEngine.Random.Range(1, 3);    // 1 = Leder | 2 = Holz | 3 = Eisen

                }
                else if (choiceDifficultHard == 2)
                {
                    choicePositionHard1 = UnityEngine.Random.Range(1, 3);    // 1 = Leder | 2 = Holz | 3 = Eisen
                    choicePositionHard2 = UnityEngine.Random.Range(1, 3);    // 1 = Leder | 2 = Holz | 3 = Eisen

                    if (choicePositionHard1 == choicePositionHard2)
                    {
                        while (choicePositionHard2 == choicePositionHard1)
                        {
                            choicePositionHard2 = UnityEngine.Random.Range(1, 3);
                        }
                    }
                }

                for (int i = 0; i < 3; i++)
                {
                    if (choiceDifficultHard == 3)
                    {
                        materials.Add(3);
                    }
                    else if (choiceDifficultHard == 2)
                    {
                        if (choicePositionHard1 == (i + 1))
                        {
                            materials.Add(3);
                        }
                        else if (choicePositionHard2 == (i + 1))
                        {
                            materials.Add(3);
                        }
                        else
                        {
                            materials.Add(2);
                        }
                    }
                    else
                    {
                        if (choicePositionHard == (i + 1))
                        {
                            materials.Add(3);
                        }
                        else
                        {
                            materials.Add(2);
                        }
                    }
                }
                break;                      // #####
        }


    } // END DifficultySettings

    public void ChangePhase(int newPhase)
    {
        switch (newPhase)                               // 0 = kann gelöscht werden | 1 = wechseln zu Phase 1 | 2 = wechseln zu Phase 2 | 3 = wechseln zu Phase 3
        {
            case 0:
                switch (phase)
                {
                    case 1:
                        int j = cContainer.phase1.FindIndex(x => x == this.gameObject);
                        cContainer.phase1.RemoveAt(j);
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                }
                Deletion();
                break;
            case 1:
                cContainer.phase1.Add(this.gameObject);
                phase = 1;
                break;
            case 2:

                cContainer.phase2.Add(this.gameObject);

                int i = cContainer.phase1.FindIndex(x => x == this.gameObject);
                cContainer.phase1.RemoveAt(i);

                break;
            case 3:
                break;

        }
    } // END ChangePhase

    void Deletion()
    {
        GameObject.DestroyImmediate(this.gameObject);
    } // END Deletion

} // END Class