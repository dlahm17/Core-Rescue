using UnityEngine;
using System.Collections;

public enum AimDirection
{
    eAimDirectionN,
    eAimDirectionNE,
    eAimDirectionE,
    eAimDirectionSE,
    eAimDirectionS,
    eAimDirectionSW,
    eAimDirectionW,
    eAimDirectionNW,
    eAimDirectionCount,
}

public class PlayerAimController : MonoBehaviour {

    public int mPlayerId = 0;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        UpdateAim();
    }

    float verticalAim = 0f;
    float horizontalAim = 0f;

    public string VerticalAimStr;
    public string HorizontalAimStr;

    public Transform AimTransform = null;

    public Vector3 CurrentAim = Vector3.zero;



    public void UpdateAim()
    {
        if( !HotInputManager.sInstance)
        {
            return;
        }
        Vector3 inputAimVec = HotInputManager.sInstance.GetLookVector(mPlayerId);

        verticalAim = inputAimVec.y;
        horizontalAim = inputAimVec.x;

        if (verticalAim == 0f && horizontalAim == 0f)
        {
            return;
        }

        GetAimDirection();

        CurrentAim.x = horizontalAim;
        CurrentAim.y = verticalAim;

        CurrentAim = Vector3.Normalize(CurrentAim);

        if( AimTransform )
        {
            AimTransform.position = transform.position + CurrentAim;
        }
    }

    public float GetDirection()
    {
        Vector3 referenceForward = Vector3.up;

        Vector3 referenceRight = Vector3.Cross(Vector3.forward, referenceForward);
        Vector3 newDirection = CurrentAim;

        float angle = Vector3.Angle(newDirection, referenceForward);
        float sign = Mathf.Sign(Vector3.Dot(newDirection, referenceRight));
        float finalAngle = sign * angle;

        return finalAngle;
    }

    public float GetAngleForDirection( AimDirection checkDir )
    {
        switch( checkDir)
        {
            case AimDirection.eAimDirectionN:
                {
                    return 0f;
                }
            case AimDirection.eAimDirectionNE:
                {
                    return -45f;
                }
            case AimDirection.eAimDirectionNW:
                {
                    return 45;
                }
            case AimDirection.eAimDirectionS:
                {
                    return 180f;
                }
            case AimDirection.eAimDirectionSE:
                {
                    return -135f;
                }
            case AimDirection.eAimDirectionSW:
                {
                    return 135f;
                }
            case AimDirection.eAimDirectionE:
                {
                    return -90f;
                }
            case AimDirection.eAimDirectionW:
                {
                    return 90f;
                }
            default:
                return 0f;
        }
    }


    public AimDirection GetAimDirection()
    {
        float timeBetween = (360f / (float)(AimDirection.eAimDirectionCount));
        float spaceForEachHalf = timeBetween / 2f;

        float angle = GetDirection();

        for (int i = 0; i < (int)AimDirection.eAimDirectionCount; i++ )
        {
            float directionAngle = GetAngleForDirection((AimDirection)i);
            float checkDirMin = directionAngle - spaceForEachHalf;
            float checkDirMax = directionAngle + spaceForEachHalf;

            if ( angle >= checkDirMin && angle <= checkDirMax)
            {
                return (AimDirection)(i);
            }
        }

        return AimDirection.eAimDirectionS;
    }

    public Vector3 GetAimOrigin()
    {
        return transform.position + GetAimVector();
    }

    public Vector3 GetAimVector()
    {
        return CurrentAim;
    }
}
