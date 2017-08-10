using UnityEngine;
using System.Collections;

public class CheckerGlow : MonoBehaviour {

    // Property for mouse over color
    public Color mouseOverColor = Color.red;

    private Color originalColor;
    private Renderer rnd;

    private void Start()
    {
        rnd = GetComponent<Renderer>();
        originalColor = rnd.material.color;
    }

    void OnMouseEnter() {
        rnd.material.color = mouseOverColor;
    }

    void OnMouseExit() {
        rnd.material.color = originalColor;
    }
}