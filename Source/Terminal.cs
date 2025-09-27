using daydream.Utils.Exceptions;
using Godot;
using Godot.Collections;

namespace daydream;

public partial class Terminal : Node {
	public bool InUse;
	private Array<Node> _children;
	private TerminalTextLabel _text;
	private TextEdit _typeable;
	// private Tween _typingTween;
	private const float TerminalCharacterTimeout = 0.1f; // seconds
	
	public override void _Ready() {
		_children = GetChildren();
		foreach (var child in _children) {
			switch (child.Name.ToString()) {
				case "Text":
					_text = child as TerminalTextLabel;
					break;
			}
		}
		// _tween = GetTree().CreateTween();
		// _tween.TweenProperty(_text, "visible_characters", _text.GetTotalCharacterCount(), TerminalCharacterTimeout);
	}

	public void WriteLine(string text) {
		_text.WriteLine(text);
		InUse = false;
	}

	public void Clear() {
		_text.Clear();
	}

	public override void _Process(double delta) {
		_typeable.Editable = InUse;
	}
}
