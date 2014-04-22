using UnityEngine;
using System.Collections;

public class SetupBehavior : MonoBehaviour {

	public PlayerMovement playerMovement;

	// Use this for initialization
	void Awake () {
		playerMovement = GameObject.FindGameObjectWithTag(Tags.dataController).GetComponent<PlayerMovement>();

		Setup ();
	}
	
	// Update is called once per frame
	void Setup () {
		if( Application.loadedLevelName == LevelNames.grasslands  ){
			GameStates.gameState = 3;
			GameStates.gameplayState = 0;
		}
		else if ( Application.loadedLevelName == LevelNames.waterlands ){
			GameStates.gameState = 3;
			GameStates.gameplayState = 1;
		}	
		else if ( Application.loadedLevelName == LevelNames.desertlands ){
			GameStates.gameState = 3;
			playerMovement.direction = -1;
			GameStates.gameplayState = 0;
		}
		else if( Application.loadedLevelName == LevelNames.sunset ){
			GameStates.gameState = 3;
			GameStates.gameplayState = 2;
		}
		else if( Application.loadedLevelName == LevelNames.space ){
			GameStates.gameState = 3;
			GameStates.gameplayState = 0;
		}
	}
}
