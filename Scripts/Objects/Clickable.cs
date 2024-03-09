using Godot;
using System;
using System.Data;

public partial class Clickable : Area2D
{
	bool mouseOver = false;
	public bool active = true;
	[Export] string tooltip = "";
	public override void _Ready()
	{
		AreaEntered += _on_area_2d_area_entered;
		AreaExited += _on_area_2d_area_exited;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if(active) {
			if(Input.IsActionJustPressed("Click")) {
				if(mouseOver) OnClick();
			}
		}
		if(mouseOver && !active) {
			mouseOver = false;
			Tooltip.Instance.Visible = false;
		}
		CheckActive();
	}

	public virtual void CheckActive() {
		if(GameController.currentState == GameController.GameState.Dialogue) {
			active = false;
		}
	}
	
	private void _on_area_2d_area_entered(Area2D area) {
		if(active) {
			mouseOver = true;
			Tooltip.Instance.Visible = true;
			Tooltip.Instance.Text = tooltip;
		}
	}
	private void _on_area_2d_area_exited(Area2D area) {
		if(active) {
			mouseOver = false;
			Tooltip.Instance.Visible = false;
		}
	}
	public virtual void OnClick() {
		
	}
}
