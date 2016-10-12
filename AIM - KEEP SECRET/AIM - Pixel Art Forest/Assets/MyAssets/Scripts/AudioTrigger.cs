using UnityEngine;
using System.Collections;

public class AudioTrigger : MonoBehaviour
{
    [SerializeField]
    private AudioClip   m_audio;
    [SerializeField]
    private bool        m_playAsSecondary = true;

    private AudioPlayer m_audioPlayer;

    void Awake()
    {
        m_audioPlayer = GameObject.Find("AudioPlayers").GetComponent<AudioPlayer>();
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D a_object)
    {
		if (m_audio == null)
			return;
        if (a_object.CompareTag("Player"))
        {
            if (!m_playAsSecondary)
                m_audioPlayer.SetPrimary(m_audio);
            else
                m_audioPlayer.SetSecondary(m_audio);
        }
    }

    void OnTriggerExit2D(Collider2D a_object)
    {
        if (a_object.CompareTag("Player"))
        {
            if (m_playAsSecondary)
                m_audioPlayer.PlayPrimary();
        }
    }
}
