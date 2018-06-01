using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class opponent_move2 : MonoBehaviour
{

	public GameObject sphere;
	public GameObject D1, D2, D3, O1, O3;
	private Vector3 pd1, pd2, pd3, po1,po3;

	int flag = 0, flag2 = 0;

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
		po1 = O1.transform.position;
		po3 = O3.transform.position;


		//transform.LookAt( new Vector3( sphere.transform.position.x, transform.position.y, sphere.transform.position.z)  );

		StartCoroutine (DelayMethod (2f, () => {

			Vector3 dir=po1-pd1;

			if (flag == 0) {
				D1.transform.position=(D1.transform.position+(dir.normalized*1*Time.deltaTime));
				D1.transform.LookAt(O1.transform);
				D1.GetComponent<Animator>().SetBool("runrun", true);

				if(pd1.x<=-2.5f){
					flag=1;
					D1.GetComponent<Animator>().SetBool("runrun", false);
				}
			}

		}));

		StartCoroutine (DelayMethod (3f, () => {
			if (flag2 == 0)
			{
				D3.transform.rotation = Quaternion.Euler(0, 135, 0);
				D3.transform.Translate(0.02f, 0f, 0.05f);
				D3.GetComponent<Animator>().SetBool("runrun", true);
			}

			if (pd3.x >= 0.1f)
			{
				flag2=1;
				D3.transform.Translate(0, 0, 0);
				D3.GetComponent<Animator>().SetBool("runrun", false);
			}

			StartCoroutine (DelayMethod (2.5f, () => {
				

				if(flag2==1){
				D3.GetComponent<Animator>().SetBool("runrun", true);		
				D3.transform.rotation = Quaternion.Euler(0, 0, 0);
				D3.transform.Translate(0f, 0f, 0.25f);
						
				}

			if (pd3.z >= 10.5f)
			{
				flag2 = 2;
			}

			if (flag2 == 2)
			{
				Vector3 pos = D3.transform.position;
				pos.z = 10.5f;
				D3.transform.position = pos;
				D3.GetComponent<Animator>().SetBool("runrun", false);
				D3.transform.Translate(0, 0, 0);
			}
			}));
		}));
	}

	private IEnumerator DelayMethod (float waittime, Action action)
	{
		yield return new WaitForSeconds (waittime);
		action ();
	}

   

}

