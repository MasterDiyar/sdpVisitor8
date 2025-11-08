using Godot;
using System;
using finalSDP.scripts.entity.player;

public partial class HellLevel : Node2D
{
	private Player pl;
	public override void _Ready()
	{
		pl = GetNode<Player>("Player");
		var camera = pl.GetNode<Camera2D>("Camera2D");

		camera.LimitLeft = 0;
		camera.LimitRight = 2550;
		camera.LimitTop = 0;
		camera.LimitBottom = 825;
	}

	public override void _Process(double delta)
	{
	}
}
