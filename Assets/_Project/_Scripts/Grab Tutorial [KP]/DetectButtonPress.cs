using MJUtilities;
using Unity.Tutorials.Core.Editor;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class DetectButtonPress : TutorialStepBase
{
public InputActionReference grabAction;  // Reference to the grab input action
    public Material newMaterial;
    public Material originalMaterial;
    public Renderer objectRenderer;

    override 
    public void StartStep()
    {

        grabAction.action.Enable();
    }

    private void Update()
    {
        if (grabAction.action.triggered)
        {
            Debug.Log("1");
        }
    }

    private void ChangeMaterial()
    {
        
        if (objectRenderer.material == originalMaterial)
        {
            objectRenderer.material = newMaterial;
        }
        else
        {
            objectRenderer.material = originalMaterial;
        }
    }
}
