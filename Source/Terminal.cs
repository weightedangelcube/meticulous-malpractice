using System;
using daydream.Utils.Exceptions;
using Godot;
using Godot.Collections;

namespace daydream;

public partial class Terminal : Node {
	private TerminalTextLabel _text;
	private LineEdit _typeable;
	// private Tween _typingTween;
	private const float TerminalCharacterTimeout = 0.1f; // seconds
	
	public override void _Ready() {
		_text = GetNode("TerminalText") as TerminalTextLabel;
		_typeable = GetNode("TerminalTypeable") as LineEdit;
		
		// _tween = GetTree().CreateTween();
		// _tween.TweenProperty(_text, "visible_characters", _text.GetTotalCharacterCount(), TerminalCharacterTimeout);
	}
	
	public void OnInputSubmitted(string input) {
		WriteLine("> " + input);
		_typeable.Clear();

		switch (input) {
			case "clear":
				Clear();
				break;
			
			
			case "haha annie try this lol 123":
				WriteLine("meow meow meow meow meow meow meow meow meow meow meow meow meow meow meow meow meow meow" +
				          "meow meow ");
				break;
			default:
				WriteLine("Command not found");
				break;
		}
	}

	public void WriteLine(string text) {
		_text.WriteLine(text);
	}

	public void Clear() {
		_text.Clear();
	}

	public void Focus() {
		_typeable.GrabFocus();
	}
	
	public override void _Process(double delta) {
		if (_text.GetThemeDefaultFont().GetMultilineStringSize(_text.Text).Y > _text.Size.Y) {
			_text.Text = _text.Text[(_text.Text.IndexOf('\n') + 1)..];
		}
	}
}
