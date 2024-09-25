using System;
using System.Collections;
using System.Collections.Generic;
using MJUtilities;
using UnityEngine;
using UnityEngine.InputSystem;

public class TutorialButtonStep : TutorialStepBase
{
    public InputAction holdAction;
    public InputAction pressAction;

    [SerializeField] private int completionPressCount;
    private int _currentPressCount;

    private bool _pressActionPressed;
    private bool _holdActionPressed = true;

    private void Awake()
    {
        if (holdAction != null)
        {
            holdAction.started += OnHoldActionStart;
            holdAction.canceled += OnHoldActionCancel;
        }

        pressAction.started += OnPressActionStart;
        pressAction.canceled += OnPressActionCancel;
    }


    private void OnDestroy()
    {
        if (holdAction != null)
        {
            holdAction.started -= OnHoldActionStart;
            holdAction.canceled -= OnHoldActionCancel;
        }

        pressAction.started -= OnPressActionStart;
        pressAction.canceled -= OnPressActionCancel;
    }

    public override void StartStep()
    {
        base.StartStep();
        pressAction.Enable();
        holdAction.Enable();
    }

    public override void CompleteStep()
    {
        base.CompleteStep();
        pressAction.Disable();
        holdAction.Disable();
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
