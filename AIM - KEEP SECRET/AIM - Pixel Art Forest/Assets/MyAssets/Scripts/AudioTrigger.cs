using UnityEngine;
using System.Collections;

[RequireComponent (typeof(CircleCollider2D))]
public class AudioTrigger : MonoBehaviour {
	public EnemyAudio enemyAudio;
	CircleCollider2D _circleCollider;
	public AnimationCurve distanceCurve = AnimationCurve.Linear (0, 0, 1, 1);

	public CircleCollider2D circleCollider {
		get {
			if (_circleCollider == null)
				_circleCollider = GetComponent<CircleCollider2D> ();
			return _circleCollider;
		}
	}

	void OnTriggerStay2D (Collider2D a_object) {
		if (enemyAudio == null)
			return;
		if (a_object.CompareTag ("Player")) {
			enemyAudio.setToValue = distanceCurve.Evaluate (1 - Mathf.InverseLerp (0, circleCollider.radius * transform.lossyScale.magnitude, Vector2.Distance (V3To2 (transform.position) + circleCollider.offset, V3To2 (a_object.transform.position))));
		}
	}

	Vector2 V3To2 (Vector3 v) {
		return new Vector2 (v.x, v.y);
	}
}
