using System;
using UnityEngine;

namespace Managers
{
    public class InputModule : MonoBehaviour
    {
        private const string HORIZONTAL_INPUT = "Horizontal";
        private const string VERTICAL_INPUT = "Vertical";
        
        public Action<Vector2> OnMove { get; set; }
        public Action OnInteract { get; set; }
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                OnInteract?.Invoke();
            }
        }

        private void FixedUpdate()
        {
            Vector2 inputAxis = new Vector2(Input.GetAxisRaw(HORIZONTAL_INPUT), Input.GetAxisRaw(VERTICAL_INPUT));
            OnMove?.Invoke(inputAxis);
        }
    }
}