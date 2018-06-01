using UnityEngine;
using System;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class player_move3 : MonoBehaviour {

	/*---------------------Team Player-------------------*/
	public GameObject ball, O1, O2, O3;
	private int flag = 0, flag2=0,begin=0;
	Vector3 po1, po2, po3,pb;

	/*-------------------Opponent Player-----------------*/
	public GameObject D1, D2, D3;
	private Vector3 pd1, pd2, pd3;
	public GUIText text1;

    private Vector3 sd1, sd2, sd3, so1, so2, so3, sb;
    private Quaternion ro1, ro2, ro3, rd1, rd2, rd3;

    //private PassingListener gestureListener;
    private AudioSource[] sources;

    // Use this for initialization
    void Start () {
		text1.text = "[Point]\n基本は空いたスペースでボールをもらうこと";
        // get the gestures listener

        //GameObject.Find("KinectController").GetComponent<KinectManager>().StartKinect();
        // gestureListener = PassingListener.Instance;

        so1 = O1.transform.position;
        so2 = O2.transform.position;
        so3 = O3.transform.position;
        sd1 = D1.transform.position;
        sd2 = D2.transform.position;
        sd3 = D3.transform.position;
        sb = ball.transform.position;

        ro1 = O1.transform.rotation;
        ro2 = O2.transform.rotation;
        ro3 = O3.transform.rotation;
        rd1 = D1.transform.rotation;
        rd2 = D2.transform.rotation;
        rd3 = D3.transform.rotation;

        sources = GameObject.Find("/AudioClipObject").GetComponents<AudioSource>();

        sources[0].Play();
        StartCoroutine(DelayMethod(5f, () =>
        {
            sources[1].Play();
        }));
    }
	
	// Update is called once per frame
	void Update () {
       // gestureListener = PassingListener.Instance;
        /*-------------------about gesture---------------------*/
       // if (!gestureListener)return;
       /* if (gestureListener.IsRaiseRightHand())
        {
            Debug.Log(false);
        }*/

        po1 = O1.transform.position;
		po2 = O2.transform.position;
		po3 = O3.transform.position;
		pd1 = D1.transform.position;
		pd2 = D2.transform.position;
		pd3 = D3.transform.position;
		pb = ball.transform.position;
        if (begin == 0)
        {

            StartCoroutine(DelayMethod(5f, () =>
            {
                if (flag == 0)
                {
                    //text1.text = "基本は空いたスペースでボールをもらうことです";
                    iTween.MoveTo(ball, iTween.Hash("position", new Vector3(po2.x - 0.3f, pb.y, po2.z - 0.3f), "Time", 2f));
                    //text1.text = "";
                    O1.transform.rotation = Quaternion.Euler(0, 10, 0);
                    O1.GetComponent<Animator>().SetBool("runrun", true);

                }

                StartCoroutine(DelayMethod(0.5f, () =>
                {
                    if (flag == 0)
                    {
                        D1.transform.rotation = Quaternion.Euler(0, 10, 0);
                        D1.GetComponent<Animator>().SetBool("runrun", true);
                    }
                }));

                
                StartCoroutine(DelayMethod(5f, () =>
                {
                    //text1.text = "ここでパスをもらうための動き方が２つあります\n赤い円のスペースか青い円のスペースでもらうのかの2つ\nここで注意したいのが、自分をマークしているディフェンスが\n自分より前に出てきているということです";
                    GameObject.Find("/Marker/RadarCursor1/Cursor1").GetComponent<Renderer>().enabled = false;
                    GameObject.Find("/Marker/RadarCursor1/Cursor2").GetComponent<Renderer>().enabled = false;
                    GameObject.Find("/Marker/RadarCursor1/Cursor3").GetComponent<Renderer>().enabled = false;
                    //GameObject.Find("Marker/circle_red").GetComponent<Renderer>().enabled = true;
                    //GameObject.Find("Marker/circle_blue").GetComponent<Renderer>().enabled = true;
                    //StartCoroutine (DelayMethod (3f, () =>{
                    if (flag == 1)
                    {
                        GameObject.Find("/Marker/circle3").GetComponent<Renderer>().enabled = false;
                        O1.transform.rotation = Quaternion.Euler(0, 260, 0);
                        O1.GetComponent<Animator>().SetBool("runrun", true);
                        O1.GetComponent<Animator>().speed = 1.3f;
                        D1.transform.rotation = Quaternion.Euler(0, 250, 0);
                        D1.GetComponent<Animator>().SetBool("runrun", true);
                        D1.GetComponent<Animator>().speed = 1f;

                        O3.transform.rotation = Quaternion.Euler(0, 130, 0);
                        O3.GetComponent<Animator>().SetBool("runrun", true);
                        O3.GetComponent<Animator>().speed = 1f;
                        D3.transform.rotation = Quaternion.Euler(0, 130, 0);
                        D3.GetComponent<Animator>().SetBool("runrun", true);
                        D3.GetComponent<Animator>().speed = 1.0f;

                    }
                }));


                StartCoroutine(DelayMethod(0.5f, () =>
                {
                    if (flag == 3)
                    {
                        /*if (gestureListener.IsRaiseRightHand()||gestureListener.IsMoveRight())
                        {
                        text1.text = "もしここで右に動いてしまうと狙っていたディフェンスに\nボールを取られてしまいます";
                        //if (Input.GetKey(KeyCode.RightArrow)){
                        flag2 = 1;
                            Debug.Log(true);
                            ball.GetComponent<Rigidbody>().AddForce((new Vector3(po3.x, pb.y, po3.z - 1.5f) - pb) * 500);
                            O3.transform.rotation = Quaternion.Euler(0, 125, 0);
                            O3.GetComponent<Animator>().SetBool("runrun", true);

                            D3.transform.rotation = Quaternion.Euler(0, 120, 0);
                            D3.GetComponent<Animator>().SetBool("runrun", true);
                            D3.GetComponent<Animator>().speed = 1.3f;
                        }*/


                        //if (gestureListener.IsRaiseLeftHand()||gestureListener.IsMoveLeft()){
                        //text1.text = "";
                        //if(Input.GetKey(KeyCode.LeftArrow)){
                        //flag2 = 2;
                        O3.transform.rotation = Quaternion.Euler(0, 5, 0);
                        O3.GetComponent<Animator>().SetBool("runrun", true);
                        O3.GetComponent<Animator>().speed = 1.3f;
                        // ball.GetComponent<Rigidbody>().AddForce((new Vector3(po3.x, pb.y, po3.z + 2f) - pb) * 100);
                        iTween.MoveTo(ball, iTween.Hash("position", new Vector3(po3.x + 0f, pb.y, po3.z + 1f), "Time", 1f));

                        StartCoroutine(DelayMethod(0.5f, () =>
                        {
                            if (flag2 == 0)
                            {
                                D3.transform.rotation = Quaternion.Euler(0, 0, 0);
                                D3.GetComponent<Animator>().SetBool("runrun", true);
                                D3.GetComponent<Animator>().speed = 1.2f;
                            }
                        }));

                    }
                }));

                StartCoroutine(DelayMethod(10f, () =>
                {
                    SceneManager.LoadScene("3DLesson3slow");
                }));
                    // }
                    /*StartCoroutine(DelayMethod(10f, () =>
                    {
                        //screen shot
                        begin = 1;
                    O1.transform.position = so1;
                    O2.transform.position = so2;
                    O3.transform.position = so3;
                    D1.transform.position = sd1;
                    D2.transform.position = sd2;
                    D3.transform.position = sd3;
                    ball.transform.position = sb;
                    // Debug.Log(begin);
                    O1.transform.rotation = ro1;
                    O2.transform.rotation = ro2;
                    O3.transform.rotation = ro3;
                    D1.transform.rotation = rd1;
                    D2.transform.rotation = rd2;
                    D3.transform.rotation = rd3;
                    //this.transform.parent = null;



                //ball.transform.parent = O1.transform;
                //flag = 0; flag2 = 0;

                        //O1.GetComponent<Animator>().SetBool("runrun", false);
                        //D1.GetComponent<Animator>().SetBool("runrun", false);
                    }));*/

                }));

        }
       /* if (begin == 1)
        {
            Debug.Log(true);
            StartCoroutine(DelayMethod(5f, () =>
            {
                if (flag == 0)
                {
                    text1.text = "基本は空いたスペースでボールをもらうことです";
                    iTween.MoveTo(ball, iTween.Hash("position", new Vector3(po2.x - 0.3f, pb.y, po2.z - 0.3f), "Time", 2f));
                    //text1.text = "";
                    O1.transform.rotation = Quaternion.Euler(0, 10, 0);
                    O1.GetComponent<Animator>().SetBool("runrun", true);

                }

                StartCoroutine(DelayMethod(0.5f, () =>
                {
                    if (flag == 0)
                    {
                        D1.transform.rotation = Quaternion.Euler(0, 10, 0);
                        D1.GetComponent<Animator>().SetBool("runrun", true);
                    }
                }));




                StartCoroutine(DelayMethod(5f, () =>
                {
                    //text1.text = "ここでパスをもらうための動き方が２つあります\n赤い円のスペースか青い円のスペースでもらうのかの2つ\nここで注意したいのが、自分をマークしているディフェンスが\n自分より前に出てきているということです";
                    GameObject.Find("/Marker/RadarCursor1/Cursor1").GetComponent<Renderer>().enabled = false;
                    GameObject.Find("/Marker/RadarCursor1/Cursor2").GetComponent<Renderer>().enabled = false;
                    GameObject.Find("/Marker/RadarCursor1/Cursor3").GetComponent<Renderer>().enabled = false;
                    //GameObject.Find("Marker/circle_red").GetComponent<Renderer>().enabled = true;
                    //GameObject.Find("Marker/circle_blue").GetComponent<Renderer>().enabled = true;
                    //StartCoroutine (DelayMethod (3f, () =>{
                    if (flag == 1)
                    {

                        O1.transform.rotation = Quaternion.Euler(0, 260, 0);
                        O1.GetComponent<Animator>().SetBool("runrun", true);
                        O1.GetComponent<Animator>().speed = 1.3f;
                        D1.transform.rotation = Quaternion.Euler(0, 250, 0);
                        D1.GetComponent<Animator>().SetBool("runrun", true);
                        D1.GetComponent<Animator>().speed = 1f;

                        O3.transform.rotation = Quaternion.Euler(0, 130, 0);
                        O3.GetComponent<Animator>().SetBool("runrun", true);
                        O3.GetComponent<Animator>().speed = 1f;
                        D3.transform.rotation = Quaternion.Euler(0, 130, 0);
                        D3.GetComponent<Animator>().SetBool("runrun", true);
                        D3.GetComponent<Animator>().speed = 1.0f;

                    }
                }));
                

                StartCoroutine(DelayMethod(0.5f, () =>
                {
                    if (flag == 3)
                    {

                        //if (gestureListener.IsRaiseLeftHand()||gestureListener.IsMoveLeft()){
                        text1.text = "";
                        //if(Input.GetKey(KeyCode.LeftArrow)){
                        //flag2 = 2;
                        O3.transform.rotation = Quaternion.Euler(0, 5, 0);
                        O3.GetComponent<Animator>().SetBool("runrun", true);
                        O3.GetComponent<Animator>().speed = 1.3f;
                        // ball.GetComponent<Rigidbody>().AddForce((new Vector3(po3.x, pb.y, po3.z + 2f) - pb) * 100);
                        iTween.MoveTo(ball, iTween.Hash("position", new Vector3(po3.x + 0f, pb.y, po3.z + 1f), "Time", 1f));

                        StartCoroutine(DelayMethod(0.5f, () =>
                        {
                            if (flag2 == 0)
                            {
                                D3.transform.rotation = Quaternion.Euler(0, 0, 0);
                                D3.GetComponent<Animator>().SetBool("runrun", true);
                                D3.GetComponent<Animator>().speed = 1.2f;
                            }
                        }));

                    }
                }));

                // }
               
            }));

        }*/

		/*----------------------------------------------------------------------------------*/

		if ((Mathf.Abs(pb.x-pd3.x) <= 0.5f) && (Mathf.Abs(pb.z-pd3.z) <= 0.5f)) {
			this.transform.position= pd3;
			Vector3 pospos = ball.transform.position;
			pospos.y = 1.4f;
			pospos.z = pd3.z-0.3f;
			ball.transform.position = pospos;

			this.GetComponent<Rigidbody>().velocity = Vector3.zero;
			//this.GetComponent<Rigidbody>().AddForce(Vector3.zero);
			//Debug.Log ("true");

			/*---shift relationship of parent and children from O1 to O3---*/
			//this.transform.parent = O1.transform;
			//this.transform.parent = null;
			ball.transform.parent = D3.transform;
		}


		if ((Mathf.Abs(pb.x-po3.x) <= 0.5f) && (Mathf.Abs(pb.z-po3.z) <= 0.5f)) {
			this.transform.position= po3;
			Vector3 pospos = this.transform.position;
			pospos.y = 1.4f;
			pospos.z = po3.z+0.3f;
			this.transform.position = pospos;

			this.GetComponent<Rigidbody>().velocity = Vector3.zero;
			//this.GetComponent<Rigidbody>().AddForce(Vector3.zero);
			//Debug.Log ("true");

			/*---shift relationship of parent and children from O1 to O3---*/
			//this.transform.parent = O1.transform;
		    this.transform.parent = null;
			ball.transform.parent = O3.transform;

		}

        /*---------------------------------------------------------------------------------*/


       // if (begin == 0){

            if (flag == 0 && po1.z >= 11f)
            {
                flag = 1;
                O1.transform.rotation = Quaternion.Euler(0, 90, 0);
                O1.GetComponent<Animator>().SetBool("runrun", false);
                D1.GetComponent<Animator>().SetBool("runrun", false);
            GameObject.Find("/Marker/circle3").GetComponent<Renderer>().enabled = true;
        }

            if (flag == 1 && po1.x <= -4.5f)
            {
                flag = 2;
                O1.GetComponent<Animator>().SetBool("runrun", false);
                D1.GetComponent<Animator>().SetBool("runrun", false);
                O1.transform.rotation = Quaternion.Euler(0, 140, 0);
                //			GameObject.Find("/Marker/circle2").GetComponent<Renderer>().enabled=false;
                //			iTween.MoveTo (ball, iTween.Hash ("position", new Vector3 (po1.x+0.5f, pb.y, po1.z - 0.6f), "Time", 2f));
            }

            if (flag == 2 && po3.x >= -1.5f)
            {
                flag = 3;
                O3.transform.rotation = Quaternion.Euler(0, 60, 0);
                O3.GetComponent<Animator>().SetBool("runrun", false);
                D3.GetComponent<Animator>().SetBool("runrun", false);
                //add_view();

                //			GameObject.Find("/Marker/circle").GetComponent<Renderer>().enabled=false;
                //			iTween.MoveTo (ball, iTween.Hash ("position", new Vector3 (po3.x + 0.3f, pb.y, po3.z + 0.4f), "Time", 2f));
            }

            if (flag == 3 && flag2 == 1 && po3.x >= 1f)
            {
                flag = 4;
                //O3.transform.rotation = Quaternion.Euler(0, 60, 0);
                O3.GetComponent<Animator>().SetBool("runrun", false);
                D3.GetComponent<Animator>().SetBool("runrun", false);
            }

            if (flag == 3 && flag2 == 0 && po3.z >= 10.5f)
            {
                flag = 4;
                O3.GetComponent<Animator>().SetBool("runrun", false);

            }
            if (flag == 4 && flag2 == 0 && pd3.z >= 9.5f)
            {
                flag2 = 1;
                D3.GetComponent<Animator>().SetBool("runrun", false);
            }

        //}

	}

	private IEnumerator DelayMethod(float time, Action action)
	{
		yield return new WaitForSeconds(time);
		action();
	}

//    void delete_view()
//    {
//            Destroy(GameObject.Find("Player3").GetComponent<AvatarController>());
//            GameObject.Find("Player3").GetComponent<Animator>().enabled = true;
//    }
//
//    void add_view()
//    {
//        GameObject.Find("Player3").AddComponent<AvatarController>();
//        GameObject.Find("Player3").GetComponent<AvatarController>().moveRate = 0;
//        //GameObject.Find("Player3").GetComponent<Animator>().enabled = false;
//    }

}
