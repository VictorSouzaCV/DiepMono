using UnityEngine;
using TMPro;

namespace DiepMono.UI 
{ 
    [RequireComponent(typeof (TextMeshProUGUI))]
    public class TextUI : MonoBehaviour
    {
        public TextMeshProUGUI textMesh;

        public void UpdateInterface(float number) 
        { 
            textMesh.text = number.ToString(); 
        }

        public void UpdateInterface(int number) 
        {
            textMesh.text = number.ToString(); 
        }

        public void UpdateInterface(string newText) 
        {
            textMesh.text = newText; 
        }

        void Reset() 
        {
            textMesh = GetComponent<TextMeshProUGUI>(); 
        }
    } 
}
