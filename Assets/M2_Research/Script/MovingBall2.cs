using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MovingBall2 : MonoBehaviour {

	[SerializeField]
	private List<Transform> OurPlayer;

	private Vector3 Player1, Player2, Player3, BallPos;
	private int flag = 0;
	float timer = 0.0f;

	// Update is called once per frame
	void Update () {

		timer += Time.deltaTime;
		Debug.Log (timer);

		Player1 = OurPlayer [0].position;
		Player2 = OurPlayer [1].position;
		Player3 = OurPlayer [2].position;
		BallPos = this.transform.position;


		StartCoroutine (DelayMethod (0.5f, () => {
			if(flag==0){
				iTween.MoveTo(this.gameObject, iTween.Hash("position", new Vector3(Player3.x, BallPos.y, Player3.z), "Time", 2f));
				flag=1;
			}
		}));

		StartCoroutine (DelayMethod (5f, () => {
			if(flag==1){
				iTween.MoveTo(this.gameObject, iTween.Hash("position", new Vector3(Player2.x, BallPos.y, Player2.z), "Time", 2f));
				flag=2;
			}
		}));

		StartCoroutine (DelayMethod (9.5f, () => {
			if(flag==2){
				iTween.MoveTo(this.gameObject, iTween.Hash("position", new Vector3(Player1.x, BallPos.y, Player1.z), "Time", 2f));	
				flag=3;
			}
		}));

		StartCoroutine (DelayMethod (16f, () => {
			if(flag==3){
				flag=4;
				iTween.MoveTo(this.gameObject, iTween.Hash("position", new Vector3(Player2.x, BallPos.y, Player2.z), "Time", 2f));	
			}
		}));


		StartCoroutine (DelayMethod (18f, () => {
			if(flag==4){
				flag=5;
				iTween.MoveTo(this.gameObject, iTween.Hash("position", new Vector3(Player1.x, BallPos.y, Player1.z), "Time", 1f));	
			}
		}));

		StartCoroutine (DelayMethod (19f, () => {
			if(flag==5){
				flag=6;
				//iTween.MoveTo(this.gameObject, iTween.Hash("position", new Vector3(Player2.x, BallPos.y, Player2.z), "Time", 2f));	
			}
		}));

		StartCoroutine (DelayMethod (19.5f, () => {
			if(flag==6){
				flag=7;
				//iTween.MoveTo(this.gameObject, iTween.Hash("position", new Vector3(Player1.x-2f, BallPos.y, Player1.z), "Time", 2f));	
			}
		}));

		StartCoroutine (DelayMethod (22.5f, () => {
			if(flag==7){
				flag=8;
				iTween.MoveTo(this.gameObject, iTween.Hash("position", new Vector3(Player3.x, BallPos.y, Player3.z), "Time", 2f));	
			}
		}));

		StartCoroutine (DelayMethod (24f, () => {
			if(flag==8){
				flag=9;
				iTween.MoveTo(this.gameObject, iTween.Hash("position", new Vector3(Player1.x, BallPos.y, Player1.z), "Time", 2f));	
			}
		}));
		
	}

	private IEnumerator DelayMethod(float time, Action action)
	{
		yield return new WaitForSeconds(time);
		action();
	}
}
