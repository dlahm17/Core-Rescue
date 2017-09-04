using UnityEngine;
using System.Collections;

public class WireSetToggle : MonoBehaviour {

    public Animator[] mToggleWires = new Animator[0];

    public void SetWiresActive( bool newActive )
    {
        foreach( Animator wireAnim in mToggleWires )
        {
            wireAnim.SetBool("WirePowered", newActive);
        }
    }
}
