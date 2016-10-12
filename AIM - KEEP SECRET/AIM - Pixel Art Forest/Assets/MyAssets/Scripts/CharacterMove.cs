using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Rigidbody2D))]
public class CharacterMove : MonoBehaviour {
	[SerializeField]
	private float m_moveSpeed;
	[SerializeField]
	private float m_sprintMultiplier = 1.4f;

	private Animator m_animator;

	private Rigidbody2D m_rigidbody;

	void Awake () {
		m_rigidbody = GetComponent<Rigidbody2D> ();
		m_animator = transform.GetChild (0).GetComponent<Animator> ();
	}

	void FixedUpdate () {
		InputUpdate ();
	}

	void InputUpdate () {
		Vector3 pos = m_rigidbody.position;

		if (Input.GetKey (KeyCode.W) && Input.GetKey (KeyCode.LeftShift)) {
			pos.y += m_moveSpeed * m_sprintMultiplier * Time.deltaTime;
		} else if (Input.GetKey (KeyCode.W)) {
			pos.y += m_moveSpeed * Time.deltaTime;
		}
		if (Input.GetKeyDown (KeyCode.W))
			m_animator.SetTrigger ("Up");

		if (Input.GetKey (KeyCode.S) && Input.GetKey (KeyCode.LeftShift)) {
			pos.y -= m_moveSpeed * m_sprintMultiplier * Time.deltaTime;
		} else if (Input.GetKey (KeyCode.S)) {
			pos.y -= m_moveSpeed * Time.deltaTime;
		}
		if (Input.GetKeyDown (KeyCode.S))
			m_animator.SetTrigger ("Down");

		if (Input.GetKey (KeyCode.D) && Input.GetKey (KeyCode.LeftShift)) {
			pos.x += m_moveSpeed * m_sprintMultiplier * Time.deltaTime;
		} else if (Input.GetKey (KeyCode.D)) {
			pos.x += m_moveSpeed * Time.deltaTime;
		}
		if (Input.GetKeyDown (KeyCode.D))
			m_animator.SetTrigger ("Right");

		if (Input.GetKey (KeyCode.A) && Input.GetKey (KeyCode.LeftShift)) {
			pos.x -= m_moveSpeed * m_sprintMultiplier * Time.deltaTime;
		} else if (Input.GetKey (KeyCode.A)) {
			pos.x -= m_moveSpeed * Time.deltaTime;
		}
		if (Input.GetKeyDown (KeyCode.A))
			m_animator.SetTrigger ("Left");

		m_rigidbody.position = pos;
	}
}
