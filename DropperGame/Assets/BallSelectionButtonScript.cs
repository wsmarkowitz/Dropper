using System.Collections.Generic;
using UnityEngine;

public class BallSelectionButtonScript : MonoBehaviour
{
    [SerializeField] private PlayerInformation playerInformation;
    [SerializeField] private int ballIndex;
    private List<PlayerAction> _playerActions;

    private void Start()
    {
        _playerActions = playerInformation.playerActions;
    }

    private void OnMouseDown()
    {
        {
            _playerActions.Add(new PlayerAction
            {
                PlayerActionType = PlayerActionType.BALL_SELECTION, Index = ballIndex
            });
        }
    }
}