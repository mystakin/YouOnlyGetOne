using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	public PlayerMovement playerMovement;
	public Vector2 cameraFrameMovement;
	public Vector3 newCameraLocation;
	public Vector3[] offsetArray;
	public float yLock;
	public float xLock;
	public float cameraSpeed;
	public CharacterController player;
	public Transform xLockLeft;
	public Transform xLockRight;
	public Transform yLockBottom;
	public bool lockOverride;


	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag(Tags.player).GetComponent<CharacterController>();
		playerMovement = GameObject.FindGameObjectWithTag(Tags.dataController).GetComponent<PlayerMovement>();

		offsetArray = new Vector3[3];
		offsetArray[0] = new Vector3 (5f * playerMovement.direction, 3.42f, -10f);
		offsetArray[1] = new Vector3 (5f, -3.42f, -10f);
		offsetArray[2] = new Vector3 (5f, 3.42f, -10f);
	}
	
	public void CameraMove( int cameraMode ){
		if( !lockOverride ){
			if( cameraMode == 0 ){
				newCameraLocation = player.transform.position + offsetArray[0];
				newCameraLocation = new Vector3(newCameraLocation.x, yLock, newCameraLocation.z);
			}
			else if( cameraMode == 1 ){
				newCameraLocation = player.transform.position + offsetArray[1];
				newCameraLocation = new Vector3(xLock, newCameraLocation.y, newCameraLocation.z);
			}
			else if( cameraMode == 2 ){
				newCameraLocation = player.transform.position + offsetArray[2];
				newCameraLocation = new Vector3(xLock, newCameraLocation.y, newCameraLocation.z);
			}
		}
		else {
			newCameraLocation = player.transform.position + offsetArray[2];
			newCameraLocation = new Vector3(xLock, yLock, newCameraLocation.z);
		}

		Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, newCameraLocation, cameraSpeed * Time.deltaTime);
	}

	public void CalculateXLock( bool up ){
		Ray xLockLeftRay = new Ray();
		Ray xLockRightRay = new Ray();
		RaycastHit hitInfo;

		if( !up ){
			xLockLeftRay = new Ray( playerMovement.player.transform.position, Vector3.left );
			xLockRightRay = new Ray( playerMovement.player.transform.position, Vector3.right );
		}
		else{
			xLockLeftRay = new Ray( playerMovement.player.transform.position + Vector3.up * 10, Vector3.left );
			xLockRightRay = new Ray( playerMovement.player.transform.position + Vector3.up * 10, Vector3.right );
		}

		if( Physics.Raycast(xLockLeftRay, out hitInfo) ){
			xLockLeft = hitInfo.transform;
		}

		if( Physics.Raycast(xLockRightRay, out hitInfo) ){
			xLockRight = hitInfo.transform;
		}

		xLock = xLockRight.position.x - xLockLeft.position.x;
		xLock = xLock / 2;
		xLock += xLockLeft.position.x;
	}

	public void CalculateYLock(){
		Ray yLockRay = new Ray( playerMovement.player.transform.position, Vector3.down );
		RaycastHit hitInfo;

		if( Physics.Raycast( yLockRay, out hitInfo ) ){
			yLockBottom = hitInfo.transform;
		}

		yLock = yLockBottom.position.y + 3.5f;

	}
}
