using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatedIngredients : MonoBehaviour
{
    private SpawnFood sp;
    private GameManager gm;

    public AudioClip audioSFX;

    public void PlayAudio()
    {
        AudioManager.Instance.Play(audioSFX);
    }

    private void Start()
    {
        GameObject gameMger = GameObject.Find("GameManager");
        gm = gameMger.GetComponent<GameManager>();
        GameObject spawnMger = GameObject.Find("SpawnFoodMngr");
        sp = spawnMger.GetComponent<SpawnFood>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Food"))
        {
            if (gm.foodList[sp.index].ingredientsLeft[sp.randomIndex] <= 0)
            {
                gm.foodList[sp.index].ingredientsLeft[sp.randomIndex] = 0;
            }
            else
            {
                gm.foodList[sp.index].ingredientsLeft[sp.randomIndex]--;
            }
            PlayAudio();
            Destroy(collision.gameObject);
        }
    }
}
