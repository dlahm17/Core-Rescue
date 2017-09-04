using UnityEngine;
using System.Collections;

public class AutoDestruct : MonoBehaviour {

    public float m_Lifetime = 2f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        m_Lifetime -= Time.deltaTime;
        if( m_Lifetime <= 0f)
        {
            ReviveSpawns revival = GetComponent<ReviveSpawns>();
            if( revival && GameController.sReviveSpawns.ContainsKey(revival.mObjectId))
            {
                GameController.sReviveSpawns.Remove(revival.mObjectId);
            }

            Destroy(gameObject);
        }

    }
}
