using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]private GameObject LoadingScreen;
    
    [Header("Weapons Json Data")]
    public TextAsset textJSON;
    [SerializeField]private WeaponList WeaponsList = new WeaponList();
   
    private void Start() 
    {
        ReadWeapons();
    }
    public void ReadWeapons()
    {
        WeaponsList = JsonUtility.FromJson<WeaponList>(textJSON.text);
    }
    public void WriteWeapons()
    {
        string jsonData = JsonUtility.ToJson(WeaponsList);
        File.WriteAllText(Application.dataPath + "/Scripts/Weapons/WeaponData.json", jsonData);
    }

    public WeaponList getWeapons()
    {
        return WeaponsList;
    }
}
