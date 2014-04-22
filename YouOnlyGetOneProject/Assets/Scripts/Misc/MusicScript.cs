using UnityEngine;
using System.Collections;

public class MusicScript : MonoBehaviour {

	public GameObject music;

	// Use this for initialization
	void Awake () {
		if( GameObject.Find("Music") == null ){
			GameObject musicClone;
			musicClone = (GameObject)Instantiate(music);
			musicClone.transform.parent = gameObject.transform;
			musicClone.name = "Music";
			GameStates.initialBoot = true;
		}
		else{
			GameStates.initialBoot = false;
			Destroy(gameObject);
		}
			

		DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {

	}
}
