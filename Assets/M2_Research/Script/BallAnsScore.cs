using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallAnsScore : MonoBehaviour {

	[SerializeField]
	private GameObject[] MoveAns;
	[SerializeField]
	private GameObject[] AnsArea;

	private BallAnsData[] AnswerData;


	// Use this for initialization
	void Start () {
		AnswerData = new BallAnsData[MoveAns.Length];
		for (int i = 0; i < AnswerData.Length; i++) {
			AnswerData [i] = new BallAnsData(MoveAns [i]);
			Debug.Log (AnswerData [i].getNameTag());
		}
			
	}
	
	// Update is called once per frame
	void Update () {
		
		
	}


	/*---------------Tagでやる場合---------------------*/

//	void OnTriggerEnter(Collider AnswerPlayer){
//		foreach(var Ans in AnswerData){
//			if ((this.gameObject.tag=="RedArea" && AnswerPlayer.tag == Ans.getNameTag())
//				|| (this.gameObject.tag == "BlueArea" && AnswerPlayer.tag == Ans.getNameTag())) {
//				Ans.BallEnter();
//
//			} 
//		}
//	}
//
//	void OnTriggerExit(Collider AnswerPlayer){
//		foreach(var Ans in AnswerData){
//			if ((this.gameObject.tag=="RedArea" && AnswerPlayer.tag == Ans.getNameTag())
//				|| (this.gameObject.tag == "BlueArea" && AnswerPlayer.tag == Ans.getNameTag())) {
//				Ans.BallExit();
//			}
//		}
//	}


	/*--------------Nameでやる場合----------------------*/

	void OnTriggerEnter(Collider AnswerPlayer){
		foreach (var Ans in AnswerData) {
			if ((this.gameObject.tag == "BlueArea" && AnswerPlayer.tag == "BlueAnswer")
			   || (this.gameObject.tag == "RedArea" && AnswerPlayer.tag == "RedAnswer")) {
				if (AnswerPlayer.name == Ans.getName ()
				   && AnswerPlayer.tag != "RedArea" && AnswerPlayer.tag != "BlueArea") {

					Ans.BallEnter ();
					break;
				} 
			}
		}
	}

	void OnTriggerExit(Collider AnswerPlayer){
		foreach (var Ans in AnswerData) {
			if ((this.gameObject.tag == "BlueArea" && AnswerPlayer.tag == "BlueAnswer")
				|| (this.gameObject.tag == "RedArea" && AnswerPlayer.tag == "RedAnswer")) {
				if (AnswerPlayer.name == Ans.getName ()
					&& AnswerPlayer.tag != "RedArea" && AnswerPlayer.tag != "BlueArea") {

					Ans.BallExit ();
					break;
				} 
			}
		}
	}

}
