﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;

public class TestTracking : MonoBehaviour {

    [SerializeField]
    private GameObject target;
   
    private Vector3 pos;


	// Use this for initialization
	void Start () {
        //pos = target.transform.position;
       // this.transform.position = new Vector3(pos.x, this.transform.position.y, pos.z);
    }
	
	// Update is called once per frame
	void Update () {

        Quaternion pos = this.transform.rotation;
        pos.y = InputTracking.GetLocalRotation(VRNode.CenterEye).y;
       
        this.transform.rotation = pos;

    }
}
