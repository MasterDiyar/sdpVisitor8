using Godot;
using System;
using finalSDP.scripts.entity;
using finalSDP.scripts.entity.bullet;
using finalSDP.scripts.entity.player;

public partial class Hand : Area2D
{
	private Timer timer;
	AnimatedSprite2D animatedSprite;
	float angle= 0;
	public override void _Ready()
	{
		angle = GD.Randf() * Mathf.Pi;
		animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		timer = GetNode<Timer>("Timer");
		
		timer.Start();
		animatedSprite.Play("idle");
		
		timer.Timeout += TimerOnTimeout;
		BodyEntered += AreaOnBodyEntered;
		AreaEntered += OnAreaEntered;
	}

	private void OnAreaEntered(Area2D area)
	{
		if (area is Bullet )
		{
			QueueFree();
		}
	}

	private void AreaOnBodyEntered(Node2D body)
	{
		if (body is Player pl)
			pl.TakeDamage(13);
		QueueFree();
	}

	float MaxSpeed = 120;
	float Speed = 120;
	public override void _Process(double delta)
	{
		var Velocity = Speed * (float)delta * new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
		Speed -= (float)delta * 30;
		Position += Velocity;
	}

	private void TimerOnTimeout()
	{
		Speed = MaxSpeed;
		var player = GetParent().GetNode<Player>("Player");
		angle = (player.GlobalPosition - GlobalPosition).Angle();
		Rotation = angle;
		animatedSprite.Animation = "attack";
	}
	
}
