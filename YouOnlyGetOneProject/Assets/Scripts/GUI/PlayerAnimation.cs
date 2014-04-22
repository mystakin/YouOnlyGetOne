using UnityEngine;
using System.Collections;

public class PlayerAnimation : MonoBehaviour {

	public PlayerMovement playerMovement;
	public Animator playerAnim;
	public HashIDs hash;
	public int localItemCount;
	public AudioClip jumpAudio;
	public AudioClip deathAudio;
	public AudioClip victoryAudio;
	public AudioClip victoryFinishAudio;
	public AudioClip itemAudio;
	public float volume;

	// Use this for initialization
	void Awake () {
		playerMovement = GameObject.FindGameObjectWithTag(Tags.dataController).GetComponent<PlayerMovement>();
		playerAnim = GameObject.FindGameObjectWithTag(Tags.player).GetComponentInChildren<Animator>();
		hash = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<HashIDs>();

		localItemCount = GameStates.items;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		HandleAnimations();
		HandleAudio();
	}

	void HandleAnimations(){
		if( playerMovement.speed > 1f && GameStates.gameplayState == 0  ){
			playerAnim.SetBool(hash.boolRun, true);
		}
		else
			playerAnim.SetBool(hash.boolRun, false);

		if( GameStates.gameplayState == 0 && playerMovement.direction < 0 )
			playerAnim.SetBool(hash.boolFaceLeft, true);
		else if( !(GameStates.gameplayState == 0) && playerMovement.speed < -0.5f ) 
			playerAnim.SetBool(hash.boolFaceLeft, true);
		else if( !(GameStates.gameplayState == 0) && playerMovement.speed > 0.5f )
			playerAnim.SetBool(hash.boolFaceLeft, false);
			                 
	}

	void HandleAudio(){
		if( GameStates.gameState == 0 && GameObject.Find("One shot audio") == null )
			AudioSource.PlayClipAtPoint(deathAudio, playerMovement.player.transform.position, volume);

		if( localItemCount < GameStates.items ){
			AudioSource.PlayClipAtPoint(itemAudio, playerMovement.player.transform.position, volume);
			localItemCount = GameStates.items;
		}
	}

	public void PlayJumpSFX(){
		if( playerMovement.player.isGrounded )
			AudioSource.PlayClipAtPoint(jumpAudio, playerMovement.player.transform.position, volume);
	}

	public void PlayVictorySFX(){
		if( GameObject.Find("One shot audio") == null ){
			AudioSource.PlayClipAtPoint(victoryAudio, playerMovement.player.transform.position, volume*3);
			StartCoroutine(GlobalMethods.Delay( 2.3f, PlayVictoryFinish ) );
		}
	}

	void PlayVictoryFinish(){
		AudioSource.PlayClipAtPoint(victoryFinishAudio, playerMovement.player.transform.position, volume*3);
	}
			             
}
