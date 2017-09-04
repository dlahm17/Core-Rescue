using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GamePanelManager : MonoBehaviour {

    public GameObject m_playerOneHealthPanel = null;
    public GameObject m_playerTwoHealthPanel = null;
    public GameObject m_menuPanel = null;
    public GameObject m_gameOverPanel = null;

	// Update is called once per frame
	void Update () {
        if ( GameController.sGameEnded )
        {
            if( m_gameOverPanel != null )
            {
                m_gameOverPanel.SetActive(true);
            }
            if (m_menuPanel != null)
            {
                m_menuPanel.SetActive(false);
            }
        }
        else if( !GameController.sGameStarted )
        {
            if( m_menuPanel != null )
            {
                m_menuPanel.SetActive(true);
            }
            if (m_gameOverPanel != null)
            {
                m_gameOverPanel.SetActive(false);
            }
        }
        else
        {
            if( GameController.sActivePlayers.ContainsKey(0))
            {
                if (m_playerOneHealthPanel)
                {
                    m_playerOneHealthPanel.SetActive(true);
                }
            }
            if (GameController.sActivePlayers.ContainsKey(1))
            {
                if (m_playerTwoHealthPanel)
                {
                    m_playerTwoHealthPanel.SetActive(true);
                }
            }

            

            if (m_menuPanel != null)
            {
                m_menuPanel.SetActive(false);
            }
            if (m_gameOverPanel != null)
            {
                m_gameOverPanel.SetActive(false);
            }
        }
	
	}
}
