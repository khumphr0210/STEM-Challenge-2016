using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class playerDeath : MonoBehaviour {


	void OnCollisionEnter(Collision collision)
	{
		if( collision.gameObject.tag == "Player" )
		{
			Destroy(collision.gameObject);
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

		}
	}

}
