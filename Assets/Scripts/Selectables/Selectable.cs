using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Selectable : MonoBehaviour { // Strategy Design Pattern (Context)
    protected bool test = true;
    //protected const int maxActions = 10;

    private List<Element> elements;

    private List<Button> validButtons;

    public List<Button> GetValidButtons()
    {
        return validButtons;
    }

    public void FindElements()
    {
        Component[] components = this.gameObject.GetComponents<Element>();
        for (int i = 0; i < components.Length; i++)
        {
            Element element = (Element)components[i];
            elements.Add(element);
        }
    }
        
    void Awake()
    {
        elements = new List<Element>();
    }

    void Start()
    {
        FindElements();
    }

    private bool HasValidTarget(System.Type type)
    {
        if (test) Debug.Log("Selectable.HasValidTarget...");
        foreach (Element element in elements)
        {
            if (element.GetType() == type)
            {
                return true;
            }
        }
        Debug.Log("Selectable.Collect Failed.");
        return false;
    }

    /**
     * As player progresses and circumstances change, 
     * new actions can be performed on different Selectables.
     * This function checks the player's capabilities and adds 
     * actions as appropriate. 
     */
    public void ValidateButtons(List<Button> allButtons)
    {
        if (test) Debug.Log("Selectable.ValidateButtons...");
        validButtons = new List<Button>();

        foreach (Button button in allButtons)
        {
            Action action = button.gameObject.GetComponent<Action>();
            if (action == null)
            {
                Debug.Log("Error: allActionButtons has a button with no action!");
                return;
            }
            System.Type targetType = action.TargetType();
            if (HasValidTarget(targetType))
            {
                validButtons.Add(button);
            }
        }
    }
}
