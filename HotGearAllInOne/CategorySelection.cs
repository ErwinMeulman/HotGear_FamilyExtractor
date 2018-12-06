using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace HotGearAllInOne
{
	public class CategorySelection : Form
	{
		internal string I_path;

		internal List<Family> I_FamilySymbol;

		internal List<string> I_cat_name;

		internal ICollection<ElementId> I_Eleid;

		internal Document I_Doc;

		internal ExternalCommandData cmddata;

		internal Document HGDoc;

		internal UIApplication HGUiApp;

		internal Application HGApp;

		internal UIDocument HGUiDoc;

		internal View HGActiveView;

		private int count = 0;

		private int un_check = 2;

		private IContainer components = null;

		private TreeView treeView1;

		private Button button1;

		private Button button2;

		private Button button3;

		private ToolTip toolTip1;

		private ComboBox comboBox1;

		private Label label1;

		private Label label2;

		private Button button4;

		private FolderBrowserDialog folderBrowserDialog1;

		private TextBox textBox1;

		private Label label3;

		public CategorySelection()
		{
			this.InitializeComponent();
		}

		public void InitializeComponent(ExternalCommandData cmdData)
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_0003: Unknown result type (might be due to invalid IL or missing references)
			//IL_0009: Unknown result type (might be due to invalid IL or missing references)
			//IL_000a: Unknown result type (might be due to invalid IL or missing references)
			//IL_000f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0016: Unknown result type (might be due to invalid IL or missing references)
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_0025: Unknown result type (might be due to invalid IL or missing references)
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Unknown result type (might be due to invalid IL or missing references)
			//IL_0036: Unknown result type (might be due to invalid IL or missing references)
			//IL_003d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0042: Unknown result type (might be due to invalid IL or missing references)
			//IL_0047: Unknown result type (might be due to invalid IL or missing references)
			//IL_004d: Unknown result type (might be due to invalid IL or missing references)
			//IL_004e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0053: Unknown result type (might be due to invalid IL or missing references)
			//IL_0058: Unknown result type (might be due to invalid IL or missing references)
			this.cmddata = cmdData;
			this.HGUiApp = cmdData.get_Application();
			this.HGDoc = this.HGUiApp.get_ActiveUIDocument().get_Document();
			this.HGUiDoc = this.HGUiApp.get_ActiveUIDocument();
			this.HGActiveView = this.HGDoc.get_ActiveView();
			this.HGApp = cmdData.get_Application().get_Application();
		}

		private void CategorySelection_Load(object sender, EventArgs e)
		{
			this.Text = "Family Extractor : Category Selection";
			List<string> g_Doc_Selection = GlobalVar.G_Doc_Selection;
			foreach (string item in g_Doc_Selection)
			{
				this.comboBox1.Items.Add(item);
			}
			this.comboBox1.SelectedIndex = 0;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
			if (this.textBox1.Text == string.Empty)
			{
				MessageBox.Show("Please Enter the Path.");
			}
			else
			{
				List<string> i_cat_name = this.I_cat_name;
				List<string> list = new List<string>();
				foreach (TreeNode node in this.treeView1.Nodes)
				{
					if (node.Checked)
					{
						list.Add(i_cat_name[node.Index]);
					}
				}
				this.I_path = this.textBox1.Text;
				this.count = list.Count;
				GlobalVar.G_Ele = this.I_FamilySymbol;
				GlobalVar.G_Cat_Selection = list;
				GlobalVar.G_Sel_Doc = this.I_Doc;
				GlobalVar.G_Eleid = this.I_Eleid;
				GlobalVar.G_Path = this.I_path;
				base.Close();
			}
		}

		protected override void OnFormClosed(FormClosedEventArgs e)
		{
			if (this.count == 0)
			{
				GlobalVar.G_Cat_Selection = null;
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			GlobalVar.G_Cat_Selection = null;
			base.Close();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			if (this.un_check % 2 != 0)
			{
				foreach (TreeNode node in this.treeView1.Nodes)
				{
					node.Checked = false;
				}
			}
			else
			{
				foreach (TreeNode node2 in this.treeView1.Nodes)
				{
					node2.Checked = true;
				}
			}
			this.un_check++;
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0024: Unknown result type (might be due to invalid IL or missing references)
			//IL_0029: Unknown result type (might be due to invalid IL or missing references)
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0036: Unknown result type (might be due to invalid IL or missing references)
			//IL_0037: Unknown result type (might be due to invalid IL or missing references)
			//IL_004c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0051: Unknown result type (might be due to invalid IL or missing references)
			//IL_0055: Unknown result type (might be due to invalid IL or missing references)
			//IL_0081: Unknown result type (might be due to invalid IL or missing references)
			//IL_0086: Unknown result type (might be due to invalid IL or missing references)
			//IL_0088: Unknown result type (might be due to invalid IL or missing references)
			//IL_008a: Unknown result type (might be due to invalid IL or missing references)
			//IL_008b: Unknown result type (might be due to invalid IL or missing references)
			//IL_009a: Unknown result type (might be due to invalid IL or missing references)
			//IL_009f: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Expected O, but got Unknown
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00da: Unknown result type (might be due to invalid IL or missing references)
			//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
			//IL_0295: Unknown result type (might be due to invalid IL or missing references)
			//IL_0296: Unknown result type (might be due to invalid IL or missing references)
			//IL_029c: Unknown result type (might be due to invalid IL or missing references)
			this.treeView1.Nodes.Clear();
			int selectedIndex = this.comboBox1.SelectedIndex;
			Application application = this.cmddata.get_Application().get_Application();
			List<Document> list = new List<Document>();
			foreach (Document document in application.get_Documents())
			{
				list.Add(document);
			}
			Document val = list[selectedIndex];
			FilteredElementCollector val2 = null;
			val2 = new FilteredElementCollector(val).OfClass(typeof(Family));
			IList<Element> list2 = val2.ToElements();
			List<Family> list3 = new List<Family>();
			List<string> list4 = new List<string>();
			List<int> list5 = new List<int>();
			foreach (Element item in list2)
			{
				Family val3 = item;
				if ((int)val3.get_FamilyCategory() != 0 && val3.get_IsEditable())
				{
					list3.Add(val3);
				}
			}
			var enumerable = from x in (IEnumerable<Family>)list3
			group x by x.get_FamilyCategory().get_Name() into g
			let count = ((IEnumerable<Family>)g).Count<Family>()
			let name = ((IEnumerable<Family>)g).First<Family>().get_FamilyCategory().get_Name()
			orderby name
			select new
			{
				Name = g.Key,
				Count = count
			};
			foreach (var item2 in enumerable)
			{
				list4.Add(item2.Name);
				list5.Add(item2.Count);
			}
			for (int i = 0; i < list4.Count; i++)
			{
				this.treeView1.Nodes.Add(list4[i] + "(" + list5[i] + ")");
			}
			this.I_FamilySymbol = list3;
			this.I_cat_name = list4;
			this.I_Doc = val;
			this.I_Eleid = val2.ToElementIds();
		}

		private void button4_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
			folderBrowserDialog.ShowDialog();
			this.textBox1.Text = folderBrowserDialog.SelectedPath;
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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(CategorySelection));
			this.treeView1 = new TreeView();
			this.button1 = new Button();
			this.button2 = new Button();
			this.button3 = new Button();
			this.toolTip1 = new ToolTip(this.components);
			this.comboBox1 = new ComboBox();
			this.label1 = new Label();
			this.label2 = new Label();
			this.button4 = new Button();
			this.folderBrowserDialog1 = new FolderBrowserDialog();
			this.textBox1 = new TextBox();
			this.label3 = new Label();
			base.SuspendLayout();
			this.treeView1.CheckBoxes = true;
			this.treeView1.Location = new Point(12, 119);
			this.treeView1.Name = "treeView1";
			this.treeView1.Size = new Size(339, 398);
			this.treeView1.TabIndex = 0;
			this.button1.Location = new Point(195, 523);
			this.button1.Name = "button1";
			this.button1.Size = new Size(75, 23);
			this.button1.TabIndex = 1;
			this.button1.Text = "OK";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += this.button1_Click;
			this.button2.Location = new Point(276, 523);
			this.button2.Name = "button2";
			this.button2.Size = new Size(75, 23);
			this.button2.TabIndex = 2;
			this.button2.Text = "Cancel";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += this.button2_Click;
			this.button3.Location = new Point(12, 521);
			this.button3.Name = "button3";
			this.button3.Size = new Size(118, 23);
			this.button3.TabIndex = 3;
			this.button3.Text = "Check / Uncheck All";
			this.toolTip1.SetToolTip(this.button3, "Check or Uncheck all item In the list.");
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += this.button3_Click;
			this.comboBox1.BackColor = Color.White;
			this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
			this.comboBox1.FlatStyle = FlatStyle.Popup;
			this.comboBox1.ForeColor = Color.Black;
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new Point(12, 27);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new Size(339, 21);
			this.comboBox1.TabIndex = 4;
			this.comboBox1.SelectedIndexChanged += this.comboBox1_SelectedIndexChanged;
			this.label1.AutoSize = true;
			this.label1.Location = new Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new Size(103, 13);
			this.label1.TabIndex = 5;
			this.label1.Text = "Document Selection";
			this.label2.AutoSize = true;
			this.label2.Location = new Point(12, 97);
			this.label2.Name = "label2";
			this.label2.Size = new Size(96, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "Category Selection";
			this.button4.Location = new Point(321, 70);
			this.button4.Name = "button4";
			this.button4.Size = new Size(30, 22);
			this.button4.TabIndex = 6;
			this.button4.Text = "...";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += this.button4_Click;
			this.textBox1.Location = new Point(12, 71);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new Size(303, 20);
			this.textBox1.TabIndex = 7;
			this.label3.AutoSize = true;
			this.label3.Location = new Point(12, 53);
			this.label3.Name = "label3";
			this.label3.Size = new Size(57, 13);
			this.label3.TabIndex = 8;
			this.label3.Text = "Save Path";
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(362, 556);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.textBox1);
			base.Controls.Add(this.button4);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.comboBox1);
			base.Controls.Add(this.button3);
			base.Controls.Add(this.button2);
			base.Controls.Add(this.button1);
			base.Controls.Add(this.treeView1);
			base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "CategorySelection";
			this.Text = "Category Selection";
			base.Load += this.CategorySelection_Load;
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
