﻿using UnityEngine;
using System.Collections;

public class keyRotate : MonoBehaviour {


	
	// Update is called once per frame
	void Update () {

		transform.Rotate (0, 200 * Time.deltaTime, 0);

	
	}
}
