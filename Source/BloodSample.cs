using System;
using System.Linq;
using Godot;

namespace daydream;

public class BloodSample {
    public bool infected { get; }
    public int subjectIndex { get; }
    public AvailableSamples availableSamples { get; }
    public string CellSequence { get; }
    public int OxygenResponse { get; }
    public int WhiteBloodCellCount { get; }

    public BloodSample(bool infected, int subjectIndex, AvailableSamples availableSamples) {
        this.infected = infected;
        this.subjectIndex = subjectIndex;
        this.availableSamples = availableSamples;
        CellSequence = GetCellSequence();
        OxygenResponse = GetOxygenResponse();
        WhiteBloodCellCount = GetWhiteBloodCellCount();
    }

    [Flags]
    public enum AvailableSamples {
        Cell = 1,
        Oxygen = 2,
        WhiteBloodCell = 4
    }
    
    private string GetCellSequence() {
        var sequence = "";

        char[] letters = ['A', 'T', 'C', 'G'];
        var initialSequence = "";
        for (int i = 0; i < 10; i++) {
            var randomIndex = new Random().Next(0, 4);
            initialSequence += letters[randomIndex];
        }
        
        if (infected) {
            foreach (var letter in initialSequence) {
                switch (letter) {
                    case 'A' when new Random().Next(4) >= 1:
                        sequence += 'S'; // 75% chance A becomes S
                        break;
                    case 'A':
                        sequence += 'A';
                        break;
                    default:
                        sequence += letter;
                        break;
                }
            }
        } else {
            foreach (var letter in initialSequence) {
                switch (letter) {
                    case 'A' when new Random().Next(4) >= 3:
                        sequence += 'S'; // 25% chance A becomes S
                        break;
                    case 'A':
                        sequence += 'A';
                        break;
                    default:
                        sequence += letter;
                        break;
                }
            }
        }
        
        return sequence;
    }

    private int GetOxygenResponse() {
        if (infected) {
            return new Random().Next(2) == 1 ? // coin flip
                new Random().Next(25, 70) : new Random().Next(105, 150);
        } else {
            return new Random().Next(70, 105);
        }
    }

    private int GetWhiteBloodCellCount() {
        if (infected) {
            return new Random().Next(2) == 1 ? // coin flip
                new Random().Next(0, 5000) : new Random().Next(10000, 15000);
        } else {
            return new Random().Next(5000, 10000);
        }
    }
}