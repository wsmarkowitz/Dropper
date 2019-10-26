using System;
using System.Collections.Generic;
using UnityEngine;

public class BallSelectionButtonScript : MonoBehaviour
{
    public PlayerInformation playerInformation;
    public int ballIndex;
    public Sprite defaultSprite;
    public Sprite activeSprite;
    private List<PlayerAction> _playerActions;
    private SpriteRenderer _spriteRenderer;
    private float timer = 0f;
    private float cooldown = 3f;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _playerActions = playerInformation.playerActions;
    }

    private void Update()
    {
        timer = Math.Max(0, timer - Time.deltaTime);
        _spriteRenderer.sprite =
            (playerInformation.indexOfSelectedBall != null && playerInformation.indexOfSelectedBall == ballIndex)
                ? activeSprite
                : defaultSprite;
        if (timer > 0)
        {
            _spriteRenderer.color = new Color(.5f + .5f * (cooldown - timer) / cooldown,
                .5f + .5f * (cooldown - timer) / cooldown, .5f + .5f * (cooldown - timer) / cooldown);
        }
        else
        {
            _spriteRenderer.color = Color.white;
        }
    }

    private void OnMouseDown()
    {
        _playerActions.Add(new PlayerAction
        {
            PlayerActionType = PlayerActionType.BALL_SELECTION, Index = ballIndex
        });
    }

    public void StartCooldown()
    {
        timer = cooldown;
    }

    public bool IsOnCooldown()
    {
        return timer > 0;
    }
}