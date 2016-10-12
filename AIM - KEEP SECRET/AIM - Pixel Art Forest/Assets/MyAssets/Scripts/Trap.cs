using UnityEngine;
using System.Collections;

public class Trap : MonoBehaviour
{
    [SerializeField]
    private float   m_moveSpeed = 2f;

    private Vector3 m_startPos;
    private Vector3 m_finishPos;

    private bool    m_active = false;
    private bool    m_reset = true;

    private Rigidbody2D m_rigidbody;

    void Awake()
    {
        m_rigidbody = GetComponent<Rigidbody2D>();
    }

	// Use this for initialization
	void Start ()
    {
        m_startPos = transform.position;
        m_finishPos = transform.GetChild(0).position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (m_active && m_reset)
        {
            MoveToPoint();
            if (Vector3.Distance(m_rigidbody.position, m_finishPos) < 2)
            {
                m_reset = false;
                m_active = false;
            }
        }
        else
        {
            MoveBack();
            if (Vector3.Distance(m_rigidbody.position, m_startPos) < 2)
            {
                m_reset = true;
                m_active = false;
            }
        }
        
	}

    void MoveToPoint()
    {
        Vector3 position = m_rigidbody.position;

        position = Vector3.Lerp(position, m_finishPos, m_moveSpeed * Time.deltaTime);

        m_rigidbody.position = position;
    }

    void MoveBack()
    {
        Vector3 position = m_rigidbody.position;

        position = Vector3.Lerp(position, m_startPos, m_moveSpeed * Time.deltaTime);

        m_rigidbody.position = position;
    }

    public void Activate()
    {
        m_active = true;
    }

    public void OnTriggerEnter2DChild(Collider2D a_object)
    {

    }

    void OnCollisionEnter2D(Collision2D a_object)
    {
        if (a_object.collider.CompareTag("Player"))
            Application.LoadLevel(0);
    }

    void OnTriggerEnter2D(Collider2D a_object)
    {
        
        
    }
}
