using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabKeyCardActivation : MonoBehaviour
{
    public GameObject cutScene;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            cutScene.SetActive(true);
            GameManager.Instance.HasCard = true;
        }
    }
}
