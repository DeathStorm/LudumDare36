using UnityEngine;
using UnityEngine.UI;
using System.Collections;

using WEAPONTYPES = ENUMS.WEAPONTYPES;

public class Stage1PickWeaponWindow : MonoBehaviour
{
    public Stage1_GridManager gridManager;

    public Dropdown weaponDropDown;


    // Use this for initialization
    void Start()
    {
        weaponDropDown.ClearOptions();
        Dropdown.OptionData option;
        foreach (WEAPONTYPES weaponType in gridManager.weaponDictionary.Keys)
        {
            option = new Dropdown.OptionData();
            option.text = weaponType.ToString();
            weaponDropDown.options.Add(option);
        }
        weaponDropDown.value = 0;
        weaponDropDown.RefreshShownValue();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void ButtonClickChoose()
    {
        gridManager.selectedWeapon = gridManager.stringToWeaponType[weaponDropDown.options[weaponDropDown.value].text];
        gridManager.CreateNewGrid();
        this.gameObject.SetActive(false);
    }
}
