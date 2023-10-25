namespace SkiaSharpMauiSamples;

public partial class RadialProgressPage : ContentPage
{
	public RadialProgressPage()
	{
		InitializeComponent();
	}

    void Handle_Tapped(object sender, System.EventArgs e)
    {
        var rngesus = new Random(Guid.NewGuid().GetHashCode());

        var startingAt1 = rngesus.Next(-360, 360);
        var endingAt1 = rngesus.Next(-360, 360);

        Progress1.Animate("Progress1Start", x => Progress1.StartingDegrees = (float)x, Progress1.StartingDegrees, startingAt1, 4, 5000, Easing.BounceIn);
        Progress1.Animate("Progress1End", x => Progress1.EndingDegrees = (float)x, Progress1.EndingDegrees, endingAt1, 4, 5000, Easing.BounceIn);

        var startingAt2 = rngesus.Next(-360, 360);
        var endingAt2 = rngesus.Next(-360, 360);
        Progress2.Animate("Progress2Start", x => Progress2.StartingDegrees = (float)x, Progress2.StartingDegrees, startingAt2, 4, 5000, Easing.SpringOut);
        Progress2.Animate("Progress2End", x => Progress2.EndingDegrees = (float)x, Progress2.EndingDegrees, endingAt2, 4, 5000, Easing.SpringOut);

        var startingAt3 = rngesus.Next(-360, 360);
        var endingAt3 = rngesus.Next(-360, 360);
        Progress3.Animate("Progress3Start", x => Progress3.StartingDegrees = (float)x, Progress3.StartingDegrees, startingAt3, 4, 5000, Easing.CubicInOut);
        Progress3.Animate("Progress3End", x => Progress3.EndingDegrees = (float)x, Progress3.EndingDegrees, endingAt3, 4, 5000, Easing.CubicInOut);
    }
}
