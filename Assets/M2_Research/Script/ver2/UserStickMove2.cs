using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;

public class UserStickMove2 : MonoBehaviour {

    [SerializeField]
    private float MoveSpeed = 2;
    [SerializeField]
    private float RotateDeg = 45;

    private Vector3 Player_pos;

	// Use this for initialization
	void Start () {

        Player_pos = GetComponent<Transform>().position;
        
	}
	
	// Update is called once per frame
	void Update () {

        InputTracking.GetLocalRotation(VRNode.CenterEye);

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
            //transform.Rotate(new Vector3(0, -RotateDeg, 0) * Time.deltaTime, Space.World);

        }

        if (OVRInput.Get(OVRInput.RawButton.RThumbstickRight))
        {
            transform.Translate(MoveSpeed, 0f, 0f);
           // transform.Rotate(new Vector3(0, RotateDeg, 0) * Time.deltaTime, Space.World);

        }

        
        Vector3 diff = transform.position-Player_pos;

        if(diff.magnitude > 0f)
        {
           // transform.LookAt(diff);
        }


        Player_pos = transform.position;

    }
}
