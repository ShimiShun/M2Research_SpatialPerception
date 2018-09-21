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
		//Debug.Log (timer);

		Player1 = OurPlayer [0].position;
		Player2 = OurPlayer [1].position;
		Player3 = OurPlayer [2].position;
		BallPos = this.transform.position;

        if (timer <= GameObject.Find("FeedBackCamera").GetComponent<ChangingCamera>().PlayTime)
        {

            StartCoroutine(DelayMethod(0.5f, () =>
            {
                if (flag == 0)
                {
                    iTween.MoveTo(this.gameObject, iTween.Hash("position", new Vector3(Player3.x, BallPos.y, Player3.z), "Time", 2f));
                    flag = 1;
                }
            }));

            StartCoroutine(DelayMethod(5f, () =>
            {
                if (flag == 1)
                {
                    iTween.MoveTo(this.gameObject, iTween.Hash("position", new Vector3(Player2.x, BallPos.y, Player2.z), "Time", 2f));
                    flag = 2;
                }
            }));

            StartCoroutine(DelayMethod(10f, () =>
            {
                if (flag == 2)
                {
                    iTween.MoveTo(this.gameObject, iTween.Hash("position", new Vector3(Player1.x, BallPos.y, Player1.z - 0.3f), "Time", 1f));
                    flag = 3;
                }
            }));

            StartCoroutine(DelayMethod(13.5f, () =>
            {
                if (flag == 3)
                {
                    flag = 4;
                    iTween.MoveTo(this.gameObject, iTween.Hash("position", new Vector3(Player3.x, BallPos.y, Player3.z), "Time", 2f));
                }
            }));


            StartCoroutine(DelayMethod(14f, () =>
            {
                if (flag == 4)
                {
                    flag = 5;
                    iTween.MoveTo(this.gameObject, iTween.Hash("position", new Vector3(Player2.x, BallPos.y, Player2.z), "Time", 1f));
                    GameObject.Find("FeedBackCamera").GetComponent<AnswerOparate>().BallScore = 2;
                }
            }));

            StartCoroutine(DelayMethod(19f, () =>
            {
                if (flag == 5)
                {
                    flag = 6;
                    //iTween.MoveTo(this.gameObject, iTween.Hash("position", new Vector3(Player2.x, BallPos.y, Player2.z), "Time", 2f));	
                }
            }));

            StartCoroutine(DelayMethod(19.5f, () =>
            {
                if (flag == 6)
                {
                    flag = 7;
                    //iTween.MoveTo(this.gameObject, iTween.Hash("position", new Vector3(Player1.x-2f, BallPos.y, Player1.z), "Time", 2f));	
                }
            }));

            StartCoroutine(DelayMethod(20f, () =>
            {
                if (flag == 7)
                {
                    flag = 8;
                    iTween.MoveTo(this.gameObject, iTween.Hash("position", new Vector3(Player3.x, BallPos.y, Player3.z), "Time", 2f));
                    GameObject.Find("FeedBackCamera").GetComponent<AnswerOparate>().BallScore = 3;
                }
            }));

            StartCoroutine(DelayMethod(25f, () =>
            {
                if (flag == 8)
                {
                    flag = 9;
                    iTween.MoveTo(this.gameObject, iTween.Hash("position", new Vector3(Player1.x + 2.5f, BallPos.y, Player1.z + 2f), "Time", 2f));
                    GameObject.Find("FeedBackCamera").GetComponent<AnswerOparate>().BallScore = 1;
                }
            }));
        }
        else
        {
            flag = 10;
        }
		
	}

	private IEnumerator DelayMethod(float time, Action action)
	{
		yield return new WaitForSeconds(time);
		action();
	}
}
