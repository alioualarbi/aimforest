using UnityEngine;
using System.Collections;

public class Immovable : MonoBehaviour
{
    private Vector3 m_startPos;

    void Awake()
    {

    }
	// Use this for initialization
	void Start ()
    {
        m_startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = m_startPos;
	}

    void OnTriggerEnter2D(Collider2D a_object)
    {
    }
}
