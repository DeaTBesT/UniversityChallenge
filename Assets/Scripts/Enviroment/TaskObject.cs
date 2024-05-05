using System;
using Interfaces;
using Tasks;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

namespace Environment
{
    public class TaskObject : Interactable, IInteractable
    {
        [SerializeField] private TaskConfig[] _taskConfigs;
        [SerializeField] private bool _isFinalTask = false;
        
        [Header("Events")]
        [SerializeField] private UnityEvent OnSuccessedInteract;
        [SerializeField] private UnityEvent OnFailedInteract;
        
        public TaskConfig GetTaskConfig => _taskConfigs[Random.Range(0, _taskConfigs.Length)];
        public bool IsFinalTask => _isFinalTask;
        public static Action<TaskObject> OnInteract { get; set; }
        
        public bool TryInteract(IInteractor interactor)
        {
            if ((_taskConfigs.Length <= 0) || (!IsInteractable))
            {
                return false;
            }
            
            OnInteract?.Invoke(this);
            return true;
        }

        public void FinishInteract(bool isSuccess)
        {
            if (isSuccess)
            {
                OnSuccessedInteract?.Invoke();
                IsInteractable = false;
            }
            else
            {
                OnFailedInteract?.Invoke();
            }
        }
    }
}