using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingScript : MonoBehaviour
{
     void OnEnable()
         {
             EventManager.SlingAction += Sling;
         }

         // Update is called once per frame
         void OnDisable()
         {
              EventManager.SlingAction -= Sling;
         }

         void Sling()
         {
              Debug.Log("Sling");
         }
}
