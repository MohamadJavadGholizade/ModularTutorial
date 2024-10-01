using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerAffordance : MonoBehaviour
{
    public List<ControllerAffordanceUI> controllerAffordanceUIList = new List<ControllerAffordanceUI>();

    public void ActivateControllerUI(ActionBinding targetActionBinding)
    {
        foreach (var controller in controllerAffordanceUIList)
        {
            Debug.Log("Hello Im alive");
            if (controller.CompareUI(targetActionBinding))
                controller.ActivateUIGameObjects(true);
            else
                controller.ActivateUIGameObjects(false);
        }
    }
}

[Serializable]
public class ControllerAffordanceUI
{
    public ActionBinding actionBinding;

    public List<GameObject> uiGameObject = new List<GameObject>();

    public void ActivateUIGameObjects(bool active)
    {
        
        foreach (var obj in uiGameObject)
        {
           obj.SetActive(active); 
        }
    }
    public bool CompareUI(ActionBinding targetActionBinding)
    {
        if (actionBinding == targetActionBinding)
            return true;

        return false;
    }
}