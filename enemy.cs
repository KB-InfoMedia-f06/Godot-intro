using Godot;
using System;

public partial class enemy : CharacterBody2D
{
	public const float Speed = 300.0f;
	public const float JumpVelocity = -400.0f;

	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();
	
	private int direction = 1;

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor()){
			velocity.Y += gravity * (float)delta;
		}

		velocity.X = 400*direction;
		
		Velocity = velocity;
		MoveAndSlide();
	}

	public void OnWallDetectorBodyEntered(Node2D body){
		GD.Print("collision with" + body.Name);
		if(body is TileMap){
			GD.Print("change direction");
			direction = -direction;
		}
	}

	public void OnDeathDetectorBodyEntered(Node2D body){
		if(body is player){
			GD.Print("I have colliden with something" + body.Name);
			QueueFree();
		}
	}
}
