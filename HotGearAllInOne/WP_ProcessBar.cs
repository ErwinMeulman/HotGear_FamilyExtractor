using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace HotGearAllInOne
{
	public class WP_ProcessBar : Form
	{
		internal string Path;

		internal List<Family> FL;

		internal int PB;

		internal Document DOC;

		private IContainer components = null;

		private ProgressBar progressBar1;

		private Button button2;

		private BindingSource bindingSource1;

		public WP_ProcessBar(Document doc, string path, List<Family> filtereleList, int processbar)
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			this.InitializeComponent();
			this.DOC = doc;
			this.FL = filtereleList;
			this.PB = processbar;
			this.Path = path;
			this.WP_ProcessBar_Load();
		}

		private void WP_ProcessBar_Load()
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0025: Unknown result type (might be due to invalid IL or missing references)
			//IL_002d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0049: Unknown result type (might be due to invalid IL or missing references)
			//IL_004e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0051: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
			//IL_0101: Unknown result type (might be due to invalid IL or missing references)
			//IL_0103: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0120: Unknown result type (might be due to invalid IL or missing references)
			//IL_0135: Unknown result type (might be due to invalid IL or missing references)
			//IL_014a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0151: Unknown result type (might be due to invalid IL or missing references)
			//IL_0166: Unknown result type (might be due to invalid IL or missing references)
			this.progressBar1.Maximum = this.PB;
			int num = 0;
			int num2 = 0;
			SaveAsOptions val = new SaveAsOptions();
			val.set_Compact(true);
			val.set_MaximumBackups(1);
			val.set_OverwriteExistingFile(true);
			foreach (Family item in this.FL)
			{
				string name = item.get_Name();
				num2++;
				this.Text = "HotGear Project Family Extractor Process : " + num2.ToString() + "/" + this.PB;
				this.progressBar1.Value = num2;
				try
				{
					if (item.get_IsEditable())
					{
						string path = this.Path + "\\" + item.get_FamilyCategory().get_Name() + "\\";
						if (!Directory.Exists(path))
						{
							Directory.CreateDirectory(path);
						}
						Document val2 = this.DOC.EditFamily(item);
						val2.SaveAs(this.Path + "\\" + item.get_FamilyCategory().get_Name() + "\\" + item.get_Name() + ".rfa", val);
						val2.Close(false);
					}
				}
				catch (ObjectDisposedException)
				{
				}
				catch (Exception ex2)
				{
					MessageBox.Show(item.get_Name() + ex2.Message);
				}
				num++;
				base.Show();
				Application.DoEvents();
			}
			base.Close();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			base.Close();
			MessageBox.Show("Process is Canceled");
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.components = new Container();
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(WP_ProcessBar));
			this.progressBar1 = new ProgressBar();
			this.button2 = new Button();
			this.bindingSource1 = new BindingSource(this.components);
			((ISupportInitialize)this.bindingSource1).BeginInit();
			base.SuspendLayout();
			this.progressBar1.Location = new Point(12, 12);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new Size(600, 20);
			this.progressBar1.TabIndex = 0;
			this.button2.FlatStyle = FlatStyle.Flat;
			this.button2.Location = new Point(512, 38);
			this.button2.Name = "button2";
			this.button2.Size = new Size(100, 30);
			this.button2.TabIndex = 1;
			this.button2.Text = "Cancel";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += this.button2_Click;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(624, 77);
			base.Controls.Add(this.button2);
			base.Controls.Add(this.progressBar1);
			base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "WP_ProcessBar";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "WP_ProcessBar";
			((ISupportInitialize)this.bindingSource1).EndInit();
			base.ResumeLayout(false);
		}
	}
}
