using UnityEngine;
using System.Collections;

public class Magnet_Controller : MonoBehaviour {

	public GameObject obj;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		obj.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezePositionY;
		obj.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeRotation;
	}
}
