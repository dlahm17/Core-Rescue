using UnityEngine;
using System.Collections;

public class HitReactionComp : MonoBehaviour {

    public float m_HitReactShakeStrength = 1f;
    public float m_HitReactTimeTotal = 0.3f;
    public float m_HitReactTimeVariance = 0.3f;
    public float m_HitReactShakeRate = 0.05f;
    public float m_HitReactShakeRateVariance = 0.02f;

    float m_ShakeTimeLeft = 0f;
    float m_TimeTilShake = 0f;

    Vector3 originalPosition = Vector3.zero;

    void Start()
    {
        originalPosition = transform.localPosition;
    }

	// Update is called once per frame
	void Update () {
        if ( m_ShakeTimeLeft > 0f )
        {
            m_ShakeTimeLeft -= Time.deltaTime;
            m_TimeTilShake -= Time.deltaTime;
            if (m_TimeTilShake <= 0f)
            {
                Vector2 shakeAmount = Random.insideUnitCircle * m_HitReactShakeStrength;
                Vector3 shakeVec3 = new Vector3(shakeAmount.x, shakeAmount.y, 0f);
                transform.localPosition = originalPosition + shakeVec3;
            }
            
            if( m_ShakeTimeLeft <= 0f )
            {
                transform.localPosition = originalPosition;
            }
        }
	}

    public void Shake()
    {
        m_ShakeTimeLeft = Random.Range(m_HitReactTimeTotal - m_HitReactTimeVariance, m_HitReactTimeTotal + m_HitReactTimeVariance);
    }
}
