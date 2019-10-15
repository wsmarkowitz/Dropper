using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class LaneHighlighter : MonoBehaviour
{
    [SerializeField] private PlayerActionSelector playerActionSelector;
    private List<PlayerAction> playerActions;

    private void Start()
    {
        playerActions = playerActionSelector.playerActions;
    }

// Update is called once per frame
    void OnGUI()
    {
        List<Rect> rects = Utility.GetLaneRects();
        foreach (PlayerAction playerAction in playerActions)
        {
            if (playerAction.PlayerActionType == PlayerActionType.LANE_SELECTION)
            {
                Render_Colored_Rectangle(rects[playerAction.Index]);
            }
        }
    }

    private void Render_Colored_Rectangle(Rect rect)
    {
        Texture2D rgbTexture = new Texture2D((int) rect.width, (int) rect.height);
        Color rgbColor = new Color(255, 255, 255, 0.3f);

        int i, j;
        for (i = 0;
            i < rect.width;
            i++)
        {
            for (j = 0; j < rect.height; j++)
            {
                rgbTexture.SetPixel(i, j, rgbColor);
            }
        }

        rgbTexture.Apply();
        GUIStyle genericStyle = new GUIStyle();
        GUI.skin.box = genericStyle;
        GUI.Box(rect, rgbTexture);
    }
}