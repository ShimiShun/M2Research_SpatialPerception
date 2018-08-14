using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallAnsScore : MonoBehaviour {

	[SerializeField]
	private GameObject[] MoveAns;
	[SerializeField]
	private GameObject[] AnsArea;
   
	private BallAnsData[] AnswerData;
    public static int BallNumber;

    AnswerOparate BallHoldNumber;
    public int AnsState = 0;


	// Use this for initialization
	void Start () {
		AnswerData = new BallAnsData[MoveAns.Length];
		for (int i = 0; i < AnswerData.Length; i++) {
			AnswerData [i] = new BallAnsData(MoveAns [i]);
			//Debug.Log (AnswerData [i].getNameTag());
		}

        BallHoldNumber = GameObject.Find("FeedBackCamera").GetComponent<AnswerOparate>();
			
	}
	


	void OnTriggerEnter(Collider AnswerPlayer){
        
		foreach (var Ans in AnswerData) {

            if (BallHoldNumber.BallScore == 1 && this.gameObject.name == "Player1" && AnswerPlayer.tag == "ball"
                || BallHoldNumber.BallScore == 2 && this.gameObject.name == "Player2" && AnswerPlayer.tag == "ball"
                || BallHoldNumber.BallScore == 3 && this.gameObject.name == "Player3" && AnswerPlayer.tag == "ball")
            {
                Ans.BallEnter();
                break;
            }

            if ((this.gameObject.tag == "BlueArea" && AnswerPlayer.tag == "BlueAnswer")
			   || (this.gameObject.tag == "RedArea" && AnswerPlayer.tag == "RedAnswer")) {
				if (AnswerPlayer.name == Ans.getName ()
				   && AnswerPlayer.tag != "RedArea" && AnswerPlayer.tag != "BlueArea") {

                    AnsState++;

                    if (AnsState==1)
                    {
                        Ans.PlayerEnter();
                       
                    }
                    Debug.Log(AnsState);
                    break;
				} 
			}
		}
	}

	void OnTriggerExit(Collider AnswerPlayer){
		foreach (var Ans in AnswerData) {

            if (BallHoldNumber.BallScore == 1 && this.gameObject.name == "Player1" && AnswerPlayer.tag == "ball"
                || BallHoldNumber.BallScore == 2 && this.gameObject.name == "Player2" && AnswerPlayer.tag == "ball"
                || BallHoldNumber.BallScore == 3 && this.gameObject.name == "Player3" && AnswerPlayer.tag == "ball")
            {
                Ans.BallExit();
                break;
            }

            if ((this.gameObject.tag == "BlueArea" && AnswerPlayer.tag == "BlueAnswer")
				|| (this.gameObject.tag == "RedArea" && AnswerPlayer.tag == "RedAnswer")) {
				if (AnswerPlayer.name == Ans.getName ()
					&& AnswerPlayer.tag != "RedArea" && AnswerPlayer.tag != "BlueArea") {

                    AnsState--;
                    if (AnsState == 0)
                    {
                        Ans.PlayerExit();
                       
                    }

                    Debug.Log(AnsState);
                    break;
				} 
			}
		}
	}

}
