using System.Linq;
using finalSDP.scripts.weapon;

namespace finalSDP.scripts.factories;
using Godot;
using finalSDP.scripts.entity.player;
using finalSDP.scripts.Adapters;

public partial class LevelBase : Node2D
{
    protected Player Player;
    protected Camera2D Camera;
    private MovementAdapter mA;

    public virtual string[] Texts { get; set; }

    public override void _Ready()
    {
        LoadPlayer();
        LoadMovementAdapter();
        ConfigureCamera();
        OnLevelLoaded();
    }

    protected virtual void LoadPlayer()
    {
        Player = GetNode<Player>("Player");
        Camera = Player.GetNode<Camera2D>("Camera2D");
    }
    protected virtual void LoadMovementAdapter()
    {
         mA = GetNode<MovementAdapter>("/root/MovementAdapter");

        Player.Material = mA.playerColor;

        if (mA.savedWeapon.GetParent() != null) 
            mA.savedWeapon?.Reparent(Player);
        else
            Player.AddChild(mA.savedWeapon);
        mA.savedWeapon?.ReSubscribe();
    }


    protected virtual void ConfigureCamera()
    {
        Camera.LimitLeft = 0;
        Camera.LimitRight = 0;
        Camera.LimitTop = 0;
        Camera.LimitBottom = 0;
    }
    protected virtual void OnLevelLoaded()
    {
        
    }

    public override void _ExitTree()
    {
        foreach (Node child in Player.GetChildren())
            if (child is Weapon w)
                w.Reparent(mA);
    }

}
