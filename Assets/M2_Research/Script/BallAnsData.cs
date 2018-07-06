using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallAnsData{

	private bool state;
	private GameObject ball;
	public static int score = 0;

	

	public BallAnsData(GameObject ball){
		state = false;

		this.ball = ball;
	}

	public void BallEnter(){
		state = true;
		score += 16;
        if (score >= 96)
            score = 100;
        Debug.Log (score);
	}

	public void BallExit(){
		state = false;
		score -= 16;
        if (score >= 96)
            score = 100;
		Debug.Log (score);
	}

	public string getNameTag(){
		return ball.tag;
	}

	public string getName(){
		return ball.name;
	}
}
