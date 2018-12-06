using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace HotGearAllInOne.Properties
{
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	internal class Resources
	{
		private static ResourceManager resourceMan;

		private static CultureInfo resourceCulture;

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (Resources.resourceMan == null)
				{
					ResourceManager resourceManager = Resources.resourceMan = new ResourceManager("HotGearAllInOne.Properties.Resources", typeof(Resources).Assembly);
				}
				return Resources.resourceMan;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return Resources.resourceCulture;
			}
			set
			{
				Resources.resourceCulture = value;
			}
		}

		internal static Bitmap FamilyExtractor
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("FamilyExtractor", Resources.resourceCulture);
				return (Bitmap)@object;
			}
		}

		internal static Bitmap FamilyExtractor_s
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("FamilyExtractor_s", Resources.resourceCulture);
				return (Bitmap)@object;
			}
		}

		internal static Bitmap gear
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("gear", Resources.resourceCulture);
				return (Bitmap)@object;
			}
		}

		internal static Bitmap gear16
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("gear16", Resources.resourceCulture);
				return (Bitmap)@object;
			}
		}

		internal static Bitmap gear32
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("gear32", Resources.resourceCulture);
				return (Bitmap)@object;
			}
		}

		internal static Bitmap pp_donate
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("pp_donate", Resources.resourceCulture);
				return (Bitmap)@object;
			}
		}

		internal Resources()
		{
		}
	}
}
