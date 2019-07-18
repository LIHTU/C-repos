using Otter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ScenesAndEntities
{
  public static class Globals
  {
    public const int gameWidth = 1280;
    public const int gameHeight = 940;

    public static int paddleHt = 100;
    public static int paddleWd = 20;
  }

  class Program
  {
    static void Main(string[] args)
    {
      // Create a new game
      
      var game = new Game("Scenes and Entities", Globals.gameWidth, Globals.gameHeight);

      // create entities
      var ballRad = 20;
      var paddleHt = 100;
      var paddleWd = 20;

      // Add a PlayerEntity to the Scene at half of the Game's width, and half of the Game's height (centered)
      // scene.Add(new PlayerEntity(Game.Instance.HalfWidth, Game.Instance.HalfHeight));

      var ball = new Entity(Game.Instance.HalfWidth - ballRad, Game.Instance.HalfHeight - ballRad);
      ball.AddGraphic(Image.CreateCircle(ballRad, Color.White));

      var paddle1 = new PlayerEntity(1, 40, Globals.gameHeight / 2 - paddleHt / 2);
      paddle1.AddGraphic(Image.CreateRectangle(paddleWd, paddleHt, Color.Red));
      var paddle2 = new PlayerEntity(2, 1220, Globals.gameHeight / 2 - paddleHt / 2);
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
      public float MoveSpeed = 10;

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
      }

      public override void Update()
      {
        base.Update();
        // Every update check for input and react accordingly.

        if (Input.KeyDown(Controls.up))
        {
          if (Y > 0)
          {
            Y -= MoveSpeed;
          }
        }
        if (Input.KeyDown(Controls.down))
        {
          // TODO: FIND THE RIGHT PADDLE MIN VALUE
          if (Y < Globals.gameHeight - Globals.paddleHt)
          {
            Y += MoveSpeed;
          }
        }
        //if (Input.KeyDown(Controls.left))
        //{
        //  X -= MoveSpeed;
        //}
        //if (Input.KeyDown(Controls.right))
        //{
        //  X += MoveSpeed;
        //}

      }

    }
  }
}

