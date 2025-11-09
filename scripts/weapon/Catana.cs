using Godot;
using System;
using finalSDP.scripts.weapon;

public partial class Catana : Weapon
{
	private Tween tween;
	private Sprite2D sprite;
	private bool attacking = false;

	public override void _Ready()
	{
		base._Ready();
		sprite = GetNodeOrNull<Sprite2D>("Catana");
	}

	public override void _Process(double delta)
	{
		sprite.FlipH =  GetGlobalMousePosition().X < GlobalPosition.X;
	}

	protected override bool TimerCheck()
	{
		if (attacking) return false;
		float downAngle = (sprite.FlipH)? Mathf.DegToRad(-60):Mathf.DegToRad(60);
                          		
        attacking = true;
        tween?.Kill();
        tween = CreateTween();
  
        if (sprite.FlipV)
            downAngle = -downAngle;
  
        tween.Parallel().TweenProperty(this, "rotation", downAngle, 0.15f)
            .SetTrans(Tween.TransitionType.Quad)
            .SetEase(Tween.EaseType.Out);
        tween.Parallel().TweenProperty(this, "position", Position + new Vector2(sprite.FlipH ? -60 : 60, 0), 0.15f)
            .SetTrans(Tween.TransitionType.Quad)
            .SetEase(Tween.EaseType.Out);
        tween.TweenInterval(0.1f);
  
        tween.Parallel().TweenProperty(this, "rotation", 0, 0.2f)
            .SetTrans(Tween.TransitionType.Quad)
            .SetEase(Tween.EaseType.In);
        tween.Parallel().TweenProperty(this, "position", Position, 0.2f)
            .SetTrans(Tween.TransitionType.Quad)
            .SetEase(Tween.EaseType.In);
  
        tween.Finished += () => attacking = false;
        
        return true;
	}
	
}
