using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFood : MonoBehaviour
{
    //public GameObject foodPrefab;
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
