using UnityEngine;

//script is assigned to each selectable object

public class Unit : MonoBehaviour
{
    private Material originalMat;

    public int chicksNeeded; //number of chicks needed to use carry comamand

    void Start()
    {
        //grabs original materal (before selection) of object and stores into variable
        originalMat = GetComponent<Renderer>().material;
        UnitSelections.Instance.unitList.Add(this.gameObject); //adds every object w/ this script to unitList (list). might need to optimize and edit so it only add objects at a certian radius
    }

    void OnDestroy()
    {
        UnitSelections.Instance.unitList.Remove(this.gameObject);
    }

    public void Restore()
    {
        GetComponent<Renderer>().material = originalMat;
    }
}
