using Godot;
using System;

public partial class Player : CharacterBody2D
{
	const double Gravity = 150d;
	const double JumpForce = -65d;
	private Vector2 Motion;
	private double Speed = 60d;
	private string Animation;
	private bool Attacking;
	private Sprite2D Sprite;
	private AnimationPlayer Animator;
	private Timer TimerAttack;

	public override void _Ready()
	{
		Sprite = GetNode<Sprite2D>("Sprite2D");
		Animator = GetNode<AnimationPlayer>("AnimationPlayer");
		TimerAttack = GetNode<Timer>("TimerAttack");
	}

	public override void _Process(double delta)
	{
		// Aplica gravidade
		Motion.Y += (float)(Gravity * delta);

		// Pulo
		if (IsOnFloor() && Input.IsActionJustPressed("ui_accept"))
		{
			Motion.Y = (float)JumpForce;
		}
	}

	public override void _PhysicsProcess(double delta)
	{
		// Movimento lateral
		float input = Input.GetActionStrength("ui_right") - Input.GetActionStrength("ui_left");
		Motion.X = (float)(input * Speed);

		// Aplica movimento
		Velocity = Motion;
		MoveAndSlide();
		Motion = Velocity;
	}

}