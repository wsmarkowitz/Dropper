using System.Collections.Generic;
using UnityEngine;

public class LaneHandler : MonoBehaviour
{
    private int _laneIndex = 0;
    [SerializeField] private PlayerInformation playerInformation;

    public void SetLane(int newLaneIndex)
    {
        _laneIndex = newLaneIndex;
    }
    
    private void OnMouseOver()
    {
        if (Input.GetMouseButton(0))
        {
            Color tmp = GetComponent<SpriteRenderer>().color;
            tmp.a = 0.3f;
            GetComponent<SpriteRenderer>().color = tmp;
            playerInformation.playerActions.Add(new PlayerAction
            {
                PlayerActionType = PlayerActionType.LANE_SELECTION, Index = _laneIndex
            });
        }
        else
        {
            Color tmp = GetComponent<SpriteRenderer>().color;
            tmp.a = 0f;
            GetComponent<SpriteRenderer>().color = tmp;
        }
    }

    private void OnMouseExit()
    {
        Color tmp = GetComponent<SpriteRenderer>().color;
        tmp.a = 0f;
        GetComponent<SpriteRenderer>().color = tmp;
    }
}