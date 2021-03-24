using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<FoodSO> foodList;
    public Button recipeSelect;
    public Text foodName;
    public GameObject gameWonUI;

    public int foodIndex = 0;

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        recipeSelect.image.sprite = foodList[foodIndex].foodImage;
        foodName.text = foodList[foodIndex].iName;
    }

    public void ChangeRight()
    {
        foodIndex++;
        if (foodIndex > 2)
        {
            foodIndex = 0;
        }
    }

    public void ChangeLeft()
    {
        foodIndex--;
        if (foodIndex < 0)
        {
            foodIndex = 2;
        }
    }

    public void GameOver()
    {
        gameWonUI.SetActive(true);
        //Time.timeScale = 0f;
    }

}
