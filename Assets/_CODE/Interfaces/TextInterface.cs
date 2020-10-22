using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextInterface : MonoBehaviour {

    public TextMeshProUGUI textMesh;
    public void UpdateInterface(float number) { textMesh.text = number.ToString(); }
    public void UpdateInterface(int number) { textMesh.text = number.ToString(); }
    public void UpdateInterface(string newText) { textMesh.text = newText; }

    void Reset() { textMesh = GetComponent<TextMeshProUGUI>(); }
}
