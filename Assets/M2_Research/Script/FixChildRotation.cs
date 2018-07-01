using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixChildRotation : MonoBehaviour {


	private Quaternion _parent;


	void Start(){
		_parent = this.transform.transform.rotation;
	}



	void Update ()
	{
		gameObject.transform.rotation = Quaternion.Euler(_parent.x, _parent.y, _parent.z);
	}
}
