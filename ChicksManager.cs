using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChicksManager : MonoBehaviour
{
    public List<GameObject> chicksIdle = new List<GameObject>();

    private static ChicksManager _instance;
    public static ChicksManager Instance { get {return _instance; }}

    void Awake()
    {
            //if an instance of this already exists and it isn't this one
            if (_instance != null && _instance != this )
            {
                //we destroy this instance
                Destroy(this.gameObject);
            }
            else
            {
                //make this the instance
                _instance = this;
            }
     }




    
}
