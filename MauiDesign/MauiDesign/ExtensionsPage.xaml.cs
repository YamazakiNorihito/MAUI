namespace MauiDesign;

public partial class ExtensionsPage : ContentPage
{
    public const double MyFontSize = 100;
    public ExtensionsPage()
	{
		InitializeComponent();
	}
}
public class GlobalFontSizeExtension : IMarkupExtension
{
    public object ProvideValue(IServiceProvider serviceProvider)
    {
        return ExtensionsPage.MyFontSize;
    }
}

[ContentProperty("Member")]
public class StaticExtension : IMarkupExtension
{
    public string Member { get; set; }
    public object ProvideValue(IServiceProvider serviceProvider)
    {
        return Member;
    }
}