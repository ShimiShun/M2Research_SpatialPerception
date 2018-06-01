using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class player_move : MonoBehaviour
{
	
	GameObject obj;
    //public GameObject sphere,goal;
    public int speed = 100;
    public GameObject ball, O1, O2, O3;
	bool run = false;
    int flag = 0;
    Vector3 po1, po2, po3;
    public GUIText text1;

    private AudioSource audioSource;    // AudioSorceコンポーネント格納用
    public AudioClip sound1;        // 効果音の格納用。インスペクタで。
    public AudioClip sound2;        // 効果音の格納用。インスペクタで。
    public AudioClip sound3;        // 効果音の格納用。インスペクタで。

    // Use this for initialization
    void Start ()
	{
        audioSource = GameObject.Find("/AudioClipObject").GetComponent<AudioSource>();
        //audioSource.clip = sound2;
        //audioSource.Play();

        StartCoroutine(DelayMethod(3f, () =>
        {
            audioSource.PlayOneShot(sound1);
        }));
        StartCoroutine(DelayMethod(10f, () =>
        {
            audioSource.PlayOneShot(sound2);
        }));
        StartCoroutine(DelayMethod(18f, () =>
        {
            audioSource.PlayOneShot(sound3);
        }));
        text1.text = "[カッティング]\nディフェンスを振り切って走りこむ動作\n[バックカット]\n相手の裏を通ってパスをもらうカット\n";
    }

    // Update is called once per frame
    void Update()
    {

        
        po1 = O1.transform.position;
        po2 = O2.transform.position;
        po3 = O3.transform.position;


        StartCoroutine(DelayMethod(30f, () =>
        {

            SceneManager.LoadScene("3DLesson1");
            
        }));




        StartCoroutine(DelayMethod(21f, () =>
         {
             
            // audioSource.PlayOneShot(sound2);
             move1();
            
         }));
        //GetComponent<Animator>().SetBool("runrun", false);
        



    }


	void move1(){
        if (flag == 0)
        {
            transform.rotation = Quaternion.Euler(0, 200, 0);
           // O3.transform.Translate(0.02f, 0f, 0.02f);
            GetComponent<Animator>().SetBool("runrun", true);
        }

        if (flag == 1)
        {
            transform.rotation = Quaternion.Euler(0, 30, 0);
           // O3.transform.Translate(0.07f, 0f, 0.08f);
           // GetComponent<Animator>().SetBool("runout", false);
            GetComponent<Animator>().SetBool("runrun", true);
            O3.GetComponent<Animator>().speed = 1.3f;
            if (po3.x>=-3.5f)
               // iTween.MoveTo(ball, iTween.Hash("position", new Vector3(po3.x + 0f, ball.transform.position.y, po3.z + 4f), "Time", 2f));
            ball.GetComponent<Rigidbody>().AddForce((new Vector3(po3.x+1f, ball.transform.position.y, po3.z + 4f) - ball.transform.position) *20);
        }

        if (po3.x <= -5f)
        {
            flag = 1;
           
            //GetComponent<Animator>().SetBool("runrun", true);
        }

        
           

        if (po3.x >= -1.5f)
        {
            flag = 2;
            GetComponent<Animator>().SetBool("runrun", false);
        }

        /* if (po3.x <= -4.7f)
         {
             //GetComponent<Animator>().SetBool("runrun", false);
             GetComponent<Animator>().SetBool("runout", true);

         }*/



        if ((Mathf.Abs(ball.transform.position.x - po3.x) <= 0.5f) && (Mathf.Abs(ball.transform.position.z - po3.z) <= 0.5f))
        {
            ball.transform.position = po3;
            Vector3 pospos = ball.transform.position;
            pospos.y = 1.4f;
            pospos.z = po3.z + 0.3f;
            ball.transform.position = pospos;

            ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
            //this.GetComponent<Rigidbody>().AddForce(Vector3.zero);
            //Debug.Log ("true");

            /*---shift relationship of parent and children from O1 to O3---*/
            //this.transform.parent = O1.transform;
            ball.transform.parent = null;
            ball.transform.parent = O3.transform;

        }

    }

    private IEnumerator DelayMethod(float time, Action action)
    {
        yield return new WaitForSeconds(time);
        action();
    }
		
}