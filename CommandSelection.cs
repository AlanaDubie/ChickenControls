using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//rewrite to be a queue
public class CommandSelection : MonoBehaviour
{
    public int selectedCommand = 0;
    public static CommandSelection Instance { get; private set;}

    //needed script game CommandSelectionbjects
    public GameObject unitClickScript; //unit click script

    //use this for initialization
    void Start()
    {
        SelectCommand();
        Instance = this;
        //unitClickScript = UnitClick.instance;
    }

    //Update is called once per frame
    void Update()
    {
            //if user presses e
         if (Input.GetKeyDown(KeyCode.E))
         {
            //loops around to first index of command selection
            if (selectedCommand >= transform.childCount - 1)
                selectedCommand = 0;
            else
                selectedCommand++;
           SelectCommand();
           //CommandTypeInitiate();
         }

    }

    void SelectCommand()
    {
        int i = 0;
        foreach (Transform command in transform)
        {
            //selected command
            if (i == selectedCommand)
            {
                //makes selected command icon visible
                command.gameObject.SetActive(true);
            }
            else
            {
                command.gameObject.SetActive(false);
            }
            i++;
        }
    }

    //might need to rewrite on a seperate script
    //current issues:
    //1. disabling script for each command case - can it be written better & optimized?
    void CommandTypeInitiate()
    {
        //index 0 = carry command
        //index 1 = ladder command
        //index 2 = break command
        //index 3 = sling command

        switch (selectedCommand)
        {
            case 0:
                //unitClickScript.gameObject.SetActive(true);
                //chicks go to selected obj
                break;

            case 1:
                unitClickScript.gameObject.SetActive(false);
                //deselects any selected objs
                //UnitSelectionsScript.GetComponent<UnitSelections>().DeselectAll();
                break;

            case 2:
                 unitClickScript.gameObject.SetActive(true);
                 //chicks go to selected obj

                break;
            case 3:
                unitClickScript.gameObject.SetActive(false);
                //deselects any selected objs
                //UnitSelectionsScript.GetComponent<UnitSelections>().DeselectAll();
                break;
                
            default:
                 Debug.Log("Error - CommandSelection.cs, default switch case");
                break;
        }

    }


}
