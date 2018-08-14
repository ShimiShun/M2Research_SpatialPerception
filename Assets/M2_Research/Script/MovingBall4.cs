using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MovingBall4 : MonoBehaviour {

	[SerializeField]
	private List<Transform> OurPlayer;

	private Vector3 Player1, Player2, Player3, BallPos;
	private int flag = 0;
	float timer = 0.0f;



	// Update is called once per frame
	void Update () {


		timer += Time.deltaTime;
		//Debug.Log (timer);

		Player1 = OurPlayer [0].position;
		Player2 = OurPlayer [1].position;
		Player3 = OurPlayer [2].position;
		BallPos = this.transform.position;


		StartCoroutine (DelayMethod (14.5f, () => {
			if(flag==0){
				iTween.MoveTo(this.gameObject, iTween.Hash("position", new Vector3(Player1.x, BallPos.y, Player1.z+1.5f), "Time", 1f));
				flag=1;
			}
		}));

		StartCoroutine (DelayMethod (16.5f, () => {
			if(flag==1){
				iTween.MoveTo(this.gameObject, iTween.Hash("position", new Vector3(Player2.x-1f, BallPos.y, Player2.z-1f), "Time", 0.5f));
				flag=2;
			}
		}));

		StartCoroutine (DelayMethod (18f, () => {
			if(flag==2){
				iTween.MoveTo(this.gameObject, iTween.Hash("position", new Vector3(Player1.x+0f, BallPos.y, Player1.z), "Time", 1f));	
				flag=3;
			}
		}));
			
		StartCoroutine (DelayMethod (24f, () => {
			if(flag==3){
				flag=4;
				iTween.MoveTo(this.gameObject, iTween.Hash("position", new Vector3(Player3.x-2.5f, BallPos.y, Player3.z+1f), "Time", 0.5f));
				GameObject.Find("FeedBackCamera").GetComponent<AnswerOparate>().BallScore = 3;	
			}
		}));
			

	}


	private IEnumerator DelayMethod(float time, Action action)
	{
		yield return new WaitForSeconds(time);
		action();
	}


}
