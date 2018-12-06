using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using HotGearAllInOne;
using System.Collections.Generic;
using System.Linq;

[Transaction()]
[Regeneration()]
public class FamilyExtractor
{
	public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_0174: Unknown result type (might be due to invalid IL or missing references)
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		//IL_0198: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Unknown result type (might be due to invalid IL or missing references)
		UIApplication application = commandData.get_Application();
		Document document = application.get_ActiveUIDocument().get_Document();
		UIDocument activeUIDocument = application.get_ActiveUIDocument();
		Application application2 = commandData.get_Application().get_Application();
		List<string> list = new List<string>();
		foreach (Document document2 in application2.get_Documents())
		{
			list.Add(document2.get_Title());
		}
		GlobalVar.G_Doc_Selection = list;
		CategorySelection categorySelection = new CategorySelection();
		categorySelection.InitializeComponent(commandData);
		categorySelection.ShowDialog();
		List<Family> g_Ele = GlobalVar.G_Ele;
		List<string> g_Cat_Selection = GlobalVar.G_Cat_Selection;
		string g_Path = GlobalVar.G_Path;
		Document g_Sel_Doc = GlobalVar.G_Sel_Doc;
		if (g_Cat_Selection == null)
		{
			return 0;
		}
		List<ElementId> list2 = new List<ElementId>();
		foreach (Family item in g_Ele)
		{
			foreach (string item2 in g_Cat_Selection)
			{
				if (item.get_FamilyCategory().get_Name() == item2)
				{
					list2.Add(item.get_FamilyCategory().get_Id());
				}
			}
		}
		List<ElementId> cat_id = ((IEnumerable<ElementId>)list2).Distinct<ElementId>().ToList<ElementId>();
		List<Family> list3 = Method.CategoryFilter(g_Sel_Doc, cat_id);
		int count = list3.Count;
		WP_ProcessBar wP_ProcessBar = new WP_ProcessBar(g_Sel_Doc, g_Path, list3, count);
		return 0;
	}
}
