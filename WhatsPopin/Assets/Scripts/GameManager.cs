using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<FoodSO> foodList;
    public Button recipeSelect;

    private void Start()
    {
        recipeSelect.image.sprite = foodList[0].foodImage;
    }
}
