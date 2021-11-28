using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class GuardAI : MonoBehaviour
{
    public List<Transform> wayPoints;
    private NavMeshAgent _agent;
    [SerializeField]
    private int currentTarget;
    private bool _reverse = false;
    private bool _targetReached = false;
    private Animator _animator;
    public bool coinTossed = false;
    public Vector3 coinPosition;

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.SetDestination(wayPoints[currentTarget].position);
        _animator = GetComponent<Animator>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        //if waypoints.count > 0 && waypoints[currentTarget] != null
        //setDestination to current target

        if (wayPoints.Count > 0 && wayPoints[currentTarget] != null && coinTossed == false)
        {
            _agent.SetDestination(wayPoints[currentTarget].position);

            float distance = Vector3.Distance(transform.position, wayPoints[currentTarget].position);

            if(distance < 1.0f && _targetReached == false)
            {
                _targetReached = true;

                StartCoroutine(WaitBeforeMoving());
               
            }
        }
        else if(coinTossed == true)
        {
            float distance = Vector3.Distance(transform.position, coinPosition);

            if (distance < 4.0f)
            {
                _animator.SetBool("Walk", false);
            }
        }

    }

    IEnumerator WaitBeforeMoving()
    {

        if (_reverse == true)
        {
            currentTarget--;

            if (currentTarget <= 0)
            {
                _reverse = false;
                currentTarget = 0;
            }
           
        }
        else if(_reverse == false && currentTarget == 0 && wayPoints.Count > 1)
        {
            _animator.SetBool("Walk", false);
            yield return new WaitForSeconds(Random.Range(2.0f, 6.0f));
            currentTarget++;
            _animator.SetBool("Walk", true);
        }

        else if(_reverse == false && currentTarget != 0 && wayPoints.Count > 1)
        {
            currentTarget++;
            

            if (currentTarget >= wayPoints.Count)
            {
                currentTarget = wayPoints.Count - 1;
                _reverse = true;
                _animator.SetBool("Walk", false);
                yield return new WaitForSeconds(Random.Range(2.0f, 6.0f));
                currentTarget--;
                _animator.SetBool("Walk", true);
            }
        }
       
      

        _targetReached = false;
    }
}
