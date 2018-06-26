using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingCamera : MonoBehaviour {

	[SerializeField]
	private GameObject[] MainCamera;
	[SerializeField]
	private GameObject[] AnswerCamera;
//	[SerializeField]
//	private Camera FeedbackCamera;

	[SerializeField]
	private bool[] ChangeCamera;

	private float Timer = 0;
	private int flag;

	// Use this for initialization
	void Start () {
		
		if (ChangeCamera [0] && !ChangeCamera [1] && !ChangeCamera [2]) {
			MainCamera [0].SetActive (true);
			AnswerCamera [0].SetActive (true);
			flag = 0;
		}
		else if (!ChangeCamera [0] && ChangeCamera [1] && !ChangeCamera [2]) {
			MainCamera [1].SetActive (true);
			AnswerCamera [1].SetActive (true);
			flag = 1;
		}
		else if (!ChangeCamera [0] && !ChangeCamera [1] && ChangeCamera [2]) {
			MainCamera [2].SetActive (true);
			AnswerCamera [2].SetActive (true);
			flag = 2;
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		Timer += Time.deltaTime;

		if (Timer > 30f) {
			if (flag == 0)
				MainCamera [0].GetComponent<Camera> ().enabled = false;
				AnswerCamera [0].GetComponent<Camera> ().enabled = true;

			if(flag == 1)
				MainCamera [1].GetComponent<Camera> ().enabled = false;
				AnswerCamera [1].GetComponent<Camera> ().enabled = true;

			if (flag == 2)
				MainCamera [2].GetComponent<Camera> ().enabled = false;
				AnswerCamera [2].GetComponent<Camera> ().enabled = true;	
		}

		/*此処より下にフィードバック用にoculustouchでカメラチェンジするコードを書く*/

	}
}
