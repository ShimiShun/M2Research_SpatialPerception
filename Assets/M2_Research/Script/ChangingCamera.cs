using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;

public class ChangingCamera : MonoBehaviour {

	[SerializeField]
	private GameObject[] MainCamera;
	[SerializeField]
	private GameObject[] AnswerCamera;
    [SerializeField]
    private GameObject OculusCamera;

	[SerializeField]
	private bool[] ChangeCamera;

	private float Timer = 0;
	private int CameraNumber;

	// Use this for initialization
	void Start () {
		
		if (ChangeCamera [0] && !ChangeCamera [1] && !ChangeCamera [2]) {
			MainCamera [0].SetActive (true);
			AnswerCamera [0].SetActive (true);
			CameraNumber = 0;
		}
		else if (!ChangeCamera [0] && ChangeCamera [1] && !ChangeCamera [2]) {
			MainCamera [1].SetActive (true);
			AnswerCamera [1].SetActive (true);
			CameraNumber = 1;
		}
		else if (!ChangeCamera [0] && !ChangeCamera [1] && ChangeCamera [2]) {
			MainCamera [2].SetActive (true);
			AnswerCamera [2].SetActive (true);
			CameraNumber = 2;
		}


        
    }

	// Update is called once per frame
	void Update () {
		Timer += Time.deltaTime;
        OculusCamera.GetComponent<Camera>().enabled = false;
       
        if (Timer > 30f) {
			
			MainCamera [CameraNumber].GetComponent<Camera> ().enabled = false;
            //AnswerCamera [CameraNumber].GetComponent<Camera> ().enabled = true;
            OculusCamera.GetComponent<Camera>().enabled = true;

////メインカメラ(一人称視点のカメラ)へのシフトONOFF
			if (OVRInput.Get (OVRInput.RawButton.B)) {
				MainCamera [CameraNumber].GetComponent<Camera> ().enabled = true;
				//AnswerCamera [CameraNumber].GetComponent<Camera> ().enabled = false;
                OculusCamera.GetComponent<Camera>().enabled = false;
            } else {
				MainCamera [CameraNumber].GetComponent<Camera> ().enabled = false;
                //AnswerCamera [CameraNumber].GetComponent<Camera> ().enabled = true;
                OculusCamera.GetComponent<Camera>().enabled = true;
            }

            ////三人称視点のトップからの視点へのシフトONOFF
            if (OVRInput.Get (OVRInput.RawButton.A)) {
				//AnswerCamera [CameraNumber].GetComponent<Camera> ().enabled = false;
				this.GetComponent<Camera> ().enabled = true;
                OculusCamera.GetComponent<Camera>().enabled = false;
            } else{
               
               // AnswerCamera [CameraNumber].GetComponent<Camera> ().enabled = false;
                this.GetComponent<Camera> ().enabled = false;
                OculusCamera.GetComponent<Camera>().enabled = true;
            }


			
            
		}
	}

}
