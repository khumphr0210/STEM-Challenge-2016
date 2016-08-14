using UnityEngine;
using System.Collections;

public class BoingSound : MonoBehaviour {
	
	public GameObject boingSound;

	void OnCollisionEnter(Collision collision)
	{
		//if (collider.gameObject.CompareTag ("bounceTile")) {

			SFX.Instance.boingSound.Play ();
		//}
	}
}
