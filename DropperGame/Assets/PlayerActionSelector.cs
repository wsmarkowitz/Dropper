using System;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

/**
 * TODO (after Ball Selection UI put in place):
 * Implement clicking on ball selector on keyboard
 * Implement tapping on ball selector on phone
 */

public class PlayerActionSelector : MonoBehaviour
{
    private readonly KeyCode[] _ballIndexKeyCodes = new[]
        {KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4, KeyCode.Alpha5, KeyCode.Alpha6};

    [SerializeField] public List<PlayerAction> playerActions = new List<PlayerAction>();

    // Update is called once per frame
    void Update()
    {
        playerActions.Clear();
        BallActionFromKeyboard();
        LaneActionFromMouse();
    }

    void BallActionFromKeyboard()
    {
        for (var i = 0; i < _ballIndexKeyCodes.Length; i++)
        {
            if (Input.GetKey(_ballIndexKeyCodes[i]))
            {
                playerActions.Add(new PlayerAction
                {
                    PlayerActionType = PlayerActionType.BALL_SELECTION, Index = i
                });
                return;
            }
        }
    }

    void LaneActionFromMouse()
    {
        List<Rect> rects = Utility.GetLaneRects();
        for (int i = 0; i < rects.Count; i++)
        {
            if (Input.GetMouseButton(0) && rects[i].Contains(Input.mousePosition))
            {
                playerActions.Add(new PlayerAction
                {
                    PlayerActionType = PlayerActionType.LANE_SELECTION, Index = i
                });
                return;
            }
        }
    }

    void LaneActionFromTouch()
    {
        List<Rect> rects = Utility.GetLaneRects();
        foreach (var touch in Input.touches)
        {
            for (int i = 0; i < rects.Count; i++)
            {
                if (rects[i].Contains(touch.position))
                {
                    playerActions.Add(new PlayerAction
                    {
                        PlayerActionType = PlayerActionType.LANE_SELECTION, Index = i
                    });
                    return;
                }
            }
        }
    }
}