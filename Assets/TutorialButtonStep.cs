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

    private bool _holdActionPressed = true;

    private void OnEnable()
    {
        if (holdAction != null)
        {
            holdAction.started += OnHoldActionStart;
            holdAction.canceled += OnHoldActionCancel;
        }

        pressAction.started += OnPressActionStart;
        pressAction.canceled += OnPressActionCancel;
    }


    private void OnDisable()
    {
        if (holdAction != null)
        {
            holdAction.started -= OnHoldActionStart;
            holdAction.canceled -= OnHoldActionCancel;
        }

        pressAction.started -= OnPressActionStart;
        pressAction.canceled -= OnPressActionCancel;
    }

    private void OnPressActionStart(InputAction.CallbackContext context)
    {
        _currentPressCount++;
        if (_currentPressCount >= completionPressCount)
        {
            CompleteStep();
        }
    }

    private void OnPressActionCancel(InputAction.CallbackContext context)
    {
        
    }
    
    private void OnHoldActionStart(InputAction.CallbackContext context)
    {
        _holdActionPressed = true;
    }

    private void OnHoldActionCancel(InputAction.CallbackContext context)
    {
        _holdActionPressed = false;
    }
}
