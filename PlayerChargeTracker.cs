using UnityEngine;
using System.Collections;

public class PlayerChargeTracker : MonoBehaviour {

    public float m_MaxCharge = 100f;
    public float m_CurrentCharge = 100f;

    public ProgressRenderer m_HealthBar = null;

	public void UseCharge( float chargeUsage )
    {
        m_CurrentCharge -= chargeUsage;
        OnChargeDecreased();
    }

    public void TakeDamage( Vector3 fromDir, float damageAmt )
    {
        m_CurrentCharge -= damageAmt;
        if(m_HealthBar)
        {
            m_HealthBar.OnTakeDamage();
        }

        if (m_TimeTilNextDamageSound <= 0f && m_TakeDamageClips.Length > 0)
        {
            m_TimeTilNextDamageSound = m_DamageSoundRate;
            AudioClip playClip = m_TakeDamageClips[Random.Range(0, m_TakeDamageClips.Length)];
            AudioSource aud = GetComponent<AudioSource>();
            if (playClip && aud)
            {
                aud.PlayOneShot(playClip);
            }
        }

        OnChargeDecreased();

    }

    public AudioClip[] m_TakeDamageClips = new AudioClip[0];
    public float m_DamageSoundRate = 1f;
    public float m_TimeTilNextDamageSound = 0f;

    void OnChargeDecreased()
    {
        if (m_CurrentCharge <= 0f && GameController.sInstance)
        {
            // Notify our game controller. If we're the only player, the game is over!
            GameController.sInstance.OnPlayerDepleted(GetComponent<PlayerObject>().mObjectId);
        }
    }

    public bool IsMaxed()
    {
        return m_CurrentCharge == m_MaxCharge;
    }

    public bool IsDepleted()
    {
        return m_CurrentCharge <= 0f;
    }

    public float GetCurrentCharge()
    {
        return m_CurrentCharge;
    }

    public void RefillCharge()
    {
        m_CurrentCharge = m_MaxCharge;
    }
}
