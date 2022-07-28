using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakScript : MonoBehaviour
{
     void OnEnable()
     {
         EventManager.BreakAction += Break;
     }

     // Update is called once per frame
     void OnDisable()
     {
          EventManager.CarryAction -= Break;
     }

     void Break()
     {
          Debug.Log("Break");
     }
}
