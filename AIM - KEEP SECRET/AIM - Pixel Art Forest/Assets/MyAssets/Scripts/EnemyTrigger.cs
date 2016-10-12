using UnityEngine;
using System.Collections;

public class EnemyTrigger : MonoBehaviour {
	private ChasePlayer m_chasePlayer;

	void Awake () {
		m_chasePlayer = transform.parent.GetComponent<ChasePlayer> ();
	}

	void OnTriggerEnter2D (Collider2D a_object) {
		if (a_object.CompareTag ("Player"))
			m_chasePlayer.SetChasePlayer (true);
	}

	void OnTriggerExit2D (Collider2D a_object) {
		if (a_object.CompareTag ("Player"))
			m_chasePlayer.SetChasePlayer (false);
	}
}
