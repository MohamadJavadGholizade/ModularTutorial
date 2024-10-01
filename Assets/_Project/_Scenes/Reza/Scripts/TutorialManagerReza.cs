using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class TutorialManagerReza : MonoBehaviour
{
    public InputActionProperty grabActionLeft; // Input action for the left hand grab
    public InputActionProperty grabActionRight; // Input action for the right hand grab
    public GameObject grabSocketSection; // The grab/socket section to activate after the first task

    public GameObject[] grabSocketObjects; // List of objects that are part of the grab/socket section
    public Toggle[] tutorialCheckboxes; // Checkboxes to show progress in the UI

    [SerializeField] private int grabCount = 0; // Tracks how many times the player has grabbed
    private bool isGrabSectionActive = false; // Keeps track if the grab/socket section is active
    private bool hasCompletedGrabSection = false; // Keeps track if the grab/socket section is completed

    // Track the previous state of the grab actions to detect transitions
    private bool wasGrabbingLeft = false;
    private bool wasGrabbingRight = false;

    public void UISection()
    {
        // Check if the left grab action was just pressed down
        if (grabCount < 3)
        {
            grabCount++;
            Debug.Log("Grab Count: " + grabCount); 
            UpdateUI(grabCount-1); 
        }

        
        // When the player has grabbed 3 times, activate the grab/socket section
        if (grabCount >= 3 && !isGrabSectionActive)
        {
            ActivateGrabSocketSection();
        }
    }

    public void AddedSockets()
    {
        grabCount++;
        Debug.Log("Grab Count: " + grabCount); 
        UpdateUI(grabCount-1); 
    }
    // Update is called once per frame
    void Update()
    {
        // Check if the grab button has been pressed down (transition from unpressed to pressed)
        bool isGrabbingLeft = CheckGrabInput(grabActionLeft);
        bool isGrabbingRight = CheckGrabInput(grabActionRight);

       

        // Update the previous state of the grab buttons
        wasGrabbingLeft = isGrabbingLeft;
        wasGrabbingRight = isGrabbingRight;

        // Check if the grab/socket section is completed
        if (isGrabSectionActive && CheckGrabSocketCompletion() && !hasCompletedGrabSection)
        {
            CompleteGrabSocketSection();
        }
    }

    // Check if the grab action is pressed
    private bool CheckGrabInput(InputActionProperty grabAction)
    {
        return grabAction.action.IsPressed();
    }

    // Activate the grab/socket section after the first task is completed
    private void ActivateGrabSocketSection()
    {
        grabSocketSection.SetActive(true);
        isGrabSectionActive = true;
    }

    // Mark a task as complete in the UI using checkboxes
    private void UpdateUI(int index)
    {
        if (index >= 0 && index < tutorialCheckboxes.Length)
        {
            tutorialCheckboxes[index].isOn = true;
        }
    }

    // Check if the player has completed all 3 grab/socket interactions
    private bool CheckGrabSocketCompletion()
    {
        int completedSockets = 0;

        foreach (var socketObject in grabSocketObjects)
        {
            var socketInteractor = socketObject.GetComponent<XRSocketInteractor>();
            if (socketInteractor && socketInteractor.hasSelection) // Check if something is placed in the socket
            {
                completedSockets++;
            }
        }

        return completedSockets == grabSocketObjects.Length; // Return true if all sockets are filled
    }

    // Complete the grab/socket section and mark it in the UI
    private void CompleteGrabSocketSection()
    {
        hasCompletedGrabSection = true;
        UpdateUI(1); // Mark the grab/socket section as done
    }
}
