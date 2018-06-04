using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingOurPlayer : MonoBehaviour {

	[SerializeField]
	private GameObject MoveOurBall;
	[SerializeField]
	private GameObject OurPlayer;

	private bool TrackFlag = false;
	private Vector3 FirstPos;

	// Use this for initialization
	void Start () {
		FirstPos = MoveOurBall.transform.position;
		
	}

	void OnTriggerStay(Collider other)
	{
		if (other.gameObject.tag == "RedBall")
		{
			TrackFlag = false;
			//Debug.Log ("false");
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "RedBall")
		{
			TrackFlag = true;
			Debug.Log ("true");
		}
	}

	// Update is called once per frame
	void Update () {
//		Vector2 pos1 = new Vector2(this.transform.position.x, this.transform.position.z);
//		Vector2 pos2 = new Vector2(MoveOurBall [0].transform.position.x, MoveOurBall [0].transform.position.z);
		if (MoveOurBall.transform.position != FirstPos)
			TrackFlag = true;


		if (TrackFlag == true) {
			OurPlayer.GetComponent<Animator> ().SetBool ("runrun", true);
			OurPlayer.transform.position += (MoveOurBall.transform.position - OurPlayer.transform.position) * 0.01f;
		} else {
			OurPlayer.GetComponent<Animator> ().SetBool ("runrun", false);
			//Debug.Log (Vector2.Distance (pos1, pos2));
		}

		
	}
}
