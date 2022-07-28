using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicks : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ChicksManager.Instance.chicksIdle.Add(this.gameObject);
    }

    void OnDestroy()
     {
         ChicksManager.Instance.chicksIdle.Remove(this.gameObject);
     }

}
