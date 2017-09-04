using UnityEngine;
using System.Collections;

public class GameBounds : MonoBehaviour {

    public static GameBounds sBounds = null;

	// Use this for initialization
	void Start () {

        sBounds = this;

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public float m_DefaultRadius = 100f;

    public float GetGameRadius()
    {
        SphereCollider spher = GetComponent<SphereCollider>();
        if( !spher )
        {
            return m_DefaultRadius;
        }

        return spher.bounds.size.x / 2f;
    }
}
