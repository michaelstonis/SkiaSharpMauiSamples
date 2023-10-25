namespace SkiaSharpMauiSamples;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    void RadialProgress_Clicked(object sender, System.EventArgs e)
    {
        this.Navigation.PushAsync(new RadialProgressPage());
    }

    void RadialProgressOpenGl_Clicked(object sender, System.EventArgs e)
    {
        this.Navigation.PushAsync(new RadialProgressOpenGLPage());
    }

    void LinearProgress_Clicked(object sender, System.EventArgs e)
    {
        this.Navigation.PushAsync(new LinearProgressPage());
    }
}


