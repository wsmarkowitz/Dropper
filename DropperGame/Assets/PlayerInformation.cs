using System.Collections.Generic;
using UnityEngine;

public class PlayerInformation : MonoBehaviour
{
    public List<PlayerAction> playerActions = new List<PlayerAction>();
    public int? indexOfSelectedBall = null;
    public int? indexOfSelectedLane = null;
}