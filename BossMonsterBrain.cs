using UnityEngine;
using System.Collections;

public class BossMonsterBrain : BaseMonsterBrain {

    public override void SetStunnedState(bool stunned)
    {
        // No stun for bosses
        //base.SetStunnedState(stunned);
    }

}
