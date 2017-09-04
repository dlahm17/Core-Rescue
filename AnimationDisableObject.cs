using UnityEngine;
using System.Collections;

public class AnimationDisableObject : MonoBehaviour {

    public void OnAnimationEnd()
    {
        gameObject.SetActive(false);
    }

    public void OnAnimationStart()
    {

    }
}
