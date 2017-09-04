using UnityEngine;
using System.Collections;

public class ReviveSpawns : MonoBehaviour {

    public int mObjectId = 0;

    public GameObject m_RevivePrefab = null;

	// Use this for initialization
	void Start () { 

        mObjectId = GameController.GetNextObjectId();
        GameController.sReviveSpawns.Add(mObjectId, this);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SpawnRevive()
    {
        if( !m_RevivePrefab)
        {
            return;
        }

        Instantiate(m_RevivePrefab, transform.position, Quaternion.identity);

        GameController.sReviveSpawns.Remove(mObjectId);

        Destroy(gameObject);
    }
}
