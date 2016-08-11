using UnityEngine;
using System.Collections;

public class GlassSound : MonoBehaviour {

	public GameObject glassSound;

	void OnCollisionEnter(Collision collision)
	{
		//if (collider.gameObject.CompareTag ("bounceTile")) {

		SFX.Instance.glassSound.Play ();
		//}
	}
}
