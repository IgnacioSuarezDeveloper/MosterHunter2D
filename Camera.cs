using Microsoft.Xna.Framework;

namespace MonoGame
{
    internal class Camera
    {
        public Matrix Transform { get; private set; }
        public Vector2 Position { get; private set; }

        private int _screenWidth;
        private int _screenHeight;

        public Camera(int screenWidth, int screenHeight)
        {
            _screenWidth = screenWidth;
            _screenHeight = screenHeight;
        }

        public void Follow(Vector2 targetPosition)
        {
            Position = targetPosition;

            Transform =
                Matrix.CreateTranslation(
                    -Position.X,
                    -Position.Y,
                    0) *

                Matrix.CreateTranslation(
                    _screenWidth / 2f,
                    _screenHeight / 2f,
                    0);
        }
    }
}
