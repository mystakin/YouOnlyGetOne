using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public CharacterController player;
	public Vector2 frameMovement;
	public float speed;
	public float speedAccel;
	public float speedMax;
	public float gravity;
	public float gravityAccel;
	public float gravityMax;
	public float jumpPower;
	public int direction;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag(Tags.player).GetComponent<CharacterController>();

		if( GameStates.gameplayState == 1 )
			gravityMax = -7.5f;
		else if( GameStates.gameplayState == 2 ){
			gravityMax = 7.5f;
			gravityAccel = -gravityAccel;
		}
			
	}
	
	void FixedUpdate(){
		frameMovement = new Vector2(Mathf.Clamp(direction, -1, 1) * speed, gravity);
		Gravity();

		player.Move(frameMovement * Time.fixedDeltaTime);
	}

	void Gravity(){
		if( player.isGrounded && gravity < 0 && GameStates.gameplayState == 0 ){
			gravity = -0.01f;
		}
		else{
			if( GameStates.gameplayState == 2 ){
				if( gravity < gravityMax ){
					gravity += gravityAccel;
				}
				else{
					gravity = gravityMax;
				}
			}
			else{
				if( gravity > gravityMax ){
					gravity += gravityAccel;
				}
				else{
					gravity = gravityMax;
				}
			}
		}
	}

	public void SpeedUp(){
		if( speed < speedMax ){
			speed += speedAccel;
		}
		else
			speed = speedMax;
	}

	public void SlowDown(){
		if( speed > 0f ){
			speed -= speedAccel * 2;
		}
		else
			speed = 0f;
	}

	public void MoveLeft(){
		if( speed > -speedMax ){
			speed -= speedAccel;
		}
		else
			speed = -speedMax;
	}

	public void MoveToZero(){
		if( speed < -1 )
			speed += speedAccel * 2;
		else if ( speed > 1 )
			speed -= speedAccel * 2;
		else
			speed = 0;
	}

	public void Jump(){
		if( player.isGrounded ){
			gravity = jumpPower;
		}
	}
}
