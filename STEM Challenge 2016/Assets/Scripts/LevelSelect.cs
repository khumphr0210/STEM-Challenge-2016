using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour {

	public void LoadLevelSelect()
	{
		StartCoroutine (GameLevelSelect ());
	}

	IEnumerator GameLevelSelect()
	{
		FadeManager.Instance.Fade(true, 2.0f); //fade to black
		SFX.Instance.FadeSecondaryMusic(false, false, 0.5f, SFX.Instance.secondaryGameMusic.volume);
		Debug.Log ("Secondary music faded out");
		yield return new WaitForSeconds(2.0f);
		SceneManager.LoadScene ("LevelSelect");
		FadeManager.Instance.Fade (false, 2.0f); //fade to transparent
		SFX.Instance.FadeSecondaryMusic(true, true, 0.2f, 0);
		Debug.Log ("Secondary music faded in");
	}

	public void LoadLevel1_1()
	{
		StartCoroutine (Level1_1 ());
	}

	IEnumerator Level1_1()
	{
		FadeManager.Instance.Fade(true, 2.0f); //fade to black
		SFX.Instance.FadeSecondaryMusic(false, false, 0.5f, SFX.Instance.secondaryGameMusic.volume);
		Debug.Log ("Secondary music faded out");
		yield return new WaitForSeconds(2.0f);
		SceneManager.LoadScene ("Level01");
		FadeManager.Instance.Fade (false, 2.0f); //fade to transparent
		SFX.Instance.FadeMainMusic(true, true, 0.2f, 0);
		Debug.Log ("Main music faded in");
	}
}
