using UnityEngine;
using System.Collections;

public class HashIDs : MonoBehaviour {
	
	public int boolRun;
	public int boolFaceLeft;

	void Awake(){
		boolRun = Animator.StringToHash("Run");
		boolFaceLeft = Animator.StringToHash("FaceLeft");
	}
}
