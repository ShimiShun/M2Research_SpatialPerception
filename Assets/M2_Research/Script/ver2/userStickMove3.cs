using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class userStickMove3 : MonoBehaviour {

    [SerializeField]
    private float MoveSpeed = 0.02f;
    [SerializeField]
    private Camera FirstCamera;

    private Vector3 Player_pos;
    private float inputH;
    private float inputV;
    private Rigidbody rb;

    // Use this for initialization
    void Start () {
        Player_pos = GetComponent<Transform>().position;
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {

        Vector2 pos = new Vector2(Input.GetAxis("Horizontal2"), Input.GetAxis("Vertical2"));
        Debug.Log( pos);

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
    }

    private void FixedUpdate()
    {
        inputV = Input.GetAxis("Vertical2");
        inputH = Input.GetAxis("Horizontal2");


        Vector3 cameraForward = Vector3.Scale(FirstCamera.transform.forward, new Vector3(1, 0, 1).normalized);

        Vector3 moveForward = cameraForward * MoveSpeed * inputV + FirstCamera.transform.right * inputH;

        rb.velocity = moveForward * MoveSpeed;

        if (moveForward != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveForward);
        }
    }
}
