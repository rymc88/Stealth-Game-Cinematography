using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
   
    private NavMeshAgent _agent;
    private Animator _animator;
    private Vector3 _target;
    public GameObject coinPrefab;
    public AudioClip coinSoundEffect;
    private bool _hasThrownCoin = false;
    

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponentInChildren<Animator>();
        
    }

  
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if(Physics.Raycast(rayOrigin, out hitInfo))
            {
                //Debug.Log("Hit: " + hitInfo.point);
                _agent.SetDestination(hitInfo.point);
                _animator.SetBool("Walk", true);
                _target = hitInfo.point;
            }

            
        }

        float distance = Vector3.Distance(transform.position, _target);

        if(distance < 1.0f)
        {
            _animator.SetBool("Walk", false);
        }

        if (Input.GetMouseButtonDown(1) && _hasThrownCoin == false)
        {
            Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if(Physics.Raycast(rayOrigin, out hitInfo))
            {
                _animator.SetTrigger("Throw");
                _hasThrownCoin = true;
                Instantiate(coinPrefab, hitInfo.point, Quaternion.identity);
                AudioSource.PlayClipAtPoint(coinSoundEffect, transform.position);
                SendAIToCoinSpot(hitInfo.point);
            }

        }

    }

    void SendAIToCoinSpot(Vector3 coinPosition)
    {
        GameObject[] guards = GameObject.FindGameObjectsWithTag("Guard1");
        foreach(var guard in guards)
        {
            NavMeshAgent currentAgent = guard.GetComponent<NavMeshAgent>();
            GuardAI currentGuard = guard.GetComponent<GuardAI>();
            Animator currentAnim = guard.GetComponent<Animator>();

            currentGuard.coinTossed = true;
            currentAgent.SetDestination(coinPosition);
            currentAnim.SetBool("Walk", true);
            currentGuard.coinPosition = coinPosition;
            
        }
    }


}
