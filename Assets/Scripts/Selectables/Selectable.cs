using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Selectable : MonoBehaviour {

    private const int maxActions = 10;
    private Action[] actions = new Action[maxActions];

    // Getter and Setter for Action List
    public Action[] Actions{ get; set; }

    /*This method generates 
     */
    public virtual SelectMenu DisplayGUI()
    {
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
