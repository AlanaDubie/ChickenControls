
using UnityEngine;

//click functionalities and logic

public class UnitClick : MonoBehaviour
{
    private Camera myCam;
    public LayerMask clickable;

    void Start()
    {
        myCam = Camera.main;
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            RaycastHit hit;
            Ray ray = myCam.ScreenPointToRay(Input.mousePosition);
                                                                            //carry || break is selected
            if (Physics.Raycast(ray, out hit, 20, clickable) && (CommandSelection.Instance.selectedCommand == 0 || CommandSelection.Instance.selectedCommand == 2))
            {
                //if we hit a clickable object (shift click)
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    //shift clicked
                    UnitSelections.Instance.ShiftClickSelect(hit.collider.gameObject);
                }
                else //normal left clicked
                {

                  //if (command == nextCommand)

                     UnitSelections.Instance.ClickSelect(hit.collider.gameObject);

                }
            }
            //else
            //{
                //if we ddint && we're not shift clicking
                //if (!Input.GetKey(KeyCode.LeftShift))
               // {
                   // UnitSelections.Instance.DeselectAll();

               // }
           // }

        }
    }
}
