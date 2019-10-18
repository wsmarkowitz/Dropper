using System;
using System.Collections.Generic;
using System.Linq;
using BallTypes;
using UnityEngine;

public class ActionHandler : MonoBehaviour
{
    private readonly KeyCode[] _ballIndexKeyCodes = new[]
        {KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4, KeyCode.Alpha5, KeyCode.Alpha6};

    [SerializeField] private PlayerInformation playerInformation;
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private GameObject lanesGameObject;
    [SerializeField] private GameObject ballButtonsParent;

    private List<Transform> _lanes = new List<Transform>();

    // Update is called once per frame
    private void Update()
    {
        BallActionFromKeyboard();
        FindLaneAction();
        FindBallSelectionAction();
        DropBall();
        playerInformation.playerActions.Clear();
        playerInformation.indexOfSelectedLane = null;
    }

    // Finds the first Lane Selection Action and stores it in PlayerInformation.
    // Returns true if one is found, otherwise false
    private bool FindLaneAction()
    {
        foreach (var playerAction in playerInformation.playerActions.Where(playerAction =>
            playerAction.PlayerActionType.Equals(PlayerActionType.LANE_SELECTION)))
        {
            playerInformation.indexOfSelectedLane = playerAction.Index;
            return true;
        }

        return false;
    }

    // Finds the first Ball Selection Action and stores it in PlayerInformation.
    // Returns true if one is found, otherwise false
    private bool FindBallSelectionAction()
    {
        foreach (var playerAction in playerInformation.playerActions.Where(playerAction =>
            playerAction.PlayerActionType.Equals(PlayerActionType.BALL_SELECTION)))
        {
            playerInformation.indexOfSelectedBall = playerAction.Index;
            return true;
        }

        return false;
    }

    private void BallActionFromKeyboard()
    {
        for (var i = 0; i < _ballIndexKeyCodes.Length; i++)
        {
            if (!Input.GetKey(_ballIndexKeyCodes[i])) continue;
            playerInformation.playerActions.Add(new PlayerAction
            {
                PlayerActionType = PlayerActionType.BALL_SELECTION, Index = i
            });
            return;
        }
    }

    private void DropBall()
    {
        if (playerInformation.indexOfSelectedLane == null) return;
        if (playerInformation.indexOfSelectedBall == null) return;
        BallSelectionButtonScript ballSelectionButtonScript = ballButtonsParent.transform
            .GetChild((int) playerInformation.indexOfSelectedBall).GetComponent<BallSelectionButtonScript>();
        if (ballSelectionButtonScript.IsOnCooldown()) return;
        Sprite newBallSprite = playerInformation.listOfBallOptions[(int) playerInformation.indexOfSelectedBall]
            .GetBallSprite();
        GameObject ball = Instantiate(ballPrefab);
        ball.transform.localScale = new Vector3(0.7f, 0.7f, 1);
        ball.transform.SetParent(lanesGameObject.transform.GetChild((int) playerInformation.indexOfSelectedLane));
        ball.transform.localPosition = new Vector3(0, 0.6f, 0);
        ball.GetComponent<SpriteRenderer>().sprite = newBallSprite;
        ballSelectionButtonScript.StartCooldown();
    }
}