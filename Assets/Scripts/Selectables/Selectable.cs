using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Selectable : MonoBehaviour { // Strategy Design Pattern (Context)
    private bool test = true;
    protected const int maxActions = 10;
    protected Action[] actions = new Action[maxActions];

    // Getter and Setter for Action List
    public Action[] Actions{ get; set; }

    /*This method generates 
     */
    public virtual SelectMenu DisplayGUI() 
    {
        if (test) Debug.Log("Selectable.DisplayGUI...");
        return new SelectMenu(this);
    }

    /*
     * As player progresses and circumstances change, 
     * new actions can be performed on different Selectables.
     * This function checks the player's capabilities and adds 
     * actions as appropriate. 
     */
    public abstract void UpdateActions(GameObject player);

}
