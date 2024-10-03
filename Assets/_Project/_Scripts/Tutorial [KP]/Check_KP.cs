using MJUtilities;
using UnityEngine;
using UnityEngine.UI;

public class CollisionFillHandler : TutorialStepBase
{
    [SerializeField] private Image fillImage;
    private float fillAmount = 0f; 
    [SerializeField] private float fillRate = 0.2f; 
    private bool isColliding = false;
    private bool canColide =false;

    public override void StartStep()
    {
        base.StartStep();
        canColide = true;
    }

    public override void CompleteStep()
    {
        base.CompleteStep();
        canColide = false;
    }

    void Update()
    {
      
        if (canColide && isColliding)
        {
            fillAmount += fillRate * Time.deltaTime;
            fillAmount = Mathf.Clamp(fillAmount, 0f, 1f);
        }
        else
        {
            fillAmount -= fillRate * Time.deltaTime;
            fillAmount = Mathf.Clamp(fillAmount, 0f, 1f); 
        }
        
        
        fillImage.fillAmount = fillAmount;
        if (fillAmount == 1f)
        {
            CompleteStep();
            canColide = false;
            fillImage.enabled = false;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Watcher")) 
        {
            isColliding = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Watcher"))
        {
            isColliding = false; 
        }
    }
}