using daydream.Utils.Exceptions;
using Godot;

namespace daydream;

public partial class Main : Node {
	private Terminal _terminal;
	public override void _Ready() {
		foreach (var child in GetChildren()) {
			if (child.Name == "Terminal") {
				_terminal = child as Terminal;
			}
		}
		// check if terminal has been initialized
		if (_terminal == null) throw new MalformedSceneTreeException("Terminal Node doesn't exist!");
		
		InitGame();
	}

	public override void _Input(InputEvent @event) {
		
	}

	public void InitGame() {
		_terminal.Clear();
		_terminal.WriteLine("> Welcome to Nefarious Corporation.");
		_terminal.WriteLine("> Username: polyblank");
		_terminal.WriteLine("> Password: *********");
		_terminal.WriteLine("> Authorized.");
		_terminal.WriteLine("> Directive: blah blah blah blah");
		
		// play intro audio
		
		
	}
}
