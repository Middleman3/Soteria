using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuiController {
    private static GuiController instance = null;

    public GuiController Instance()
    {
        if (instance == null)
        {
            instance = new GuiController();
        }
        return instance;
    }
    private GuiController()
    {
        
    }
}
