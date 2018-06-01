using UnityEngine;
using System;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
//using Windows.Kinect;

public class player_move4_2 : MonoBehaviour
{

	/*---------------------Team Player-------------------*/
	public GameObject ball, O1, O2, O3;
	private int flag = 0, flag2 = 0;
	Vector3 po1, po2, po3, pb;

	/*-------------------Opponent Player-----------------*/
	public GameObject D1, D2, D3;
	private Vector3 pd1, pd2, pd3;

	public GUIText text1;
   // private PassingListener gestureListener;

    private Vector3 sd1, sd2, sd3, so1, so2, so3, sb;
    private Quaternion ro1, ro2, ro3, rd1, rd2, rd3;

    private AudioSource[] sources;
    private bool voice = false;

    // Use this for initialization
    void Start ()
	{
        text1.text = "[Point] : 動きに強弱をつける";
        //gestureListener = PassingListener.Instance;
        //delete_view();
        //GameObject.Find("KinectController").GetComponent<KinectManager>().StartKinect();
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
        //sources[0].Play();
        StartCoroutine(DelayMethod(0f, () =>
        {
            sources[0].Play();
        }));

        StartCoroutine(DelayMethod(12f, () =>
        {
            sources[1].Play();
        }));

    }

    

	// Update is called once per frame
	void Update ()
	{

		po1 = O1.transform.position;
		po2 = O2.transform.position;
		po3 = O3.transform.position;
		pd1 = D1.transform.position;
		pd2 = D2.transform.position;
		pd3 = D3.transform.position;
		pb = ball.transform.position;

        // if (!gestureListener)
        //return;

        StartCoroutine(DelayMethod(23f, () =>
        {
           SceneManager.LoadScene("3DLesson4");
        }));


        StartCoroutine (DelayMethod (3f, () => {
			//text1.text = "";
           // delete_view();
			if(flag<1){
				//text1.text = "そこで動きに強弱をつけると\nディフェンスは付いて行きづらい";
			}
			if (flag == 0) {
				iTween.MoveUpdate (ball, iTween.Hash ("position", new Vector3 (po3.x - 0.3f, pb.y, po3.z - 0.3f), "Time", 2f));
				O1.transform.rotation = Quaternion.Euler (0, -10, 0);
				O1.GetComponent<Animator> ().SetBool ("runrun", true);
                O1.GetComponent<Animator>().speed = 0.9f;
            }

			if (flag == 1) {
				O1.transform.rotation = Quaternion.Euler (0, 100, 0);
				O1.GetComponent<Animator> ().SetBool ("runrun", true);
                O1.GetComponent<Animator>().speed = 0.8f;
               // iTween.MoveTo(ball, iTween.Hash("position", new Vector3(po2.x, pb.y, po2.z + 0.3f), "Time", 2f));

            }

            if (flag>=1) {
               // text1.text = "具体的に言うと、<青矢印>までゆっくり動いて\nそこから<赤矢印>までを早くする、という具合に動きに緩急をつける";
                GameObject.Find("/Marker/RadarCursor_Blue/Cursor1").GetComponent<Renderer>().enabled = true;
                GameObject.Find("/Marker/RadarCursor_Blue/Cursor2").GetComponent<Renderer>().enabled = true;
                GameObject.Find("/Marker/RadarCursor_Blue/Cursor3").GetComponent<Renderer>().enabled = true;
                GameObject.Find("/Marker/RadarCursor_Red/Cursor1").GetComponent<Renderer>().enabled = true;
                GameObject.Find("/Marker/RadarCursor_Red/Cursor2").GetComponent<Renderer>().enabled = true;
                GameObject.Find("/Marker/RadarCursor_Red/Cursor3").GetComponent<Renderer>().enabled = true;
            }

			/*-------------カッティングに強弱をつける-------------*/

			StartCoroutine (DelayMethod (5f, () => {
                
                //flag2=1;
                Vector3 dir = po1 - pd1;
			if (flag == 2&& flag2==1) {
                   
                        iTween.MoveTo(ball, iTween.Hash("position", new Vector3(po2.x, pb.y, po2.z + 0.3f), "Time", 2f));
                        O1.transform.rotation = Quaternion.Euler(0, 190, 0);
                        O1.GetComponent<Animator>().SetBool("runrun", true);
                        O1.GetComponent<Animator>().speed = 0.8f;

                        D1.transform.rotation = Quaternion.Euler(0, 180, 0);
                        D1.GetComponent<Animator>().SetBool("runrun", true);
                        D1.GetComponent<Animator>().speed = 0.8f;

                    
                }

				if(flag==3){
                   
                        //ball.GetComponent<Rigidbody>().AddForce((new Vector3(po1.x+3f, pb.y, po1.z-1.5f) - pb) * 500);
                        O1.transform.rotation = Quaternion.Euler(0, 120, 0);
                        O1.GetComponent<Animator>().SetBool("runrun", true);
                        O1.GetComponent<Animator>().speed = 1.5f;
                       
                            D1.transform.rotation = Quaternion.Euler(0, 120, 0);
                            D1.GetComponent<Animator>().SetBool("runrun", true);
                            D1.GetComponent<Animator>().speed = 1.0f;
                        

                        
				}

				/*if(flag2==1){
                    if (gestureListener.IsMoveForward())
                    {
                        //					D1.transform.position = (D1.transform.position + (dir.normalized * 1 * Time.deltaTime));
                        //					D1.transform.LookAt (O1.transform);
                        D1.transform.rotation = Quaternion.Euler(0, 180, 0);
                        D1.GetComponent<Animator>().SetBool("runrun", true);
                        D1.GetComponent<Animator>().speed = 0.8f;
                    }
                }*/
					
			}));
			/*-------------カッティングに強弱をつける-------------*/
		




			StartCoroutine (DelayMethod (1.5f, () => {
				Vector3 dir = po1 - pd1;
				if (flag2 == 0) {
					D1.transform.position = (D1.transform.position + (dir.normalized * 1 * Time.deltaTime));
					D1.transform.LookAt (O1.transform);
					D1.GetComponent<Animator> ().SetBool ("runrun", true);

					if(flag2==1){
					}
				}
			}));


			StartCoroutine (DelayMethod (2f, () => {
				if (flag < 2) {
					O2.transform.rotation = Quaternion.Euler (0, -130, 0);
					O2.GetComponent<Animator> ().SetBool ("runrun", true);
					O2.GetComponent<Animator> ().speed = 1.2f;
					D2.transform.rotation = Quaternion.Euler (0, -130, 0);
					D2.GetComponent<Animator> ().SetBool ("runrun", true);
					D2.GetComponent<Animator> ().speed = 1.0f;

				}
			}));

		}));

        
		/*StartCoroutine (DelayMethod (10f, () => {
            //GameObject.Find("KinectController").GetComponent<KinectManager>().OnDestroy();
            SceneManager.LoadScene("3DLesson4-2");
		}));*/



		/*---------------------------------------------------------------------------------*/

		if ((Mathf.Abs (pb.x - po3.x) <= 0.5f) && (Mathf.Abs (pb.z - po3.z) <= 0.5f)) {
			this.transform.position = po3;
			Vector3 pospos = this.transform.position;
			pospos.y = 1.4f;
			pospos.z = po3.z + 0.3f;
			this.transform.position = pospos;

			//this.GetComponent<Rigidbody> ().velocity = Vector3.zero;
			//this.GetComponent<Rigidbody>().AddForce(Vector3.zero);
			//Debug.Log ("true");

			/*---shift relationship of parent and children from O1 to O3---*/
			//this.transform.parent = O1.transform;
			this.transform.parent = null;
			ball.transform.parent = O3.transform;
		}

		if ((Mathf.Abs (pb.x - po2.x) <= 0.5f) && (Mathf.Abs (pb.z - po2.z) <= 0.5f)) {
			this.transform.position = po2;
			Vector3 pospos = this.transform.position;
			pospos.y = 1.4f;
			pospos.z = po2.z + 0.3f;
			this.transform.position = pospos;

			//this.GetComponent<Rigidbody> ().velocity = Vector3.zero;
			//this.GetComponent<Rigidbody>().AddForce(Vector3.zero);
			//Debug.Log ("true");

			/*---shift relationship of parent and children from O1 to O3---*/
			//this.transform.parent = O1.transform;
			this.transform.parent = null;
			ball.transform.parent = O2.transform;
		}


		if ((Mathf.Abs (pb.x - po1.x) <= 0.5f) && (Mathf.Abs (pb.z - po1.z) <= 0.5f)) {
			this.transform.position = po1;
			Vector3 pospos = this.transform.position;
			pospos.y = 1.4f;
			pospos.z = po1.z +0.4f;
			this.transform.position = pospos;

			this.GetComponent<Rigidbody> ().velocity = Vector3.zero;
			//this.GetComponent<Rigidbody>().AddForce(Vector3.zero);
			//Debug.Log ("true");

			/*---shift relationship of parent and children from O1 to O3---*/
			//this.transform.parent = O1.transform;
			this.transform.parent = null;
			ball.transform.parent = O1.transform;

		}
	/*---------------------------------------------------------------------------------*/

		if (flag==0 && po1.z >= 11.5f) {
			flag = 1;
			O1.GetComponent<Animator> ().SetBool ("runrun", false);
			//D1.GetComponent<Animator> ().SetBool ("runrun", false);
		}

		if (flag==1 && po1.x >= 1.4f) {
			flag = 2;
			flag2 = 1;
            O1.transform.rotation = Quaternion.Euler(0, 180, 0);
            O1.GetComponent<Animator> ().SetBool ("runrun", false);
			D1.GetComponent<Animator> ().SetBool ("runrun", false);
		}

		if (flag==2 && po1.z <= 9.0f) {
			flag = 3;
			flag2 = 2;
			//O1.transform.rotation = Quaternion.Euler (0, -120, 0);
			O1.GetComponent<Animator> ().SetBool ("runrun", false);
			//D1.transform.rotation = Quaternion.Euler (0, 160, 0);
			D1.GetComponent<Animator> ().SetBool ("runrun", false);
		}

		if (flag == 3 && po1.x >= 4.5f) {
			flag = 4;
			O1.transform.rotation = Quaternion.Euler (0, -120, 0);
			O1.GetComponent<Animator> ().SetBool ("runrun", false);
            D1.GetComponent<Animator>().SetBool("runrun", false);
            iTween.MoveTo(ball, iTween.Hash("position", new Vector3(po1.x, pb.y, po1.z), "Time", 1.5f));
            
            }

        if (po2.x <= 0f) {
			//			flag = 2; flag2 = 1;
			O2.transform.rotation = Quaternion.Euler (0, 0, 0);
			O2.GetComponent<Animator> ().SetBool ("runrun", false);
			D2.GetComponent<Animator> ().SetBool ("runrun", false);
            //iTween.MoveTo(ball, iTween.Hash("position", new Vector3(po2.x, pb.y, po2.z + 0.3f), "Time", 2f));
        }

	/*---------------------------------------------------------------------------------*/


	}

	private IEnumerator DelayMethod (float time, Action action)
	{
		yield return new WaitForSeconds (time);
		action ();
	}

//    void delete_view()
//    {
//        Destroy(GameObject.Find("Player1").GetComponent<AvatarController>());
//        GameObject.Find("Player1").GetComponent<Animator>().enabled = true;
//    }
//
//    void add_view()
//    {
//        GameObject.Find("Player1").AddComponent<AvatarController>();
//        GameObject.Find("Player1").GetComponent<AvatarController>().moveRate = 0;
//        //GameObject.Find("Player1").GetComponent<Animator>().enabled = false;
//    }

}
