using UnityEngine;
using System.Collections;

public class AnimationRootController : MonoBehaviour {

    bool m_bIsAnimRooted = false;

    public void StartRoot()
    {
        m_bIsAnimRooted = true;
    }

    public void EndRoot()
    {
        m_bIsAnimRooted = false;
    }

	public bool IsAnimRooted()
    {
        return m_bIsAnimRooted;
    }
}
