using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Menu's and Loading Screen")]
    [SerializeField]private GameObject LoadingScreen;
    [SerializeField] private GameObject SettingsMenu;

    [Header("Weapons Json Data")]
    public TextAsset textJSON;
    [SerializeField]private WeaponList WeaponsList = new WeaponList();
    public static GameManager GAMEMANAGER;

    private void Awake() 
    {
        //create a singleton of this game manager
        if(GAMEMANAGER != null && GAMEMANAGER != this)
        {
            Destroy(this.gameObject);
        }else
        {
            GAMEMANAGER = this;
        }
    }
    private void Start() 
    {
        ReadWeapons();
    }
    //Reads in the list of weaons from json
    public void ReadWeapons()
    {
        WeaponsList = JsonUtility.FromJson<WeaponList>(textJSON.text);
    }
    //writes the list of weapons to the json file
    public void WriteWeapons()
    {
        string jsonData = JsonUtility.ToJson(WeaponsList);
        File.WriteAllText(Application.dataPath + "/Scripts/Weapons/WeaponData.json", jsonData);
    }

    //returns the list of weapons that can be used
    public WeaponList getWeapons()
    {
        return WeaponsList;
    }

    //Opens the settings menu
    public void openSettings()
    {
        SettingsMenu.SetActive(true);
    }
    //Close the settings menu
    public void closeSettings()
    {
        SettingsMenu.SetActive(false);
    }
}
