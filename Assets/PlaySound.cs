using UnityEngine;
using System.Collections;

public class PlaySound : MonoBehaviour {


    private AudioSource audioSource;    // AudioSorceコンポーネント格納用
    public AudioClip sound1;        // 効果音の格納用。インスペクタで。
    public AudioClip sound2;        // 効果音の格納用。インスペクタで。
	
    // Use this for initialization
	void Start () {
        audioSource = GameObject.Find("/AudioClipObject").GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
       
        if(Input.GetMouseButtonUp(0)){
            audioSource.PlayOneShot(sound2);
        }
    }
}
