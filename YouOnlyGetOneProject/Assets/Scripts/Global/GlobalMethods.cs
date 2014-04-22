using UnityEngine;
using System.Collections;
using System;

public class GlobalMethods : MonoBehaviour {

	public static int localItemCount;

	void Awake(){
		localItemCount = GameStates.items;
	}

	public static IEnumerator Delay( float sec, Action nextMethod ){
		yield return new WaitForSeconds(sec);
		nextMethod();
	}

	public static void Restart(){
		GameStates.items = localItemCount;
		Application.LoadLevel(Application.loadedLevel);
	}
	
}
