using Autodesk.Revit.DB;
using System.Collections.Generic;

public class MyFailuresPreProcessor
{
	private string _failureMessage;

	private bool _hasError;

	public string FailureMessage
	{
		get
		{
			return this._failureMessage;
		}
		set
		{
			this._failureMessage = value;
		}
	}

	public bool HasError
	{
		get
		{
			return this._hasError;
		}
		set
		{
			this._hasError = value;
		}
	}

	public FailureProcessingResult PreprocessFailures(FailuresAccessor failuresAccessor)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Invalid comparison between Unknown and I4
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Invalid comparison between Unknown and I4
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		IList<FailureMessageAccessor> failureMessages = failuresAccessor.GetFailureMessages();
		if (failureMessages.Count == 0)
		{
			return 0;
		}
		foreach (FailureMessageAccessor item in failureMessages)
		{
			if ((int)item.GetSeverity() == 2)
			{
				this._failureMessage = item.GetDescriptionText();
				this._hasError = true;
				return 1;
			}
			if ((int)item.GetSeverity() == 1)
			{
				failuresAccessor.DeleteWarning(item);
			}
		}
		return 0;
	}
}
