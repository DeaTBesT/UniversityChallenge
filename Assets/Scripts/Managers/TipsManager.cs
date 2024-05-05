using System;
using Environment;
using Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace Managers
{
    public class TipsManager : MonoBehaviour
    {
        [SerializeField] private RawImage _tipsImage;
        [SerializeField] private Button _buttonCloseTips;
        [SerializeField] private GameObject _tipsPanel;

        private IInteractable _interactable;
        
        public static Action OnFinishInteract { get; set; }
        
        private void OnEnable()
        {
            TipsObject.OnInteract += ShowTips;
            _buttonCloseTips.onClick.AddListener(CloseTips);
        }

        private void OnDisable()
        {
            TipsObject.OnInteract -= ShowTips;
            _buttonCloseTips.onClick.RemoveListener(CloseTips);
        }

        private void ShowTips(TipsObject tipsObject)
        {
            _interactable = tipsObject;
            
            _tipsPanel.SetActive(true);
            _tipsImage.texture = tipsObject.GetTipsSprite;
            _tipsImage.SetNativeSize();
        }

        private void CloseTips()
        {
            _tipsPanel.gameObject.SetActive(false);
            _interactable.FinishInteract(true);
            OnFinishInteract?.Invoke();
        }
    }
}