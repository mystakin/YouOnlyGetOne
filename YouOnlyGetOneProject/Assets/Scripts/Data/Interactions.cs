using UnityEngine;
using System.Collections;

public class Interactions : MonoBehaviour {

	public PlayerMovement playerMovement;
	public PlayerController playerController;
	public CameraMovement cameraMovement;
	public CameraController cameraController;
	public bool interacted;

	void Awake(){
		playerMovement = GameObject.FindGameObjectWithTag(Tags.dataController).GetComponent<PlayerMovement>();
		cameraMovement = GameObject.FindGameObjectWithTag(Tags.dataController).GetComponent<CameraMovement>();
		cameraController = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<CameraController>();
		playerController = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<PlayerController>();
		interacted = false;
	}

	public void DeathInteraction( GameObject player, GameObject other ){
		if( !interacted ){
			GameStates.gameState = 0;
			StartCoroutine( GlobalMethods.Delay( 1.888f, GlobalMethods.Restart ) );
			interacted = true;
			player.GetComponentInChildren<SpriteRenderer>().enabled = false;
		}
	}

	public void HitWall(){
		if( GameStates.gameplayState == 0 )
			playerMovement.SlowDown();
		else
			playerMovement.MoveToZero();
	}

	public void Finish(){
		GameObject[] finishArray = GameObject.FindGameObjectsWithTag(Tags.finish);

		for( int i = 0; i < finishArray.Length; i++ ){
			finishArray[i].collider.isTrigger = true;
		}

		GameStates.gameState = 2;
	}

	public void CollectItem( GameObject item ){
		item.collider.isTrigger = true;
		item.GetComponentInChildren<SpriteRenderer>().enabled = false;
		GameStates.items += 1;
	}

	public void DirectionTrigger( GameObject trig ){
		if( trig.name == "FallTrigger" ){
			trig.collider.isTrigger = true;
			cameraMovement.CalculateXLock( false );
			GameStates.gameplayState = 1;
			playerMovement.gravityMax = -7.5f;
		}
		else if( trig.name == "LeftTrigger" ){
			trig.collider.isTrigger = true;
			cameraMovement.CalculateYLock();
			playerController.rightPress = false;
			GameStates.gameplayState = 0;
			playerMovement.direction = -1;
			cameraMovement.offsetArray[0] = new Vector3 (5f * playerMovement.direction, 2.42f, -10f);
			playerMovement.gravityMax = -15f;
		}
		else if( trig.name == "UpTrigger" ){
			trig.collider.isTrigger = true;
			cameraMovement.CalculateXLock( true );
			GameStates.gameplayState = 2;
			playerMovement.gravityMax = 7.5f;
			playerMovement.gravityAccel = 1;
			playerMovement.direction = 1;
		}
		else if( trig.name == "RightTrigger" ){
			trig.collider.isTrigger = true;
			cameraMovement.CalculateYLock();
			GameStates.gameplayState = 0;
			playerMovement.gravityMax = -15f;
			playerMovement.gravityAccel = -1;
			playerMovement.direction = 1;
			cameraMovement.offsetArray[0] = new Vector3 (5f * playerMovement.direction, 2.42f, -10f);
		}
		else if( trig.name == "StateTrigger" ){
			trig.collider.isTrigger = true;
			cameraMovement.offsetArray[2] = new Vector3 (5f, -2.42f, -10f);
		}
	}
}
