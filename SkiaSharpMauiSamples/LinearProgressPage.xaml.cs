namespace SkiaSharpMauiSamples;

public partial class LinearProgressPage : ContentPage
{
	public LinearProgressPage()
	{
		InitializeComponent();
	}

	void Handle_Tapped(object sender, System.EventArgs e)
	{
		var rngesus = new Random(Guid.NewGuid().GetHashCode());

		Progress1.StartingPoint = Progress1.EndingPoint = rngesus.Next(0, 100);
		var endingAt1 = rngesus.Next((int)Progress1.StartingPoint + 1, 100);
		Progress1.Animate(nameof(Progress1), x => Progress1.EndingPoint = (float)x, 0, endingAt1, 4, 500, Easing.CubicInOut);

		Progress2.StartingPoint = Progress2.EndingPoint = rngesus.Next(0, 100);
		var endingAt2 = rngesus.Next((int)Progress2.StartingPoint + 1, 100);
		Progress3.Animate(nameof(Progress2), x => Progress2.EndingPoint = (float)x, 0, endingAt2, 4, 500, Easing.SpringOut);

		Progress3.StartingPoint = Progress3.EndingPoint = rngesus.Next(0, 100);
		var endingAt3 = rngesus.Next((int)Progress3.StartingPoint + 1, 100);
		Progress3.Animate(nameof(Progress3), x => Progress3.EndingPoint = (float)x, 0, endingAt3, 4, 500, Easing.BounceOut);

	}
}
