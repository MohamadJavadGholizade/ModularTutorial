using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MJUtilities
{
    public class TutorialManager : MonoBehaviour
    {
        [SerializeField] private int currentSectionIndex;
        [SerializeField] private List<TutorialSection> tutorialSectionsList = new List<TutorialSection>();
        
        private void OnEnable()
        {
            ActionContainer.OnSectionComplete += CompleteCurrentSection;
        }

        private void OnDisable()
        {
            ActionContainer.OnSectionComplete -= CompleteCurrentSection;
        }

        private void Awake()
        {
            currentSectionIndex = 0;
        }

        private void Start()
        {
            StartFirstSection();
        }

        private void StartFirstSection()
        {
            if (tutorialSectionsList.Count > 0)
            {
                Debug.Log("Start First TaskBase Index => " + currentSectionIndex, tutorialSectionsList[currentSectionIndex].gameObject);
                tutorialSectionsList[currentSectionIndex].StartFirstStep();
            }
        }


        private void CompleteCurrentSection()
        {
            if (tutorialSectionsList.Count > 0)
            {
                //Do Something between tasks
                StartNextTask();
            }
        }


        public void StartTaskByIndex(int taskIndex)
        {
            currentSectionIndex = taskIndex;
            if (currentSectionIndex < tutorialSectionsList.Count)
            {
                Debug.Log("Start tutorialSection index => " + currentSectionIndex);
                tutorialSectionsList[currentSectionIndex].StartFirstStep();
            }
        }

        private void StartNextTask()
        {
            currentSectionIndex++;
            if (currentSectionIndex < tutorialSectionsList.Count)
            {
                Debug.Log("Start section index => " + currentSectionIndex);
                tutorialSectionsList[currentSectionIndex].StartFirstStep();
            }
            else
            {
                AllSectionsAreFinished();
            }
        }

        private void AllSectionsAreFinished()
        {
            Debug.Log("All Tasks Are Done");
        }
    }

}