using UnityEngine;
using System.Collections;

public class LockTrigger : MonoBehaviour {

	private Collider myCollider;

	// Use this for initialization
	void Start () {
		myCollider = GetComponent<Collider> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.Find("Player").GetComponent<PlayerMovement>().gotKey) {
			Debug.Log ("There is a key. Make collider a trigger now");
			myCollider.isTrigger = true;
		} else {
			myCollider.isTrigger = false;
		}
	}
}
