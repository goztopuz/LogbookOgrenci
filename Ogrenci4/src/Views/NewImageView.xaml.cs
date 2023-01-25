using CommunityToolkit.Mvvm.Messaging;
using Ogrenci4.src.Models;

namespace Ogrenci4.src.Views;

public partial class NewImageView : ContentPage
{
    string _filePath = "";
    public NewImageView(ImageSource imgFilePath)
    {
        InitializeComponent();
        imgStudy.Source = imgFilePath;
        _filePath = imgFilePath.ToString();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        if (_filePath.StartsWith("Uri"))
        {

            //Api'den Sil 
            //Resim Listesinden Sil....(MsgCenter - Düzenle)

            WeakReferenceMessenger.Default.Send(new DosyaApiSilMessage(_filePath));
            WeakReferenceMessenger.Default.Send(new RefreshMessage("DosyaSil"));


        }
        else
        {

            //Resim Listesinden Sil....(MsgCenter - Yeni)
            WeakReferenceMessenger.Default.Send(new DosyaKaldirMessage(_filePath));
        }

        await Navigation.PopAsync();


    }
}

public class PinchToZoomContainer : ContentView
{
    double currentScale = 1;
    double startScale = 1;
    double xOffset = 0;
    double yOffset = 0;

    public PinchToZoomContainer()
    {
        var pinchGesture = new PinchGestureRecognizer();
        pinchGesture.PinchUpdated += OnPinchUpdated;
        GestureRecognizers.Add(pinchGesture);
    }

    void OnPinchUpdated(object sender, PinchGestureUpdatedEventArgs e)
    {
        if (e.Status == GestureStatus.Started)
        {
            // Store the current scale factor applied to the wrapped user interface element,
            // and zero the components for the center point of the translate transform.
            startScale = Content.Scale;
            Content.AnchorX = 0;
            Content.AnchorY = 0;
        }
        if (e.Status == GestureStatus.Running)
        {
            // Calculate the scale factor to be applied.
            currentScale += (e.Scale - 1) * startScale;
            currentScale = Math.Max(1, currentScale);

            // The ScaleOrigin is in relative coordinates to the wrapped user interface element,
            // so get the X pixel coordinate.
            double renderedX = Content.X + xOffset;
            double deltaX = renderedX / Width;
            double deltaWidth = Width / (Content.Width * startScale);
            double originX = (e.ScaleOrigin.X - deltaX) * deltaWidth;

            // The ScaleOrigin is in relative coordinates to the wrapped user interface element,
            // so get the Y pixel coordinate.
            double renderedY = Content.Y + yOffset;
            double deltaY = renderedY / Height;
            double deltaHeight = Height / (Content.Height * startScale);
            double originY = (e.ScaleOrigin.Y - deltaY) * deltaHeight;

            // Calculate the transformed element pixel coordinates.
            double targetX = xOffset - (originX * Content.Width) * (currentScale - startScale);
            double targetY = yOffset - (originY * Content.Height) * (currentScale - startScale);

            // Apply translation based on the change in origin.
            Content.TranslationX = targetX.Clamp(-Content.Width * (currentScale - 1), 0);
            Content.TranslationY = targetY.Clamp(-Content.Height * (currentScale - 1), 0);

            // Apply scale factor
            Content.Scale = currentScale;
        }
        if (e.Status == GestureStatus.Completed)
        {
            // Store the translation delta's of the wrapped user interface element.
            xOffset = Content.TranslationX;
            yOffset = Content.TranslationY;
        }
    }

}

public static class DoubleExtensions
{
    public static double Clamp(this double self, double min, double max)
    {
        return Math.Min(max, Math.Max(self, min));
    }
}