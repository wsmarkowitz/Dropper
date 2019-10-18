using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ActionHandler : MonoBehaviour
{
    private readonly KeyCode[] _ballIndexKeyCodes = new[]
        {KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4, KeyCode.Alpha5, KeyCode.Alpha6};

    [SerializeField] private PlayerInformation playerInformation;
    private List<PlayerAction> _playerActions;


    private void Start()
    {
        _playerActions = playerInformation.playerActions;
    }

    // Update is called once per frame
    private void Update()
    {
        BallActionFromKeyboard();
        FindLaneAction();
        FindBallSelectionAction();
        _playerActions.Clear();
    }

    // Finds the first Lane Selection Action and stores it in PlayerInformation.
    // Returns true if one is found, otherwise false
    private bool FindLaneAction()
    {
        foreach (var playerAction in _playerActions.Where(playerAction =>
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
        foreach (var playerAction in _playerActions.Where(playerAction =>
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
            _playerActions.Add(new PlayerAction
            {
                PlayerActionType = PlayerActionType.BALL_SELECTION, Index = i
            });
            return;
        }
    }
}