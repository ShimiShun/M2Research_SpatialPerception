using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Start_run : MonoBehaviour {

	public static int[] array={1,2,3};

	// Use this for initialization
	void Start () {
		System.Random rng = new System.Random();
		int n = array.Length;
		while (n > 1)
		{
			n--;
			int k = rng.Next(n + 1);
			int tmp = array[k];
			array[k] = array[n];
			array[n] = tmp;
		}
		//Debug.Log (array[0]+1);
		//Debug.Log (array[1]+1);
		//Debug.Log (array[2]+1);
		//Debug.Log (array[3]+1);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SceneLoad () {
		SceneManager.LoadScene (array [0]);
}

}
