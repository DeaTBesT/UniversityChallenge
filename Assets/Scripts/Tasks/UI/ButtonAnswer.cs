using Managers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Tasks.UI
{
    public class ButtonAnswer : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _textButton;
        [SerializeField] private Button _button;
        
        private int _answerId;
        private TasksManager _tasksManager;
        
        public void Initialize(TasksManager tasksManager, int answerId, string text)
        {
            _answerId = answerId;
            _textButton.text = text;
            _tasksManager = tasksManager;
            
            _button.onClick.AddListener(SelectAnswer);
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveListener(SelectAnswer);
        }

        private void SelectAnswer()
        {
            _tasksManager.SelectAnswer(_answerId);
        }
    }
}