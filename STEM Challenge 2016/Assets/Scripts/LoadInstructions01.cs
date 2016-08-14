using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadInstructions01 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
		SFX.Instance.FadeSecondaryMusic(true, true, 0.5f, 0);
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
		FadeManager.Instance.Fade(true, 2.0f); //fade to black
		SFX.Instance.FadeSecondaryMusic(false, false, 0.5f, SFX.Instance.secondaryGameMusic.volume);
		yield return new WaitForSeconds(2.0f);
		SceneManager.LoadScene ("Instructions01");
		FadeManager.Instance.Fade (false, 2.0f); //fade to transparent
		SFX.Instance.FadeSecondaryMusic(true, true, 0.2f, 0);

	}



	IEnumerator FadeLastLoadedLevel ()
	{
		FadeManager.Instance.Fade(true, 2.0f); //fade to black
		SFX.Instance.FadeSecondaryMusic(false, false, 0.5f, SFX.Instance.secondaryGameMusic.volume);
		yield return new WaitForSeconds(2.0f);
		SceneManager.LoadScene (PlayerPrefs.GetInt ("LastLoadedLevel"));
		FadeManager.Instance.Fade (false, 2.0f); //fade to transparent
		SFX.Instance.FadeMainMusic(true, true, 0.2f, 0);

	}
}
