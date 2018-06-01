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
	public GUIText text1;

    /*---------------audio clip--------------------------*/
    /*private AudioSource audioSource;    // AudioSorceコンポーネント格納用
    public AudioClip sound1;        // 効果音の格納用。インスペクタで。
    public AudioClip sound2;        // 効果音の格納用。インスペクタで。
    public AudioClip sound3;        // 効果音の格納用。インスペクタで。
    public AudioClip sound4;
    public AudioClip sound5;*/
    private AudioSource[] sources;

    // Use this for initialization
    void Start () {
        text1.text = "[パス＆ランのポイント]\n・ボールをもらう選手の動き方\n・パスしたプレーヤーは動く\n・空いているスペースをうまく使う";
        sources = GameObject.Find("/AudioClipObject").GetComponents<AudioSource>();
        sources[0].Play();
        StartCoroutine(DelayMethod(10f, () =>
        {
            sources[1].Play();
        }));
        StartCoroutine(DelayMethod(15f, () =>
        {
            sources[2].Play();
        }));
        StartCoroutine(DelayMethod(20f, () =>
        {
            sources[3].Play();
        }));
        StartCoroutine(DelayMethod(30f, () =>
        {
            sources[4].Play();
        }));
        StartCoroutine(DelayMethod(40f, () =>
        {
            sources[5].Play();
        }));
        StartCoroutine(DelayMethod(50f, () =>
        {
            sources[6].Play();
        }));

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

		StartCoroutine (DelayMethod (5f, () => {
			if(flag==0){
			iTween.MoveTo (ball, iTween.Hash ("position", new Vector3 (po2.x - 0.3f, pb.y, po2.z - 0.3f), "Time", 2f));
			//text1.text="基本はディフェンスの前を通ってゴールに向かって動きます";
			} 
//				else if(flag==1){
//				text1.text="ディフェンスは点を取られたくないので\nそこを守ろうとします";
//			} else if(flag==2){
//				text1.text="そうするとはじめてスペースが空くので";
//			}

			StartCoroutine (DelayMethod (5f, () => {
				if(flag==0){
				O1.transform.rotation = Quaternion.Euler(0, 10, 0);
				O1.GetComponent<Animator>().SetBool("runrun", true);
				}
		/*--------------------------------------------------------------------------------*/
				StartCoroutine (DelayMethod (5f, () => {
					//flag=1;
					if(flag2==0){
						//text1.text="ディフェンスは点を取られたくないので\nそこを守ろうとします";
						D1.transform.rotation = Quaternion.Euler(0, 15, 0);
						D1.GetComponent<Animator>().SetBool("runrun", true);
					}
						
				}));

		/*--------------------------------------------------------------------------------*/
				StartCoroutine (DelayMethod (10f, () => {
					//flag=2;
					Debug.Log(flag);
					if(flag==1){
						//text1.text="そうするとはじめてスペースが空くので\nそのスペースにボールをもらいに行って\nスペースを埋める";
						GameObject.Find("/Marker/circle").GetComponent<Renderer>().enabled=true;
                        GameObject.Find("/Marker/RadarCursor1/Cursor1").GetComponent<Renderer>().enabled = true;
                        GameObject.Find("/Marker/RadarCursor1/Cursor2").GetComponent<Renderer>().enabled = true;
                        GameObject.Find("/Marker/RadarCursor1/Cursor3").GetComponent<Renderer>().enabled = true;

                        GameObject.Find("/Player/Player3/Pcircle").GetComponent<Renderer>().enabled = true;

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
						//text1.text="すると今度は別の場所が空くので\nその空いたスペースに別の選手が\nボールをもらいに行く";
						GameObject.Find("/Marker/circle2").GetComponent<Renderer>().enabled=true;
                        GameObject.Find("/Marker/RadarCursor2/Cursor1").GetComponent<Renderer>().enabled = true;
                        GameObject.Find("/Marker/RadarCursor2/Cursor2").GetComponent<Renderer>().enabled = true;
                        GameObject.Find("/Marker/RadarCursor2/Cursor3").GetComponent<Renderer>().enabled = true;

                        GameObject.Find("/Player/Player1/Pcircle").GetComponent<Renderer>().enabled = true;
                    }
				}));

				StartCoroutine (DelayMethod (25f, () => {
				if(flag==2&&flag2==1){
				//O1.transform.Rotate(0, -3f, 0);
				O1.transform.rotation = Quaternion.Euler(0, 260, 0);
				O1.GetComponent<Animator>().SetBool("runrun", true);
				O1.GetComponent<Animator> ().speed = 1.3f;
				D1.transform.rotation = Quaternion.Euler(0, 260, 0);
				D1.GetComponent<Animator>().SetBool("runrun", true);
				D1.GetComponent<Animator> ().speed = 1.1f;
					}
				}));
		/*--------------------------------------------------------------------------------*/
				StartCoroutine (DelayMethod (30f, () => {
					if(flag==3){
						GameObject.Find("/Marker/circle3").GetComponent<Renderer>().enabled=true;
                        GameObject.Find("/Marker/RadarCursor3/Cursor1").GetComponent<Renderer>().enabled = true;
                        GameObject.Find("/Marker/RadarCursor3/Cursor2").GetComponent<Renderer>().enabled = true;
                        GameObject.Find("/Marker/RadarCursor3/Cursor3").GetComponent<Renderer>().enabled = true;

                        GameObject.Find("/Player/Player3/Pcircle").GetComponent<Renderer>().enabled = true;
                    }
				}));

				StartCoroutine (DelayMethod (35f, () => {
					if(flag==3){
						//text1.text="これらの繰り返し！";
						//GameObject.Find("/Marker/circle").GetComponent<Renderer>().enabled=true;
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
						GameObject.Find("/Marker/circle4").GetComponent<Renderer>().enabled=true;
                        GameObject.Find("/Marker/RadarCursor4/Cursor1").GetComponent<Renderer>().enabled = true;
                        GameObject.Find("/Marker/RadarCursor4/Cursor2").GetComponent<Renderer>().enabled = true;
                        GameObject.Find("/Marker/RadarCursor4/Cursor3").GetComponent<Renderer>().enabled = true;

                        GameObject.Find("/Player/Player2/Pcircle").GetComponent<Renderer>().enabled = true;
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
						GameObject.Find("/Marker/circle5").GetComponent<Renderer>().enabled=true;
                        GameObject.Find("/Marker/RadarCursor5/Cursor1").GetComponent<Renderer>().enabled = true;
                        GameObject.Find("/Marker/RadarCursor5/Cursor2").GetComponent<Renderer>().enabled = true;
                        GameObject.Find("/Marker/RadarCursor5/Cursor3").GetComponent<Renderer>().enabled = true;

                        GameObject.Find("/Player/Player3/Pcircle").GetComponent<Renderer>().enabled = true;
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

                StartCoroutine(DelayMethod(58.5f, () => {

                    if (flag == 6)
                    {
                       // text1.text="これを繰り返す中でシュートが打てそうであれば\n積極的にシュートを狙っていく";
                       
                    }
                }));
                /*--------------------------------------------------------------------------------*/

            }));

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
			GameObject.Find("/Marker/circle").GetComponent<Renderer>().enabled=false;
			iTween.MoveTo (ball, iTween.Hash ("position", new Vector3 (po3.x + 0.3f, pb.y, po3.z + 0.4f), "Time", 2f));

            GameObject.Find("/Marker/RadarCursor1/Cursor1").GetComponent<Renderer>().enabled = false;
            GameObject.Find("/Marker/RadarCursor1/Cursor2").GetComponent<Renderer>().enabled = false;
            GameObject.Find("/Marker/RadarCursor1/Cursor3").GetComponent<Renderer>().enabled = false;
            GameObject.Find("/Player/Player3/Pcircle").GetComponent<Renderer>().enabled = false;
        }

		if (flag==2&&flag2==1&&po1.x <= -4.5f) {
			//flag = 4;
			O1.GetComponent<Animator>().SetBool("runrun", false);
			
			O1.transform.rotation = Quaternion.Euler(0, 140, 0);
			GameObject.Find("/Marker/circle2").GetComponent<Renderer>().enabled=false;
            O3.transform.rotation = Quaternion.Euler(0, -40, 0);
            flag = 3;
            D1.GetComponent<Animator>().SetBool("runrun", false);
            GameObject.Find("/Marker/RadarCursor2/Cursor1").GetComponent<Renderer>().enabled = false;
            GameObject.Find("/Marker/RadarCursor2/Cursor2").GetComponent<Renderer>().enabled = false;
            GameObject.Find("/Marker/RadarCursor2/Cursor3").GetComponent<Renderer>().enabled = false;
            GameObject.Find("/Player/Player1/Pcircle").GetComponent<Renderer>().enabled = false;
            iTween.MoveTo (ball, iTween.Hash ("position", new Vector3 (po1.x+0.5f, pb.y, po1.z - 0.6f), "Time", 2f));
		}

       /* if (flag == 3 && pd1.x <= -3.5f)
        {
            flag = 4;
            D1.GetComponent<Animator>().SetBool("runrun", false);
            GameObject.Find("/Marker/RadarCursor2/Cursor1").GetComponent<Renderer>().enabled = false;
            GameObject.Find("/Marker/RadarCursor2/Cursor2").GetComponent<Renderer>().enabled = false;
            GameObject.Find("/Marker/RadarCursor2/Cursor3").GetComponent<Renderer>().enabled = false;
        }*/

		if(flag==3&&po3.z >= 11f) {
			flag=4;
			//O1.transform.rotation = Quaternion.Euler(0, 90, 0);
			O3.GetComponent<Animator>().SetBool("runrun", false);
			D3.GetComponent<Animator>().SetBool("runrun", false);
			O3.transform.rotation = Quaternion.Euler(0, -120, 0);
			GameObject.Find("/Marker/circle3").GetComponent<Renderer>().enabled=false;
            GameObject.Find("/Marker/RadarCursor3/Cursor1").GetComponent<Renderer>().enabled = false;
            GameObject.Find("/Marker/RadarCursor3/Cursor2").GetComponent<Renderer>().enabled = false;
            GameObject.Find("/Marker/RadarCursor3/Cursor3").GetComponent<Renderer>().enabled = false;
            GameObject.Find("/Player/Player3/Pcircle").GetComponent<Renderer>().enabled = false;
            iTween.MoveTo (ball, iTween.Hash ("position", new Vector3 (po3.x-0.5f, pb.y, po3.z-0.3f), "Time", 2f));
		}

		if (flag == 4 && po2.x <= 0) {
			flag = 5;
			O2.GetComponent<Animator>().SetBool("runrun", false);
			D2.GetComponent<Animator>().SetBool("runrun", false);
			O2.transform.rotation = Quaternion.Euler(0, 0, 0);
			GameObject.Find("/Marker/circle4").GetComponent<Renderer>().enabled=false;
            GameObject.Find("/Marker/RadarCursor4/Cursor1").GetComponent<Renderer>().enabled = false;
            GameObject.Find("/Marker/RadarCursor4/Cursor2").GetComponent<Renderer>().enabled = false;
            GameObject.Find("/Marker/RadarCursor4/Cursor3").GetComponent<Renderer>().enabled = false;
            GameObject.Find("/Player/Player2/Pcircle").GetComponent<Renderer>().enabled = false;
            iTween.MoveTo (ball, iTween.Hash ("position", new Vector3 (po2.x-0.2f, pb.y, po2.z + 0.3f), "Time", 2f));
		}

		if (flag == 5 && po3.x >= 4.3f) {
			flag = 6;
			O3.GetComponent<Animator>().SetBool("runrun", false);
			D3.GetComponent<Animator>().SetBool("runrun", false);
			O3.transform.rotation = Quaternion.Euler(0, -120, 0);
			GameObject.Find("/Marker/circle5").GetComponent<Renderer>().enabled=false;
            GameObject.Find("/Marker/RadarCursor5/Cursor1").GetComponent<Renderer>().enabled = false;
            GameObject.Find("/Marker/RadarCursor5/Cursor2").GetComponent<Renderer>().enabled = false;
            GameObject.Find("/Marker/RadarCursor5/Cursor3").GetComponent<Renderer>().enabled = false;
            GameObject.Find("/Player/Player3/Pcircle").GetComponent<Renderer>().enabled = false;
            //			iTween.MoveTo (ball, iTween.Hash ("position", new Vector3 (po2.x-0.2f, pb.y, po2.z + 0.3f), "Time", 2f));
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

