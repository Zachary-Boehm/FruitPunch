using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    
    [SerializeField] private bool canMove = false;
    [Header("Audio Variables")]
    [SerializeField] private AudioManager soundManager;
    [SerializeField] private Slider[] VolumeSliders;

    [Header("Menu's and Loading Screen")]
    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private GameObject settingsMenu;

    [Header("Menu Variables")]
    [Range(0.00f, 1.00f)]//Adds a slider into the inspector for soundFX volume
    [SerializeField] private float soundFXVolume; //percent of FX volume
    [Range(0.00f, 1.00f)]//Adds a slider into the inspector for Music volume
    [SerializeField] private float musicVolume; //percent of Music volume

    [Header("Json Data")]
    public TextAsset weaponDataFile;
    public TextAsset gameDataFile;
    [SerializeField] private WeaponList WeaponsList = new WeaponList();
    public static GameManager GAMEMANAGER;
    private SaveData gameData = new SaveData();

    //------------------------------
    //Initialization
    //------------------------------

    private void Awake()
    {
        //create a singleton of this game manager
        if (GAMEMANAGER != null && GAMEMANAGER != this)
        {
            Destroy(this.gameObject);
        } else
        {
            GAMEMANAGER = this;
        }
    }
    private void Start()
    {
        ReadWeapons(); //Reads in the weapons
        LoadGame();
    }


    //------------------------------
    //Global Variable Getters
    //------------------------------
    public bool getCanMove()//return whether entities are allowed to move
    {
        return canMove;
    }

    //------------------------------
    //Scene Loading
    //------------------------------


    public void loadScene(SceneName scene, bool withLoadingScreen = true)
    {
        Debug.Log("Loading next scene");
        if(withLoadingScreen)
        {
            StartCoroutine(LoadingScreen());
        }
        SceneManager.LoadScene((int)scene);
        if(scene == SceneName.MainMenu)
        {
            playMusic("Menu Music");
            canMove = false;
        }
        if(scene == SceneName.Level_1)
        {
            playMusic("General Theme");
            canMove = true;
        }
    }

    IEnumerator LoadingScreen()
    {
        Debug.Log("Turning on loading screen");
        loadingScreen.SetActive(true);
        yield return new WaitForSeconds(5f);
        Debug.Log("Turning off loading screen");
        loadingScreen.SetActive(false);
    }


    //------------------------------
    //Json data methods
    //------------------------------


    //Reads in the list of weaons from json
    public void ReadWeapons()
    {
        WeaponsList = JsonUtility.FromJson<WeaponList>(weaponDataFile.text);
    }
    //writes the list of weapons to the json file
    public void WriteWeapons()
    {
        string jsonData = JsonUtility.ToJson(WeaponsList);
        File.WriteAllText(Application.dataPath + "/Scripts/GameMechanics/" + weaponDataFile.name + ".json", jsonData);
    }

    //returns the list of weapons that can be used
    public WeaponList getWeapons()
    {
        return WeaponsList;
    }

    public void SaveGame()
    {
        gameData.fxVolume = soundFXVolume;
        gameData.musicVolume = musicVolume;
        gameData.WriteGameData(gameDataFile);
        Debug.Log("GameSaved");
    }

    public void LoadGame()
    {
        gameData.ReadGameData(gameDataFile);
        Debug.Log(gameData.fxVolume + " | " + gameData.musicVolume);
        soundFXVolume = gameData.fxVolume;
        musicVolume = gameData.musicVolume;
        updateVolumes();
    }
    //------------------------------
    //Sound Methods
    //------------------------------


    //gets FX volume
    public float getFXVolume()
    {
        return soundFXVolume;
    }

    //gets music volume
    public float getMusicVolume()
    {
        return musicVolume;
    }

    //Plays the button hover sound
    public void playFX(string fxName)
    {
        soundManager.playFx(fxName);
    }

    public void playMusic(string musicName)
    {
        soundManager.playMusic(musicName);
    }

    public void updateFXVolume()
    {
        foreach(Slider s in VolumeSliders)
        {
            if(s.name == "FX Slider")
            {
                soundManager.updateVolume(0, s.value);
                soundFXVolume = s.value;
            }
        }
    }

    public void updateMusicVolume()
    {
        foreach(Slider s in VolumeSliders)
        {
            if(s.name == "Music Slider")
            {
                soundManager.updateVolume(1, s.value);
                musicVolume = s.value;
            }
        }
    }

    public void updateVolumes()
    {
        foreach(Slider s in VolumeSliders)
        {
            if(s.name == "Music Slider")
            {
                s.value = musicVolume;
            }
            else if(s.name == "FX Slider")
            {
                s.value = soundFXVolume;
            }
        }
    }
    //------------------------------
    //Menu Logic
    //------------------------------


    //Opens the settings menu
    public void openSettings()
    {
        settingsMenu.SetActive(true);
    }
    //Close the settings menu
    public void closeSettings()
    {
        settingsMenu.SetActive(false);
    }

    
}

[System.Serializable]
public class SaveData
{
    public float fxVolume;
    public float musicVolume;

    //Reads in the data from json
    public void ReadGameData(TextAsset file)
    {
        SaveData temp = JsonUtility.FromJson<SaveData>(file.text);
        fxVolume = temp.fxVolume;
        musicVolume = temp.musicVolume;
    }
    //writes the data to the json file
    public void WriteGameData(TextAsset file)
    {
        string jsonData = JsonUtility.ToJson(this);
        Debug.Log("Saving this data to save file: " + jsonData);
        File.WriteAllText(Application.dataPath + "/Scripts/GameMechanics/" + file.name + ".json", jsonData);
    }
}
