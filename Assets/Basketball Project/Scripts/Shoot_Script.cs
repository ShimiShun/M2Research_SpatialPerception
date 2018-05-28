
using UnityEngine;
using System.Collections;

// throw handling in D-Pad
public class Shoot_Script : MonoBehaviour {

	public GameObject sphere;

	void Update () {
		// control touch input for mobile device
    	for (int touchIndex = 0; touchIndex<Input.touchCount; touchIndex++){
      		Touch currentTouch = Input.touches[touchIndex];
      		if (currentTouch.phase == TouchPhase.Ended && GetComponent<GUITexture>().HitTest(currentTouch.position)) {
				sphere.GetComponent<Sphere>().shootButtonEnded = true;
			}
    	}
	}
	
}
