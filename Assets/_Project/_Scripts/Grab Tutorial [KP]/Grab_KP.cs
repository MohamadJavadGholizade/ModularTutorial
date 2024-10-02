
using MJUtilities;
using UnityEngine;

public class Grab_KP : TutorialStepBase
{
    private int countObject = 0;
    [SerializeField] private GameObject objects;

    public override void StartStep()
    {
        base.StartStep();
        objects.SetActive(true);
    }

    public override void CompleteStep()
    {
        base.CompleteStep();
        
    }
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Destroyable"))
        {
            countObject++; 
            Debug.Log(countObject);
            Destroy(collision.gameObject);
        }
        if (countObject == 3)
            CompleteStep();
    }
}
