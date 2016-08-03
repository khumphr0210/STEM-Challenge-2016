using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadScene1_1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine (WaitToLoad());
	
	}

	IEnumerator WaitToLoad()
	{
		yield return new WaitForSeconds(3); // change this to 5 or greater
		StartCoroutine (LoadLevel());
	}

	IEnumerator LoadLevel()
	{
		FadeManager.Instance.Fade(true, 2.0f); //fade to black
		yield return new WaitForSeconds(2.0f);
		SceneManager.LoadScene ("Level01");
		FadeManager.Instance.Fade (false, 2.0f); //fade to transparent
	}
	

}
