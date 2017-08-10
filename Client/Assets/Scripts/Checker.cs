using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checker : MonoBehaviour {
    
    public Player Player { get; set; }
    public GameObject Object { get; set; }
    
    // Static constants
    public static Quaternion DefaultRotation { get; private set; }
	
    public static  float Width { get; private set; }

    // Use this for initialization
	void Start () {
        // What is the default rotation for this piece in the world space
        DefaultRotation = Quaternion.Euler(-90.0f, 0, 0);
        Width = 0.02279646f;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
