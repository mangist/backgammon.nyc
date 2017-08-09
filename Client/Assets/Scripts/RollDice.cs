using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RollDice : MonoBehaviour {

	
	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClick()
    {
        Debug.Log("Rolling dice...");

        DiceManager.Roll();
    }
}
