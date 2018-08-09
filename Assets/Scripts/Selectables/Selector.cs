using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Selector : MonoBehaviour {
    bool test = true;
    public static Canvas SelectionCanvas;
    public static readonly List<Button> allActionButtons;
    
    Selectable selection;

	void Start () {
		
	}
	
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                GameObject gameObject = hitInfo.collider.gameObject;
                if (test) Debug.Log("gameObject Clicked: ", gameObject);
                if (isSelectable(gameObject))
                {
                    Selectable selection = gameObject.GetComponent<Selectable>();
                    select(selection);
                }
                else if (test) Debug.Log("Selection not Selectable.");
            }
            else if (test) Debug.Log("Selection Failed.");
        }
    }

    private void select(Selectable selection)
    {
        if (test) Debug.Log("Selector.select");

        this.selection = selection;
        
        SelectMenu menu = new SelectMenu(selection);
    }


    private bool selecting()
    {
        return this.selection == null;
    }
    private bool isSelectable(GameObject o)
    {
        bool selectable = o.GetComponent<Selectable>() != null;
        if (test) Debug.Log("Selector.isSelectable..." + selectable.ToString());
        return selectable;
    }
}
