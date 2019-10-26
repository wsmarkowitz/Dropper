using System.Collections.Generic;
using BallTypes;
using UnityEngine;

public class BallButtonInitializer : MonoBehaviour
{
    [SerializeField] private GameObject ballButtonPrefab;
    [SerializeField] private PlayerInformation playerInformation;
    [SerializeField] private GameObject ballButtonParent;

    private void Start()
    {
        List<Ball> balls = playerInformation.listOfBallOptions;
        for (int i = 0; i < Config.NUMBER_OF_BALLS; i++)
        {
            GameObject ballButton = Instantiate(ballButtonPrefab, ballButtonParent.transform);
            Vector3 pos = ballButton.transform.localPosition;
            pos.x += 0.88f * i;
            ballButton.transform.localPosition = pos;
            ballButton.GetComponent<BallSelectionButtonScript>().playerInformation = playerInformation;
            ballButton.GetComponent<BallSelectionButtonScript>().ballIndex = i;
            ballButton.GetComponent<BallSelectionButtonScript>().activeSprite = balls[i].GetActiveBallButtonSprite();
            ballButton.GetComponent<BallSelectionButtonScript>().defaultSprite = balls[i].GetBallButtonSprite();
        }
    }
}