using UnityEngine;

namespace Player
{
    public class CameraController : MonoBehaviour
    {
        private const float Z_OFFSET = -10f;
        
        [SerializeField] private float _smooth;
        
        private Camera _camera;

        private void Start()
        {
            _camera = Camera.main;
        }

        private void FixedUpdate()
        {
            _camera.transform.position = Vector3.Lerp(_camera.transform.position, new Vector3(transform.position.x, transform.position.y, Z_OFFSET), _smooth * Time.fixedDeltaTime);
        }
    }
}