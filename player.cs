using Godot;
using System;

public partial class player : CharacterBody2D
{
	[Signal]
	public delegate void PlayerScoreEventHandler();
	public float speed = 300;
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GD.Print(gravity);
	}

	public override void _PhysicsProcess(double delta){
		Vector2 mVelocity = Velocity;
		/*
		mVelocity.Y += gravity * (float)delta; 

		if(Input.IsActionJustPressed("jump")){
			mVelocity.Y = 	-900;
		}
		*/
		Vector2 mDirection = Input.GetVector("move_left","move_right","move_up","move_down");
		mVelocity.X = mDirection.X * speed;
		mVelocity.Y = mDirection.Y * speed;
		Velocity = mVelocity;
		MoveAndSlide();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if(Input.IsActionJustPressed("add_score")){
			GD.Print("Player should score");
			EmitSignal(SignalName.PlayerScore);
		}
	}
}
