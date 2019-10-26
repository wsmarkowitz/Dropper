using System.Runtime.Versioning;
using UnityEngine;

namespace BallTypes
{
    public abstract class Ball
    {
        private string BallSpriteFilePath;
        private string BallButtonSpriteFilePath;
        private string ActiveBallButtonSpriteFilePath;
        private Element ElementType;
        private Sprite BallSprite;
        private Sprite BallButtonSprite;
        private Sprite ActiveBallButtonSprite;

        protected Ball(string ballSpriteFilePath, Element element, string ballButtonSpriteFilePath, string activeBallButtonSpriteFilePath)
        {
            BallSpriteFilePath = ballSpriteFilePath;
            BallButtonSpriteFilePath = ballButtonSpriteFilePath;
            ActiveBallButtonSpriteFilePath = activeBallButtonSpriteFilePath;
            ElementType = element;
            BallSprite = Resources.Load<Sprite>(BallSpriteFilePath);
            BallButtonSprite = Resources.Load<Sprite>(BallButtonSpriteFilePath);
            ActiveBallButtonSprite = Resources.Load<Sprite>(ActiveBallButtonSpriteFilePath);
        }

        public Element GetElementType()
        {
            return ElementType;
        }
        
        public Sprite GetBallSprite()
        {
            return BallSprite;
        }
        
        public Sprite GetBallButtonSprite()
        {
            return BallButtonSprite;
        }
        
        public Sprite GetActiveBallButtonSprite()
        {
            return ActiveBallButtonSprite;
        }
    }
}