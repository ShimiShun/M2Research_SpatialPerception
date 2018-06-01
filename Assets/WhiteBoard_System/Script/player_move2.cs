using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class player_move2 : MonoBehaviour
{

    //GameObject obj;
    //public GameObject sphere,goal;
    public GameObject ball, O1, O2, O3,body;
    public int flag = 0, flag2=0;
    Vector3 po1, po2, po3,pb;


    // Use this for initialization
    void Start()
    {
        //animate = GetComponent<Animator>();
        //obj = GameObject.Find("Basketball_ps");
        //print(Flag);
    }

    // Update is called once per frame
    void Update()
    {

        po1 = O1.transform.position;
        po2 = O2.transform.position;
        po3 = O3.transform.position;
        pb = ball.transform.position;


		//O3.transform.LookAt (pb-po3);  


            StartCoroutine(DelayMethod(2f, () =>
        {
            iTween.MoveTo(ball, iTween.Hash("position", new Vector3(po2.x - 0.3f, pb.y, po2.z - 0.3f), "Time", 2f));
            if (flag == 0)
            {
                O1.transform.rotation = Quaternion.Euler(0, 30, 0);
                O1.transform.Translate(0.01f, 0f, 0.04f);
                O1.GetComponent<Animator>().SetBool("runrun", true);
            }

            if (po1.x >= 2f)
            {
                flag=1;
                O1.transform.Translate(0, 0, 0);
            }

            if (flag == 1)
				{ 
					//O1.transform.rotation = Quaternion.Euler(0, 330, 0);
				O1.transform.Rotate(0, -3, 0);
               // O1.transform.Translate(0.03f, 0f, 0.05f);
                O1.GetComponent<Animator>().SetBool("runrun", true);
            }

            if (po1.x <= -2.5f)
            {
                flag=2;
                O1.transform.Translate(Vector3.zero);
                O1.GetComponent<Animator>().SetBool("runrun", false);
            }
        }));
       

        StartCoroutine(DelayMethod2(3,() =>
			{
			  
            if (flag2 == 0)
            {
				//body.transform.LookAt (pb-body.transform.position);
                O3.transform.rotation = Quaternion.Euler(0, 120, 0);
               // O3.transform.Translate(0.03f, 0f, 0.03f);
                O3.GetComponent<Animator>().SetBool("runrun", true);
            }

            if (po3.x >= -0.2f)
            {
                flag2=1;
               // O3.transform.Translate(0, 0, 0);
                //Debug.Log(po3.x);
            }

           
            if (flag2 == 1)
            {
					//body.transform.LookAt (pb-body.transform.position);
					O3.transform.rotation = Quaternion.Euler(0, 0, 0);
					O3.transform.Translate(0f, 0f, 0.2f);
				//iTween.RotateTo(body, iTween.Hash("y", 0,"time", 0.2f));
				//O3.transform.LookAt (pb-po3);              
                //O3.GetComponent<Animator>().SetBool("runrun", true);
				//iTween.MoveTo(ball, iTween.Hash("position", po3, "Time", 0.5f));
					//ball.GetComponent<Rigidbody>().AddForce((new Vector3(po3.x,pb.y,po3.z+1.0f))*500);

            }

           

            if (po3.z >= 11.5f)
            {
                flag2 = 2;
                Debug.Log(po3.z);
               
            }

             if (flag2 == 2)
                        {
                Vector3 pos = O3.transform.position;
                pos.z = 11.5f;
                O3.transform.position = pos;
                O3.GetComponent<Animator>().SetBool("runrun", false);
                O3.transform.Translate(0, 0, 0);
            }
        }));

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