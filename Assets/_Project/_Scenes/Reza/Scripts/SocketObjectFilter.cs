using UnityEngine;


using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class SocketObjectFilter : XRSocketInteractor
{
    public ObjectType socketType; // Assign this in the inspector for each socket

    // Override CanSelect to check object type before selecting it
    public override bool CanSelect(IXRSelectInteractable interactable)
    {
        // Check the object type before allowing selection
        GrabbableObjectType objectTypeComponent = interactable.transform.GetComponent<GrabbableObjectType>();

        if (objectTypeComponent != null)
        {
            ObjectType objectType = objectTypeComponent.objectType;

            // Allow selection only if the object's type matches the socket type
            return objectType == socketType && base.CanSelect(interactable);
        }

        return false;
    }

    // Override CanHover to restrict hover based on object type
    public override bool CanHover(IXRHoverInteractable interactable)
    {
        // Check the object type before allowing hover
        GrabbableObjectType objectTypeComponent = interactable.transform.GetComponent<GrabbableObjectType>();

        if (objectTypeComponent != null)
        {
            ObjectType objectType = objectTypeComponent.objectType;

            // Allow hover only if the object's type matches the socket type
            return objectType == socketType && base.CanHover(interactable);
        }

        return false;
    }
}

public enum ObjectType
{
    Tool,      // Add types that are relevant for sockets
    Weapon,
    Key
}
