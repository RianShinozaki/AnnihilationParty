using Godot;
using System;

public partial class SuspectPhoto : Clickable
{
	[Export] public GameController.Location myLocation;
	[Export] public string goToScene;
	bool clicked;

    public override void _Ready()
    {
        base._Ready();
    }
    public override void _Process(double delta)
    {
        base._Process(delta);
    }
    public override void OnClick()
    {
        base.OnClick();
		GameController.currentLocation = myLocation;
		GameController.Instance.OnSwitchSceneTransitionBegin(goToScene);
		clicked = true;
    }
	public void OnSwitchScene() {
		if(clicked) {

		}
	}
}