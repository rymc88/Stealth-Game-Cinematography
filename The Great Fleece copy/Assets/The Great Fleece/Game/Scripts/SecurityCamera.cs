using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityCamera : MonoBehaviour
{
    public GameObject gameOverCutScene;
    public Animator anim;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            MeshRenderer render = GetComponent<MeshRenderer>();
            Color color = new Color(0.6f, .1f, .1f, .3f);
            render.material.SetColor("_TintColor", color);
            anim.enabled = false;
            StartCoroutine(FreezeCameras());
            
        }
    }

    IEnumerator FreezeCameras()
    {
        yield return new WaitForSeconds(.5f);
        gameOverCutScene.SetActive(true);
    }

}
