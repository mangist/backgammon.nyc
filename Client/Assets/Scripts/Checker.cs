using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checker {
    
    public Player Player { get; set; }
    public GameObject Object { get; set; }
    
    // Static constants
    public static readonly Quaternion DefaultRotation = Quaternion.Euler(-90.0f, 0, 0);
    public static readonly float Width = 0.02279646f;

}
