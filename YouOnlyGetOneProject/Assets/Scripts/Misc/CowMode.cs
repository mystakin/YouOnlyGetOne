using UnityEngine;
using System.Collections;

public class CowMode : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if( Input.GetKeyDown(KeyCode.BackQuote) ){
			NextLevel();
		}
	}

	void NextLevel(){
		if( Application.loadedLevelName == LevelNames.grasslands )
			Application.LoadLevel( LevelNames.waterlands );
		else if( Application.loadedLevelName == LevelNames.waterlands )
			Application.LoadLevel( LevelNames.desertlands );
		else if( Application.loadedLevelName == LevelNames.desertlands )
			Application.LoadLevel( LevelNames.sunset );
		else if( Application.loadedLevelName == LevelNames.sunset )
			Application.LoadLevel( LevelNames.space );
		else if( Application.loadedLevelName == LevelNames.space )
			Application.LoadLevel( LevelNames.ending );
	}
}
