using System;
using System.Linq;
using daydream.Utils.Exceptions;
using Godot;
using Godot.Collections;

namespace daydream;

public partial class Main : Node {
	public static BloodSample[] samples = new BloodSample[10];
	public static int currentIndex = 0;
	public static int correctAnswers = 0;
	
	public override void _Ready() {
		for (var i = 0; i < 10; i++) {
			BloodSample.AvailableSamples availableSamples = 0x0;
			const int mask = (int) (BloodSample.AvailableSamples.WhiteBloodCell | BloodSample.AvailableSamples.Cell | 
									BloodSample.AvailableSamples.Oxygen);
			switch (i) {
				case < 2: // hardcode everything for the first two subjects
					availableSamples = BloodSample.AvailableSamples.WhiteBloodCell | BloodSample.AvailableSamples.Cell
						| BloodSample.AvailableSamples.Oxygen;
					break;
				default:
					availableSamples = (BloodSample.AvailableSamples) (mask & (new Random().Next(mask) + 1));
					break;
			}
			samples[i] = new BloodSample(new Random().Next(2) == 1, i, availableSamples);
			// generates either 0 or 1 i think
		}
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
