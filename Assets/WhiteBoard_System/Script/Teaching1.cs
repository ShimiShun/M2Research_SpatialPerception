using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Teaching1 : MonoBehaviour
{

	public Text text1;//follow to practice text
	public GameObject arrow,ball,O1,O2,O3,D1,D2,D3; // magnet position
	Vector3 po1,po2,po3,pb,pd1,pd2,pd3; // primary position
	float px,pz;//po1.x - pd1.x, po1.z - pd1.z
	public int flag=0;



	public GameObject buttonN;


	// Use this for initialization
	void Start ()
	{
		//text1.text = "";


	}
	
	// Update is called once per frame
	void Update ()
	{
		

		pb = ball.transform.position;
		po1 = O1.transform.position;
		po2 = O2.transform.position;
		po3 = O3.transform.position;
		pd1 = D1.transform.position;
		pd2 = D2.transform.position;
		pd3 = D3.transform.position;

		px = po1.x - pd1.x;
		pz = po1.z - pd1.z;



		Debug.Log("("+(px)+","+(pz)+")");
		//to1 = "x: "+pb.ToString();

	}


	void Teach ()
	{
		/*---------------pass cut------------------*/
		if ((0f <= px && px <= 0.2f) && (0f <= pz && pz <= 0.3f)) {
			text1.text = "ディフェンスを振り切れない，パスがもらえない時はこの練習がいいでしょう";
			buttonN.SetActive (true);
			flag = 1;
		}

		/*---------------shoot select------------------*/
		if ((pz >= 0.5f)) {
			text1.text = "ディフェンとの距離がある場合は積極的にシュートをすることを心がけるといいでしょう";
		}

		/*---------------dribrring------------------*/
		if ((0f <= px && px <= 0.3f) && (0.3f <= pz && pz <= 0.45f)) {
			text1.text = "ディフェンスとの距離がなんか微妙な時は.....";
		}

	}

//	void Practice3D(){
//		if (flag == 1) {
//			SceneManager.LoadScene ("3DLesson1");
//		}
//	}
}
