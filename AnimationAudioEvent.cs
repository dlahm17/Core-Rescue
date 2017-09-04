using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class AnimationAudio
{
    public AudioClip m_Clip = null;
    public float m_VolumeScale = 1f;
}

public class AnimationAudioEvent : MonoBehaviour {

    public AnimationAudio[] m_clips = new AnimationAudio[0];

    public void PlayAudioEvent()
    {
        AudioSource aud = GetComponent<AudioSource>();
        if( aud )
        {
            foreach(AnimationAudio clip in m_clips )
            {
                aud.PlayOneShot(clip.m_Clip, clip.m_VolumeScale);
            }
            
        }

    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
