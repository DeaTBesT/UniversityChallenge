using UnityEngine;

namespace Environment
{
    public class Interactable : MonoBehaviour
    {
        [field: SerializeField] public bool IsInteractable { get; set; } = true;
    }
}