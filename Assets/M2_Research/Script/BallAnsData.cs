using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallAnsData : MonoBehaviour {

	private bool state;
	private GameObject ball;
	public static int score = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public BallAnsData(GameObject ball){
		state = false;

		this.ball = ball;
	}

	public void BallEnter(){
		state = true;
		score += 16;
		Debug.Log (score);
	}

	public void BallExit(){
		state = false;
		score -= 16;
		Debug.Log (score);
	}

	public string getNameTag(){
		return ball.tag;
	}

	public string getName(){
		return ball.name;
	}
}
