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
                if (buttonData.tooltip.GetComponentInChildren<MeshRenderer>() != null) 
                    buttonData.tooltip.GetComponentInChildren<MeshRenderer>().enabled = true;
                if (buttonData.tooltipCurve != null) 
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
            if (buttonData.tooltip.GetComponentInChildren<MeshRenderer>() != null) 
                buttonData.tooltip.GetComponentInChildren<MeshRenderer>().enabled = false;
            if (buttonData.tooltipCurve != null) 
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
    Trigger,
    Primary2DAxis
}
