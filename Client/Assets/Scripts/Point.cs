﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point
{
    public List<Checker> Checkers { get; private set; }
    public int Number { get; private set; }

    public Vector3 Position;

    public Point(int number, Vector3 position)
    {
        this.Checkers = new List<Checker>();
        this.Number = number;

        this.Position = position;
    }

    public void AddChecker(Checker checker)
    {
        // Add to our list of checkers
        this.Checkers.Add(checker);

        // Are we stacking up (away) or down (towards) the camera
        var ct = checker.Object.transform;

        var zIncrease = this.Number <= 12;

        // Now move the object (this is instant, I want to animate this at some point!)
        if (zIncrease)
        {
            ct.position = this.Position + new Vector3(0, 0, Checker.Width * (Checkers.Count+1));
        }
        else
        {
            ct.position = this.Position - new Vector3(0, 0, Checker.Width * (Checkers.Count+1));
        }

        ct.rotation = Checker.DefaultRotation;
    }

    public void RemoveChecker(Checker checker)
    {
        // Assume this is the top checker
        this.Checkers.Remove(checker);
    }
}
