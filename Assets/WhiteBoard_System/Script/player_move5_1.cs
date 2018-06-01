using UnityEngine;
using System;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
//using Windows.Kinect;

public class player_move5_1 : MonoBehaviour
{

    /*---------------------Team Player-------------------*/
    public GameObject ball, O1, O2, O3;
    private int flag = 0, flag2 = 0, flag3 = 0,flag4=0;
    Vector3 po1, po2, po3, pb;

    /*-------------------Opponent Player-----------------*/
    public GameObject D1, D2, D3;
    private Vector3 pd1, pd2, pd3;

    public GUIText text1;
    //private PassingListener gestureListener;

    private Vector3 sd1, sd2, sd3, so1, so2, so3, sb;
    private Quaternion ro1, ro2, ro3, rd1, rd2, rd3;

    private AudioSource[] sources;
    private bool voice = false;

    // Use this for initialization
    void Start()
    {

        //gestureListener = PassingListener.Instance;
        //delete_view();
        //GameObject.Find("KinectController").GetComponent<KinectManager>().StartKinect();
        text1.text = "[Points!]\nパスしたら動くことと\n動きに強弱をつけること\nバックカットを意識してボールをもらおう！";
        sources = GameObject.Find("/AudioClipObject").GetComponents<AudioSource>();
        //sources[0].Play();
        StartCoroutine(DelayMethod(3f, () =>
        {
            sources[0].Play();
        }));
        StartCoroutine(DelayMethod(12f, () =>
        {
            sources[1].Play();
        }));
        StartCoroutine(DelayMethod(23f, () =>
        {
            sources[2].Play();
        }));

    }



    // Update is called once per frame
    void Update()
    {

        StartCoroutine(DelayMethod(33f, () =>
        {
            SceneManager.LoadScene("3DLesson5");
        }));

        po1 = O1.transform.position;
        po2 = O2.transform.position;
        po3 = O3.transform.position;
        pd1 = D1.transform.position;
        pd2 = D2.transform.position;
        pd3 = D3.transform.position;
        pb = ball.transform.position;

        //if (!gestureListener)
        //return;


        StartCoroutine(DelayMethod(3f, () =>
        {


            if (flag == 0)
            {
                iTween.MoveTo(ball, iTween.Hash("position", new Vector3(po3.x + 0f, pb.y, po3.z - 0.3f), "Time", 2f));
                O1.transform.rotation = Quaternion.Euler(0, -10, 0);


                O1.GetComponent<Animator>().SetBool("runrun", true);
                O1.GetComponent<Animator>().speed = 0.8f;

                StartCoroutine(DelayMethod(2.0f, () =>
                {
                    Vector3 dir = po1 - pd1;
                    if (flag2 == 0)
                    {
                        D1.transform.position = (D1.transform.position + (dir.normalized * 1 * Time.deltaTime));
                        D1.transform.LookAt(O1.transform);
                        D1.GetComponent<Animator>().SetBool("runrun", true);
                        D1.GetComponent<Animator>().speed = 0.8f;
                    }
                }));

            }

            if (flag == 1)
            {
                O1.transform.rotation = Quaternion.Euler(0, 100, 0);
                O1.GetComponent<Animator>().SetBool("runrun", true);
                O1.GetComponent<Animator>().speed = 0.7f;

                Vector3 dir = po1 - pd1;
                D1.transform.position = (D1.transform.position + (dir.normalized * 1 * Time.deltaTime));
                D1.transform.LookAt(O1.transform);
                D1.GetComponent<Animator>().SetBool("runrun", true);
                D1.GetComponent<Animator>().speed = 0.8f;
                // iTween.MoveTo(ball, iTween.Hash("position", new Vector3(po2.x, pb.y, po2.z + 0.3f), "Time", 2f));

            }


            if (flag == 2 && flag3 == 0)
            {


                O2.transform.rotation = Quaternion.Euler(0, -120, 0);
                O2.GetComponent<Animator>().SetBool("runrun", true);
                O2.GetComponent<Animator>().speed = 0.7f;
                D2.transform.rotation = Quaternion.Euler(0, -120, 0);
                D2.GetComponent<Animator>().SetBool("runrun", true);
                D2.GetComponent<Animator>().speed = 0.7f;

                GameObject.Find("Opponent_Player/Opponent_Player2/P-RadarCursor/Cursor1").GetComponent<Renderer>().enabled = true;
                GameObject.Find("Opponent_Player/Opponent_Player2/P-RadarCursor/Cursor2").GetComponent<Renderer>().enabled = true;
                GameObject.Find("Opponent_Player/Opponent_Player2/P-RadarCursor/Cursor3").GetComponent<Renderer>().enabled = true;
                //GameObject.Find("/Marker/circle").GetComponent<Renderer>().enabled = true;
                GameObject.Find("Opponent_Player/Opponent_Player2/Pcircle").GetComponent<Renderer>().enabled = true;

            }

            if (flag3 == 1)
            {


                O2.transform.rotation = Quaternion.Euler(0, 190, 0);
                D2.transform.rotation = Quaternion.Euler(0, 170, 0);

                O2.GetComponent<Animator>().SetBool("runrun", true);
                O2.GetComponent<Animator>().speed = 1f;
                D2.GetComponent<Animator>().SetBool("runrun", true);
                D2.GetComponent<Animator>().speed = 0.7f;

            }


            if (flag3 == 2 && flag == 2 && flag2 == 1)
            {
                O1.transform.rotation = Quaternion.Euler(0, 120, 0);
                O1.GetComponent<Animator>().SetBool("runrun", true);
                O1.GetComponent<Animator>().speed = 1.0f;
                D1.transform.rotation = Quaternion.Euler(0, 120, 0);
                D1.GetComponent<Animator>().SetBool("runrun", true);
                D1.GetComponent<Animator>().speed = 0.9f;
            }

            if (flag == 3 && flag2 == 2)
            {
                GameObject.Find("/Marker/circle").GetComponent<Renderer>().enabled = true;
            }


            StartCoroutine(DelayMethod(13f, () =>
            {
                if (flag == 3 && flag2 == 2)
            {
                
                O2.transform.rotation = Quaternion.Euler(0, 20, 0);
                O2.GetComponent<Animator>().SetBool("runrun", true);
                O2.GetComponent<Animator>().speed = 1f;
                D2.transform.rotation = Quaternion.Euler(0, 20, 0);
                D2.GetComponent<Animator>().SetBool("runrun", true);
                D2.GetComponent<Animator>().speed = 0.8f;
                //Vector3 dir = po2 - pd2;
                //D2.transform.position = (D2.transform.position + (dir.normalized * 1 * Time.deltaTime));
                //D2.transform.LookAt(O2.transform);
                //D2.GetComponent<Animator>().SetBool("runrun", true);

            }

            if (flag == 4)
            {
                O3.transform.rotation = Quaternion.Euler(0, 130, 0);
                O3.GetComponent<Animator>().SetBool("runrun", true);
                O3.GetComponent<Animator>().speed = 1.1f;
                D3.transform.rotation = Quaternion.Euler(0, 130, 0);
                D3.GetComponent<Animator>().SetBool("runrun", true);
                D3.GetComponent<Animator>().speed = 0.8f;
            }

                StartCoroutine(DelayMethod(10f, () =>
                {
                    if (flag == 5 && flag2 == 4)
                    {
                        //StartCoroutine(DelayMethod(1.0f, () =>{

                        O2.transform.rotation = Quaternion.Euler(0, 230, 0);
                        O2.GetComponent<Animator>().SetBool("runrun", true);
                        O2.GetComponent<Animator>().speed = 0.9f;
                        D2.transform.rotation = Quaternion.Euler(0, 230, 0);
                        D2.GetComponent<Animator>().SetBool("runrun", true);
                        D2.GetComponent<Animator>().speed = 0.9f;
                        GameObject.Find("Opponent_Player/Opponent_Player2/P-RadarCursor/Cursor1").GetComponent<Renderer>().enabled = true;
                        GameObject.Find("Opponent_Player/Opponent_Player2/P-RadarCursor/Cursor2").GetComponent<Renderer>().enabled = true;
                        GameObject.Find("Opponent_Player/Opponent_Player2/P-RadarCursor/Cursor3").GetComponent<Renderer>().enabled = true;
                        GameObject.Find("Opponent_Player/Opponent_Player2/Pcircle").GetComponent<Renderer>().enabled = true;

                        // }));
                    }

                    if (flag == 6 && flag2 == 5)
                    {
                       
                        StartCoroutine(DelayMethod(1.0f, () =>
                        {
                            GameObject.Find("Opponent_Player/Opponent_Player2/P-RadarCursor/Cursor1").GetComponent<Renderer>().enabled = false;
                            GameObject.Find("Opponent_Player/Opponent_Player2/P-RadarCursor/Cursor2").GetComponent<Renderer>().enabled = false;
                            GameObject.Find("Opponent_Player/Opponent_Player2/P-RadarCursor/Cursor3").GetComponent<Renderer>().enabled = false;
                            GameObject.Find("Opponent_Player/Opponent_Player2/Pcircle").GetComponent<Renderer>().enabled = false;

                            O2.transform.rotation = Quaternion.Euler(0, 50, 0);
                            O2.GetComponent<Animator>().SetBool("runrun", true);
                            O2.GetComponent<Animator>().speed = 1.1f;
                            iTween.MoveTo(ball, iTween.Hash("position", new Vector3(po2.x + 0.3f, pb.y, po2.z + 0.3f), "Time", 1f));
                            //D2.transform.rotation = Quaternion.Euler(0, 50, 0);
                            //D2.GetComponent<Animator>().SetBool("runrun", true);
                            //D2.GetComponent<Animator>().speed = 1.1f;
                            

                            if (flag2 == 5)
                            {
                                StartCoroutine(DelayMethod(0.2f, () =>
                                {
                                    D2.transform.rotation = Quaternion.Euler(0, 50, 0);
                                    D2.GetComponent<Animator>().SetBool("runrun", true);
                                    D2.GetComponent<Animator>().speed = 1.0f;

                                }));
                            }
                        }));
                    }
                }));
        }));

        }));


        /*StartCoroutine (DelayMethod (10f, () => {
            //GameObject.Find("KinectController").GetComponent<KinectManager>().OnDestroy();
            SceneManager.LoadScene("3DLesson4-2");
		}));*/



        /*---------------------------------------------------------------------------------*/

        if ((Mathf.Abs(pb.x - po3.x) <= 0.5f) && (Mathf.Abs(pb.z - po3.z) <= 0.5f))
        {
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

        if ((Mathf.Abs(pb.x - po2.x) <= 0.5f) && (Mathf.Abs(pb.z - po2.z) <= 0.5f))
        {
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


        if ((Mathf.Abs(pb.x - po1.x) <= 0.5f) && (Mathf.Abs(pb.z - po1.z) <= 0.5f))
        {
            this.transform.position = po1;
            Vector3 pospos = this.transform.position;
            pospos.y = 1.5f;
            pospos.z = po1.z - 0.2f;
            this.transform.position = pospos;

            this.GetComponent<Rigidbody>().velocity = Vector3.zero;
            //this.GetComponent<Rigidbody>().AddForce(Vector3.zero);
            //Debug.Log ("true");

            /*---shift relationship of parent and children from O1 to O3---*/
            //this.transform.parent = O1.transform;
            this.transform.parent = null;
            ball.transform.parent = O1.transform;

        }
        /*---------------------------------------------------------------------------------*/

        if (flag == 0 && po1.z >= 11.5f)
        {
            flag = 1;
            O1.GetComponent<Animator>().SetBool("runrun", false);
            //D1.GetComponent<Animator> ().SetBool ("runrun", false);
        }

        if (flag == 1 && po1.x >= 1.4f)
        {
            flag = 2;
            flag2 = 1;
            O1.transform.rotation = Quaternion.Euler(0, 180, 0);
            O1.GetComponent<Animator>().SetBool("runrun", false);
            D1.GetComponent<Animator>().SetBool("runrun", false);
        }

        if (flag3 == 0 && po2.x <= 1.0f)
        {
            flag3 = 1;
            GameObject.Find("Opponent_Player/Opponent_Player2/P-RadarCursor/Cursor1").GetComponent<Renderer>().enabled = false;
            GameObject.Find("Opponent_Player/Opponent_Player2/P-RadarCursor/Cursor2").GetComponent<Renderer>().enabled = false;
            GameObject.Find("Opponent_Player/Opponent_Player2/P-RadarCursor/Cursor3").GetComponent<Renderer>().enabled = false;
            

        }

        if (flag3 == 1 && po2.z <= 4f)
        {
            flag3 = 2;
            iTween.MoveTo(ball, iTween.Hash("position", new Vector3(po2.x + 0f, pb.y, po2.z - 0f), "Time", 2f));
            O2.transform.rotation = Quaternion.Euler(0, 0, 0);
            O2.GetComponent<Animator>().SetBool("runrun", false);
            D2.GetComponent<Animator>().SetBool("runrun", false);
            GameObject.Find("Opponent_Player/Opponent_Player2/Pcircle").GetComponent<Renderer>().enabled = false;
        }

        /*if (flag3 == 1 && po2.x <= -2.5f)
        {
           // iTween.MoveTo(ball, iTween.Hash("position", new Vector3(po3.x + 0f, pb.y, po3.z - 0.3f), "Time", 2f));
            flag3 = 10;
            O2.GetComponent<Animator>().SetBool("runrun", false);
            D2.GetComponent<Animator>().SetBool("runrun", false);
        }*/

        if (flag == 2 && po1.x >= 5.5f)
        {
            flag = 3;
            flag2 = 2;
            iTween.MoveTo(ball, iTween.Hash("position", new Vector3(po1.x, pb.y, po1.z + 0f), "Time", 1.5f));
            O1.transform.rotation = Quaternion.Euler (0, -120, 0);
            O1.GetComponent<Animator> ().SetBool ("runrun", false);
            D1.transform.rotation = Quaternion.Euler (0, 160, 0);
            D1.GetComponent<Animator> ().SetBool ("runrun", false);
        }

        if (flag == 3 && po2.z >= 12f)
        {
            flag = 4;flag2 = 3;
            O2.transform.rotation = Quaternion.Euler(0, -100, 0);
            D2.transform.rotation = Quaternion.Euler(0, -100, 0);
            GameObject.Find("/Marker/circle").GetComponent<Renderer>().enabled = false;
        }

        if (flag == 4 &&flag2==3&& po2.x <= -1.5f)
        {
            flag = 5; flag2 = 4;
            O2.transform.rotation = Quaternion.Euler(0, 190, 0);
            O2.GetComponent<Animator>().SetBool("runrun", false);
            D2.transform.rotation = Quaternion.Euler(0, 160, 0);
            D2.GetComponent<Animator>().SetBool("runrun", false);
        }

        if ((flag4==0)&& po3.x >= 0.5f)
        {
            iTween.MoveTo(ball, iTween.Hash("position", new Vector3(po3.x, pb.y, po3.z + 0f), "Time", 1.5f));
            O3.transform.rotation = Quaternion.Euler(0, -15, 0);
            O3.GetComponent<Animator>().SetBool("runrun", false);
            D3.transform.rotation = Quaternion.Euler(0, 170, 0);
            D3.GetComponent<Animator>().SetBool("runrun", false);
            flag4 = 1;
            GameObject.Find("/Marker/circle2").GetComponent<Renderer>().enabled = true;
        }

        if (flag == 5&&flag2==4&&po2.x<=-3.5f)
        {
            flag = 6; flag2 = 5;
            GameObject.Find("/Marker/circle2").GetComponent<Renderer>().enabled = false;
            GameObject.Find("/Marker/circle3").GetComponent<Renderer>().enabled = true;
        }

        if (flag4==1&&po2.x >= -1.5f)
        {
            flag = 7; flag2 = 6;
           // iTween.MoveTo(ball, iTween.Hash("position", new Vector3(po2.x + 0f, pb.y, po2.z + 0f), "Time", 1f));
            //O2.transform.rotation = Quaternion.Euler(0, 50, 0);
            O2.GetComponent<Animator>().SetBool("runrun", false);
            //D2.transform.rotation = Quaternion.Euler(0, 50, 0);
            D2.GetComponent<Animator>().SetBool("runrun", false);
            GameObject.Find("/Marker/circle3").GetComponent<Renderer>().enabled = false;
            GameObject.Find("Opponent_Player/Opponent_Player2/P-RadarCursor/Cursor1").GetComponent<Renderer>().enabled = false;
            GameObject.Find("Opponent_Player/Opponent_Player2/P-RadarCursor/Cursor2").GetComponent<Renderer>().enabled = false;
            GameObject.Find("Opponent_Player/Opponent_Player2/P-RadarCursor/Cursor3").GetComponent<Renderer>().enabled = false;
        }
        

       /* if (flag3 == 1 && po3.z >= 10f)
        {
            flag3 = 2;
            O3.GetComponent<Animator>().SetBool("runrun", false);
            D3.GetComponent<Animator>().SetBool("runrun", false);
        }*/

        /*---------------------------------------------------------------------------------*/


    }

    private IEnumerator DelayMethod(float time, Action action)
    {
        yield return new WaitForSeconds(time);
        action();
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
