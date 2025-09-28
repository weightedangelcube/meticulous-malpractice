using System;

namespace daydream;

public class BloodSample {
    public BloodSample(bool infected) {
        this.infected = infected;
    }

    private bool infected { get; }
    private string CellSequence => GetCellSequence();
    private int OxygenResponse => GetOxygenResponse();
    private int WhiteBloodCellCount => GetWhiteBloodCellCount();

    public string GetCellSequence() {
        var sequence = "";
        
        if (infected) {
            foreach (var letter in "ATGCAATCATCGA") {
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
            foreach (var letter in "ATGCAATCATCGA") {
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

    public int GetOxygenResponse() {
        if (infected) {
            return new Random().Next(1) >= 0.5 ? // coin flip
                new Random().Next(25, 70) : new Random().Next(105, 150);
        } else {
            return new Random().Next(70, 105);
        }
    }

    public int GetWhiteBloodCellCount() {
        if (infected) {
            return new Random().Next(1) >= 0.5 ? // coin flip
                new Random().Next(0, 5000) : new Random().Next(10000, 15000);
        } else {
            return new Random().Next(5000, 10000);
        }
    }
}