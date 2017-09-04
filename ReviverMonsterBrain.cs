using UnityEngine;
using System.Collections;

public class ReviverMonsterBrain : BaseMonsterBrain {

    public enum ReviveMonsterState
    {
        eMonsterStateAttacking,
        eMonsterStateReviving,
    }

    ReviveMonsterState mOurState = ReviveMonsterState.eMonsterStateAttacking;

    public override void UpdateDesiredMovePoint()
    {
        float distanceTo = 0f;
        ReviveSpawns closest = GameController.GetClosestReviveSpawn(transform.position, ref distanceTo);
        if (closest)
        {
            Vector3 dir = Vector3.Normalize(transform.position - closest.transform.position);
            Vector3 desiredPos = (closest.transform.position) + (m_MonsterAttackDistance * dir);
            m_DesiredMovePosition = desiredPos;
            mOurState = ReviveMonsterState.eMonsterStateReviving;
            return;
        }

        mOurState = ReviveMonsterState.eMonsterStateAttacking;

        base.UpdateDesiredMovePoint();
    }

    public override void UpdateMonsterBrain()
    {
        UpdateDesiredMovePoint();
        UpdateMonsterMove();
        switch( mOurState )
        {
            case ReviveMonsterState.eMonsterStateReviving:
                {
                    UpdateRevive();
                    break;
                }
            case ReviveMonsterState.eMonsterStateAttacking:
                {
                    UpdateAttack();
                    break;
                }
            default:
                break;
        }
    }

    public float m_ReviveMonsterDistance = 3f;

    public void OnReviveStart()
    {
        // We need to do an animation
        if (m_AnimComponent)
        {
            m_AnimComponent.SetTrigger("ReviveSpell");
        }

        m_BrainActive = false;
        // once we get the animation event back, we'll resume
    }

    public void OnAnimationEnd()
    {
        if( mOurState == ReviveMonsterState.eMonsterStateReviving )
        {
            float distanceTo = 0f;
            ReviveSpawns closest = GameController.GetClosestReviveSpawn(transform.position, ref distanceTo);
            if (!closest)
            {
                return;
            }
            closest.SpawnRevive();

            m_BrainActive = true;
        }
    }

    public void UpdateRevive()
    {
        float distanceTo = 0f;
        ReviveSpawns closest = GameController.GetClosestReviveSpawn(transform.position, ref distanceTo);
        if (!closest)
        {
            mOurState = ReviveMonsterState.eMonsterStateAttacking;
            return;
        }

        if( distanceTo <= m_ReviveMonsterDistance )
        {

            OnReviveStart();
        }
    }

    public override void SetAttackingState(bool attacking)
    {
        //base.SetAttackingState(attacking);
    }
}
