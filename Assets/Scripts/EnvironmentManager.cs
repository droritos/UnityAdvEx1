using System.Collections.Generic;
using UnityEngine;

public class EnvironmentManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> myChilds = new List<GameObject>();

    void Start()
    {
        GetAllChilds();
        SetChildsComponents();
    }

    private void GetAllChilds()
    {
        // Get children of this transform
        foreach (Transform child in transform)
        {
            myChilds.Add(child.gameObject);
        }
    }

    private void SetChildsComponents()
    {
        foreach (GameObject obj in myChilds)
        {
            // Make sure ChangeCoinPosition doesnt exits already 
            if (obj.GetComponent<ChangeCoinPosition>() == null)
            {
                obj.AddComponent<ChangeCoinPosition>();
            }
        }
    }
}
