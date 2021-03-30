using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameWon : MonoBehaviour
{
    public GameObject gameWonUI;

    public void GameOver()
    {
        gameWonUI.SetActive(true);

    }


}
