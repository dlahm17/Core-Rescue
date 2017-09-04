using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BlackoutScreen : MonoBehaviour {

    public Color ClearColor;
    public Color BlackoutColor;
    public Image FadePanel;

	// Use this for initialization
	void Start () {
	
	}

    public float m_FadeTime = 1f;
    public bool m_bActiveFade = false;
    public bool m_bFadedOut = false;
    public float m_TimeInFade = 0f;

	// Update is called once per frame
	void Update () {
        if( !FadePanel)
        {
            return;
        }

        if( m_bActiveFade )
        {
            m_TimeInFade += Time.deltaTime;
            float fadePerc = Mathf.Clamp01(m_TimeInFade / m_FadeTime);
            Color newColor = FadePanel.color;
            if (m_bFadedOut)
            {
                newColor = Color.Lerp(ClearColor, BlackoutColor, fadePerc);
            }
            else
            {
                newColor = Color.Lerp(BlackoutColor, ClearColor, fadePerc);
            }
            FadePanel.color = newColor;

            if( m_TimeInFade >= m_FadeTime )
            {
                m_bActiveFade = false;
                m_TimeInFade = 0f;
            }
        }
	
	}

    public void FadeIn()
    {
        m_bActiveFade = true;
        m_TimeInFade = 0f;
        m_bFadedOut = false;
    }

    public void FadeOut()
    {
        m_bActiveFade = true;
        m_TimeInFade = 0f;
        m_bFadedOut = true;
    }
}
