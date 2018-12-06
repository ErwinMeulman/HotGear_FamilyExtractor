using Autodesk.Revit.UI;
using System.IO;
using System.Reflection;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace HotGear
{
	public class HotGearPackage
	{
		private static string AddInPath = typeof(HotGearPackage).Assembly.Location;

		public Result OnStartup(UIControlledApplication application)
		{
			//IL_0008: Unknown result type (might be due to invalid IL or missing references)
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0024: Unknown result type (might be due to invalid IL or missing references)
			//IL_002b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Unknown result type (might be due to invalid IL or missing references)
			//IL_003b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0040: Unknown result type (might be due to invalid IL or missing references)
			//IL_0041: Unknown result type (might be due to invalid IL or missing references)
			//IL_0042: Unknown result type (might be due to invalid IL or missing references)
			//IL_0043: Unknown result type (might be due to invalid IL or missing references)
			//IL_0048: Expected O, but got Unknown
			//IL_004d: Unknown result type (might be due to invalid IL or missing references)
			//IL_004f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0065: Unknown result type (might be due to invalid IL or missing references)
			//IL_006a: Unknown result type (might be due to invalid IL or missing references)
			//IL_006f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0071: Unknown result type (might be due to invalid IL or missing references)
			//IL_007e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0090: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00da: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
			//IL_0100: Unknown result type (might be due to invalid IL or missing references)
			//IL_0108: Unknown result type (might be due to invalid IL or missing references)
			//IL_010c: Unknown result type (might be due to invalid IL or missing references)
			string text = "Hot Gear";
			try
			{
				application.CreateRibbonTab(text);
			}
			catch
			{
			}
			RibbonPanel val = application.CreateRibbonPanel(text, "Family Extractor");
			ContextualHelp contextualHelp = new ContextualHelp(2, "https://hotgearproject.gitbooks.io/hotgear-project/content/6.family_extractor.html");
			SplitButtonData val2 = new SplitButtonData("HotGear", "HotGear");
			SplitButton val3 = val.AddItem(val2) as SplitButton;
			PushButton val4 = val3.AddPushButton(new PushButtonData("FamilyExtractor", "Family Extractor", HotGearPackage.AddInPath, "FamilyExtractor"));
			val4.set_ToolTip("Extractor All Selected Category Family in Project.");
			val4.set_LargeImage(HotGearPackage.RetriveImage("HotGearAllInOne.Resources.FamilyExtractor.png"));
			val4.set_Image(HotGearPackage.RetriveImage("HotGearAllInOne.Resources.FamilyExtractor_s.png"));
			val4.SetContextualHelp(contextualHelp);
			val4 = val3.AddPushButton(new PushButtonData("About", "About", HotGearPackage.AddInPath, "About"));
			val4.set_ToolTip("About HotGear Project");
			val4.set_LargeImage(HotGearPackage.RetriveImage("HotGearAllInOne.Resources.gear32.png"));
			val4.set_Image(HotGearPackage.RetriveImage("HotGearAllInOne.Resources.gear16.png"));
			val4.SetContextualHelp(contextualHelp);
			return 0;
		}

		public Result OnShutdown(UIControlledApplication application)
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_0005: Unknown result type (might be due to invalid IL or missing references)
			return 0;
		}

		public static ImageSource RetriveImage(string imagePath)
		{
			Stream manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(imagePath);
			switch (imagePath.Substring(imagePath.Length - 3))
			{
			case "jpg":
			{
				JpegBitmapDecoder jpegBitmapDecoder = new JpegBitmapDecoder(manifestResourceStream, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
				return jpegBitmapDecoder.Frames[0];
			}
			case "bmp":
			{
				BmpBitmapDecoder bmpBitmapDecoder = new BmpBitmapDecoder(manifestResourceStream, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
				return bmpBitmapDecoder.Frames[0];
			}
			case "png":
			{
				PngBitmapDecoder pngBitmapDecoder = new PngBitmapDecoder(manifestResourceStream, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
				return pngBitmapDecoder.Frames[0];
			}
			case "ico":
			{
				IconBitmapDecoder iconBitmapDecoder = new IconBitmapDecoder(manifestResourceStream, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
				return iconBitmapDecoder.Frames[0];
			}
			default:
				return null;
			}
		}
	}
}
