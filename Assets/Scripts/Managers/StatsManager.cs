using TMPro;
using UnityEngine;

namespace Managers
{
    public class StatsManager : MonoBehaviour
    {
        private const int WIN_SCORE = 6;
        private const int LOSE_SCORE = 0;
        
        [SerializeField] private int _startHealth;
        
        [Header("UI")]
        [SerializeField] private TextMeshProUGUI _textScores;
        [SerializeField] private GameObject[] _healthView;
        
        [Header("Modules")]
        [SerializeField] private TasksManager _tasksManager;
        [SerializeField] private GameManager _gameManager;

        private int _score = 0;
        private int _health = 0;

        private void Start()
        {
            _health = _startHealth;
        }

        private void OnEnable()
        {
            _tasksManager.OnRightAnswer += OnRightAnswer;
            _tasksManager.OnWrongAnswer += OnWrongAnswer;
        }

        private void OnDisable()
        {
            _tasksManager.OnRightAnswer -= OnRightAnswer;
            _tasksManager.OnWrongAnswer -= OnWrongAnswer;
        }

        private void OnRightAnswer()
        {
            _score++;
            _textScores.text = _score.ToString();
            
            if (_score >= WIN_SCORE)
            {
                _gameManager.FinishGame(true, true);
            }
        }
        
        private void OnWrongAnswer(bool isFinalTask)
        {
            _health--;
            
            _healthView[Mathf.Clamp(_health, 0, _healthView.Length - 1)].SetActive(false);

            if ((_health <= LOSE_SCORE) || (isFinalTask))
            {
                _gameManager.FinishGame(false, isFinalTask);
            }
        }
    }
}