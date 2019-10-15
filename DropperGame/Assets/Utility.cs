using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public static class Utility
    {
        public static List<Rect> GetLaneRects()
        {
            List<Rect> rects = new List<Rect>();
            for (int i = 0; i < Config.NUMBER_OF_LANES; i++)
            {
                float width = ((float) Screen.width) / Config.NUMBER_OF_LANES;
                rects.Add(new Rect(((float) i * width), 0, width,
                    Screen.height));
            }

            return rects;
        }
    }
}