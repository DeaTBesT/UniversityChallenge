using System;
using Interfaces;
using Managers;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerController : MonoBehaviour, IInput
    {
        [Header("Stats")]
        [SerializeField] private float _speed;
        
        [Header("Modules")]
        [SerializeField] private InputModule _inputModule;

        private Rigidbody2D _rigidbody;

        public bool IsMove { get; set; } = true;
        
        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void OnEnable()
        {
            _inputModule.OnMove += OnMove;
            TasksManager.OnFinishInteract += OnFinishInteract;
            TipsManager.OnFinishInteract += OnFinishInteract;
        }

        private void OnDisable()
        {
            _inputModule.OnMove -= OnMove;
            TasksManager.OnFinishInteract -= OnFinishInteract;
            TipsManager.OnFinishInteract -= OnFinishInteract;
        }

        public void OnMove(Vector2 inputAxis)
        {
            if (!IsMove)
            {
                return;
            }
            
            Vector2 move = Vector2.right * inputAxis.x + Vector2.up * inputAxis.y;
            _rigidbody.MovePosition(_rigidbody.position + move * _speed * Time.fixedDeltaTime);
        }

        private void OnFinishInteract()
        {
            IsMove = true;
        }
    }
}