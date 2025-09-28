using daydream.Utils.Exceptions;
using Godot;

namespace daydream;

public partial class Main : Node {
	
	public override void _Ready() {

		// check if terminal has been initialized
		
		// InitGame();
	}

	public override void _Process(double delta) {
		// _terminal.Focus();
	}

	private void OnTerminalPressed() {
		GetTree().ChangeSceneToFile("res://Source/TerminalScene.tscn");
	}

	
}
