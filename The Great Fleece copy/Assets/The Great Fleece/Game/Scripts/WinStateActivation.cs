using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinStateActivation : MonoBehaviour
{
    public GameObject cutScene;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (GameManager.Instance.HasCard == true)
            {
                cutScene.SetActive(true);
            }
            else
            {
                Debug.Log("You must get key!");
            }
        }
    }
}
