using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using HotGearAllInOne;

[Transaction()]
[Regeneration()]
public class About
{
	public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		WF_About wF_About = new WF_About();
		wF_About.Show();
		return 0;
	}
}
