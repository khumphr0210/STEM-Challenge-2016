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
		yield return new WaitForSeconds(10); // change this to 5 or greater
		StartCoroutine (LoadLevel());
	}

	IEnumerator LoadLevel()
	{
		FadeManager.Instance.Fade(true, 2.0f); //fade to black
		SFX.Instance.FadeSecondaryMusic(false, false, 1.5f, SFX.Instance.secondaryGameMusic.volume);
		yield return new WaitForSeconds(2.0f);
		SceneManager.LoadScene ("Level01");
		FadeManager.Instance.Fade (false, 2.0f); //fade to transparent
		SFX.Instance.FadeMainMusic(true, true, 1.5f, 0);
	}
	

}
