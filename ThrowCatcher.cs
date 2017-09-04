using UnityEngine;
using System.Collections;

public class ThrowCatcher : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnTriggerEnter( Collider other )
    {
        PlayerFireController playerFire = other.GetComponent<PlayerFireController>();
        if( playerFire )
        {
            if( playerFire.m_suckHoldObject != null )
            {
                CatchableObject catchObj = playerFire.m_suckHoldObject.GetComponent<CatchableObject>();
                if (catchObj)
                {
                    BaseMonsterBrain monster = catchObj.GetComponent<BaseMonsterBrain>();
                    if(monster)
                    {
                        monster.OnAssimilation();
                    }
                    OnCatch();

                }
            }
        }

        CatchableObject catchable = other.GetComponent<CatchableObject>();
        if( catchable )
        {
            BaseMonsterBrain monster = catchable.GetComponent<BaseMonsterBrain>();
            if (monster && !monster.IsKnockedOut())
            {
                return;
            }
            else if( monster)
            {
                monster.OnAssimilation();
            }
            else
            {
                Destroy(other.gameObject);
            }
            
            OnCatch();
        }
    }

    public Animator m_AnimComp = null;

    public void OnCatch()
    {
        if( m_AnimComp )
        {
            m_AnimComp.SetTrigger("Catch");
        }
    }
}
