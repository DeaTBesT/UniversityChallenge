using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        private const int MENU_LEVEL_ID = 0;
        
        [SerializeField] private GameObject _finishGamePanel;
        [SerializeField] private GameObject _winPanel;
        [SerializeField] private GameObject _losePanel;
        [SerializeField] private GameObject _loseExamPanel;
        [SerializeField] private Button _buttonExit;

        private void Start()
        {
            Time.timeScale = 1;
        }

        private void OnEnable()
        {
            _buttonExit.onClick.AddListener(ExitGame);
        }
        
        private void OnDisable()
        {
            _buttonExit.onClick.RemoveListener(ExitGame);
        }

        public void FinishGame(bool isWin, bool isFinalTask)
        {
            Time.timeScale = 0;
            _finishGamePanel.SetActive(true);
            
            _winPanel.SetActive(isWin);
            _losePanel.SetActive((!isFinalTask) && (!isWin));
            _loseExamPanel.SetActive((isFinalTask) && (!isWin));
        }

        private void ExitGame()
        {
            SceneManager.LoadScene(MENU_LEVEL_ID);
        }
    }
}