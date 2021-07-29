using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

//important: fonts should be as "inserted resources"
//material google fonts and icons
[assembly: ExportFont("NotoSansKR-Regular.otf", Alias = "FontRegular")]
[assembly: ExportFont("NotoSansKR-Bold.otf", Alias = "FontBold")]
[assembly: ExportFont("NotoSansKR-Black.otf", Alias = "FontBrands")]
[assembly: ExportFont("NotoSansKR-Light.otf", Alias = "FontLight")]
[assembly: ExportFont("MaterialIconsRound-Regular.otf", Alias = "MaterialIcons")]