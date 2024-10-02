using System.Collections;
using System.Collections.Generic;
using MJUtilities;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class GrabTuto : TutorialStepBase
{
    private int countObjects=0;
    [SerializeField] private GameObject m_GameObject;
    
    public override void StartStep()
    {
        base.StartStep();
        m_GameObject.SetActive(true);
        
    }

    public override void CompleteStep()
    {
        
        base.CompleteStep();
    }


    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Destroyable"))
        {
            countObjects ++;
            Destroy(collision.gameObject);
        }
        if(countObjects==3)
            CompleteStep();
    }
}
