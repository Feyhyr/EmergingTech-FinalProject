using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create Food")]
public class FoodSO : ScriptableObject
{
    public string iName;
    public Sprite foodImage;
    public GameObject foodPrefab;
    public List<GameObject> ingredientsList;
    public List<string> ingredientName;
    public List<int> ingredientsLeft;
}
