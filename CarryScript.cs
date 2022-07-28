using System.Collections;
using UnityEngine;

public class CarryScript : MonoBehaviour
{
    void OnEnable()
    {
        EventManager.CarryAction += Carry;
    }

    void OnDisable()
    {
         EventManager.CarryAction -= Carry;
    }

    void Carry()
    {
         Debug.Log("Carry");
    }
}
