using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public int cameraState;	// 0 = horizontal, 1 = vertical
	public CameraMovement cameraMovement;

	// Use this for initialization
	void Start () {
		cameraMovement = GameObject.FindGameObjectWithTag(Tags.dataController).GetComponent<CameraMovement>();
	}

	// Update is called once per frame
	void FixedUpdate () {
		cameraMovement.CameraMove( GameStates.gameplayState );
	}
}
