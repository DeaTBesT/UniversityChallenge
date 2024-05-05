using UnityEngine;

namespace Tasks
{
    [CreateAssetMenu(menuName = "Tasks/New task")]
    public class TaskConfig : ScriptableObject
    {
        [SerializeField] private string _description;
        [SerializeField] private int _rightAnswerId;
        [SerializeField] private string[] _answers;
        
        public string GetDescription => _description;
        public int GetRightAnswerId => _rightAnswerId;
        public string[] GetAnswers => _answers;
    }
}