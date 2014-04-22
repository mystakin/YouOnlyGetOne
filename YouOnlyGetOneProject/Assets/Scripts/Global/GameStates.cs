using UnityEngine;
using System.Collections;

public class GameStates : MonoBehaviour {

	public static int gameState; 	// 0 = Game Over, 1 = Pause, 2 = Finish, 3 = Gameplay
	public static int gameplayState;	// 0 = Run, 1 = Fall, 2 = Fly
	public static int items;
	public static bool initialBoot;
	public PlayerController playerController;
	public PlayerMovement playerMovement;
	public EndingBehavior ending;
	public CameraController cameraController;
	public int prevGameState;

	void Awake(){
		prevGameState = gameState;
		playerController = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<PlayerController>();
		playerMovement = GameObject.FindGameObjectWithTag(Tags.dataController).GetComponent<PlayerMovement>();
		ending = GameObject.FindGameObjectWithTag(Tags.dataController).GetComponent<EndingBehavior>();
		cameraController = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<CameraController>();

		ending.enabled = false;
	}

	void Update(){
		if( prevGameState != gameState ){
			ChangeGameState( gameState );
			prevGameState = gameState;
		}
	}

	void ChangeGameState( int state ){
		if( state == 0 ){
			playerController.enabled = false;
			playerMovement.enabled = false;
		}
		else if( state == 2 ){
			playerController.enabled = false;
			cameraController.enabled = false;
			ending.enabled = true;
			ending.victorySFX = true;
		}
	}
}
