using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

        // Raycast and see if we hit any checkers
        var checker = GetCheckerUnderMouse();
        if (checker != null)
        {

        }
    }

    GameObject GetCheckerUnderMouse()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            // Did we mouse over a checker?
            if (hit.collider.gameObject.tag == Tags.Checker)
            {
                Debug.Log(String.Format("MouseOver checker {0}", hit.collider.gameObject.name));
                return hit.collider.gameObject;
            }
            else
            {
                return null;
            }
        }
        else
        {
            return null; // Nothing under mouse
        }
    }
}
