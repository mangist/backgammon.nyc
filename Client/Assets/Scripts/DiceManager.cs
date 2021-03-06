﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceManager : MonoBehaviour {

    // A list to store the dice Rigidbodies
    private static List<Dice> dice = new List<Dice>();
    
    // Use this for initialization
    void Start () {
        var diceObjects = GameObject.FindGameObjectsWithTag("Dice");

        // Remember their starting positions
        foreach (var d in diceObjects)
        {
            var rb = d.GetComponent<Rigidbody>();

            dice.Add(new Dice
            {
                Name = d.name,
                Body = rb,
                StartPosition = rb.position,
                State = DiceState.None
            });
        }
    }
	
	// Update is called once per frame
	void Update () {
		
        // Now check dice velocity to see if they have stopped
        foreach (var die in dice)
        {
            if (die.State == DiceState.Rolling)
            {
                if (die.Body.IsSleeping())
                {
                    Debug.Log(
                        string.Format("Dice {0} has stopped moving (rotation={1}", 
                        die.Name,
                        die.Body.rotation));
                                        
                    // Now calculate the value on the dice
                    die.State = DiceState.Rolled;
                }
                else if (die.Body.position.y < 0)
                {
                    // If die went off the table - needs a re-roll
                    Debug.Log(
                        string.Format("Die went off the table"));
                }
            }
        }
	}

    public static void Roll()
    {
        foreach (var die in dice)
        {
            // Set die in rolling state
            die.State = DiceState.Rolling;

            die.Body.position = die.StartPosition;

            // Give a slightly random velocity
            var xVel = Random.Range(0.01f, 0.2f);
            var yVel = Random.Range(0.01f, 0.2f);

            die.Body.velocity = new Vector3(xVel, yVel, 0);
            die.Body.rotation = Random.rotation;
        }
    }
}
