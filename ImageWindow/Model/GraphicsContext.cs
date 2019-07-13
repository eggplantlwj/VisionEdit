using System;
using System.Collections;
using HalconDotNet;

namespace ViewWindow.Model
{
	public delegate void GCDelegate(string val);

	/// <summary>
	/// This class contains the graphical context of an HALCON object. The
	/// set of graphical modes is defined by the hashlist 'graphicalSettings'.
	/// If the list is empty, then there is no difference to the graphical
	/// setting defined by the system by default. Otherwise, the provided
	/// HALCON window is adjusted according to the entries of the supplied
	/// graphical context (when calling applyContext()) 
	/// </summary>
	public class GraphicsContext
	{

		/// <summary>
		/// Graphical mode for the output color (see dev_set_color)
		/// </summary>        
		public const string GC_COLOR	 = "Color";

		/// <summary>
		/// Graphical mode for the multi-color output (see dev_set_colored)
		/// </summary>
		public const string GC_COLORED	 = "Colored";

		/// <summary>
		/// Graphical mode for the line width (see set_line_width)
		/// </summary>
		public const string GC_LINEWIDTH = "LineWidth";

		/// <summary>
		/// Graphical mode for the drawing (see set_draw)
		/// </summary>
		public const string GC_DRAWMODE  = "DrawMode";

		/// <summary>
		/// Graphical mode for the drawing shape (see set_shape)
		/// </summary>
		public const string GC_SHAPE     = "Shape";

		/// <summary>
		/// Graphical mode for the LUT (lookup table) (see set_lut)
		/// </summary>
		public const string GC_LUT       = "Lut";

		/// <summary>
		/// Graphical mode for the painting (see set_paint)
		/// </summary>
		public const string GC_PAINT     = "Paint";

		/// <summary>
		/// Graphical mode for the line style (see set_line_style)
		/// </summary>
		public const string GC_LINESTYLE = "LineStyle";

		/// <summary> 
		/// Hashlist containing entries for graphical modes (defined by GC_*), 
		/// which is then linked to some HALCON object to describe its 
		/// graphical context.
		/// </summary>
		private Hashtable		graphicalSettings;

		/// <summary> 
		/// Backup of the last graphical context applied to the window.
		/// </summary>
		public	Hashtable		stateOfSettings;

		private IEnumerator iterator;

		/// <summary> 
		/// Option to delegate messages from the graphical context 
		/// to some observer class 
		/// </summary>
		public GCDelegate   gcNotification;


		/// <summary> 
		/// Creates a graphical context with no initial 
		/// graphical modes 
		/// </summary> 
		public GraphicsContext()
		{
			graphicalSettings = new Hashtable(10, 0.2f);
			gcNotification = new GCDelegate(dummy);
			stateOfSettings = new Hashtable(10, 0.2f);
		}


		/// <summary> 
		/// Creates an instance of the graphical context with 
		/// the modes defined in the hashtable 'settings' 
		/// </summary>
		/// <param name="settings"> 
		/// List of modes, which describes the graphical context 
		/// </param>
		public GraphicsContext(Hashtable settings)
		{
			graphicalSettings = settings;
			gcNotification = new GCDelegate(dummy);
			stateOfSettings = new Hashtable(10, 0.2f);
		}

		/// <summary>Applies graphical context to the HALCON window</summary>
		/// <param name="window">Active HALCON window</param>
		/// <param name="cContext">
		/// List that contains graphical modes for window
		/// </param>
		public void applyContext(HWindow window, Hashtable cContext)
		{
			string key  = "";
			string valS = "";
			int    valI = -1;
			HTuple valH = null;

			iterator = cContext.Keys.GetEnumerator();

			try
			{
				while (iterator.MoveNext())
				{

					key = (string)iterator.Current;

					if (stateOfSettings.Contains(key) &&
						stateOfSettings[key] == cContext[key])
						continue;

					switch (key)
					{
						case GC_COLOR:
							valS = (string)cContext[key];
							window.SetColor(valS);
							if (stateOfSettings.Contains(GC_COLORED))
								stateOfSettings.Remove(GC_COLORED);

							break;
						case GC_COLORED:
							valI = (int)cContext[key];
							window.SetColored(valI);

							if (stateOfSettings.Contains(GC_COLOR))
								stateOfSettings.Remove(GC_COLOR);

							break;
						case GC_DRAWMODE:
							valS = (string)cContext[key];
							window.SetDraw(valS);
							break;
						case GC_LINEWIDTH:
							valI = (int)cContext[key];
							window.SetLineWidth(valI);
							break;
						case GC_LUT:
							valS = (string)cContext[key];
							window.SetLut(valS);
							break;
						case GC_PAINT:
							valS = (string)cContext[key];
							window.SetPaint(valS);
							break;
						case GC_SHAPE:
							valS = (string)cContext[key];
							window.SetShape(valS);
							break;
						case GC_LINESTYLE:
							valH = (HTuple)cContext[key];
							window.SetLineStyle(valH);
							break;
						default:
							break;
					}


					if (valI != -1)
					{
						if (stateOfSettings.Contains(key))
							stateOfSettings[key] = valI;
						else
							stateOfSettings.Add(key, valI);

						valI = -1;
					}
					else if (valS != "")
					{
						if (stateOfSettings.Contains(key))
							stateOfSettings[key] = valI;
						else
							stateOfSettings.Add(key, valI);

						valS = "";
					}
					else if (valH != null)
					{
						if (stateOfSettings.Contains(key))
							stateOfSettings[key] = valI;
						else
							stateOfSettings.Add(key, valI);

						valH = null;
					}
				}//while
			}
			catch (HOperatorException e)
			{
				gcNotification(e.Message);
				return;
			}
		}


		/// <summary>Sets a value for the graphical mode GC_COLOR</summary>
		/// <param name="val"> 
		/// A single color, e.g. "blue", "green" ...etc. 
		/// </param>
		public void setColorAttribute(string val)
		{
			if (graphicalSettings.ContainsKey(GC_COLORED))
				graphicalSettings.Remove(GC_COLORED);

			addValue(GC_COLOR, val);
		}

		/// <summary>Sets a value for the graphical mode GC_COLORED</summary>
		/// <param name="val"> 
		/// The colored mode, which can be either "colored3" or "colored6"
		/// or "colored12" 
		/// </param>
		public void setColoredAttribute(int val)
		{
			if (graphicalSettings.ContainsKey(GC_COLOR))
				graphicalSettings.Remove(GC_COLOR);

			addValue(GC_COLORED, val);
		}

		/// <summary>Sets a value for the graphical mode GC_DRAWMODE</summary>
		/// <param name="val"> 
		/// One of the possible draw modes: "margin" or "fill" 
		/// </param>
		public void setDrawModeAttribute(string val)
		{
			addValue(GC_DRAWMODE, val);
		}

		/// <summary>Sets a value for the graphical mode GC_LINEWIDTH</summary>
		/// <param name="val"> 
		/// The line width, which can range from 1 to 50 
		/// </param>
		public void setLineWidthAttribute(int val)
		{
			addValue(GC_LINEWIDTH, val);
		}

		/// <summary>Sets a value for the graphical mode GC_LUT</summary>
		/// <param name="val"> 
		/// One of the possible modes of look up tables. For 
		/// further information on particular setups, please refer to the
		/// Reference Manual entry of the operator set_lut.
		/// </param>
		public void setLutAttribute(string val)
		{
			addValue(GC_LUT, val);
		}


		/// <summary>Sets a value for the graphical mode GC_PAINT</summary>
		/// <param name="val"> 
		/// One of the possible paint modes. For further 
		/// information on particular setups, please refer refer to the
		/// Reference Manual entry of the operator set_paint.
		/// </param>
		public void setPaintAttribute(string val)
		{
			addValue(GC_PAINT, val);
		}


		/// <summary>Sets a value for the graphical mode GC_SHAPE</summary>
		/// <param name="val">
		/// One of the possible shape modes. For further 
		/// information on particular setups, please refer refer to the
		/// Reference Manual entry of the operator set_shape.
		/// </param>
		public void setShapeAttribute(string val)
		{
			addValue(GC_SHAPE, val);
		}

		/// <summary>Sets a value for the graphical mode GC_LINESTYLE</summary>
		/// <param name="val"> 
		/// A line style mode, which works 
		/// identical to the input for the HDevelop operator 
		/// 'set_line_style'. For particular information on this 
		/// topic, please refer to the Reference Manual entry of the operator
		/// set_line_style.
		/// </param>
		public void setLineStyleAttribute(HTuple val)
		{
			addValue(GC_LINESTYLE, val);
		}

		/// <summary> 
		/// Adds a value to the hashlist 'graphicalSettings' for the 
		/// graphical mode described by the parameter 'key' 
		/// </summary>
		/// <param name="key"> 
		/// A graphical mode defined by the constant GC_* 
		/// </param>
		/// <param name="val"> 
		/// Defines the value as an int for this graphical
		/// mode 'key' 
		/// </param>
		private void addValue(string key, int val)
		{
			if (graphicalSettings.ContainsKey(key))
				graphicalSettings[key] = val;
			else
				graphicalSettings.Add(key, val);
		}

		/// <summary>
		/// Adds a value to the hashlist 'graphicalSettings' for the 
		/// graphical mode, described by the parameter 'key'
		/// </summary>
		/// <param name="key"> 
		/// A graphical mode defined by the constant GC_* 
		/// </param>
		/// <param name="val"> 
		/// Defines the value as a string for this 
		/// graphical mode 'key' 
		/// </param>
		private void addValue(string key, string val)
		{
			if (graphicalSettings.ContainsKey(key))
				graphicalSettings[key] = val;
			else
				graphicalSettings.Add(key, val);
		}


		/// <summary> 
		/// Adds a value to the hashlist 'graphicalSettings' for the 
		/// graphical mode, described by the parameter 'key'
		/// </summary>
		/// <param name="key">
		/// A graphical mode defined by the constant GC_* 
		/// </param>
		/// <param name="val"> 
		/// Defines the value as a HTuple for this 
		/// graphical mode 'key' 
		/// </param>
		private void addValue(string key, HTuple val)
		{
			if (graphicalSettings.ContainsKey(key))
				graphicalSettings[key] = val;
			else
				graphicalSettings.Add(key, val);
		}

		/// <summary> 
		/// Clears the list of graphical settings. 
		/// There will be no graphical changes made prior 
		/// before drawing objects, since there are no 
		/// graphical entries to be applied to the window.
		/// </summary>
		public void clear()
		{
			graphicalSettings.Clear();
		}


		/// <summary> 
		/// Returns an exact clone of this graphicsContext instance 
		/// </summary>
		public GraphicsContext copy()
		{
			return new GraphicsContext((Hashtable)this.graphicalSettings.Clone());
		}


		/// <summary> 
		/// If the hashtable contains the key, the corresponding 
		/// hashtable value is returned 
		/// </summary>
		/// <param name="key"> 
		/// One of the graphical keys starting with GC_* 
		/// </param>
		public object getGraphicsAttribute(string key)
		{
			if (graphicalSettings.ContainsKey(key))
				return graphicalSettings[key];

			return null;
		}

		/// <summary> 
		/// Returns a copy of the hashtable that carries the 
		/// entries for the current graphical context 
		/// </summary>
		/// <returns> current graphical context </returns>
		public Hashtable copyContextList()
		{
			return (Hashtable)graphicalSettings.Clone();
		}


		/********************************************************************/
		public void dummy(string val) { }

	}//end of class
}//end of namespace
