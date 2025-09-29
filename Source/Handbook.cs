using Godot;

namespace daydream;

public partial class Handbook : Control {
	private int displayedIndex = 0;
	private string[] pages = [
		"""
		[font_size=24][b]Blood and you![/b][/font_size]
		(It's a lot more than red.)
		Red, green, and even blue, blood of all colours are all around you! In this business, you'll be working with blood in a variety of ways. [b]But be sure to be careful with your usage! We only have a limited amount to pass around per subject![/b]
		""",
		"""
		[font_size=24][b]The PC, CAM![/b][/font_size]
		(Beep beep, boop boop...)
		Be amazed by our state of the art technology, finally integrated to the medical field. Behold, Central Analysis Machine, CAM for short! Using the Macux operating system from Watermelon Technologies, this beast will analyze everything for you, from debilitating Prions to misshapen cells. What's the catch, you may say? Well... a recent security breach forced all of us to remove almost all graphical interfaces, so you'll be working with the terminal. Here are some commands that might be useful:
		[b]info[/b]: displays info about the current subject.
		[b]analyze[/b]
				  - [b]cell[/b]: analyzes the blood sample for cell sequence.
				  - [b]oxygen[/b]: analyzes the blood sample for oxygen response.
				  - [b]whitebloodcell[/b]: analyzes the blood sample for white blood cell count.
		[b]clear[/b]: clears the screen.
		[b]mark[/b]
		 - [b]healthy[/b]: marks the subject as healthy.
		 - [b]infected[/b]: marks the subject as infected.
		""",
		"""
		[font_size=24][b]Accepted values of analysis[/b][/font_size]
		(Don't screw up, now!)
		I know everyone in your class failed analysis back in high school, so we at Nefarious Corporation have dumbed everything down and made it more easy to navigate! No linear regression or whatnot here, only a few simple guidelines for you to follow!
		[b]Cell sequence test:[/b]
		Check for the S nucleotide replacing the A nucleotide. The more S nucleotides, the higher risk of infection! The less S nucleotides, the lower risk.
		[b]Oxygen response test:[/b]
		Normal oxygen thresholds should be somewhere near 75mmHg - 100mmHg. The further the oxygen response is from the normal threshold, the higher chance of infection there is.
		[b]White blood cell count test:[/b]
		Normal WBC counts should be around 5000wbc/μL - 10,000wbc/μL. The further the white blood cell count is from this threshold, the higher chance of infection there is.
		""",
		"""
		[font_size=24][b]Being a good employee![/b][/font_size]
		(...or else...)
		You've read through the entire Employee's Handbook of Nefarious Corporation! Congratulations, for you are now qualified to use comically expensive lab gear for our good cause. Remember to ALWAYS follow what we say, and do EVERYTHING that we ask of. Good luck, and welcome to Nefarious Corporation...
		"""
	];

	private RichTextLabel handbookLabel;

	public override void _Ready() {
		handbookLabel = GetNode("HandbookLabel") as RichTextLabel;
		handbookLabel.ParseBbcode(pages[displayedIndex]);
	}
	
	private void OnForwardPress() {
		GD.Print("forward press");
		displayedIndex++;
		if (displayedIndex > (pages.Length - 1)) {
			displayedIndex = 0;
		} 
		handbookLabel.ParseBbcode(pages[displayedIndex]);
	}
	
	private void OnBackwardPress() {
		displayedIndex--;
		if (displayedIndex < 0) {
			displayedIndex = pages.Length - 1;
		}
		handbookLabel.ParseBbcode(pages[displayedIndex]);
	}


}
