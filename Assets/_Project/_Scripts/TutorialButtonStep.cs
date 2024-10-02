using System;
using System.Collections;
using System.Collections.Generic;
using MJUtilities;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.InputSystem;

public class TutorialButtonStep : TutorialStepBase
{
    [SerializeField] private ControllerButtonGuide leftControllerButtonGuide;
    [SerializeField] private ControllerButtonGuide rightControllerButtonGuide;
    
    [SerializeField] private ActionBinding actionBinding;   
    private InputAction _holdAction = new InputAction();
    private InputAction _pressAction = new InputAction();

    [SerializeField] private int completionPressCount;
    private int _currentPressCount;

    private bool _pressActionPressed;
    private bool _holdActionPressed = true;

    private const string XRControllerPath = "<XRController>/";
    
    private void Awake()
    {
        if (_holdAction != null)
        {
            _holdAction.started += OnHoldActionStart;
            _holdAction.canceled += OnHoldActionCancel;
        }

        _pressAction.started += OnPressActionStart;
        _pressAction.canceled += OnPressActionCancel;
    }

    public override void StartStep()
    {
        base.StartStep();
        
        switch (actionBinding)
        {
            case ActionBinding.DirectGrab:
            {
                _pressAction.AddBinding(XRControllerPath + ControllerButtonName.Grip);
                
                leftControllerButtonGuide?.ActivateGuideForButton(ControllerButtonName.Grip);
                rightControllerButtonGuide?.ActivateGuideForButton(ControllerButtonName.Grip);
                
                break;
            }
            case ActionBinding.DirectActivate:
            {
                _holdAction.AddBinding(XRControllerPath + ControllerButtonName.Grip);
                _pressAction.AddBinding(XRControllerPath + ControllerButtonName.Trigger);
                
                leftControllerButtonGuide?.ActivateGuideForButton(ControllerButtonName.Grip);
                leftControllerButtonGuide?.ActivateGuideForButton(ControllerButtonName.Trigger);
                rightControllerButtonGuide?.ActivateGuideForButton(ControllerButtonName.Grip);
                rightControllerButtonGuide?.ActivateGuideForButton(ControllerButtonName.Trigger);
                
                break;
            }
        }
        
        _pressAction.Enable();
        _holdAction.Enable();
    }

    public override void CompleteStep()
    {
        base.CompleteStep();
        
        if (_holdAction != null)
        {
            _holdAction.started -= OnHoldActionStart;
            _holdAction.canceled -= OnHoldActionCancel;
        }

        _pressAction.started -= OnPressActionStart;
        _pressAction.canceled -= OnPressActionCancel;
        
        leftControllerButtonGuide?.DeactivateAllGuides();
        rightControllerButtonGuide?.DeactivateAllGuides();
    }

    private void OnPressActionStart(InputAction.CallbackContext context)
    {
        _pressActionPressed = true;

        if (_holdActionPressed)
        {
            _currentPressCount++;
            if (_currentPressCount >= completionPressCount)
            {
                CompleteStep();
            }
        }
    }

    private void OnPressActionCancel(InputAction.CallbackContext context)
    {
        _pressActionPressed = false;
    }
    
    private void OnHoldActionStart(InputAction.CallbackContext context)
    {
        if (!_pressActionPressed)
            _holdActionPressed = true;
    }

    private void OnHoldActionCancel(InputAction.CallbackContext context)
    {
        _holdActionPressed = false;
    }
}


public enum ActionBinding
{
    DirectGrab,
    DirectActivate
}
