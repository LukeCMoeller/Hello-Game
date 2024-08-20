using System.Transactions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Hello_Game
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D _ATexture;
        private Vector2 _APosition;
        private Vector2 _AVelocity;
        private bool _isFlip;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _APosition = new Vector2(_graphics.GraphicsDevice.Viewport.Width / 2 - 55, _graphics.GraphicsDevice.Viewport.Height / 2 - 55);
            System.Random random = new System.Random();
            _AVelocity = new Vector2((float)random.NextDouble(), (float)random.NextDouble());
            _AVelocity.Normalize();
            _AVelocity *= 100;
            _isFlip = false;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            _ATexture = Content.Load<Texture2D>("A");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            _APosition += _AVelocity * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (_APosition.X < _graphics.GraphicsDevice.Viewport.X || _APosition.X > _graphics.GraphicsDevice.Viewport.Width - 110)
            {
                _AVelocity.X *= -1;
                _isFlip = !_isFlip;
            }

            if (_APosition.Y < _graphics.GraphicsDevice.Viewport.Y || _APosition.Y > _graphics.GraphicsDevice.Viewport.Height - 110)
            {
                _AVelocity.Y *= -1;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            SpriteEffects flipEffect = SpriteEffects.None;
            if (_isFlip == true)
            {
                 flipEffect = SpriteEffects.FlipHorizontally;
            }
            _spriteBatch.Draw(_ATexture, _APosition, null, Color.White, 0f, Vector2.Zero, 1f, flipEffect, 0f);

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
