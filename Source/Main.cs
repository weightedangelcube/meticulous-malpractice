using daydream.Utils.Exceptions;
using Godot;

namespace daydream;

public partial class Main : Node {
	
	public override void _Ready() {

	}

	public override void _Process(double delta) {
	}

	private void OnTerminalPressed() {
		GetTree().ChangeSceneToFile("res://Source/TerminalScene.tscn");
	}

	private void OnFridgePressed() {
		GetTree().ChangeSceneToFile("res://Source/FridgeScene.tscn");
	}

	
}
