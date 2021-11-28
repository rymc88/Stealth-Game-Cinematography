using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyes : MonoBehaviour
{
    public GameObject gameOverCutScene;

    //ontriggerenter
    //check if it is darren Player Tag
    //enable the game over cutscene

   

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            gameOverCutScene.SetActive(true);
        }
    }
}
