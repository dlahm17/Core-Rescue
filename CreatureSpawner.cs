using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public enum CreatureType
{
    eCreatureTypeBasic,
    eCreatureTypeRevive,
    eCreatureTypeSpider
}

[Serializable]
public class Creature
{
    public GameObject m_PrefabObj = null;
    public int m_LevelRequirement = 0;
    public int m_MaxSpawnPerLevel = -1;
    public CreatureType m_CreatureType = CreatureType.eCreatureTypeBasic;
}

public class CreatureSpawner : MonoBehaviour {

    public Creature[] mCreatures = new Creature[0];

    public int m_CurrentLevel = 1;
    public float m_SpawnCheckRate = 10f;
    public float m_LevelTime = 30f;

    public float m_InitialDelay = 0f;

    public float m_CreaturesPerLevel = 0.5f;

    float m_currentTime = 0f;
    float m_timeTilSpawn = 0f;

    public SphereCollider m_GameBounds = null;


    // Use this for initialization
    void Start () {

        m_timeTilSpawn = m_InitialDelay;

    }
	
	// Update is called once per frame
	void Update () {

        if( !GameController.sGameStarted)
        {
            return;
        }

        m_currentTime += Time.deltaTime;
        m_timeTilSpawn -= Time.deltaTime;

        m_CurrentLevel = Mathf.FloorToInt(m_currentTime / m_LevelTime);

        if ( m_timeTilSpawn < 0f )
        {
            SpawnWave();
        }
    }

    void SpawnWave()
    {
        if(mCreatures.Length == 0)
        {
            return;
        }
        int amountToSpawn = Mathf.CeilToInt((m_CreaturesPerLevel * (float)m_CurrentLevel) + 0.1f);

        Debug.Log("Spawning " + amountToSpawn.ToString() + " creatures!" + " we have " + m_CreaturesPerLevel.ToString()) ;
        while( amountToSpawn > 0 )
        {
            Vector2 randomPos = UnityEngine.Random.insideUnitCircle;
            Vector3 spawnPos = new Vector3(randomPos.x, randomPos.y, 0f);

            spawnPos = Vector3.Normalize(spawnPos);

            if (m_GameBounds)
            {
                spawnPos *= (m_GameBounds.bounds.size.x / 2f );
            }

            int randomAccess = UnityEngine.Random.Range(0, mCreatures.Length);
            Creature spawnCreature = mCreatures[randomAccess];
            if( spawnCreature.m_LevelRequirement > m_CurrentLevel)
            {
                continue;
            }

            Instantiate(spawnCreature.m_PrefabObj, spawnPos, Quaternion.identity);

            amountToSpawn--;
        }

        m_timeTilSpawn = m_SpawnCheckRate;
    }
}
