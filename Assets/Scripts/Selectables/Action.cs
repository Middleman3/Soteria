using System;
using UnityEngine;
using UnityEngine.UI;

public abstract class Action : MonoBehaviour // Command Design Pattern (Strategy)
{
    private bool test = true;

    protected abstract bool Execute();

    /** Every Action has a target, specified in the 
     * concreateAction's constructor. This function verifies 
     *  that the target is of the proper type.
     */
    public abstract System.Type TargetType();
}
