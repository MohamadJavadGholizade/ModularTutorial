using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerButtonGuide : MonoBehaviour
{
    [SerializeField] private List<ControllerButtonData> buttonDataList;

    public void ActivateGuideForButton(ControllerButtonName buttonName)
    {
        foreach (var buttonData in buttonDataList)
        {
            if (buttonData.buttonName == buttonName)
            {
            }
        }
    }
}

[Serializable]
public class ControllerButtonData
{
    public ControllerButtonName buttonName;
    public GameObject buttonModel;
    public GameObject buttonAffordance;
}

public enum ControllerButtonName
{
    Grip,
    Trigger
}
