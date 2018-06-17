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
		if (OpponentPlayer.transform.position.y != MoveOurBall.transform.position.y)
			MoveOurBall.transform.position = new Vector3 (MoveOurBall.transform.position.x, OpponentPlayer.transform.position.y, MoveOurBall.transform.position.z);

		if (TrackFlag == true) {
			OpponentPlayer.GetComponent<Animator> ().SetBool ("runrun", true);
			PlayerPos = OpponentPlayer.transform.position;
			PlayerPos.x += (MoveOurBall.transform.position.x - PlayerPos.x) * 0.1f;
			PlayerPos.z += (MoveOurBall.transform.position.z - PlayerPos.z) * 0.1f;
			OpponentPlayer.transform.position = PlayerPos;
			OpponentPlayer.transform.LookAt (MoveOurBall.transform.position);

		} else {
			Quaternion target = Quaternion.LookRotation (new Vector3(MoveOurBall.transform.rotation.x, OpponentPlayer.transform.rotation.y, MoveOurBall.transform.rotation.z)-OpponentPlayer.transform.position);
			OpponentPlayer.GetComponent<Animator> ().SetBool ("runrun", false);
			//OurPlayer.transform.rotation = Quaternion.Slerp (OurPlayer.transform.rotation, target, Time.deltaTime*3);
		}

		BallSpeed = ((MoveOurBall.transform.position - LastedSpeed) / Time.deltaTime).magnitude;
		LastedSpeed = MoveOurBall.transform.position;

		MoveState ();


	}


	private void MoveState(){

		if (BallSpeed <= 0.09f) 
			TrackFlag = false;
		else 
			TrackFlag = true;

	}
}
