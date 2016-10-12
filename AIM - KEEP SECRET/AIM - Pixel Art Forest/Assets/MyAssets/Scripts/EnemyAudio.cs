using UnityEngine;
using System.Collections;

[RequireComponent (typeof(AudioSource))]
public class EnemyAudio : MonoBehaviour {
	AudioSource source;

	float _setToValue = 0;
	bool wasSetThisLateUpdate = false;

	void Start () {
		source = GetComponent<AudioSource> ();
	}

	public float setToValue {
		set {
			_setToValue = Mathf.Max (_setToValue, value);
			wasSetThisLateUpdate = true;
		}
	}

	void LateUpdate () {
		if (wasSetThisLateUpdate) {
			source.volume = _setToValue;
		} else {
			source.volume = 0;
		}
		_setToValue = 0;
		wasSetThisLateUpdate = false;
	}
}
