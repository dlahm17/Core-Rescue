using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BaseMonsterBrain : MonoBehaviour {

    public int mObjectId = 0;

    public bool m_BrainActive = true;

    public SpriteRenderer m_SpriteComp = null;

    public GameObject m_StunPrefab = null;
    public GameObject m_RevivePrefab = null;
    public GameObject m_LaserDeathPrefab = null;
    public GameObject m_ThrownDeathPrefab = null;

    public float m_MoveSpeed = 1f;
    public float m_MonsterAttackDistance = 2f;

    public float m_KnockOutHealth = 2f;

    public float m_MonsterHealthCurrent = 5f;
    public float m_MonsterHealthMax = 5f;

    public Vector3 m_DesiredMovePosition = Vector3.zero;

    public Animator m_AnimComponent = null;

    public HitReactionComp[] m_HitReactors = new HitReactionComp[0];

    public void Awake()
    {
        mObjectId = GameController.GetNextObjectId();
        GameController.sSpawnedMonsters.Add(mObjectId, this);
    }

	// Update is called once per frame
	void Update () {
        if( !GameController.sGameStarted || GameController.sGameEnded)
        {
            return;
        }

        if (IsKnockedOut())
        {
            UpdateKnockedOut();
        }
        else if (m_BrainActive)
        {
            UpdateMonsterBrain();   
        }
	}

    public virtual void UpdateMonsterBrain()
    {
        UpdateDesiredMovePoint();
        UpdateMonsterMove();
        UpdateAttack();
    }


    public bool IsKnockedOut()
    {
        return m_MonsterHealthCurrent <= m_KnockOutHealth;
    }

    public void DoDamage( float incDamage, Vector3 damageDir )
    {
        if(m_MonsterHealthCurrent <= 0f )
        {
            return;
        }

        m_MonsterHealthCurrent -= incDamage;

        foreach( HitReactionComp hitComp in m_HitReactors)
        {
            hitComp.Shake();
        }

        if(m_BrainActive && m_MonsterHealthCurrent <= m_KnockOutHealth )
        {
            OnKnockedOut(damageDir);
        }

        if( m_MonsterHealthCurrent <= 0f )
        {
            OnDeath(damageDir);
        }
    }

    public void Unregister()
    {
        GameController.sSpawnedMonsters.Remove(mObjectId);
    }

    // On Death should be called when we are turned to ash
    public void OnDeath( Vector3 damageDir )
    {
        Unregister();

        if (m_LaserDeathPrefab)
        {
            Instantiate(m_LaserDeathPrefab, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }

    public void OnKnockedOut(Vector3 damageDir)
    {
        Debug.Log("Please only happen once");
        m_TimeKnockedOut = 0f;
        if(m_StunPrefab)
        {
            Instantiate(m_StunPrefab, transform.position, Quaternion.LookRotation(damageDir));
        }
        m_BrainActive = false;

        SetStunnedState(true);
    }

    public void OnRevive()
    {
        m_MonsterHealthCurrent = m_MonsterHealthMax;
        m_BrainActive = true;
        SetStunnedState(false);

        if (m_RevivePrefab)
        {
            Instantiate(m_RevivePrefab, transform.position, Quaternion.identity);
        }
    }

    public Vector3 GetMoveDirection()
    {
        return Vector3.Normalize(m_DesiredMovePosition - transform.position);
    }

    public virtual void UpdateDesiredMovePoint()
    {
        float distanceTo = 0f;
        GameObject closest = GameController.GetClosestAttackableObject(transform.position, ref distanceTo);
        if (!closest)
        {
            return;
        }

        Vector3 dir = (transform.position - closest.transform.position );
        dir = Vector3.Normalize(dir);
        Vector3 desiredPos = (closest.transform.position) + ( dir);
        m_DesiredMovePosition = desiredPos;
    }

    public virtual Vector3 GetDesiredMovePoint()
    {
        return m_DesiredMovePosition;
    }

    public float m_MovePrecisionLeniency = 0.3f;
    public float m_KnockedOutRecoveryRate = 5f;
    float m_TimeKnockedOut = 0f;

    public void UpdateKnockedOut()
    {
        m_TimeKnockedOut += Time.deltaTime;
        if (m_TimeKnockedOut >= m_KnockedOutRecoveryRate)
        {
            OnRevive();
        }
    }

    public void UpdateMonsterMove()
    {
        if(IsKnockedOut())
        {
            UpdateKnockedOut();
            return;
        }
        Vector3 moveTo = GetDesiredMovePoint();
        Vector3 moveDir = GetMoveDirection();

        float distanceTo = Vector3.Distance(moveTo, transform.position);

        if (moveDir.x != 0f && m_SpriteComp != null)
        {
            Vector3 spriteScale = Vector3.one;
            spriteScale.x = (moveDir.x > 0f) ? 1f : -1f;
            m_SpriteComp.transform.localScale = spriteScale;
        }

        Vector3 newPosition = Vector3.MoveTowards(transform.position, moveTo, m_MoveSpeed * Time.deltaTime);
        transform.position = newPosition;
        SetAttackingState(false);
    }

    public float m_MonsterAttackDamagePerSec = 5f;

    public virtual void SetAttackingState( bool attacking )
    {
        if (m_AnimComponent)
        {
            m_AnimComponent.SetBool("IsAttacking", attacking);
        }
    }

    public virtual void SetStunnedState( bool stunned )
    {
        if( m_AnimComponent )
        {
            m_AnimComponent.SetBool("IsStunned", stunned);
        }
    }

    public void UpdateAttack()
    {
        float distanceTo = 0f;
        GameObject attackObj = GameController.GetClosestAttackableObject(transform.position, ref distanceTo);
        if(!attackObj)
        {
            SetAttackingState(false);
            
            return;
        }
        else if(distanceTo <= m_MonsterAttackDistance)
        {
            SetAttackingState(true);

            PlayerTeamObjectiveObject objective = attackObj.GetComponent<PlayerTeamObjectiveObject>();
            PlayerChargeTracker playerCharge = attackObj.GetComponent<PlayerChargeTracker>();
            if( objective )
            {
                objective.TakeDamage(Vector3.Normalize(objective.transform.position - transform.position), m_MonsterAttackDamagePerSec * Time.deltaTime);
            }
            else if(playerCharge)
            {
                playerCharge.TakeDamage(Vector3.Normalize(playerCharge.transform.position - transform.position), m_MonsterAttackDamagePerSec * Time.deltaTime);
            }
        }

    }

    public void OnThrownDeath(Vector3 damageDir)
    {
        Unregister();

        if (m_ThrownDeathPrefab)
        {
            Instantiate(m_ThrownDeathPrefab, transform.position, Quaternion.LookRotation(damageDir));
        }
        Destroy(gameObject);
    }

    public void OnAssimilation()
    {
        Unregister();
        Destroy(gameObject);
    }
}
