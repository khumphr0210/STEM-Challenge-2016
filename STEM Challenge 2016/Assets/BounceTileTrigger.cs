using UnityEngine;
using System.Collections;

public class BounceTileTrigger : MonoBehaviour {

	void OnTriggerEnter(Collider player)
	{
		player.GetComponent<BoxCollider> ().material.bounciness = 1;
	}

	void OnTriggerExit(Collider player)
	{
		
	}
}
