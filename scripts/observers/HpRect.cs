using Godot;
using System;
using finalSDP.scripts.entity;

public partial class HpRect : ColorRect
{
	private Entity parent;
	private Label hpLabel;
	private Line2D line;
	public override void _Ready()
	{
		hpLabel = GetNode<Label>("Label");
		line = GetNode<Line2D>("Line2D");
		parent = GetParent<Entity>();
		parent.OnHurt += OnHurt;
	}

	private void OnHurt(float obj)
	{
		hpLabel.Text = $"{Mathf.Floor(100* parent.Hp / parent.MaxHp)}%";
		line.SetPointPosition(1, new Vector2(1 + 63 * (parent.Hp / parent.MaxHp), 5));
	}
	
}
