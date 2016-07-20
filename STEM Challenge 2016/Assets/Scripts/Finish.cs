using UnityEngine;
using System.Collections;

public class Finish : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log ("Game has started");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnParticleCollision(GameObject player) {
		Rigidbody body = player.GetComponent<Rigidbody> ();
		body.freezeRotation = true;
		body.position = new Vector3 (transform.position.x, transform.position.y + 3, transform.position.z);
		//if (body) {
			//Vector3 direction = player.transform.position - transform.position;
			//direction = direction.normalized;
			//body.AddForce (direction * 5);

		//}
	}
}
