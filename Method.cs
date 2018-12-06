using Autodesk.Revit.DB;
using System.Collections.Generic;

public class Method
{
	private const double _inch_to_mm = 25.4;

	private const double _foot_to_mm = 304.79999999999995;

	public static string RealString(double a)
	{
		return a.ToString("0.##");
	}

	public static string PointStringMm(XYZ p)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		return string.Format("{0},{1},{2}", Method.RealString(p.get_X() * 304.79999999999995), Method.RealString(p.get_Y() * 304.79999999999995), Method.RealString(p.get_Z() * 304.79999999999995));
	}

	public static List<Element> GeometryFilter(Document doc, ICollection<ElementId> id)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_014f: Unknown result type (might be due to invalid IL or missing references)
		List<ElementCategoryFilter> list = new List<ElementCategoryFilter>();
		list.Add(new ElementCategoryFilter(-2000011));
		list.Add(new ElementCategoryFilter(-2000032));
		list.Add(new ElementCategoryFilter(-2000100));
		list.Add(new ElementCategoryFilter(-2000180));
		list.Add(new ElementCategoryFilter(-2000038));
		list.Add(new ElementCategoryFilter(-2001330));
		list.Add(new ElementCategoryFilter(-2001300));
		list.Add(new ElementCategoryFilter(-2000151));
		list.Add(new ElementCategoryFilter(-2000120));
		list.Add(new ElementCategoryFilter(-2001220));
		list.Add(new ElementCategoryFilter(-2001320));
		list.Add(new ElementCategoryFilter(-2000035));
		list.Add(new ElementCategoryFilter(-2003400));
		list.Add(new ElementCategoryFilter(-2000269));
		list.Add(new ElementCategoryFilter(-2001336));
		List<Element> list2 = new List<Element>();
		foreach (ElementCategoryFilter item in list)
		{
			FilteredElementCollector val = new FilteredElementCollector(doc, id);
			foreach (Element item2 in val.WherePasses(item).WhereElementIsNotElementType().ToElements())
			{
				list2.Add(item2);
			}
		}
		return list2;
	}

	public static List<Family> CategoryFilter(Document doc, List<ElementId> Cat_id)
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Expected O, but got Unknown
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		List<ElementCategoryFilter> list = new List<ElementCategoryFilter>();
		List<Family> list2 = new List<Family>();
		foreach (ElementId item in Cat_id)
		{
			FilteredElementCollector val = new FilteredElementCollector(doc);
			foreach (Element item2 in val.OfClass(typeof(Family)).ToElements())
			{
				Family val2 = item2;
				if (val2.get_FamilyCategory().get_Id() == item)
				{
					list2.Add(val2);
				}
			}
		}
		return list2;
	}
}
