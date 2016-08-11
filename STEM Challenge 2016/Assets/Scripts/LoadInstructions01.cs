using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadInstructions01 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
		FadeManager.Instance.Fade (false, 2.0f);
		SFX.Instance.secondaryGameMusic.Play ();
	}


	public void GetLastLoadedLevel ()
	{
		if (PlayerPrefs.GetInt ("LastLoadedLevel") != null) {
			if (PlayerPrefs.GetInt ("LastLoadedLevel") < 3 || PlayerPrefs.GetInt ("LastLoadedLevel") > 12) {
				Debug.Log ("1");
				StartCoroutine (FadeLoadFade ());
			} else {
				Debug.Log ("2");
				StartCoroutine (FadeLastLoadedLevel ());
			}
		} else {
			Debug.Log ("3");
			StartCoroutine (FadeLoadFade ());
		}
	}


	public void GetHighestLevel ()
	{
		if (PlayerPrefs.GetInt ("HighestLevel") != null) {



		} else {

			StartCoroutine (FadeLoadFade ());
		}
	}

	
	public void loadInstructions01 (){
		StartCoroutine (FadeLoadFade ());
	}

	IEnumerator FadeLoadFade ()
	{
		//FadeManager.Instance.FadeIn ();
		FadeManager.Instance.Fade(true, 2.0f); //fade to black
		yield return new WaitForSeconds(2.0f);
		SceneManager.LoadScene ("Instructions01");
		//FadeManager.Instance.FadeOut ();
		FadeManager.Instance.Fade (false, 2.0f); //fade to transparent

	}



	IEnumerator FadeLastLoadedLevel ()
	{
		//FadeManager.Instance.FadeIn ();
		FadeManager.Instance.Fade(true, 2.0f); //fade to black
		yield return new WaitForSeconds(2.0f);
		SceneManager.LoadScene (PlayerPrefs.GetInt ("LastLoadedLevel"));
		//FadeManager.Instance.FadeOut ();
		FadeManager.Instance.Fade (false, 2.0f); //fade to transparent

	}
}
