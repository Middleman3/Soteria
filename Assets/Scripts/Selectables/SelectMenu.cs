using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectMenu {

    private const int radius = 50;
    private Vector3 center;
    private Selectable subject;
    private Button[] buttons;
    private  Dictionary<string, Text> textMap;


    public SelectMenu (Selectable subject)
    {
        this.center = Camera.main.WorldToScreenPoint(subject.gameObject.transform.position);
        this.subject = subject;
        this.buttons = generateButtons();
    }

    private Button[] generateButtons ()
    {
        Action[] actionList = subject.Actions;
        int length = actionList.Length;
        Button[] buttons = new Button[length];
        for (int i = 0; i < length; i++)
        {
            Vector3 buttonPos = getButtonPos(i, length);
            if (actionList[i] != null) buttons[i] = actionList[i].CreateButton(buttonPos);
        }
        return buttons;
    }

    private Vector3 getButtonPos (int iterator, int count)
    {
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
