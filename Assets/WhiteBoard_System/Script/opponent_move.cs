using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class opponent_move : MonoBehaviour
{

	public GameObject sphere;
    public GameObject D1, D2, D3;
    private Vector3 pd1, pd2, pd3;

    int flag=0;

    // Use this for initialization
    void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
        pd1 = D1.transform.position;
  		pd2 = D2.transform.position;
        pd3 = D3.transform.position;

        //transform.LookAt( new Vector3( sphere.transform.position.x, transform.position.y, sphere.transform.position.z)  );

        StartCoroutine(DelayMethod(21f, () =>
        {

            if (flag == 0)
            {
                transform.rotation = Quaternion.Euler(0, 200, 0);
               // D3.transform.Translate(0.045f, 0f, 0.045f);
                GetComponent<Animator>().SetBool("runrun", true);
            }

            if (flag == 1)
            {
                transform.rotation = Quaternion.Euler(0, 30, 0);
               // D3.transform.Translate(0.04f, 0f, 0.04f);
                //GetComponent<Animator>().SetBool("runout", false);
                GetComponent<Animator>().SetBool("runrun", true);
            }

            if (pd3.x <= -4.5f)
            {
                flag = 1;
                GetComponent<Animator>().SetBool("runrun", true);
                D3.GetComponent<Animator>().speed = 1.2f;
            }
            if (pd3.x >= -2.0f)
            {
                flag = 2;
                GetComponent<Animator>().SetBool("runrun", false);
            }

      

           
           

        }));
    }

    private IEnumerator DelayMethod(float waittime, Action action)
    {
        yield return new WaitForSeconds(waittime);
        action();
    }

}

