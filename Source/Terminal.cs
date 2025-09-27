using Godot;
using System;
using daydream;
using daydream.Utils.Exceptions;
using Godot.Collections;

public partial class Terminal : Node2D {
	private Array<Node> _children;
	private TerminalTextLabel _text;
	// private Tween _typingTween;
	private const float TerminalCharacterTimeout = 0.1f; // seconds
	
	public override void _Ready() {
		_children = GetChildren();
		foreach (var child in _children) {
			if (child.Name.ToString().Equals("TerminalText")) {
				_text = child as TerminalTextLabel;
			} 
		}
		if (_text == null) throw new MalformedSceneTreeException("Node doesn't exist!");
		
		// _tween = GetTree().CreateTween();
		// _tween.TweenProperty(_text, "visible_characters", _text.GetTotalCharacterCount(), TerminalCharacterTimeout);
	}

	public void WriteLine(string text) {
		_text.WriteLine(text);
	}

	public void Clear() {
		_text.Clear();
	}

	public override void _Process(double delta) {
	
	}
	

	public void InitGame() {

	}
}
