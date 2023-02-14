using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// credit to Michael Guerrero

public class LoadGame : MonoBehaviour
{
    public string loadScene;

    public void LoadScene()
    {
        SceneManager.LoadScene(loadScene, LoadSceneMode.Single);
    }
}
