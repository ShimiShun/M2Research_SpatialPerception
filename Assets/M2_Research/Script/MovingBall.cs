using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class MovingBall : MonoBehaviour {

	[SerializeField]
	private List<Transform> OurPlayer;

	private Vector3 Player1, Player2, Player3, BallPos;
	private int flag = 0;
    float timer = 0.0f;


    // Update is called once per frame
    void Update () {
		Player1 = OurPlayer [0].position;
		Player2 = OurPlayer [1].position;
		Player3 = OurPlayer [2].position;
		BallPos = this.transform.position;
        timer += Time.deltaTime;


        if (timer <= GameObject.Find("FeedBackCamera").GetComponent<ChangingCamera>().PlayTime)
        {

            StartCoroutine(DelayMethod(0f, () =>
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
                    iTween.MoveTo(this.gameObject, iTween.Hash("position", new Vector3(Player2.x + 1f, BallPos.y, Player2.z - 1f), "Time", 2f));
                    flag = 2;
                }
            }));

            StartCoroutine(DelayMethod(7f, () =>
            {
                if (flag == 2)
                {
                    iTween.MoveTo(this.gameObject, iTween.Hash("position", new Vector3(Player1.x - 2.5f, BallPos.y, Player1.z - 1f), "Time", 2f));
                    flag = 3;
                }
            }));

            StartCoroutine(DelayMethod(10.5f, () =>
            {
                if (flag == 3)
                {
                    flag = 4;
                    iTween.MoveTo(this.gameObject, iTween.Hash("position", new Vector3(Player2.x, BallPos.y, Player2.z), "Time", 2f));
                }
            }));


            StartCoroutine(DelayMethod(13f, () =>
            {
                if (flag == 4)
                {
                    flag = 5;
                    iTween.MoveTo(this.gameObject, iTween.Hash("position", new Vector3(Player3.x, BallPos.y, Player3.z), "Time", 2f));
                }
            }));

            StartCoroutine(DelayMethod(15.5f, () =>
            {
                if (flag == 5)
                {
                    flag = 6;
                    iTween.MoveTo(this.gameObject, iTween.Hash("position", new Vector3(Player2.x, BallPos.y, Player2.z), "Time", 2f));
                    GameObject.Find("FeedBackCamera").GetComponent<AnswerOparate>().BallScore = 2;
                }
            }));

            StartCoroutine(DelayMethod(24.5f, () =>
            {
                if (flag == 6)
                {
                    flag = 7;
                    iTween.MoveTo(this.gameObject, iTween.Hash("position", new Vector3(Player1.x - 2f, BallPos.y, Player1.z + 2f), "Time", 2f));
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
