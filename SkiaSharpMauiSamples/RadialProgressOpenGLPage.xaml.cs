namespace SkiaSharpMauiSamples;

public partial class RadialProgressOpenGLPage : ContentPage
{
	public RadialProgressOpenGLPage()
	{
		InitializeComponent();
	}

    void Handle_Tapped(object sender, System.EventArgs e)
    {
        var rngesus = new Random(Guid.NewGuid().GetHashCode());

        Progress1.StartingDegrees = rngesus.Next(-360, 360);
        var endingAt1 = rngesus.Next(-360, 360);
        Progress1.Animate(nameof(Progress1), x => Progress1.EndingDegrees = (float)x, 0, endingAt1, 4, 5000, Easing.BounceIn);

        Progress2.StartingDegrees = rngesus.Next(-360, 360);
        var endingAt2 = rngesus.Next(-360, 360);
        Progress2.Animate(nameof(Progress1), x => Progress2.EndingDegrees = (float)x, 0, endingAt2, 4, 5000, Easing.SpringOut);

        Progress3.StartingDegrees = rngesus.Next(-360, 360);
        var endingAt3 = rngesus.Next(-360, 360);
        Progress3.Animate(nameof(Progress1), x => Progress3.EndingDegrees = (float)x, 0, endingAt3, 4, 5000, Easing.CubicInOut);
    }
}
