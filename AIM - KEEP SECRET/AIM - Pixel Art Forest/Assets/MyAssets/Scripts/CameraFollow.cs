using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform   m_target;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 position = transform.position;
        position.x = m_target.position.x;
        position.y = m_target.position.y;
        transform.position = position;
	}
}
