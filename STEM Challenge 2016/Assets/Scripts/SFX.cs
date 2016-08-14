using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SFX : MonoBehaviour {

	public static SFX Instance { set; get; }
	public AudioSource lockExplosion;
	public AudioSource keyCollect;
	public AudioSource finish;
	public AudioSource mainGameMusic;
	public AudioSource secondaryGameMusic;
	public AudioSource boingSound;
	public AudioSource glassSound;


	void Awake () {
		DontDestroyOnLoad(transform.gameObject);
		Instance = this;
	}

	//public void playFadeInMainGameMusic(float fadeLength)
	//{
	//	StartCoroutine (fadeInMainMusic (fadeLength));
	//}

	//IEnumerator fadeInMainMusic(float fadeLength)
	//{
	//	mainGameMusic.Play ();
	//	mainGameMusic.volume = 0;
	//	while (mainGameMusic.volume < 1) {

	//		mainGameMusic.volume += Time.deltaTime / fadeLength;
	//		yield return null;
	//	}
	//}

	//public void playFadeOutMainGameMusic(float fadeLength)
	//{
	//	StartCoroutine (fadeOutMainMusic (fadeLength));
	//}

	//IEnumerator fadeOutMainMusic(float fadeLength)
	//{
	//	//secondaryGameMusic.Play ();
	//	mainGameMusic.volume = 1;
	//	while (mainGameMusic.volume > 0) {

	//		mainGameMusic.volume -= Time.deltaTime / fadeLength;
	//		yield return null;
	//	}
	//}

	//public void playFadeInSecondaryGameMusic(float fadeLength)
	//{
	//	StartCoroutine (fadeInSecondaryMusic (fadeLength));
	//}

	//IEnumerator fadeInSecondaryMusic(float fadeLength)
	//{
	//	secondaryGameMusic.Play ();
	//	secondaryGameMusic.volume = 0;
	//	while (secondaryGameMusic.volume < 1) {
			
	//		secondaryGameMusic.volume += Time.deltaTime / fadeLength;
	//		yield return null;
	//	}
	//}

	//public void playFadeOutSecondaryGameMusic(float fadeLength)
	//{
	//	StartCoroutine (fadeOutSecondaryMusic (fadeLength));
	//}

	//IEnumerator fadeOutSecondaryMusic(float fadeLength)
	//{
	//	//secondaryGameMusic.Play ();
	//	secondaryGameMusic.volume = 1;
	//	while (secondaryGameMusic.volume > 0) {

	//		secondaryGameMusic.volume -= Time.deltaTime / fadeLength;
	//		yield return null;
	//	}
	//}

	//public void pauseFadeInMainGameMusic(float fadeLength)
	//{
	//	StartCoroutine (fadeInPausedMusic (fadeLength));
	//}

	//IEnumerator fadeInPausedMusic(float fadeLength)
	//{
	//	//float currentVolume = mainGameMusic.volume;
	//	while (mainGameMusic.volume < 1) {

	//		mainGameMusic.volume += Time.deltaTime / fadeLength;
	//		yield return null;
	//	}
	//}

	//public void pauseFadeOutMainGameMusic(float fadeLength)
	//{
	//	StartCoroutine (fadeOutPausedMusic (fadeLength));
	//}

	//IEnumerator fadeOutPausedMusic(float fadeLength)
	//{
	//	//float currentVolume = mainGameMusic.volume;
	//	while (mainGameMusic.volume > 0.5f) {

	//		mainGameMusic.volume -= Time.deltaTime / fadeLength;
	//		yield return null;
	//	}
	//}

	//public void restartFadeInMainGameMusic(float fadeLength)
	//{
	//	StartCoroutine (restartFadeInPausedMusic (fadeLength));
	//}

	//IEnumerator restartFadeInPausedMusic(float fadeLength)
	//{
	//	//float currentVolume = mainGameMusic.volume;
	//	while (mainGameMusic.volume < 1) {

	//		mainGameMusic.volume += Time.deltaTime / fadeLength;
	//		yield return null;
	//	}
	//}

	//public void levelSelectFromPauseFadeOutMainGameMusic(float fadeLength)
	//{
	//	StartCoroutine (LevelSelectFromPauseFadeOutPausedMusic (fadeLength));
	//}

	//IEnumerator LevelSelectFromPauseFadeOutPausedMusic(float fadeLength)
	//{
	//	//float currentVolume = mainGameMusic.volume;
	//	while (mainGameMusic.volume > 0.0f) {

	//		mainGameMusic.volume -= Time.deltaTime / fadeLength;
	//		yield return null;
	//	}
	//}

	//public void levelSelectFromPauseFadeInMainGameMusic(float fadeLength)
	//{
	//	StartCoroutine (LevelSelectFromPauseFadeInPausedMusic (fadeLength));
	//}

	//IEnumerator LevelSelectFromPauseFadeInPausedMusic(float fadeLength)
	//{
	//	//float currentVolume = mainGameMusic.volume;
	//	secondaryGameMusic.Play();
	//	secondaryGameMusic.volume = 0;
	//	while (secondaryGameMusic.volume < 1) {

	//		secondaryGameMusic.volume += Time.deltaTime / fadeLength;
	//		yield return null;
	//	}
	//}

	//public void levelSelectFadeOutMainGameMusic(float fadeLength)
	//{
	//	StartCoroutine (LevelSelectFadeOutPausedMusic (fadeLength));
	//}

	//IEnumerator LevelSelectFadeOutPausedMusic(float fadeLength)
	//{
	//	//float currentVolume = mainGameMusic.volume;
	//	while (secondaryGameMusic.volume > 0.0f) {

	//		secondaryGameMusic.volume -= Time.deltaTime / fadeLength;
	//		yield return null;
	//	}
	//}



	public void FadeMainMusic(bool playFromStart,bool fadeIn, float fadeLength, float initVolume)
	{
		StartCoroutine (FadeMainSong (playFromStart, fadeIn, fadeLength, initVolume));
	}
	IEnumerator FadeMainSong(bool playFromStart, bool fadeIn, float fadeLength, float initVolume)
	{
		mainGameMusic.volume = initVolume;

		if (playFromStart) {
			mainGameMusic.Play ();
		}

		if (fadeIn) {
			while (mainGameMusic.volume < 1) {
				mainGameMusic.volume += Time.deltaTime / fadeLength;
				yield return null;
			}
		} else {
			while (mainGameMusic.volume > 0.0f) {
				mainGameMusic.volume -= Time.deltaTime / fadeLength;
				yield return null;
			}
			mainGameMusic.Stop ();
		}
	}

	public void FadeSecondaryMusic(bool playFromStart,bool fadeIn, float fadeLength, float initVolume)
	{
		StartCoroutine (FadeSecondarySong (playFromStart, fadeIn, fadeLength, initVolume));
	}
	IEnumerator FadeSecondarySong(bool playFromStart, bool fadeIn, float fadeLength, float initVolume)
	{
		secondaryGameMusic.volume = initVolume;

		if (playFromStart) {
			secondaryGameMusic.Play ();
			Debug.Log("Secondary music played from start");
		}

		if (fadeIn) {
			while (secondaryGameMusic.volume < 1) {
				secondaryGameMusic.volume += Time.deltaTime / fadeLength;
				yield return null;
			}
		} else {
			while (secondaryGameMusic.volume > 0.0f) {
				secondaryGameMusic.volume -= Time.deltaTime / fadeLength;
				yield return null;
			}
			//secondaryGameMusic.Stop ();
			Debug.Log ("Secondary music stopped");
		}
	}



	public void FadeMainMusicFromPause(bool fadeIn, float fadeLength, float initVolume)
	{
		StartCoroutine (FadeMainSongFromPause (fadeIn, fadeLength, initVolume));
	}
	IEnumerator FadeMainSongFromPause(bool fadeIn, float fadeLength, float initVolume)
	{
		mainGameMusic.volume = initVolume;

		if (fadeIn) {
			while (mainGameMusic.volume < 1) {
				mainGameMusic.volume += Time.deltaTime / fadeLength;
				yield return null;
			}
		} else {
			while (mainGameMusic.volume > 0.4f) {
				mainGameMusic.volume -= Time.deltaTime / fadeLength;
				yield return null;
			}
		}
	}
}
