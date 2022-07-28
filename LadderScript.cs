using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderScript : MonoBehaviour
{
     void OnEnable()
         {
             EventManager.LadderAction += Ladder;
         }

         // Update is called once per frame
         void OnDisable()
         {
              EventManager.LadderAction -= Ladder;
         }

         void Ladder()
         {
              Debug.Log("Ladder");
         }
}
