using Godot;
using System;
using daydream;

public partial class TerminalScene : Node {
	private Terminal _terminal;
	private Control handbook;

	public override void _Ready() {
		_terminal = GetNode("Terminal") as Terminal;
		handbook = GetNode("Handbook") as Control;
		InitGame();
	}

	public override void _Process(double delta) {
		// _terminal.Focus();
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
