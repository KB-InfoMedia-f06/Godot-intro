using Godot;
using System;

public partial class Main : Node
{
	private int timeLeft = 100;
	[Export]
	public PackedScene enemyScene { get; set; }
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GD.Print("Hello World");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void OnTimerTimeout(){
		timeLeft--;
		GD.Print(timeLeft);
		if(timeLeft <= 0){
			GD.Print("Game Over");
		}
	}

	public void OnEnemySpawnTimerTimeout(){
		//spawn an enemy
		GD.Print("Timeout");
		enemy mEnemy = enemyScene.Instantiate<enemy>();
		mEnemy.Position = GetNode<Marker2D>("EnemySpawn").Position;
		AddChild(mEnemy);
	}
}
