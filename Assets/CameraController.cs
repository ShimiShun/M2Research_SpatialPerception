using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public float distance;
	public float height;
	public float width;
	public float rotx;
	public float roty;
	public float rotz;

	public Transform target;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.position = target.position + (-Vector3.forward * distance) + (Vector3.up * height)+(Vector3.left*width);
		//this.transform.rotation = Quaternion.Euler(target.transform.localEulerAngles.x*rotx,0,0);
		//transform.LookAt (target);
	}
}
