namespace MauiDesign;

public partial class NoteOSPage : ContentPage
{
    string _fileName = Path.Combine(FileSystem.AppDataDirectory, "notes.txt");
    //Editor editor;

    public NoteOSPage()
	{
		InitializeComponent();
        MyStackLayout.Padding =
            DeviceInfo.Platform == DevicePlatform.iOS
                ? new Thickness(30, 60, 30, 30) // Shift down by 60 points on iOS only
                : new Thickness(30); // Set the default margin to be 30 points
    }
    void OnSaveButtonClicked(object sender, EventArgs e)
    {
        File.WriteAllText(_fileName, editor.Text);
    }

    void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        if (File.Exists(_fileName))
        {
            File.Delete(_fileName);
        }
        editor.Text = string.Empty;
    }
}