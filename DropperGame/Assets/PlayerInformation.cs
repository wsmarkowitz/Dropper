using System;
using System.Collections.Generic;
using BallTypes;
using UnityEngine;

public class PlayerInformation : MonoBehaviour
{
    public List<PlayerAction> playerActions = new List<PlayerAction>();
    public int? indexOfSelectedBall = null;
    public int? indexOfSelectedLane = null;
    public List<Ball> listOfBallOptions;

    private void Awake()
    {
        listOfBallOptions = Utility.BasicBalls();
    }
}