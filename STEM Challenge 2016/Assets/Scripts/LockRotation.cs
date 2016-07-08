using UnityEngine;
using System.Collections;

public class LockRotation : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {
		//transform.eulerAngles = Vector3(0, 0, 0);
		transform.eulerAngles = new Vector3 (0, 0, 0);
	}
}
