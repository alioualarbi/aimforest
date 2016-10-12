using UnityEngine;
using System.Collections;

public class ChasePlayer : MonoBehaviour
{
    private bool    m_chasePlayer = false;
    [SerializeField]
    private float   m_moveSpeed = 5f;
    [SerializeField]
    private float   m_chaseTime = 3f;
    private float   m_chaseTimer = 0;
    [SerializeField]
    private float   m_cooldownTime = 2f;
    private float   m_cooldownTimer = 0;

    private GameObject  m_player;

    void Awake()
    {
        m_player = GameObject.Find("Player");
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        MoveToPlayer();
	}

    void MoveToPlayer()
    {
        if (m_chasePlayer == false)
            return;

        if (m_cooldownTimer <= 0)
        {
            if (m_chaseTimer < m_chaseTime)
            {
                m_chaseTimer += Time.deltaTime;
                // Move to
                transform.position = Vector2.MoveTowards(transform.position, m_player.transform.position, m_moveSpeed * Time.deltaTime);
                // Look at
                Vector3 direction = m_player.transform.position - transform.position;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }
            else if (m_chaseTimer >= m_chaseTime)
            {
                m_chaseTimer = 0;
                m_cooldownTimer = m_cooldownTime;
            }
        }
        else if (m_cooldownTimer > 0)
        {
            m_cooldownTimer -= Time.deltaTime;
        }
    }

    public void SetChasePlayer(bool a_state) { m_chasePlayer = a_state; }

    void OnCollisionEnter2D(Collision2D a_object)
    {
        if (a_object.collider.CompareTag("Player"))
            Application.LoadLevel(0);
    }
}
