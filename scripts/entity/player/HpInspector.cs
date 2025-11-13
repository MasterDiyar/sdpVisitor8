using Godot;
using System;
using finalSDP.scripts.entity.player;

public partial class HpInspector : CanvasLayer
{
	
	Player grandParent;
	[Export] Line2D line;
	[Export] Label  hpLabel;
	public override void _Ready()
	{
		grandParent = GetParent().GetParent<Player>();
		grandParent.OnHurt += OnHurt;
	}

	private void OnHurt(float obj)
	{
		hpLabel.Text ="Hp: "+grandParent.Hp;
		line.SetPointPosition(1, Vector2.Right * Mathf.Clamp(grandParent.Hp/grandParent.MaxHp, 0, 1)*100);
	}
}
