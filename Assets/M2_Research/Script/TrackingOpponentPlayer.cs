using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingOpponentPlayer : MonoBehaviour {

	[SerializeField]
	private GameObject MoveOurBall;
	[SerializeField]
	private GameObject OpponentPlayer;
	private bool TrackFlag = false;
	private Vector3 PlayerPos;

	private float BallSpeed;
	private Vector3 LastedSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
