using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class MovingBall : MonoBehaviour {

	[SerializeField]
	private List<Transform> OurPlayer;

	private Vector3 Player1, Player2, Player3, BallPos;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Player1 = OurPlayer [0].position;
		Player2 = OurPlayer [1].position;
		Player3 = OurPlayer [2].position;
		BallPos = this.transform.position;



		StartCoroutine (DelayMethod (0f, () => {
			this.transform.parent=null;
			GetComponent<Rigidbody>().AddForce(new Vector3(Player3.x-BallPos.x, BallPos.y, Player3.z-BallPos.z)*30f,ForceMode.Force);
			this.transform.parent=OurPlayer[2];
		}));

		StartCoroutine (DelayMethod (5f, () => {
			this.transform.parent=null;
			GetComponent<Rigidbody>().AddForce(new Vector3(Player2.x-BallPos.x, BallPos.y, Player2.z-BallPos.z)*30f,ForceMode.Force);
			this.transform.parent=OurPlayer[1];
		}));

		StartCoroutine (DelayMethod (7f, () => {
			this.transform.parent=null;
			GetComponent<Rigidbody>().AddForce(new Vector3(Player1.x-BallPos.x, BallPos.y, Player1.z-BallPos.z)*30f,ForceMode.Force);
			this.transform.parent=OurPlayer[0];
		}));

		StartCoroutine (DelayMethod (12.5f, () => {
			this.transform.parent=null;
			GetComponent<Rigidbody>().AddForce(new Vector3(Player3.x-BallPos.x, BallPos.y, Player3.z-BallPos.z)*30f,ForceMode.Force);

		}));
			

	}



	private IEnumerator DelayMethod(float time, Action action)
	{
		yield return new WaitForSeconds(time);
		action();
	}



}
