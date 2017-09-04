using UnityEngine;
using System.Collections;

public class AnimationEndListener : MonoBehaviour {

    public GameObject m_ListeningObject = null;

    public bool m_DisableAtEnd = false;

	public void OnAnimEnd()
    {
        if(m_ListeningObject)
        {
            m_ListeningObject.SendMessage("OnAnimationEnd");
        }
        else
        {
            transform.root.SendMessage("OnAnimationEnd");
        }
        
        if(m_DisableAtEnd)
        {
            gameObject.SetActive(false);
        }
    }
}
