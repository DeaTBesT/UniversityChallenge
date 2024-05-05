using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Managers
{
    public class MenuManager : MonoBehaviour
    {
        private const int GAME_LEVEL_ID = 1;
        
        [SerializeField] private Button _buttonStart;
        [SerializeField] private Button _buttonExit;

        private void Start()
        {
            Time.timeScale = 1;
        }

        private void OnEnable()
        {
            _buttonStart.onClick.AddListener(StartGame);
            _buttonExit.onClick.AddListener(ExitGame);
        }

        private void OnDisable()
        {
            _buttonStart.onClick.RemoveListener(StartGame);
            _buttonExit.onClick.RemoveListener(ExitGame);
        }

        private void StartGame()
        {
            SceneManager.LoadScene(GAME_LEVEL_ID);
        }

        private void ExitGame()
        {
            Application.Quit();
        }
    }
}