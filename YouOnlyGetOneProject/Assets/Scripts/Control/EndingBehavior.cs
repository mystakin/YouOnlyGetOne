using UnityEngine;
using System.Collections;

public class EndingBehavior : MonoBehaviour {

	public PlayerAnimation playerAnim;
	public PlayerMovement playerMovement;
	public bool victorySFX;

	// Use this for initialization
	void Awake () {
		playerMovement = GameObject.FindGameObjectWithTag(Tags.dataController).GetComponent<PlayerMovement>();
		playerAnim = GameObject.FindGameObjectWithTag(Tags.guiController).GetComponent<PlayerAnimation>();
		victorySFX = false;
	}
	
	// Update is called once per frame
	void Update () {
		if( victorySFX ){
			playerAnim.PlayVictorySFX();
			victorySFX = false;
		}
		if( GameStates.gameplayState == 0 )
			playerMovement.SpeedUp();
		else
			playerMovement.speed = 0f;

		GlobalMethods.localItemCount = GameStates.items;
		StartCoroutine(GlobalMethods.Delay( 4.3f, NextLevel ) );
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
