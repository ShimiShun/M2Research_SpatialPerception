using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerOparate : MonoBehaviour {
	
	[SerializeField]
	private GameObject TargetAnswer;

	[SerializeField]
	private GameObject[] AnswerCamera;

    [SerializeField]
    private GameObject PointText;

    [SerializeField]
    private GameObject[] UserMovePlayers;


	ChangingCamera AnsCameraState;
	private int CameraState;
    public int BallScore;
	public int a = 0;

    private float[] posY = new float[7];

    // Use this for initialization
    void Start() {
        /*AnsCameraState = GetComponent<ChangingCamera> ();
		for (int i = 0; i < AnswerCamera.Length; i++) {
			var pos = AnswerCamera [i].transform.transform.position;
			pos.y += 10f;
			AnswerCamera [i].transform.position = pos;
		}*/

        for(int i=0; i<UserMovePlayers.Length; i++)
        {
            posY[i] = UserMovePlayers[i].transform.position.y;
        }

        
    }
	
	// Update is called once per frame
	void Update () {

        //CameraState = AnsCameraState.flag;


        if (Input.GetKey(KeyCode.Return))
        {
            for(int i=0; i<UserMovePlayers.Length; i++)
            {
                if(UserMovePlayers[i].transform.position.y < -10f)
                {
                    var pos = UserMovePlayers[i].transform.position;
                    pos.y = posY[i];
                    UserMovePlayers[i].transform.position = pos;
                }
            }

           
        }
       
		
        /*-------EnterKeyで答え合わせをで～～～～ん---------*/
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


        /*------------------ポイントの３Dテキスト表示------------------------*/

      
        PointText.GetComponent<TextMesh>().text = BallAnsData.score + "Points";



	}
}
