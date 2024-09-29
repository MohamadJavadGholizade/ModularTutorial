using System.Collections;
using System.Collections.Generic;
using MJUtilities;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class HoldActionStep : TutorialStepBase
{
    [SerializeField] private XRGrabInteractable grabInteractable;
    [SerializeField] private float completionHoldDuration;
    [SerializeField] private int completionCount;

    private bool _holding;
    private float _currentPassedTime;
    private float _currentPassedCount;

    private void Update()
    {
        if (_holding)
        {
            _currentPassedTime += Time.deltaTime;

            if (_currentPassedTime >= completionHoldDuration)
            {
                _currentPassedCount++;
                _holding = false;
                _currentPassedTime = 0f;
                if (_currentPassedCount >= completionCount)
                {
                    CompleteStep();
                }
            }
        }
    }

    public override void StartStep()
    {
        base.StartStep();
        grabInteractable.activated.AddListener(OnHold);
        grabInteractable.deactivated.AddListener(OnRelease);
    }

    public override void CompleteStep()
    {
        base.CompleteStep();
        grabInteractable.activated.RemoveListener(OnHold);
        grabInteractable.deactivated.RemoveListener(OnRelease);
    }

    private void OnHold(ActivateEventArgs args)
    {
        _holding = true;
    }

    private void OnRelease(DeactivateEventArgs args)
    {
        _holding = false;
        _currentPassedTime = 0f;
    }
}
