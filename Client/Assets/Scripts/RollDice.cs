using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RollDice : MonoBehaviour {

	private GameObject[] dice;
    private Dictionary<Rigidbody, Vector3> startPosition = new Dictionary<Rigidbody, Vector3>();
	// Use this for initialization
	void Start () {
        dice = GameObject.FindGameObjectsWithTag("Dice");

        // Remember their starting positions
        foreach (var d in dice)
        {
            var rb = d.GetComponent<Rigidbody>();
            startPosition.Add(rb, rb.position);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClick()
    {
        Debug.Log("Clicked button");

        foreach (var d in dice)
        {
            var rb = d.GetComponent<Rigidbody>();
            rb.position = startPosition[rb];

            // Give a slightly random velocity
            var xVel = Random.Range(0.01f, 0.2f);
            var yVel = Random.Range(0.01f, 0.2f);

            rb.velocity = new Vector3(xVel, yVel, 0);
            rb.rotation = Random.rotation;
        }
    }
}
