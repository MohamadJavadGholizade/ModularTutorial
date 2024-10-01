// using System;
// using UnityEngine;
//
// public class TaskManager : MonoBehaviour
// {
//     public event Action OnTaskCompleted; // Event to signal task completion
//
//     [SerializeField] private MonoBehaviour[] taskObjects;  // Drag tasks into this from the editor
//     private ITask[] tasks;
//     private int currentTaskIndex = 0;
//
//     private void Start()
//     {
//         // Convert MonoBehaviours to ITask if they implement the interface
//         tasks = Array.ConvertAll(taskObjects, task => task as ITask);
//
//         if (tasks.Length > 0)
//         {
//             StartNextTask();  // Start the first task automatically
//         }
//         else
//         {
//             Debug.LogWarning("No tasks assigned to TaskManager!");
//         }
//     }
//
//     // Start the current task
//     public void StartNextTask()
//     {
//         if (currentTaskIndex < tasks.Length && tasks[currentTaskIndex] != null)
//         {
//             tasks[currentTaskIndex].StartTask();
//         }
//     }
//
//     // Called when the task is done
//     public void EndTask()
//     {
//         OnTaskCompleted?.Invoke();  
//         currentTaskIndex++;  
//         if (currentTaskIndex < tasks.Length)
//         {
//             StartNextTask();  // Start the next task
//         }
//         else
//         {
//             Debug.Log("All tasks completed.");
//         }
//     }
// }