using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; //imports AI library

public class ChicksFollowPoint : MonoBehaviour
{

     public GameObject FollowPoint;
     public NavMeshAgent chick;

    void Start()
    {
        chick = GetComponent<NavMeshAgent>(); 
    }

    void Update()
    {
        chick.SetDestination(FollowPoint.transform.position);
    }



}
