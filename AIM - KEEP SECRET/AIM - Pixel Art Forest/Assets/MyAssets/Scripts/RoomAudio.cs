using UnityEngine;
using System.Collections;

[RequireComponent (typeof(AudioSource))]
public class RoomAudio : MonoBehaviour {
	RoomAudio[] roomAudios;
	AudioSource source;
	public float fadeBetweenTime = 0.2f;
	public float maxVolume = 1;
	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource> ();
		roomAudios = GameObject.FindObjectsOfType<RoomAudio> ();
	}

	void OnTriggerEnter2D (Collider2D a_object) {
		for (int i = 0; i < roomAudios.Length; i++) {
			roomAudios [i].StopAllCoroutines ();
		}
		if (a_object.CompareTag ("Player")) {
			StartCoroutine ("FadeVolume");
		}
	}

	IEnumerator FadeVolume () {
		float timer = 0;
		float[] fadeFrom = new float[roomAudios.Length];
		for (int i = 0; i < roomAudios.Length; i++) {
			fadeFrom [i] = roomAudios [i].source.volume;
		}

		while (timer < fadeBetweenTime) {
			float t = timer / fadeBetweenTime;
			for (int i = 0; i < roomAudios.Length; i++) {
				roomAudios [i].source.volume = Mathf.Lerp (fadeFrom [i], roomAudios [i] == this ? maxVolume : 0, t);
			}
			timer += Time.deltaTime;
			yield return null;
		}

		for (int i = 0; i < roomAudios.Length; i++) {
			roomAudios [i].source.volume = roomAudios [i] == this ? maxVolume : 0;
		}
	}
}
