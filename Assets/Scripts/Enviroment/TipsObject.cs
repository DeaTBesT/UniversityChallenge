using System;
using Interfaces;
using UnityEngine;

namespace Environment
{
    public class TipsObject : Interactable, IInteractable
    {
        [SerializeField] private Texture _tipsSprite;
    
        public Texture GetTipsSprite => _tipsSprite;
        public static Action<TipsObject> OnInteract { get; set; }
        
        public bool TryInteract(IInteractor interactor)
        {
            if ((_tipsSprite == null) || (!IsInteractable))
            {
                return false;
            }
            
            OnInteract?.Invoke(this);
            return true;
        }

        public void FinishInteract(bool isSuccess)
        {
            
        }
    }
}