using UnityEngine;
using System.Collections;

public class BounceTileTrigger : MonoBehaviour {

	void OnTriggerEnter(Collider player)
	{
		player.GetComponent<SphereCollider> ().material.bounciness = 1;
		player.GetComponent<SphereCollider> ().material.dynamicFriction = 0;
		player.GetComponent<SphereCollider> ().material.staticFriction = 0;
		player.GetComponent<SphereCollider> ().material.frictionCombine = PhysicMaterialCombine.Maximum;
		player.GetComponent<SphereCollider> ().material.bounceCombine = PhysicMaterialCombine.Maximum;

		player.GetComponent<Rigidbody> ().drag = 0;
		player.GetComponent<Rigidbody> ().angularDrag = 0;
	}

	void OnTriggerExit(Collider player)
	{
		player.GetComponent<SphereCollider> ().material.bounciness = 0.2f;
		player.GetComponent<SphereCollider> ().material.dynamicFriction = 0.6f;
		player.GetComponent<SphereCollider> ().material.staticFriction = 0.6f;
		player.GetComponent<SphereCollider> ().material.frictionCombine = PhysicMaterialCombine.Average;
		player.GetComponent<SphereCollider> ().material.bounceCombine = PhysicMaterialCombine.Average;

		player.GetComponent<Rigidbody> ().drag = 1;
		player.GetComponent<Rigidbody> ().angularDrag = 0.05f;
	}
}
