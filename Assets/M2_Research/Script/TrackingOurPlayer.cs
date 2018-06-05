using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingOurPlayer : MonoBehaviour {

	[SerializeField]
	private GameObject MoveOurBall;
	[SerializeField]
	private GameObject OurPlayer;
	[SerializeField]
	AnimationCurve anim;

	private bool TrackFlag = true;
	private Vector3[] BfoAftPos= new Vector3[2];
	private Vector3 PlayerPos;

	private float BallSpeed;
	private Vector3 LastedSpeed;

	// Use this for initialization
	void Start () {
		
		
	}

	void OnTriggerStay(Collider other)
	{
		if (other.gameObject.tag == "RedBall")
		{
			TrackFlag = false;
			//Debug.Log ("false");
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "RedBall")
		{
			TrackFlag = true;
			//Debug.Log ("true");
		}
	}

	// Update is called once per frame
	void Update () {
		
		if (TrackFlag == true) {
			PlayerPos = OurPlayer.transform.position;
			OurPlayer.GetComponent<Animator> ().SetBool ("runrun", true);
			PlayerPos.x += (MoveOurBall.transform.position.x - PlayerPos.x) * 0.1f;
			PlayerPos.z += (MoveOurBall.transform.position.z - PlayerPos.z) * 0.1f;
			OurPlayer.transform.position = PlayerPos;
		} else {
			OurPlayer.GetComponent<Animator> ().SetBool ("runrun", false);

		}

		BallSpeed = ((MoveOurBall.transform.position - LastedSpeed) / Time.deltaTime).magnitude;
		LastedSpeed = MoveOurBall.transform.position;
		Debug.Log (BallSpeed);

		if (BallSpeed <= 0.09f)
			Debug.Log ("false");
//		else
//			Debug.Log ("true");
		
	}


//	private bool MoveState(){
//		if (BallSpeed == Vector3.zero)
//			return false;
//		else
//			return true;
//	}
}
