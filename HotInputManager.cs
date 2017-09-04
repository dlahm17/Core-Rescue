using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Rewired;

public class HotInputManager : MonoBehaviour {

    public static HotInputManager sInstance = null;

    public int[] mRegisteredPlayers = new int[0];
    public Dictionary<int, Player> mRewiredPlayers = new Dictionary<int, Player>();

    public bool m_bIsBlockingInput = true;

    void Awake()
    {
        sInstance = this;
    }

    public void OnAnimationEnd()
    {
        m_bIsBlockingInput = false;
    }

	// Use this for initialization
	void Start () {

        foreach( int playerId in mRegisteredPlayers)
        {
            mRewiredPlayers[playerId] = ReInput.players.GetPlayer(playerId);
        }

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    Player GetPlayer( int playerId )
    {
        if(m_bIsBlockingInput)
        {
            return null;
        }

        if( !mRewiredPlayers.ContainsKey(playerId))
        {
            return null;
        }
        return mRewiredPlayers[playerId];
    }

    public Vector3 GetMoveVector( int playerId )
    {
        Player use = GetPlayer(playerId);
        if( use == null )
        {
            return Vector3.zero;
        }

        Vector3 retVec = Vector3.zero;
        retVec.x = use.GetAxis("MoveHorizontal");
        retVec.y = use.GetAxis("MoveVertical");

        return retVec;
    }

    public Vector3 GetLookVector(int playerId)
    {
        Player use = GetPlayer(playerId);
        if (use == null)
        {
            return Vector3.zero;
        }

        Vector3 retVec = Vector3.zero;
        retVec.x = use.GetAxis("LookHorizontal");
        retVec.y = use.GetAxis("LookVertical");

        return retVec;
    }

    public bool GetPrimaryFire(int playerId)
    {
        Player use = GetPlayer(playerId);
        if (use == null)
        {
            return false;
        }


        return use.GetButton("FirePrimary") ;
    }

    public bool GetSecondaryFire(int playerId)
    {
        Player use = GetPlayer(playerId);
        if (use == null)
        {
            return false;
        }
        return use.GetButton("FireSecondary");
    }

    public bool GetStart(int playerId)
    {
        Player use = GetPlayer(playerId);
        if ( use == null)
        {
            return false;
        }
        return use.GetButtonDown("StartButton");
    }
}
