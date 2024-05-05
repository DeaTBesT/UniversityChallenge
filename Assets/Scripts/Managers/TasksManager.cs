using System;
using Environment;
using Tasks;
using Tasks.UI;
using UnityEngine;

namespace Managers
{
    public class TasksManager : MonoBehaviour
    {
        [SerializeField] private ButtonAnswer _buttonSelectAnswer;
        [SerializeField] private Transform _buttonsParent;
        [SerializeField] private GameObject _taskPanel;
        
        private TaskObject _taskObject;
        
        public Action OnRightAnswer { get; set; }
        public Action<bool> OnWrongAnswer { get; set; }
        public static Action OnFinishInteract { get; set; }
        
        private void OnEnable()
        {
            TaskObject.OnInteract += GenerateTask;
        }

        private void OnDisable()
        {
            TaskObject.OnInteract -= GenerateTask;
        }

        private void GenerateTask(TaskObject taskObject)
        {
            _taskObject = taskObject;
            
            foreach (Transform child in _buttonsParent)
            {
                Destroy(child.gameObject);
            }
            
            for (int i = 0; i < _taskObject.GetTaskConfig.GetAnswers.Length; i++)
            {
                ButtonAnswer button = Instantiate(_buttonSelectAnswer, _buttonsParent);
                button.transform.gameObject.SetActive(true);
                button.Initialize(this, i, _taskObject.GetTaskConfig.GetAnswers[i]);
            }
            
            _taskPanel.SetActive(true);
        }

        public void SelectAnswer(int answerId)
        {
            if (_taskObject.GetTaskConfig == null)
            {
                return;
            }

            if (answerId == _taskObject.GetTaskConfig.GetRightAnswerId)
            {
                OnRightAnswer?.Invoke();
                _taskObject.FinishInteract(true);
            }
            else
            {
                OnWrongAnswer?.Invoke(_taskObject.IsFinalTask);
                _taskObject.FinishInteract(false);
            }
            
            _taskPanel.SetActive(false);
            OnFinishInteract?.Invoke();
        }
    }
}