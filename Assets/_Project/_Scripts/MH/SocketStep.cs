using System.Collections;
using System.Collections.Generic;
using MJUtilities;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class SocketStep : TutorialStepBase
{
    [SerializeField] private XRSocketInteractor _xrSocketInteractor;
    
    

    public override void StartStep()
    {
        base.StartStep();
        _xrSocketInteractor.selectEntered.AddListener(OnSelected);

    }

    private void OnSelected(SelectEnterEventArgs arg0)
    {
        CompleteStep();
        arg0.interactableObject.colliders[0].enabled = false;
    }

    public override void CompleteStep()
    {
        base.CompleteStep();
        _xrSocketInteractor.selectEntered.RemoveListener(OnSelected);

    }
    
}