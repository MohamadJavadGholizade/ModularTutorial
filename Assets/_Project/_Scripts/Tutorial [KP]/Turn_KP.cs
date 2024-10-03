
using MJUtilities;
using UnityEngine;

public class Turn_KP : TutorialStepBase
{
    [SerializeField]
    private GameObject head; 
    private int turnCount = 0; 
    private Quaternion initialRotation; 

    public override void StartStep()
    {
        base.StartStep();
        initialRotation = head.transform.rotation; 
    }

    void Update()
    {
        CheckTurn(); 
    }

    private void CheckTurn()
    {
        float angleDifference = Quaternion.Angle(initialRotation, head.transform.rotation);
        if (angleDifference >= 45f)
        {
            turnCount++; 
            Debug.Log("User has turned " + turnCount + " times.");
            initialRotation = head.transform.rotation;
            if (turnCount >= 3)
            {
                CompleteStep();
            }
        }
    }

    public override void CompleteStep()
    {
        base.CompleteStep();
        Debug.Log("Step complete!");
    }
}