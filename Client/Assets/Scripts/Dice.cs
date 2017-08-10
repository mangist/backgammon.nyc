using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice
{
    public string Name { get; set; }
    public Rigidbody Body { get; set; }
    public DiceState State { get; set; }
    public Vector3 StartPosition { get; set; }
}

public enum DiceState
{
    None,
    Rolling,
    Rolled
}