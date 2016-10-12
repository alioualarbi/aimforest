using UnityEngine;
using System.Collections;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField]
    private AudioSource[]   m_audioSources;

    [SerializeField]
    private float   m_fadeSpeed = 2f;

    private bool    m_playPrimary = true;

    void Awake()
    {

    }
	// Use this for initialization
	void Start ()
    {
        m_audioSources[0].Play();
        m_audioSources[1].Play();
		m_audioSources[2].Play();

        m_audioSources[1].volume = 0;
		m_audioSources[2].volume = 0;
			}
	
	// Update is called once per frame
	void Update ()
    {
        //if (m_audioSources[0].volume < 0.01f)
        //    m_audioSources[0].Stop();
        //if (m_audioSources[1].volume < 0.01f)
        //    m_audioSources[1].Stop();

        if (m_playPrimary)
        {
            FadeIn(m_audioSources[0]);
            FadeOut(m_audioSources[1]);
			FadeOut(m_audioSources[2]);
        }
        else
        {
            FadeIn(m_audioSources[1]);
			FadeIn(m_audioSources[2]);
            FadeOut(m_audioSources[0]);
        }
	}

    /// <summary>
    /// Takes in an AudioSource to be faded in.
    /// </summary>
    /// <param name="a_track"></param>
    void FadeIn(AudioSource a_track)
    {
        a_track.volume = Mathf.Lerp(a_track.volume, 1, m_fadeSpeed * Time.deltaTime);
    }
    /// <summary>
    /// Takes in an AudioSource to be faded out.
    /// </summary>
    /// <param name="a_track"></param>
    void FadeOut(AudioSource a_track)
    {
        a_track.volume = Mathf.Lerp(a_track.volume, 0, m_fadeSpeed * Time.deltaTime);
    }

    public void SetPrimary(AudioClip a_clip)
    {
        if (m_audioSources[0].clip == null)
        {
            m_audioSources[0].clip = a_clip;
        }
        else if (m_audioSources[0].clip.name != a_clip.name)
        {
            m_audioSources[0].clip = a_clip;
            m_audioSources[0].Play();
            m_playPrimary = true;
        }
        if (!m_audioSources[0].isPlaying)
        {
            m_audioSources[0].Play();
            m_playPrimary = true;
        }
        m_playPrimary = true;

    }

    public void SetSecondary(AudioClip a_clip)
    {
        if (m_audioSources[1].clip == null)
        {
            m_audioSources[1].clip = a_clip;
        }
		if (m_audioSources[2].clip == null)
		{
			m_audioSources[2].clip = a_clip;
		}
        

        if (!m_audioSources[1].isPlaying)
        {
            m_audioSources[1].Play();
            m_playPrimary = false;
        }
        m_playPrimary = false;

		if (!m_audioSources[2].isPlaying)
		{
			m_audioSources[2].Play();
			m_playPrimary = false;
		}
		m_playPrimary = false;
    }



    public void PlayPrimary() { m_playPrimary = true; }
}
