using Godot;
using System;
using finalSDP.scripts.entity;

public partial class Bossbar : Node2D
{
	private Entity parent;
	private Line2D line;
	public override void _Ready()
	{
		line = GetNode<Line2D>("Line2D");
		parent = GetParent().GetParent<Entity>();
		parent.OnHurt += OnHurt;
	}

	private void OnHurt(float obj)
	{
		line.SetPointPosition(1, new Vector2(-381 + 762 * (parent.Hp / parent.MaxHp), 0));
	}
}
