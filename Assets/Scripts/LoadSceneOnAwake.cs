using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadSceneOnAwake : MonoBehaviour
{
    [SerializeField]private SceneName Scene;
    private void Start() 
    {
        GameManager.GAMEMANAGER.loadScene(Scene, false);//Load scene specified by Scene variable
    }
}
