using System;
using System.Collections;
using System.Collections.Generic;
using MJUtilities;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;


namespace MJUtilities
{
    public class StepGrabble : TutorialStepBase
    {
        [SerializeField] public XRGrabInteractable xrGrabInteractable;

        private void Reset()
        {
            SetReferences();
        }
        private void OnEnable()
        {
            xrGrabInteractable.selectEntered.AddListener(OnSelectEntered);
        }

        private void OnSelectEntered(SelectEnterEventArgs arg0)
        {
            if(IsActive())
                CompleteStep();
        }

        private void SetReferences()
        {
            xrGrabInteractable = GetComponentInChildren<XRGrabInteractable>();
        }
    }
}