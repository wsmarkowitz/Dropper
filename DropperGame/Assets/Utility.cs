using System.Collections.Generic;
using BallTypes;
using UnityEngine;

public static class Utility
{
    public static List<Ball> BasicBalls()
    {
        List<Ball> ballList = new List<Ball>();
        ballList.Add(new PlasticBall());
        ballList.Add(new SteelBall());
        ballList.Add(new FireBall());
        ballList.Add(new WaterBall());
        ballList.Add(new CeramicBall());
        ballList.Add(new IceBall());
        return ballList;
    }
}