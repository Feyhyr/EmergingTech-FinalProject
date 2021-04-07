using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishedFood : MonoBehaviour
{

    private GameManager gm;

    public Transform foodPlacement;

    // Start is called before the first frame update
    void Start()
    {
        GameObject gameMger = GameObject.Find("GameManager");
        gm = gameMger.GetComponent<GameManager>();

        //gm.foodList[index].foodPrefab.transform = foodPlacement;

        Instantiate(gm.foodList[gm.foodIndex].foodPrefab, foodPlacement);

    }

}
