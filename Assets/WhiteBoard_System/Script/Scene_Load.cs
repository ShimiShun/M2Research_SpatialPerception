using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class Scene_Load : MonoBehaviour
{


	int[] a = Start_run.array;
	GameObject obj;

	public static class GameManager
	{
		public static int a1 = 1;
	}

	//DontDestroyOnLoad(GameManager.a1);
	// Use this for initialization
	void Start ()
	{
		obj = GameObject.Find("Button_A");
		//Teaching1 teach = obj.GetComponent<Teaching1>();
	}


		
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void SceneLoad ()
	{
		if (GameManager.a1 == 0) {
			GameManager.a1++;
			SceneManager.LoadScene (a [0]);
			//Debug.Log ("a:" + GameManager.a1);
		} else if (GameManager.a1 == 1) {
			GameManager.a1++;
			SceneManager.LoadScene (a [1]);
			//Debug.Log ("a:" + GameManager.a1);
		} else if (GameManager.a1 == 2) {
			GameManager.a1++;
			SceneManager.LoadScene (a [2]);
			//Debug.Log ("a:" + GameManager.a1);
		} else if (GameManager.a1 == 3) {
			SceneManager.LoadScene (a [3]);
			//GameManager.a1++;
			//Debug.Log ("a:" + GameManager.a1);
		} else {
		}
	}

	public void SceneLoad2 ()
	{

		if (GameManager.a1 == 3) {
			SceneManager.LoadScene (a [2]);
			GameManager.a1--;
		} else if (GameManager.a1 == 2) {
			SceneManager.LoadScene (a [1]);
			GameManager.a1--;
		} else if (GameManager.a1 == 1) {
			SceneManager.LoadScene (a [0]);
			//GameManager.a1--;
		} else {
		}
	}

	public void Load3D(){
		Teaching1 teach = obj.GetComponent<Teaching1>();
		if (teach.flag == 1) {
			SceneManager.LoadScene ("3DLesson1");
		}
	}
}
