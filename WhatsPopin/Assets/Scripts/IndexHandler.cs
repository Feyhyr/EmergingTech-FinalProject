using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IndexHandler : MonoBehaviour
{
    public GameObject gameObj;
    private GameManager gm;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelLoaded;
    }

    public void CallRight()
    {
        gm.ChangeRight();
    }

    public void CallLeft()
    {
        gm.ChangeLeft();
    }

    private void OnLevelLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "MainMenuScene")
        {
            gameObj = GameObject.Find("GameManager");
            gm = gameObj.GetComponent<GameManager>();
        }
    }
}
