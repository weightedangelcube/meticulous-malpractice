using System;
using daydream.Utils.Exceptions;
using Godot;
using Godot.Collections;

namespace daydream;

public partial class Terminal : Node {
	private TerminalTextLabel _text;
	private LineEdit _typeable;

	private string prevInput;
	// private Tween _typingTween;
	private const float TerminalCharacterTimeout = 0.1f; // seconds
	
	public override void _Ready() {
		_text = GetNode("TerminalText") as TerminalTextLabel;
		_typeable = GetNode("TerminalTypeable") as LineEdit;
		
		// _tween = GetTree().CreateTween();
		// _tween.TweenProperty(_text, "visible_characters", _text.GetTotalCharacterCount(), TerminalCharacterTimeout);
	}

	public void OnUnhandledInput(InputEvent e) {
		if (e.GetType() != typeof(InputEventKey)) return;
		if ((e as InputEventKey).Keycode == Key.Up) {
			_typeable.Text = prevInput;
		}
	}
	
	public void OnInputSubmitted(string input) {
		prevInput = input;
		WriteLine("> " + input);
		_typeable.Clear();

		var currentSample = Main.samples[Main.currentIndex];
		
		switch (input.Trim()) {
			case "":
				break;
			case "clear":
				Clear();
				break;
			case "info":
				WriteLine("Subject ID " + Main.currentIndex);
				WriteLine("Available samples: " + currentSample.availableSamples);
				break;
			case "analyze cell":
				if (!currentSample.availableSamples.HasFlag(BloodSample.AvailableSamples.Cell)) {
					WriteLine("Sample isn't available for this subject");
					break;
				}
				WriteLine("Analysis: " + currentSample.CellSequence);
				break;
			case "analyze oxygen":
				if (!currentSample.availableSamples.HasFlag(BloodSample.AvailableSamples.Oxygen)) {
					WriteLine("Sample isn't available for this subject");
					break;
				}
				WriteLine("Analysis: " + currentSample.OxygenResponse + "mmHg");
				break;
			case "analyze whitebloodcell":
				if (!currentSample.availableSamples.HasFlag(BloodSample.AvailableSamples.WhiteBloodCell)) {
					WriteLine("Sample isn't available for this subject");
					break;
				}
				WriteLine("Analysis: " + currentSample.WhiteBloodCellCount + "wbc/μL");
				break;
			case "analyze":
				WriteLine("No command supplied, can't guess what you mean.");
				break;
			case "mark healthy":
				if (!nextSubject(false)) {
					break;
				}
				WriteLine("Subject marked as healthy.");
				WriteLine("Next subject: ID " + Main.currentIndex);
				break;
			case "mark infected":
				if (!nextSubject(true)) {
					break;
				}
				WriteLine("Success. Subject terminated.");
				WriteLine("Next subject: ID " + Main.currentIndex);
				break;
			case "haha annie try this lol 123":
				WriteLine("meow meow meow meow meow meow meow meow meow meow meow meow meow meow meow meow meow meow" +
						  " meow meow ");
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

	public bool nextSubject(bool infected) {
		if (Main.samples[Main.currentIndex].infected == infected) {
			Main.correctAnswers++;
		}

		if (Main.currentIndex + 1 == Main.samples.Length) {
			winGame();
			return false;
		} else {
			Main.currentIndex++;
			return true;
		}
	}
	
	public void winGame() {
		if ((Main.correctAnswers / Main.samples.Length) >= 0.5) {
			WriteLine("You win!");
			WriteLine("Percentage correct: " + (Main.correctAnswers / Main.samples.Length) * 100);
			WriteLine("(Good ending)");
		} else {
			WriteLine("Your contract with the company has been terminated!");
			WriteLine("Percentage correct: " + (Main.correctAnswers / Main.samples.Length) * 100);
			WriteLine("(Bad ending)");
		}
	}
	
	public override void _Process(double delta) {
		if (_text.GetThemeDefaultFont().GetMultilineStringSize(_text.Text).Y > _text.Size.Y) {
			_text.Text = _text.Text[(_text.Text.IndexOf('\n') + 1)..];
		}
	}
}
