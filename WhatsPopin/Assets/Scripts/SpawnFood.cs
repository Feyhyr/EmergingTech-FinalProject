using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnFood : MonoBehaviour
{
    public Text food1;
    public Text food2;

    public Transform location;
    private GameManager gm;

    float spawnTime;
    float prefabTimer = 3.0f;
    int index;

    private void Start()
    {
        GameObject gameMger = GameObject.Find("GameManager");
        gm = gameMger.GetComponent<GameManager>();
        index = gm.foodIndex;
        spawnTime = Time.time + 2.0f;

        food1.text = " " + gm.foodList[index].ingredientName[0] + ": " + gm.foodList[index].ingredientsLeft[0];
        food2.text = " " + gm.foodList[index].ingredientName[1] + ": " + gm.foodList[index].ingredientsLeft[1];
    }

    private void Update()
    {
        

        if (Time.time > spawnTime)
        {
            Spawner();

            spawnTime += 2.0f;
        }
    }

    public void Spawner()
    {
        GameObject instance = Instantiate(gm.foodList[index].ingredientsList[Random.Range(0, gm.foodList[index].ingredientsList.Count)], location.position + new Vector3(Random.Range(-2, 2), 0, 0), Random.rotation);
        instance.transform.parent = location;
        Destroy(instance, prefabTimer);
    }
}
