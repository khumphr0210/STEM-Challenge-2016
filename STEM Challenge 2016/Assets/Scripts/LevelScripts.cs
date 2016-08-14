using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class LevelScripts : MonoBehaviour {

	public int highestLevel;

	void Start ()
	{
		//PlayerPrefs.SetInt ("HighestLevel", 12);
		//PlayerPrefs.DeleteKey ("HighestLevel");
		//PlayerPrefs.DeleteKey ("LastLoadedLevel");
		Debug.Log ("HighestLevel: " + PlayerPrefs.GetInt("HighestLevel"));
		Debug.Log ("LastLevelLoaded: " + PlayerPrefs.GetInt("LastLoadedLevel"));
		highestLevel = PlayerPrefs.GetInt ("HighestLevel");

		//Unlock level 1-2 button if highest level is at least 2
		if (highestLevel >= 4) {

			GameObject level2Button = GameObject.Find ("1-2Container");
			level2Button.GetComponentInChildren<Image> ().enabled = false;
			level2Button.GetComponentInChildren<Text> ().enabled = true;
		} else {

			GameObject level2Button = GameObject.Find ("1-2");
			level2Button.GetComponent<Button> ().enabled = false;
		}

		//Unlock level 1-3 button if highest level is at least 3
		if (highestLevel >= 5) {

			GameObject level3Button = GameObject.Find ("1-3Container");
			level3Button.GetComponentInChildren<Image> ().enabled = false;
			level3Button.GetComponentInChildren<Text> ().enabled = true;
		} else {

			GameObject level3Button = GameObject.Find ("1-3");
			level3Button.GetComponent<Button> ().enabled = false;
		}

		//Unlock level 1-4 button if highest level is at least 4
		if (highestLevel >= 6) {

			GameObject level4Button = GameObject.Find ("1-4Container");
			level4Button.GetComponentInChildren<Image> ().enabled = false;
			level4Button.GetComponentInChildren<Text> ().enabled = true;
		} else {

			GameObject level4Button = GameObject.Find ("1-4");
			level4Button.GetComponent<Button> ().enabled = false;
		}

		//Unlock level 1-5 button if highest level is at least 5
		if (highestLevel >= 7) {

			GameObject level5Button = GameObject.Find ("1-5Container");
			level5Button.GetComponentInChildren<Image> ().enabled = false;
			level5Button.GetComponentInChildren<Text> ().enabled = true;
		} else {

			GameObject level5Button = GameObject.Find ("1-5");
			level5Button.GetComponent<Button> ().enabled = false;
		}

		//Unlock level 1-6 button if highest level is at least 6
		if (highestLevel >= 8) {

			GameObject level6Button = GameObject.Find ("1-6Container");
			level6Button.GetComponentInChildren<Image> ().enabled = false;
			level6Button.GetComponentInChildren<Text> ().enabled = true;
		} else {

			GameObject level6Button = GameObject.Find ("1-6");
			level6Button.GetComponent<Button> ().enabled = false;
		}

		//Unlock level 1-7 button if highest level is at least 7
		if (highestLevel >= 9) {

			GameObject level7Button = GameObject.Find ("1-7Container");
			level7Button.GetComponentInChildren<Image> ().enabled = false;
			level7Button.GetComponentInChildren<Text> ().enabled = true;
		} else {

			GameObject level7Button = GameObject.Find ("1-7");
			level7Button.GetComponent<Button> ().enabled = false;
		}

		//Unlock level 1-8 button if highest level is at least 8
		if (highestLevel >= 10) {

			GameObject level8Button = GameObject.Find ("1-8Container");
			level8Button.GetComponentInChildren<Image> ().enabled = false;
			level8Button.GetComponentInChildren<Text> ().enabled = true;
		} else {

			GameObject level8Button = GameObject.Find ("1-8");
			level8Button.GetComponent<Button> ().enabled = false;
		}

		//Unlock level 1-9 button if highest level is at least 9
		if (highestLevel >= 11) {

			GameObject level9Button = GameObject.Find ("1-9Container");
			level9Button.GetComponentInChildren<Image> ().enabled = false;
			level9Button.GetComponentInChildren<Text> ().enabled = true;
		} else {

			GameObject level9Button = GameObject.Find ("1-9");
			level9Button.GetComponent<Button> ().enabled = false;
		}

		//Unlock level 1-10 button if highest level is at least 10
		if (highestLevel >= 12) {

			GameObject level10Button = GameObject.Find ("1-10Container");
			level10Button.GetComponentInChildren<Image> ().enabled = false;
			level10Button.GetComponentInChildren<Text> ().enabled = true;
		} else {

			GameObject level10Button = GameObject.Find ("1-10");
			level10Button.GetComponent<Button> ().enabled = false;
		}
	}

	public void LoadLevel1()
	{
		StartCoroutine (Level1_1 ());
	}
	IEnumerator Level1_1 ()
	{
		FadeManager.Instance.Fade (true, 2.0f);
		//SFX.Instance.levelSelectFadeOutMainGameMusic (1.5f);
		SFX.Instance.FadeSecondaryMusic(false, false, 1.5f, SFX.Instance.secondaryGameMusic.volume);
		Debug.Log ("Secondary music faded out from level 1-1 button");
		yield return new WaitForSeconds (2.0f);
		SceneManager.LoadScene ("Level01");
		FadeManager.Instance.Fade (false, 2.0f);
		//SFX.Instance.levelSelectFadeInMainGameMusic (1.5f);
		SFX.Instance.FadeMainMusic(true, true, 1.5f, 0);
		Debug.Log ("Main music faded in for level 1-1");
		yield return new WaitForSeconds (2.0f);
	}

	public void LoadLevel2()
	{
		StartCoroutine (Level1_2 ());
	}
	IEnumerator Level1_2 ()
	{
		FadeManager.Instance.Fade (true, 2.0f);
		//SFX.Instance.levelSelectFadeOutMainGameMusic (1.5f);
		SFX.Instance.FadeSecondaryMusic(false, false, 1.5f, SFX.Instance.secondaryGameMusic.volume);
		yield return new WaitForSeconds (2.0f);
		SceneManager.LoadScene ("Level02");
		FadeManager.Instance.Fade (false, 2.0f);
		//SFX.Instance.levelSelectFadeInMainGameMusic (1.5f);
		SFX.Instance.FadeMainMusic(true, true, 1.5f, 0);
		yield return new WaitForSeconds (2.0f);
	}

	public void LoadLevel3()
	{
		StartCoroutine (Level1_3 ());
	}
	IEnumerator Level1_3 ()
	{
		FadeManager.Instance.Fade (true, 2.0f);
		//SFX.Instance.levelSelectFadeOutMainGameMusic (1.5f);
		SFX.Instance.FadeSecondaryMusic(false, false, 1.5f, SFX.Instance.secondaryGameMusic.volume);
		yield return new WaitForSeconds (2.0f);
		SceneManager.LoadScene ("Level03");
		FadeManager.Instance.Fade (false, 2.0f);
		//SFX.Instance.levelSelectFadeInMainGameMusic (1.5f);
		SFX.Instance.FadeMainMusic(true, true, 1.5f, 0);
		yield return new WaitForSeconds (2.0f);
	}

	public void LoadLevel4()
	{
		StartCoroutine (Level1_4 ());
	}
	IEnumerator Level1_4 ()
	{
		FadeManager.Instance.Fade (true, 2.0f);
		//SFX.Instance.levelSelectFadeOutMainGameMusic (1.5f);
		SFX.Instance.FadeSecondaryMusic(false, false, 1.5f, SFX.Instance.secondaryGameMusic.volume);
		yield return new WaitForSeconds (2.0f);
		SceneManager.LoadScene ("Level04");
		FadeManager.Instance.Fade (false, 2.0f);
		//SFX.Instance.levelSelectFadeInMainGameMusic (1.5f);
		SFX.Instance.FadeMainMusic(true, true, 1.5f, 0);
		yield return new WaitForSeconds (2.0f);
	}

	public void LoadLevel5()
	{
		StartCoroutine (Level1_5 ());
	}
	IEnumerator Level1_5 ()
	{
		FadeManager.Instance.Fade (true, 2.0f);
		//SFX.Instance.levelSelectFadeOutMainGameMusic (1.5f);
		SFX.Instance.FadeSecondaryMusic(false, false, 1.5f, SFX.Instance.secondaryGameMusic.volume);
		yield return new WaitForSeconds (2.0f);
		SceneManager.LoadScene ("Level05");
		FadeManager.Instance.Fade (false, 2.0f);
		//SFX.Instance.levelSelectFadeInMainGameMusic (1.5f);
		SFX.Instance.FadeMainMusic(true, true, 1.5f, 0);
		yield return new WaitForSeconds (2.0f);
	}

	public void LoadLevel6()
	{
		StartCoroutine (Level1_6 ());
	}
	IEnumerator Level1_6 ()
	{
		FadeManager.Instance.Fade (true, 2.0f);
		//SFX.Instance.levelSelectFadeOutMainGameMusic (1.5f);
		SFX.Instance.FadeSecondaryMusic(false, false, 1.5f, SFX.Instance.secondaryGameMusic.volume);
		yield return new WaitForSeconds (2.0f);
		SceneManager.LoadScene ("Level06");
		FadeManager.Instance.Fade (false, 2.0f);
		//SFX.Instance.levelSelectFadeInMainGameMusic (1.5f);
		SFX.Instance.FadeMainMusic(true, true, 1.5f, 0);
		yield return new WaitForSeconds (2.0f);
	}

	public void LoadLevel7()
	{
		StartCoroutine (Level1_7 ());
	}
	IEnumerator Level1_7 ()
	{
		FadeManager.Instance.Fade (true, 2.0f);
		//SFX.Instance.levelSelectFadeOutMainGameMusic (1.5f);
		SFX.Instance.FadeSecondaryMusic(false, false, 1.5f, SFX.Instance.secondaryGameMusic.volume);
		yield return new WaitForSeconds (2.0f);
		SceneManager.LoadScene ("Level07");
		FadeManager.Instance.Fade (false, 2.0f);
		//SFX.Instance.levelSelectFadeInMainGameMusic (1.5f);
		SFX.Instance.FadeMainMusic(true, true, 1.5f, 0);
		yield return new WaitForSeconds (2.0f);
	}

	public void LoadLevel8()
	{
		StartCoroutine (Level1_8 ());
	}
	IEnumerator Level1_8 ()
	{
		FadeManager.Instance.Fade (true, 2.0f);
		//SFX.Instance.levelSelectFadeOutMainGameMusic (1.5f);
		SFX.Instance.FadeSecondaryMusic(false, false, 1.5f, SFX.Instance.secondaryGameMusic.volume);
		yield return new WaitForSeconds (2.0f);
		SceneManager.LoadScene ("Level08");
		FadeManager.Instance.Fade (false, 2.0f);
		//SFX.Instance.levelSelectFadeInMainGameMusic (1.5f);
		SFX.Instance.FadeMainMusic(true, true, 1.5f, 0);
		yield return new WaitForSeconds (2.0f);
	}

	public void LoadLevel9()
	{
		StartCoroutine (Level1_9 ());
	}
	IEnumerator Level1_9 ()
	{
		FadeManager.Instance.Fade (true, 2.0f);
		//SFX.Instance.levelSelectFadeOutMainGameMusic (1.5f);
		SFX.Instance.FadeSecondaryMusic(false, false, 1.5f, SFX.Instance.secondaryGameMusic.volume);
		yield return new WaitForSeconds (2.0f);
		SceneManager.LoadScene ("Level09");
		FadeManager.Instance.Fade (false, 2.0f);
		//SFX.Instance.levelSelectFadeInMainGameMusic (1.5f);
		SFX.Instance.FadeMainMusic(true, true, 1.5f, 0);
		yield return new WaitForSeconds (2.0f);
	}

	public void LoadLevel10()
	{
		StartCoroutine (Level1_10 ());
	}
	IEnumerator Level1_10 ()
	{
		FadeManager.Instance.Fade (true, 2.0f);
		//SFX.Instance.levelSelectFadeOutMainGameMusic (1.5f);
		SFX.Instance.FadeSecondaryMusic(false, false, 1.5f, SFX.Instance.secondaryGameMusic.volume);
		yield return new WaitForSeconds (2.0f);
		SceneManager.LoadScene ("Level10");
		FadeManager.Instance.Fade (false, 2.0f);
		//SFX.Instance.levelSelectFadeInMainGameMusic (1.5f);
		SFX.Instance.FadeMainMusic(true, true, 1.5f, 0);
		yield return new WaitForSeconds (2.0f);
	}
}
