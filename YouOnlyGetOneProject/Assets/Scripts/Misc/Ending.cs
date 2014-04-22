using UnityEngine;
using System.Collections;

public class Ending : MonoBehaviour {

	public GameObject badEnding;
	public GameObject goodEnding;
	public int minutes;
	public int seconds;
	public GUIText textTimer;

	// Use this for initialization
	void Awake () {
		if( GameStates.items == 5 )
			goodEnding.GetComponent<SpriteRenderer>().enabled = true;
		else
			badEnding.GetComponent<SpriteRenderer>().enabled = true;

		if( GameObject.Find("MusicPlayer") != null )
			Destroy(GameObject.Find("MusicPlayer"));

		seconds = (int)Time.time;

		TextSetup();
	}
	
	// Update is called once per frame
	void Update () {
		if( Input.GetButton("Left") || Input.GetButtonDown("Right") || Input.GetButtonDown("Middle") )
			Application.Quit();
	}

	void TextSetup(){
		textTimer.pixelOffset= new Vector2(Screen.width / 2, Screen.height * .125f);
		textTimer.fontSize = (int)(Screen.height * .075f);

		TimeParser();

		string completeTime = "Complete Time: ";

		if( minutes < 10 )
			completeTime += "0" + minutes + ":";
		else
			completeTime += minutes + ":";

		if( seconds < 10 )
			completeTime += "0" + seconds;
		else
			completeTime += seconds;

		textTimer.text = completeTime;
	}

	void TimeParser(){
		while( seconds > 60 ){
			if( seconds > 60 ){
				minutes++;
				seconds -= 60;
			}
		}
	}
}
