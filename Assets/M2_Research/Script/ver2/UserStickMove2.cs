using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserStickMove2 : MonoBehaviour {

    [SerializeField]
    private float MoveSpeed = 2;

    private Vector3 Player_pos;

	// Use this for initialization
	void Start () {

        Player_pos = GetComponent<Transform>().position;
	}
	
	// Update is called once per frame
	void Update () {

        if (OVRInput.Get(OVRInput.RawButton.RThumbstickUp))
        {
            transform.Translate(0f, 0f, MoveSpeed);
        }

        if (OVRInput.Get(OVRInput.RawButton.RThumbstickDown))
        {
            transform.Translate(0f, 0f, -MoveSpeed);
        }

        if (OVRInput.Get(OVRInput.RawButton.RThumbstickLeft))
        {
            transform.Translate(-MoveSpeed, 0f, 0f);
        }

        if (OVRInput.Get(OVRInput.RawButton.RThumbstickRight))
        {
            transform.Translate(MoveSpeed, 0f, 0f);
        }

        
        Vector3 diff = transform.position-Player_pos;

        if(diff.magnitude > 0f)
        {
           // transform.LookAt(diff);
        }


        Player_pos = transform.position;

    }
}
