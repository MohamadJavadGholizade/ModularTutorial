using System;
using System.Collections;
using System.Collections.Generic;
using HighlightPlus;
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
                buttonData.buttonModel.GetComponent<HighlightEffect>().highlighted = true;
                buttonData.tooltip.enabled = true;
                buttonData.tooltip.GetComponentInChildren<MeshRenderer>().enabled = true;
                buttonData.tooltipCurve.enabled = true;
                return;
            }
        }
    }

    public void DeactivateAllGuides()
    {
        foreach (var buttonData in buttonDataList)
        {
            buttonData.buttonModel.GetComponent<HighlightEffect>().highlighted = false;
            buttonData.tooltip.enabled = false;
            buttonData.tooltip.GetComponentInChildren<MeshRenderer>().enabled = false;
            buttonData.tooltipCurve.enabled = false;
        }
    }
}

[Serializable]
public class ControllerButtonData
{
    public ControllerButtonName buttonName;
    public GameObject buttonModel;
    public Canvas tooltip;
    public LineRenderer tooltipCurve;
}

public enum ControllerButtonName
{
    Grip,
    Trigger
}
