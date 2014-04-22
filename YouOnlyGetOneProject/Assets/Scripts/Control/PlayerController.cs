using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public PlayerMovement playerMovement;
	public PlayerAnimation playeranim;
	public bool leftPress;
	public bool middlePress;
	public bool rightPress;

	// Use this for initialization
	void Awake () {
		playerMovement = GameObject.FindGameObjectWithTag(Tags.dataController).GetComponent<PlayerMovement>();
		playeranim = GameObject.FindGameObjectWithTag(Tags.guiController).GetComponent<PlayerAnimation>();
	}
	
	// Update is called once per frame
	void Update () {
		if( Input.GetButton("Left") ){
			leftPress = true;
		}
		else if( Input.GetButtonUp("Left") ){
			leftPress = false;
		}

		if( GameStates.gameplayState == 0 ){
			if (Input.GetButtonDown("Right") ){
				rightPress = true;
			}
		}
		else if( GameStates.gameplayState != 0 ){
			if( Input.GetButton("Right") ){
				rightPress = true;
			}
			else if( Input.GetButtonUp("Right") ){
				rightPress = false;
			}
		}

		if (Input.GetButtonDown("Middle") ){
			middlePress = true;
		}
	}

	void FixedUpdate(){
		if( GameStates.gameplayState == 0 ){
			if( leftPress ){
				playerMovement.SpeedUp();
			}
			else{
				playerMovement.SlowDown();
			}

			if( rightPress ){
				playeranim.PlayJumpSFX();
				playerMovement.Jump();
				rightPress = false;
			}
		}
		else if( GameStates.gameplayState != 0 ){
			if( leftPress ){
				if( playerMovement.speed > 0 )
					playerMovement.speed = 0f;

				playerMovement.MoveLeft();
			}
			else if( rightPress ){
				if( playerMovement.speed < 0 )
					playerMovement.speed = 0f;

				playerMovement.SpeedUp();
			}
			else{
				playerMovement.MoveToZero();
			}
		}

		if( middlePress ){
			GlobalMethods.Restart();
		}
	}
}
