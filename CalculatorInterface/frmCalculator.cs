using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Electroimpact;

namespace CalculatorInterface
{
	public class frmCalculator : System.Windows.Forms.Form
	{

		int frmWidth_vars = 1000;
		int frmWidth_std = 735;
		int frmHeight = 450;

		#region MEMBERS
		private System.Windows.Forms.TextBox txtMathString;
		private System.Windows.Forms.Button btnCalculateIt;
		private System.Windows.Forms.Label lblMethod2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton opnDegrees;
		private System.Windows.Forms.RadioButton opnRadians;
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Label lblEquation;
		private Electroimpact.StringCalc.cStringCalc _StringCalc = new Electroimpact.StringCalc.cStringCalc();
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.RadioButton opnEngineering;
		private System.Windows.Forms.RadioButton opnScientific;
		private System.Windows.Forms.RadioButton opnNewMath;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cmbDecimals;
		private System.Windows.Forms.ComboBox cmbFunctions;
		private System.Windows.Forms.ComboBox cmbConstants;
		private System.Windows.Forms.ToolTip myTip = new ToolTip();
		private System.Timers.Timer _tmrDoubleClick = new System.Timers.Timer( 200 );
		private System.Windows.Forms.RadioButton opnMoney;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ListBox lstEquations;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.ListBox lstVars;
		private System.Windows.Forms.CheckBox chkShowVars;
		private System.Windows.Forms.TextBox txtVarName;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtVarValue;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.Button btnDelete;
		private System.Windows.Forms.Button btnSaveEq;
		private System.Windows.Forms.Button btnDeleteEq;
		private int _DoubleClickCount;
		#endregion

		#region CONSTRUCTOR
		public frmCalculator()
		{
			InitializeComponent();
			this._StringCalc.Degrees = this.opnDegrees.Checked;
			this.cmbDecimals.SelectedIndex = 3;

			string[]functions = this._StringCalc.Functions.Split(' ');
			for( int ii = 0; ii < functions.Length; ii++ )
				this.cmbFunctions.Items.Add(functions[ii]);
			this.cmbFunctions.SelectedIndex = 0;

			csString test = new csString();
			string[] constants = test.constants.Split( ' ' );
			for( int ii = 0; ii < constants.Length; ii++ )
				this.cmbConstants.Items.Add( constants[ii] );
			this.cmbConstants.SelectedIndex = 0;

			this._tmrDoubleClick.Elapsed += new System.Timers.ElapsedEventHandler(_tmrDoubleClick_Elapsed);
			this._tmrDoubleClick.Enabled = false;
			this._DoubleClickCount = 0;

		}
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCalculator));
      this.txtMathString = new System.Windows.Forms.TextBox();
      this.btnCalculateIt = new System.Windows.Forms.Button();
      this.lblMethod2 = new System.Windows.Forms.Label();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.opnRadians = new System.Windows.Forms.RadioButton();
      this.opnDegrees = new System.Windows.Forms.RadioButton();
      this.lblEquation = new System.Windows.Forms.Label();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.opnMoney = new System.Windows.Forms.RadioButton();
      this.label1 = new System.Windows.Forms.Label();
      this.opnNewMath = new System.Windows.Forms.RadioButton();
      this.opnScientific = new System.Windows.Forms.RadioButton();
      this.opnEngineering = new System.Windows.Forms.RadioButton();
      this.cmbDecimals = new System.Windows.Forms.ComboBox();
      this.cmbFunctions = new System.Windows.Forms.ComboBox();
      this.cmbConstants = new System.Windows.Forms.ComboBox();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.lstEquations = new System.Windows.Forms.ListBox();
      this.groupBox3 = new System.Windows.Forms.GroupBox();
      this.btnDelete = new System.Windows.Forms.Button();
      this.btnAdd = new System.Windows.Forms.Button();
      this.label5 = new System.Windows.Forms.Label();
      this.txtVarValue = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.txtVarName = new System.Windows.Forms.TextBox();
      this.lstVars = new System.Windows.Forms.ListBox();
      this.chkShowVars = new System.Windows.Forms.CheckBox();
      this.btnSaveEq = new System.Windows.Forms.Button();
      this.btnDeleteEq = new System.Windows.Forms.Button();
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.groupBox3.SuspendLayout();
      this.SuspendLayout();
      // 
      // txtMathString
      // 
      this.txtMathString.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtMathString.Location = new System.Drawing.Point(16, 458);
      this.txtMathString.Name = "txtMathString";
      this.txtMathString.Size = new System.Drawing.Size(1200, 55);
      this.txtMathString.TabIndex = 0;
      this.txtMathString.Text = "1+2^3/4+1";
      this.txtMathString.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtMathString_KeyUp);
      // 
      // btnCalculateIt
      // 
      this.btnCalculateIt.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnCalculateIt.Location = new System.Drawing.Point(864, 546);
      this.btnCalculateIt.Name = "btnCalculateIt";
      this.btnCalculateIt.Size = new System.Drawing.Size(352, 89);
      this.btnCalculateIt.TabIndex = 2;
      this.btnCalculateIt.Text = "Calculate It";
      this.btnCalculateIt.Click += new System.EventHandler(this.btnCalculateIt_Click);
      // 
      // lblMethod2
      // 
      this.lblMethod2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblMethod2.Location = new System.Drawing.Point(16, 384);
      this.lblMethod2.Name = "lblMethod2";
      this.lblMethod2.Size = new System.Drawing.Size(1200, 44);
      this.lblMethod2.TabIndex = 3;
      this.lblMethod2.Text = "RESULT";
      this.lblMethod2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.opnRadians);
      this.groupBox1.Controls.Add(this.opnDegrees);
      this.groupBox1.Location = new System.Drawing.Point(32, 15);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(160, 133);
      this.groupBox1.TabIndex = 4;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Angle Units";
      // 
      // opnRadians
      // 
      this.opnRadians.Appearance = System.Windows.Forms.Appearance.Button;
      this.opnRadians.Checked = true;
      this.opnRadians.Location = new System.Drawing.Point(16, 74);
      this.opnRadians.Name = "opnRadians";
      this.opnRadians.Size = new System.Drawing.Size(128, 44);
      this.opnRadians.TabIndex = 1;
      this.opnRadians.TabStop = true;
      this.opnRadians.Text = "Radians";
      this.opnRadians.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // opnDegrees
      // 
      this.opnDegrees.Appearance = System.Windows.Forms.Appearance.Button;
      this.opnDegrees.Location = new System.Drawing.Point(16, 30);
      this.opnDegrees.Name = "opnDegrees";
      this.opnDegrees.Size = new System.Drawing.Size(128, 44);
      this.opnDegrees.TabIndex = 0;
      this.opnDegrees.Text = "Degrees";
      this.opnDegrees.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.opnDegrees.CheckedChanged += new System.EventHandler(this.opnDegrees_CheckedChanged);
      // 
      // lblEquation
      // 
      this.lblEquation.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblEquation.Location = new System.Drawing.Point(16, 325);
      this.lblEquation.Name = "lblEquation";
      this.lblEquation.Size = new System.Drawing.Size(1200, 44);
      this.lblEquation.TabIndex = 5;
      this.lblEquation.Text = "Equation";
      this.lblEquation.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.opnMoney);
      this.groupBox2.Controls.Add(this.label1);
      this.groupBox2.Controls.Add(this.opnNewMath);
      this.groupBox2.Controls.Add(this.opnScientific);
      this.groupBox2.Controls.Add(this.opnEngineering);
      this.groupBox2.Controls.Add(this.cmbDecimals);
      this.groupBox2.Location = new System.Drawing.Point(304, 15);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(896, 133);
      this.groupBox2.TabIndex = 6;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Output Format";
      // 
      // opnMoney
      // 
      this.opnMoney.Appearance = System.Windows.Forms.Appearance.Button;
      this.opnMoney.Location = new System.Drawing.Point(400, 30);
      this.opnMoney.Name = "opnMoney";
      this.opnMoney.Size = new System.Drawing.Size(176, 44);
      this.opnMoney.TabIndex = 6;
      this.opnMoney.Text = "$$ Money $$";
      this.opnMoney.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // label1
      // 
      this.label1.Location = new System.Drawing.Point(184, 81);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(176, 39);
      this.label1.TabIndex = 5;
      this.label1.Text = "Decimal Places";
      this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // opnNewMath
      // 
      this.opnNewMath.Appearance = System.Windows.Forms.Appearance.Button;
      this.opnNewMath.Location = new System.Drawing.Point(576, 30);
      this.opnNewMath.Name = "opnNewMath";
      this.opnNewMath.Size = new System.Drawing.Size(176, 44);
      this.opnNewMath.TabIndex = 4;
      this.opnNewMath.Text = "No Format";
      this.opnNewMath.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // opnScientific
      // 
      this.opnScientific.Appearance = System.Windows.Forms.Appearance.Button;
      this.opnScientific.Location = new System.Drawing.Point(224, 30);
      this.opnScientific.Name = "opnScientific";
      this.opnScientific.Size = new System.Drawing.Size(176, 44);
      this.opnScientific.TabIndex = 3;
      this.opnScientific.Text = "Scientific";
      this.opnScientific.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // opnEngineering
      // 
      this.opnEngineering.Appearance = System.Windows.Forms.Appearance.Button;
      this.opnEngineering.Checked = true;
      this.opnEngineering.Location = new System.Drawing.Point(48, 30);
      this.opnEngineering.Name = "opnEngineering";
      this.opnEngineering.Size = new System.Drawing.Size(176, 44);
      this.opnEngineering.TabIndex = 2;
      this.opnEngineering.TabStop = true;
      this.opnEngineering.Text = "Engineering";
      this.opnEngineering.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // cmbDecimals
      // 
      this.cmbDecimals.Items.AddRange(new object[] {
            "0",
            "0.0",
            "0.00",
            "0.000",
            "0.0000",
            "0.00000"});
      this.cmbDecimals.Location = new System.Drawing.Point(376, 81);
      this.cmbDecimals.Name = "cmbDecimals";
      this.cmbDecimals.Size = new System.Drawing.Size(242, 33);
      this.cmbDecimals.TabIndex = 0;
      // 
      // cmbFunctions
      // 
      this.cmbFunctions.Location = new System.Drawing.Point(48, 192);
      this.cmbFunctions.Name = "cmbFunctions";
      this.cmbFunctions.Size = new System.Drawing.Size(242, 33);
      this.cmbFunctions.TabIndex = 7;
      this.cmbFunctions.Text = "cmbFunctions";
      this.cmbFunctions.DoubleClick += new System.EventHandler(this.cmbFunctions_DoubleClick);
      this.cmbFunctions.MouseUp += new System.Windows.Forms.MouseEventHandler(this.cmbFunctions_MouseUp);
      // 
      // cmbConstants
      // 
      this.cmbConstants.Location = new System.Drawing.Point(48, 266);
      this.cmbConstants.Name = "cmbConstants";
      this.cmbConstants.Size = new System.Drawing.Size(242, 33);
      this.cmbConstants.TabIndex = 8;
      this.cmbConstants.Text = "cmbConstants";
      this.cmbConstants.DoubleClick += new System.EventHandler(this.cmbConstants_DoubleClick);
      this.cmbConstants.MouseUp += new System.Windows.Forms.MouseEventHandler(this.cmbConstants_MouseUp);
      // 
      // label2
      // 
      this.label2.Location = new System.Drawing.Point(48, 162);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(200, 30);
      this.label2.TabIndex = 9;
      this.label2.Text = "Functions:";
      // 
      // label3
      // 
      this.label3.Location = new System.Drawing.Point(48, 236);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(200, 30);
      this.label3.TabIndex = 10;
      this.label3.Text = "Constants:";
      // 
      // lstEquations
      // 
      this.lstEquations.ItemHeight = 25;
      this.lstEquations.Location = new System.Drawing.Point(320, 177);
      this.lstEquations.Name = "lstEquations";
      this.lstEquations.Size = new System.Drawing.Size(896, 79);
      this.lstEquations.TabIndex = 11;
      this.lstEquations.SelectedIndexChanged += new System.EventHandler(this.lstEquations_SelectedIndexChanged);
      this.lstEquations.DoubleClick += new System.EventHandler(this.lstEquations_DoubleClick);
      // 
      // groupBox3
      // 
      this.groupBox3.Controls.Add(this.btnDelete);
      this.groupBox3.Controls.Add(this.btnAdd);
      this.groupBox3.Controls.Add(this.label5);
      this.groupBox3.Controls.Add(this.txtVarValue);
      this.groupBox3.Controls.Add(this.label4);
      this.groupBox3.Controls.Add(this.txtVarName);
      this.groupBox3.Controls.Add(this.lstVars);
      this.groupBox3.Location = new System.Drawing.Point(1248, 15);
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.Size = new System.Drawing.Size(432, 620);
      this.groupBox3.TabIndex = 13;
      this.groupBox3.TabStop = false;
      this.groupBox3.Text = "User Variables";
      // 
      // btnDelete
      // 
      this.btnDelete.Location = new System.Drawing.Point(224, 561);
      this.btnDelete.Name = "btnDelete";
      this.btnDelete.Size = new System.Drawing.Size(150, 43);
      this.btnDelete.TabIndex = 6;
      this.btnDelete.Text = "Delete";
      this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
      // 
      // btnAdd
      // 
      this.btnAdd.Location = new System.Drawing.Point(64, 561);
      this.btnAdd.Name = "btnAdd";
      this.btnAdd.Size = new System.Drawing.Size(150, 43);
      this.btnAdd.TabIndex = 5;
      this.btnAdd.Text = "Add";
      this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
      // 
      // label5
      // 
      this.label5.Location = new System.Drawing.Point(32, 502);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(80, 37);
      this.label5.TabIndex = 4;
      this.label5.Text = "Value";
      this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // txtVarValue
      // 
      this.txtVarValue.Location = new System.Drawing.Point(144, 502);
      this.txtVarValue.Name = "txtVarValue";
      this.txtVarValue.Size = new System.Drawing.Size(240, 31);
      this.txtVarValue.TabIndex = 3;
      // 
      // label4
      // 
      this.label4.Location = new System.Drawing.Point(32, 458);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(80, 37);
      this.label4.TabIndex = 2;
      this.label4.Text = "Name";
      this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // txtVarName
      // 
      this.txtVarName.Location = new System.Drawing.Point(144, 458);
      this.txtVarName.Name = "txtVarName";
      this.txtVarName.Size = new System.Drawing.Size(240, 31);
      this.txtVarName.TabIndex = 1;
      // 
      // lstVars
      // 
      this.lstVars.ItemHeight = 25;
      this.lstVars.Location = new System.Drawing.Point(16, 30);
      this.lstVars.Name = "lstVars";
      this.lstVars.Size = new System.Drawing.Size(400, 354);
      this.lstVars.TabIndex = 0;
      this.lstVars.SelectedIndexChanged += new System.EventHandler(this.lstVars_SelectedIndexChanged);
      this.lstVars.DoubleClick += new System.EventHandler(this.lstVars_DoubleClick);
      // 
      // chkShowVars
      // 
      this.chkShowVars.Location = new System.Drawing.Point(16, 532);
      this.chkShowVars.Name = "chkShowVars";
      this.chkShowVars.Size = new System.Drawing.Size(208, 44);
      this.chkShowVars.TabIndex = 14;
      this.chkShowVars.Text = "Show Variables";
      this.chkShowVars.CheckedChanged += new System.EventHandler(this.chkShowVars_CheckedChanged);
      // 
      // btnSaveEq
      // 
      this.btnSaveEq.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnSaveEq.Location = new System.Drawing.Point(480, 546);
      this.btnSaveEq.Name = "btnSaveEq";
      this.btnSaveEq.Size = new System.Drawing.Size(352, 45);
      this.btnSaveEq.TabIndex = 15;
      this.btnSaveEq.Text = "Save Equation";
      this.btnSaveEq.Click += new System.EventHandler(this.btnSaveEq_Click);
      // 
      // btnDeleteEq
      // 
      this.btnDeleteEq.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnDeleteEq.Location = new System.Drawing.Point(480, 591);
      this.btnDeleteEq.Name = "btnDeleteEq";
      this.btnDeleteEq.Size = new System.Drawing.Size(352, 44);
      this.btnDeleteEq.TabIndex = 16;
      this.btnDeleteEq.Text = "Delete Equation";
      this.btnDeleteEq.Click += new System.EventHandler(this.btnDeleteEq_Click);
      // 
      // frmCalculator
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(10, 24);
      this.ClientSize = new System.Drawing.Size(2041, 1185);
      this.Controls.Add(this.btnDeleteEq);
      this.Controls.Add(this.btnSaveEq);
      this.Controls.Add(this.chkShowVars);
      this.Controls.Add(this.groupBox3);
      this.Controls.Add(this.lstEquations);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.cmbConstants);
      this.Controls.Add(this.cmbFunctions);
      this.Controls.Add(this.groupBox2);
      this.Controls.Add(this.lblEquation);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.lblMethod2);
      this.Controls.Add(this.btnCalculateIt);
      this.Controls.Add(this.txtMathString);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "frmCalculator";
      this.Text = "Todd Rudberg\'s Easy String Calculator";
      this.Load += new System.EventHandler(this.frmCalculator_Load);
      this.groupBox1.ResumeLayout(false);
      this.groupBox2.ResumeLayout(false);
      this.groupBox3.ResumeLayout(false);
      this.groupBox3.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

		}
		#endregion
		#endregion

		#region METHODS
		[STAThread]
		static void Main() 
		{
			Application.Run(new frmCalculator());
		}

		private void btnCalculateIt_Click(object sender, System.EventArgs e)
		{
			#region Set Order of Operation
			csString sz = new csString( this.txtMathString.Text );
			string equation = this._StringCalc.SetOrderOfOperation2( sz );
			this.lblEquation.Text = equation + " =";
			this.myTip.SetToolTip( this.lblEquation, equation + " =" );
			//double dog = this._StringCalc.SimpleCalc(this.txtMathString.Text);
			//Console.WriteLine(dog.ToString());
			#endregion

			#region Calculate It
			csString aString = new csString( equation );
			double Number = _StringCalc.parse( aString );
			this.lblMethod2.Text = this.FormatResult( Number );

			#endregion

			this.SaveEquation();

		}

		private string FormatResult( double Number )
		{
			string ret = "";
			if( this.opnEngineering.Checked || this.opnScientific.Checked )
			{
				int OrderOfMagnitude = this.opnEngineering.Checked ? 1000 : 10;
				int Power = 0;
				bool Neg = Number < 0 ? true : false;
				Number *= Neg ? -1 : 1;
				
				if( double.IsNaN( Number ) )
				{
					ret = "NaN";
					return ret;
				}

				if( Number <= 1 )
				{
					while( (Number < 1) && (Number != 0) )
					{
						Number *= (double)OrderOfMagnitude;
						Power -= OrderOfMagnitude == 1000 ? 3 : 1;
					}
				}
				else
				{
					while( Number > OrderOfMagnitude )
					{
						Number /= (double)OrderOfMagnitude;
						Power += OrderOfMagnitude == 1000 ? 3 : 1;
					}
				}
				Number *= Neg ? -1 : 1;
				string Mantisa = Number.ToString( cmbDecimals.Text );
				string sPower = "";

				if( Power != 0 )
				{
					sPower = "*(10)^" + Power.ToString();
				}
				ret = Mantisa + sPower;
			}
			else if( this.opnMoney.Checked )
			{
				ret = Number.ToString("$0.00");
			}
			else
				ret = Number.ToString();		

			return ret;
		}
		private void SaveEquation()
		{
			try
			{
				string FileName = this.MakeFileName("eq.txt");
				System.IO.StreamWriter sw = new System.IO.StreamWriter(FileName, false);
				sw.WriteLine( this.txtMathString.Text );
				for( int ii = 0; ii < this.lstEquations.Items.Count; ii++ )
					sw.WriteLine( this.lstEquations.Items[ii] );
				sw.Close();
			}
			catch( Exception ex )
			{
				System.Windows.Forms.MessageBox.Show( ex.Message );
			}
		}
		private void SaveEquation1()
		{
			try
			{
				string FileName = this.MakeFileName("eq.txt");
				System.IO.StreamWriter sw = new System.IO.StreamWriter(FileName, false);
				sw.WriteLine( this.txtMathString.Text );

				bool blowout = false;
				string[] equations = new string[this.lstEquations.Items.Count];
				int itemscount = this.lstEquations.Items.Count < 10 ? this.lstEquations.Items.Count + 1 : 10;
				for( int ii = 0; ii < this.lstEquations.Items.Count; ii++ )
				{
					equations[ii] = this.lstEquations.Items[ii].ToString();
					if( equations[ii] == this.txtMathString.Text )
					{
						blowout = true;
						this.lstEquations.Items[0] = this.txtMathString.Text;
						for( int jj = 0; jj < ii; jj++ )
							this.lstEquations.Items[jj+1] = equations[jj];
						break;
					}
				}
				if( !blowout )
				{
					this.lstEquations.Items.Clear();
					this.lstEquations.Items.Add( this.txtMathString.Text );
					for( int ii = 1; ii < itemscount; ii++ )
						this.lstEquations.Items.Add( equations[ii-1] );
				}

				for( int ii = 0; ii < this.lstEquations.Items.Count; ii++ )
					sw.WriteLine( this.lstEquations.Items[ii].ToString() );
				sw.Close();
			}
			catch( Exception ex )
			{
				System.Windows.Forms.MessageBox.Show( ex.Message );
			}
		}
		#endregion

		#region EVENTS
		private void opnDegrees_CheckedChanged(object sender, EventArgs e)
		{
			this._StringCalc.Degrees = this.opnDegrees.Checked;
		}

		private void txtMathString_KeyUp(object sender, KeyEventArgs e)
		{
			if( e.KeyCode == System.Windows.Forms.Keys.Enter )
			{
				this.btnCalculateIt_Click( sender, e );
			}
		}
		private void frmCalculator_Load(object sender, System.EventArgs e)
		{
			int width = this.chkShowVars.Checked ? frmWidth_vars : frmWidth_std;
			this.Size = new System.Drawing.Size( width, frmHeight );
			string FileName = "";
			try
			{
				FileName = this.MakeFileName("eq.txt");
				System.IO.StreamReader sr = new System.IO.StreamReader(FileName);
				this.txtMathString.Text = sr.ReadLine();
				while( sr.Peek() != -1 )
					this.lstEquations.Items.Add( sr.ReadLine() );
				sr.Close();
				sr = null;
			}
			catch
			{
				this.txtMathString.Text = "";
				return;
			}

			try
			{
				FileName = this.MakeFileName("vars.tko");
				System.IO.BinaryReader br = new System.IO.BinaryReader(System.IO.File.Open(FileName, System.IO.FileMode.OpenOrCreate));
				while( br.PeekChar() != -1 )
				{
					string Tag = br.ReadString();
					double Value = br.ReadDouble();
					this._StringCalc._AssignVariable( Tag, Value );
				}
				br.Close();
			}
			catch( Exception ex )
			{
				System.Windows.Forms.MessageBox.Show( ex.Message );
			}
		}
		private void cmbFunctions_DoubleClick(object sender, System.EventArgs e)
		{
			this.txtMathString.Text += this.cmbFunctions.Text;
		}

		private void cmbConstants_DoubleClick(object sender, System.EventArgs e)
		{
			this.txtMathString.Text += this.cmbConstants.Text;
		}
		private void _tmrDoubleClick_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			this._DoubleClickCount= 0;
			this._tmrDoubleClick.Enabled = false;
		}

		private void cmbFunctions_MouseUp(object sender, MouseEventArgs e)
		{
			this._DoubleClickCount++;
			if( this._DoubleClickCount > 1 )
			{
				System.EventArgs easdf = new EventArgs();
				this.cmbFunctions_DoubleClick( sender, easdf );
				this._DoubleClickCount = 0;
			}
			else
				this._tmrDoubleClick.Enabled = true;
		}

		private void cmbConstants_MouseUp(object sender, MouseEventArgs e)
		{
			this._DoubleClickCount++;
			if( this._DoubleClickCount > 1 )
			{
				System.EventArgs asdf = new System.EventArgs();
				this.cmbConstants_DoubleClick( sender, asdf );
				this._DoubleClickCount = 0;
			}
			else
				this._tmrDoubleClick.Enabled = true;
		}

		private void lstEquations_DoubleClick(object sender, EventArgs e)
		{
			this.txtMathString.Text = this.lstEquations.Text;
			this.btnCalculateIt.PerformClick();
		}

		private void lstEquations_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			csString sz = new csString( this.lstEquations.Text );
			string eq = this._StringCalc.SetOrderOfOperation2( sz );
			sz.String = null;
			sz = new csString( eq );
			double number = this._StringCalc.parse( sz );
			string ret = this.FormatResult( number );
			this.myTip.SetToolTip( this.lstEquations, ret );
		}

		private void chkShowVars_CheckedChanged(object sender, System.EventArgs e)
		{
			if( chkShowVars.Checked )
			{
				this.Size = new System.Drawing.Size(frmWidth_vars,frmHeight);//856
				this.lstVars_UpdateVarList();
			}
			else
				this.Size = new System.Drawing.Size(frmWidth_std,frmHeight);//624
		}
		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			csString css = new csString( this.txtVarValue.Text );
			if( css.IsNumeric() )
				this._StringCalc._AssignVariable( this.txtVarName.Text, css.ToDouble() );
			this.lstVars_UpdateVarList();
		}
		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			if( this.lstVars.SelectedIndex != -1 )
			{
				this._StringCalc._RemoveVariable( this.lstVars.Text );
			}
			this.lstVars_UpdateVarList();
		}
		private void lstVars_UpdateVarList()
		{
			//System.Collections.SortedList taglist = new SortedList();
			System.Collections.IList vars = this._StringCalc._GetAllVariables();
			this.lstVars.Items.Clear();

			try
			{
				string FileName = this.MakeFileName("vars.tko");
				System.IO.BinaryWriter bw = new System.IO.BinaryWriter(System.IO.File.Open(FileName, System.IO.FileMode.Create));
				for (int ii = 0; ii < vars.Count; ii++)
				{
					Electroimpact.StringCalc.cStringCalc.cVariable var = (Electroimpact.StringCalc.cStringCalc.cVariable)vars[ii];
					this.lstVars.Items.Add(var.Tag);
					bw.Write(var.Tag);
					bw.Write(var.Value);
				}
				bw.Close();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.Message);
			}
		}

		private void dfd()
		{

		}

		private void lstVars_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			double Value = this._StringCalc._GetVariable( this.lstVars.Text );
			this.myTip.SetToolTip( this.lstVars, this.FormatResult( Value ) );
		}		
		private void lstVars_DoubleClick(object sender, EventArgs e)
		{
			this.txtVarName.Text = this.lstVars.Text;
			this.txtVarValue.Text = this.FormatResult( this._StringCalc._GetVariable(this.lstVars.Text) );
		}
		private void btnSaveEq_Click(object sender, System.EventArgs e)
		{
			this.SaveEquation1();
		}

		private void btnDeleteEq_Click(object sender, System.EventArgs e)
		{
			if( this.lstEquations.SelectedIndex != -1 )
			{
				this.lstEquations.Items.RemoveAt(this.lstEquations.SelectedIndex);
				this.lstEquations.Refresh();
				this.SaveEquation();
			}
		}
		#endregion

		private string MakeFileName(string fname)
		{
			string assyname = System.Reflection.Assembly.GetExecutingAssembly().FullName;
			assyname = assyname.Substring(0, assyname.IndexOf(","));
			string FileName = System.Reflection.Assembly.GetExecutingAssembly().Location;
			FileName = FileName.Replace(assyname + ".exe", fname);
			return FileName;
		}
	}
}
