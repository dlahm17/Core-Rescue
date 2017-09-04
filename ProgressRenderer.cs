using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ProgressRenderer : MonoBehaviour {

    public Image m_ImageComp = null;
    public PlayerChargeTracker m_TrackedResource = null;
    public HitReactionComp m_HitReactor = null;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if( m_ImageComp && m_TrackedResource)
        {
            float imagePercent = m_TrackedResource.m_CurrentCharge / m_TrackedResource.m_MaxCharge;

            m_ImageComp.fillAmount = imagePercent;
        }
	
	}

    public void OnTakeDamage()
    {
        if( m_HitReactor )
        {
            m_HitReactor.Shake();
        }
    }
}
