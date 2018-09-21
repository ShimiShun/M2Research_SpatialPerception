using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingOurPlayer : MonoBehaviour {

	[SerializeField]
	private GameObject MoveOurBall;
	[SerializeField]
	private GameObject OurPlayer;
	[SerializeField]
	private Transform BasketBall;

	[SerializeField]
	private GameObject B_Ball;
	private Vector3 B_Pos;

	private bool TrackFlag = false;
	private Vector3 PlayerPos;


	private float BallSpeed;
	private Vector3 LastedSpeed;

	private float TimerCount;
   
    
    void Start()
    {
       
       
    }


    void Update () {
       
        TimerCount += Time.deltaTime;
		
		if (OurPlayer.transform.position.y != MoveOurBall.transform.position.y)
			MoveOurBall.transform.position = new Vector3 (MoveOurBall.transform.position.x, OurPlayer.transform.position.y, MoveOurBall.transform.position.z);


		if (TimerCount < GameObject.Find("FeedBackCamera").GetComponent<ChangingCamera>().PlayTime) {
            //if (TimerCount < 30) { 
			if (TrackFlag == true) {
				OurPlayer.GetComponent<Animator> ().SetBool ("runrun", true);
				PlayerPos = OurPlayer.transform.position;
				PlayerPos.x += (MoveOurBall.transform.position.x - PlayerPos.x) * 0.5f;
				PlayerPos.z += (MoveOurBall.transform.position.z - PlayerPos.z) * 0.5f;
				OurPlayer.transform.position = PlayerPos;
                OurPlayer.transform.LookAt (MoveOurBall.transform.position);
                //OurPlayer.transform.rotation = Quaternion.RotateTowards(OurPlayer.transform.rotation, MoveOurBall.transform.rotation, Time.deltaTime);

			} else {
				Quaternion target = Quaternion.LookRotation (new Vector3 (BasketBall.rotation.x, OurPlayer.transform.rotation.y, BasketBall.rotation.z) - OurPlayer.transform.position);
				OurPlayer.GetComponent<Animator> ().SetBool ("runrun", false);
				//OurPlayer.transform.rotation = Quaternion.Slerp (OurPlayer.transform.rotation, target, Time.deltaTime);
			}

			BallSpeed = ((MoveOurBall.transform.position - LastedSpeed) / Time.deltaTime).magnitude;
			LastedSpeed = MoveOurBall.transform.position;

			MoveState ();
			GetBallState ();
		
		} else {
			OurPlayer.GetComponent<Animator> ().SetBool ("runrun", false);
			MoveOurBall.GetComponent<Animator> ().enabled = false;
		}

		
	}



	private void MoveState(){
		
		if (BallSpeed <= 0.09f) 
			TrackFlag = false;
		else 
			TrackFlag = true;
		
	}

	private void GetBallState(){
		if ((Mathf.Abs (B_Ball.transform.position.x - OurPlayer.transform.position.x) <= 0.5f) 
			&& (Mathf.Abs (B_Ball.transform.position.z - OurPlayer.transform.position.z) <= 0.5f)) {

			B_Ball.transform.position = new Vector3 (OurPlayer.transform.position.x, B_Ball.transform.position.y, OurPlayer.transform.position.z-0.2f);
			B_Ball.transform.parent = null;
			B_Ball.transform.parent = OurPlayer.transform;
		}
			
	}

}
