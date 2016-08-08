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
		yield return new WaitForSeconds(2.0f);
		SceneManager.LoadScene ("LevelSelect");
		FadeManager.Instance.Fade (false, 2.0f); //fade to transparent
	}

	public void LoadLevel1_1()
	{
		StartCoroutine (Level1_1 ());
	}

	IEnumerator Level1_1()
	{
		FadeManager.Instance.Fade(true, 2.0f); //fade to black
		yield return new WaitForSeconds(2.0f);
		SceneManager.LoadScene ("Level01");
		FadeManager.Instance.Fade (false, 2.0f); //fade to transparent
	}
}
