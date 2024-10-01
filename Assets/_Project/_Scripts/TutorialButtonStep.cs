using System;
using System.Collections;
using System.Collections.Generic;
using MJUtilities;
using UnityEngine;
using UnityEngine.InputSystem;

public class TutorialButtonStep : TutorialStepBase
{
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
        switch (actionBinding)
        {
            case ActionBinding.DirectGrab:
            {
                _pressAction.AddBinding(XRControllerPath + ControllerButtonName.Grip);
                break;
            }
            case ActionBinding.DirectActivate:
            {
                _holdAction.AddBinding(XRControllerPath + ControllerButtonName.Grip);
                _pressAction.AddBinding(XRControllerPath + ControllerButtonName.Trigger);
                break;
            }
        }
        
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
