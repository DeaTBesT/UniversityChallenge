using System;
using Environment;
using Tasks;
using Tasks.UI;
using TMPro;
using UnityEngine;

namespace Managers
{
    public class TasksManager : MonoBehaviour
    {
        [SerializeField] private ButtonAnswer _buttonSelectAnswer;
        [SerializeField] private Transform _buttonsParent;
        [SerializeField] private GameObject _taskPanel;
        [SerializeField] private TextMeshProUGUI _textTaskTitle;

        private TaskObject _taskObject;
        private TaskConfig _taskConfig;

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
            _taskConfig = taskObject.GetTaskConfig;

            _textTaskTitle.text = _taskConfig.GetDescription;

            foreach (Transform child in _buttonsParent)
            {
                Destroy(child.gameObject);
            }
            
            for (int i = 0; i < _taskConfig.GetAnswers.Length; i++)
            {
                ButtonAnswer button = Instantiate(_buttonSelectAnswer, _buttonsParent);
                button.transform.gameObject.SetActive(true);
                button.Initialize(this, i, _taskConfig.GetAnswers[i]);
            }
            
            _taskPanel.SetActive(true);
        }

        public void SelectAnswer(int answerId)
        {
            if (_taskConfig == null)
            {
                return;
            }

            if (answerId == _taskConfig.GetRightAnswerId)
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