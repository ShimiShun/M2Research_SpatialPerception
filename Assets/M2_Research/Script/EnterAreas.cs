using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterAreas : MonoBehaviour {

	[SerializeField]
	public List <GameObject> Areas;

	[SerializeField]
	public List <GameObject> OurPlayers;

	private Vector3 m_velocity;
	public int EmptyArea = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		for (int i = 0; i < Areas.Count; i++) {
			if (Areas [i].transform.childCount <= 0)
				EmptyArea = i;
		}
		Debug.Log (EmptyArea);


		OurPlayers [0].transform.position += (Areas [EmptyArea].transform.position - OurPlayers [0].transform.position)*0.1f;

		OurPlayers [0].transform.root.gameObject.transform.parent = null;	
		OurPlayers [0].transform.parent = Areas [EmptyArea].transform;
	}
}
