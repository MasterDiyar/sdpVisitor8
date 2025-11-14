using Godot;
using System;
using System.Linq;
using finalSDP.scripts.Adapters;
using finalSDP.scripts.entity.player;

public partial class PlayerAnimation : AnimatedSprite2D
{
	[Export] CpuParticles2D particles2D;
	private MovementAdapter adapter;
	private Player parent;

	public override void _Ready()
	{
		parent = GetParent<Player>();
		adapter = GetNode<MovementAdapter>("/root/MovementAdapter");
	}
	
	
	public override void _Process(double delta)
	{
		var move = adapter.current.GetMove();
		bool running = Mathf.Abs(move.X) > 0.05f && parent.IsOnFloor();

		Play(running ? "run" : "idle");
		FlipH = move.X < 0;
	}
	
	
}
