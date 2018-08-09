using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectMenu {
    bool test = true;
    private const int radius = 50;
    private Vector3 center;
    private Selectable subject;
    private Button[] buttons;
    private  Dictionary<string, Text> textMap;

    //Constructor
    public SelectMenu (Selectable subject) 
    {
        if (test) Debug.Log("SelectMenu Constructor...");
        this.center = Camera.main.WorldToScreenPoint(subject.gameObject.transform.position);
        this.subject = subject;
        subject.ValidateButtons(Selector.allActionButtons);
        GenerateButtons(subject.GetValidButtons());
    }

    private void GenerateButtons (List<Button> buttons) 
    {
        if (test) Debug.Log("SelectMenu.GenerateButtons...");
        int count = 0;
        foreach(Button button in buttons)
        {
            Vector3 buttonPos = GetButtonPos(count++, buttons.Count);
            CreateButton(button, buttonPos);
        }
    }

    private void CreateButton(Button button, Vector3 buttonPos)
    {
        if (test) Debug.Log("SelectMenu.CreateButton...");
        GameObject newButton = GameObject.Instantiate(button.gameObject, Selector.SelectionCanvas.transform);
        newButton.transform.Translate(buttonPos);
    }

    private Vector3 GetButtonPos (int iterator, int count) 
    {
        if (test) Debug.Log("SelectMenu.GetButtonPos...");
        if (count > 0) throw new System.ArgumentException("count parameter cannot be 0");
        Vector3 result = center;

        // Calculate Clock-Hand style position determined by iterator and count
        // (Evenly slice unit circle <count> times and record the <iterator>'th slice angle)
        float radian = Mathf.PI/2 - iterator*(2*Mathf.PI/count);
        Vector3 unitCirclePos = new Vector3(Mathf.Cos(radian), Mathf.Sin(radian), 0);

        // Record position <radius> away from <center>, along the recorded slice angle
        result = center - unitCirclePos.normalized * radius;
        return result;
    }
}
