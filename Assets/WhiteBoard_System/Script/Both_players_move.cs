using UnityEngine;
using System;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Both_players_move : MonoBehaviour {

	/*---------------------Team Player-------------------*/
	public GameObject ball, O1, O2, O3;
	public int flag = 0, flag2=0;
	Vector3 po1, po2, po3,pb;

	/*-------------------Opponent Player-----------------*/
	public GameObject D1, D2, D3;
	private Vector3 pd1, pd2, pd3;

    
	[SerializeField]
	AnimationCurve anim;

    // Use this for initialization
    void Start () {
        

    }
	
	// Update is called once per frame
	void Update () {

		po1 = O1.transform.position;
		po2 = O2.transform.position;
		po3 = O3.transform.position;
		pd1 = D1.transform.position;
		pd2 = D2.transform.position;
		pd3 = D3.transform.position;
		pb = ball.transform.position;


			if(flag==0){
			iTween.MoveTo (ball, iTween.Hash ("position", new Vector3 (po2.x - 0.3f, pb.y, po2.z - 0.3f), "Time", 2f));
			
			} 

			StartCoroutine (DelayMethod (1f, () => {
				if(flag==0){
				//O1.transform.rotation = Quaternion.Euler(0, 10, 0);
				O1.GetComponent<Animator>().SetBool("runrun", true);
				O1.transform.position += new Vector3(1.2f, O1.transform.position.y, 1.5f)*0.001f;
				}
		/*--------------------------------------------------------------------------------*/
				StartCoroutine (DelayMethod (5f, () => {
					//flag=1;
					if(flag2==0){
						D1.transform.rotation = Quaternion.Euler(0, 15, 0);
						D1.GetComponent<Animator>().SetBool("runrun", true);
					}
						
				}));

		/*--------------------------------------------------------------------------------*/
				StartCoroutine (DelayMethod (10f, () => {
					//flag=2;
					Debug.Log(flag);
					if(flag==1){

					}
				}));

				StartCoroutine(DelayMethod(15f,() => {
					if(flag==1){
						O3.transform.rotation = Quaternion.Euler(0, 130, 0);
						O3.GetComponent<Animator>().SetBool("runrun", true);
						O3.GetComponent<Animator> ().speed = 1.3f;
						D3.transform.rotation = Quaternion.Euler(0, 140, 0);
						D3.GetComponent<Animator>().SetBool("runrun", true);
						D3.GetComponent<Animator> ().speed = 1f;
					}
				}));
		/*--------------------------------------------------------------------------------*/

				StartCoroutine (DelayMethod (20f, () => {
					
					if(flag==2){

					}
				}));

				StartCoroutine (DelayMethod (25f, () => {
				if(flag==2&&flag2==1){
				//O1.transform.Rotate(0, -3f, 0);
				O1.transform.rotation = Quaternion.Euler(0, 260, 0);
				O1.GetComponent<Animator>().SetBool("runrun", true);
				//O1.GetComponent<Animator> ().speed = 1.3f;
				O1.transform.position += new Vector3(-6.1f, O1.transform.position.y, 0.3f)*0.001f;
				D1.transform.rotation = Quaternion.Euler(0, 260, 0);
				D1.GetComponent<Animator>().SetBool("runrun", true);
				D1.GetComponent<Animator> ().speed = 1.1f;
					}
				}));
		/*--------------------------------------------------------------------------------*/
				StartCoroutine (DelayMethod (30f, () => {
					if(flag==3){
						
                    }
				}));

				StartCoroutine (DelayMethod (35f, () => {
					if(flag==3){
						O3.transform.rotation = Quaternion.Euler(0, -10, 0);
						O3.GetComponent<Animator>().SetBool("runrun", true);
						O3.GetComponent<Animator> ().speed = 1.3f;

					}
				}));

				StartCoroutine (DelayMethod (35.5f, () => {
					if(flag==3){
					D3.transform.rotation = Quaternion.Euler(0, -10, 0);
					D3.GetComponent<Animator>().SetBool("runrun", true);
					D3.GetComponent<Animator> ().speed = 1.1f;
					}
				}));
		/*--------------------------------------------------------------------------------*/
				StartCoroutine (DelayMethod (40.5f, () => {
					if(flag==4){
						
                    }
				}));

				StartCoroutine (DelayMethod (45.5f, () => {
					
					if(flag==4){
						//text1.text="そうするとはじめてスペースが空くので\nそのスペースにボールをもらいに行って\nスペースを埋める";
						//GameObject.Find("/Marker/circle").GetComponent<Renderer>().enabled=true;
						O2.transform.rotation = Quaternion.Euler(0, -125, 0);
						O2.GetComponent<Animator>().SetBool("runrun", true);
						O2.GetComponent<Animator> ().speed = 1.3f;
						D2.transform.rotation = Quaternion.Euler(0, -120, 0);
						D2.GetComponent<Animator>().SetBool("runrun", true);
						D2.GetComponent<Animator> ().speed = 1f;
					}
				}));
			/*--------------------------------------------------------------------------------*/
				StartCoroutine (DelayMethod (50.5f, () => {
					if(flag==5){
						
                    }
				}));

				StartCoroutine (DelayMethod (55.5f, () => {

					if(flag==5){
						//text1.text="そうするとはじめてスペースが空くので\nそのスペースにボールをもらいに行って\nスペースを埋める";
						//GameObject.Find("/Marker/circle").GetComponent<Renderer>().enabled=true;
						O3.transform.rotation = Quaternion.Euler(0, 115, 0);
						O3.GetComponent<Animator>().SetBool("runrun", true);
						O3.GetComponent<Animator> ().speed = 1.3f;
						D3.transform.rotation = Quaternion.Euler(0, 110, 0);
						D3.GetComponent<Animator>().SetBool("runrun", true);
						D3.GetComponent<Animator> ().speed = 1.0f;
					}
				}));
                /*--------------------------------------------------------------------------------*/

            }));

		






		if(flag==0&&po1.z >= 11f) {
			flag=1;
			//O1.transform.rotation = Quaternion.Euler(0, 90, 0);
			O1.GetComponent<Animator>().SetBool("runrun", false);
		}

		if(flag2==0&&pd1.z>=10.3f){
			flag2=1;
			D1.GetComponent<Animator>().SetBool("runrun", false);
		}

		if (flag==1&&po3.x >= 0) {
			flag = 2;
			O3.transform.rotation = Quaternion.Euler(0, 30, 0);
			O3.GetComponent<Animator> ().SetBool ("runrun", false);
			D3.GetComponent<Animator> ().SetBool ("runrun", false);
			iTween.MoveTo (ball, iTween.Hash ("position", new Vector3 (po3.x + 0.3f, pb.y, po3.z + 0.4f), "Time", 2f));
        }

		if (flag==2&&flag2==1&&po1.x <= -4.5f) {
			//flag = 4;
			O1.GetComponent<Animator>().SetBool("runrun", false);
			
			O1.transform.rotation = Quaternion.Euler(0, 140, 0);
            O3.transform.rotation = Quaternion.Euler(0, -40, 0);
            flag = 3;
            D1.GetComponent<Animator>().SetBool("runrun", false);
            iTween.MoveTo (ball, iTween.Hash ("position", new Vector3 (po1.x+0.5f, pb.y, po1.z - 0.6f), "Time", 2f));
		}

      
		if(flag==3&&po3.z >= 11f) {
			flag=4;
			//O1.transform.rotation = Quaternion.Euler(0, 90, 0);
			O3.GetComponent<Animator>().SetBool("runrun", false);
			D3.GetComponent<Animator>().SetBool("runrun", false);
			O3.transform.rotation = Quaternion.Euler(0, -120, 0);
            iTween.MoveTo (ball, iTween.Hash ("position", new Vector3 (po3.x-0.5f, pb.y, po3.z-0.3f), "Time", 2f));
		}

		if (flag == 4 && po2.x <= 0) {
			flag = 5;
			O2.GetComponent<Animator>().SetBool("runrun", false);
			D2.GetComponent<Animator>().SetBool("runrun", false);
			O2.transform.rotation = Quaternion.Euler(0, 0, 0);
            iTween.MoveTo (ball, iTween.Hash ("position", new Vector3 (po2.x-0.2f, pb.y, po2.z + 0.3f), "Time", 2f));
		}

		if (flag == 5 && po3.x >= 4.3f) {
			flag = 6;
			O3.GetComponent<Animator>().SetBool("runrun", false);
			D3.GetComponent<Animator>().SetBool("runrun", false);
			O3.transform.rotation = Quaternion.Euler(0, -120, 0);

        }
	
	}



	private IEnumerator DelayMethod(float time, Action action)
	{
		yield return new WaitForSeconds(time);
		action();
	}

	private IEnumerator DelayMethod2(float time2, Action action)
	{
		yield return new WaitForSeconds(time2);
		action();
	}

}

