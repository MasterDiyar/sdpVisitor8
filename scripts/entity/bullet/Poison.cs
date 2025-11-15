using Godot;
using System;
using finalSDP.scripts.entity;

public partial class Poison : Node2D
{
	[Export] public float Damage = 10;
	private Timer timer;
	private int times = 2;
	public override void _Ready()
	{
		timer = GetNode<Timer>("Timer");
			timer.Start();
			timer.Timeout += Timeout;
	}

	void Timeout()
	{
		times--;
		GetParent<Entity>().TakeDamage(Damage);
		if (times == 0) QueueFree();
	}
}
