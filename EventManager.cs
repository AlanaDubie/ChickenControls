using System.Collections;
using UnityEngine;

public class EventManager : MonoBehaviour
{
   public delegate void EventAction();

   public static event EventAction CarryAction;
   public static event EventAction LadderAction;
   public static event EventAction BreakAction;
   public static event EventAction SlingAction;

   public GameObject unitClickScript; //unit click script


   void OnTest()
   {
        //carry
        if (CommandSelection.Instance.selectedCommand == 0)
        {
            if (CarryAction != null)
            {
                 CarryAction();
            }
        }
        //ladder
        else if (CommandSelection.Instance.selectedCommand == 1)
        {
            if (LadderAction != null)
            {
                 LadderAction();
            }
        }

        //break
        else if (CommandSelection.Instance.selectedCommand == 2)
        {
            if (BreakAction != null)
            {
                  BreakAction();
            }
        }

        //sling
        else if (CommandSelection.Instance.selectedCommand == 3)
        {
            if (SlingAction != null)
            {
                 SlingAction();
            }
        }
   }
}
