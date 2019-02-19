using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MovingBall5 : MonoBehaviour {

	[SerializeField]
	private List<Transform> OurPlayer;

	private Vector3 Player1, Player2, Player3, BallPos;
	private int flag = 0;
	float timer = 0.0f;


	// Use this for initialization
	void Start () {
		
	}
	
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

            StartCoroutine(DelayMethod(3.2f, () =>
            {
                if (flag == 0)
                {
                    iTween.MoveTo(this.gameObject, iTween.Hash("position", new Vector3(Player1.x, BallPos.y, Player1.z), "Time", 1f));
                    flag = 1;
                }
            }));

            StartCoroutine(DelayMethod(7.5f, () =>
            {
                if (flag == 1)
                {
                    iTween.MoveTo(this.gameObject, iTween.Hash("position", new Vector3(Player2.x, BallPos.y, Player2.z), "Time", 0.5f));
                    flag = 2;
                }
            }));

            StartCoroutine(DelayMethod(9.5f, () =>
            {
                if (flag == 2)
                {
                    iTween.MoveTo(this.gameObject, iTween.Hash("position", new Vector3(Player3.x + 0f, BallPos.y, Player3.z), "Time", 0.5f));
                    flag = 3;
                }
            }));

            StartCoroutine(DelayMethod(11f, () =>
            {
                if (flag == 3)
                {
                    iTween.MoveTo(this.gameObject, iTween.Hash("position", new Vector3(Player2.x - 2f, BallPos.y, Player2.z - 1f), "Time", 0.5f));
                    flag = 4;
                }
            }));

            StartCoroutine(DelayMethod(18f, () =>
            {
                if (flag == 4)
                {
                    iTween.MoveTo(this.gameObject, iTween.Hash("position", new Vector3(Player3.x + 0f, BallPos.y, Player3.z), "Time", 0.5f));
                    flag = 5;
                }
            }));

            StartCoroutine(DelayMethod(19f, () =>
            {
                if (flag == 5)
                {
                    iTween.MoveTo(this.gameObject, iTween.Hash("position", new Vector3(Player1.x + 0f, BallPos.y, Player1.z), "Time", 0.5f));
                    flag = 6;
                    GameObject.Find("FeedBackCamera").GetComponent<AnswerOparate>().BallScore = 1;
                }
            }));

            StartCoroutine(DelayMethod(21f, () =>
            {
                if (flag == 6)
                {
                    flag = 7;
                    iTween.MoveTo(this.gameObject, iTween.Hash("position", new Vector3(Player2.x, BallPos.y, Player2.z), "Time", 1f));
                    GameObject.Find("FeedBackCamera").GetComponent<AnswerOparate>().BallScore = 2;
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
