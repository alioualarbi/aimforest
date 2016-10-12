using UnityEngine;
using System.Collections;

public class TrapTrigger : MonoBehaviour
{
    private Trap    m_trap;

    void Awake()
    {
        m_trap = transform.parent.GetComponent<Trap>();
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D a_object)
    {
        if (a_object.CompareTag("Player"))
            m_trap.Activate();
    }

    void OnTriggerStay2D(Collider2D a_object)
    {
        if (a_object.CompareTag("Player"))
            m_trap.Activate();
    }
}
