using UnityEngine;
using System.Collections;

public class Triggers : MonoBehaviour {

	public PlayerMovement playerMovement;
	public Interactions inter;

	void Awake(){
		inter = GameObject.FindGameObjectWithTag(Tags.dataController).GetComponent<Interactions>();
		playerMovement = GameObject.FindGameObjectWithTag(Tags.dataController).GetComponent<PlayerMovement>();
	}

	void OnControllerColliderHit( ControllerColliderHit hit ){
		if( hit.gameObject.tag == Tags.death )
			inter.DeathInteraction(gameObject, hit.gameObject );

		if( hit.gameObject.tag == Tags.finish )
			inter.Finish();

		if( hit.gameObject.tag == Tags.directionTrig )
			inter.DirectionTrigger( hit.gameObject );

		if( hit.gameObject.tag == Tags.item )
			inter.CollectItem( hit.gameObject );

		if( hit.moveDirection.x != 0 )
			inter.HitWall();

		if( hit.moveDirection.y > 0 ){
			if( playerMovement.gravity > 0 )
				playerMovement.gravity = 0f;
		}
	}
}
