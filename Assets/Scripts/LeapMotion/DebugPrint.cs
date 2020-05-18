using UnityEngine;

namespace LeapMotion
{
    public class DebugPrint : MonoBehaviour
    {
        [SerializeField] private string logMessage = "Debug!";
        
        public void Print(string message = null)
        {
            Debug.Log(message ?? logMessage);
        }
    }
}