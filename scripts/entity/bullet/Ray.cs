using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using finalSDP.scripts.entity.bullet;
using finalSDP.scripts.entity.player;

public partial class Ray : Bullet
{
    private List<AnimatedSprite2D> rayAnim;
    private Sprite2D dirka, ten;
    public override void _Ready()
    {
        rayAnim = GetChildren().OfType<AnimatedSprite2D>().ToList();
        rayAnim.ForEach(w => w.Play());
        
        dirka = GetNode<Sprite2D>("Blackhole12");
        ten = dirka.GetNode<Sprite2D>("Blackhole13");
        base._Ready();
        
    }
    public override void _Process(double delta)
    {
        dirka.Rotate((float) delta);
        ten.Rotate((float) delta/2);
    }

    public override void OnBodyHit(Node body)
    {
        if (body is Player entity)
        {
            entity.TakeDamage(Damage);
        }
    }
}
