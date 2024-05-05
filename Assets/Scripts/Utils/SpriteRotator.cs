using UnityEngine;

namespace Utils
{
    public class SpriteRotator : MonoBehaviour
    {
        [SerializeField] private float _speed;
        
        private void FixedUpdate()
        {
            transform.Rotate(0, 0, 1 * _speed * Time.fixedDeltaTime);
        }
    }
}