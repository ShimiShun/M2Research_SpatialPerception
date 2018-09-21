using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;

public class ChangingCamera : MonoBehaviour {

    public enum Mode
    {
        Player1,
        Player2,
        Player3,
        ThirdPeronView
    };


    [SerializeField]
    private Mode CameraMode;

	[SerializeField]
	private GameObject[] MainCamera;
	[SerializeField]
	private GameObject[] AnswerCamera;
    [SerializeField]
    private GameObject OculusCamera;

	//[SerializeField]
	//private bool[] ChangeCamera;

	private float Timer = 0;
	private int CameraNumber;
    public int PlayTime;

     

	// Use this for initialization
	void Start () {
		
		if (CameraMode == Mode.Player1) {
			MainCamera [0].SetActive (true);
			//AnswerCamera [0].SetActive (true);
			CameraNumber = 0;
		}
		else if (CameraMode == Mode.Player2) {
			MainCamera [1].SetActive (true);
			//AnswerCamera [1].SetActive (true);
			CameraNumber = 1;
		}
		else if (CameraMode == Mode.Player3) {
			MainCamera [2].SetActive (true);
			//AnswerCamera [2].SetActive (true);
			CameraNumber = 2;
		}
        else
        {
            CameraNumber = 3;
        }




        //
        MainCamera[CameraNumber].transform.parent.gameObject.transform.Find("WBP").GetComponent<SkinnedMeshRenderer>().enabled = false;
        MainCamera[CameraNumber].transform.parent.gameObject.transform.Find("PlayerMarker").GetComponent<MeshRenderer>().enabled = true;

        PlayTime = Random.Range(21, 26);
       Debug.Log(PlayTime);
    }

	// Update is called once per frame
	void Update () {
		Timer += Time.deltaTime;
        OculusCamera.GetComponent<Camera>().enabled = false;

       // Debug.Log(Timer);

       // if (Timer > PlayTime+5f){
            if (Timer > 30){ 
            MainCamera[CameraNumber].GetComponent<Camera>().enabled = false;
            //AnswerCamera [CameraNumber].GetComponent<Camera> ().enabled = true;
            OculusCamera.GetComponent<Camera>().enabled = true;


            if (GameObject.Find("FeedBackCamera").GetComponent<AnswerOparate>().a == 1) {
            ////メインカメラ(一人称視点のカメラ)へのシフトONOFF
            if (OVRInput.Get(OVRInput.RawButton.B))
            {
                MainCamera[CameraNumber].GetComponent<Camera>().enabled = true;
                //AnswerCamera [CameraNumber].GetComponent<Camera> ().enabled = false;
                OculusCamera.GetComponent<Camera>().enabled = false;
            }
            else
            {
                MainCamera[CameraNumber].GetComponent<Camera>().enabled = false;
                //AnswerCamera [CameraNumber].GetComponent<Camera> ().enabled = true;
                OculusCamera.GetComponent<Camera>().enabled = true;
            }



            ////三人称視点のトップからの視点へのシフトONOFF
            /*if (OVRInput.Get(OVRInput.RawButton.A))
            {
                //AnswerCamera [CameraNumber].GetComponent<Camera> ().enabled = false;
                this.GetComponent<Camera>().enabled = true;
                OculusCamera.GetComponent<Camera>().enabled = false;
            }
            else
            {
                // AnswerCamera [CameraNumber].GetComponent<Camera> ().enabled = false;
                this.GetComponent<Camera>().enabled = false;
                OculusCamera.GetComponent<Camera>().enabled = true;
            }*/
        }


			
            
		}
	}

}
