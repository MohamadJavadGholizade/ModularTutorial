using System;
using System.Collections.Generic;
using UnityEngine;

namespace MJUtilities
{
    public class TutorialSection : MonoBehaviour
    {
        [Header("Status")] 
        [SerializeField] private bool isActive;
        [SerializeField] private bool isDone;
        
        [SerializeField] private int currentStepIndex;
        [SerializeField] private List<TutorialStepBase> tutorialStepsList = new List<TutorialStepBase>();

        private void OnDisable()
        {
            ActionContainer.OnStepComplete -= CompleteCurrentStep;
        }
      
        public void StartFirstStep()
        {
            SetActiveStatus(true);
            currentStepIndex = 0;
            ActionContainer.OnStepComplete += CompleteCurrentStep;

            if (tutorialStepsList.Count > 0)
            {
                Debug.Log("index = " + currentStepIndex);
                tutorialStepsList[currentStepIndex].StartStep();
            }
        }

        private void CompleteCurrentStep()
        {
            if (!CheckIsActive()) return;

            if (tutorialStepsList.Count > 0)
            {
                StartNextStep();
            }
        }

        private void StartNextStep()
        {
            currentStepIndex++;
            if (currentStepIndex < tutorialStepsList.Count)
            {
                Debug.Log("Start step index = " + currentStepIndex + " ----- tutorialStepsList.Count = " + tutorialStepsList.Count);
                tutorialStepsList[currentStepIndex].StartStep();
            }
            else
            {
                CompleteSection();
            }
        }

        public void CompleteSection()
        {
            SetDoneStatus(true);
            SetActiveStatus(false);


            Debug.Log("All Steps Are Done From => " + this + " Class");
            ActionContainer.OnSectionComplete?.Invoke();
            ActionContainer.OnStepComplete -= CompleteCurrentStep;
        }
        
        public void SetActiveStatus(bool active) => isActive = active;
        public void SetDoneStatus(bool active) => isDone = active;
        public bool CheckIsActive() => isActive;
        public bool CheckIsDone() => isDone;
        public List<TutorialStepBase> GetSubTaskList() => tutorialStepsList;
    }
}