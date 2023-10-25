using SkiaSharp;
using SkiaSharp.Views.Maui;
using SkiaSharp.Views.Maui.Controls;

namespace SkiaSharpMauiSamples.Views
{
    public class CircularProgressOpenGL : SKGLView
    {
        public static BindableProperty JaggedProperty =
            BindableProperty.Create(nameof(Jagged), typeof(bool), typeof(CircularProgressOpenGL), default(bool),
                propertyChanged: (bindable, oldValue, newValue) => (bindable as SKGLView)?.InvalidateSurface());

        public bool Jagged
        {
            get { return (bool)GetValue(JaggedProperty); }
            set { SetValue(JaggedProperty, value); }
        }

        public static BindableProperty StartingDegreesProperty =
            BindableProperty.Create(nameof(StartingDegrees), typeof(float), typeof(CircularProgress), -90f,
                propertyChanged: (bindable, oldValue, newValue) => (bindable as SKGLView)?.InvalidateSurface());

        public float StartingDegrees
        {
            get { return (float)GetValue(StartingDegreesProperty); }
            set { SetValue(StartingDegreesProperty, value.Clamp(-359.99f, 359.99f)); }
        }

        public static BindableProperty EndingDegreesProperty =
            BindableProperty.Create(nameof(EndingDegrees), typeof(float), typeof(CircularProgress), -90f,
                propertyChanged: (bindable, oldValue, newValue) => (bindable as SKGLView)?.InvalidateSurface());

        public float EndingDegrees
        {
            get { return (float)GetValue(EndingDegreesProperty); }
            set { SetValue(EndingDegreesProperty, value.Clamp(-359.99f, 359.99f)); }
        }


        public static BindableProperty ProgressThicknessProperty =
            BindableProperty.Create(nameof(ProgressThickness), typeof(float), typeof(CircularProgress), 12f,
                propertyChanged: (bindable, oldValue, newValue) => (bindable as SKGLView)?.InvalidateSurface());

        public float ProgressThickness
        {
            get { return (float)GetValue(ProgressThicknessProperty); }
            set { SetValue(ProgressThicknessProperty, value); }
        }

        public static BindableProperty ProgressColorProperty =
            BindableProperty.Create(nameof(ProgressColor), typeof(Color), typeof(CircularProgress), Colors.Transparent,
                propertyChanged: (bindable, oldValue, newValue) => (bindable as SKGLView)?.InvalidateSurface());

        public Color ProgressColor
        {
            get { return (Color)GetValue(ProgressColorProperty); }
            set { SetValue(ProgressColorProperty, value); }
        }

        public CircularProgressOpenGL()
        {
            this.InputTransparent = true;
        }

        protected override void OnHandlerChanged()
        {
            base.OnHandlerChanged();

            if (Handler is not null)
            {
                this.InvalidateSurface();
            }
        }

        protected override void OnPaintSurface(SKPaintGLSurfaceEventArgs e)
        {
            base.OnPaintSurface(e);

            var canvas = e.Surface.Canvas;

            canvas.Clear();

            var size = Math.Min(e.BackendRenderTarget.Width, e.BackendRenderTarget.Height) - ProgressThickness;

            using (var paint = new SKPaint())
            using (var path = new SKPath())
            {
                var left = (e.BackendRenderTarget.Width - size) / 2f;
                var top = (e.BackendRenderTarget.Height - size) / 2f;
                var right = left + size;
                var bottom = top + size;

                path.AddArc(new SKRect(left, top, right, bottom), StartingDegrees, EndingDegrees);

                if (Jagged)
                    paint.PathEffect = SKPathEffect.CreateDiscrete(12f, 4f, (uint)Guid.NewGuid().GetHashCode());

                paint.IsAntialias = true;
                paint.StrokeCap = SKStrokeCap.Round;
                paint.Style = SKPaintStyle.Stroke;
                paint.Color = ProgressColor.ToSKColor();
                paint.StrokeWidth = ProgressThickness;
                canvas.DrawPath(path, paint);
            }
        }
    }
}
