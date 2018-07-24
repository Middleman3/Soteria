using System;
using UnityEngine;
using UnityEngine.UI;

public abstract class Action { // Strategy Design Pattern (Strategy)
    private bool test = true;
    

    protected Button buttonPrototype;
    protected abstract string buttonName { get; set; } // Abstract Property
    public abstract string title { get; set; } // Abstract Property

    //Constructor
    protected Action ()
    {
        if (test) Debug.Log("Action Constructor...");
        this.buttonPrototype = GameObject.Find(buttonName).GetComponent<Button>();
        if (this.buttonPrototype == null) throw new System.ArgumentException("Action received improper buttonName: " + buttonName);
        this.title = title;
    }

    // Template Method Design Pattern
    public bool Act() 
    {
        if (test) Debug.Log("Action.Act...");
        ValidateAction();
        Execute();
        return false;
    }
    /* This function checks all requirements 
     * of an action, such as range...
    */
    protected abstract bool ValidateAction();
    protected abstract bool Execute();

    public Button CreateButton(Vector3 buttonPos)
    {
        if (test) Debug.Log("Action.CreateButton...");
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
