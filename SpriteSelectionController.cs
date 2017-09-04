using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public enum SelectionType
{
    eSelectionAim,
    eSelectionMove
}

[Serializable]
public class SpriteSelection
{
    public AimDirection spriteDirection;
    public Sprite spriteSelection;
}

public class SpriteSelectionController : MonoBehaviour {

    public AimDirection currentDirection;
    public SelectionType mSpriteSelType = SelectionType.eSelectionAim;
    public SpriteSelection[] spriteSelections = new SpriteSelection[0];
    Dictionary<AimDirection, SpriteSelection> m_directionalSprites = new Dictionary<AimDirection, SpriteSelection>();

    // Use this for initialization
    void Start () {

        foreach (SpriteSelection sprite in spriteSelections)
        {
            if( m_directionalSprites.ContainsKey(sprite.spriteDirection))
            {
                Debug.LogError("Attempt to use the same direction twice");
                continue;
            }

            m_directionalSprites.Add(sprite.spriteDirection, sprite);
        }
	
	}

    public GameObject rootObj = null;

    public bool bVerboseLogging = false;

	// Update is called once per frame
	void Update () {

        if( !rootObj )
        {
            rootObj = transform.root.gameObject;
            return;
        }

        switch(mSpriteSelType)
        {
            case SelectionType.eSelectionAim:
                {
                    PlayerAimController playerAimControl = rootObj.GetComponent<PlayerAimController>();
                    if( playerAimControl)
                    {
                        currentDirection = playerAimControl.GetAimDirection();
                    }
                    break;
                }
            case SelectionType.eSelectionMove:
                {
                    PlayerMoveController playerMove = rootObj.GetComponent<PlayerMoveController>();
                    if(playerMove)
                    {
                        currentDirection = playerMove.GetAimDirection();
                    }
                    break;
                }
        }
        if(m_directionalSprites.ContainsKey(currentDirection))
        {
            SpriteRenderer spriteRender = GetComponent<SpriteRenderer>();
            if(spriteRender)
            {
                SpriteSelection chosen = m_directionalSprites[currentDirection];
                spriteRender.sprite = chosen.spriteSelection;
            }
            
        }

        if(bVerboseLogging)
        {
            Debug.Log("Current direction :" + currentDirection.ToString());
        }
        
    }
}
