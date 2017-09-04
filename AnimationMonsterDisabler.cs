using UnityEngine;
using System.Collections;

public class AnimationMonsterDisabler : MonoBehaviour {

	public void OnAnimStart()
    {
        BaseMonsterBrain baseBrain = transform.root.GetComponent<BaseMonsterBrain>();
        if( baseBrain )
        {
            baseBrain.m_BrainActive = false;
        }
    }

    public void OnAnimEnd()
    {
        BaseMonsterBrain baseBrain = transform.root.GetComponent<BaseMonsterBrain>();
        if (baseBrain)
        {
            baseBrain.m_BrainActive = true;
        }
    }
}
