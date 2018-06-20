using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MovingBall2 : MonoBehaviour {

	[SerializeField]
	private List<Transform> OurPlayer;

	private Vector3 Player1, Player2, Player3, BallPos;
	private int flag = 0;


	// Update is called once per frame
	void Update () {

		Player1 = OurPlayer [0].position;
		Player2 = OurPlayer [1].position;
		Player3 = OurPlayer [2].position;
		BallPos = this.transform.position;

		
	}

	private IEnumerator DelayMethod(float time, Action action)
	{
		yield return new WaitForSeconds(time);
		action();
	}
}
