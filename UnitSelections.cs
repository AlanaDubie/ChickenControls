using System.Collections.Generic;
using UnityEngine;

// includes functions for left click, shift click, and deselect options for selecting objects
public class UnitSelections : MonoBehaviour
{
    public List<GameObject> unitList = new List<GameObject>(); //list of selectable objects in game
    public List<GameObject> unitsSelected = new List<GameObject>(); //list of objects that are selected

    private static UnitSelections _instance;
    public static UnitSelections Instance { get {return _instance; }}

    public GameObject chickFollowPoint;
    public GameObject chickenBehind;
    //public GameObject commandIcons;

    [SerializeField] private Material hightlightMaterial; //material to highlight selection


    private int command; //command index (carry,sling,ladder,break) upon first selecting object
    private int nextCommand; //command index (carry,sling,ladder,break) upon after switching commands


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

    public void ClickSelect(GameObject unitToAdd)
    {
       //if object is already selected
      if (unitsSelected.Contains(unitToAdd))
       { 
           //initilazes nextCommand
            nextCommand = CommandSelection.Instance.selectedCommand;
           //if previous command = current command
           if (command == nextCommand)
           {
             Deselect(unitToAdd);
             //reverts chicksfollowpoint to the chicken
             chickFollowPoint.transform.position =  GameObject.Find("1stPersonPlayer").transform.position;
             //reverts 1stPersonPlayer as parent to chickFollowPoint (game object)
             chickFollowPoint.transform.parent = GameObject.Find("1stPersonPlayer").transform;
             //re-positions chickFollowPoint so that its behind chicken
             chickFollowPoint.transform.position = chickenBehind.transform.position;
            // chickFollowPoint.transform.Translate (Time.deltaTime, 0, -2);
             //transform.localRotation = Quaternion.Euler(0, 0, 0);
           }
       }
       //else if object is not selected
       else
       {
          DeselectAll();

          // initializes previous command
          command = CommandSelection.Instance.selectedCommand;

          unitsSelected.Add(unitToAdd);
          //SelectVisual 3d Object
          //unitToAdd.transform.GetChild(0).gameObject.SetActive(true);
          //renders highlight mat
          unitToAdd.GetComponent<Renderer>().material = hightlightMaterial;

          //changes chicksfollowpoint to the selected object coords
          chickFollowPoint.transform.position = unitToAdd.transform.position;
          //groups selected object (game object) as parent to chickFollowPoint (game object)
          chickFollowPoint.transform.parent = unitToAdd.transform;
          //(group chick sphheres?)
       }
    }

    public void ShiftClickSelect(GameObject unitToAdd)
    {
        if (!unitsSelected.Contains(unitToAdd))
        {
            unitsSelected.Add(unitToAdd);
                      //renders highlight mat

            unitToAdd.GetComponent<Renderer>().material = hightlightMaterial;
            //SelectVisual 3d Object
            //unitToAdd.transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            //unitToAdd.transform.GetChild(0).gameObject.SetActive(false);
            //restores to original material of object
            unitToAdd.GetComponent<Unit>().Restore();
            //removes unit selected
            unitsSelected.Remove(unitToAdd);
        }
    }

    //code will be needed for chicken call
    //deselects all objects
    public void DeselectAll()
    {
        foreach (var unit in unitsSelected)
        {
          //SelectVisual 3d Object
          //unit.transform.GetChild(0).gameObject.SetActive(false);
          //restores to original material of object
          unit.GetComponent<Unit>().Restore();
        }
        unitsSelected.Clear();
    }

    //deselects a selected object
    public void Deselect(GameObject unitToDeselect)
    {
        //restores to original material of object
        unitToDeselect.GetComponent<Unit>().Restore();
        unitsSelected.Remove(unitToDeselect);
        
    }//



}
