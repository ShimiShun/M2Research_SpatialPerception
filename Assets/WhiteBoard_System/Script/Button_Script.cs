using UnityEngine;
using System.Collections;

public class Button_Script : MonoBehaviour {

	public GameObject wb;//作戦盤
	public GameObject nb;//次へボタン
	public GameObject bb;//戻るボタン
	public GameObject cb;//進むボタン


	// Use this for initialization
	void Start () {

		Vector3 pos = wb.transform.position;
		pos.y += 50;
		pos.x += 630;
		nb.transform.position = pos;


		Vector3 pos1 = nb.transform.position;
		pos1.x += 350;
		bb.transform.position = pos1;


		Vector3 pos2 = wb.transform.position;
		pos2.x += 230;
		pos2.y += 370;
		cb.transform.position = pos2;


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
