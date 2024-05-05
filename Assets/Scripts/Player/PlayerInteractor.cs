using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using Managers;
using UnityEngine;

namespace Player
{
    public class PlayerInteractor : MonoBehaviour, IInteractor
    {
        [Header("UI")] 
        [SerializeField] private Transform _textInteract;
        
        [Header("Modules")]
        [SerializeField] private InputModule _inputModule;
        [SerializeField] private PlayerController _playerController;
        
        private List<IInteractable> _interactableObjects = new List<IInteractable>();

        private Coroutine _distanceChecker;
        
        private void OnEnable()
        {
            _inputModule.OnInteract += OnInteract;
        }

        private void OnDisable()
        {
            _inputModule.OnInteract -= OnInteract;
        }

        public void OnInteract()
        {
            if (_interactableObjects.Count <= 0)
            {
                return;
            }

            if (_interactableObjects[0].TryInteract(this))
            {
                InteractSuccessfully();
            }
            else
            {
                InteractException();
            }
        }

        public void InteractSuccessfully()
        {
            _playerController.IsMove = false;
        }

        public void InteractException()
        {
            
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out IInteractable interactable))
            {
                _interactableObjects.Add(interactable);

                if (_distanceChecker == null)
                {
                    _distanceChecker = StartCoroutine(CheckDistance());
                    _textInteract.gameObject.SetActive(true);
                }
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.TryGetComponent(out IInteractable interactable))
            {
                _interactableObjects.Remove(interactable);
                
                if ((_distanceChecker != null) && (_interactableObjects.Count <= 0))
                {
                    StopCoroutine(CheckDistance());
                    _distanceChecker = null;
                    _textInteract.gameObject.SetActive(false);
                }
            }
        }

        private IEnumerator CheckDistance()
        {
            while (_interactableObjects.Count > 0)
            {
                _interactableObjects.Sort((i1, i2) =>
                {
                    float distance1 = Vector2.Distance((i1 as MonoBehaviour).transform.position, transform.position);
                    float distance2 = Vector2.Distance((i2 as MonoBehaviour).transform.position, transform.position);

                    return distance1 < distance2 ? -1 : 1;
                });

                _textInteract.position = (_interactableObjects[0] as MonoBehaviour).transform.position;
                
                yield return null;
            }
        }
    }
}