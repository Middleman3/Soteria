using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Action {

    private Button buttonPrototype;



    /* This function checks all requirements 
     * of an action, such as range...
    */
    private bool validateAction()
    {
        return false;
    }


    public Button CreateButton(Vector3 buttonPos)
    {
        /*Button Position is screen space ((0,0) is bottom left corner) but 
         *button's local transform (0,0) relative to parent is in center of screen space
         */
        Canvas canvas = Selector.SelectionCanvas;
        buttonPos = buttonPos - new Vector3(Screen.width / 2, Screen.height / 2, 0);

        Button button = GameObject.Instantiate(buttonPrototype, canvas.transform);
        button.transform.Translate(buttonPos);
        return button;
    }
}
