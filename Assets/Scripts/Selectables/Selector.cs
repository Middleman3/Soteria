using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Selector : MonoBehaviour {
    bool test = true;
    public static Canvas SelectionCanvas;
    GameObject selection;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                selection = hitInfo.collider.gameObject;
                if (test) Debug.Log("gameObject Clicked: ", selection);
            }
            else if (test) Debug.Log("Selection Failed.");
        }
    }

    private bool isSelectable(GameObject o)
    {
        if (test) Debug.Log("Selector.isSelectable...");
        return o.GetComponent<Selectable>() != null;
    }
}
