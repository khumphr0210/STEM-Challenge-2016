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
			Debug.Log ("Fading out");
			while (secondaryGameMusic.volume > 0.0f) {
				secondaryGameMusic.volume -= Time.deltaTime / fadeLength;
				yield return null;
			}
			//secondaryGameMusic.Stop ();
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
			while (mainGameMusic.volume > 0) {
				mainGameMusic.volume -= Time.deltaTime / fadeLength;
				yield return null;
			}
		}
	}
}
