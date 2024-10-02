using System;
using System.Collections;
using System.Collections.Generic;
using MJUtilities;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class WalkStepTutorial : TutorialStepBase
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("MainCamera"))
        {
            CompleteStep();
        }
        
            
    }

    

   
    
}