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

    public bool getState()
    {
        return state;
    }

	public void PlayerEnter(){
		state = true;
		score += 16;
	}

	public void PlayerExit(){
		state = false;
		score -= 16;
	}

    public void BallEnter()
    {
        state = true;
        score += 4;
    }

    public void BallExit()
    {
        state = false;
        score -= 4;
    }

    public string getNameTag(){
		return ball.tag;
	}

	public string getName(){
		return ball.name;
	}
}
