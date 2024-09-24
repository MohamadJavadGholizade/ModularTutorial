using System;
using UnityEngine;

namespace MJUtilities
{
    public abstract class TutorialStepBase : MonoBehaviour
    {
        [Header("Status")] 
        [SerializeField] private bool isActive;
        [SerializeField] private bool isDone;


        public virtual void StartStep()
        {
            Debug.Log("Step Started!");
            SetActiveStatus(true);
        }

        public virtual void CompleteStep()
        {
            Debug.Log("Step Completed!");
            SetDoneStatus(true);
            SetActiveStatus(false);
            ActionContainer.OnStepComplete?.Invoke();
        }

        public void SetActiveStatus(bool active) => isActive = active;
        public void SetDoneStatus(bool active) => isDone = active;
        public bool IsActive() => isActive;
        public bool IsDone() => isDone;
    }
}