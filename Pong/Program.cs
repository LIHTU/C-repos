using Otter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ScenesAndEntities
{
  class Program
  {
    static void Main(string[] args)
    {
      // Create a new game
      var gameWidth = 1280;
      var gameHeight = 940;
      var game = new Game("Scenes and Entities", gameWidth, gameHeight);

      // create entities
      var ballRad = 20;
      var paddleHt = 100;
      var paddleWd = 20;

     
      // Add a PlayerEntity to the Scene at half of the Game's width, and half of the Game's height (centered)
      // scene.Add(new PlayerEntity(Game.Instance.HalfWidth, Game.Instance.HalfHeight));

      var ball = new Entity(Game.Instance.HalfWidth - ballRad, Game.Instance.HalfHeight - ballRad);
      ball.AddGraphic(Image.CreateCircle(ballRad, Color.White));

      var paddle1 = new PlayerEntity(1, 40, gameHeight / 2 - paddleHt / 2);
      paddle1.AddGraphic(Image.CreateRectangle(paddleWd, paddleHt, Color.Red));
      var paddle2 = new PlayerEntity(2, 1220, gameHeight / 2 - paddleHt / 2);
      paddle2.AddGraphic(Image.CreateRectangle(paddleWd, paddleHt, Color.Blue));

      // Create a new Scene
      var playScene = new Scene();
      // Add the Entity to the Scene
      playScene.Add(ball);
      playScene.Add(paddle1);
      playScene.Add(paddle2);

      // Start the game using the scene
      game.Start(playScene);
    }

    class PlayerEntity : Entity
    {

      /// <summary>
      /// The current move speed of the Entity.
      /// </summary>
      public float MoveSpeed;

      /// <summary>
      /// The move speed for when the Entity is moving slowly.
      /// </summary>
      public const float MoveSpeedSlow = 5;
      /// <summary>
      /// The move speed for when the Entity is moving quickly.
      /// </summary>
      public const float MoveSpeedFast = 10;

      private dynamic Controls; // more likely to compile

      public PlayerEntity(int ControlsKey, float x, float y) : base(x, y)
      {
        var Controls1 = new
        {
          up = Key.W,
          left = Key.A,
          down = Key.S,
          right = Key.D
        };

        var Controls2 = new
        {
          up = Key.Up,
          left = Key.Left,
          down = Key.Down,
          right = Key.Right
        };

        Controls = (ControlsKey == 1) ? Controls1 : Controls2;

        // can probably use this constructor to assign keys to commands (based on controls param passed in)
        // commands can then be referenced in the update (instead of keys)

        // Assign the initial move speed to be the slow speed.
        MoveSpeed = MoveSpeedSlow;
      }



      public override void Update()
      {
        base.Update();
        // Every update check for input and react accordingly.

        // If the W key is down,
        if (Input.KeyDown(Controls.up))
        {
          // Move up by the move speed.
          Y -= MoveSpeed;
        }
        // If the S key is down,
        if (Input.KeyDown(Controls.down))
        {
          // Move down by the move speed.
          Y += MoveSpeed;
        }
        // If the A key is down,
        if (Input.KeyDown(Controls.left))
        {
          // Move left by the move speed.
          X -= MoveSpeed;
        }
        // If the D key is down,
        if (Input.KeyDown(Controls.right))
        {
          // Move right by the move speed.
          X += MoveSpeed;
        }

        // If the space bar key is pressed,
        if (Input.KeyPressed(Key.Space))
        {
          // If the Entity is currently slow,
          if (MoveSpeed == MoveSpeedSlow)
          {
            // Set the Entity to fast,
            MoveSpeed = MoveSpeedFast;
            // And make its Color red.
            Graphic.Color = Color.Red;
          }
          // If the Entity is currently fast,
          else
          {
            // Set the Entity to slow,
            MoveSpeed = MoveSpeedSlow;
            // And make its Color white.
            Graphic.Color = Color.White;
          }
        }
      }

    }
  }
}

