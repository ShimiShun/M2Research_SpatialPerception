using UnityEngine;
using System.Collections;

// pass handling in D-Pad
public class Pass_Script : MonoBehaviour {

public GameObject sphere;

	void Start() {


	}


	void Update () {
		// control touch input for mobile devices
		for (int touchIndex = 0; touchIndex<Input.touchCount; touchIndex++){
      		Touch currentTouch = Input.touches[touchIndex];
      		if(currentTouch.phase == TouchPhase.Began && GetComponent<GUITexture>().HitTest(currentTouch.position)){

				sphere.GetComponent<Sphere>().passButtonEnded = true;
            
			} else if ( currentTouch.phase == TouchPhase.Ended && GetComponent<GUITexture>().HitTest(currentTouch.position) ) {

				sphere.GetComponent<Sphere>().passButtonEnded = false;

			}

    	}
	
	}
	
}
