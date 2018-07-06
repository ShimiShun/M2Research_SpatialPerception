using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerOparate : MonoBehaviour {
	
	[SerializeField]
	private GameObject TargetAnswer;

	[SerializeField]
	private GameObject[] AnswerCamera;


	ChangingCamera AnsCameraState;
	private int CameraState;

	int a = 0;

	// Use this for initialization
	void Start () {
		/*AnsCameraState = GetComponent<ChangingCamera> ();
		for (int i = 0; i < AnswerCamera.Length; i++) {
			var pos = AnswerCamera [i].transform.transform.position;
			pos.y += 10f;
			AnswerCamera [i].transform.position = pos;
		}*/
	}
	
	// Update is called once per frame
	void Update () {
		
		//CameraState = AnsCameraState.flag;

		/*-------EnterKeyで答え合わせをで~~~~~ん---------*/
		if (a == 0) {
			if (Input.GetKey (KeyCode.Space)) {
				var pos = TargetAnswer.transform.position;
				pos.y += 1f;
				TargetAnswer.transform.position = pos;

				/*for (int i = 0; i < AnswerCamera.Length; i++) {
					var pos2 = AnswerCamera [i].transform.transform.position;
					pos2.y -= 10f;
					AnswerCamera [i].transform.position = pos2;
				}*/

				a = 1;
			}
		}




	}
}
