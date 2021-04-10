using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpawnFood : MonoBehaviour
{
    public Text foodText;

    public Transform location;
    private GameManager gm;
    public int randomIndex;

    float spawnTime;
    float prefabTimer = 3.0f;
    public int index;

    public AudioClip audioSFX;

    private List<bool> checkList;

    public void PlayAudio()
    {
        AudioManager.Instance.Play(audioSFX);
    }

    private void Start()
    {
        GameObject gameMger = GameObject.Find("GameManager");
        gm = gameMger.GetComponent<GameManager>();
        index = gm.foodIndex;
        spawnTime = Time.time + 2.0f;

        gm.foodList[0].ingredientsLeft[0] = 4;
        gm.foodList[0].ingredientsLeft[1] = 7;
        gm.foodList[0].ingredientsLeft[2] = 3;
        gm.foodList[0].ingredientsLeft[3] = 3;
        gm.foodList[0].ingredientsLeft[4] = 2;

        gm.foodList[1].ingredientsLeft[0] = 12;

        gm.foodList[2].ingredientsLeft[0] = 5;
        gm.foodList[2].ingredientsLeft[1] = 5;
        gm.foodList[2].ingredientsLeft[2] = 5;

        checkList = new List<bool>(new bool[gm.foodList[index].ingredientsList.Count]);
    }

    private void Update()
    {
        if (Time.time > spawnTime)
        {
            Spawner();

            spawnTime += 2.0f;
        }

        foodText.text = "";

        for (int i = 0; i < gm.foodList[index].ingredientsList.Count; i++)
        {
            foodText.text += gm.foodList[index].ingredientName[i] + ": " + gm.foodList[index].ingredientsLeft[i] + "\n";
            
            if (gm.foodList[index].ingredientsLeft[i] == 0)
            {
                checkList[i] = true;
            }
        }

        if (isReady())
        {
            SceneManager.LoadScene("PlatingScene");
        }
    }

    public void Spawner()
    {
        PlayAudio();
        randomIndex = Random.Range(0, gm.foodList[index].ingredientsList.Count);
        GameObject instance = Instantiate(gm.foodList[index].ingredientsList[randomIndex], location.position + new Vector3(Random.Range(-0.5f, 0.5f), 0, 0), Random.rotation);
        instance.transform.parent = location;
        Destroy(instance, prefabTimer);
    }

    private bool isReady()
    {
        for (int i = 0; i < gm.foodList[index].ingredientsList.Count; i++)
        {
            if (checkList[i] == false)
            {
                return false;
            }
        }
        return true;
    }
}
