
#region NameSpaces

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#endregion 

/* Theme Name : Spin Theme
* Author : Narwin
* Date : 1/5/2017
* Credits : 
* AeonHacks( RoundRectangle Function ) ,
* Xerts( Some ScrollBar & ListBox Events) ,
* Mavamaarten( TabControl Slider Animation Methods )
*/

#region Helper

public sealed class HelperMethods
{

    #region MouseStates 

    public enum MouseMode
    {
        Normal,
        Hovered,
        Pushed,
        Disabled
    }

    #endregion

    #region Draw Methods 

    public void DrawImageFromBase64(Graphics G, string Base64Image, Rectangle Rect)
    {
        Image IM = null;
        using (System.IO.MemoryStream ms = new System.IO.MemoryStream(Convert.FromBase64String(Base64Image)))
        {
            IM = Image.FromStream(ms);
            ms.Close();
        }
        G.DrawImage(IM, Rect);
    }

    public void FillRoundedPath(Graphics G, Color C, Rectangle Rect, int Curve, bool TopLeft = true,bool TopRight = true, bool BottomLeft = true, bool BottomRight = true)
    {
        using(SolidBrush B = new SolidBrush(C))
        { G.FillPath(B, RoundRec(Rect, Curve, TopLeft, TopRight, BottomLeft, BottomRight));}
    }

    public void FillRoundedPath(Graphics G, Brush B, Rectangle Rect, int Curve, bool TopLeft = true,bool TopRight = true, bool BottomLeft = true, bool BottomRight = true)
    {
        G.FillPath(B, RoundRec(Rect, Curve, TopLeft, TopRight, BottomLeft, BottomRight));
    }

    public void FillWithInnerRectangle(Graphics G, Color CenterColor, Color SurroundColor, Point P, Rectangle Rect,int Curve, bool TopLeft = true, bool TopRight = true, bool BottomLeft = true, bool BottomRight = true)
    {
        using (
            PathGradientBrush PGB =
                new PathGradientBrush(RoundRec(Rect, Curve, TopLeft, TopRight, BottomLeft, BottomRight)))
        {
            
            PGB.CenterColor = CenterColor;
            PGB.SurroundColors = new Color[] { SurroundColor };
            PGB.FocusScales = P;
            GraphicsPath GP = new GraphicsPath {FillMode = FillMode.Winding};
            GP.AddRectangle(Rect);
            G.FillPath(PGB, GP);
            GP.Dispose();
        }
    }

    public void FillWithInnerEllipse(Graphics G, Color CenterColor, Color SurroundColor, Point P, Rectangle Rect)
    {
        GraphicsPath GP = new GraphicsPath {FillMode = FillMode.Winding};
        GP.AddEllipse(Rect);
        using (PathGradientBrush PGB = new PathGradientBrush(GP))
        {
            PGB.CenterColor = CenterColor;
            PGB.SurroundColors = new Color[] { SurroundColor };
            PGB.FocusScales = P;
            G.FillPath(PGB, GP);
            GP.Dispose();
        }
    }

    public void FillWithInnerRoundedPath(Graphics G, Color CenterColor, Color SurroundColor, Point P, Rectangle Rect,int Curve, bool TopLeft = true, bool TopRight = true, bool BottomLeft = true, bool BottomRight = true)
    {
        using (
            PathGradientBrush PGB =
                new PathGradientBrush(RoundRec(Rect, Curve, TopLeft, TopRight, BottomLeft, BottomRight)))
        {
            PGB.CenterColor = CenterColor;
            PGB.SurroundColors = new Color[] { SurroundColor };
            PGB.FocusScales = P;
            G.FillPath(PGB, RoundRec(Rect, Curve, TopLeft, TopRight, BottomLeft, BottomRight));
        }
    }

    public void DrawRoundedPath(Graphics G, Color C, float Size, Rectangle Rect, int Curve, bool TopLeft = true,bool TopRight = true, bool BottomLeft = true, bool BottomRight = true)
    {
        using(Pen P = new Pen(C, Size))
        { G.DrawPath(P, RoundRec(Rect, Curve, TopLeft, TopRight, BottomLeft, BottomRight));}
    }

    public void DrawTriangle(Graphics G, Color C, int Size, Point P1_0, Point P1_1, Point P2_0, Point P2_1, Point P3_0,Point P3_1)
    {
        using (Pen P = new Pen(C, Size))
        {
            G.DrawLine(P, P1_0, P1_1);
            G.DrawLine(P, P2_0, P2_1);
            G.DrawLine(P, P3_0, P3_1);
        }
    }

    public void FillStrokedRectangle(Graphics G, Rectangle Rect, Color RectColor, Color Stroke, int StrokeSize = 1)
    {
        using (SolidBrush B = new SolidBrush(RectColor))
        using (Pen S = new Pen(Stroke, StrokeSize))
        {
            G.FillRectangle(B, Rect);
            G.DrawRectangle(S, Rect);
        }

    }

    public void FillRoundedStrokedRectangle(Graphics G, Rectangle Rect, Color RectColor, Color Stroke,int StrokeSize = 1, int curve = 1, bool TopLeft = true, bool TopRight = true, bool BottomLeft = true,bool BottomRight = true)
    {
        using (SolidBrush B = new SolidBrush(RectColor))
        using (Pen S = new Pen(Stroke, StrokeSize))
        {
            FillRoundedPath(G, B, Rect, curve, TopLeft, TopRight, BottomLeft, BottomRight);
            DrawRoundedPath(G, Stroke, StrokeSize, Rect, curve, TopLeft, TopRight, BottomLeft, BottomRight);
        }
        
    }


    /// <summary>
    /// <param name="G"> The Graphic to draw the image </param>
    /// <param name="R"> The Rectangle area of image </param>
    /// <param name="_Image"> The image that the custom color applies on it</param>
    /// <param name="C">The Color that be applied to the image </param>
    /// <remarks></remarks>
    /// </summary>

    public void DrawImageWithColor(Graphics G, Rectangle R, Image _Image, Color C)
    {
        float[][] ptsArray = new float[][]
        {
            new float[] {Convert.ToSingle(C.R / 255.0), 0f, 0f, 0f, 0f},
            new float[] {0f, Convert.ToSingle(C.G / 255.0), 0f, 0f, 0f},
            new float[] {0f, 0f, Convert.ToSingle(C.B / 255.0), 0f, 0f},
            new float[] {0f, 0f, 0f, Convert.ToSingle(C.A / 255.0), 0f},
            new float[]
            {
                Convert.ToSingle( C.R/255.0),
                Convert.ToSingle( C.G/255.0),
                Convert.ToSingle( C.B/255.0), 0f,
                Convert.ToSingle( C.A/255.0)
            }
        };
        ImageAttributes imgAttribs = new ImageAttributes();
        imgAttribs.SetColorMatrix(new ColorMatrix(ptsArray), ColorMatrixFlag.Default, ColorAdjustType.Default);
        G.DrawImage(_Image, R, 0, 0, _Image.Width, _Image.Height, GraphicsUnit.Pixel, imgAttribs);
        _Image.Dispose();
    }

    #endregion

    #region Shapes 

    public Point[] Triangle(Point P1, Point P2, Point P3)
    {
        return new Point[] {P1,P2,P3};
    }

    #endregion

    #region Brushes 

    public Brush GlowBrush(Color CenterColor, Color SurroundColor, Point P, Rectangle Rect)
    {
        GraphicsPath GP = new GraphicsPath { FillMode = FillMode.Winding };
        GP.AddRectangle(Rect);
        using (PathGradientBrush PGB = new PathGradientBrush(GP) { CenterColor = CenterColor, SurroundColors = new Color[] { SurroundColor }, FocusScales = P })
        {
            return PGB;
        }
    }
    public SolidBrush SolidBrushRGBColor(int R, int G, int B, int A = 0)
    {
        return new SolidBrush(Color.FromArgb(A, R, G, B));
    }
    public SolidBrush SolidBrushHTMlColor(string C_WithoutHash)
    {
        return new SolidBrush(GetHTMLColor(C_WithoutHash));
    }

    #endregion

    #region Pens 

    public Pen PenRGBColor(int R, int G, int B, int A, float Size)
    {
        return new Pen(Color.FromArgb(A, R, G, B), Size);
    }
    public Pen PenHTMlColor(string C_WithoutHash, float Size = 1)
    {
        return new Pen(GetHTMLColor(C_WithoutHash), Size);
    }
    public Pen PenColor(Color C, float Size = 1)
    {
        return new Pen(C, Size);
    }

    #endregion

    #region Colors 

    public Color GetHTMLColor(string C_WithoutHash)
    {
        return ColorTranslator.FromHtml("#" + C_WithoutHash);
    }

    #endregion

    #region Methods 

    public void CentreString(Graphics G, string Text, Font font, Brush brush, Rectangle Rect)
    {
        G.DrawString(Text, font, brush, Rect, new StringFormat
        {
            Alignment = StringAlignment.Center,
            LineAlignment = StringAlignment.Center
        });
    }
    public void LeftString(Graphics G, string Text, Font font, Brush brush, Rectangle Rect)
    {
        G.DrawString(Text, font, brush, new Rectangle(4, Rect.Y + Convert.ToInt32(Rect.Height / 2) - Convert.ToInt32(G.MeasureString(Text, font).Height / 2) + 0, Rect.Width, Rect.Height), new StringFormat { Alignment = StringAlignment.Near });
    }
    public void RightString(Graphics G, string Text, Font font, Brush brush, Rectangle Rect)
    {
        G.DrawString(Text, font, brush, new Rectangle(4, Rect.Y + Convert.ToInt32(Rect.Height / 2) - Convert.ToInt32(G.MeasureString(Text, font).Height / 2),Convert.ToInt32(Rect.Width - Rect.Height + 10), Rect.Height), new StringFormat { Alignment = StringAlignment.Far });
    }
    public StringFormat SetPosition(StringAlignment Horizontal = StringAlignment.Center, StringAlignment Vertical = StringAlignment.Center)
    {
        return new StringFormat
        {
            Alignment = Horizontal,
            LineAlignment = Vertical
        };
    }

    public float[][] ColorToMatrix(Color C)
    {
        return new float[][] {
		new float[] {Convert.ToSingle(C.R / 255),0,0,0,0},
		new float[] {0,Convert.ToSingle(C.G / 255),0,0,0},
		new float[] {0,0,Convert.ToSingle(C.B / 255),0,0},
		new float[] {0,0,0,Convert.ToSingle(C.A / 255),0},
		new float[] {Convert.ToSingle(C.R / 255),
			Convert.ToSingle(C.G / 255),
			Convert.ToSingle(C.B / 255),
			0f,
			Convert.ToSingle(C.A / 255)
		}
	};
    }

    public Image ImageFromBase64(string Base64Image)
    {
        using (System.IO.MemoryStream ms = new System.IO.MemoryStream(Convert.FromBase64String(Base64Image)))
        {
            return Image.FromStream(ms);
        }
    }


    #endregion

    #region Round Border 

    /// <summary>
    /// Credits : AeonHack
    /// </summary>

    public GraphicsPath RoundRec(Rectangle r, int Curve, bool TopLeft = true, bool TopRight = true, bool BottomLeft = true, bool BottomRight = true)
    {
        GraphicsPath CreateRoundPath = new GraphicsPath(FillMode.Winding);
        if (TopLeft)
        {
            CreateRoundPath.AddArc(r.X, r.Y, Curve, Curve, 180f, 90f);
        }
        else
        {
            CreateRoundPath.AddLine(r.X, r.Y, r.X, r.Y);
        }
        if (TopRight)
        {
            CreateRoundPath.AddArc(r.Right - Curve, r.Y, Curve, Curve, 270f, 90f);
        }
        else
        {
            CreateRoundPath.AddLine(r.Right - r.Width, r.Y, r.Width, r.Y);
        }
        if (BottomRight)
        {
            CreateRoundPath.AddArc(r.Right - Curve, r.Bottom - Curve, Curve, Curve, 0f, 90f);
        }
        else
        {
            CreateRoundPath.AddLine(r.Right, r.Bottom, r.Right, r.Bottom);

        }
        if (BottomLeft)
        {
            CreateRoundPath.AddArc(r.X, r.Bottom - Curve, Curve, Curve, 90f, 90f);
        }
        else
        {
            CreateRoundPath.AddLine(r.X, r.Bottom, r.X, r.Bottom);
        }
        CreateRoundPath.CloseFigure();
        return CreateRoundPath;
    }

    #endregion

}
#endregion 

#region  Form

public class SpinForm : ContainerControl
{

    #region Declarations

    private static readonly HelperMethods H = new HelperMethods();
    private bool Movable = false;
    private Point MousePoint = new Point(-1, -1);
    private int _HeaderSize = 50;
    private int MoveHeight =50;
    private TitlePostion _TitleTextPostion = TitlePostion.Left;
    private Color _BaseColor = H.GetHTMLColor("FF212121");
    private Color _HeaderColor = H.GetHTMLColor("FF1A1A1A");
    private Color _HeaderTextColor = H.GetHTMLColor("efefef");
    private Color _HeaderLineColor = H.GetHTMLColor("FF151515");
    private Color _BorderColor = H.GetHTMLColor("FF151515");
    private Font _Font = new Font("Segoe UI", 11);

    #endregion

    #region Constructors

    public SpinForm()
    {
        SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
	    UpdateStyles();
        DoubleBuffered = true;
        MoveHeight = _HeaderSize;
    }

#endregion

    #region Properties

    [Category("Custom Properties"), Description("Gets or sets the form color.")]
    public Color BaseColor
    {
        get { return _BaseColor; }
        set
        {
            _BaseColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the form header color.")]
    public Color HeaderColor
    {
        get { return _HeaderColor; }
        set
        {
            _HeaderColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the form header line color.")]
    public Color HeaderLineColor
    {
        get { return _HeaderLineColor; }
        set
        {
            _HeaderLineColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the form border color.")]
    public Color BorderColor
    {
        get { return _BorderColor; }
        set
        {
            _BorderColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the form header text color.")]
    public Color HeaderTextColor
    {
        get { return _HeaderTextColor; }
        set
        {
            _HeaderTextColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the form title text postion.")]
    public virtual TitlePostion TitleTextPostion
    {
        get { return _TitleTextPostion; }
        set
        {
            _TitleTextPostion = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the size of the header.")]
    public int HeaderSize
    {
        get { return _HeaderSize; }
        set
        {
            _HeaderSize = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the font of the form.")]
    public override Font Font
    {
        get { return _Font; }
        set
        {
            _Font = value;
            Invalidate();
        }
    }

    #endregion

    #region Enumerators

    public enum TitlePostion
    {
        Left,
        Center,
        Right
    }

    #endregion

    #region Draw Control

    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics G = e.Graphics;
        G.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
        G.SmoothingMode = SmoothingMode.AntiAlias;

        Rectangle Rect = new Rectangle(0, 0, Width, Height);
     
        using (SolidBrush BG = new SolidBrush(BaseColor))
        using (SolidBrush HC = new SolidBrush(HeaderColor))
        {
            G.FillRectangle(BG, Rect);
            G.FillRectangle(HC, new Rectangle(0, 0, Width, HeaderSize));
        }

        G.DrawLine(H.PenColor(HeaderLineColor), new Point(0, HeaderSize), new Point(Width - 1, HeaderSize));
        G.DrawRectangle(H.PenColor(BorderColor), new Rectangle(0, 0, Width - 1, Height - 1));

        if (FindForm().ShowIcon)
        {
            if (FindForm().Icon != null)
            {
                switch (TitleTextPostion)
                {
                    case TitlePostion.Left:
                        using (SolidBrush HC = new SolidBrush(HeaderTextColor))
                        {
                            G.DrawString(Text, Font, HC, 27, 15);
                            G.DrawIcon(FindForm().Icon, new Rectangle(5, 16, 20, 20));
                        }
                        break;
                    case TitlePostion.Center:
                        using (SolidBrush HC = new SolidBrush(HeaderTextColor))
                        {
                            H.CentreString(G, Text, Font, HC, new Rectangle(0, 0, Width, HeaderSize));
                            G.DrawIcon(FindForm().Icon, new Rectangle(5, 16, 20, 20));
                        }
                        break;
                    case TitlePostion.Right:
                        using (SolidBrush HC = new SolidBrush(HeaderTextColor))
                        {
                            H.RightString(G, Text, Font, HC, new Rectangle(0, 0, Width, HeaderSize));
                            G.DrawIcon(FindForm().Icon, new Rectangle(Width - 30, 16, 20, 20));
                        }
                        break;
                }
            }
        }
        else
        {
            switch (TitleTextPostion)
            {
                case TitlePostion.Left:
                    using (SolidBrush HC = new SolidBrush(HeaderTextColor))
                    {
                        G.DrawString(Text, Font, HC, 5, 15);
                    }
                    break;
                case TitlePostion.Center:
                    using (SolidBrush HC = new SolidBrush(HeaderTextColor))
                    {
                        H.CentreString(G, Text, Font, HC, new Rectangle(0, 0, Width, HeaderSize));
                    }
                    break;
                case TitlePostion.Right:
                    using (SolidBrush HC = new SolidBrush(HeaderTextColor))
                    {
                        H.RightString(G, Text, Font, HC, new Rectangle(0, 0, Width, HeaderSize));
                    }
                    break;
            }
        }

    }

    #endregion

    #region Events

    protected override void OnMouseDown(MouseEventArgs e)
    {
        base.OnMouseDown(e);
        if (e.Button == System.Windows.Forms.MouseButtons.Left & new Rectangle(0, 0, Width, MoveHeight).Contains(e.Location))
        {
            Movable = true;
            MousePoint = e.Location;
        }
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
        base.OnMouseUp(e);
        Movable = false;
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
        base.OnMouseMove(e);
        int x = MousePosition.X;
        int y = MousePosition.Y;
        int x1 = MousePoint.X;
        int y1 = MousePoint.Y;

        if (Movable)
            Parent.Location = new Point(x - x1, y - y1);
        Focus();
    }

    protected override void OnCreateControl()
    {
        base.OnCreateControl();
        ParentForm.FormBorderStyle = FormBorderStyle.None;
        ParentForm.Dock = DockStyle.None;
        Dock = DockStyle.Fill;
        Invalidate();
    }


    #endregion

}

#endregion

#region TabControl

#region Horizontal TabControl

public class SpinHorizontalTabControl : TabControl
{

    #region Declarations

    private static readonly HelperMethods H = new HelperMethods();
    private Color _TabColor = H.GetHTMLColor("F5242424");
    private Color _TabPageColor = H.GetHTMLColor("FF212121");
    private Color _BorderColor = H.GetHTMLColor("202020");
    private Color _TabSelectedTextColor = Color.White;
    private Color _TabUnSlectedTextColor = H.GetHTMLColor("5c5c5c");
    private int _RoundRadius = 20;
    private bool _UseAnimation = true;

    #endregion

    #region Constructors

    public SpinHorizontalTabControl()
    {
        SetStyle(ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.SupportsTransparentBackColor, true);
        DoubleBuffered = true;
        SizeMode = TabSizeMode.Fixed;
        Dock = DockStyle.None;
        ItemSize = new Size(80, 40);
        Font = new Font("Segoe UI", 8);
        Alignment = TabAlignment.Top;
        UpdateStyles();
    }

    #endregion

    #region Draw Control

    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics G = e.Graphics;
        G.PixelOffsetMode = PixelOffsetMode.HighQuality;
        G.SmoothingMode = SmoothingMode.AntiAlias;
        G.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

        G.Clear(TabPageColor);

        Cursor = Cursors.Hand;

        int Rects = 0;

        for (int i = 0; i <= TabCount - 1; i++)
        {
            Rectangle R = GetTabRect(i);

            if (i == TabCount - 1)
            {
                using (SolidBrush B = new SolidBrush(TabColor))
                {
                    H.FillRoundedPath(G, B, R, RoundRadius, false, true, false);
                }
            }
            else if (i == 0)
            {
                using (SolidBrush B = new SolidBrush(TabColor))
                {
                    H.FillRoundedPath(G, B, new Rectangle(R.X, R.Y, R.Width + 3, R.Height), RoundRadius, true, false, true, false);
                }
            }
            else
            {
                using (SolidBrush B = new SolidBrush(TabColor))
                {
                    G.FillRectangle(B, R);
                }
            }
        }

        for (int i = 0; i <= TabCount - 1; i++)
        {
            Rectangle R = GetTabRect(i);
            Rects += R.Width;
            if (SelectedIndex == i)
            {
                using (SolidBrush B = new SolidBrush(TabSelectedTextColor))
                {
                    G.DrawString(TabPages[i].Text, Font,B , R, H.SetPosition());
                }
            }
            else
            {
                using (SolidBrush B = new SolidBrush(TabUnSlectedTextColor))
                {
                    G.DrawString(TabPages[i].Text, Font, B, R, H.SetPosition());
                }
            }
        }
        try
        {
            H.DrawRoundedPath(G, BorderColor, 1, new Rectangle(GetTabRect(0).X, GetTabRect(0).Y + 1, Rects, GetTabRect(TabCount - 1).Height), RoundRadius);
        }
        catch
        {
        }
    }

    #endregion

    #region Events

    protected override void OnMouseMove(MouseEventArgs e)
    {
        base.OnMouseMove(e);
        for (int i = 0; i <= TabCount - 1; i++)
        {
            Rectangle R = GetTabRect(i);
            if (R.Contains(e.Location))
            {
                Cursor = Cursors.Hand;
                Invalidate();
            }
            else
            {
                Cursor = Cursors.Arrow;
                Invalidate();
            }
        }
    }

    protected override void OnCreateControl()
    {
        base.OnCreateControl();
        foreach (TabPage Tab in base.TabPages)
        {
            Tab.BackColor = TabPageColor;
        }
    }

    #region Animation


    // Credits : Mavamaarten


    int OldIndex;
    private int _Speed = 40;
    public int Speed
    {
        get { return _Speed; }
        set
        {
            if (value > 40 | value < -40)
            {
                throw new Exception("Speed needs to be in between -40 and 40.");
            }
            else
            {
                _Speed = value;
            }
        }
    }
    public void DoAnimationScrollLeft(Control Control1, Control Control2)
    {
        Graphics G = Control1.CreateGraphics();
        Bitmap P1 = new Bitmap(Control1.Width, Control1.Height);
        Bitmap P2 = new Bitmap(Control2.Width, Control2.Height);
        Control1.DrawToBitmap(P1, new Rectangle(0, 0, Control1.Width, Control1.Height));
        Control2.DrawToBitmap(P2, new Rectangle(0, 0, Control2.Width, Control2.Height));

        foreach (Control c in Control1.Controls)
        {
            c.Hide();
        }

        int Slide = Control1.Width - (Control1.Width % _Speed);

        int a = 0;
        for (a = 0; a <= Slide; a += _Speed)
        {
            G.DrawImage(P1, new Rectangle(a, 0, Control1.Width, Control1.Height));
            G.DrawImage(P2, new Rectangle(a - Control2.Width, 0, Control2.Width, Control2.Height));
        }
        a = Control1.Width;
        G.DrawImage(P1, new Rectangle(a, 0, Control1.Width, Control1.Height));
        G.DrawImage(P2, new Rectangle(a - Control2.Width, 0, Control2.Width, Control2.Height));

        SelectedTab = (TabPage)Control2;

        foreach (Control c in Control2.Controls)
        {
            c.Show();
        }

        foreach (Control c in Control1.Controls)
        {
            c.Show();
        }
    }

    protected override void OnSelecting(System.Windows.Forms.TabControlCancelEventArgs e)
    {
        if (UseAnimation)
        {
            if (OldIndex < e.TabPageIndex)
            {
                DoAnimationScrollRight(TabPages[OldIndex], TabPages[e.TabPageIndex]);
            }
            else
            {
                DoAnimationScrollLeft(TabPages[OldIndex], TabPages[e.TabPageIndex]);
            }
        }
    }

    protected override void OnDeselecting(System.Windows.Forms.TabControlCancelEventArgs e)
    {
        OldIndex = e.TabPageIndex;
    }

    public void DoAnimationScrollRight(Control Control1, Control Control2)
    {
        Graphics G = Control1.CreateGraphics();
        Bitmap P1 = new Bitmap(Control1.Width, Control1.Height);
        Bitmap P2 = new Bitmap(Control2.Width, Control2.Height);
        Control1.DrawToBitmap(P1, new Rectangle(0, 0, Control1.Width, Control1.Height));
        Control2.DrawToBitmap(P2, new Rectangle(0, 0, Control2.Width, Control2.Height));

        foreach (Control c in Control1.Controls)
        {
            c.Hide();
        }

        int Slide = Control1.Width - (Control1.Width % _Speed);

        int a = 0;
        for (a = 0; a >= -Slide; a += -_Speed)
        {
            G.DrawImage(P1, new Rectangle(a, 0, Control1.Width, Control1.Height));
            G.DrawImage(P2, new Rectangle(a + Control2.Width, 0, Control2.Width, Control2.Height));
        }
        a = Control1.Width;
        G.DrawImage(P1, new Rectangle(a, 0, Control1.Width, Control1.Height));
        G.DrawImage(P2, new Rectangle(a + Control2.Width, 0, Control2.Width, Control2.Height));

        SelectedTab = (TabPage)Control2;

        foreach (Control c in Control2.Controls)
        {
            c.Show();
        }

        foreach (Control c in Control1.Controls)
        {
            c.Show();
        }
    }

    #endregion

    #endregion

    #region Properties

    [Category("Custom Properties"), Description("Gets or sets the tabpages color of the tabcontrol")]
    public Color TabPageColor
    {
        get { return _TabPageColor; }
        set
        {
            _TabPageColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the tabcontrol header color")]
    public Color TabColor
    {
        get { return _TabColor; }
        set
        {
            _TabColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the tabcontrol header Rounded Corners")]
    public int RoundRadius
    {
        get { return _RoundRadius; }
        set
        {
            _RoundRadius = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the tabpage Text color while selected")]
    public Color TabSelectedTextColor
    {
        get { return _TabSelectedTextColor; }
        set
        {
            _TabSelectedTextColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the tabpage Text color while un-selected")]
    public Color TabUnSlectedTextColor
    {
        get { return _TabUnSlectedTextColor; }
        set
        {
            _TabUnSlectedTextColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the tabcontrol border color")]
    public Color BorderColor
    {
        get { return _BorderColor; }
        set
        {
            _BorderColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets whether the tabcontrol use animation to sliding or not.")]
    public bool UseAnimation
    {
        get { return _UseAnimation; }
        set
        {
            _UseAnimation = value;
            Invalidate();
        }
    }

    #endregion

}

#endregion

#region Vertical TabControl

public class SpinVerticalTabControl : TabControl
{

    #region Declarations

    private static readonly HelperMethods H = new HelperMethods();
    private Color _TabColor = H.GetHTMLColor("F5242424");
    private Color _TabPageColor = H.GetHTMLColor("FF212121");
    private Color _TabSelectedTextColor = Color.White;
    private Color _TabUnSelectedTextColor = H.GetHTMLColor("5c5c5c");
    private Color _TabTextHeaderColor = H.GetHTMLColor("5c5c5c");
    private Color _TabLinesColor = H.GetHTMLColor("FF202020");
    private Color _SelectedTabSmallRectColor = H.GetHTMLColor("FF2B90D2");
    private TextRenderingHint _TextQuality = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
    private SmoothingMode _RenderingQuality = SmoothingMode.Default;
    private InterpolationMode _ImageRenderingQuality = InterpolationMode.Default;
    private bool _UseAnimation = true;
    private Point _ImageLocation = new Point(28, 12);
    private Point _TextLocation = new Point(60, 0);
    private Point _HeaderTextLocation = new Point(30, 2);
    private Color _ImageColor = H.GetHTMLColor("5c5c5c");

    #endregion

    #region Constructors

    public SpinVerticalTabControl()
    {
        SetStyle(ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.SupportsTransparentBackColor, true);
        DoubleBuffered = true;
        SizeMode = TabSizeMode.Fixed;
        Dock = DockStyle.None;
        ItemSize = new Size(35, 150);
        Alignment = TabAlignment.Left;
        Font = new Font("Segoe UI", 8);
        UpdateStyles();
        SelectedIndex = 1;
    }

    #endregion

    #region Properties

    [Category("Custom Properties"), Description("Gets or sets the tabcontrol left side color")]
    public Color TabColor
    {
        get { return _TabColor; }
        set
        {
            _TabColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the tabpages color of the tabcontrol")]
    public Color TabPageColor
    {
        get { return _TabPageColor; }
        set
        {
            _TabPageColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the tabpage Text color while selected")]
    public Color TabSelectedTextColor
    {
        get { return _TabSelectedTextColor; }
        set
        {
            _TabSelectedTextColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the tabpage header Text color while Taged.")]
    public Color TabTextHeaderColor
    {
        get { return _TabTextHeaderColor; }
        set
        {
            _TabTextHeaderColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the tabpage Text color while un-selected")]
    public Color TabUnSelectedTextColor
    {
        get { return _TabUnSelectedTextColor; }
        set
        {
            _TabUnSelectedTextColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the tabcontrol selected lines color while selected")]
    public Color TabLinesColor
    {
        get { return _TabLinesColor; }
        set
        {
            _TabLinesColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the tabcontrol small rectangle color while selected")]
    public Color SelectedTabSmallRectColor
    {
        get { return _SelectedTabSmallRectColor; }
        set
        {
            _SelectedTabSmallRectColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the tabcontrol text rendering quality.")]
    public TextRenderingHint TextQuality
    {
        get { return _TextQuality; }
        set
        {
            _TextQuality = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the tabcontrol rendering quality.")]
    public SmoothingMode RenderingQuality
    {
        get { return _RenderingQuality; }
        set
        {
            _RenderingQuality = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the tabcontrol image rendering quality.")]
    public InterpolationMode ImageRenderingQuality
    {
        get { return _ImageRenderingQuality; }
        set
        {
            _ImageRenderingQuality = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets whether the tabcontrol use animation to sliding or not.")]
    public bool UseAnimation
    {
        get { return _UseAnimation; }
        set
        {
            _UseAnimation = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the tab pages image location.")]
    public Point ImageLocation
    {
        get { return _ImageLocation; }
        set
        {
            _ImageLocation = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the tab pages text location.")]
    public Point TextLocation
    {
        get { return _TextLocation; }
        set
        {
            _TextLocation = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the tab pages header text location.")]
    public Point HeaderTextLocation
    {
        get { return _HeaderTextLocation; }
        set
        {
            _HeaderTextLocation = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the tabpages image color.")]
    public Color ImageColor
    {
        get { return _ImageColor; }
        set
        {
            _ImageColor = value;
            Invalidate();
        }
    }

    #endregion

    #region Draw Control
    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics G = e.Graphics;

        G.TextRenderingHint = TextQuality;
        G.SmoothingMode = RenderingQuality;
        G.InterpolationMode = ImageRenderingQuality;
        int Rects = 0;

        using (SolidBrush TC = new SolidBrush(TabColor))
        using (SolidBrush TPC = new SolidBrush(TabPageColor))
        {
            G.FillRectangle(TC, new Rectangle(0, 0, ItemSize.Height, Height));
            G.FillRectangle(TPC, new Rectangle(ItemSize.Height, 0, Width, Height));
        }
     
        for (int i = 0; i <= TabCount - 1; i++)
        {
            Rects += GetTabRect(i).Height;
            Rectangle R = GetTabRect(i);
            Cursor = Cursors.Hand;


            if (TabPages[i].Tag != null)
            {
                using (SolidBrush TTHC = new SolidBrush(TabTextHeaderColor))
                using (StringFormat SF = new StringFormat { LineAlignment = StringAlignment.Center })
                {
                    G.DrawString(TabPages[i].Text.ToUpper(), Font, TTHC,
                        new Rectangle(R.X + 15, R.Y, R.Width, R.Height),
                        SF);
                }
                G.DrawLine(H.PenColor(TabLinesColor), new Point(ItemSize.Height - 1, 0), new Point(ItemSize.Height - 1, Height));
            }
            else if (SelectedIndex == i && TabPages[i].Tag == null)
            {
                using (SolidBrush TPC = new SolidBrush(TabPageColor))
                using (SolidBrush STSRC = new SolidBrush(SelectedTabSmallRectColor))
                using (SolidBrush TSTC = new SolidBrush(TabSelectedTextColor))
                using (StringFormat SF = new StringFormat { LineAlignment = StringAlignment.Center })
                {
                    G.FillRectangle(TPC, new Rectangle(R.X, R.Y + 1, R.Width, R.Height - 1));
                    G.FillRectangle(STSRC, new Rectangle(R.X, R.Y + 2, 3, R.Height - 3));

                    G.DrawLine(H.PenColor(TabLinesColor), new Point(R.X + 3, R.Y + 1), new Point(ItemSize.Height - 1, R.Y + 1));

                    G.DrawLine(H.PenColor(TabLinesColor), new Point(R.X + 3, R.Bottom - 1), new Point(ItemSize.Height - 1, R.Bottom - 1));

                    G.DrawLine(H.PenColor(TabLinesColor), new Point(ItemSize.Height - 1, 0), new Point(ItemSize.Height - 1, R.Y));

                    G.DrawLine(H.PenColor(TabLinesColor), new Point(ItemSize.Height - 1, R.Bottom - 1), new Point(ItemSize.Height - 1, Bottom - 1));

                    G.DrawString(TabPages[i].Text.ToUpper(), Font, TSTC, new Rectangle(R.X + TextLocation.X, R.Y + TextLocation.Y, R.Width - 2, R.Height), SF);

                }
                if ((ImageList != null) && ImageList.Images[i] != null && TabPages[i].Tag == null)
                {
                    H.DrawImageWithColor(G, new Rectangle(new Point(R.X + ImageLocation.X, R.Y + ImageLocation.Y), ImageList.ImageSize), ImageList.Images[i], TabSelectedTextColor);
                }
            }

            else
            {
                using (SolidBrush TUSTC = new SolidBrush(TabUnSelectedTextColor))
                using (StringFormat SF = new StringFormat { LineAlignment = StringAlignment.Center })
                {
                    G.DrawString(TabPages[i].Text.ToUpper(), Font, TUSTC, new Rectangle(R.X + TextLocation.X, R.Y + TextLocation.Y, R.Width - 2, R.Height), SF);
                }
                if ((ImageList != null) && ImageList.Images[i] != null && TabPages[i].Tag == null)
                {
                    H.DrawImageWithColor(G, new Rectangle(new Point(R.X + ImageLocation.X, R.Y + ImageLocation.Y), ImageList.ImageSize), ImageList.Images[i], ImageColor);
                }
            }

        }

        if (ShowStatusComponents)
        {
            using (SolidBrush BG = new SolidBrush(PG1BaseColor))
            using (SolidBrush BG2 = new SolidBrush(PG2BaseColor))
            using (Pen P = new Pen(PG1BaseColor))
            using (SolidBrush TUSTC = new SolidBrush(TabUnSelectedTextColor))
            {

            G.DrawLine(P, new Point(10, Rects + 8), new Point(ItemSize.Height - 21, Rects + 8));
            G.DrawString(Text1.ToUpper(), Font, TUSTC, 10, Rects + 18);
            G.DrawString(Text2.ToUpper(), Font, TUSTC, 10, Rects + 48);
            G.DrawString(Text3.ToUpper(), Font, TUSTC, 10, Rects + 88);

            int W = ItemSize.Height - 21;
            int H = 5;
            int PG1CurrentValue = Convert.ToInt32(PG1Value / PG1Maximum * W);
            int PG2CurrentValue = Convert.ToInt32(PG2Value / PG2Maximum * W);
            Rectangle Rect = new Rectangle(10, Rects + 68, W, H);
            Rectangle Rect2 = new Rectangle(10, Rects + 108, W, H);
                
                G.FillRectangle(BG, Rect);
                G.FillRectangle(BG2, Rect2);
         
            if (PG1CurrentValue != 0)
            {
                using (SolidBrush PS = new SolidBrush(PG1ProgressColor))
                {
                    G.FillRectangle(PS, new Rectangle(Rect.X, Rect.Y, PG1CurrentValue - 1, Rect.Height));
                }
            }

            if (PG2CurrentValue != 0)
            {
                using (SolidBrush PS = new SolidBrush(PG2ProgressColor))
                {
                    G.FillRectangle(PS, new Rectangle(Rect2.X, Rect2.Y, PG2CurrentValue - 1, Rect2.Height));
                }
            }
            }
        }
    }

    #endregion

    #region Events

    protected override void OnCreateControl()
    {
        base.OnCreateControl();
        foreach (TabPage Tab in base.TabPages)
        {
            Tab.BackColor = TabPageColor;
        }
    }

    #region Animation 

    // Credits : Mavamaarten


    int OldIndex;
    private int _Speed = 40;
    public int Speed
    {
        get { return _Speed; }
        set
        {
            if (value > 40 | value < -40)
            {
                throw new Exception("Speed needs to be in between -40 and 40.");
            }
            else
            {
                _Speed = value;
            }
        }
    }
    public void DoAnimationScrollLeft(Control Control1, Control Control2)
    {
        Graphics G = Control1.CreateGraphics();
        Bitmap P1 = new Bitmap(Control1.Width, Control1.Height);
        Bitmap P2 = new Bitmap(Control2.Width, Control2.Height);
        Control1.DrawToBitmap(P1, new Rectangle(0, 0, Control1.Width, Control1.Height));
        Control2.DrawToBitmap(P2, new Rectangle(0, 0, Control2.Width, Control2.Height));

        foreach (Control c in Control1.Controls)
        {
            c.Hide();
        }

        int Slide = Control1.Width - (Control1.Width % _Speed);

        int a = 0;
        for (a = 0; a <= Slide; a += _Speed)
        {
            G.DrawImage(P1, new Rectangle(a, 0, Control1.Width, Control1.Height));
            G.DrawImage(P2, new Rectangle(a - Control2.Width, 0, Control2.Width, Control2.Height));
        }
        a = Control1.Width;
        G.DrawImage(P1, new Rectangle(a, 0, Control1.Width, Control1.Height));
        G.DrawImage(P2, new Rectangle(a - Control2.Width, 0, Control2.Width, Control2.Height));

        SelectedTab = (TabPage)Control2;

        foreach (Control c in Control2.Controls)
        {
            c.Show();
        }

        foreach (Control c in Control1.Controls)
        {
            c.Show();
        }
    }

    protected override void OnSelecting(System.Windows.Forms.TabControlCancelEventArgs e)
    {
        if (UseAnimation)
        {
            if (OldIndex < e.TabPageIndex)
            {
                DoAnimationScrollRight(TabPages[OldIndex], TabPages[e.TabPageIndex]);
            }
            else
            {
                DoAnimationScrollLeft(TabPages[OldIndex], TabPages[e.TabPageIndex]);
            }
        }
    }

    protected override void OnDeselecting(System.Windows.Forms.TabControlCancelEventArgs e)
    {
        OldIndex = e.TabPageIndex;
    }

    public void DoAnimationScrollRight(Control Control1, Control Control2)
    {
        Graphics G = Control1.CreateGraphics();
        Bitmap P1 = new Bitmap(Control1.Width, Control1.Height);
        Bitmap P2 = new Bitmap(Control2.Width, Control2.Height);
        Control1.DrawToBitmap(P1, new Rectangle(0, 0, Control1.Width, Control1.Height));
        Control2.DrawToBitmap(P2, new Rectangle(0, 0, Control2.Width, Control2.Height));

        foreach (Control c in Control1.Controls)
        {
            c.Hide();
        }

        int Slide = Control1.Width - (Control1.Width % _Speed);

        int a = 0;
        for (a = 0; a >= -Slide; a += -_Speed)
        {
            G.DrawImage(P1, new Rectangle(a, 0, Control1.Width, Control1.Height));
            G.DrawImage(P2, new Rectangle(a + Control2.Width, 0, Control2.Width, Control2.Height));
        }
        a = Control1.Width;
        G.DrawImage(P1, new Rectangle(a, 0, Control1.Width, Control1.Height));
        G.DrawImage(P2, new Rectangle(a + Control2.Width, 0, Control2.Width, Control2.Height));

        SelectedTab = (TabPage)Control2;

        foreach (Control c in Control2.Controls)
        {
            c.Show();
        }

        foreach (Control c in Control1.Controls)
        {
            c.Show();
        }
    }

    #endregion

    #endregion

    #region Progress

    private bool _ShowStatusComponents = true;
    public bool ShowStatusComponents
    {
        get { return _ShowStatusComponents; }
        set
        {
            _ShowStatusComponents = value;
            Invalidate();
        }
    }
    
    #region Labels 

    private string _Text1 = "SERVER STATUS";
    public string Text1
    {
        get { return _Text1; }
        set
        {
            _Text1 = value;
            Invalidate();
        }
    }

    private string _Text2 = "CPU Used";
    public string Text2
    {
        get { return _Text2; }
        set
        {
            _Text2 = value;
            Invalidate();
        }
    }

    private string _Text3 = "SERVER STATUS";
    public string Text3
    {
        get { return _Text3; }
        set
        {
            _Text3 = value;
            Invalidate();
        }
    }

    #endregion

    #region 1st ProgressBar 

    #region Declarations

    private int _PG1Maximum = 100;
    private int _PG1Value = 0;
    private bool _PG1ShowProgressLines = true;
    private Color _PG1ProgressColor = H.GetHTMLColor("FF2C97DE");
    private Color _PG1ProgressLinesColor = H.GetHTMLColor("FF2B90D2");

    private Color _PG1BaseColor = H.GetHTMLColor("FF353535");
    #endregion

    #region Properties

    [Category("1st ProgressBar"), Description("Gets or sets the current position of the progressbar.")]
    public int PG1Value
    {
        get
        {
            if (_PG1Value < 0)
            {
                return 0;
            }
            else
            {
                return _PG1Value;
            }
        }
        set
        {
            if (value > PG1Maximum)
            {
                value = PG1Maximum;
            }
            _PG1Value = value;
            Invalidate();
        }
    }

    [Category("1st ProgressBar"), Description("Gets or sets the maximum value of the progressbar.")]
    public int PG1Maximum
    {
        get { return _PG1Maximum; }
        set
        {
                if(value < _PG1Value)
                    _PG1Value = value;
            _PG1Maximum = value;
            Invalidate();
        }
    }

    [Category("1st ProgressBar"), Description("Gets or sets the whether the progressbar line be shown or not.")]
    public bool PG1ShowProgressLines
    {
        get { return _PG1ShowProgressLines; }
        set
        {
            _PG1ShowProgressLines = value;
            Invalidate();
        }
    }

    [Category("1st ProgressBar"), Description("Gets or sets the basecolor of the control.")]
    public Color PG1BaseColor
    {
        get { return _PG1BaseColor; }
        set
        {
            _PG1BaseColor = value;
            Invalidate();
        }
    }

    [Category("1st ProgressBar"), Description("Gets or sets the progress color of the control.")]
    public Color PG1ProgressColor
    {
        get { return _PG1ProgressColor; }
        set
        {
            _PG1ProgressColor = value;
            Invalidate();
        }
    }

    [Category("1st ProgressBar"), Description("Gets or sets the progress lines color of the control.")]
    public Color PG1ProgressLinesColor
    {
        get { return _PG1ProgressLinesColor; }
        set
        {
            _PG1ProgressLinesColor = value;
            Invalidate();
        }
    }

    #endregion

    #endregion

    #region 2nd ProgressBar 

    #region Declarations

    private int _PG2Maximum = 100;
    private int _PG2Value = 0;
    private bool _PG2ShowProgressLines = true;
    private Color _PG2ProgressColor = H.GetHTMLColor("FF2C97DE");
    private Color _PG2ProgressLinesColor = H.GetHTMLColor("FF2B90D2");

    private Color _PG2BaseColor = H.GetHTMLColor("FF353535");
    #endregion

    #region Properties

    [Category("2nd ProgressBar"), Description("Gets or sets the current position of the progressbar.")]
    public int PG2Value
    {
        get
        {
            if (_PG2Value < 0)
            {
                return 0;
            }
            else
            {
                return _PG2Value;
            }
        }
        set
        {
            if (value > PG2Maximum)
            {
                value = PG2Maximum;
            }
            _PG2Value = value;
            Invalidate();
        }
    }

    [Category("2nd ProgressBar"), Description("Gets or sets the maximum value of the progressbar.")]
    public int PG2Maximum
    {
        get { return _PG2Maximum; }
        set
        {
            if (value > PG2Maximum)
            {
                value = PG2Maximum;
            }
            _PG2Value = value;
            Invalidate();
        }
    }

    [Category("2nd ProgressBar"), Description("Gets or sets the whether the progressbar line be shown or not.")]
    public bool PG2ShowProgressLines
    {
        get { return _PG2ShowProgressLines; }
        set
        {
            _PG2ShowProgressLines = value;
            Invalidate();
        }
    }

    [Category("2nd ProgressBar"), Description("Gets or sets the basecolor of the control.")]
    public Color PG2BaseColor
    {
        get { return _PG2BaseColor; }
        set
        {
            _PG2BaseColor = value;
            Invalidate();
        }
    }

    [Category("2nd ProgressBar"), Description("Gets or sets the progress color of the control.")]
    public Color PG2ProgressColor
    {
        get { return _PG2ProgressColor; }
        set
        {
            _PG2ProgressColor = value;
            Invalidate();
        }
    }

    [Category("2nd ProgressBar"), Description("Gets or sets the progress lines color of the control.")]
    public Color PG2ProgressLinesColor
    {
        get { return _PG2ProgressLinesColor; }
        set
        {
            _PG2ProgressLinesColor = value;
            Invalidate();
        }
    }

    #endregion

    #endregion

    #endregion

}

#endregion

#region Vertical Mine TabControl 

public class SpinMiniTabControl : TabControl
{

    #region Declarations

    private static readonly HelperMethods H = new HelperMethods();
    private Color _TabColor = H.GetHTMLColor("F5242424");
    private Color _TabPageColor = H.GetHTMLColor("FF212121");
    private Color _TabSelectedTextColor = Color.White;
    private Color _TabUnSlectedTextColor = H.GetHTMLColor("5c5c5c");
    private Color _TabTextHeaderColor = H.GetHTMLColor("5c5c5c");
    private Color _TabLinesColor = H.GetHTMLColor("FF202020");
    private Color _SelectedTabSmallRectColor = H.GetHTMLColor("FF2B90D2");
    private TextRenderingHint _TextQuality = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
    private SmoothingMode _RenderingQuality = SmoothingMode.Default;
    private InterpolationMode _ImageRenderingQuality = InterpolationMode.Default;

    private bool _UseAnimation = true;
    #endregion

    #region Constructors

    public SpinMiniTabControl()
    {
        SetStyle(ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.SupportsTransparentBackColor, true);
        DoubleBuffered = true;
        SizeMode = TabSizeMode.Fixed;
        Dock = DockStyle.None;
        Size = new Size(450, 250);
        base.ItemSize = new Size(50, 55);
        Alignment = TabAlignment.Left;
        Font = new Font("Segoe UI", 8);
        UpdateStyles();
        SelectedIndex = 1;
    }

    #endregion

    #region Properties

    [Category("Custom Properties"), Description("Gets or sets the tabcontrol left side color")]
    public Color TabColor
    {
        get { return _TabColor; }
        set
        {
            _TabColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the tabpages color of the tabcontrol")]
    public Color TabPageColor
    {
        get { return _TabPageColor; }
        set
        {
            _TabPageColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the tabpage Text color while selected")]
    public Color TabSelectedTextColor
    {
        get { return _TabSelectedTextColor; }
        set
        {
            _TabSelectedTextColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the tabpage header Text color while Taged.")]
    public Color TabTextHeaderColor
    {
        get { return _TabTextHeaderColor; }
        set
        {
            _TabTextHeaderColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the tabpage Text color while un-selected")]
    public Color TabUnSlectedTextColor
    {
        get { return _TabUnSlectedTextColor; }
        set
        {
            _TabUnSlectedTextColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the tabcontrol selected lines color while selected")]
    public Color TabLinesColor
    {
        get { return _TabLinesColor; }
        set
        {
            _TabLinesColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the tabcontrol small rectangle color while selected")]
    public Color SelectedTabSmallRectColor
    {
        get { return _SelectedTabSmallRectColor; }
        set
        {
            _SelectedTabSmallRectColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the tabcontrol text rendering quality.")]
    public TextRenderingHint TextQuality
    {
        get { return _TextQuality; }
        set
        {
            _TextQuality = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the tabcontrol rendering quality.")]
    public SmoothingMode RenderingQuality
    {
        get { return _RenderingQuality; }
        set
        {
            _RenderingQuality = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the tabcontrol image rendering quality.")]
    public InterpolationMode ImageRenderingQuality
    {
        get { return _ImageRenderingQuality; }
        set
        {
            _ImageRenderingQuality = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets whether the tabcontrol use animation to sliding or not.")]
    public bool UseAnimation
    {
        get { return _UseAnimation; }
        set
        {
            _UseAnimation = value;
            Invalidate();
        }
    }

    [Browsable(false)]
    public new Size ItemSize
    {
        get { return new Size(50, 55); }
        set { base.ItemSize = new Size(50, 55); }
    }


    #endregion

    #region Draw Control


    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics G = e.Graphics;

        G.TextRenderingHint = TextQuality;
        G.SmoothingMode = RenderingQuality;
        G.InterpolationMode = ImageRenderingQuality;

        using (SolidBrush TC = new SolidBrush(TabColor))
        using (SolidBrush TPC = new SolidBrush(TabPageColor))
        {
            G.FillRectangle(TC, new Rectangle(0, 0, ItemSize.Height, Height));
            G.FillRectangle(TPC, new Rectangle(ItemSize.Height, 0, Width, Height));
        }

        for (int i = 0; i <= TabCount - 1; i++)
        {
            Rectangle R = GetTabRect(i);
            Cursor = Cursors.Hand;

            if (SelectedIndex == i)
            {
                using (SolidBrush B = new SolidBrush(TabPageColor))
                using (SolidBrush SB = new SolidBrush(SelectedTabSmallRectColor))
                {
                    G.FillRectangle(B, new Rectangle(R.X, R.Y + 1, R.Width, R.Height - 1));
                    G.FillRectangle(SB, new Rectangle(R.X, R.Y + 2, 3, R.Height - 3));
                }

                G.DrawLine(H.PenColor(TabLinesColor), new Point(R.X + 3, R.Y + 1), new Point(ItemSize.Height - 1, R.Y + 1));

                G.DrawLine(H.PenColor(TabLinesColor), new Point(R.X + 3, R.Bottom - 1), new Point(ItemSize.Height - 1, R.Bottom - 1));

                G.DrawLine(H.PenColor(TabLinesColor), new Point(ItemSize.Height - 1, 0), new Point(ItemSize.Height - 1, R.Y));

                G.DrawLine(H.PenColor(TabLinesColor), new Point(ItemSize.Height - 1, R.Bottom - 1), new Point(ItemSize.Height - 1, Bottom - 1));
            }

            if ((ImageList != null) && (ImageList.Images[i] !=null))
            {
                G.DrawImage(ImageList.Images[i], new Rectangle(R.X + 18, R.Y + 17, 16, 16));
            }

        }
    }

    #endregion

    #region Events

    protected override void OnCreateControl()
    {
        base.OnCreateControl();
        foreach (TabPage Tab in base.TabPages)
        {
            Tab.BackColor = TabPageColor;
        }
    }

    #region Animation

    // Credits : Mavamaarten


    int OldIndex;
    private int _Speed = 40;
    public int Speed
    {
        get { return _Speed; }
        set
        {
            if (value > 40 | value < -40)
            {
                throw new Exception("Speed needs to be in between -40 and 40.");
            }
            else
            {
                _Speed = value;
            }
        }
    }
    public void DoAnimationScrollLeft(Control Control1, Control Control2)
    {
        Graphics G = Control1.CreateGraphics();
        Bitmap P1 = new Bitmap(Control1.Width, Control1.Height);
        Bitmap P2 = new Bitmap(Control2.Width, Control2.Height);
        Control1.DrawToBitmap(P1, new Rectangle(0, 0, Control1.Width, Control1.Height));
        Control2.DrawToBitmap(P2, new Rectangle(0, 0, Control2.Width, Control2.Height));

        foreach (Control c in Control1.Controls)
        {
            c.Hide();
        }

        int Slide = Control1.Width - (Control1.Width % _Speed);

        int a = 0;
        for (a = 0; a <= Slide; a += _Speed)
        {
            G.DrawImage(P1, new Rectangle(a, 0, Control1.Width, Control1.Height));
            G.DrawImage(P2, new Rectangle(a - Control2.Width, 0, Control2.Width, Control2.Height));
        }
        a = Control1.Width;
        G.DrawImage(P1, new Rectangle(a, 0, Control1.Width, Control1.Height));
        G.DrawImage(P2, new Rectangle(a - Control2.Width, 0, Control2.Width, Control2.Height));

        SelectedTab = (TabPage)Control2;

        foreach (Control c in Control2.Controls)
        {
            c.Show();
        }

        foreach (Control c in Control1.Controls)
        {
            c.Show();
        }
    }

    protected override void OnSelecting(System.Windows.Forms.TabControlCancelEventArgs e)
    {
        if (UseAnimation)
        {
            if (OldIndex < e.TabPageIndex)
            {
                DoAnimationScrollRight(TabPages[OldIndex], TabPages[e.TabPageIndex]);
            }
            else
            {
                DoAnimationScrollLeft(TabPages[OldIndex], TabPages[e.TabPageIndex]);
            }
        }
    }

    protected override void OnDeselecting(System.Windows.Forms.TabControlCancelEventArgs e)
    {
        OldIndex = e.TabPageIndex;
    }

    public void DoAnimationScrollRight(Control Control1, Control Control2)
    {
        Graphics G = Control1.CreateGraphics();
        Bitmap P1 = new Bitmap(Control1.Width, Control1.Height);
        Bitmap P2 = new Bitmap(Control2.Width, Control2.Height);
        Control1.DrawToBitmap(P1, new Rectangle(0, 0, Control1.Width, Control1.Height));
        Control2.DrawToBitmap(P2, new Rectangle(0, 0, Control2.Width, Control2.Height));

        foreach (Control c in Control1.Controls)
        {
            c.Hide();
        }

        int Slide = Control1.Width - (Control1.Width % _Speed);

        int a = 0;
        for (a = 0; a >= -Slide; a += -_Speed)
        {
            G.DrawImage(P1, new Rectangle(a, 0, Control1.Width, Control1.Height));
            G.DrawImage(P2, new Rectangle(a + Control2.Width, 0, Control2.Width, Control2.Height));
        }
        a = Control1.Width;
        G.DrawImage(P1, new Rectangle(a, 0, Control1.Width, Control1.Height));
        G.DrawImage(P2, new Rectangle(a + Control2.Width, 0, Control2.Width, Control2.Height));

        SelectedTab = (TabPage)Control2;

        foreach (Control c in Control2.Controls)
        {
            c.Show();
        }

        foreach (Control c in Control1.Controls)
        {
            c.Show();
        }
    }

    #endregion

    #endregion

}

#endregion

#endregion

#region Button

public class SpinButton : Control
{

    #region Declarations

    private static readonly HelperMethods H = new HelperMethods();
    private HelperMethods.MouseMode State;
    private int _RoundRadius = 5;
    private bool _IsEnabled = true;
    private Color _NormalColor = H.GetHTMLColor("FF2C97DE");
    private Color _NormalBorderColor = H.GetHTMLColor("FF2B90D2");
    private Color _NormalTextColor = Color.White;
    private Color _HoverColor = H.GetHTMLColor("8dd42e");
    private Color _HoverBorderColor = H.GetHTMLColor("83ae48");
    private Color _HoverTextColor = Color.White;
    private Color _PushedColor = H.GetHTMLColor("548710");
    private Color _PushedBorderColor = H.GetHTMLColor("83ae48");
    private Color _PushedTextColor = Color.White;

    #endregion

    #region Constructors
    public SpinButton()
    {
        SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
        DoubleBuffered = true;
        BackColor = Color.Transparent;
        Font = new Font("Segoe UI", 14, FontStyle.Regular);
        UpdateStyles();
    }

    #endregion

    #region Properties

    [Category("Custom Properties"), Description("Gets or sets a value indicating whether the control can Rounded in corners.")]
    public int RoundRadius
    {
        get { return _RoundRadius; }
        set
        {
            _RoundRadius = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets a value indicating whether the control can respond to user interaction.")]
    public bool IsEnabled
    {
        get { return _IsEnabled; }
        set
        {
            Enabled = value;
            _IsEnabled = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the the button color in normal mouse state.")]
    public Color NormalColor
    {
        get { return _NormalColor; }
        set
        {
            _NormalColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the the button border color in normal mouse state.")]
    public Color NormalBorderColor
    {
        get { return _NormalBorderColor; }
        set
        {
            _NormalBorderColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the the button Text color in normal mouse state.")]
    public Color NormalTextColor
    {
        get { return _NormalTextColor; }
        set
        {
            _NormalTextColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the the button color in hover mouse state.")]
    public Color HoverColor
    {
        get { return _HoverColor; }
        set
        {
            _HoverColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the the button border color in hover mouse state.")]
    public Color HoverBorderColor
    {
        get { return _HoverBorderColor; }
        set
        {
            _HoverBorderColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the the button Text color in hover mouse state.")]
    public Color HoverTextColor
    {
        get { return _HoverTextColor; }
        set
        {
            _HoverTextColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the the button color in mouse down state.")]
    public Color PushedColor
    {
        get { return _PushedColor; }
        set
        {
            _PushedColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the the button border color in mouse down state.")]
    public Color PushedBorderColor
    {
        get { return _PushedBorderColor; }
        set
        {
            _PushedBorderColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the the button Text color in mouse down state.")]
    public Color PushedTextColor
    {
        get { return _PushedTextColor; }
        set
        {
            _PushedTextColor = value;
            Invalidate();
        }
    }

    #endregion

    #region Draw Control

    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics G = e.Graphics;
        GraphicsPath GP = new GraphicsPath();
        Rectangle Rect = new Rectangle(0, 0, Width - 1, Height - 1);

        if (RoundRadius > 0)
        {
            G.SmoothingMode = SmoothingMode.AntiAlias;
            GP = H.RoundRec(Rect, RoundRadius);
        }
        else
        {
            GP.AddRectangle(Rect);
        }

        GP.CloseFigure();

        G.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

        switch (State)
        {
            case HelperMethods.MouseMode.Normal:

                using (SolidBrush BG = new SolidBrush(NormalColor))
                using (Pen P = new Pen(NormalBorderColor))
                using (SolidBrush TB = new SolidBrush(NormalTextColor))
                {
                    G.FillPath(BG, GP);
                    G.DrawPath(P, GP);
                    H.CentreString(G, Text, Font, TB, new Rectangle(0, 0, Width, Height));
                }
                break;
            case HelperMethods.MouseMode.Hovered:
                Cursor = Cursors.Hand;
                using (SolidBrush BG = new SolidBrush(HoverColor))
                using (Pen P = new Pen(HoverBorderColor))
                using (SolidBrush TB = new SolidBrush(NormalTextColor))
                {
                    G.FillPath(BG, GP);
                    G.DrawPath(P, GP);
                    H.CentreString(G, Text, Font, TB, new Rectangle(0, 0, Width, Height));
                }
                break;
            case HelperMethods.MouseMode.Pushed:
                using (SolidBrush BG = new SolidBrush(PushedColor))
                using (Pen P = new Pen(PushedBorderColor))
                using (SolidBrush TB = new SolidBrush(NormalTextColor))
                {
                    G.FillPath(BG, GP);
                    G.DrawPath(P, GP);
                    H.CentreString(G, Text, Font, TB, new Rectangle(0, 0, Width, Height));
                }
                break;
        }

        GP.Dispose();
    }

    #endregion

    #region Events

    protected override void OnMouseUp(MouseEventArgs e)
    {
        base.OnMouseUp(e);
        State = HelperMethods.MouseMode.Hovered;
        Invalidate();
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        base.OnMouseUp(e);
        State = HelperMethods.MouseMode.Pushed;
        Invalidate();
    }

    protected override void OnMouseEnter(EventArgs e)
    {
        base.OnMouseEnter(e);
        State = HelperMethods.MouseMode.Hovered;
        Invalidate();
    }

    protected override void OnMouseLeave(EventArgs e)
    {
        base.OnMouseEnter(e);
        State = HelperMethods.MouseMode.Normal;
        Invalidate();
    }

    #endregion

}

public class SpinPlusButton : Control
{

    #region Declarations

    private static readonly HelperMethods H = new HelperMethods();
    private HelperMethods.MouseMode State;
    private int _RoundRadius = 5;
    private bool _IsEnabled = true;
    private Color _NormalColor = H.GetHTMLColor("FF2C97DE");
    private Color _NormalBorderColor = H.GetHTMLColor("FF2B90D2");
    private Color _NormalTextColor = Color.White;
    private Color _HoverColor = H.GetHTMLColor("8dd42e");
    private Color _HoverBorderColor = H.GetHTMLColor("83ae48");
    private Color _HoverTextColor = Color.White;
    private Color _PushedColor = H.GetHTMLColor("548710");
    private Color _PushedBorderColor = H.GetHTMLColor("83ae48");
    private Color _PushedTextColor = Color.White;
    private Image _Image = null;

    #endregion

    #region Constructors

    public SpinPlusButton()
    {
        SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
        DoubleBuffered = true;
        BackColor = Color.Transparent;
        Font = new Font("Segoe UI", 14, FontStyle.Regular);
        UpdateStyles();
    }

    #endregion

    #region Properties

    [Category("Custom Properties"), Description("Gets or sets a value indicating whether the control can Rounded in corners.")]
    public int RoundRadius
    {
        get { return _RoundRadius; }
        set
        {
            _RoundRadius = value;

            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets a value indicating whether the control can respond to user interaction.")]
    public bool IsEnabled
    {
        get { return _IsEnabled; }
        set
        {
            Enabled = value;
            _IsEnabled = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the the button color in normal mouse state.")]
    public Color NormalColor
    {
        get { return _NormalColor; }
        set
        {
            _NormalColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the the button border color in normal mouse state.")]
    public Color NormalBorderColor
    {
        get { return _NormalBorderColor; }
        set
        {
            _NormalBorderColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the the button Text color in normal mouse state.")]
    public Color NormalTextColor
    {
        get { return _NormalTextColor; }
        set
        {
            _NormalTextColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the the button color in hover mouse state.")]
    public Color HoverColor
    {
        get { return _HoverColor; }
        set
        {
            _HoverColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the the button border color in hover mouse state.")]
    public Color HoverBorderColor
    {
        get { return _HoverBorderColor; }
        set
        {
            _HoverBorderColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the the button Text color in hover mouse state.")]
    public Color HoverTextColor
    {
        get { return _HoverTextColor; }
        set
        {
            _HoverTextColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the the button color in mouse down state.")]
    public Color PushedColor
    {
        get { return _PushedColor; }
        set
        {
            _PushedColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the the button border color in mouse down state.")]
    public Color PushedBorderColor
    {
        get { return _PushedBorderColor; }
        set
        {
            _PushedBorderColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the the button Text color in mouse down state.")]
    public Color PushedTextColor
    {
        get { return _PushedTextColor; }
        set
        {
            _PushedTextColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the image that is displayed on a button control.")]
    public System.Drawing.Image Image
    {
        get { return _Image; }
        set
        {
            _Image = value;
            Invalidate();
        }
    }

    #endregion

    #region Draw Control

    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics G = e.Graphics;
        GraphicsPath GP = new GraphicsPath();
        Rectangle Rect = new Rectangle(0, 0, Width - 1, Height - 1);
        Rectangle newRect = new Rectangle(0, 0, Width / 5, Height);
        GraphicsPath GPN = new GraphicsPath();

        if (RoundRadius > 0)
        {
            G.SmoothingMode = SmoothingMode.AntiAlias;
            GP = H.RoundRec(Rect, RoundRadius);
            GPN = H.RoundRec(newRect, RoundRadius, true, false, true, false);
        }
        else
        {
            GP.AddRectangle(Rect);
            GPN.AddRectangle(newRect);
        }

        GP.CloseFigure();
        GPN.CloseFigure();

        G.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
        G.InterpolationMode = InterpolationMode.HighQualityBicubic;

        switch (State)
        {
            case HelperMethods.MouseMode.Normal:

                using (SolidBrush BG = new SolidBrush(NormalColor))
                using (Pen P = new Pen(NormalBorderColor))
                using (SolidBrush PLSGP = new SolidBrush(Color.FromArgb(35, Color.Black)))
                using (SolidBrush TC = new SolidBrush(NormalTextColor))
                {
                    G.FillPath(BG, GP);
                    G.FillPath(PLSGP, GPN);
                    G.DrawPath(P, GP);
                    H.CentreString(G, Text, Font, TC, new Rectangle(Width / 7, 0, Width - Width / 7, Height));
                }
                break;
            case HelperMethods.MouseMode.Hovered:

                Cursor = Cursors.Hand;
                using (SolidBrush BG = new SolidBrush(HoverColor))
                using (Pen P = new Pen(HoverBorderColor))
                using (SolidBrush PLSGP = new SolidBrush(Color.FromArgb(35, Color.Black)))
                using (SolidBrush TC = new SolidBrush(HoverTextColor))
                {
                     G.FillPath(BG, GP);
                     G.FillPath(PLSGP, GPN);
                     G.DrawPath(P, GP);
                     H.CentreString(G, Text, Font, TC, new Rectangle(Width / 7, 0, Width - Width / 7, Height));
                }

                break;
            case HelperMethods.MouseMode.Pushed:

                using (SolidBrush BG = new SolidBrush(PushedColor))
                using (Pen P = new Pen(PushedBorderColor))
                using (SolidBrush PLSGP = new SolidBrush(Color.FromArgb(35, Color.Black)))
                using (SolidBrush TC = new SolidBrush(PushedTextColor))
                {
                     G.FillPath(BG, GP);
                     G.FillPath(PLSGP, GPN);
                     G.DrawPath(P, GP);
                     H.CentreString(G, Text, Font, TC, new Rectangle(Width / 7, 0, Width - Width / 7, Height));
                }

                break;
        }

        if (Image != null)
        {G.DrawImage(Image, new Rectangle(new Point(newRect.Left + newRect.Width / 2 - Image.Width / 2, newRect.Top + newRect.Height / 2 - Image.Height / 2), Image.Size));}
       
        GP.Dispose();
        GPN.Dispose();

    }

    #endregion

    #region Events

    protected override void OnMouseUp(MouseEventArgs e)
    {
        base.OnMouseUp(e);
        State = HelperMethods.MouseMode.Hovered;
        Invalidate();
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        base.OnMouseUp(e);
        State = HelperMethods.MouseMode.Pushed;
        Invalidate();
    }

    protected override void OnMouseEnter(EventArgs e)
    {
        base.OnMouseEnter(e);
        State = HelperMethods.MouseMode.Hovered;
        Invalidate();
    }

    protected override void OnMouseLeave(EventArgs e)
    {
        base.OnMouseEnter(e);
        State = HelperMethods.MouseMode.Normal;
        Invalidate();
    }

    #endregion

}

public class SpinTileButton : Control
{

    #region Declarations

    private static readonly HelperMethods H = new HelperMethods();
    private HelperMethods.MouseMode State;
    private int _RoundRadius = 5;
    private bool _IsEnabled = true;
    private Color _NormalColor = H.GetHTMLColor("FF2C97DE");
    private Color _NormalBorderColor = H.GetHTMLColor("FF2B90D2");
    private Color _NormalTextColor = Color.White;
    private Color _HoverColor = H.GetHTMLColor("8dd42e");
    private Color _HoverBorderColor = H.GetHTMLColor("83ae48");
    private Color _HoverTextColor = Color.White;
    private Color _PushedColor = H.GetHTMLColor("548710");
    private Color _PushedBorderColor = H.GetHTMLColor("83ae48");
    private Color _PushedTextColor = Color.White;
    private Image _Image = null;
    private Size _ImageSize = new Size(30, 30);
    private ContentAlignment _TileImageAlign = ContentAlignment.TopLeft;

    #endregion

    #region Constructors

    public SpinTileButton()
    {
        SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
        DoubleBuffered = true;
        BackColor = Color.Transparent;
        Font = new Font("Segoe UI", 14, FontStyle.Regular);
        UpdateStyles();
    }

    #endregion

    #region Properties

    [Category("Custom Properties"), Description("Gets or sets the image that is displayed on a button control.")]
    public Size ImageSize
    {
        get { return _ImageSize; }
        set
        {
            _ImageSize = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the image that is displayed on a button control.")]
    public System.Drawing.Image Image
    {
        get { return _Image; }
        set
        {
            _Image = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets a value indicating whether the control can Rounded in corners.")]
    public int RoundRadius
    {
        get { return _RoundRadius; }
        set
        {
            _RoundRadius = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets a value indicating whether the control can respond to user interaction.")]
    public bool IsEnabled
    {
        get { return _IsEnabled; }
        set
        {
            Enabled = value;
            _IsEnabled = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the the button color in normal mouse state.")]
    public Color NormalColor
    {
        get { return _NormalColor; }
        set
        {
            _NormalColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the the button border color in normal mouse state.")]
    public Color NormalBorderColor
    {
        get { return _NormalBorderColor; }
        set
        {
            _NormalBorderColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the the button Text color in normal mouse state.")]
    public Color NormalTextColor
    {
        get { return _NormalTextColor; }
        set
        {
            _NormalTextColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the the button color in hover mouse state.")]
    public Color HoverColor
    {
        get { return _HoverColor; }
        set
        {
            _HoverColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the the button border color in hover mouse state.")]
    public Color HoverBorderColor
    {
        get { return _HoverBorderColor; }
        set
        {
            _HoverBorderColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the the button Text color in hover mouse state.")]
    public Color HoverTextColor
    {
        get { return _HoverTextColor; }
        set
        {
            _HoverTextColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the the button color in mouse down state.")]
    public Color PushedColor
    {
        get { return _PushedColor; }
        set
        {
            _PushedColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the the button border color in mouse down state.")]
    public Color PushedBorderColor
    {
        get { return _PushedBorderColor; }
        set
        {
            _PushedBorderColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the the button Text color in mouse down state.")]
    public Color PushedTextColor
    {
        get { return _PushedTextColor; }
        set
        {
            _PushedTextColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the image Alignment that is displayed on a button control.")]
    public ContentAlignment TileImageAlign
    {
        get { return _TileImageAlign; }
        set
        {
            _TileImageAlign = value;
            Invalidate();
        }
    }

    #endregion

    #region Draw Control

    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics G = e.Graphics;
        GraphicsPath GP = new GraphicsPath();
        Rectangle Rect = new Rectangle(0, 0, Width - 1, Height - 1);

        if (RoundRadius > 0)
        {
            G.SmoothingMode = SmoothingMode.AntiAlias;
            GP = H.RoundRec(Rect, RoundRadius);
        }
        else
        {
            GP.AddRectangle(Rect);
        }

        GP.CloseFigure();

        G.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

        switch (State)
        {

            case HelperMethods.MouseMode.Normal:

                using (SolidBrush BG = new SolidBrush(NormalColor))
                using (Pen P = new Pen(NormalBorderColor))
                using (SolidBrush TC = new SolidBrush(NormalTextColor))
                {
                    G.FillPath(BG, GP);
                    G.DrawPath(P, GP);
                    G.DrawString(Text, Font, TC, new Rectangle(0, 0, Width, Height), H.SetPosition(StringAlignment.Center, StringAlignment.Far));
                }
                break;

            case HelperMethods.MouseMode.Hovered:

                Cursor = Cursors.Hand;

                using (SolidBrush BG = new SolidBrush(HoverColor))
                using (Pen P = new Pen(HoverBorderColor))
                using (SolidBrush TC = new SolidBrush(HoverTextColor))
                {
                    G.FillPath(BG, GP);
                    G.DrawPath(P, GP);
                    G.DrawString(Text, Font, TC, new Rectangle(0, 0, Width, Height), H.SetPosition(StringAlignment.Center, StringAlignment.Far));
                }
                break;

            case HelperMethods.MouseMode.Pushed:

                using (SolidBrush BG = new SolidBrush(PushedColor))
                using (Pen P = new Pen(PushedBorderColor))
                using (SolidBrush TC = new SolidBrush(PushedTextColor))
                {
                    G.FillPath(BG, GP);
                    G.DrawPath(P, GP);
                    G.DrawString(Text, Font, TC, new Rectangle(0, 0, Width, Height), H.SetPosition(StringAlignment.Center, StringAlignment.Far));
                }
                break;
        }

        if (Image != null)
        {G.DrawImage(Image, new Point(Rect.Left + Rect.Width / 2 - Image.Width / 2, Rect.Top + Rect.Height / 2 - Image.Height / 2));}

        GP.Dispose();
    }

    #endregion

    #region Events

    protected override void OnMouseUp(MouseEventArgs e)
    {
        base.OnMouseUp(e);
        State = HelperMethods.MouseMode.Hovered;
        Invalidate();
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        base.OnMouseUp(e);
        State = HelperMethods.MouseMode.Pushed;
        Invalidate();
    }

    protected override void OnMouseEnter(EventArgs e)
    {
        base.OnMouseEnter(e);
        State = HelperMethods.MouseMode.Hovered;
        Invalidate();
    }

    protected override void OnMouseLeave(EventArgs e)
    {
        base.OnMouseEnter(e);
        State = HelperMethods.MouseMode.Normal;
        Invalidate();
    }

    #endregion

}

public class SpinDescriptiveButton : Control
{

    #region Declarations

    private static readonly HelperMethods H = new HelperMethods();
    private HelperMethods.MouseMode State;
    private int _RoundRadius = 5;
    private bool _IsEnabled = true;
    private Color _NormalColor = H.GetHTMLColor("FF2C97DE");
    private Color _NormalBorderColor = H.GetHTMLColor("FF2B90D2");
    private Color _NormalTextColor = Color.White;
    private Color _HoverColor = H.GetHTMLColor("8dd42e");
    private Color _HoverBorderColor = H.GetHTMLColor("83ae48");
    private Color _HoverTextColor = Color.White;
    private Color _PushedColor = H.GetHTMLColor("548710");
    private Color _PushedBorderColor = H.GetHTMLColor("83ae48");
    private Color _PushedTextColor = Color.White;
    private string _Title = "Title";
    private string _Text = "This is the descriptive button";

    #endregion

    #region Constructors

    public SpinDescriptiveButton()
    {
        SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
        DoubleBuffered = true;
        BackColor = Color.Transparent;
        Font = new Font("Segoe UI", 14, FontStyle.Bold);
        UpdateStyles();
    }

    #endregion

    #region Properties

    [Category("Custom Properties"), Description("Gets or sets the Title text of control.")]
    public string Title
    {
        get { return _Title; }
        set
        {
            _Title = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the content text of control.")]
    public new string Text
    {
        get { return _Text; }
        set
        {
            _Text = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets a value indicating whether the control can Rounded in corners.")]
    public int RoundRadius
    {
        get { return _RoundRadius; }
        set
        {
            _RoundRadius = value;

            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets a value indicating whether the control can respond to user interaction.")]
    public bool IsEnabled
    {
        get { return _IsEnabled; }
        set
        {
            Enabled = value;
            _IsEnabled = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the the button color in normal mouse state.")]
    public Color NormalColor
    {
        get { return _NormalColor; }
        set
        {
            _NormalColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the the button border color in normal mouse state.")]
    public Color NormalBorderColor
    {
        get { return _NormalBorderColor; }
        set
        {
            _NormalBorderColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the the button Text color in normal mouse state.")]
    public Color NormalTextColor
    {
        get { return _NormalTextColor; }
        set
        {
            _NormalTextColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the the button color in hover mouse state.")]
    public Color HoverColor
    {
        get { return _HoverColor; }
        set
        {
            _HoverColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the the button border color in hover mouse state.")]
    public Color HoverBorderColor
    {
        get { return _HoverBorderColor; }
        set
        {
            _HoverBorderColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the the button Text color in hover mouse state.")]
    public Color HoverTextColor
    {
        get { return _HoverTextColor; }
        set
        {
            _HoverTextColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the the button color in mouse down state.")]
    public Color PushedColor
    {
        get { return _PushedColor; }
        set
        {
            _PushedColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the the button border color in mouse down state.")]
    public Color PushedBorderColor
    {
        get { return _PushedBorderColor; }
        set
        {
            _PushedBorderColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the the button Text color in mouse down state.")]
    public Color PushedTextColor
    {
        get { return _PushedTextColor; }
        set
        {
            _PushedTextColor = value;
            Invalidate();
        }
    }


    #endregion

    #region Draw Control

    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics G = e.Graphics;
        GraphicsPath GP = new GraphicsPath();
        Rectangle Rect = new Rectangle(0, 0, Width - 1, Height - 1);

        if (RoundRadius > 0)
        {
            G.SmoothingMode = SmoothingMode.AntiAlias;
            GP = H.RoundRec(Rect, RoundRadius);
        }
        else
        {
            GP.AddRectangle(Rect);
        }

        GP.CloseFigure();

        G.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

        switch (State)
        {

            case HelperMethods.MouseMode.Normal:

                using (SolidBrush BG = new SolidBrush(NormalColor))
                using (Pen P = new Pen(NormalBorderColor))
                using (SolidBrush B = new SolidBrush(NormalTextColor))
                using (Font F = new Font(Font.FontFamily, 12))
                {
                    G.FillPath(BG, GP);
                    G.DrawPath(P, GP);
                    G.DrawString(Title, Font, B, new PointF(5, 8));
                    SizeF TitleSize = G.MeasureString(Title, Font);
                    G.DrawString(Text, F, B, new PointF(5, (float)(TitleSize.Height * 1.5)), StringFormat.GenericDefault);
                }
                break;

            case HelperMethods.MouseMode.Hovered:

                Cursor = Cursors.Hand;
                using (SolidBrush BG = new SolidBrush(HoverColor))
                using (Pen P = new Pen(HoverBorderColor))
                using (SolidBrush B = new SolidBrush(HoverTextColor))
                using (Font F = new Font(Font.FontFamily, 12))
                {
                    G.FillPath(BG, GP);
                    G.DrawPath(P, GP);
                    G.DrawString(Title, Font, B, new PointF(5, 8));
                    SizeF TitleSize = G.MeasureString(Title, Font);
                    G.DrawString(Text, F, B, new PointF(5, (float)(TitleSize.Height * 1.5)), StringFormat.GenericDefault);
                }
                break;

            case HelperMethods.MouseMode.Pushed:

                using (SolidBrush BG = new SolidBrush(PushedColor))
                using (Pen P = new Pen(PushedBorderColor))
                using (SolidBrush B = new SolidBrush(PushedTextColor))
                using (Font F = new Font(Font.FontFamily, 12))
                {
                    G.FillPath(BG, GP);
                    G.DrawPath(P, GP);
                    G.DrawString(Title, Font, B, new PointF(5, 8));
                    SizeF TitleSize = G.MeasureString(Title, Font);
                    G.DrawString(Text, F, B, new PointF(5, (float)(TitleSize.Height * 1.5)), StringFormat.GenericDefault);
                }

                break;
        }

        GP.Dispose();
    }

    #endregion

    #region Events

    protected override void OnMouseUp(MouseEventArgs e)
    {
        base.OnMouseUp(e);
        State = HelperMethods.MouseMode.Hovered;
        Invalidate();
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        base.OnMouseUp(e);
        State = HelperMethods.MouseMode.Pushed;
        Invalidate();
    }

    protected override void OnMouseEnter(EventArgs e)
    {
        base.OnMouseEnter(e);
        State = HelperMethods.MouseMode.Hovered;
        Invalidate();
    }

    protected override void OnMouseLeave(EventArgs e)
    {
        base.OnMouseEnter(e);
        State = HelperMethods.MouseMode.Normal;
        Invalidate();
    }

    #endregion

}

#endregion

#region TextBox

[DefaultEvent("TextChanged")]
public class SpinTextbox : Control
{

    #region Declarations

    private TextBox T = new TextBox();
    private TextBox _T
    {
        get { return _T; }
        set
        {
            if (_T != null)
            {
                _T.Leave -= T_Leave;
                _T.Enter -= T_Enter;
                _T.KeyDown -= T_KeyDown;
                _T.TextChanged -= T_TextChanged;
            }
            _T = value;
            if (_T != null)
            {
                _T.Leave += T_Leave;
                _T.Enter += T_Enter;
                _T.KeyDown += T_KeyDown;
                _T.TextChanged += T_TextChanged;
            }
        }
    }
    private static readonly HelperMethods H = new HelperMethods();
    private HorizontalAlignment _TextAlign = HorizontalAlignment.Left;
    private int _MaxLength = 32767;
    private bool _ReadOnly = false;
    private bool _UseSystemPasswordChar = false;
    private string _WatermarkText = string.Empty;
    private Image _Image;
    private HelperMethods.MouseMode State = HelperMethods.MouseMode.Normal;
    private Color _BackColor = H.GetHTMLColor("262626");
    private Color _ForeColor = H.GetHTMLColor("444444");
    private AutoCompleteSource _AutoCompleteSource = AutoCompleteSource.None;
    private AutoCompleteMode _AutoCompleteMode = AutoCompleteMode.None;
    private AutoCompleteStringCollection _AutoCompleteCustomSource;
    private bool _Multiline = false;
    private string[] _Lines = null;
    private Color _BorderColor = H.GetHTMLColor("444444");
    private Color _HoverColor = H.GetHTMLColor("FF2C97DE");

    #endregion

    #region Native Methods 

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, string lParam);

    #endregion

    #region Properties

    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public BorderStyle BorderStyle
    {
        get {return BorderStyle.None;}
    }

    [Category("Custom Properties"), Description("Gets or sets how text is aligned in a Spin TextBox control.")]
    public HorizontalAlignment TextAlign
    {
        get { return _TextAlign; }
        set
        {
            _TextAlign = value;
            TextBox _text = T;
            if (_text != null)
            {
                _text.TextAlign = value;
            }
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets how text is aligned in a Spin TextBox control.")]
    public int MaxLength
    {
        get { return _MaxLength; }
        set
        {
            _MaxLength = value;
            if (T != null)
            {
                T.MaxLength = value;
            }
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the background color of the control.")]
    public override Color BackColor
    {
        get { return _BackColor; }
        set
        {
            base.BackColor = value;
            _BackColor = value;
            T.BackColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the color of the control whenever hovered.")]
    public Color HoverColor
    {
        get { return _HoverColor; }
        set
        {
            _HoverColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the border color of the control.")]
    public Color BorderColor
    {
        get { return _BorderColor; }
        set
        {
            _BorderColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the foreground color of the control.")]
    public override Color ForeColor
    {
        get { return _ForeColor; }
        set
        {
            base.ForeColor = value;
            _ForeColor = value;
            T.ForeColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets a value indicating whether text in the text box is read-only.")]
    public bool ReadOnly
    {
        get { return _ReadOnly; }
        set
        {
            _ReadOnly = value;
            if (T != null)
            {
                T.ReadOnly = value;
            }
        }
    }

    [Category("Custom Properties"), Description("Gets or sets a value indicating whether the text in the Spin TextBox control should appear as the default password character.")]
    public bool UseSystemPasswordChar
    {
        get { return _UseSystemPasswordChar; }
        set
        {
            _UseSystemPasswordChar = value;
            if (T != null)
            {
                T.UseSystemPasswordChar = value;
            }
        }
    }

    [Category("Custom Properties"), Description("Gets or sets a value indicating whether this is a multiline System.Windows.Forms.TextBox control.")]
    public bool Multiline
    {
        get { return _Multiline; }
        set
        {
            _Multiline = value;
            if (T == null)
            {return;}
            T.Multiline = value;
            if (value)
            {
                T.Height = Height - 10;
            }
            else
            {
                Height = T.Height + 10;
            }
        }
    }

    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override Image BackgroundImage
    {
        get { return null; }
    }

    [Category("Custom Properties"), Description("Gets or sets the current text in the Spin TextBox.")]
    public override string Text
    {
        get { return T.Text; }
        set
        {
            base.Text = value;
            if (T != null)
            {
                T.Text = value;
            }
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the text in the System.Windows.Forms.TextBox while being empty.")]
    public string WatermarkText
    {
        get { return _WatermarkText; }
        set
        {
            _WatermarkText = value;
            SendMessage(T.Handle, 5377, 0, value);
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the image of the control.")]
    public Image Image
    {
        get { return _Image; }
        set
        {
            _Image = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets a value specifying the source of complete strings used for automatic completion.")]
    public AutoCompleteSource AutoCompleteSource
    {
        get { return _AutoCompleteSource; }
        set
        {
            _AutoCompleteSource = value;
            if (T != null)
            {
                T.AutoCompleteSource = value;
            }
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets a value specifying the source of complete strings used for automatic completion.")]
    public AutoCompleteStringCollection AutoCompleteCustomSource
    {
        get { return _AutoCompleteCustomSource; }
        set
        {
            _AutoCompleteCustomSource = value;
            if (T != null)
            {
                T.AutoCompleteCustomSource = value;
            }
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets an option that controls how automatic completion works for the TextBox.")]
    public AutoCompleteMode AutoCompleteMode
    {
        get { return _AutoCompleteMode; }
        set
        {
            _AutoCompleteMode = value;
            if (T != null)
            {
                T.AutoCompleteMode = value;
            }
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the font of the text displayed by the control.")]
    public override Font Font
    {
        get { return base.Font; }
        set
        {
            base.Font = value;
            if (T == null)
                return;
            T.Font = value;
            T.Location = new Point(5, 5);
            T.Width = Width - 8;
            if (!Multiline)
                Height = T.Height + 11;
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the lines of text in the control.")]
    public string[] Lines
    {
        get { return _Lines; }
        set
        {
            _Lines = value;
            if (T != null)
            T.Lines = value;
            Invalidate();
        }
    }
    
    [Category("Custom Properties"), Description("Gets or sets the ContextMenuStrip associated with this control.")]
    public override ContextMenuStrip ContextMenuStrip
    {
        get { return base.ContextMenuStrip; }
        set
        {
            base.ContextMenuStrip = value;
            if (T == null)
                return;
            T.ContextMenuStrip = value;
            Invalidate();
        }
    }


    #endregion

    #region Constructors

    public SpinTextbox()
    {
        SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
        DoubleBuffered = true;
        Font = new Font("Segoe UI", 11, FontStyle.Regular);
        T_Defaults();
        Size = new Size(135, 30);
        UpdateStyles();
        
    }

    void T_Defaults()
    {
        T.TextChanged += T_TextChanged;
        T.KeyDown += T_KeyDown;
        T.Multiline = false;
        T.Cursor = Cursors.IBeam;
        T.BackColor = BackColor;
        T.ForeColor = ForeColor;
        T.BorderStyle = BorderStyle.None;
        T.Location = new Point(7, 8);
        T.Font = Font;
        T.UseSystemPasswordChar = UseSystemPasswordChar;
        if (Multiline)
        {
            T.Height = Height - 11;
        }
        else
        {
            Height = T.Height + 11;
        }
    }

    #endregion

    #region Events

    public new event TextChangedEventHandler TextChanged;
    public delegate void TextChangedEventHandler(object sender);

    private void T_Leave(object sender, EventArgs e)
    {
        if (Text.Length == 0)
        {
            Text = WatermarkText;
            T.ForeColor = ForeColor;
        }
    }
    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        T.Size = new Size(Width - 10, Height - 10);
    }
    private void T_Enter(object sender, EventArgs e)
    {
        if (Text == WatermarkText)
        {
            Text = "";
            T.ForeColor = Color.Gray;
        }
    }

    private void T_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.Control && e.KeyCode == Keys.A)
            e.SuppressKeyPress = true;
        if (e.Control && e.KeyCode == Keys.C)
        {
            T.Copy();
            e.SuppressKeyPress = true;
        }
    }
    private void T_TextChanged(object sender, EventArgs e)
    {
        Text = T.Text;
        TextChanged?.Invoke(this);
        Invalidate();
    }
    protected override void OnCreateControl()
    {
        base.OnCreateControl();
        if (!Controls.Contains(T))
            Controls.Add(T);
        if (string.IsNullOrEmpty(T.Text) && !string.IsNullOrEmpty(WatermarkText))
        {
            T.Text = WatermarkText;
        }
    }

    public void AppendText(string text)
    {
        if (T != null)
        {
            T.AppendText(text);
        }
    }

    public void Undo()
    {
        if (T != null)
        {
            if (T.CanUndo)
            {
                T.Undo();
            }
        }
    }

    public int GetLineFromCharIndex(int index)
    {
        if (T != null)
        {
            return T.GetLineFromCharIndex(index);
        }
        else
        {
            return 0;
        }
    }

    public System.Drawing.Point GetPositionFromCharIndex(int index)
    {
        return T.GetPositionFromCharIndex(index);
    }

    public int GetCharIndexFromPosition(System.Drawing.Point pt)
    {
        if (T == null)
            return 0;
        return T.GetCharIndexFromPosition(pt);
    }

    public void ClearUndo()
    {
        if (T == null)
            return;
        T.ClearUndo();
    }

    public void Copy()
    {
        if (T == null)
            return;
        T.Copy();
    }

    public void Cut()
    {
        if (T == null)
            return;
        T.Cut();
    }

    public void SelectAll()
    {
        if (T == null)
            return;
        T.SelectAll();
    }

    public void DeselectAll()
    {
        if (T == null)
            return;
        T.DeselectAll();
    }

    public void Paste(string clipFormat)
    {
        if (T == null)
            return;
        T.Paste(clipFormat);
    }

    public void Select(int start, int length)
    {
        if (T == null)
            return;
        T.Select(start, length);
    }

    #endregion

    #region Draw Control

    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics G = e.Graphics;
        Rectangle Rect = new Rectangle(0, 0, Width - 1, Height - 1);
        G.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

        using (SolidBrush BG = new SolidBrush(BackColor))
        using (Pen P = new Pen(BorderColor))
        using (Pen PH = new Pen(HoverColor))
        {
            switch (State)
            {
                case HelperMethods.MouseMode.Normal:
                    G.FillRectangle(BG, Rect);
                    G.DrawRectangle(P, Rect);
                    break;
                case HelperMethods.MouseMode.Pushed:
                    G.FillRectangle(BG, Rect);
                    G.DrawRectangle(PH, Rect);
                    break;
            }
        }

        if (Image != null)
        {
            T.Location = new Point(31, 4);
            T.Width = Width - 60;
            G.InterpolationMode = InterpolationMode.HighQualityBicubic;
            G.DrawImage(Image, new Rectangle(7, 6, 18, 18));
        }
        else
        {
            T.Location = new Point(7, 4);
            T.Width = Width - 10;
        }

    }

    #endregion

}

#endregion

#region CheckBox

public class SpinCheckBox : Control
{

    #region Declarations

    private static readonly HelperMethods H = new HelperMethods();
    private bool _Checked;
    protected HelperMethods.MouseMode State = HelperMethods.MouseMode.Normal;
    private Color _CheckBorderColor = H.GetHTMLColor("164772");
    private Color _UnCheckBorderColor = Color.Black;
    private Color _CheckedColor = Color.White;
    private Color _UnCheckColor = Color.Gray;
    private Color _CheckBackGroundColor = H.GetHTMLColor("FF2C97DE");
    private Color _UnCheckBackGroundColor = H.GetHTMLColor("FF353535");
    private Timer AnimationTimer = new Timer() { Interval = 20 };
    private int Alpha = 0;

    #endregion

    #region Properties

    [Category("Custom Properties"), Description("Gets or set a value indicating whether the control is in the checked state.")]
    public bool Checked
    {
        get { return _Checked; }
        set
        {
            _Checked = value;
            CheckedChanged?.Invoke(this);
            Invalidate();
        }
    }

    [Browsable(false), Category("Custom Properties"), Description("Gets or sets the Radiobutton control border color while checked.")]
    public Color CheckBorderColor
    {
        get { return _CheckBorderColor; }
        set
        {
            _CheckBorderColor = value;
            Invalidate();
        }
    }

    [Browsable(false), Category("Custom Properties"), Description("Gets or sets the Radiobutton control border color while unchecked.")]
    public Color UnCheckBorderColor
    {
        get { return _UnCheckBorderColor; }
        set
        {
            _UnCheckBorderColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the Radiobutton control check symbol color while checked.")]
    public Color CheckColor
    {
        get { return _CheckedColor; }
        set
        {
            _CheckedColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the Radiobutton control check symbol color while Unchecked.")]
    public Color UnCheckColor
    {
        get { return _UnCheckColor; }
        set
        {
            _UnCheckColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the Radiobutton control check symbol color while checked.")]
    public Color CheckBackGroundColor
    {
        get { return _CheckBackGroundColor; }
        set
        {
            _CheckBackGroundColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the Radiobutton control check symbol color while Unchecked.")]
    public Color UnCheckBackGroundColor
    {
        get { return _UnCheckBackGroundColor; }
        set
        {
            _UnCheckBackGroundColor = value;
            Invalidate();
        }
    }

    #endregion

    #region Constructors

    public SpinCheckBox()
    {
        SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
        DoubleBuffered = true;
        Cursor = Cursors.Hand;
        BackColor = Color.Transparent;
        AnimationTimer.Tick += AnimationTick;
        ForeColor = H.GetHTMLColor("C5C5C5");
        Font = new Font("Segoe UI", 9);
        UpdateStyles();
    }

    #endregion

    #region Draw Control

    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics G = e.Graphics;
        G.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
        Rectangle rect = new Rectangle(0, 0, Convert.ToInt32(17.5), 17);
        using (Brush BackBrush = Checked ? new SolidBrush(CheckBackGroundColor) : new SolidBrush(UnCheckBackGroundColor))
        using (Brush CheckMarkBrush = Checked ? new SolidBrush(Color.FromArgb(Alpha, CheckColor)) : new SolidBrush(UnCheckColor))
        using (SolidBrush TC = new SolidBrush(ForeColor))
        using (Font F = new Font("Marlett", 13))
        using (StringFormat SF = new StringFormat{Alignment = StringAlignment.Near,LineAlignment = StringAlignment.Center})
        {
            G.FillRectangle(BackBrush, rect);
            G.DrawString("b", F, CheckMarkBrush, new Rectangle(-2, Convert.ToInt32(0.5), Width, Height));
            G.DrawString(Text, Font, TC, new Rectangle(18, Convert.ToInt32(1.5), Width, Height - 4), SF);
        }
    }

    #endregion

    #region Events

    public event CheckedChangedEventHandler CheckedChanged;
    public delegate void CheckedChangedEventHandler(object sender);

    private void AnimationTick(object sender, EventArgs e)
    {
        if (Checked)
        {
            if (Alpha < 250)
            {
                Alpha += 25;
                Invalidate();
            }
        }
        else if (Alpha > 0)
        {
            Alpha -= 25;
            Invalidate();
        }
    }

    protected override void OnClick(EventArgs e)
    {
        _Checked = !Checked;
        CheckedChanged?.Invoke(this);
        base.OnClick(e);
        Invalidate();
    }

    protected override void OnTextChanged(System.EventArgs e)
    {
        Invalidate();
        base.OnTextChanged(e);
    }

    protected override void OnResize(System.EventArgs e)
    {
        base.OnResize(e);
        Height = 17;
        Invalidate();
    }

    protected override void OnMouseHover(EventArgs e)
    {
        base.OnMouseHover(e);
        State = HelperMethods.MouseMode.Hovered;
        Invalidate();
    }

    protected override void OnMouseLeave(EventArgs e)
    {
        base.OnMouseLeave(e);
        State = HelperMethods.MouseMode.Normal;
        Invalidate();
    }

    protected override void OnHandleCreated(EventArgs e)
    {
        base.OnHandleCreated(e);
        AnimationTimer.Start();
    }

    #endregion

}

#endregion

#region RadioButton

[DefaultEvent("CheckedChanged"), DefaultProperty("Checked")]
public class SpinRadioButton : Control
{

    #region Declarations

    private static readonly HelperMethods H = new HelperMethods();
    private bool _Checked;
    protected int _Group = 1;
    protected HelperMethods.MouseMode State = HelperMethods.MouseMode.Normal;
    private Color _CheckBorderColor = H.GetHTMLColor("164772");
    private Color _UnCheckBorderColor = Color.Black;
    private Color _CheckColor = Color.White;
    private Color _UnCheckColor = Color.Gray;
    private Color _CheckBackGroundColor = H.GetHTMLColor("FF2C97DE");
    private Color _UnCheckBackGroundColor = H.GetHTMLColor("FF353535");
    private int Alpha = 0;
    private System.Windows.Forms.Timer AnimationTimer = new Timer(){Interval=20};

    #endregion
    
    #region Properties

    [Category("Custom Properties"), Description("Gets or set a value indicating whether the control is in the checked state.")]
    public bool Checked
    {
        get { return _Checked; }
        set
        {
            _Checked = value;
            UpdateState();
            Invalidate();
        }
    }

    [Category("Custom Properties")]
    public int Group
    {
        get { return _Group; }
        set
        {
            _Group = value;
            Invalidate();
        }
    }

    [Browsable(false), Category("Custom Properties"), Description("Gets or sets the Radiobutton control border color while checked.")]
    public Color CheckBorderColor
    {
        get { return _CheckBorderColor; }
        set
        {
            _CheckBorderColor = value;
            Invalidate();
        }
    }

    [Browsable(false), Category("Custom Properties"), Description("Gets or sets the Radiobutton control border color while unchecked.")]
    public Color UnCheckBorderColor
    {
        get { return _UnCheckBorderColor; }
        set
        {
            _UnCheckBorderColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the Radiobutton control check symbol color while checked.")]
    public Color CheckColor
    {
        get { return _CheckColor; }
        set
        {
            _CheckColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the Radiobutton control check symbol color while Unchecked.")]
    public Color UnCheckColor
    {
        get { return _UnCheckColor; }
        set
        {
            _UnCheckColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the Radiobutton control check symbol color while checked.")]
    public Color CheckBackGroundColor
    {
        get { return _CheckBackGroundColor; }
        set
        {
            _CheckBackGroundColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the Radiobutton control check symbol color while Unchecked.")]
    public Color UnCheckBackGroundColor
    {
        get { return _UnCheckBackGroundColor; }
        set
        {
            _UnCheckBackGroundColor = value;
            Invalidate();
        }
    }

    #endregion

    #region Constructors

    public SpinRadioButton()
    {
        SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
        DoubleBuffered = true;
        Cursor = Cursors.Hand;
        BackColor = Color.Transparent;
        AnimationTimer.Tick+=AnimationTick;
        ForeColor = H.GetHTMLColor("c5c5c5");
        Font = new Font("Segoe UI", 9, FontStyle.Regular);
        UpdateStyles();
    }

    #endregion

    #region Draw Control

    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics G = e.Graphics;
       G.SmoothingMode = SmoothingMode.AntiAlias;
        G.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

        using (Brush BackBrush = Checked ? new SolidBrush(CheckBackGroundColor) : new SolidBrush(UnCheckBackGroundColor))
        using (Brush CheckMarkBrush = Checked ? new SolidBrush(Color.FromArgb(Alpha, CheckColor)) : new SolidBrush(UnCheckColor))
        using (Font F = new Font("Marlett", 12, FontStyle.Bold))
        {
            G.FillEllipse(BackBrush, new Rectangle(0, 0, 18, 18));
            G.DrawString(Text, Font, new SolidBrush(ForeColor), new Rectangle(21, Convert.ToInt32(0.5), Width, Height - 2), H.SetPosition(StringAlignment.Near));
            G.SmoothingMode = SmoothingMode.None;
            G.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            G.DrawString("b", F, CheckMarkBrush, new Rectangle(Convert.ToInt32(-1.4), Convert.ToInt32(1.5), Width, Height));
        }
          
    }

    #endregion

    #region Events

    public event CheckedChangedEventHandler CheckedChanged;
    public delegate void CheckedChangedEventHandler(object sender);

    private void AnimationTick(object sender, EventArgs e)
    {
        if (Checked)
        {
            if (Alpha < 250)
            {
                Alpha += 25;
                Invalidate();
            }
        }
        else if (Alpha > 0)
        {
            Alpha -= 25;
            Invalidate();
        }
    }

    private void UpdateState()
    {
        if (!IsHandleCreated || !_Checked)
            return;

        foreach (Control C in Parent.Controls)
        {
            if (!ReferenceEquals(C, this) && C is SpinRadioButton && ((SpinRadioButton)C).Group == _Group)
            {
                ((SpinRadioButton)C).Checked = false;
            }
        }
        CheckedChanged?.Invoke(this);
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        _Checked = !Checked;
        UpdateState();
        base.OnMouseDown(e);
        Invalidate();
    }

    protected override void OnCreateControl()
    {
        UpdateState();
        base.OnCreateControl();
    }

    protected override void OnTextChanged(System.EventArgs e)
    {
        Invalidate();
        base.OnTextChanged(e);
    }

    protected override void OnResize(System.EventArgs e)
    {
        base.OnResize(e);
        Height = 21;
        Invalidate();
    }

    protected override void OnHandleCreated(EventArgs e)
    {
        base.OnHandleCreated(e);
        AnimationTimer.Start();
    }

    #endregion

}

#endregion

#region Progress

[DefaultEvent("ValueChanged"), DefaultProperty("Value")]
public class SpinProgressBar : Control
{

    #region Declarations

    private static readonly HelperMethods H = new HelperMethods();
    private int _Maximum = 100;
    private int _Value = 0;
    private bool _ShowProgressLines = true;
    private Color _ProgressColor = H.GetHTMLColor("FF2C97DE");
    private Color _ProgressLinesColor = H.GetHTMLColor("FF2B90D2");
    private Color _BaseColor = H.GetHTMLColor("FF353535");
    private int CurrentValue;
    private int _Minimum = 0;

    #endregion

    #region Constructors

    public SpinProgressBar()
    {
        SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
        DoubleBuffered = true;
        BackColor = Color.Transparent;
        CurrentValue = Convert.ToInt32(Value / Maximum * Width);
        UpdateStyles();

    }

    #endregion

    #region Properties

    [Category("Custom Properties"), Description("Gets or sets the current position of the progressbar.")]
    public int Value
    {
        get
        {
            if (_Value < 0)
            {
                return 0;
            }
            else
            {
                return _Value;
            }
        }
        set
        {
            if (value > Maximum)
            {
                value = Maximum;
            }
            if (value < Minimum)
            {
                value = Minimum;
            }
            _Value = value;
            RenewCurrentValue();
            Invalidate();
            ValueChanged?.Invoke(this);
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the maximum value of the progressbar.")]
    public int Maximum
    {
        get { return _Maximum; }
        set
        {
            if (value < _Value)
            {
                _Value = Value;
            }
            _Maximum = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the minimum value of the progressbar.")]
    public int Minimum
    {
        get { return _Minimum; }
        set
        {
            _Minimum = value;
            if (value > _Value)
            {
                _Value = Value;
            }
            if (value > Maximum)
            {
                Maximum = value;
            }
                Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the whether the progressbar line be shown or not.")]
    public bool ShowProgressLines
    {
        get { return _ShowProgressLines; }
        set
        {
            _ShowProgressLines = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the basecolor of the control.")]
    public Color BaseColor
    {
        get { return _BaseColor; }
        set
        {
            _BaseColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the progress color of the control.")]
    public Color ProgressColor
    {
        get { return _ProgressColor; }
        set
        {
            _ProgressColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the progress lines color of the control.")]
    public Color ProgressLinesColor
    {
        get { return _ProgressLinesColor; }
        set
        {
            _ProgressLinesColor = value;
            Invalidate();
        }
    }

    #endregion

    #region Draw Control

    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics G = e.Graphics;
        Rectangle Rect = new Rectangle(0, 0, Width, Height);
        using (SolidBrush BG = new SolidBrush(BaseColor))
        {
            G.FillRectangle(BG, Rect);
        }
        if (CurrentValue != Minimum)
        {
            using (SolidBrush PS = new SolidBrush(ProgressColor))
            {
                G.FillRectangle(PS, new Rectangle(Rect.X, Rect.Y, CurrentValue - 1, Rect.Height));
            }
            G.SmoothingMode = SmoothingMode.AntiAlias;
            using (Pen PSL = H.PenColor(ProgressLinesColor, 20))
            {
                if (ShowProgressLines)
                {
                    for (int i = 9; i <= Convert.ToInt32((double)((Width - 20) * (((double)Value - (double)Minimum) / ((double)Maximum - (double)Minimum)))); i += 45)
                    {
                        G.DrawLine(PSL, new Point(i, Convert.ToInt32((double) ((((double) Height) / 2.0) - Height))), new Point(i - Height, Convert.ToInt32((double) ((((double) Height) / 2.0) + Height))));
                    }
                }
            }
        }
    }

    #endregion

    #region Events

    public event ValueChangedEventHandler ValueChanged;
    public delegate void ValueChangedEventHandler(object sender);
    public void RenewCurrentValue()
    {
        CurrentValue = (int)Math.Round((Value - (double)Minimum) / ((double)(Maximum) - (double)Minimum) * (double)(Width));
    }

    public void Increment(int value)
    {
        Value += value;
    }

    #endregion

}

[DefaultEvent("ValueChanged"), DefaultProperty("Value")]
public class SpinVerticalProgressBar : Control
{

    #region Declarations

    private static readonly HelperMethods H = new HelperMethods();
    private int _Maximum = 100;
    private int _Value = 0;
    private Color _ProgressColor = H.GetHTMLColor("FF2C97DE");
    private Color _BaseColor = H.GetHTMLColor("FF353535");
    private int CurrentValue;
    private int _Minimum = 0;

    #endregion

    #region Constructors


    public SpinVerticalProgressBar()
    {
        SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
        DoubleBuffered = true;
        BackColor = Color.Transparent;
        RenewCurrentValue();
        UpdateStyles();

    }

    #endregion

    #region Properties

    [Category("Custom Properties"), Description("Gets or sets the current position of the progressbar.")]
    public int Value
    {
        get
        {
            if (_Value < 0)
            {
                return 0;
            }
            else
            {
                return _Value;
            }
        }
        set
        {
            if (value > Maximum)
            {
                value = Maximum;
            }
            _Value = value;
            RenewCurrentValue();
            Invalidate();
            ValueChanged?.Invoke(this);
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the maximum value of the progressbar.")]
    public int Maximum
    {
        get { return _Maximum; }
        set
        {
            if (value < _Value)
            {
                _Value = Value;
            }
            _Maximum = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the minimum value of the progressbar.")]
    public int Minimum
    {
        get { return _Minimum; }
        set
        {
            _Minimum = value;
            if (value > _Value)
            {
                _Value = Value;
            }
            if (value > Maximum)
            {
                Maximum = value;
            }
            Invalidate();
        }
    }
    [Category("Custom Properties"), Description("Gets or sets the basecolor of the control.")]
    public Color BaseColor
    {
        get { return _BaseColor; }
        set
        {
            _BaseColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the progress color of the control.")]
    public Color ProgressColor
    {
        get { return _ProgressColor; }
        set
        {
            _ProgressColor = value;
            Invalidate();
        }
    }

    #endregion

    #region Draw Control

    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics G = e.Graphics;
        Rectangle Rect = new Rectangle(0, 0, Width, Height);
        using (SolidBrush BG = new SolidBrush(BaseColor))
        {
            G.FillRectangle(BG, Rect);
        }
        if (CurrentValue != Minimum)
        {
            using (SolidBrush PS = new SolidBrush(ProgressColor))
            {
                G.FillRectangle(PS, new Rectangle(0, Height - CurrentValue, Width, CurrentValue));
            }
        }
    }

    #endregion

    #region Events

    public event ValueChangedEventHandler ValueChanged;
    public delegate void ValueChangedEventHandler(object sender);
    public void RenewCurrentValue()
    {

        CurrentValue = Convert.ToInt32((double)(((Value - (double) Minimum) / ((double)Maximum - (double)Minimum)) *  Height));
    }

    public void Increment(int value)
    {
        Value += value;
    }

    #endregion

}

#endregion

#region GroupBox

public class SpinGroupBox : ContainerControl
{

    #region Declarations

    private static readonly HelperMethods H = new HelperMethods();
    private Color _HeaderColor = H.GetHTMLColor("FF2D2D2D");
    private Color _HeaderTextColor = H.GetHTMLColor("dadada");
    private Color _BorderColor = H.GetHTMLColor("FF212121");
    private Color _BaseColor = H.GetHTMLColor("FF2D2D2D");

    #endregion

    #region Properties

    [Category("Custom Properties"), Description("Gets or sets the Header color for the control.")]
    public Color HeaderColor
    {
        get { return _HeaderColor; }
        set
        {
            _HeaderColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the text color for the control.")]
    public Color HeaderTextColor
    {
        get { return _HeaderTextColor; }
        set
        {
            _HeaderTextColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the background border color for the control.")]
    public Color BorderColor
    {
        get { return _BorderColor; }
        set
        {
            _BorderColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the background color for the control.")]
    public Color BaseColor
    {
        get { return _BaseColor; }
        set
        {
            _BaseColor = value;
            Invalidate();
        }
    }

    #endregion

    #region Draw Control

    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics G = e.Graphics;
        G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
        Rectangle Rect = new Rectangle(0, 0, Width, Height);
        using (SolidBrush BG = new SolidBrush(BaseColor))
        using (SolidBrush HC = new SolidBrush(HeaderColor))
        using (Pen P = H.PenColor(BorderColor))
        using (SolidBrush HTC = new SolidBrush(HeaderTextColor))
        using (StringFormat SF = new StringFormat { LineAlignment = StringAlignment.Center })
        {
            G.FillRectangle(BG, Rect);
            G.FillRectangle(HC, new Rectangle(0, 0, Width, 50));
            G.DrawLine(P, new Point(0, 50), new Point(Width, 50));
            G.DrawRectangle(P, new Rectangle(0, 0, Width - 1, Height - 1));
            G.DrawString(Text, Font, HTC, new Rectangle(5, 0, Width, 50), SF);
        }
    }

    #endregion

    #region Constructors

    public SpinGroupBox()
    {
        SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
        DoubleBuffered = true;
        Font = new Font("Segoe UI", 10);
        BackColor = Color.Transparent;
        UpdateStyles();
    }

    #endregion

}

#endregion

#region Track

#region Horizontal Track

[DefaultEvent("Scroll"), DefaultProperty("Value")]
public class SpinHorizontalTrack : Control
{

    #region Declarations

    private static readonly HelperMethods H = new HelperMethods();
    protected bool Variable;
    private Rectangle Track;
    private Rectangle TrackSide;
    protected int _Maximum = 100;
    private int _Minimum;
    private int _Value;
    private int CurrentValue;
    private Color _BaseColor = H.GetHTMLColor("FF353535");
    private Color _TrackColor = H.GetHTMLColor("FF2C97DE");
    private Color _BorderColor = H.GetHTMLColor("262626");
    private Color _ValueTextColor = Color.White;

    #endregion

    #region Properties

    [Category("Custom Properties"), Description("Gets or sets the upper limit of the range this TrackBar is working with.")]
    public int Maximum
    {
        get { return _Maximum; }
        set
        {
            _Maximum = value;
            RenewCurrentValue();
            MoveTrack();
            Invalidate();
        }
    }
    
    [Category("Custom Properties"), Description("Gets or sets the lower limit of the range this TrackBar is working with.")]
    public int Minimum
    {
        get { return _Minimum; }
        set
        {
            if (!(value < 0))
            {
                _Minimum = value;
                RenewCurrentValue();
                MoveTrack();
                Invalidate();
            }
        }
    }

    [Category("Custom Properties"), Description("Gets or sets a numeric value that represents the current position of the scroll box on the track bar.")]
    public int Value
    {
        get { return _Value; }
        set
        {
            if (value != _Value)
            {
                _Value = value;
                RenewCurrentValue();
                MoveTrack();
                Invalidate();
                Scroll?.Invoke(this);
            }
        }
    }


    [Category("Custom Properties"), Description("Gets or sets the value text color of the control.")]
    public Color ValueTextColor
    {
        get { return _ValueTextColor; }
        set
        {
            _ValueTextColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the background color of the control.")]
    public Color BaseColor
    {
        get { return _BaseColor; }
        set
        {
            _BaseColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the border color of the control.")]
    public Color BorderColor
    {
        get { return _BorderColor; }
        set
        {
            _BorderColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the track handler color of the control.")]
    public Color TrackColor
    {
        get { return _TrackColor; }
        set
        {
            _TrackColor = value;
            Invalidate();
        }
    }

    #endregion

    #region Constructors

    public SpinHorizontalTrack()
    {
        SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
        DoubleBuffered = true;
        BackColor = Color.Transparent;
        Font = new Font("Arial", 6);
        CurrentValue = Convert.ToInt32(Value / (double) (Maximum) - (2 * Width));
        UpdateStyles();
    }

    #endregion

    #region Events

    public event ScrollEventHandler Scroll;
    public delegate void ScrollEventHandler(object sender);

    protected override void OnMouseMove(MouseEventArgs e)
    {
        if (Variable && e.X > -1 && e.X < Width + 1)
        {
            Value = Minimum + (int)Math.Round((double)(Maximum - Minimum) * (double)e.X / Width);
        }

        base.OnMouseMove(e);
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left && Height > 0)
        {
            RenewCurrentValue();
            if (Width > 0 && Height > 0) Track = new Rectangle(CurrentValue + Convert.ToInt32(0.8), 0, 25, 24);

            Variable = new Rectangle(CurrentValue, 0, 24, Height).Contains(e.Location);
        }
        base.OnMouseDown(e);
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
        Variable = false;
        base.OnMouseUp(e);
    }

    protected override void OnKeyDown(KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Subtract || e.KeyCode == Keys.Down || e.KeyCode == Keys.Left)
        {
            if (Value != 0)
            {
                Value -= 1;

            }

        }
        else if (e.KeyCode == Keys.Add || e.KeyCode == Keys.Up || e.KeyCode == Keys.Right)
        {
            if (Value != Maximum)
            {
                Value += 1;
            }

        }
        base.OnKeyDown(e);
    }

    protected override void OnResize(EventArgs e)
    {
        if (Width > 0 && Height > 0)
        {
            RenewCurrentValue();
            MoveTrack();

        }
        Height = 19;
        Invalidate();
        base.OnResize(e);
    }

    private void MoveTrack()
    {
        if (Height > 0 && Width > 0)
            Track = new Rectangle(CurrentValue, 1, 20, 18);
        TrackSide = new Rectangle(Convert.ToInt32(CurrentValue + 5.8), 6, 20, 18);
    }

    public void RenewCurrentValue()
    {
        CurrentValue = Convert.ToInt32(Math.Round((double)(Value - Minimum) / (double)(Maximum - Minimum) * (Width - 19)));
        Invalidate();
        
    }

    #endregion

    #region Draw Control

    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics G = e.Graphics;

        G.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

        Cursor = Cursors.Hand;

        using (SolidBrush BG = new SolidBrush(BaseColor))
        {
            G.FillRectangle(BG, new Rectangle(0, Convert.ToInt32(5.5), Width, 8));
        }

        using (SolidBrush VC = new SolidBrush(TrackColor))
        using (SolidBrush VTC = new SolidBrush(ValueTextColor))
        {
            if (CurrentValue != 0)
                G.FillRectangle(VC, new Rectangle(0, Convert.ToInt32(5.5), CurrentValue, 8));
                G.FillRectangle(VC, Track);
                G.DrawString(Value.ToString(), Font, VTC, Track, H.SetPosition());
        }
    }

    #endregion

}

#endregion

#region Vertical Track

[DefaultEvent("Scroll"), DefaultProperty("Value")]
public class SpinVerticalTrackBar : Control
{

    #region Declarations

    private static readonly HelperMethods H = new HelperMethods();
    protected bool Variable;
    private Rectangle Track;
    private Rectangle TrackSide;
    protected int _Maximum = 100;
    private int _Minimum;
    private int _Value;
    private int CurrentValue;
    private Color _BaseColor = H.GetHTMLColor("FF353535");
    private Color _TrackColor = H.GetHTMLColor("FF2C97DE");
    private Color _BorderColor = H.GetHTMLColor("262626");
    private Color _ValueTextColor = Color.White;

    #endregion

    #region Properties

    [Category("Custom Properties"), Description("Gets or sets the upper limit of the range this TrackBar is working with.")]
    public int Maximum
    {
        get { return _Maximum; }
        set
        {
            _Maximum = value;
            RenewCurrentValue();
            MoveTrack();
            Invalidate();
        }
    }


    [Category("Custom Properties"), Description("Gets or sets the lower limit of the range this TrackBar is working with.")]
    public int Minimum
    {
        get { return _Minimum; }
        set
        {
            if (!(value < 0))
            {
                _Minimum = value;
                RenewCurrentValue();
                MoveTrack();
                Invalidate();
            }
        }
    }

    [Category("Custom Properties"), Description("Gets or sets a numeric value that represents the current position of the scroll box on the track bar.")]
    public int Value
    {
        get { return _Value; }
        set
        {
            if (value != _Value)
            {
                _Value = value;
                RenewCurrentValue();
                MoveTrack();
                Invalidate();
                Scroll?.Invoke(this);
            }
        }
    }


    [Category("Custom Properties"), Description("Gets or sets the value text color of the control.")]
    public Color ValueTextColor
    {
        get { return _ValueTextColor; }
        set
        {
            _ValueTextColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the background color of the control.")]
    public Color BaseColor
    {
        get { return _BaseColor; }
        set
        {
            _BaseColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the border color of the control.")]
    public Color BorderColor
    {
        get { return _BorderColor; }
        set
        {
            _BorderColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the track handler color of the control.")]
    public Color TrackColor
    {
        get { return _TrackColor; }
        set
        {
            _TrackColor = value;
            Invalidate();
        }
    }

    #endregion

    #region Constructors

    public SpinVerticalTrackBar()
    {
        SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
        DoubleBuffered = true;
        BackColor = Color.Transparent;
        Font = new Font("Arial", 6);
        CurrentValue = Convert.ToInt32((double)((((double)Value) / ((double)Maximum)) - (Height)));
        UpdateStyles();
    }

    #endregion

    #region Events

    public event ScrollEventHandler Scroll;
    public delegate void ScrollEventHandler(object sender);

    protected override void OnMouseMove(MouseEventArgs e)
    {
        if (Variable && e.Y > -1 && e.Y < Height + 1)
        {
            Value = Minimum + (int)Math.Round((double)(Maximum - Minimum) * (((double) e.Y) / Height));
        }

        base.OnMouseMove(e);
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left && Height > 0)
        {
            RenewCurrentValue();
            if (Width > 0 && Height > 0) Track = new Rectangle(CurrentValue + Convert.ToInt32(0.8), 0, 25, 24);
            Variable = new Rectangle(0, CurrentValue, 24, Height).Contains(e.Location);
        }
        base.OnMouseDown(e);
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
        Variable = false;
        base.OnMouseUp(e);
    }

    protected override void OnKeyDown(KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Subtract || e.KeyCode == Keys.Down || e.KeyCode == Keys.Left)
        {
            if (Value != 0)
            {
                Value -= 1;

            }

        }
        else if (e.KeyCode == Keys.Add || e.KeyCode == Keys.Up || e.KeyCode == Keys.Right)
        {
            if (Value != Maximum)
            {
                Value += 1;
            }

        }
        base.OnKeyDown(e);
    }

    protected override void OnResize(EventArgs e)
    {
        if (Width > 0 && Height > 0)
        {
            RenewCurrentValue();
            MoveTrack();

        }
        Width = 26;
        Invalidate();
        base.OnResize(e);
    }

    private void MoveTrack()
    {
        if (Height > 0 && Width > 0)
        Track = new Rectangle(Convert.ToInt32(2.5), CurrentValue , 20, 18);
        TrackSide = new Rectangle(4, CurrentValue, 20, 18);
    }

    public void RenewCurrentValue()
    {
        CurrentValue = Convert.ToInt32(Math.Round((double)(Value - Minimum) / (double)(Maximum - Minimum) * (Height - 18)));
        Invalidate();

    }

    #endregion

    #region Draw Control

    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics G = e.Graphics;

        G.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

        Cursor = Cursors.Hand;
        using (Brush BG = new SolidBrush(BaseColor))
        {
            G.FillRectangle(BG, new Rectangle(7, 0, 8, Height));
        }

        using (Brush VC = new SolidBrush(TrackColor))
        using (Brush VTC = new SolidBrush(ValueTextColor))
        {
            if (CurrentValue != 0)
            {
                G.FillRectangle(VC,new Rectangle(7, 0, 8, CurrentValue));
            }
            G.FillRectangle(VC, Track);
            G.DrawString(Value.ToString(), Font, VTC, Track, H.SetPosition());
        }
    }

    #endregion

}

#endregion

#endregion

#region Silder

[DefaultEvent("Scroll"), DefaultProperty("Value")]
public class SpinSilder : Control
{

    #region Declarations

    private static readonly HelperMethods H = new HelperMethods();
    protected bool Variable;
    private Rectangle Silder;
    private Rectangle SilderSide;
    protected int _Maximum = 100;
    private int _Minimum;
    private int _Value;
    private int CurrentValue;
    private Color _BaseColor = H.GetHTMLColor("FF353535");
    private Color _SliderColor = H.GetHTMLColor("FF2C97DE");
    private Color _BorderColor = H.GetHTMLColor("262626");
    private Color _ValueTextColor = Color.White;

    #endregion

    #region Properties

    [Category("Custom Properties"), Description("Gets or sets the upper limit of the range this TrackBar is working with.")]
    public int Maximum
    {
        get { return _Maximum; }
        set
        {
            _Maximum = value;
            RenewCurrentValue();
            MoveTrack();
            Invalidate();
        }
    }


    [Category("Custom Properties"), Description("Gets or sets the lower limit of the range this TrackBar is working with.")]
    public int Minimum
    {
        get { return _Minimum; }
        set
        {
            if (!(value < 0))
            {
                _Minimum = value;
                RenewCurrentValue();
                MoveTrack();
                Invalidate();
            }
        }
    }

    [Category("Custom Properties"), Description("Gets or sets a numeric value that represents the current position of the scroll box on the track bar.")]
    public int Value
    {
        get { return _Value; }
        set
        {
            if (value != _Value)
            {
                _Value = value;
                RenewCurrentValue();
                MoveTrack();
                Invalidate();
                Scroll?.Invoke(this);
            }
        }
    }


    [Category("Custom Properties"), Description("Gets or sets the value text color of the control.")]
    public Color ValueTextColor
    {
        get { return _ValueTextColor; }
        set
        {
            _ValueTextColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the background color of the control.")]
    public Color BaseColor
    {
        get { return _BaseColor; }
        set
        {
            _BaseColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the border color of the control.")]
    public Color BorderColor
    {
        get { return _BorderColor; }
        set
        {
            _BorderColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the track handler color of the control.")]
    public Color SliderColor
    {
        get { return _SliderColor; }
        set
        {
            _SliderColor = value;
            Invalidate();
        }
    }

    #endregion

    #region Constructors

    public SpinSilder()
    {
        SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
        DoubleBuffered = true;
        BackColor = Color.Transparent;
        Font = new Font("Arial", 6);
        CurrentValue = Convert.ToInt32((double)((Value / Maximum) - (2 * Width)));
        UpdateStyles();
    }

    #endregion

    #region Events

    public event ScrollEventHandler Scroll;
    public delegate void ScrollEventHandler(object sender);

    protected override void OnMouseMove(MouseEventArgs e)
    {
        if (Variable && e.X > -1 && e.X < Width + 1)
        {
            Value = Minimum + (int)Math.Round((double)(Maximum - Minimum) * (double)e.X / Width);
        }

        base.OnMouseMove(e);
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left && Height > 0)
        {
            RenewCurrentValue();
            if (Width > 0 && Height > 0) Silder = new Rectangle(CurrentValue + Convert.ToInt32(0.8), 0, 25, 24);

            Variable = new Rectangle(CurrentValue, 0, 24, Height).Contains(e.Location);
        }
        base.OnMouseDown(e);
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
        Variable = false;
        base.OnMouseUp(e);
    }

    protected override void OnKeyDown(KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Subtract || e.KeyCode == Keys.Down || e.KeyCode == Keys.Left)
        {
            if (Value != 0)
            {
                Value -= 1;

            }

        }
        else if (e.KeyCode == Keys.Add || e.KeyCode == Keys.Up || e.KeyCode == Keys.Right)
        {
            if (Value != Maximum)
            {
                Value += 1;
            }

        }
        base.OnKeyDown(e);
    }

    protected override void OnResize(EventArgs e)
    {
        if (Width > 0 && Height > 0)
        {
            RenewCurrentValue();
            MoveTrack();

        }
        Height = 19;
        Invalidate();
        base.OnResize(e);
    }

    private void MoveTrack()
    {
        if (Height > 0 && Width > 0)
            Silder = new Rectangle(CurrentValue, 1, 20, 18);
            SilderSide = new Rectangle(Convert.ToInt32(CurrentValue + 5.8), 6, 20, 18);
    }

    public void RenewCurrentValue()
    {
        CurrentValue = Convert.ToInt32(Math.Round((double)(Value - Minimum) / (double)(Maximum - Minimum) * (Width - 19)));
        Invalidate();

    }

    #endregion

    #region Draw Control

    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics G = e.Graphics;
        G.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

        Cursor = Cursors.Hand;

        using (SolidBrush BG = new SolidBrush(BaseColor))
        {
            G.FillRectangle(BG, new Rectangle(0, 0, Width, Height));
        }

        using (SolidBrush VC = new SolidBrush(SliderColor))
        using (SolidBrush VTC = new SolidBrush(ValueTextColor))
        using (Pen P = H.PenColor(BorderColor))
        {
            G.FillRectangle(VC, Silder);
            G.DrawString(Value.ToString(), Font, VTC, Silder, H.SetPosition());
            G.DrawRectangle(P, new Rectangle(0, 0, Width - 1, Height - 1));
        }
         
    }

    #endregion

}

#endregion

#region ComboBox

public class SpinComboBox : ComboBox
{

    #region Declarations

    private static readonly HelperMethods H = new HelperMethods();
    private int _StartIndex = 0;
    private Color _BaseColor = H.GetHTMLColor("262626");
    private Color _BorderColor = H.GetHTMLColor("444444");
    private Color _ArrowColor = H.GetHTMLColor("444444");
    private Color _TextColor = H.GetHTMLColor("C5C5C5");
    private Color _SelectedItemColor = Color.White;
    private Color _SelectedItemBackColor = H.GetHTMLColor("FF2C97DE");

    #endregion

    #region Constructors


    public SpinComboBox()
    {
        SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
        BackColor = Color.Transparent;
        Font = new Font("Arial", 12);
        DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
        DoubleBuffered = true;
        StartIndex = 0;
        CausesValidation = false;
        AllowDrop = true;
        DropDownStyle = ComboBoxStyle.DropDownList;
        UpdateStyles();
    }

    #endregion

    #region Properties

    [Category("Custom Properties"), Description("Gets or sets the index specifying the currently selected item.")]
    private int StartIndex
    {
        get { return _StartIndex; }
        set
        {
            _StartIndex = value;
            try
            {
                base.SelectedIndex = value;
            }
            catch
            {
            }
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the background color of the control.")]
    public Color BaseColor
    {
        get { return _BaseColor; }
        set
        {
            _BaseColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the border color of the control.")]
    public Color BorderColor
    {
        get { return _BorderColor; }
        set
        {
            _BorderColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the arrow handler color of the control.")]
    public Color ArrowColor
    {
        get { return _ArrowColor; }
        set
        {
            _ArrowColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the text color of the control.")]
    public Color TextColor
    {
        get { return _TextColor; }
        set
        {
            _TextColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the selected text color of the control.")]
    public Color SelectedItemColor
    {
        get { return _SelectedItemColor; }
        set
        {
            _SelectedItemColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the background color of the selected item of the control.")]
    public Color SelectedItemBackColor
    {
        get { return _SelectedItemBackColor; }
        set
        {
            _SelectedItemBackColor = value;
            Invalidate();
        }
    }

    #endregion

    #region Draw Control

    protected override void OnDrawItem(DrawItemEventArgs e)
    {
        Graphics G = e.Graphics;
        G.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

        try
        {
            using (SolidBrush BG = new SolidBrush((e.State & DrawItemState.Selected) == DrawItemState.Selected ? SelectedItemBackColor : BaseColor))
            using (SolidBrush TC = new SolidBrush((e.State & DrawItemState.Selected) == DrawItemState.Selected ? SelectedItemColor : TextColor))
            {
                G.FillRectangle(BG, e.Bounds);
                G.DrawString(GetItemText(Items[e.Index]), Font, TC, e.Bounds);
            }
            
        }
        catch
        {
        }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics G = e.Graphics;
        Rectangle Rect = new Rectangle(0, 0, Width - 1, Height - 1);
        G.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

        H.FillStrokedRectangle(G, Rect, BaseColor, BorderColor, 1);

        G.SmoothingMode = SmoothingMode.AntiAlias;

        H.DrawTriangle(G, ArrowColor, Convert.ToInt32(1.5), new Point(Width - 20, 12), new Point(Width - 16, 16), new Point(Width - 16, 16), new Point(Width - 12, 12), new Point(Width - 16, 17), new Point(Width - 16, 16));
        G.SmoothingMode = SmoothingMode.None;
        using (SolidBrush TC = new SolidBrush(TextColor))
        {
            G.DrawString(Text, Font, TC, new Rectangle(7, 1, Width - 1, Height - 1), H.SetPosition(StringAlignment.Near));
        }

    }

    #endregion

    #region Events
    
    protected override void OnLeave(EventArgs e)
    {
        base.OnLeave(e);
        SendKeys.Send("{TAB}");
        Invalidate();
    }

    #endregion

}

#endregion

#region Toggle

[DefaultEvent("Toggled"), DefaultProperty("Toggle")]
public class SpinToggle : Control
{

    #region Declarations

    private static readonly HelperMethods H = new HelperMethods();
    private bool _Toggled;
    protected HelperMethods.MouseMode State = HelperMethods.MouseMode.Normal;
    private Color _UnCheckedColor = H.GetHTMLColor("FF353535");
    private Color _CheckedColor = H.GetHTMLColor("FF2C97DE");
    private Color _CheckedBallColor = Color.White;
    private Color _UnCheckedBallColor = Color.White;
    private int CircleLocation = 0;
    private Timer T = new Timer() { Enabled = true, Interval = 1 };

    #endregion

    #region Properties
    
    [Category("Custom Properties"), Description("Gets or set a value indicating whether the control is in the checked state.")]
    public bool Toggle
    {
        get { return _Toggled; }
        set
        {
            _Toggled = value;
            Toggled?.Invoke(this);
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the switch control color while unchecked")]
    public Color UnCheckedColor
    {
        get { return _UnCheckedColor; }
        set
        {
            _UnCheckedColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the switch control color while checked")]
    public Color CheckedColor
    {
        get { return _CheckedColor; }
        set
        {
            _CheckedColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the switch control ball color while checked")]
    public Color CheckedBallColor
    {
        get { return _CheckedBallColor; }
        set
        {
            _CheckedBallColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the switch control ball color while unchecked")]
    public Color UnCheckedBallColor
    {
        get { return _UnCheckedBallColor; }
        set
        {
            _UnCheckedBallColor = value;
            Invalidate();
        }
    }

    #endregion

    #region Constructors

    public SpinToggle()
    {
        SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
        DoubleBuffered = true;
        Cursor = Cursors.Hand;
        BackColor = Color.Transparent;
        T.Tick += T_Tick;
        UpdateStyles();
    }

    #endregion

    #region Events

    public event ToggledEventHandler Toggled;
    public delegate void ToggledEventHandler(object sender);

    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        Size = new Size(37, 21);
        Invalidate();
    }

    protected override void OnClick(EventArgs e)
    {
        _Toggled = !Toggle;
        base.OnClick(e);
        Invalidate();
    }

    protected override void OnTextChanged(System.EventArgs e)
    {
        Invalidate();
        base.OnTextChanged(e);
    }

    protected override void OnMouseHover(EventArgs e)
    {
        base.OnMouseHover(e);
        State = HelperMethods.MouseMode.Hovered;
        Invalidate();
    }

    protected override void OnMouseLeave(EventArgs e)
    {
        base.OnMouseLeave(e);
        State = HelperMethods.MouseMode.Normal;
        Invalidate();
    }

    private void T_Tick(object sender, EventArgs e)
    {
        if (Toggle)
        {
            if (CircleLocation < 100)
            {
                CircleLocation += 5;
                Invalidate(false);
            }
        }
        else
        {
            if (CircleLocation > 0)
            {
                CircleLocation -= 5;
                Invalidate(false);
            }
        }
    }

    #endregion

    #region Draw Control

    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics G = e.Graphics;
        G.SmoothingMode = SmoothingMode.AntiAlias;
        Rectangle Rect = new Rectangle(0, 0, 36, 20);
        using (SolidBrush BG = new SolidBrush(Toggle ? CheckedColor : UnCheckedColor))
        using (SolidBrush Cir = new SolidBrush(CheckedBallColor))
        {
            H.FillRoundedPath(e.Graphics, BG, Rect, 20);
            G.FillEllipse(Cir, new Rectangle((int)Math.Round((double)((Rect.X + 2.6) + Convert.ToInt32((double)(Rect.Width * (((double)CircleLocation) / 240.0))))), 2, 16, 16));
        }
    }

    #endregion

}

#endregion

#region Switch

[DefaultEvent("CheckedChanged"), DefaultProperty("Switched")]
public class SpinSwitch : Control
{

    #region Declarations

    private static readonly HelperMethods H = new HelperMethods();
    private bool _Switch = false;
    private Color _ForeColor = Color.Gray;
    private Color _UnCheckedColor = H.GetHTMLColor("FF353535");
    private Color _CheckedColor = H.GetHTMLColor("FF2C97DE");
    private Color _CheckedSquareColor = H.GetHTMLColor("FF353535");
    private Color _UnCheckedSquareColor = H.GetHTMLColor("FF2C97DE");
    private Color _StateTextColor = Color.WhiteSmoke;
    private Timer T = new Timer() { Enabled = true,Interval = 1 };
    private int CircleLocation = 0;

    #endregion

    #region Properties

    public bool Switched
    {
        get { return _Switch; }
        set
        {
            _Switch = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the switch control color while unchecked")]
    public Color UnCheckedColor
    {
        get { return _UnCheckedColor; }
        set
        {
            _UnCheckedColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the switch control color while checked")]
    public Color CheckedColor
    {
        get { return _CheckedColor; }
        set
        {
            _CheckedColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the switch control ball color while checked")]
    public Color CheckedSquareColor
    {
        get { return _CheckedSquareColor; }
        set
        {
            _CheckedSquareColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the switch control ball color while unchecked")]
    public Color UnCheckedSquareColor
    {
        get { return _UnCheckedSquareColor; }
        set
        {
            _UnCheckedSquareColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the switch state text color.")]
    public Color StateTextColor
    {
        get { return _StateTextColor; }
        set
        {
            _StateTextColor = value;
            Invalidate();
        }
    }

    #endregion

    #region Constructors

    public SpinSwitch()
    {
        SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
        DoubleBuffered = true;
        BackColor = Color.Transparent;
        Cursor = Cursors.Hand;
        Size = new Size(70, 28);
        Font = new Font("Segoe UI", 12);
        T.Tick += T_Tick;
    }

    #endregion

    #region Draw Control
    
    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics G = e.Graphics;
        G.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

        Rectangle Rect = new Rectangle(0, 0, 70, 27);

        using (SolidBrush BG = new SolidBrush(Switched ? CheckedColor : UnCheckedColor))
        using (SolidBrush Cir = new SolidBrush(Switched ? CheckedSquareColor : UnCheckedSquareColor))
        {
            G.FillRectangle(BG, Rect);
            G.FillRectangle(Cir, new RectangleF((float) ((Rect.X + 2.5) + Convert.ToInt32((double) (Rect.Width * (((double) CircleLocation) / 180.0)))), 1.5f, 25.5f, 23f));
        }
        using (SolidBrush B = new SolidBrush(StateTextColor))
        using (StringFormat SF = new StringFormat { LineAlignment = StringAlignment.Center })
        {
            if (Switched)
            {
                G.DrawString("ON", Font, B, new PointF(Width - 64, 14), SF);
            }
            else
            {
                G.DrawString("OFF", Font, B, new PointF(32, 14),SF);
            }
        }
    }

    #endregion

    #region Events

    public event CheckedChangedEventHandler CheckedChanged;
    public delegate void CheckedChangedEventHandler(object sender);
    
    protected override void OnClick(EventArgs e)
    {
        _Switch = !_Switch;
        CheckedChanged?.Invoke(this);
        base.OnClick(e);
        Invalidate();
    }

    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        Size = new Size(70, 28);
    }
    private void T_Tick(object sender, EventArgs e)
    {
        if (Switched)
        {
            if (CircleLocation < 100)
            {
                CircleLocation += 5;
                Invalidate(false);
            }
        }
        else
        {
            if (CircleLocation > 0)
            {
                CircleLocation -= 5;
                Invalidate(false);
            }
        }
    }
    #endregion

}

#endregion

#region Link Label

class SpinLinkLabel : LinkLabel
{

    #region Declarations

    private static readonly HelperMethods H = new HelperMethods();

#endregion

    #region Constructors

    public SpinLinkLabel()
    {
        Font = new Font("Segoe UI", 9, FontStyle.Regular);
        BackColor = Color.Transparent;
        LinkColor = H.GetHTMLColor("C5C5C5");
        ActiveLinkColor = Color.White;
        VisitedLinkColor = H.GetHTMLColor("FF2C97DE");
        LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
    }


    #endregion

}

#endregion

#region Label

[DefaultEvent("TextChanged")]
public class SpinLabel : Control
{

    #region Declarations

    private static readonly HelperMethods H = new HelperMethods();

    #endregion

    #region Draw Cotnrol

    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics G = e.Graphics;
        G.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
        using (SolidBrush B = new SolidBrush(ForeColor))
        {
            G.DrawString(Text, Font, B, ClientRectangle);
        }
    }

    #endregion

    #region Constructors

    public SpinLabel()
    {
        SetStyle(ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
        DoubleBuffered = true;
        BackColor = Color.Transparent;
        ForeColor = H.GetHTMLColor("C5C5C5");
        Font = new Font("Segoe UI", 10, FontStyle.Regular);
        UpdateStyles();
    }

    #endregion

    #region Events

    protected override void OnResize(EventArgs e)
    {
        Height = Font.Height + 1;
    }

    protected override void OnTextChanged(EventArgs e)
    {
        base.OnTextChanged(e);
        Invalidate();
    }

    #endregion

}

#endregion

#region Seperator

public class SpinSeperator : Control
{

    #region Declarations

    private static readonly HelperMethods H = new HelperMethods();
    private Style _SepStyle = Style.Horizental;
    private Color _SeperatorColor = H.GetHTMLColor("FF353535");
    #endregion

    #region Enumerators

    public enum Style
    {
        Horizental,
        Vertiacal
    }

    #endregion

    #region Properties

    [Category("Custom Properties"), Description("Gets or sets the style for the control.")]
    public Style SepStyle
    {
        get { return _SepStyle; }
        set
        {
            _SepStyle = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the color for the control.")]
    public Color SeperatorColor
    {
        get { return _SeperatorColor; }
        set
        {
            _SeperatorColor = value;
            Invalidate();
        }
    }

    #endregion

    #region Constructors

    public SpinSeperator()
    {
        SetStyle(ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
        DoubleBuffered = true;
        BackColor = Color.Transparent;
        UpdateStyles();
    }

    #endregion

    #region Draw Control

    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics G = e.Graphics;
        switch (SepStyle)
        {
            case Style.Horizental:
                using (Pen P = new Pen(SeperatorColor))
                {
                    G.DrawLine(P, 0, 1, Width, 1);
                }
                break;
            case Style.Vertiacal:
                using (Pen P = new Pen(SeperatorColor))
                {
                    G.DrawLine(P, 1, 0, 1, Height);
                }
                break;
        }

    }

    #endregion

    #region Events

    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        if (SepStyle == Style.Horizental)
        {
            Height = 4;
        }
        else
        {
            Width = 4;
        }
    }

    #endregion

}

#endregion

#region Panel

public class SpinPanel : ContainerControl
{

    #region Declarations

    private static readonly HelperMethods H = new HelperMethods();
    private Color _BaseColor = H.GetHTMLColor("FF2D2D2D");
    private Color _BorderColor = H.GetHTMLColor("FF212121");

    #endregion

    #region Constructors

    public SpinPanel()
    {
        SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
        DoubleBuffered = true;
        BackColor = Color.Transparent;
        UpdateStyles();
    }

    #endregion

    #region Properties

    [Category("Custom Properties"), Description("Gets or sets the background color for the control.")]
    public Color BaseColor
    {
        get { return _BaseColor; }
        set
        {
            _BaseColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the border color for the control.")]
    public Color BorderColor
    {
        get { return _BorderColor; }
        set
        {
            _BorderColor = value;
            Invalidate();
        }
    }

    #endregion

    #region Draw Control

    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics G = e.Graphics;
        Rectangle Rect = new Rectangle(0, 0, Width - 1, Height - 1);
        H.FillStrokedRectangle(G, Rect, BaseColor, BorderColor);
    }

    #endregion

}

#endregion

#region SpecifiedPanel

public class SpinSpecifiedPanel : ContainerControl
{

    #region Declarations

    private static readonly HelperMethods H = new HelperMethods();
    private Color _LowerPartColor = H.GetHTMLColor("FF2D2D2D");
    private Color _BorderColor = H.GetHTMLColor("FF212121");
    private Color _HeaderPartColor = H.GetHTMLColor("FF2C97DE");
    private int _RoundRadius = 0;

    #endregion

    #region Constructors

    public SpinSpecifiedPanel()
    {
        SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
        DoubleBuffered = true;
        BackColor = Color.Transparent;
        UpdateStyles();
    }

    #endregion

    #region Properties

    [Category("Custom Properties"), Description("Gets or sets the lower color for the control.")]
    public Color LowerPartColor
    {
        get { return _LowerPartColor; }
        set
        {
            _LowerPartColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the header color for the control.")]
    public Color HeaderPartColor
    {
        get { return _HeaderPartColor; }
        set
        {
            _HeaderPartColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the border color for the control.")]
    public Color BorderColor
    {
        get { return _BorderColor; }
        set
        {
            _BorderColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets a value indicating whether the control can Rounded in corners.")]
    public int RoundRadius
    {
        get { return _RoundRadius; }
        set
        {
            _RoundRadius = value;

            Invalidate();
        }
    }

    #endregion

    #region Draw Control

    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics G = e.Graphics;
        Rectangle HeaderRect = new Rectangle(0, 0, Width - 1, Convert.ToInt32(Height / 2) + 1);
        Rectangle LowerRect = new Rectangle(0, Convert.ToInt32(Height / 2) - 1, Width - 1, Height - Convert.ToInt32(Height / 2));
        Rectangle MainRect = new Rectangle(0, 0, Width - 1, Height - 1);

        GraphicsPath GPH = new GraphicsPath();
        GraphicsPath GPL = new GraphicsPath();

        GraphicsPath GPR = new GraphicsPath { FillMode = FillMode.Winding };

        if (RoundRadius > 0)
        {
            GPH = H.RoundRec(HeaderRect, RoundRadius, true, true, false, false);
            GPL = H.RoundRec(LowerRect, RoundRadius, false, false, true, true);
            GPR = H.RoundRec(MainRect, RoundRadius);
            GPH.CloseFigure();
            GPL.CloseFigure();
            GPR.CloseFigure();
        }
        else
        {
            GPH.AddRectangle(HeaderRect);
            GPL.AddRectangle(LowerRect);
            GPR.AddRectangle(MainRect);
            GPH.CloseFigure();
            GPL.CloseFigure();
            GPR.CloseFigure();
        }
        if (RoundRadius > 1)
        {
            G.SmoothingMode = SmoothingMode.AntiAlias;
        }
        using (SolidBrush Header = new SolidBrush(HeaderPartColor))
        using (SolidBrush Lower = new SolidBrush(LowerPartColor))
        using (Pen P = new Pen(BorderColor))
        {
            G.FillPath(Header, GPH);
            G.FillPath(Lower, GPL);
            G.DrawPath(P, GPR);
        }
       
        GPH.Dispose();
        GPL.Dispose();
        GPR.Dispose();
    }

    #endregion

}

#endregion

#region ListBox

public class SpinListBox : Control
{
    
    #region Declarations

    private static readonly HelperMethods H = new HelperMethods();
    private List<string> _Items = new List<string>();
    private readonly List<string> _SelectedItems = new List<string>();
    private bool _MultiSelect = true;
    private int _ItemHeight = 25;
    private Color _BaseColor = H.GetHTMLColor("262626");
    private SpinVerticalScrollBar SVS = new SpinVerticalScrollBar();
    private int _SelectedIndex;
    private string _SelectedItem;
    private Color _BorderColor = H.GetHTMLColor("444444");
    private Color _UnSelectedItemesColor = Color.Gray;
    private Color _SelectedItemesColor = H.GetHTMLColor("262626");
    private Color _SelectedItemesBackColor = H.GetHTMLColor("FF2C97DE");
    private bool _ShowScrollBar = false;

    #endregion

    #region Properties

    [TypeConverter(typeof(CollectionConverter)), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Category("Custom Properties"), Description("Gets the items of the Spin ListBox.")]
    public string[] Items
    {
        get { return _Items.ToArray(); }
        set
        {
            _Items = new List<string>(value);
            InvalidateScroll();
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets a collection containing the currently selected items in the Spin ListBox.")]
    public string[] SelectedItems
    {
        get { return _SelectedItems.ToArray(); }
    }

    [Category("Custom Properties"), Description("Gets or sets the height of an item in the Spin ListBox.")]
    public int ItemHeight
    {
        get { return _ItemHeight; }
        set
        {
            _ItemHeight = value;
            Invalidate();
        }
    }

    [Browsable(false), Category("Custom Properties"), Description("Gets or sets the currently selected item in the Spin ListBox.")]
    public string SelectedItem
    {
        get { return _SelectedItem; }
        set
        {
            _SelectedItem = value;
            Invalidate();
        }
    }

    [Browsable(false), Category("Custom Properties"), Description("Gets or sets the zero-based index of the currently selected item in a Spin ListBox.")]
    public int SelectedIndex
    {
        get { return _SelectedIndex; }
        set
        {
            _SelectedIndex = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets a value indicating whether the Spin ListBox supports multiple rows.")]
    public bool MultiSelect
    {
        get { return _MultiSelect; }
        set
        {
            _MultiSelect = value;

            if (_SelectedItems.Count > 1)
                _SelectedItems.RemoveRange(1, _SelectedItems.Count - 1);

            Invalidate();
        }
    }

    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public int Count
    {
        get { return _Items.Count; }
    }

    [Category("Custom Properties"), Description("Gets or sets the background color of the control.")]
    public Color BaseColor
    {
        get { return _BaseColor; }
        set
        {
            _BaseColor = value;
            SVS.BackColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the border color of the control.")]
    public Color BorderColor
    {
        get { return _BorderColor; }
        set
        {
            _BorderColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the un-selected itemes color of the control.")]
    public Color UnSelectedItemesColor
    {
        get { return _UnSelectedItemesColor; }
        set
        {
            _UnSelectedItemesColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the selected itemes color of the control.")]
    public Color SelectedItemesColor
    {
        get { return _SelectedItemesColor; }
        set
        {
            _SelectedItemesColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the selected itemes background color of the control.")]
    public Color SelectedItemesBackColor
    {
        get { return _SelectedItemesBackColor; }
        set
        {
            _SelectedItemesBackColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets a value indicating whether the vertical scroll bar is shown or not.")]
    public bool ShowScrollBar
    {
        get { return _ShowScrollBar; }
        set
        {
            if (value)
            {
                if (!Controls.Contains(SVS))
                {
                    Controls.Add(SVS);
                }
            }
            else
            {
                if (Controls.Contains(SVS))
                {
                    Controls.Remove(SVS);
                }
            }
            _ShowScrollBar = value;
            Invalidate();
        }
    }

    #endregion

    #region Events

    public void AddItem(string newItem)
    {
        _Items.Add(newItem);
        Invalidate();
        InvalidateScroll();
    }

    public void AddItems(string[] newItems)
    {
        _Items.AddRange(newItems);
        Invalidate();
        InvalidateScroll();
    }

    public void RemoveItemAt(int index)
    {
        _Items.RemoveAt(index);
        Invalidate();
        InvalidateScroll();
    }

    public void RemoveItem(string item)
    {
        _Items.Remove(item);
        Invalidate();
        InvalidateScroll();
    }

    public int IndexOf(string value)
    {
        return _Items.IndexOf(value);
    }
    public bool Contains(object item)
    {
        return _Items.Contains(item.ToString());
    }

    public void RemoveItems(string[] itemsToRemove)
    {
        foreach (string item in itemsToRemove)
        {
            _Items.Remove(item);
        }
        Invalidate();
        InvalidateScroll();
    }

    public void Clear()
    {
        for (int i = _Items.Count - 1; i >= 0; i += -1)
        {
            _Items.RemoveAt(i);
        }
    }

    protected override void OnSizeChanged(EventArgs e)
    {
        InvalidateScroll();
        InvalidateLayout();
        base.OnSizeChanged(e);
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        Focus();
        if (e.Button == MouseButtons.Left)
        {
            int offset = Convert.ToInt32(SVS.Value * (SVS.Maximum + (Height - (ItemHeight))));
            int index = (e.Y + offset) / ItemHeight;
            if (index > Items.Length - 1)
                index = -1;
            if (index != -1)
            {
                if (ModifierKeys == Keys.Control && MultiSelect)
                {
                    if (_SelectedItems.Contains(_Items[index]))
                    {
                        _SelectedItems.Remove(_Items[index]);
                    }
                    else
                    {
                        _SelectedItems.Add(_Items[index]);
                    }
                }
                else
                {
                    _SelectedItems.Clear();
                    _SelectedItems.Add(_Items[index]);
                    SelectedIndex = index;
                    SelectedItem = _Items[index];
                }
            }
            Invalidate();
        }
        base.OnMouseDown(e);
    }

    private void HandleScroll(object sender)
    {
        Invalidate();
    }

    private void InvalidateScroll()
    {
        if (Convert.ToInt32(Math.Round(((double)(Items.Length) * ItemHeight) / 1)) < Convert.ToDouble((((Items.Length) * ItemHeight) / 1)))
        {
            SVS.Maximum = Convert.ToInt32(Math.Ceiling(((double)(Items.Length) * ItemHeight) / 1));
        }
        else if (Convert.ToInt32(Math.Round(((double)(Items.Length) * ItemHeight) / 1)) == 0)
        {
            SVS.Maximum = 1;
        }
        else
        {
            SVS.Maximum = Convert.ToInt32(Math.Round(((double)(Items.Length) * ItemHeight) / 1));
        }
        Invalidate();
    }
    private void VS_MouseDown(object sender, MouseEventArgs e)
    {
        Focus();
    }
    private void InvalidateLayout()
    {
        SVS.Location = new Point(Width - SVS.Width - 1, 1);
        SVS.Size = new Size(18, Height - 3);
        Invalidate();
    }
    protected override void OnMouseWheel(MouseEventArgs e)
    {
        int Move = -((e.Delta * SystemInformation.MouseWheelScrollLines / 120) * (2 / 2));
        int Value = Math.Max(Math.Min(SVS.Value + Move, SVS.Maximum), SVS.Minimum);
        SVS.Value = Value;
        base.OnMouseWheel(e);
    }

    #endregion

    #region Constructors

    public SpinListBox()
    {
        SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
        DoubleBuffered = true;
        Font = new Font("Segoe UI", 8, FontStyle.Regular);
        BackColor = Color.Transparent;
        Size = new Size(130, 100);
        SVS.Scroll += HandleScroll;
        SVS.MouseDown += VS_MouseDown;
        SVS.BackColor = BaseColor;
        SVS.SmallChange = ItemHeight;
        SVS.LargeChange = ItemHeight * 2;
    }

    #endregion

    #region Draw Control

    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics G = e.Graphics;
        G.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
        Rectangle mainRect = new Rectangle(0, 0, Width - 1, Height - 1);

        using (SolidBrush BG = new SolidBrush(BaseColor))
        {
            G.FillRectangle(BG, mainRect);
        }

        int offset = Convert.ToInt32(SVS.Value * (SVS.Maximum + (Height - (ItemHeight))));
        int startIndex = 0;
        if (offset == 0)
            startIndex = 0;
        else
            startIndex = Convert.ToInt32(offset / ItemHeight / SVS.Maximum);
        using (SolidBrush BG = new SolidBrush(BaseColor))
        using (SolidBrush USIC = new SolidBrush(UnSelectedItemesColor))
        using (SolidBrush SIC = new SolidBrush(SelectedItemesColor))
        using (SolidBrush SIBC = new SolidBrush(SelectedItemesBackColor))
        {
        for (int i = startIndex; i <= _Items.Count - 1; i++)
        {
            string currentItem = Items[i];
            int Y = ((i * ItemHeight) + 1 - offset) + Convert.ToInt32((ItemHeight / 2) - 8);

            G.FillRectangle(BG, new Rectangle(0, (i * ItemHeight) + 1 - offset, Width - 19, ItemHeight - 1));
            G.DrawString(currentItem, Font, USIC, new Rectangle(7, Y, Width - 34, Y + 10));

            if (_SelectedItems.Contains(currentItem))
            {
                G.FillRectangle(SIBC, new Rectangle(0, (i * ItemHeight) + 1 - offset, Width - 19, ItemHeight - 1));
                G.DrawString(currentItem, Font, SIC, new Rectangle(7, Y, Width - 34, Y + 10));
            }
        }
        }
        using (Pen borderPen = H.PenColor(BorderColor))
        {
            G.DrawRectangle(borderPen, mainRect);
        }


    }

    #endregion

}

#endregion

#region Numerical UpDown

[DefaultProperty("Value")]
public class SpinNumericUpDown : Control
{

    #region Declarations

    private static readonly HelperMethods H = new HelperMethods();
    private Point CurrentLocation = new Point(1, 1);
    private int _Value;
    private int _Maximum;
    private int _Minimum;
    private Color _BaseColor = H.GetHTMLColor("FF353535");
    private Color _ControllingAreasColor = H.GetHTMLColor("262626");
    private Color _ControllingLinesColor = H.GetHTMLColor("232323");
    private Color _ControllersTextColor = H.GetHTMLColor("FF2B90D2");
    private Color _ValueTextColor = H.GetHTMLColor("FF2B90D2");
    private Color _BorderColor = H.GetHTMLColor("262626");

    #endregion

    #region Properties

    [Category("Custom Properties"), Description("Gets or sets the current number of the NumericUpDown.")]
    public int Value
    {
        get { return _Value; }
        set
        {
            if (value <= Maximum & value >= Minimum)
                _Value = value;
            Invalidate();
        }
    }


    [Category("Custom Properties"), Description("Gets or sets the maximum number of the NumericUpDown.")]
    public int Maximum
    {
        get { return _Maximum; }
        set
        {
            if (value > Minimum)
                _Maximum = value;
            if (value > _Maximum)
                value = _Maximum;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the minimum number of the NumericUpDown.")]
    public int Minimum
    {
        get { return _Minimum; }
        set
        {
            if (value < Maximum)
                _Minimum = value;
            if (value < _Minimum)
                value = _Minimum;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the background color of the control.")]
    public Color BaseColor
    {
        get { return _BaseColor; }
        set
        {
            _BaseColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the the plus and minus area background color of the control.")]
    public Color ControllingAreasColor
    {
        get { return _ControllingAreasColor; }
        set
        {
            _ControllingAreasColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the lines of plus and minus area color of the control.")]
    public Color ControllingLinesColor
    {
        get { return _ControllingLinesColor; }
        set
        {
            _ControllingLinesColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the plus and minus symbols color of the control.")]
    public Color ControllersTextColor
    {
        get { return _ControllersTextColor; }
        set
        {
            _ControllersTextColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the value text color of the control.")]
    public Color ValueTextColor
    {
        get { return _ValueTextColor; }
        set
        {
            _ValueTextColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the border color of the control.")]
    public Color BorderColor
    {
        get { return _BorderColor; }
        set
        {
            _BorderColor = value;
            Invalidate();
        }
    }

    #endregion

    #region Constructors

    public SpinNumericUpDown()
    {
        SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
        DoubleBuffered = true;
        BackColor = Color.Transparent;
        Font = new Font("Segoe UI", 10, FontStyle.Regular);
    }

    #endregion

    #region Draw Control

    protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
    {
        Graphics G = e.Graphics;
        G.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
        Rectangle Rect = new Rectangle(0, 0, Width, Height);

        using (SolidBrush BG = new SolidBrush(BaseColor))
        {
            G.FillRectangle(BG, Rect);
        }

        using (SolidBrush CAC = new SolidBrush(ControllingAreasColor))
        using (Pen CLS = H.PenColor(ControllingLinesColor))
        using (SolidBrush CTC = new SolidBrush(ControllersTextColor))
        using (Font F = new Font("Segoe UI", 16, FontStyle.Bold))
        {
            G.FillRectangle(CAC, new Rectangle(Width - 25, 0, 24, Height - 1));
            G.FillRectangle(CAC, new Rectangle(0, 0, 24, Height - 1));
            G.DrawLine(CLS, new Point(Width - 25, 1), new Point(Width - 25, Height - 2));
            G.DrawLine(CLS, new Point(24, 1), new Point(24, Height - 2));
            H.CentreString(G, "+", F, CTC, new Rectangle(Width - 25, 0, 25, Height - 4));
            H.CentreString(G, "-", F, CTC, new Rectangle(1, 0, 23, Height - 4));
        }

        using (SolidBrush VTC = new SolidBrush(ValueTextColor))
        {
            G.DrawString(Value.ToString(), Font, VTC, new Rectangle(10, 0, Width - 25, Height - 1), H.SetPosition());
        }

        using (Pen BorderPen = H.PenColor(BorderColor))
        {
            G.DrawRectangle(BorderPen, new Rectangle(0, 0, Width - 1, Height - 1));
        }

    }

    #endregion

    #region Events

    protected override void OnCreateControl()
    {
        base.OnCreateControl();
        Maximum = int.MaxValue;
        Minimum = 0;
    }

    protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
    {
        base.OnMouseMove(e);
        CurrentLocation = e.Location;
        Invalidate();
        if (e.X > 0 && e.X < 24)
        {
            Cursor = Cursors.Hand;
        }
        else if (e.X > Width - 24 && e.X < Width - 3)
        {
            Cursor = Cursors.Hand;
        }
        else
        {
            Cursor = Cursors.IBeam;
        }
    }

    protected override void OnResize(System.EventArgs e)
    {
        base.OnResize(e);
        Height = 26;
    }

    protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
    {
        base.OnMouseClick(e);
        if (CurrentLocation.X > 1 && CurrentLocation.X < 23)
        {
            if ((Value - 1) >= Minimum)
                Value -= 1;
        }
        else if (CurrentLocation.X > Width - 23 && CurrentLocation.X < Width - 3)
        {
            if ((Value + 1) <= Maximum)
                Value += 1;
        }
        Invalidate();
    }

    #endregion

}


#endregion

#region ContextMenuStrip

public class SpinContextMenuStrip : ContextMenuStrip
{

    #region Variables

    private ToolStripItemClickedEventArgs ClickedEventArgs;
    private static readonly HelperMethods H = new HelperMethods();

    #endregion

    #region Constructors

    public SpinContextMenuStrip()
    {
        Renderer = new SpinToolStripRender();
        BackColor = H.GetHTMLColor("FF1A1A1A");
    }

    #endregion

    #region Events

    public event ClickedEventHandler Clicked;
    public delegate void ClickedEventHandler(object sender);

    protected override void OnItemClicked(ToolStripItemClickedEventArgs e)
    {
        if ((e.ClickedItem != null) && !(e.ClickedItem is ToolStripSeparator))
        {
            if (object.ReferenceEquals(e, ClickedEventArgs))
                OnItemClicked(e);
            else
            {
                ClickedEventArgs = e; Clicked?.Invoke(this);
            }
        }
    }

    protected override void OnMouseHover(EventArgs e)
    {
        base.OnMouseHover(e);
        Cursor = Cursors.Hand;
        Invalidate();
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
        base.OnMouseUp(e);
        Cursor = Cursors.Hand;
        Invalidate();
    }

    #endregion

    #region SpinToolStripMenuItem

    public sealed class SpinToolStripMenuItem : ToolStripMenuItem
    {

        #region Constructors

        public SpinToolStripMenuItem()
        {
            AutoSize = false;
            Size = new Size(160, 30);
        }

        #endregion

        #region Adding DropDowns

        protected override ToolStripDropDown CreateDefaultDropDown()
        {
            if (DesignMode)
            { return base.CreateDefaultDropDown(); }
            SpinContextMenuStrip DP = new SpinContextMenuStrip();
            DP.Items.AddRange(base.CreateDefaultDropDown().Items);
            return DP;
        }

        #endregion

    }

    #endregion

    #region SpinToolStripRender

    public sealed class SpinToolStripRender : ToolStripProfessionalRenderer
    {

        #region Drawing Text

        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            Rectangle textRect = new Rectangle(25, e.Item.ContentRectangle.Y, e.Item.ContentRectangle.Width - (24 + 16), e.Item.ContentRectangle.Height - 4);
            using (SolidBrush B = new SolidBrush(e.Item.Enabled ? H.GetHTMLColor("C5C5C5") : Color.Gray))
            using (Font F = new Font("Segoe UI", 10))
            {
                e.Graphics.DrawString(e.Text, F, B, textRect);
            }
        }

        #endregion

        #region Drawing Backgrounds

        protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
        {
            base.OnRenderToolStripBackground(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.InterpolationMode = InterpolationMode.High;
            e.Graphics.Clear(H.GetHTMLColor("FF1A1A1A"));
        }

        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            e.Graphics.InterpolationMode = InterpolationMode.High;
            e.Graphics.Clear(H.GetHTMLColor("FF1A1A1A"));
            Rectangle R = new Rectangle(0, e.Item.ContentRectangle.Y - 2, e.Item.ContentRectangle.Width + 4, e.Item.ContentRectangle.Height + 3);
            using (SolidBrush B = new SolidBrush(e.Item.Selected && e.Item.Enabled? H.GetHTMLColor("FF2B90D2"): H.GetHTMLColor("FF1A1A1A")))
            {
                e.Graphics.FillRectangle(B, R);
            }

        }

        #endregion

        #region Set Image Margin

        protected override void OnRenderImageMargin(ToolStripRenderEventArgs e)
        {
            //MyBase.OnRenderImageMargin(e) 
            //I Make above line comment which makes users to be able to add images to ToolStrips
        }

        #endregion

        #region Drawing Seperators & Borders

        protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.DrawLine(new Pen(Color.Gray, 1), new Point(e.Item.Bounds.Left, e.Item.Bounds.Height / 2), new Point(e.Item.Bounds.Right - 5, e.Item.Bounds.Height / 2));
        }

        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            e.Graphics.InterpolationMode = InterpolationMode.High;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            H.DrawRoundedPath(e.Graphics, Color.Gray, 1, new Rectangle(e.AffectedBounds.X, e.AffectedBounds.Y, e.AffectedBounds.Width - 1, e.AffectedBounds.Height - 1), 4);
        }

        #endregion

        #region Drawing DropDown Arrows

        protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
        {
            int ArrowX, ArrowY;
            ArrowX = e.ArrowRectangle.X + e.ArrowRectangle.Width / 2;
            ArrowY = e.ArrowRectangle.Y + e.ArrowRectangle.Height / 2;
            Point[] ArrowPoints = new Point[] 
            {
				new Point(ArrowX - 5, ArrowY - 5),
				new Point(ArrowX, ArrowY),
				new Point(ArrowX - 5, ArrowY + 5)
			};

            using (SolidBrush ArrowBrush = new SolidBrush(e.Item.Enabled ? H.GetHTMLColor("C5C5C5") : Color.Gray))
            {
                e.Graphics.FillPolygon(ArrowBrush, ArrowPoints);
            }

        }

        #endregion

    }

    #endregion

}

#endregion

#region ScrollBars

#region Vertical ScrollBars

[DefaultEvent("Scroll"), DefaultProperty("Value")]
public class SpinVerticalScrollBar : Control
{

    #region Declarations

    private static readonly HelperMethods H = new HelperMethods();
    private Color _BackColor = H.GetHTMLColor("FF353535");
    private Color _ThumbColor = H.GetHTMLColor("FF2C97DE");
    private Color _ArrowColor = H.GetHTMLColor("FF2C97DE");
    private int _Minimum = 0;
    private int _Maximum = 100;
    private int _Value = 0;
    private int _SmallChange = 1;
    private int II;
    private int _LargeChange = 10;
    private Point MouseLocation = new Point(1, 1);
    private HelperMethods.MouseMode _ThumbState = HelperMethods.MouseMode.Normal;
    private HelperMethods.MouseMode _ArrowState = HelperMethods.MouseMode.Normal;
    private Rectangle UpperArrow;
    private Rectangle LowerArrow;
    private Rectangle Shaft;
    private Rectangle Thumb;
    private bool ShowThumb;
    private int _ThumbSize = 20;

    #endregion

    #region Properties

    [Category("Custom Properties"), Description("Gets or sets the background color for the control.")]
    public new Color BackColor
    {
        get { return _BackColor; }
        set
        {
            _BackColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the thumb color for the control.")]
    public Color ThumbColor
    {
        get { return _ThumbColor; }
        set
        {
            _ThumbColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the arrows color for the control.")]
    public Color ArrowColor
    {
        get { return _ArrowColor; }
        set
        {
            _ArrowColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the lower limit of the scrollable range.")]
    public int Minimum
    {
        get { return _Minimum; }
        set
        {
            _Minimum = value;
            if (value > _Value)
            {
                _Value = value;
            }
            else if (value > _Maximum)
            {
                _Maximum = value;
            }
            InvalidateLayout();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the upper limit of the scrollable range.")]
    public int Maximum
    {
        get { return _Maximum; }
        set
        {
            if (value < _Value)
            {
                _Value = value;
            }
            else if (value < _Minimum)
            {
                _Minimum = value;
            }
            InvalidateLayout();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets a numeric value that represents the current position of the scroll bar box.")]
    public int Value
    {
        get { return _Value; }
        set
        {
            if (value > _Maximum)
            {
                throw new Exception("Already reached to the maximum value.");
            }
            else if (value < _Minimum)
            {
                throw new Exception("Already reached to the minimum value.");
            }
            else
            {
                _Value = value;
            }
            InvalidatePosition();
            Scroll?.Invoke(this);
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the distance to move a scroll bar in response to a small scroll command.")]
    public int SmallChange
    {
        get { return _SmallChange; }
        set
        {
            _SmallChange = value;
            Invalidate();

        }
    }

    [Category("Custom Properties"), Description("Gets or sets the distance to move a scroll bar in response to a large scroll command.")]
    public int LargeChange
    {
        get { return _LargeChange; }
        set { _LargeChange = value;Invalidate(); }
    }

    #endregion

    #region Events

    protected override void OnSizeChanged(EventArgs e)
    {
        InvalidateLayout();
    }

    private void InvalidateLayout()
    {

        UpperArrow = new Rectangle(0, 0, Width, 0x10);
        Shaft = new Rectangle(0, UpperArrow.Bottom + 1, Width, Convert.ToInt32((double)((Height - (((double)Height) / 8.0)) - 8.0)));
        ShowThumb = (Maximum - Minimum) > 0;
        if (ShowThumb)
        {
            Thumb = new Rectangle(4, 0, Width - 8, Convert.ToInt32((double)(((double)Height) / 8.0)));
        }
        Scroll?.Invoke(this);
        InvalidatePosition();
    }

    public event ScrollEventHandler Scroll;
    public delegate void ScrollEventHandler(object sender);

    public void InvalidatePosition()

    {
        Thumb.Y = Convert.ToInt32((double)(Value - Minimum) / (Maximum - Minimum) * (Shaft.Height - _ThumbSize) + 16.0);
        Invalidate();
    }
   protected override void OnMouseDown(MouseEventArgs e)
    {
        base.OnMouseDown(e);
        if (e.Button == MouseButtons.Left && ShowThumb)
        {
            if (UpperArrow.Contains(e.Location))
            {
                _ArrowState = HelperMethods.MouseMode.Pushed;
                II = Value - SmallChange;
            }
            else if (LowerArrow.Contains(e.Location))
            {
                II = Value + SmallChange;
                _ArrowState = HelperMethods.MouseMode.Pushed;
            }
            else
            {
                if (Thumb.Contains(e.Location))
                {
                    _ThumbState = HelperMethods.MouseMode.Pushed;
                    Invalidate();
                    return;
                }
                if (e.Y < Thumb.Y)
                {
                    II = Value - LargeChange;
                }
                else
                {
                    II = Value + LargeChange;
                }
            }
            Value = Math.Min(Math.Max(II, Minimum), Maximum);
            Invalidate();
            InvalidatePosition();
        }

    }
    protected override void OnMouseMove(MouseEventArgs e)
    {
        if (_ThumbState == HelperMethods.MouseMode.Pushed | _ArrowState == HelperMethods.MouseMode.Pushed && ShowThumb)
        {
            int thumbPosition = (e.Y - UpperArrow.Height) - (_ThumbSize / 2);
            int thumbBounds = Shaft.Height - _ThumbSize;
            II = Convert.ToInt32(((double)(thumbPosition) / thumbBounds) * (Maximum - Minimum)) - Minimum;
            Value = Math.Min(Math.Max(II, Minimum), Maximum);
            InvalidatePosition();
        }

    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
        if (Thumb.Contains(e.Location))
        {
            _ThumbState = HelperMethods.MouseMode.Hovered;
        }
        else
        {
            _ThumbState = HelperMethods.MouseMode.Normal;
        }
        if ((e.Location.Y < 0x10) | (e.Location.Y > (Width - 0x10)))
        {
            _ThumbState = HelperMethods.MouseMode.Hovered;
        }
        else
        {
            _ThumbState = HelperMethods.MouseMode.Normal;
        }
        Invalidate();


    }

    protected override void OnMouseLeave(EventArgs e)
    {
        _ThumbState = HelperMethods.MouseMode.Normal;
        _ArrowState = HelperMethods.MouseMode.Normal;
        Invalidate();
    }

    protected override void OnMouseEnter(EventArgs e)
    {
        base.OnMouseEnter(e);
        Invalidate();
    }

    #endregion

    #region Contsructors

    public SpinVerticalScrollBar()
    {
        SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.Selectable | ControlStyles.SupportsTransparentBackColor, true);
        DoubleBuffered = true;
        Size = new Size(19, 50);
        UpdateStyles();
    }

    #endregion

    #region Draw Control
    protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
    {
        Graphics G = e.Graphics;

        G.SmoothingMode = SmoothingMode.HighQuality;
        G.PixelOffsetMode = PixelOffsetMode.HighQuality;
        G.Clear(BackColor);
        using (SolidBrush ThumbBrush = new SolidBrush(ThumbColor))
        {
            G.FillRectangle(ThumbBrush, Thumb);
        }

        Point[] UpperTriangle = H.Triangle(new Point(Convert.ToInt32(Width / 2), 5), new Point(Convert.ToInt32(Width / 4), 11), new Point(Convert.ToInt32(Width / 2 + Width / 4), 11));
        Point[] LowerTriangle = H.Triangle(new Point(Convert.ToInt32(Width / 2), Height - 5), new Point(Convert.ToInt32(Width / 4), Height - 11), new Point(Convert.ToInt32(Width / 2 + Width / 4), Height - 11));

        using (SolidBrush ArrowBrush = new SolidBrush(ArrowColor))
        {
            G.FillPolygon(ArrowBrush, UpperTriangle);
            G.FillPolygon(ArrowBrush, LowerTriangle);
        }

    }

    #endregion

}

#endregion

#region Horizontal ScrollBars

[DefaultEvent("Scroll"), DefaultProperty("Value")]
public class SpinHorizontalScrollBar : Control
{

    #region Declarations

    private static readonly HelperMethods H = new HelperMethods();
    private Color _BackColor = H.GetHTMLColor("FF353535");
    private Color _ThumbColor = H.GetHTMLColor("FF2C97DE");
    private Color _ArrowColor = H.GetHTMLColor("FF2C97DE");
    private int _Minimum = 0;
    private int _Maximum = 100;
    private int _Value = 0;
    private int _SmallChange = 1;
    private int _LargeChange = 10;
    private Point MouseLocation = new Point(1, 1);
    private HelperMethods.MouseMode _ThumbState = HelperMethods.MouseMode.Normal;
    private HelperMethods.MouseMode _ArrowState = HelperMethods.MouseMode.Normal;
    private int II;
    private Rectangle UpperArrow;
    private Rectangle LowerArrow;
    private Rectangle Shaft;
    private Rectangle Thumb;
    private bool ShowThumb;

    private int _ThumbSize = 25;
    #endregion

    #region Properties

    [Category("Custom Properties"), Description("Gets or sets the background color for the control.")]
    public new Color BackColor
    {
        get { return _BackColor; }
        set
        {
            _BackColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the thumb color for the control.")]
    public Color ThumbColor
    {
        get { return _ThumbColor; }
        set
        {
            _ThumbColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the arrows color for the control.")]
    public Color ArrowColor
    {
        get { return _ArrowColor; }
        set
        {
            _ArrowColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the lower limit of the scrollable range.")]
    public int Minimum
    {
        get { return _Minimum; }
        set
        {
            _Minimum = value;
            if (value > _Value)
            {
                _Value = value;
            }
            else if (value > _Maximum)
            {
                _Maximum = value;
            }
            InvalidateLayout();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the upper limit of the scrollable range.")]
    public int Maximum
    {
        get { return _Maximum; }
        set
        {
            if (value < _Value)
            {
                _Value = value;
            }
            else if (value < _Minimum)
            {
                _Minimum = value;
            }
            InvalidateLayout();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets a numeric value that represents the current position of the scroll bar box.")]
    public int Value
    {
        get { return _Value; }
        set
        {
            if (value > _Maximum)
            {
                throw new Exception("Already reached to the maximum value.");
            }
            else if (value < _Minimum)
            {
                throw new Exception("Already reached to the minimum value.");
            }
            else
            {
                _Value = value;
            }
            InvalidatePosition();
            Scroll?.Invoke(this);
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the distance to move a scroll bar in response to a small scroll command.")]
    public int SmallChange
    {
        get { return _SmallChange; }
        set
        {
            _SmallChange = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the distance to move a scroll bar in response to a large scroll command.")]
    public int LargeChange
    {
        get { return _LargeChange; }
        set
        {
            _LargeChange = value;
            Invalidate();
        }
    }

    #endregion

    #region Events

    protected override void OnSizeChanged(EventArgs e)
    {
        InvalidateLayout();
    }

    private void InvalidateLayout()
    {
        UpperArrow = new Rectangle(0, 0, 16, Height);
        Shaft = new Rectangle(UpperArrow.Right + 1, 0, Convert.ToInt32(Width - Width / 8 - 8), Height);
        ShowThumb = Convert.ToBoolean(((_Maximum - _Minimum)));
        if (ShowThumb)
            Thumb = new Rectangle(0, 4, Convert.ToInt32(Width / 8), Height - 8);
        Scroll?.Invoke(this);
        InvalidatePosition();
    }

    public event ScrollEventHandler Scroll;
    public delegate void ScrollEventHandler(object sender);

    private void InvalidatePosition()
    {
        Thumb.X = Convert.ToInt32((double)(((((double)(_Value - _Minimum)) / ((double)(_Maximum - _Minimum))) * (Shaft.Width - _ThumbSize)) + 16.0));
        Invalidate();

    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        if ((e.Button == MouseButtons.Left) && ShowThumb)
        {
            if (UpperArrow.Contains(e.Location))
            {
                _ArrowState = HelperMethods.MouseMode.Pushed;
                II = _Value - _SmallChange;
            }
            else if (LowerArrow.Contains(e.Location))
            {
                II = _Value + _SmallChange;
                _ArrowState = HelperMethods.MouseMode.Pushed;
            }
            else
            {
                if (Thumb.Contains(e.Location))
                {
                    _ThumbState = HelperMethods.MouseMode.Pushed;
                    Invalidate();
                    return;
                }
                if (e.X < Thumb.X)
                {
                    II = _Value - _LargeChange;
                }
                else
                {
                    II = _Value + _LargeChange;
                }
            }
            Value = Math.Min(Math.Max(II, _Minimum), _Maximum);
            Invalidate();
            InvalidatePosition();
        }

    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
        MouseLocation = e.Location;
    if (UpperArrow.Contains(MouseLocation))
    {
        _ArrowState = HelperMethods.MouseMode.Hovered;
    }
    else if (LowerArrow.Contains(MouseLocation))
    {
        _ArrowState = HelperMethods.MouseMode.Hovered;
    }
    else if (_ArrowState != HelperMethods.MouseMode.Pushed)
    {
        _ArrowState = HelperMethods.MouseMode.Normal;
    }
    if (Thumb.Contains(MouseLocation) & (_ThumbState != HelperMethods.MouseMode.Pushed))
    {
        _ThumbState = HelperMethods.MouseMode.Hovered;
    }
    else if (_ThumbState != HelperMethods.MouseMode.Pushed)
    {
        _ThumbState = HelperMethods.MouseMode.Normal;
    }
    Invalidate();
    if (_ThumbState == HelperMethods.MouseMode.Pushed | _ArrowState == HelperMethods.MouseMode.Pushed && ShowThumb)
    {
        int num = ((e.X + 2) - UpperArrow.Width) - (_ThumbSize / 2);
         II = Convert.ToInt32((double) ((((double) num) / ((double) Shaft.Width - _ThumbSize)) * (_Maximum - _Minimum))) - _Minimum;
         Value = Math.Min(Math.Max(II, _Minimum), _Maximum);
         InvalidatePosition();
    }

    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
        MouseLocation = e.Location;
        if (Thumb.Contains(MouseLocation))
        {
            _ThumbState = HelperMethods.MouseMode.Hovered;
        }
        else if (!Thumb.Contains(MouseLocation))
        {
            _ThumbState = HelperMethods.MouseMode.Normal;
        }
        if (MouseLocation.X < 16 | MouseLocation.X > Width - 16)
        {
            _ThumbState = HelperMethods.MouseMode.Hovered;
        }
        else if (!(MouseLocation.X < 16) | MouseLocation.X > Width - 16)
        {
            _ThumbState = HelperMethods.MouseMode.Normal;
        }
        Invalidate();
    }

    protected override void OnMouseLeave(EventArgs e)
    {
        _ThumbState = HelperMethods.MouseMode.Normal;
        _ArrowState = HelperMethods.MouseMode.Normal;
        Invalidate();
    }

    protected override void OnMouseEnter(EventArgs e)
    {
        base.OnMouseEnter(e);
        Invalidate();
    }

    #endregion

    #region Contsructors 

    public SpinHorizontalScrollBar()
    {
        SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.Selectable | ControlStyles.SupportsTransparentBackColor, true);
        DoubleBuffered = true;
        Size = new Size(50, 19);
    }
    #endregion

    #region Draw Control

    protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
    {
        Graphics G = e.Graphics;

        G.SmoothingMode = SmoothingMode.HighQuality;
        G.PixelOffsetMode = PixelOffsetMode.HighQuality;
        G.Clear(BackColor);
        using (SolidBrush ThumbBrush = new SolidBrush(ThumbColor))
        {
            G.FillRectangle(ThumbBrush, Thumb);
        }

        Point[] LeftTriangle = H.Triangle(new Point(5, Convert.ToInt32(Height / 2)), new Point(11, Convert.ToInt32(Height / 4)), new Point(11, Convert.ToInt32(Height / 2 + Height / 4)));

        Point[] RightTriangle = H.Triangle(new Point(Width - 5, Convert.ToInt32(Height / 2)), new Point(Width - 11, Convert.ToInt32(Height / 4)), new Point(Width - 11, Convert.ToInt32(Height / 2 + Height / 4)));

        using (SolidBrush ArrowBrush = new SolidBrush(ArrowColor))
        {
            G.FillPolygon(ArrowBrush, LeftTriangle);
            G.FillPolygon(ArrowBrush, RightTriangle);
        }


    }

    #endregion

}

#endregion

#endregion

#region StarRating

public class SpinRate : Control
{

    #region Declarations

    private static readonly HelperMethods H = new HelperMethods();
    private int _starCount = 5;
    private int _Pieces = 5;
    private int _Value = 3;
    private Color _UnRatedColor = H.GetHTMLColor("FF353535");
    private Color _RatedColor = H.GetHTMLColor("FF2C97DE");
    private List<Point> StarsList = new List<Point>();
    private bool MouseIn;
    private int currMouseX;

    #endregion

    #region Constructors

    public SpinRate()
    {
        SetStyle(ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor, true);
        DoubleBuffered = true;
        BackColor = Color.Transparent;
        UpdateStyles();
    }

    #endregion

    #region Properties

    [Category("Custom Properties"), Description("Gets or sets the number of stars to be rate.")]
    public int Value
    {
        get { return _Value; }
        set
        {
            _Value = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the number of control stars.")]
    public int StarCount
    {
        get { return _starCount; }
        set
        {
            _starCount = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the control star pieces.")]
    public int Pieces
    {
        get { return _Pieces; }
        set
        {
            _Pieces = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the control star color whenever un-rated.")]
    public Color UnRatedColor
    {
        get { return _UnRatedColor; }
        set
        {
            _UnRatedColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the control star color whenever rated.")]
    public Color RatedColor
    {
        get { return _RatedColor; }
        set
        {
            _RatedColor = value;
            Invalidate();
        }
    }

    #endregion

    #region Draw Control
    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics G = e.Graphics;
        G.SmoothingMode = SmoothingMode.AntiAlias;
        int X = (int)Math.Round((double)Width / (double)StarCount);
        int Y = (int)Math.Round((double)Height / 2.0);
        GraphicsPath GP = new GraphicsPath();
        using (SolidBrush BRated = new SolidBrush(RatedColor))
        {
            using (SolidBrush BUnrated = new SolidBrush(UnRatedColor))
            {
                int starCount = StarCount;
                for (int i = 0; i <= starCount; i++)
                {
                    GP = new GraphicsPath();
                    GP.AddPolygon(
                        GetPoints(
                            new Point((int) Math.Round((double) ((float) (unchecked((double) X*((double) i - 0.5))))), Y),
                            Pieces).ToArray());
                    G.FillPath(BUnrated, GP);
                }
                bool mouseIn = MouseIn;
                if (mouseIn)
                {
                    int num = currMouseX;
                    for (int j = 0; j <= num; j++)
                    {
                        GP = new GraphicsPath();
                        GP.AddPolygon(
                            GetPoints(
                                new Point(
                                    (int) Math.Round((double) ((float) (unchecked((double) X*((double) j - 0.5))))), Y),
                                Pieces).ToArray());
                        G.FillPath(BRated, GP);
                    }
                }
                else
                {
                    int value = Value;
                    for (int k = 0; k <= value; k++)
                    {
                        GP = new GraphicsPath();
                        GP.AddPolygon(
                            GetPoints(
                                new Point(
                                    (int) Math.Round((double) ((float) (unchecked((double) X*((double) k - 0.5))))), Y),
                                Pieces).ToArray());
                        G.FillPath(BRated, GP);
                    }
                }
            }
        }
        GP.Dispose();
    }

    #endregion

    #region Events

    public event ValueChangedEventHandler ValueChanged;
    public delegate void ValueChangedEventHandler(object sender);

    public List<Point> GetPoints(Point Center, int Pieces)
    {
        List<Point> P = new List<Point>();
        for (int i = 0; i <= Pieces * 2 - 1; i++)
        {
            if (i % 2 == 1)
            {
                int x = Convert.ToInt32(12 * Math.Cos(Convert.ToSingle(90 * Math.PI / 180) + Convert.ToSingle((360 / (Pieces * 2)) * Math.PI / 180) * i)) + Center.X;
                int y = Convert.ToInt32(12 * Math.Sin(Convert.ToSingle(90 * Math.PI / 180) + Convert.ToSingle((360 / (Pieces * 2)) * Math.PI / 180) * i)) + Center.Y;
                P.Add(new Point(x, y));
            }
            else
            {
                int x = Convert.ToInt32(8 * Math.Cos(Convert.ToSingle(90 * Math.PI / 180) + Convert.ToSingle((360 / (Pieces * 2)) * Math.PI / 180) * i)) + Center.X;
                int y = Convert.ToInt32(8 * Math.Sin(Convert.ToSingle(90 * Math.PI / 180) + Convert.ToSingle((360 / (Pieces * 2)) * Math.PI / 180) * i)) + Center.Y;
                P.Add(new Point(x, y));
            }
        }
        return P;
    }

    protected override void OnMouseClick(MouseEventArgs e)
    {
        if (MouseIn)
        {
            if (currMouseX == checked(_Value - 1))
            {
                _Value = 0;
            }
            else
            {
                _Value = currMouseX;
            }
            ValueChanged?.Invoke(this);
            Invalidate();
        }
        base.OnMouseClick(e);
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
        checked
        {
            int X = (int)Math.Round((double)Width / (double)StarCount / 3.5);
            int MouseLocationX = e.X / X / 3;
            if (MouseLocationX != currMouseX)
            {
                currMouseX = MouseLocationX;
            }
            Invalidate();
            base.OnMouseMove(e);
        }
    }

    protected override void OnMouseLeave(System.EventArgs e)
    {
        MouseIn = false;
        Invalidate();
        base.OnMouseLeave(e);
    }

    protected override void OnMouseEnter(System.EventArgs e)
    {
        MouseIn = true;
        Invalidate();
        base.OnMouseEnter(e);
    }

    #endregion

}

#endregion

#region ControlBox
class SpinControlBox : Control
{

    #region Declarations

    private static HelperMethods H=new HelperMethods();
    private bool MinimizeHovered = false;
    private bool MaximizeHovered = false;
    private bool CloseHovered = false;
    private bool _MinimizeBox = true;
    private bool _MaximizeBox = true;
    private Color _NormalColor = Color.Gray;
    private Color _DisabledColor = Color.DimGray;
    private Color _HoveredColor = H.GetHTMLColor("FF2C97DE");
    
    #endregion

    #region Properties

    [Category("Custom Properties"), Description("Gets or sets a value indicating whether the Maximize button is Enabled in the caption bar of the form.")]
    public bool MaximizeBox
    {
        get { return _MaximizeBox; }
        set
        {
            _MaximizeBox = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets a value indicating whether the Minimize button is Enabled in the caption bar of the form.")]
    public bool MinimizeBox
    {
        get { return _MinimizeBox; }
        set
        {
            _MinimizeBox = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the control color in normal mouse state.")]
    public Color NormalColor
    {
        get { return _NormalColor; }
        set
        {
            _NormalColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the control color while the control disabled.")]
    public Color DisabledColor
    {
        get { return _DisabledColor; }
        set
        {
            _DisabledColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the control color in hover mouse state.")]
    public Color HoveredColor
    {
        get { return _HoveredColor; }
        set
        {
            _HoveredColor = value;
            Invalidate();
        }
    }

    #endregion

    #region Events

    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        Size = new Size(100, 25);
    }
    protected override void OnMouseMove(MouseEventArgs e)
    {
        base.OnMouseMove(e);
        if (e.Location.Y > 0 && e.Location.Y < (Height - 2))
        {
            if (e.Location.X > 0 && e.Location.X < 34)
            {
                Cursor = Cursors.Hand;
                MinimizeHovered = true;
                MaximizeHovered = false;
                CloseHovered = false;
            }
            else if (e.Location.X > 33 && e.Location.X < 65)
            {
                Cursor = Cursors.Hand;
                MinimizeHovered = false;
                MaximizeHovered = true;
                CloseHovered = false;
            }
            else if (e.Location.X > 64 && e.Location.X < Width)
            {
                Cursor = Cursors.Hand;
                MinimizeHovered = false;
                MaximizeHovered = false;
                CloseHovered = true;
            }
            else
            {
                Cursor = Cursors.Arrow;
                MinimizeHovered = false;
                MaximizeHovered = false;
                CloseHovered = false;
            }
        }
        Invalidate();
    }
    protected override void OnMouseUp(MouseEventArgs e)
    {
        base.OnMouseDown(e);
        if (CloseHovered)
        {
            Parent.FindForm().Close();
        }
        else if (MinimizeHovered)
        {
            if (MinimizeBox)
                Parent.FindForm().WindowState = FormWindowState.Minimized;

        }
        else if (MaximizeHovered)
        {
            if (MaximizeBox)
            {
                if (Parent.FindForm().WindowState == FormWindowState.Normal)
                {
                    Parent.FindForm().WindowState = FormWindowState.Maximized;
                }
                else
                {
                    Parent.FindForm().WindowState = FormWindowState.Normal;
                }
            }
        }
    }
    protected override void OnMouseLeave(EventArgs e)
    {
        base.OnMouseLeave(e);
        Cursor = Cursors.Arrow;
        MinimizeHovered = false;
        MaximizeHovered = false;
        CloseHovered = false;
        Invalidate();
    }
    protected override void OnMouseDown(MouseEventArgs e)
    {
        base.OnMouseDown(e);
        Focus();
    }

    #endregion

    #region Constructors

    public SpinControlBox()
    {
        SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
        DoubleBuffered = true;
        UpdateStyles();
        BackColor = Color.Transparent;
        Anchor = AnchorStyles.Top | AnchorStyles.Right;
    }

    #endregion

    #region Draw Control

    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics G = e.Graphics;
        G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

        using (SolidBrush CloseBoxState = new SolidBrush(CloseHovered ? HoveredColor : NormalColor))
        using (Font F = new Font("Marlett", 12))
        using (StringFormat SF = new StringFormat { Alignment = StringAlignment.Center })
        {
            G.DrawString("r", F, CloseBoxState, new Point(Width - 16, 8), SF);
        }

        if (Parent.FindForm().WindowState == FormWindowState.Maximized)
        {
            using (SolidBrush MaximizeBoxState = new SolidBrush(MaximizeBox ? MaximizeHovered ? HoveredColor : NormalColor : DisabledColor))
            using (Font F = new Font("Marlett", 12))
            using (StringFormat SF = new StringFormat { Alignment = StringAlignment.Center })
            {
                G.DrawString("2", F, MaximizeBoxState, new Point(51, 7), SF);
            }
        }
        else if (Parent.FindForm().WindowState == FormWindowState.Normal)
        {
            using (SolidBrush MaximizeBoxState = new SolidBrush(MaximizeBox ? MaximizeHovered ? HoveredColor : NormalColor : DisabledColor))
            using (Font F = new Font("Marlett", 12))
            using (StringFormat SF = new StringFormat { Alignment = StringAlignment.Center })
            {
                G.DrawString("1", F, MaximizeBoxState, new Point(51, 7), SF);
            }
        }

        using (SolidBrush MinimizeBoxState = new SolidBrush(MinimizeBox ? MinimizeHovered ? HoveredColor : NormalColor : DisabledColor))
        using (Font F = new Font("Marlett", 12))
        using (StringFormat SF = new StringFormat { Alignment = StringAlignment.Center })
        {
            G.DrawString("0", F, MinimizeBoxState, new Point(20, 7), SF);
        }

    }

    #endregion

}

#endregion

#region ListLabel

public class SpinListLabel : Control
{

    #region Declarations

    private static readonly HelperMethods H = new HelperMethods();
    private Color _SymbolColor = H.GetHTMLColor("FF2C97DE");
    private Color _ItemsColor = Color.White;
    private int _SymbolSize = 7;
    private int _SeperateWidth = 30;
    private List<string> _Items = new List<string>();
    private SymbolStyle _SymbolShape = SymbolStyle.Square;

    #endregion

    #region Constructors

    public SpinListLabel()
    {
        SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
        DoubleBuffered = true;
        UpdateStyles();
        BackColor = Color.Transparent;
        Font = new Font("Segoe UI", 9);

    }

    #endregion

    #region Enumerators

    public enum SymbolStyle
    {
        Ellipse,
        Square
    }

    #endregion

    #region Properties

    [Category("Custom Properties"), Description("Gets or sets the symbol color of the control.")]
    public Color SymbolColor
    {
        get { return _SymbolColor; }
        set
        {
            _SymbolColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the items color of the control.")]
    public Color ItemsColor
    {
        get { return _ItemsColor; }
        set
        {
            _ItemsColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the symbol size of the control.")]
    public int SymbolSize
    {
        get { return _SymbolSize; }
        set
        {
            _SymbolSize = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the seperator width of the control.")]
    public int SeperateWidth
    {
        get { return _SeperateWidth; }
        set
        {
            _SeperateWidth = value;
            Invalidate();
        }
    }

    [TypeConverter(typeof(CollectionConverter)), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Category("Custom Properties"), Description("Gets the items of the Spin ListLabel.")]
    public string[] Items
    {
        get { return _Items.ToArray(); }
        set
        {
            _Items = new List<string>(value);
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the the style shape of symbol.")]
    public SymbolStyle SymbolShape
    {
        get { return _SymbolShape; }
        set
        {
            _SymbolShape = value;
            Invalidate();
        }
    }


    #endregion

    #region Draw Control


    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics G = e.Graphics;
        G.SmoothingMode = SmoothingMode.AntiAlias;
        G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

        int _Margin = 5;
        int X = _Margin;
        int Y = _Margin;
        int WidthLength = 0;

        using (SolidBrush SymBrush = new SolidBrush(SymbolColor))
        using (SolidBrush ItemsBrush = new SolidBrush(ItemsColor))
        {
            for (int i = 0; i <= Items.Length - 1; i++)
            {
                SizeF textSize = G.MeasureString(Items[i], Font);
                if (SymbolShape == SymbolStyle.Square)
                {
                    G.SmoothingMode = SmoothingMode.Default;
                    G.FillRectangle(SymBrush, X, Y + 1, SymbolSize, SymbolSize);
                }
                else
                {
                    G.SmoothingMode = SmoothingMode.AntiAlias;
                    G.FillEllipse(SymBrush, X, Y + 1, SymbolSize, SymbolSize);
                }
                
                G.DrawString(Items[i], Font, ItemsBrush, X + SymbolSize + 2, Y + ((SymbolSize / 2) - Convert.ToInt32(textSize.Height / 2)));
                
                Y += Convert.ToInt32(textSize.Height);
                
                if ((textSize.Width + SymbolSize + 2) > WidthLength)
                    WidthLength = Convert.ToInt32(textSize.Width + SymbolSize + 2);
                
                if ((Y + Convert.ToInt32(textSize.Height)) > Height)
                {
                    Y = _Margin;
                    X += WidthLength + SeperateWidth;
                    WidthLength = 0;
                }
            }
        }
   
    }

    #endregion

}


#endregion

#region RichTextBox

[DefaultEvent("TextChanged")]
public class SpinRichTextbox : Control
{

    #region Declarations

    private static readonly HelperMethods H = new HelperMethods();
    private RichTextBox _T = new RichTextBox();
    private RichTextBox T
    {
        get { return _T; }
        set
        {
            if (_T != null)
            {
                _T.SelectionChanged -= T_SelectionChanged;
                _T.SelectionChanged -= T_LinkClicked;
                _T.Protected -= T_Protected;
                _T.TextChanged -= T_TextChanged;
                _T.KeyDown -= T_KeyDown;
                _T.MouseUp -= T_MouseUp;
            }
            _T = value;
            if (_T != null)
            {
                _T.SelectionChanged += T_SelectionChanged;
                _T.SelectionChanged += T_LinkClicked;
                _T.Protected += T_Protected;
                _T.TextChanged += T_TextChanged;
                _T.KeyDown += T_KeyDown;
                _T.MouseUp += T_MouseUp;
            }
        }
    }
    private bool _ReadOnly = false;
    private Color _BackColor = H.GetHTMLColor("262626");
    private Color _ForeColor = H.GetHTMLColor("444444");
    private bool _WordWrap;
    private bool _AutoWordSelection;
    private string[] _Lines = null;
    private Color _BorderColor = H.GetHTMLColor("444444");

    #endregion

    #region Native Methods

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
    private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPWStr)] string lParam);

    #endregion

    #region Properties

    [Category("Custom Properties"), Description("Gets or sets the lines of text in the control.")]
    public string[] Lines
    {
        get { return _Lines; }
        set
        {
            _Lines = value;
            if (T == null)
                return;
            T.Lines = value;
            Invalidate();
        }
    }

    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public BorderStyle BorderStyle
    {
        get
        {
            return BorderStyle.None;
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the background color of the control.")]
    public new Color BackColor
    {
        get { return _BackColor; }
        set
        {
            base.BackColor = value;
            _BackColor = value;
            T.BackColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the border color of the control.")]
    public Color BorderColor
    {
        get { return _BorderColor; }
        set
        {
            _BorderColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the foreground color of the control.")]
    public new Color ForeColor
    {
        get { return _ForeColor; }
        set
        {
            base.ForeColor = value;
            _ForeColor = value;
            T.ForeColor = value;
            Invalidate();
        }
    }

    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new Image[] BackgroundImage
    {
        get { return null; }
    }

    [Category("Custom Properties"), Description("Gets or sets a value indicating whether text in the System.Windows.Forms.ToolStripTextBox is read-only.")]
    public virtual bool ReadOnly
    {
        get { return _ReadOnly; }
        set
        {
            _ReadOnly = value;
            if (T != null)
            {
                T.ReadOnly = value;
            }
        }
    }

    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual bool Multiline
    {
        get { return true; }
    }

    [Category("Custom Properties"), Description("Gets or sets the current text in the Spin RichTextBox.")]
    public new string Text
    {
        get { return T.Text; }
        set
        {
            base.Text = value;
            if (T != null)
            {
                T.Text = value;
            }
        }
    }

    [Category("Custom Properties"), Description("Indicates whether a multiline text box control automatically wraps words to the beginning of the next line when necessary.")]
    public bool WordWrap
    {
        get { return _WordWrap; }
        set
        {
            _WordWrap = value;
            if (T != null)
            {
                T.WordWrap = value;
            }
        }
    }

    [Category("Custom Properties"), Description("Gets or sets a value indicating whether automatic word selection is enabled.")]
    public bool AutoWordSelection
    {
        get { return _AutoWordSelection; }
        set
        {
            _AutoWordSelection = value;
            if (T != null)
            {
                T.AutoWordSelection = value;
            }
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the ContextMenuStrip associated with this control.")]
    public override ContextMenuStrip ContextMenuStrip
    {
        get { return base.ContextMenuStrip; }
        set
        {
            base.ContextMenuStrip = value;
            if (T == null)
                return;
            T.ContextMenuStrip = value;
            Invalidate();
        }
    }

    #endregion

    #region Constructors

    public SpinRichTextbox()
    {
        SetStyle(ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
        DoubleBuffered = true;
        WordWrap = true;
        AutoWordSelection = false;
        Font = new Font("Segoe UI", 10, FontStyle.Regular);
        T.Size = new Size(Width, Height);
        T.Multiline = true;
        T.Cursor = Cursors.IBeam;
        T.BackColor = BackColor;
        T.ForeColor = ForeColor;
        T.BorderStyle = BorderStyle.None;
        T.Location = new Point(7, 5);
        T.Font = Font;
        UpdateStyles();
    }

    #endregion

    #region Events

    public event SelectionChangedEventHandler SelectionChanged;
    public delegate void SelectionChangedEventHandler(object sender, System.EventArgs e);
    public event LinkClickedEventHandler LinkClicked;
    public delegate void LinkClickedEventHandler(object sender, EventArgs e);
    public event ProtectedEventHandler Protected;
    public delegate void ProtectedEventHandler(object sender, System.EventArgs e);
    public new event TextChangedEventHandler TextChanged;
    public delegate void TextChangedEventHandler(object sender);

    private void T_SelectionChanged(object sender, System.EventArgs e)
    {
        SelectionChanged?.Invoke(sender, e);
    }

    private void T_LinkClicked(object sender, System.EventArgs e)
    {
        LinkClicked?.Invoke(sender, e);
    }

    private void T_Protected(object sender, System.EventArgs e)
    {
        Protected?.Invoke(sender, e);
    }

    private void T_TextChanged(object sender, EventArgs e)
    {
        Text = T.Text;
        TextChanged?.Invoke(this);
        Invalidate();
    }

    private void T_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.Control && e.KeyCode == Keys.A)
            e.SuppressKeyPress = true;
        if (e.Control && e.KeyCode == Keys.C)
        {
            T.Copy();
            e.SuppressKeyPress = true;
        }
    }

    protected override void OnCreateControl()
    {
        base.OnCreateControl();
        if (!Controls.Contains(T))
            Controls.Add(T);
    }

    private void T_MouseUp(object sender, MouseEventArgs e)
    {
        if (e.Button == System.Windows.Forms.MouseButtons.Right)
        {
            if (ContextMenuStrip != null)
                ContextMenuStrip.Show(T, new Point(e.X, e.Y));
        }
        Invalidate();
    }

    protected override void OnFontChanged(System.EventArgs e)
    {
        base.OnFontChanged(e);
        T.Font = Font;
    }

    protected override void OnSizeChanged(System.EventArgs e)
    {
        base.OnSizeChanged(e);
        T.Size = new Size(Width - 10, Height - 10);
    }

    public void AppendText(string text)
    {
        if (T != null)
        {
            T.AppendText(text);
        }
    }

    public void Undo()
    {
        if (T != null)
        {
            if (T.CanUndo)
            {
                T.Undo();
            }
        }
    }

    public void Redo()
    {
        if (T != null)
        {
            if (T.CanRedo)
            {
                T.Redo();
            }
        }
    }

    public int GetLineFromCharIndex(int index)
    {
        if (T != null)
        {
            return T.GetLineFromCharIndex(index);
        }
        else
        {
            return 0;
        }
    }

    public System.Drawing.Point GetPositionFromCharIndex(int index)
    {
        if (T != null)
        {
            return T.GetPositionFromCharIndex(index);
        }
        else
        {
            return new Point(0, 0);
        }
    }

    public int GetCharIndexFromPosition(System.Drawing.Point pt)
    {
        if (T == null)
            return 0;
        return T.GetCharIndexFromPosition(pt);
    }

    public void ClearUndo()
    {
        if (T == null)
            return;
        T.ClearUndo();
    }

    public void Copy()
    {
        if (T == null)
            return;
        T.Copy();
    }

    public void Cut()
    {
        if (T == null)
            return;
        T.Cut();
    }

    public void SelectAll()
    {
        if (T == null)
            return;
        T.SelectAll();
    }

    public void DeselectAll()
    {
        if (T == null)
            return;
        T.DeselectAll();
    }

    public void Paste(System.Windows.Forms.DataFormats.Format clipFormat)
    {
        if (T == null)
            return;
        T.Paste(clipFormat);
    }

    public void Select(int start, int length)
    {
        if (T == null)
            return;
        T.Select(start, length);
    }

    public void LoadFile(string path)
    {
        if (T == null)
            return;
        T.LoadFile(path);
    }

    public void LoadFile(string path, System.Windows.Forms.RichTextBoxStreamType fileType)
    {
        if (T == null)
            return;
        T.LoadFile(path, fileType);
    }

    public void LoadFile(System.IO.Stream data, System.Windows.Forms.RichTextBoxStreamType fileType)
    {
        if (T == null)
            return;
        T.LoadFile(data, fileType);
    }

    public void SaveFile(string path)
    {
        if (T == null)
            return;
        T.SaveFile(path);
    }

    public void SaveFile(string path, System.Windows.Forms.RichTextBoxStreamType fileType)
    {
        if (T == null)
            return;
        T.SaveFile(path, fileType);
    }
    public void SaveFile(System.IO.Stream data, System.Windows.Forms.RichTextBoxStreamType fileType)
    {
        if (T == null)
            return;
        T.SaveFile(data, fileType);
    }

    public bool CanPaste(System.Windows.Forms.DataFormats.Format clipFormat)
    {
        return T.CanPaste(clipFormat);
    }

    public int Find(char[] characterSet)
    {
        if (T == null)
            return 0;
        return T.Find(characterSet);
    }

    public int Find(char[] characterSet, int start)
    {
        if (T == null)
            return 0;
        return T.Find(characterSet, start);
    }

    public int Find(char[] characterSet, int start, int ends)
    {
        if (T == null)
            return 0;
        return T.Find(characterSet, start, ends);
    }

    public int Find(string str)
    {
        if (T == null)
            return 0;
        return T.Find(str);
    }

    public int Find(string str, int start, int ends, System.Windows.Forms.RichTextBoxFinds options)
    {
        if (T == null)
            return 0;
        return T.Find(str, start, ends, options);
    }

    public int Find(string str, System.Windows.Forms.RichTextBoxFinds options)
    {
        if (T == null)
            return 0;
        return T.Find(str, options);
    }

    public int Find(string str, int start, System.Windows.Forms.RichTextBoxFinds options)
    {
        if (T == null)
            return 0;
        return T.Find(str, start, options);
    }

    #endregion

    #region Draw Control

    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics G = e.Graphics;
        Rectangle Rect = new Rectangle(0, 0, Width, Height);
        G.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
        using (SolidBrush BG = new SolidBrush(BackColor))
        using (Pen Stroke = H.PenColor(BorderColor))
        {
            G.FillRectangle(BG, Rect);
            G.DrawRectangle(Stroke, new Rectangle(0, 0, Width - 1, Height - 1));
        }
  
    }

    #endregion

}

#endregion

#region Alert

[DefaultEvent("TextChanged")]
public class SpinAlertStyle : Control
{

    #region Declarations

    private static readonly HelperMethods H = new HelperMethods();
    private string _TitleText = "Alert Text";
    private Style _AlertStyle = Style.Blue;
    private Color StyleAlert = H.GetHTMLColor("007aff");
    private int _RoundRadius = 2;
    private Point Loc = new Point(1, 1);

    #endregion

    #region Constructors

    public SpinAlertStyle()
    {
        SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
        DoubleBuffered = true;
        Cursor = Cursors.Arrow;
        BackColor = Color.Transparent;
        Font = new Font("Segoe UI", 9, FontStyle.Regular);
        UpdateStyles();
    }

    #endregion

    #region Properties

    [Category("Custom Properties"), Description("Gets or sets the control title text.")]
    public string TitleText
    {
        get { return _TitleText; }
        set 
        { 
            _TitleText = value;
            Invalidate(); 
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the control alert style.")]
    public Style AlertStyle
    {
        get { return _AlertStyle; }
        set
        {
            _AlertStyle = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets a value indicating whether the control can Rounded in corners.")]
    public int RoundRadius
    {
        get { return _RoundRadius; }
        set
        {
            _RoundRadius = value;
            Invalidate();
        }
    }

    #endregion

    #region Enumerators

    public enum Style
    {
        Blue,
        Orange,
        Green,
        Red
    }

    #endregion

    #region Draw Control

    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics G = e.Graphics;
        GraphicsPath GP = new GraphicsPath();
        Rectangle Rect = new Rectangle(0, 0, Width - 1, Height - 1);

        if (RoundRadius > 0)
        {
            G.SmoothingMode = SmoothingMode.AntiAlias;
            GP = H.RoundRec(Rect, RoundRadius);
        }
        else
        {
            GP.AddRectangle(Rect);
        }

        GP.CloseFigure();

        G.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

        Color CloseColor = H.GetHTMLColor("FF268FD6");
        Color CloseBroderColor = H.GetHTMLColor("FF268FD6");

        switch (AlertStyle)
        {
            case Style.Blue:
                StyleAlert = H.GetHTMLColor("FF2C97DE");
                CloseColor = H.GetHTMLColor("FF247AB4");
                CloseBroderColor = H.GetHTMLColor("FF1D6392");
                break;
            case Style.Orange:
                StyleAlert = H.GetHTMLColor("FFE76D3B");
                CloseColor = H.GetHTMLColor("FFBB5830");
                CloseBroderColor = H.GetHTMLColor("FF974727");
                break;
            case Style.Green:
                StyleAlert = H.GetHTMLColor("FF84B547");
                CloseColor = H.GetHTMLColor(("FF6B933A"));
                CloseBroderColor = H.GetHTMLColor("FF56772F");
                break;
            case Style.Red:
                StyleAlert = H.GetHTMLColor("FFCC3E4A");
                CloseColor = H.GetHTMLColor("FFA6323C");
                CloseBroderColor = H.GetHTMLColor("FF862931");
                break;
        }
        using (SolidBrush BG = new SolidBrush(StyleAlert))
        using (SolidBrush TB = new SolidBrush(Color.White))
        using (Font TTF = new Font("Segoe UI", 10, FontStyle.Bold))
        {
            G.FillPath(BG, GP);
            G.DrawString(TitleText, TTF, TB, new Rectangle(12, 7, Width - 10, 20));
            G.DrawString(Text, Font, TB, 12, G.MeasureString(TitleText, TTF).Height + 11);
        }
       
        G.SmoothingMode = SmoothingMode.AntiAlias;
        using (SolidBrush CloseBGBrush = new SolidBrush(CloseColor))
        using (Pen CloseBorder = H.PenColor(CloseBroderColor))
        using (SolidBrush CloseTextBrush = new SolidBrush(Color.White))
        using (Font CloseFont = new Font("Segoe UI", 7, FontStyle.Bold))
        {
            G.FillEllipse(CloseBGBrush, new Rectangle(Width - 20, 10, 14, 14));
            G.DrawEllipse(CloseBorder, new Rectangle(Width - 20, 10, 14, 14));
            G.DrawString("x", CloseFont, CloseTextBrush, new Rectangle(Width - 19, 10, 14, 14), H.SetPosition());
        }
        GP.Dispose();
    }

    #endregion

    #region Events

    protected override void OnMouseMove(MouseEventArgs e)
    {
        base.OnMouseMove(e);
        Loc = e.Location;
        if (Loc.Y > 10 && Loc.Y < 24 && Loc.X > Width - 20 && Loc.X < Width - 1)
        {
            Cursor = Cursors.Hand;
        }
        else
        {
            Cursor = Cursors.Arrow;
        }
        Invalidate();
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        base.OnMouseDown(e);
        if (Loc.Y > 10 && Loc.Y < 24 && Loc.X > Width - 20 && Loc.X < Width - 1)
        {
            Visible = false;
        }
    }

    #endregion

}

#endregion

#region CircleProgressbar
[DefaultEvent("ValueChanged"), DefaultProperty("Value")]
public class SpinCircleProgressBar : Control
{

    #region Declarations

    private static readonly HelperMethods H = new HelperMethods();
    private Color _ProgressColor = H.GetHTMLColor("FF2C97DE");
    private Color _BaseColor = H.GetHTMLColor("FF353535");
    private Color _ProgressTextColor = Color.White;
    private int _Maximum = 100;
    private int _Value = 0;
    private int _Thickness = 12;
    private bool _ShowProgressValue = true;
    private bool _FillInside = false;
    private Color _InsideColor = H.GetHTMLColor("FF303030");
    private Font _Font = new Font("Segoe UI", 12);
    public event ValueChangedEventHandler ValueChanged;
    public delegate void ValueChangedEventHandler(object sender);
    private LineCap _EndStyle = LineCap.Custom;
    private LineCap _StartStyle = LineCap.Custom;
    private bool _ShowBase = true;

    #endregion

    #region Constructors

    public SpinCircleProgressBar()
    {
        SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
        DoubleBuffered = true;
        UpdateStyles();
        BackColor = Color.Transparent;
        Size = new Size(95, 95);
    }

    #endregion

    #region Properties

    [Category("Custom Properties"), Description("Gets or sets the current position of the CircleProgressBar.")]
    public int Value
    {
        get
        {
            switch (_Value)
            {
                case 0:
                    return 0;
                default:
                    return _Value;
            }
        }
        set
        {
            if (value > Maximum)
            {
                _Value = Maximum;
            }
            _Value = value;
            ValueChanged?.Invoke(this);
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets the Maximum value of the CircleProgressBar.")]
    public int Maximum
    {
        get { return _Maximum; }
        set
        {
            if (value < _Value)
            {
                _Value = Value;
            }
            _Maximum = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the progress color of the CircleProgressBar.")]
    public Color ProgressColor
    {
        get { return _ProgressColor; }
        set
        {
            _ProgressColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the progress text color of the CircleProgressBar.")]
    public Color ProgressTextColor
    {
        get { return _ProgressTextColor; }
        set
        {
            _ProgressTextColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the thickness of the CircleProgressBar.")]
    public virtual int Thickness
    {
        get { return _Thickness; }
        set
        {
            _Thickness = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the basecolor of the CircleProgressBar.")]
    public Color BaseColor
    {
        get { return _BaseColor; }
        set
        {
            _BaseColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets whether the inside of progress be shown or not.")]
    public bool FillInside
    {
        get { return _FillInside; }
        set
        {
            _FillInside = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets whether the base of progress be shown or not.")]
    public bool ShowBase
    {
        get { return _ShowBase; }
        set
        {
            _ShowBase = value;
            Invalidate();
        }
    }
    [Category("Custom Properties"), Description("Gets or sets whether the progress be shown as text or not.")]
    public bool ShowProgressValue
    {
        get { return _ShowProgressValue; }
        set
        {
            _ShowProgressValue = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the inside color of the CircleProgressBar.")]
    public Color InsideColor
    {
        get { return _InsideColor; }
        set
        {
            _InsideColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the font style applied to the calendar.")]
    public override Font Font
    {
        get { return _Font; }
        set
        {
            _Font = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the end shape of progress.")]
    public LineCap EndStyle
    {
        get { return _EndStyle; }
        set
        {
            _EndStyle = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the start shape of progress.")]
    public LineCap StartStyle
    {
        get { return _StartStyle; }
        set
        {
            _StartStyle = value;
            Invalidate();
        }
    }

    #endregion

    #region Draw Control

    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics G = e.Graphics;
        G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
        G.SmoothingMode = SmoothingMode.AntiAlias;

        Rectangle Rect = new Rectangle(5, 5, Width - 10, Height - 10);
        Rectangle PGA = new Rectangle(Convert.ToInt32(Thickness / 2) + 10, Convert.ToInt32(Thickness / 2) + 10, Width - Thickness - 19, Height - Thickness - 19);
        int CurrentValue = (int)Math.Round((double)(3.6 * Value));

        using (Pen BG = H.PenColor(BaseColor, Thickness - 3))
        using (SolidBrush INS = new SolidBrush(InsideColor))
        {
            if (FillInside)
            {
                G.FillEllipse(INS, new Rectangle(33, 33, Width - 66, Height - 66));
            }
            if (ShowBase)
            {
                G.DrawArc(BG, PGA, -90, 360);
            }
        }

        using (Pen PC = new Pen(ProgressColor, Thickness - 2) { StartCap = StartStyle, EndCap = EndStyle })
        using (SolidBrush PT = new SolidBrush(ProgressTextColor))
        {
            if ((CurrentValue != 0))
            {
                G.DrawArc(PC, PGA, -90, CurrentValue);
                if (ShowProgressValue)
                {
                    G.DrawString(Value + "%", Font, PT, Rect, H.SetPosition());
                }
            }
        }

    }

    #endregion

    #region Events
    
    public void Increment(int value)
    {
        Value += value;
    }

    #endregion

}


#endregion

#region Gauge

[DefaultEvent("ValueChanged"), DefaultProperty("Value")]
public class SpinGauge : Control
{

    #region Declarations

    private static readonly HelperMethods H = new HelperMethods();
    private int _Thickness = 20;
    private int _Value = 0;
    public event ValueChangedEventHandler ValueChanged;
    public delegate void ValueChangedEventHandler(object sender);
    private Color _ProgressColor = H.GetHTMLColor("FF2C97DE");
    private Color _BaseColor = H.GetHTMLColor("FF353535");
    private Color _ProgressTextColor = Color.White;
    private LineCap _EndStyle = LineCap.Custom;
    private LineCap _StartStyle = LineCap.Custom;

    #endregion

    #region Constructors

    public SpinGauge()
    {
        SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
        DoubleBuffered = true;
        BackColor = Color.Transparent;
        Font = new Font("Segoe UI", 25, FontStyle.Bold);
        UpdateStyles();
    }

    #endregion

    #region Properties

    [Category("Custom Properties"), Description("Gets or sets the thickness of the gauge.")]
    public int Thickness
    {
        get { return _Thickness; }
        set
        {
            _Thickness = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the current position of the gauge.")]
    public int Value
    {
        get { return _Value; }
        set
        {
            if (value > Maximum)
            {
                _Value = Maximum;
                throw new Exception("The value cannot be more than maximum");
                
            }
            else
            {
                _Value = value;
            }

            ValueChanged?.Invoke(this);
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets the Maximum value of the gauge.")]
    public int Maximum
    {
        get { return 100; }
    }


    [Category("Custom Properties"), Description("Gets or sets the progress color of the gauge.")]
    public Color ProgressColor
    {
        get { return _ProgressColor; }
        set
        {
            _ProgressColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the progress text color of the gauge.")]
    public Color ProgressTextColor
    {
        get { return _ProgressTextColor; }
        set
        {
            _ProgressTextColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the basecolor of the gauge.")]
    public Color BaseColor
    {
        get { return _BaseColor; }
        set
        {
            _BaseColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the end shape of gauge.")]
    public LineCap EndStyle
    {
        get { return _EndStyle; }
        set
        {
            _EndStyle = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the start shape of gauge.")]
    public LineCap StartStyle
    {
        get { return _StartStyle; }
        set
        {
            _StartStyle = value;
            Invalidate();
        }
    }

    #endregion

    #region Draw Control

    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics G = e.Graphics;
        G.SmoothingMode = SmoothingMode.AntiAlias;
        G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

        int num = Width - Thickness * 2;

        Rectangle R = new Rectangle(Thickness, Thickness, num, num);

        using (SolidBrush PTC = new SolidBrush(ProgressTextColor))
        {
            G.DrawString(Value.ToString() + "%", Font, PTC, R, H.SetPosition());
        }

        using (Pen BG = new Pen(BaseColor, Thickness) { StartCap = StartStyle, EndCap = EndStyle })
        {
            G.DrawArc(BG, R, 170f, 200f);
        }

        using (Pen PC = new Pen(ProgressColor, Thickness) { StartCap = StartStyle, EndCap = EndStyle })
        {
            if (num != 0)
            {
                G.DrawArc(PC, R, 170f, Convert.ToSingle(Math.Round(Convert.ToDouble(Value) * 200.0 / 100.0, 0)));
            }
        }

    }

    #endregion

}

#endregion

#region ToolTip
public class SpinToolTip : ToolTip , INotifyPropertyChanged 
{

	#region Declarations
    
    private static readonly HelperMethods H = new HelperMethods();
    private Color _BackColor = SystemColors.Window;
    private Color _BorderColor = Color.Gray;
	private string errIMG = "iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAALGPC/xhBQAAAAlwSFlzAAAOwgAADsIBFShKgAAAABh0RVh0U29mdHdhcmUAcGFpbnQubmV0IDQuMC45bDN+TgAAANBJREFUOE+tkrEVwyAMRN2m8whsklW8SbxB2CTexGyQUQjfkhLLgBunuPfE3UlIgiHnXON+iwVrQVYQP1teT0jiW5OWgllBDIfmCu2Tk5pIGPcm1UfVpCPlTeRmhOmbIDxcCR03KR85QwQlZmcUc11AeOskcLDbW233CjAOWuTA7EtlEmO7gGgsdjVT3b6YzgpsY/ylQH+EM8gIiaC/xB4OS7z4jEJc+Eg/wb7yo6D3ldHwJOOPJusEvApIAMTGbzcbfAEgO6GQdQSI4YL35+ED+tuFv78OZr4AAAAASUVORK5CYII=";
	private string excIMG = "iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAAYdEVYdFNvZnR3YXJlAHBhaW50Lm5ldCA0LjAuNvyMY98AAADNSURBVDhPnZJdDcMwDIQNYRAGYRAGYRACZSTyXiYrg4VBC6EMMsc/SZy407SHT7LvXN0pKuScz4mwIi/XE1yRiBCQLAT3BnFFIsKOHMLm3iCuSImc/BROW0wCwenlo4tQZrfFJOChpi+dtog2tTAL0dKvSELeMrstzIIHNp1nHGl2W9SB6NN5Lw2SzDfxTIs6oKHpa6eVH2ncTQs22NT0e9VGije0UGNOZ50f0WqmhYqa/hiO2xs0TcOoRS/s5vAbLTD0yz9sWtMzfwDSB4MxskcE6XapAAAAAElFTkSuQmCC";
	private string infIMG = "iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAALGPC/xhBQAAAAlwSFlzAAAOwgAADsIBFShKgAAAABh0RVh0U29mdHdhcmUAcGFpbnQubmV0IDQuMC45bDN+TgAAANNJREFUOE+lktENwjAMRDtCR8hoIAahG5BN6Bj8tRt0lOBX2ZC4sUDw8aTk7uw4bYZSyoHz45KFRSgK61sv22wkROGmRbMwKazR8JpGdfGqIQrGOqT+qN4+kelmcjLGyYwIMprN7BGSClMnjC7Lg26TpPr03thRA66Dl9lw99mHPkGNsNgp4fjgPaAGL2ygoa8ahFcgAF4Haqhl8fdH7P5G1V447/0bVfj9IVWGPeWrED1lPDKr6T5kk8BdoABYm76fbDQNQAJ8ExrZRMAaLbX5MjwByiSlG0FA+zcAAAAASUVORK5CYII=";

	#endregion

	#region Properties

    public new Color BackColor
    {
        get { return _BackColor; }
	    set
	    {
	        _BackColor = value;

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BackColor"));
        }
	}

    public Color BorderColor
    {
        get { return _BorderColor; }
        set
        {
            _BorderColor = value;

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BorderColor"));
        }
    }
    
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public new bool IsBalloon { get; set; }

	#endregion

    #region Events

	    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        public delegate void PropertyChangedEventHandler(object sender, PropertyChangedEventArgs e);

		#endregion

	#region Draw Control

	private void OnDraw(object sender, DrawToolTipEventArgs e)
	{
        Graphics G = e.Graphics;
        G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
        G.InterpolationMode = InterpolationMode.HighQualityBicubic;

        using (SolidBrush BG = new SolidBrush(BackColor))
        {
            G.FillRectangle(BG, e.Bounds);
        }

        string Icon = "";
        SolidBrush B = H.SolidBrushHTMlColor("FF61C863");
        Rectangle IconRect = new Rectangle(5, 5, 16, 16);
        Point TitleTipRect = new Point(IconRect.X, e.Bounds.Y);
        Font F = new Font("Segoe UI", 9, FontStyle.Bold);

        switch (ToolTipIcon)
        {
            case ToolTipIcon.None:
                Icon = "";
                B = H.SolidBrushHTMlColor("0056AD");
                TitleTipRect = new Point(5, 1);
                break;
            case ToolTipIcon.Warning:
                Icon = excIMG;
                B = H.SolidBrushHTMlColor("FFFF9500");
                TitleTipRect = new Point(20, e.Bounds.Y + 3);
                break;
            case ToolTipIcon.Info:
                Icon = infIMG;
                B = H.SolidBrushHTMlColor("FF61C863");
                TitleTipRect = new Point(20, e.Bounds.Y + 3);
                break;
            case ToolTipIcon.Error:
                Icon = errIMG;
                B = H.SolidBrushHTMlColor("FFFF3F09");
                TitleTipRect = new Point(20, e.Bounds.Y + 3);
                break;
        }

        if (Icon != "")
        {
            H.DrawImageFromBase64(G, Icon, IconRect);
        }
        using (Font F2 = new Font("Segoe UI", 9))
        if (ToolTipTitle !="")
        {
            G.DrawString(ToolTipTitle, F, B, TitleTipRect);
            G.DrawString(e.ToolTipText,F2 , H.SolidBrushHTMlColor("B2B2B2"), new PointF(TitleTipRect.X + 1, e.Graphics.MeasureString(ToolTipTitle, F).Height + 1));
        }
        else
        {
            G.DrawString(e.ToolTipText, F2, H.SolidBrushHTMlColor("B2B2B2"), TitleTipRect);
        }

        using (Pen Stroke = new Pen(BorderColor))
        {
            G.DrawRectangle(Stroke, new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width - 1, e.Bounds.Height - 1));
        }
        F.Dispose();
        B.Dispose();

	}
	
	#endregion

    #region Constructors

    public SpinToolTip()
    {
        Draw += OnDraw;
        OwnerDraw = true;
    }
#endregion

}



#endregion

#region Range

[DefaultEvent("RangeChanged")]
public class SpinRange : Control
{

	#region Declarations
    
    private static readonly HelperMethods H = new HelperMethods();
	private int _MinRange;
	private int _MaxRange;
	private int _MaximumRange = 100;
	private Rectangle RangeValue;
    private CustomControl Track = new CustomControl();
    private CustomControl Track2 = new CustomControl();
	private Color _BaseColor = H.GetHTMLColor("FF353535");
	private Color _RangeColor = H.GetHTMLColor("FF2C97DE");
	private Color _RangeTextColor = Color.White;
	public event RangeChangedEventHandler RangeChanged;
	public delegate void RangeChangedEventHandler(object sender);

	#endregion

	#region Properties

	[Category("Custom Properties"), Description("Gets or sets the upper limit of the range.")]
	public int MaximumRange 
    {
		get { return _MaximumRange; }
		set 
        {
			_MaximumRange = value;
			MaxRange = value * Track2.Left / (Width - 15);
			MinRange = value * Track.Left / (Width - 15);
			RenewCurrentValue();
            RangeChanged?.Invoke(this);
        }
	}

	[Category("Custom Properties"), Description("Gets or sets the upper limit value of the range.")]
	public int MaxRange 
    {
		get { return _MaxRange; }
		set 
        {
			if (value > MaximumRange)
				throw new Exception("Maximum Value Reached");
			_MaxRange = value;
			Track2.Left = (Width - 18) * _MaxRange / MaximumRange;
			if (Track2.Left < Track.Left) 
            {
				Track2.Left = Track2.Left;
				throw new Exception("Maximum Value Reached");
			}
			RenewCurrentValue();
            RangeChanged?.Invoke(this);
            Track2.Text = value.ToString();
		}
	}

	[Category("Custom Properties"), Description("Gets or sets the lower limit value of the range.")]
	public int MinRange 
    {
		get { return _MinRange; }
		set 
        {
			if (value > _MaximumRange)
				throw new Exception("Minmium Value Reached");
			_MinRange = value;
			Track.Left = (Width - 15) * _MinRange / _MaximumRange;
			if (Track.Left > Track2.Left) 
            {
				Track.Left = Track.Left;
				throw new Exception("Minmium Value Reached");
			}
			RenewCurrentValue();
            RangeChanged?.Invoke(this);
            Track.Text = value.ToString();
		}
	}

	[Category("Custom Properties"), Description("Gets or sets the control color.")]
	public Color BaseColor 
    {
		get { return _BaseColor; }
		set 
        {
			_BaseColor = value;
			Invalidate();
		}
	}

	[Category("Custom Properties"), Description("Gets or sets the range and range handler color.")]
	public Color RangeColor 
    {
		get { return _RangeColor; }
		set 
        {
			_RangeColor = value;
			Track.BaseColor = value;
			Track2.BaseColor = value;
			Invalidate();
		}
	}

	[Category("Custom Properties"), Description("Gets or sets the range text color.")]
	public Color RangeTextColor 
    {
		get { return _RangeTextColor; }
		set 
        {
			_RangeTextColor = value;
			Track.TextColor = value;
			Track2.TextColor = value;
			Invalidate();
		}
	}

	#endregion

	#region Constructors

	public SpinRange()
	{
		SetStyle(ControlStyles.SupportsTransparentBackColor, true);
	    DoubleBuffered = true;
		SetDefaults();
		BackColor = Color.Transparent;
		Size = new Size(300, 20);
		MaxRange = MaximumRange * Track2.Left / (Width - 15);
		MinRange = MaximumRange * Track.Left / (Width - 15);
		UpdateStyles();
	    RangeValue = new Rectangle(MinRange, Convert.ToInt32(5.5), MaxRange, 8);
		RenewCurrentValue();
	}
	public void SetDefaults()
	{
	    Track.MouseMove += Track_MouseMove;
        Track.Size = new Size(18, 18);
        Track.Location = new Point(0, 1);
        Track.TabIndex = 1;
        Track.Text = MinRange.ToString();
        Track2.MouseMove += Track2_MouseMove;
        Track2.Size = new Size(18, 18);
        Track2.Location = new Point(195, 1);
        Track2.TabIndex = 2;
        Track2.Text = MaxRange.ToString();
	}

	#endregion

	#region Events

	protected override void OnResize(EventArgs e)
	{
		base.OnResize(e);
		Height = 20;
	}

	protected override void OnCreateControl()
	{
		base.OnCreateControl();
		Controls.Add(Track);
		Controls.Add(Track2);
		Invalidate();
	}

	private void Track2_MouseMove(object sender, MouseEventArgs e)
	{
		if (e.Button == MouseButtons.Left) 
        {
            if (e.X + Track2.Right == MaxRange)
				return;
			int num = e.X + Track2.Left;
			if (num > Track.Left && num + Track2.Width - 1 < Width) 
            {
				Track2.Left = num;
				RenewCurrentValue();
				MaxRange = (MaximumRange * Track2.Left) / (Width - 18);
			}
		}
	}

	private void Track_MouseMove(object sender, MouseEventArgs e)
	{
		if (e.Button == MouseButtons.Left) 
        {
            if (e.X + Track.Left == MinRange)
				return;
			int num = e.X + Track.Left;
			if (num < Track2.Left && num > -1 && num + Track.Width < Width) 
            {
				Track.Left = num;
				RenewCurrentValue();
				MinRange = MaximumRange * Track.Left / (Width - 15);
			}
		}
	}

	public void RenewCurrentValue()
	{
		RangeValue.X = Track.Left + Track.Width / 2;
		RangeValue.Width = Track2.Left + Track2.Width / 2 - RangeValue.Left;
	}

	#endregion

	#region Draw Control

	protected override void OnPaint(PaintEventArgs e)
	{
		Graphics G = e.Graphics;
		using (SolidBrush BG = new SolidBrush(BaseColor)) 
        using (SolidBrush RC = new SolidBrush(RangeColor)) 
        using (SolidBrush RTC = new SolidBrush(RangeTextColor))
        {
            G.FillRectangle(BG, new Rectangle(0, Convert.ToInt32(5.5), Width, 8));
            G.FillRectangle(RC, RangeValue);
            G.DrawString(MinRange.ToString(), Font, RTC, new Rectangle(Track.Left, Track.Top, Track.Width, Track.Height), H.SetPosition());
        }
	}


	#endregion

	#region Custom Control

	public sealed class CustomControl : Control
	{

		#region Declarations

		private Color _BaseColor = H.GetHTMLColor("FF2C97DE");
		private Color _TextColor = Color.White;

		#endregion

		#region Constructors

		public CustomControl()
		{
			SetStyle(ControlStyles.SupportsTransparentBackColor, true);
			DoubleBuffered = true;
			Cursor = Cursors.Hand;
			UpdateStyles();
		}

		#endregion

		#region Properties

		public Color BaseColor 
        {
			get { return _BaseColor; }
			set 
            {
				_BaseColor = value;
				Invalidate();
			}
		}
		public Color TextColor 
        {
			get { return _TextColor; }
			set 
            {
				_TextColor = value;
				Invalidate();
			}
		}

		#endregion

		#region Draw Control

		protected override void OnPaint(PaintEventArgs e)
		{
			Graphics G = e.Graphics;
			G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

			Rectangle R = new Rectangle(0, 0, Width, Height);

		    using (SolidBrush BG = new SolidBrush(BaseColor))
            using (SolidBrush TC = new SolidBrush(TextColor))
            using (Font F = new Font("Arial", 6))
		    {
                G.FillRectangle(BG, R);
                H.CentreString(G, Text, F, TC, R);
		    }
		}

		#endregion

	}

	#endregion

}

#endregion

#region Indicator

public class SpinIndicator : Control
{

    #region Declarations

    private static readonly HelperMethods H = new HelperMethods();
    private int _CircleNumbers = 8;
    private Color _CirclesBorderColor = H.GetHTMLColor("FF2C97DE");
    private Color _CirclesColor = H.GetHTMLColor("FF2B90D2");
    private double _CircleSize = 2.0;
    private double _Increment = 1.0;
    private Timer T = new Timer();
    private int CurrentCircle = 0;

#endregion

    #region Constructors

    public SpinIndicator()
    {
        T.Enabled = false;
        SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
        DoubleBuffered = true;
        BackColor = Color.Transparent;
        Width = 100;
        Height = 100;
        UpdateStyles();
        T.Interval = 100;
        T.Tick += T_Tick;
    }

    #endregion

    #region Draw Control

    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics G = e.Graphics;
        G.SmoothingMode = SmoothingMode.HighQuality;
        int Length = Math.Min(Width, Height);
        float Radius = ((Length / 2) - CircleSize) - ((CircleNumbers - 1) * Increment);
        float Angle = 360 / CircleNumbers;
        CurrentCircle++;
        CurrentCircle = (CurrentCircle >= CircleNumbers) ? 0 : CurrentCircle;
        using (SolidBrush B = new SolidBrush(CirclesColor))
        using (Pen P = H.PenColor(CirclesBorderColor, 1f))
        {
            int CircleIndex = 0;
            int num = CurrentCircle + (CircleNumbers - 1);
            for (int i = CurrentCircle; i <= num; i++)
            {
                int factor = i % CircleNumbers;
                Point pO = new Point(Length / 2, Length / 2);
                float left  = pO.X + (float) (Radius * Math.Cos(Angle * factor * Math.PI / 180));
                float top  = pO.Y + (float) (Radius * Math.Sin(Angle * factor * Math.PI / 180));
                float CurrentCycle = CircleSize + CircleIndex*Increment;
                Point c1 = new Point((int)(left - CurrentCycle), (int)(top - CurrentCycle));
                G.FillEllipse(B, (float) c1.X, (float) c1.Y, 2f * CurrentCycle, 2f * CurrentCycle);
                G.DrawEllipse(P, (float) c1.X, (float) c1.Y, 2f * CurrentCycle, 2f * CurrentCycle);
                CircleIndex++;
            }
        }
    
    }

    #endregion

    #region Events

    protected override void OnVisibleChanged(EventArgs e)
    {
        T.Enabled = Visible;
        base.OnVisibleChanged(e);
    }

    private void T_Tick(object sender, EventArgs e)
    {
        Invalidate();
    }

#endregion

    #region Properties

    [Category("Custom Properties"), Description("Gets or sets the number of circles.")]
    public int CircleNumbers
    {
        get
        {
            return _CircleNumbers;
        }
        set
        {
            _CircleNumbers = (value >= 2) ? value : 2;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the speed of rotation.")]
    public int Speed
    {
        get
        {
            return T.Interval;
        }
        set
        {
            T.Interval=value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the number of circles.")]
    public Color CirclesBorderColor
    {
        get
        {
            return _CirclesBorderColor;
        }
        set
        {
            _CirclesBorderColor = value;
            Invalidate();
        }
    }

    [Description("Gets or sets the number of circles."), Category("Custom Properties")]
    public Color CirclesColor
    {
        get
        {
            return _CirclesColor;
        }
        set
        {
            _CirclesColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the control circles size.")]
    public float CircleSize
    {
        get
        {
            return (float) _CircleSize;
        }
        set
        {
            _CircleSize = (value >= 1f) ? ((double) value) : ((double) 1f);
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the control animation speed.")]
    public float Increment
    {
        get
        {
            return (float) _Increment;
        }
        set
        {
            _Increment = (value >= 0f) ? ((double) value) : ((double) 0f);
            Invalidate();
        }
    }

#endregion

}

#endregion

#region StatusStrip

public class SpinStatusStrip : StatusStrip
{

	#region Declarations
    
    private static readonly HelperMethods H = new HelperMethods();
	private Color _LineColor = H.GetHTMLColor("FF151515");
	private Color _BackColor = H.GetHTMLColor("FF1A1A1A");
	private Color _ForeColor = Color.Silver;

	#endregion

	#region Constructors

	public SpinStatusStrip()
	{
		AutoSize = false;
		Padding = new Padding(0, 5, 0, 3);
		Size = new Size(Size.Width, 28);
		SizingGrip = false;
	}

	#endregion

	#region Properties

	[Category("Custom Properties"), Description("Gets or sets the header line color of Spin StatusStrip.")]
	public Color LineColor 
    {
		get { return _LineColor; }
		set 
        {
			_LineColor = value;
			Invalidate();
		}
	}

	[Category("Custom Properties"), Description("Gets or sets the background color of the control.")]
    public new Color BackColor
    {
		get { return _BackColor; }
		set 
        {
			_BackColor = value;
			Invalidate();
		}
	}

	[Category("Custom Properties"), Browsable(true), Description("Gets or sets the foreground color of the control.")]
    public new Color ForeColor
    {
		get { return _ForeColor; }
		set 
        {
			_ForeColor = value;
			Invalidate();
		}
	}

	#endregion

	#region Draw Control

	protected override void OnPaintBackground(PaintEventArgs e)
	{
        Graphics G = e.Graphics;
        Rectangle R = new Rectangle(0, 0, Width, Height);
        using (SolidBrush B = new SolidBrush(BackColor)) 
        using (Pen P = H.PenColor(LineColor)) 
        {
            G.FillRectangle(B, R);
            G.DrawLine(P, R.Left, 0, R.Right, 0);
        }
    }

	#endregion

	#region Events

	protected override void OnItemAdded(ToolStripItemEventArgs e)
	{
		e.Item.BackColor = BackColor;
		e.Item.ForeColor = ForeColor;
		base.OnItemAdded(e);
	}

	#endregion

}


#endregion

#region Paginator

[DefaultEvent("SelectedIndexChanged")]
public class SpinPaginator : Control
{

    #region Declarations

    private static readonly HelperMethods H = new HelperMethods();
    private int _ItemsWidth = 30;
    private Color _SelectedItem = H.GetHTMLColor("FF2C97DE");
    private List<Item> _Items = new List<Item>();
    private int _SelectedIndex;
    private Color _BorderColor = H.GetHTMLColor("FF1A1A1A");
    private Color _BaseColor = H.GetHTMLColor("FF212121");
    public event SelectedIndexChangedEventHandler SelectedIndexChanged;

    public delegate void SelectedIndexChangedEventHandler(object sender);

    #endregion

    #region Constructors

    public SpinPaginator()
    {
        SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
        DoubleBuffered = true;
        UpdateStyles();
        BackColor = Color.Transparent;
        Font = new Font("Segoe UI", 10);
    }

    #endregion

    #region Properties

    [Category("Custom Properties"), Description("Gets the collection of the items contained in control.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content),
     TypeConverter(typeof(CollectionConverter))]
    public Item[] Items
    {
        get { return _Items.ToArray(); }
        set
        {
            _Items = new List<Item>(value);
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the index specifying the currently selected item.")]
    public int SelectedIndex
    {
        get { return _SelectedIndex; }
        set
        {
            _SelectedIndex = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the width of each item in control items.")]
    public int ItemsWidth
    {
        get { return _ItemsWidth; }
        set
        {
            _ItemsWidth = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the background color of the control.")]
    public Color BaseColor
    {
        get { return _BaseColor; }
        set
        {
            _BaseColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the background lines color of the control.")]
    public Color BorderColor
    {
        get { return _BorderColor; }
        set
        {
            _BorderColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the selected item color of the control.")]
    public Color SelectedItem
    {
        get { return _SelectedItem; }
        set
        {
            _SelectedItem = value;
            Invalidate();
        }
    }

    #endregion

    #region Draw Control

    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics G = e.Graphics;

        G.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

        Rectangle R = new Rectangle(0, 0, Width - 1, Height - 1);

        using (SolidBrush B = new SolidBrush(BaseColor))
        using (Pen P = H.PenColor(BorderColor))
        {
            G.FillRectangle(B, R);
            G.DrawRectangle(P, R);
        }

        using (SolidBrush SB = new SolidBrush(SelectedItem))
        {
            G.FillRectangle(SB,new Rectangle((SelectedIndex*ItemsWidth) + 1, 1, (int) Math.Round((double) (ItemsWidth - 1.5)),Height - 2));
        }

        for (int i = 0; i <= Items.Length - 1; i++)
        {
            using (SolidBrush BG = new SolidBrush(_Items[i].ItemColor))
            {
                SizeF textSize = G.MeasureString(Items[i].Text, Font);
                int X = (i*ItemsWidth) + ((ItemsWidth/2) - (Convert.ToInt32(textSize.Width)/2));
                int Y = (Height/2) - (Convert.ToInt32(textSize.Height)/2);
                G.DrawString(Items[i].Text, Font, BG, X, Y);
            }
        }

        using (Pen P = H.PenColor(BorderColor))
        {
            for (int i = 1; i <= Items.Length; i++)
            {
                G.DrawLine(P, i*ItemsWidth, 1, i*ItemsWidth, Height - 2);
            }
        }

    }

    #endregion

    #region Events

    protected override void OnMouseDown(MouseEventArgs e)
    {
        base.OnMouseDown(e);
        _SelectedIndex = PointToClient(Cursor.Position).X/_ItemsWidth;
        Invalidate();
        SelectedIndexChanged?.Invoke(this);
    }

    #endregion

    #region Child Class

    [DefaultEvent("PropertyChanged")]
    public sealed class Item : INotifyPropertyChanged
    {

        #region Declarations

        private string _Text;
        private Color _ItemColor = Color.White;
        private string _ItemHexColor = ColorTranslator.ToHtml(Color.White);

        #endregion

        #region Events

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        public delegate void PropertyChangedEventHandler(object sender, PropertyChangedEventArgs e);

        #endregion

        #region Properties

        [Category("Apperance")]
        public string Text
        {
            get { return _Text; }
            set
            {
                _Text = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Text"));
            }
        }


        [Category("Apperance")]
        public Color ItemColor
        {
            get { return _ItemColor; }
            set
            {
                _ItemColor = value;
                try
                {
                    ItemHexColor = ColorTranslator.ToHtml(value);
                }
                catch
                {
                }
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ItemColor"));
            }
        }


        [Category("Apperance")]
        public string ItemHexColor
        {
            get { return _ItemHexColor; }
            set
            {
                _ItemHexColor = value;
                try
                {
                    _ItemColor = ColorTranslator.FromHtml(value);
                }
                catch
                {
                }
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ItemHexColor"));
            }
        }

  

    #endregion
  }

#endregion
}

#endregion

#region DatePicker

[DefaultEvent("ValueChanged"), DefaultProperty("Value")]
public class SpinDatePicker : Control
{

    #region Declarations

    private static readonly HelperMethods H = new HelperMethods();
    private HelperMethods.MouseMode State;
    private int _RoundRadius = 5;
    private bool _IsEnabled = true;
    private Color _NormalColor = H.GetHTMLColor("FF2C97DE");
    private Color _NormalBorderColor = H.GetHTMLColor("FF2B90D2");
    private Color _NormalTextColor = Color.White;
    private Color _HoverColor = H.GetHTMLColor("8dd42e");
    private Color _HoverBorderColor = H.GetHTMLColor("83ae48");
    private Color _HoverTextColor = Color.White;
    private Color _PushedColor = H.GetHTMLColor("548710");
    private Color _PushedBorderColor = H.GetHTMLColor("83ae48");
    private Color _PushedTextColor = Color.White;
    public event ValueChangedEventHandler ValueChanged;
    public delegate void ValueChangedEventHandler(object sender, EventArgs e);
    private static DateTimePicker DTP = new DateTimePicker();
    private DateTimePickerFormat _Format = DTP.Format;
    private DateTime _value = DTP.Value;
    private string _Text = DTP.Value.ToLongDateString();
    private string _CustomFormat = string.Empty;
    private DateTime _MinTime = DTP.MinDate;
    private DateTime _MaxTime = DTP.MaxDate;
    private string ima = "iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAGXRFWHRTb2Z0d2FyZQBBZG9iZSBJbWFnZVJlYWR5ccllPAAAA2ZpVFh0WE1MOmNvbS5hZG9iZS54bXAAAAAAADw/eHBhY2tldCBiZWdpbj0i77u/IiBpZD0iVzVNME1wQ2VoaUh6cmVTek5UY3prYzlkIj8+IDx4OnhtcG1ldGEgeG1sbnM6eD0iYWRvYmU6bnM6bWV0YS8iIHg6eG1wdGs9IkFkb2JlIFhNUCBDb3JlIDUuMC1jMDYxIDY0LjE0MDk0OSwgMjAxMC8xMi8wNy0xMDo1NzowMSAgICAgICAgIj4gPHJkZjpSREYgeG1sbnM6cmRmPSJodHRwOi8vd3d3LnczLm9yZy8xOTk5LzAyLzIyLXJkZi1zeW50YXgtbnMjIj4gPHJkZjpEZXNjcmlwdGlvbiByZGY6YWJvdXQ9IiIgeG1sbnM6eG1wTU09Imh0dHA6Ly9ucy5hZG9iZS5jb20veGFwLzEuMC9tbS8iIHhtbG5zOnN0UmVmPSJodHRwOi8vbnMuYWRvYmUuY29tL3hhcC8xLjAvc1R5cGUvUmVzb3VyY2VSZWYjIiB4bWxuczp4bXA9Imh0dHA6Ly9ucy5hZG9iZS5jb20veGFwLzEuMC8iIHhtcE1NOk9yaWdpbmFsRG9jdW1lbnRJRD0ieG1wLmRpZDoyMUJDRjc3RDYyMDRFMjExOEI4OEMwODMzOTc4RjA1OCIgeG1wTU06RG9jdW1lbnRJRD0ieG1wLmRpZDo1NjQxM0NBMzA2RTgxMUUyQjcyMUREMEFFQ0Q1ODM2RSIgeG1wTU06SW5zdGFuY2VJRD0ieG1wLmlpZDo1NjQxM0NBMjA2RTgxMUUyQjcyMUREMEFFQ0Q1ODM2RSIgeG1wOkNyZWF0b3JUb29sPSJBZG9iZSBQaG90b3Nob3AgQ1M1LjEgV2luZG93cyI+IDx4bXBNTTpEZXJpdmVkRnJvbSBzdFJlZjppbnN0YW5jZUlEPSJ4bXAuaWlkOkJCRTUzRUFDRTYwNkUyMTFBOTQ5RkEyRUM0RTE2OTk4IiBzdFJlZjpkb2N1bWVudElEPSJ4bXAuZGlkOjIxQkNGNzdENjIwNEUyMTE4Qjg4QzA4MzM5NzhGMDU4Ii8+IDwvcmRmOkRlc2NyaXB0aW9uPiA8L3JkZjpSREY+IDwveDp4bXBtZXRhPiA8P3hwYWNrZXQgZW5kPSJyIj8+6176IgAAAIJJREFUeNpiYEAFlxgIAxQ1TEC8F4j/Q/n8UPo/DoyuZi+yYg+ohAceAzDUMCKZTBZgYqAQsCCxGUnU+58qLmDCZzoQ+KEFYh0uxf9xGAADzED8BIi1sOkjxgBXID6DzWJiwyAWiBfjC01CLgDZLopNH3JCGphopEpS3kGB/h0AAQYAttk0iWEdTHUAAAAASUVORK5CYII=";

    #endregion

    #region Constructors

    public SpinDatePicker()
    {
        SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
        DoubleBuffered = true;
        BackColor = Color.Transparent;
        Font = new Font("Segoe UI", 14, FontStyle.Regular);
        DTP.Location = new Point(55, Height - 1);
        DTP.Size = Size;
        DTP.ValueChanged += DTP_ValueChanged;
        Controls.Add(DTP);
        UpdateStyles();
    }

    #endregion

    #region Properties

    [Category("Custom Properties"), Description("Gets or sets a value indicating whether the control can Rounded in corners.")]
    public int RoundRadius
    {
        get { return _RoundRadius; }
        set
        {
            _RoundRadius = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets a value indicating whether the control can respond to user interaction.")]
    public bool IsEnabled
    {
        get { return _IsEnabled; }
        set
        {
            Enabled = value;
            _IsEnabled = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the the control color in normal mouse state.")]
    public Color NormalColor
    {
        get { return _NormalColor; }
        set
        {
            _NormalColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the the control border color in normal mouse state.")]
    public Color NormalBorderColor
    {
        get { return _NormalBorderColor; }
        set
        {
            _NormalBorderColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the the control Text color in normal mouse state.")]
    public Color NormalTextColor
    {
        get { return _NormalTextColor; }
        set
        {
            _NormalTextColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the the control color in hover mouse state.")]
    public Color HoverColor
    {
        get { return _HoverColor; }
        set
        {
            _HoverColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the the control border color in hover mouse state.")]
    public Color HoverBorderColor
    {
        get { return _HoverBorderColor; }
        set
        {
            _HoverBorderColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the the control Text color in hover mouse state.")]
    public Color HoverTextColor
    {
        get { return _HoverTextColor; }
        set
        {
            _HoverTextColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the the control color in mouse down state.")]
    public Color PushedColor
    {
        get { return _PushedColor; }
        set
        {
            _PushedColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the the control border color in mouse down state.")]
    public Color PushedBorderColor
    {
        get { return _PushedBorderColor; }
        set
        {
            _PushedBorderColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the the control Text color in mouse down state.")]
    public Color PushedTextColor
    {
        get { return _PushedTextColor; }
        set
        {
            _PushedTextColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties")]
    [Description("Gets or sets the maximum date and time that can be selected in the control.")]
    public DateTime MaxDate
    {
        get { return _MaxTime; }
        set
        {
            _MaxTime = value;
            DTP.MaxDate = value;
            Invalidate();
        }
    }

    [Category("Custom Properties")]
    [Description("Gets or sets the minimum date and time that can be selected in the control.")]
    public DateTime MinDate
    {
        get { return _MinTime; }
        set
        {
            _MinTime = value;
            DTP.MinDate = value;
            Invalidate();
        }
    }

    [Category("Custom Properties")]
    [Description("Gets or sets the date/time value assigned to the control.")]
    public DateTime Value
    {
        get { return _value; }
        set
        {
            if (value > MaxDate || value < MinDate)
                return;
            _value = value;
            DTP.Value = _value;
            Text = DTP.Value.ToString();
            Invalidate();
        }
    }

    [Category("Custom Properties")]
    [Description("Gets or sets the custom date/time format string.")]
    public string CustomFormat
    {
        get { return _CustomFormat; }
        set
        {
            _CustomFormat = value;
            DTP.CustomFormat = value;
            Invalidate();
        }
    }

    [Category("Custom Properties")]
    [Description("Gets or sets the format of the date and time displayed in the control.")]
    public DateTimePickerFormat Format
    {
        get { return _Format; }
        set
        {
            _Format = value;
            DTP.Format = value;
            if (value == DateTimePickerFormat.Long)
            {
                Text = DTP.Value.ToLongDateString();
            }
            else if (value == DateTimePickerFormat.Short)
            {
                Text = DTP.Value.ToShortDateString();
            }
            else if (value == DateTimePickerFormat.Time)
            {
                Text = DTP.Value.ToLongTimeString();
            }
            else if (value == DateTimePickerFormat.Custom)
            {
                _CustomFormat = MaxDate.ToString();
                Text = DTP.Value.ToString();
            }
            Invalidate();
        }
    }

    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public override string Text
    {
        get { return _Text; }
        set
        {
            _Text = value;
            Invalidate();
        }
    }


    #endregion

    #region Draw Control

    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics G = e.Graphics;
        GraphicsPath GP = new GraphicsPath();
        Rectangle Rect = new Rectangle(0, 0, Width - 1, Height - 1);

        if (RoundRadius > 0)
        {
            G.SmoothingMode = SmoothingMode.AntiAlias;
            GP = H.RoundRec(Rect, RoundRadius);
        }
        else
        {
            GP.AddRectangle(Rect);
        }

        GP.CloseFigure();

        G.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

        switch (State)
        {

            case HelperMethods.MouseMode.Normal:

                using (SolidBrush BG = new SolidBrush(NormalColor))
                using (Pen P = new Pen(NormalBorderColor))
                {
                    G.FillPath(BG, GP);
                    G.DrawPath(P, GP);
                }

                using (SolidBrush B = new SolidBrush(NormalTextColor))
                {
                    H.CentreString(G, Text, Font, B, new Rectangle(0, 0, Width, Height));
                }

                G.SmoothingMode = SmoothingMode.AntiAlias;

                H.DrawTriangle(G, NormalTextColor, Convert.ToInt32(1.5), new Point(Width - 20, 14), new Point(Width - 16, 18), new Point(Width - 16, 18), new Point(Width - 12, 14), new Point(Width - 16, 19), new Point(Width - 16, 18));
                H.DrawImageWithColor(G, new Rectangle(10, Height / 4, 16, 16), H.ImageFromBase64(ima), NormalTextColor);

                break;
            case HelperMethods.MouseMode.Hovered:

                Cursor = Cursors.Hand;

                using (SolidBrush BG = new SolidBrush(HoverColor))
                using (Pen P = new Pen(HoverBorderColor))
                {
                    G.FillPath(BG, GP);
                    G.DrawPath(P, GP);
                }


                using (SolidBrush B = new SolidBrush(HoverTextColor))
                {
                    H.CentreString(G, Text, Font, B, new Rectangle(0, 0, Width, Height));
                }

                G.SmoothingMode = SmoothingMode.AntiAlias;

                H.DrawTriangle(G, HoverTextColor, Convert.ToInt32(1.5), new Point(Width - 20, 14), new Point(Width - 16, 18), new Point(Width - 16, 18), new Point(Width - 12, 14), new Point(Width - 16, 19), new Point(Width - 16, 18));
                H.DrawImageWithColor(G, new Rectangle(10, Height / 4, 16, 16), H.ImageFromBase64(ima), HoverTextColor);

                break;
            case HelperMethods.MouseMode.Pushed:

                using (SolidBrush BG = new SolidBrush(PushedColor))
                using (Pen P = new Pen(PushedBorderColor))
                {
                    G.FillPath(BG, GP);
                    G.DrawPath(P, GP);
                }


                using (SolidBrush B = new SolidBrush(PushedTextColor))
                {
                    H.CentreString(G, Text, Font, B, new Rectangle(0, 0, Width, Height));
                }

                G.SmoothingMode = SmoothingMode.AntiAlias;

                H.DrawTriangle(G, PushedTextColor, Convert.ToInt32(1.5), new Point(Width - 20, 14), new Point(Width - 16, 18), new Point(Width - 16, 18), new Point(Width - 12, 14), new Point(Width - 16, 19), new Point(Width - 16, 18));
                H.DrawImageWithColor(G, new Rectangle(10, Height / 4, 16, 16), H.ImageFromBase64(ima), PushedTextColor);

                break;
        }

    }

    #endregion

    #region Events

    private void DTP_ValueChanged(object sender, EventArgs e)
    {
        Text = DTP.Value.ToLongDateString();
        _value = DTP.Value;
        ValueChanged?.Invoke(this, e);
    }

    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        Size = new Size(330, 32);
    }

    protected override void OnClick(EventArgs e)
    {
        DTP.Select();
        SendKeys.Send("%{DOWN}");
        base.OnClick(e);
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
        base.OnMouseUp(e);
        State = HelperMethods.MouseMode.Hovered;
        Invalidate();
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        base.OnMouseDown(e);
        State = HelperMethods.MouseMode.Pushed;
        Invalidate();
    }

    protected override void OnMouseEnter(EventArgs e)
    {
        base.OnMouseEnter(e);
        State = HelperMethods.MouseMode.Hovered;
        Invalidate();
    }

    protected override void OnMouseLeave(EventArgs e)
    {
        base.OnMouseEnter(e);
        State = HelperMethods.MouseMode.Normal;
        Invalidate();
    }

    #endregion

}


#endregion

#region Signal

[DefaultProperty("Value")]
public class SpinSignal : Control
{

    #region Declarations

    private static readonly HelperMethods H = new HelperMethods();
    private Color _FilledColor = H.GetHTMLColor("FF2C97DE");
    private Color _UnFilledColor = H.GetHTMLColor("FF353535");
    private int _Value = 3;

    #endregion

    #region Constructors

    public SpinSignal()
    {
        SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
        DoubleBuffered = true;
        BackColor = Color.Transparent;
        UpdateStyles();
    }

    #endregion

    #region Properties

    [Category("Custom Properties"), Description("Gets or sets the control signal color whenever filled.")]
    public Color FilledColor
    {
        get { return _FilledColor; }
        set
        {
            _FilledColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the control signal color whenever un-filled.")]
    public Color UnFilledColor
    {
        get { return _UnFilledColor; }
        set
        {
            _UnFilledColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the number of Singal to be fill.")]
    public int Value
    {
        get { return _Value; }
        set
        {
            if (value > 5)
                throw new Exception("The maximum value is 5.");
            _Value = value;
            Invalidate();
        }
    }

    #endregion

    #region Draw Control

    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics G = e.Graphics;
        Rectangle R1 = new Rectangle(2, (int)(Height / 1.2), (int)(Width / 8.0), Height);
        Rectangle R2 = new Rectangle((int)(Width - (Width) / 1.3), (int)(Height / 1.5), (int)(Width / 8.0), Height);
        Rectangle R3 = new Rectangle((int)(Width - (Width) / 1.8), (int)(Height / 2.1), (int)(Width / 8.0), Height);
        Rectangle R4 = new Rectangle((int)(Width - (Width) / 2.9), (int)(Height / 4.0), (int)(Width / 8.0), Height);
        Rectangle R5 = new Rectangle((int)(Width - (Width) / 8.0), 1, (int)(Width / 8.0), Height);

        using (SolidBrush UFC = new SolidBrush(UnFilledColor))
        {
            G.FillRectangles(UFC, new Rectangle[] {R1,R2,R3,R4,R5});
        }

        using (SolidBrush FC = new SolidBrush(FilledColor))
        {

            if (Value == 1)
            {
                G.FillRectangles(FC, new Rectangle[] { R1 });
            }
            else if (Value == 2)
            {
                G.FillRectangles(FC, new Rectangle[] { R1,R2 });
            }
            else if (Value == 3)
            {
                G.FillRectangles(FC, new Rectangle[] {R1,R2,R3});
            }
            else if (Value == 4)
            {
                G.FillRectangles(FC, new Rectangle[] {R1,R2,R3,R4});
            }
            else if (Value == 5)
            {
                G.FillRectangles(FC, new Rectangle[] {R1,R2,R3,R4,R5});
            }

        }

    }

    #endregion

}

#endregion

#region SpinCard

[DefaultEvent("OnClicked")]
public class SpinCard : Control
{

    #region Declarations

    private static readonly HelperMethods H = new HelperMethods();
    private Image _Image = null;
    private string _TitleText = "Small Title";
    private string _ContentText = "Card Content is here";
    private string _ButtonText = "Okey";
    private Color _BaseColor = H.GetHTMLColor("FF212121");
    private Color _ThumbnailColor = H.GetHTMLColor("F5232323");
    private Color _FilledColor = H.GetHTMLColor("FF2C97DE");
    private Color _BorderColor = H.GetHTMLColor("FF151515");
    private Color _ButtonColor = H.GetHTMLColor("FF2C97DE");
    private Color _TitleColor = H.GetHTMLColor("FF2C97DE");
    private Color _ContentColor = H.GetHTMLColor("5c5c5c");
    private Font _Font = new Font("Segoe UI", 8);
    private Rectangle R;

    #endregion

    #region Properties

    [Category("Custom Properties"), Description("Gets or sets the background color.")]
    public Color BaseColor
    {
        get { return _BaseColor; }
        set
        {
            _BaseColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the background border color.")]
    public Color BorderColor
    {
        get { return _BorderColor; }
        set
        {
            _BorderColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the text title color.")]
    public Color TitleColor
    {
        get { return _TitleColor; }
        set
        {
            _TitleColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the text content color.")]
    public Color ContentColor
    {
        get { return _ContentColor; }
        set
        {
            _ContentColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the info text color.")]
    public string TitleText
    {
        get { return _TitleText; }
        set
        {
            _TitleText = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the info text color.")]
    public string ContentText
    {
        get { return _ContentText; }
        set
        {
            _ContentText = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the button color.")]
    public Color ButtonColor
    {
        get { return _ButtonColor; }
        set
        {
            _ButtonColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the button text.")]
    public string ButtonText
    {
        get { return _ButtonText; }
        set
        {
            _ButtonText = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the thumbnail image.")]
    public Image Image
    {
        get { return _Image; }
        set
        {
            _Image = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the font of the text displayed by the control.")]
    public override Font Font
    {
        get { return _Font; }
        set
        {
            _Font = value;
            Invalidate();
        }
    }

    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public override Color ForeColor
    {
        get { return Color.Transparent; }
    }

    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public override Color BackColor
    {
        get { return Color.Transparent; }
    }

    [Category("Custom Properties"), Description("Gets or sets the thumbnail background color.")]
    public Color ThumbnailColor
    {
        get { return _ThumbnailColor; }
        set
        {
            _ThumbnailColor = value;
            Invalidate();
        }
    }

    #endregion

    #region Events

    public event OnClickedEventHandler OnClicked;
    public delegate void OnClickedEventHandler(object sender, EventArgs e);

    protected override void OnMouseMove(MouseEventArgs e)
    {
        if (R.Contains(e.Location))
        {
            Cursor = Cursors.Hand;
        }
        else
        {
            Cursor = Cursors.Arrow;
        }
        base.OnMouseMove(e);
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        base.OnMouseDown(e);
        if (R.Contains(e.Location))
        {
            OnClicked?.Invoke(this, null);
        }
    }

    protected override void OnTextChanged(EventArgs e)
    {
        base.OnTextChanged(e);
        Invalidate();
    }

    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        Size = new Size(240, 295);
    }

    #endregion

    #region Constructors

    public SpinCard()
    {
        SetStyle(ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
        DoubleBuffered = true;
    }


    #endregion

    #region Draw Control


    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics G = e.Graphics;

        using (SolidBrush BG = new SolidBrush(BaseColor))
        using (SolidBrush TTC = new SolidBrush(TitleColor))
        using (SolidBrush CTC = new SolidBrush(ContentColor))
        using (Pen PC = new Pen(BorderColor))
        using (SolidBrush BTC = new SolidBrush(ButtonColor))
        using (SolidBrush THC = new SolidBrush(ThumbnailColor))
        {

            G.FillRectangle(BG, new Rectangle(0, 0, Width - 1, Height - 1));

            G.DrawString(TitleText, Font, TTC, 12, 176);

            G.DrawString(ContentText, Font, CTC, 12, 202);

            G.SmoothingMode = SmoothingMode.AntiAlias;

            using (LinearGradientBrush LGB = new LinearGradientBrush(new Rectangle(45, 235, Width - 90, 235), Color.Empty,Color.Empty, 0f))
            {

                ColorBlend B = new ColorBlend();
                B.Colors = new Color[]
                {
                    Color.Transparent,
                    BorderColor,
                    BorderColor,
                    Color.Transparent
                };
                B.Positions = new float[]
                {
                    0f,
                    0.15f,
                    0.85f,
                    1f
                };
                LGB.InterpolationColors = B;
                using (Pen PGB = new Pen(LGB))
                {
                    G.DrawLine(PGB, 45, 235, Width - 45, 235);
                    G.DrawLine(PC, new Point(16, 240), new Point(Width - 16, 240));
                    G.DrawLine(PGB, new Point(45, 245), new Point(Width - 45, 245));
                }
            }

            R = new Rectangle(Width - 82, 250, Width - 175, 35);

            G.DrawString(ButtonText, Font, BTC, R, H.SetPosition());

            G.FillRectangle(THC, new Rectangle(0, 0, Width - 1, 166));

            if (Image != null)
                G.DrawImage(Image, 1, 1, Width - 2, 166);

            G.DrawLine(PC, new Point(1, 166), new Point(Width - 2, 166));
            G.DrawRectangle(PC, new Rectangle(0, 0, Width - 1, Height - 1));
        }


    }

    #endregion

}

#endregion

#region ColorBox

[DefaultProperty("Text")]
public class SpinColorBox : Control
{

    #region Declarations

    private static readonly HelperMethods H = new HelperMethods();
    private Rectangle ControlRectangle;
    private Point _LocatedPosition = new Point(-1, -1);
    private Color _ChosenColor = H.GetHTMLColor("FF2C97DE");
    private string _Text = H.GetHTMLColor("FF2C97DE").ToString();
    private Rectangle TextRectangle;
    private Color _BaseColor = H.GetHTMLColor("262626");
    private Color _ControlAreaColor = H.GetHTMLColor("303030");
    private Color _BorderColor = H.GetHTMLColor("444444");
    private Color _TextColor = Color.White;

    #endregion

    #region Constructors

    public SpinColorBox()
    {
        SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
        DoubleBuffered = true;
        UpdateStyles();
        BackColor = Color.Transparent;
        Font = new Font("Segoe UI", 10);
    }

    #endregion

    #region Properties

    [Category("Custom Properties"), Description("Gets or sets the text of the hex color that chosen by the user.")]
    public override string Text
    {
        get { return _Text; }
        set
        {
            _Text = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the color that chosen by the user.")]
    public Color ChosenColor
    {
        get { return _ChosenColor; }
        set
        {
            _ChosenColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the control color.")]
    public Color BaseColor
    {
        get { return _BaseColor; }
        set
        {
            _BaseColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the Border color of the control.")]
    public Color BorderColor
    {
        get { return _BorderColor; }
        set
        {
            _BorderColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the ControlAreaColor color.")]
    public Color ControlAreaColor
    {
        get { return _ControlAreaColor; }
        set
        {
            _ControlAreaColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the control text color.")]
    public Color TextColor
    {
        get { return _TextColor; }
        set
        {
            _TextColor = value;
            Invalidate();
        }
    }

    #endregion

    #region Draw Control

    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics G = e.Graphics;
        Rectangle R = new Rectangle(0, 0, Width - 1, Height - 1);
        G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
        ControlRectangle = new Rectangle(10, 7, 20, Height - 14);
        using (SolidBrush B = new SolidBrush(BaseColor))
        using (Pen P = new Pen(BorderColor))
        using (SolidBrush CR = new SolidBrush(ControlAreaColor))
        using (SolidBrush CCS = new SolidBrush(ChosenColor))
        using (SolidBrush TC = new SolidBrush(TextColor))
        using (StringFormat SF = new StringFormat { LineAlignment = StringAlignment.Center })
        {
            G.FillRectangle(B, R);
            G.FillRectangle(CR, new Rectangle(0, 0, 40, Height - 1));
            G.FillRectangle(CCS, ControlRectangle);
            G.DrawLine(P, 40, 0, 40, Height - 1);
            G.DrawString(Text, Font, TC, new RectangleF(45, 0, Width - 46, Height - 1),SF);
            G.DrawRectangle(P, R);
        }

        SizeF TextSize = G.MeasureString(Text, Font);
        TextRectangle = new Rectangle((int)(TextSize.Width / 1.5), (int)(TextSize.Height - (TextSize.Height - 1f)), (int)(TextSize.Width + 1f), (int)(TextSize.Height));

    }

    #endregion

    #region Events

    protected override void OnMouseMove(MouseEventArgs e)
    {
        _LocatedPosition = e.Location;
        if (ControlRectangle.Contains(_LocatedPosition) || TextRectangle.Contains(_LocatedPosition))
        {
            Cursor = Cursors.Hand;
        }
        else
        {
            Cursor = Cursors.Default;
        }
        Invalidate();
        base.OnMouseMove(e);
    }

    protected override void OnMouseLeave(EventArgs e)
    {
        _LocatedPosition = new Point(-1, -1);
        Cursor = Cursors.Default;
        Invalidate();
        base.OnMouseLeave(e);
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        if (ControlRectangle.Contains(_LocatedPosition))
        {
            if (e.Button == MouseButtons.Left)
            {
                ColorDialog CD = new ColorDialog
                {
                    AnyColor = true,
                    AllowFullOpen = true,
                    FullOpen = true
                };
                if (CD.ShowDialog() == DialogResult.OK)
                {
                    ChosenColor = CD.Color;
                    Text = ColorTranslator.ToHtml(CD.Color);
                }
            }
        }
        else if (TextRectangle.Contains(_LocatedPosition))
        {
            Clipboard.SetText(Text);
            MessageBox.Show("The color copied to clipboard.", "SpinColorBox");
        }
        base.OnMouseDown(e);
    }

    #endregion

}


#endregion

#region DatePick

[DefaultEvent("ValueChanged"), DefaultProperty("Text")]
public class SpinDatePick : Control
{

    #region Declarations

    private static readonly HelperMethods H = new HelperMethods();
    private Rectangle ControlRectangle;
    private Point _LocatedPosition = new Point(-1, -1);
    private Rectangle TextRectangle;
    private Color _BaseColor = H.GetHTMLColor("262626");
    private Color _ControlAreaColor = H.GetHTMLColor("303030");
    private Color _BorderColor = H.GetHTMLColor("444444");
    private Color _TextColor = Color.White;
    public event ValueChangedEventHandler ValueChanged;
    public delegate void ValueChangedEventHandler(object sender, EventArgs e);
    private static DateTimePicker DTP = new DateTimePicker();
    private DateTimePickerFormat _Format = DTP.Format;
    private DateTime _value = DTP.Value;
    private string _Text = DTP.Value.ToLongDateString();
    private string _CustomFormat = string.Empty;
    private DateTime _MinTime = DTP.MinDate;
    private DateTime _MaxTime = DTP.MaxDate;
    private string ima = "iVBORw0KGgoAAAANSUhEUgAAADAAAAAwCAYAAABXAvmHAAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAALEwAACxMBAJqcGAAAAO5JREFUaIHtmlsKgzAURI/SpXQRxZ20WrrvalfgYwv2Qz80CNFoGVPugYCEZLzD1clPYDtPoBlHHrDf5QV0QAsUB+h5aYB+HPUBet1ErwkRyIByIhLLqIAsGYu/hjg/AVXC4CZaUnUBe7kszCWePW7HfOt9bNWbrY++AyEG2slzUOw5dHv13HjykTPkfw3cQ17oUDAUXgOPFetn9S6l0N5v+tfYP3AqojdgJ7GaNSdxf9J54A86YAbUWAqpsRRSYwbUWAqpsRRSYwbUWAqpsRRSYwbUWAqpsRRSYwbUWAqpSYGPuogdlBDvZY83cPsCvhSsdFGimCEAAAAASUVORK5CYII=";

    #endregion

    #region Constructors

    public SpinDatePick()
    {
        SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
        DoubleBuffered = true;
        UpdateStyles();
        BackColor = Color.Transparent;
        Font = new Font("Segoe UI", 14);
        DTP.Location = new Point(55, Height - 1);
        DTP.Size = Size;
        DTP.ValueChanged += DtpValueChanged;
        Controls.Add(DTP);
    }

    #endregion

    #region Properties

    [Category("Custom Properties")]
    [Description("Gets or sets the maximum date and time that can be selected in the control.")]
    public DateTime MaxDate
    {
        get { return _MaxTime; }
        set
        {
            _MaxTime = value;
            DTP.MaxDate = value;
            Invalidate();
        }
    }

    [Category("Custom Properties")]
    [Description("Gets or sets the minimum date and time that can be selected in the control.")]
    public DateTime MinDate
    {
        get { return _MinTime; }
        set
        {
            _MinTime = value;
            DTP.MinDate = value;
            Invalidate();
        }
    }

    [Category("Custom Properties")]
    [Description("Gets or sets the date/time value assigned to the control.")]
    public DateTime Value
    {
        get { return _value; }
        set
        {
            if (value > MaxDate || value < MinDate)
                return;
            _value = value;
            DTP.Value = _value;
            Text = DTP.Value.ToString();
            Invalidate();
        }
    }

    [Category("Custom Properties")]
    [Description("Gets or sets the custom date/time format string.")]
    public string CustomFormat
    {
        get { return _CustomFormat; }
        set
        {
            _CustomFormat = value;
            DTP.CustomFormat = value;
            Invalidate();
        }
    }

    [Category("Custom Properties")]
    [Description("Gets or sets the format of the date and time displayed in the control.")]
    public DateTimePickerFormat Format
    {
        get { return _Format; }
        set
        {
            _Format = value;
            DTP.Format = value;
            if (value == DateTimePickerFormat.Long)
            {
                Text = DTP.Value.ToLongDateString();
            }
            else if (value == DateTimePickerFormat.Short)
            {
                Text = DTP.Value.ToShortDateString();
            }
            else if (value == DateTimePickerFormat.Time)
            {
                Text = DTP.Value.ToLongTimeString();
            }
            else if (value == DateTimePickerFormat.Custom)
            {
                _CustomFormat = MaxDate.ToString();
                Text = DTP.Value.ToString();
            }
            Invalidate();
        }
    }

    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public override string Text
    {
        get { return _Text; }
        set
        {
            _Text = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the control color.")]
    public Color BaseColor
    {
        get { return _BaseColor; }
        set
        {
            _BaseColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the Border color of the control.")]
    public Color BorderColor
    {
        get { return _BorderColor; }
        set
        {
            _BorderColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the ControlAreaColor color.")]
    public Color ControlAreaColor
    {
        get { return _ControlAreaColor; }
        set
        {
            _ControlAreaColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the control text color.")]
    public Color TextColor
    {
        get { return _TextColor; }
        set
        {
            _TextColor = value;
            Invalidate();
        }
    }

    #endregion

    #region Draw Control

    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics G = e.Graphics;
        Rectangle R = new Rectangle(0, 0, Width - 1, Height - 1);
        G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
        G.InterpolationMode = InterpolationMode.HighQualityBicubic;
        G.CompositingQuality = CompositingQuality.HighQuality;

        ControlRectangle = new Rectangle(10, 6, 20, Height - 12);

        using (SolidBrush B = new SolidBrush(BaseColor))
        using (Pen P = new Pen(BorderColor))
        using (SolidBrush CR = new SolidBrush(ControlAreaColor))
        using (SolidBrush TC = new SolidBrush(TextColor))
        using (StringFormat SF = new StringFormat { LineAlignment = StringAlignment.Center })
        {
            G.FillRectangle(B, R);
            G.FillRectangle(CR, new Rectangle(0, 0, 40, Height - 1));
            H.DrawImageWithColor(G, ControlRectangle, H.ImageFromBase64(ima), TextColor);
            G.DrawLine(P, 40, 0, 40, Height - 1);
            G.DrawString(Text, Font, TC, new RectangleF(45, 0, Width - 46, Height - 1),SF);
            G.DrawRectangle(P, R);
        }

        SizeF TextSize = G.MeasureString(Text, Font);
        TextRectangle = new Rectangle((int)(TextSize.Width / 1.5), (int)(TextSize.Height - (TextSize.Height - 1f)), (int)(TextSize.Width + 1f), (int)(TextSize.Height));

    }

    #endregion

    #region Events
    private void DtpValueChanged(object sender, EventArgs e)
    {
        Text = DTP.Value.ToLongDateString();
        _value = DTP.Value;
        ValueChanged?.Invoke(this, e);
    }
    protected override void OnMouseMove(MouseEventArgs e)
    {
        _LocatedPosition = e.Location;
        if (ControlRectangle.Contains(_LocatedPosition) || TextRectangle.Contains(_LocatedPosition))
        {
            Cursor = Cursors.Hand;
        }
        else
        {
            Cursor = Cursors.Default;
        }
        Invalidate();
        base.OnMouseMove(e);
    }

    protected override void OnMouseLeave(EventArgs e)
    {
        _LocatedPosition = new Point(-1, -1);
        Cursor = Cursors.Default;
        Invalidate();
        base.OnMouseLeave(e);
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        if (ControlRectangle.Contains(_LocatedPosition))
        {
            if (e.Button == MouseButtons.Left)
            {
                DTP.Select();
                SendKeys.Send("%{DOWN}");
            }
        }
        else if (TextRectangle.Contains(_LocatedPosition))
        {
            Clipboard.SetText(Text);
            MessageBox.Show("The color copied to clipboard.", "SpinColorBox");
        }
        base.OnMouseDown(e);
    }
    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        Size = new Size(330, 32);
    }
    #endregion

}


#endregion

#region DialogBox

[DefaultProperty("Text")]
public class SpinDialogBox : Control
{

    #region Declarations

    private static readonly HelperMethods H = new HelperMethods();
    private Rectangle ControlRectangle;
    private Point _LocatedPosition = new Point(-1, -1);
    private Color _TextColor = Color.White;
    private Color _BaseColor = H.GetHTMLColor("262626");
    private Color _BorderColor = H.GetHTMLColor("444444");
    private Color _ControlColor = H.GetHTMLColor("303030");
    private string _Text;
    private Rectangle TextRectangle;
    private Dialogs _DialogType = Dialogs.OpenFileDialog;

    #endregion

    #region Constructors

    public SpinDialogBox()
    {
        SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
        DoubleBuffered = true;
        UpdateStyles();
        BackColor = Color.Transparent;
        Font = new Font("Segoe UI", 10);
    }

    #endregion

    #region Properties

    [Category("Custom Properties"), Description("Gets or sets the text of the control.")]
    public override string Text
    {
        get { return _Text; }
        set
        {
            _Text = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the text color of the control.")]
    public Color TextColor
    {
        get { return _TextColor; }
        set
        {
            _TextColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the background color of the control.")]
    public Color BaseColor
    {
        get { return _BaseColor; }
        set
        {
            _BaseColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the border color of the control.")]
    public Color BorderColor
    {
        get { return _BorderColor; }
        set
        {
            _BorderColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the controlling area color of the control.")]
    public Color ControlColor
    {
        get { return _ControlColor; }
        set
        {
            _ControlColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the dialog type.")]
    public Dialogs DialogType
    {
        get { return _DialogType; }
        set
        {
            _DialogType = value;
            Invalidate();
        }
    }

    #endregion

    #region Draw Control

    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics G = e.Graphics;
        Rectangle R = new Rectangle(0, 0, Width - 1, Height - 1);
        G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
        ControlRectangle = new Rectangle(Width - 40, 7, Width - 20, Height - 14);
        using (SolidBrush B = new SolidBrush(BaseColor))
        using (Pen P = new Pen(BorderColor))
        using (SolidBrush CR = new SolidBrush(ControlColor))
        using (SolidBrush TC = new SolidBrush(TextColor))
        {
            G.FillRectangle(B, R);
            G.FillRectangle(CR, new Rectangle(Width - 60, 0, Width - 20, Height - 1));
            G.DrawLine(P, Width - 60, 0, Width - 60, Height - 1);
            G.DrawString(Text, Font, TC, new RectangleF(4, 0, Width - 46, Height - 1), H.SetPosition(StringAlignment.Near));
            G.DrawRectangle(P, R);

            switch (DialogType)
            {
                case Dialogs.FontDialog:
                    G.DrawString("Font", Font, TC, new RectangleF(Width - 60, 0, 60, Height - 2),
                        H.SetPosition());
                    break;
                case Dialogs.FolderBrowserDialog:
                    G.DrawString("Folder", Font, TC, new RectangleF(Width - 60, 0, 60, Height - 2),
                        H.SetPosition());
                    break;
                case Dialogs.OpenFileDialog:
                    G.DrawString("File", Font, TC, new RectangleF(Width - 60, 0, 60, Height - 2),
                        H.SetPosition());
                    break;
            }
        }
    }

    #endregion

    #region Enumerators

    public enum Dialogs
    {
        FolderBrowserDialog,
        FontDialog,
        OpenFileDialog
    }

    #endregion

    #region Events

    protected override void OnMouseMove(MouseEventArgs e)
    {
        _LocatedPosition = e.Location;
        if (ControlRectangle.Contains(_LocatedPosition) || TextRectangle.Contains(_LocatedPosition))
        {
            Cursor = Cursors.Hand;
        }
        else
        {
            Cursor = Cursors.Default;
        }
        Invalidate();
        base.OnMouseMove(e);
    }

    protected override void OnMouseLeave(EventArgs e)
    {
        _LocatedPosition = new Point(-1, -1);
        Cursor = Cursors.Default;
        Invalidate();
        base.OnMouseLeave(e);
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        if (ControlRectangle.Contains(_LocatedPosition))
        {
            if (e.Button == MouseButtons.Left)
            {
                using (FontDialog FD = new FontDialog())
                using (FolderBrowserDialog FBD = new FolderBrowserDialog())
                using (OpenFileDialog OFD = new OpenFileDialog())
                {
                    if (DialogType == Dialogs.FontDialog)
                    {
                        if (FD.ShowDialog() == DialogResult.OK)
                            Text = FD.Font.Name;
                    }
                    else if (DialogType == Dialogs.FolderBrowserDialog)
                    {
                        if (FBD.ShowDialog() == DialogResult.OK)
                            Text = FBD.SelectedPath;
                    }
                    else if (DialogType == Dialogs.OpenFileDialog)
                    {
                        if (OFD.ShowDialog() == DialogResult.OK)
                            Text = OFD.FileName;
                    }
                }

            }
        }
        base.OnMouseDown(e);
    }

    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        Height = 32;
    }

    #endregion

}


#endregion

#region SmallCard

public class SpinSmallCard : Control
{

    #region Declarations

    private static readonly HelperMethods H = new HelperMethods();
    private Image _Image = null;
    private string _ContentText = "Content";
    private Color _TitleColor = H.GetHTMLColor("FF2C97DE");
    private Color _ThumbnailColor = H.GetHTMLColor("F5232323");
    private string _TitleText = "SmallCard Title";
    private Color _ContentColor = H.GetHTMLColor("999999");
    private Color _BaseColor = H.GetHTMLColor("FF212121");
    private Color _BorderColor = H.GetHTMLColor("FF151515");
    private int _ThumbnailWidth = 50;
    private Font _Font = new Font("Segoe UI", 9);

    #endregion

    #region Properties

    [Category("Custom Properties"), Description("Gets or sets the thumbnail image.")]
    public Image Image
    {
        get { return _Image; }
        set
        {
            _Image = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the thumbnail background color.")]
    public Color ThumbnailColor
    {
        get { return _ThumbnailColor; }
        set
        {
            _ThumbnailColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the background color.")]
    public Color BaseColor
    {
        get { return _BaseColor; }
        set
        {
            _BaseColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the background border color.")]
    public Color BorderColor
    {
        get { return _BorderColor; }
        set
        {
            _BorderColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the text content color.")]
    public Color ContentColor
    {
        get { return _ContentColor; }
        set
        {
            _ContentColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the text title color.")]
    public Color TitleColor
    {
        get { return _TitleColor; }
        set
        {
            _TitleColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the info text color.")]
    public string TitleText
    {
        get { return _TitleText; }
        set
        {
            _TitleText = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the info text color.")]
    public string ContentText
    {
        get { return _ContentText; }
        set
        {
            _ContentText = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the font of the text displayed by the control.")]
    public override Font Font
    {
        get { return _Font; }
        set
        {
            _Font = value;
            Invalidate();
        }
    }

    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public override Color ForeColor
    {
        get { return Color.Transparent; }
    }

    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public override Color BackColor
    {
        get { return Color.Transparent; }
    }

    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public override string Text
    {
        get { return null; }
    }

    [Category("Custom Properties"), Description("Gets or sets the thumbnail area width.")]
    public int ThumbnailWidth
    {
        get { return _ThumbnailWidth; }
        set
        {
            _ThumbnailWidth = value;
            Invalidate();
        }
    }

    #endregion

    #region Events

    protected override void OnTextChanged(EventArgs e)
    {
        base.OnTextChanged(e);
        Invalidate();
    }
    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        Height = 52;
    }

    #endregion

    #region Constructors

    public SpinSmallCard()
    {
        SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        Size = new Size(140, 182);
        DoubleBuffered = true;
        UpdateStyles();
    }

    #endregion

    #region Draw Control

    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics G = e.Graphics;
        G.InterpolationMode = InterpolationMode.HighQualityBicubic;
        G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
        Rectangle ThumbnailBG = new Rectangle(1, 1, ThumbnailWidth, 49);
        Rectangle BGC = new Rectangle(1, 1, Width - 3, Height - 3);

        using (SolidBrush BG = new SolidBrush(BaseColor))
        using (Pen PG = new Pen(BorderColor))
        using (SolidBrush THC = new SolidBrush(ThumbnailColor))
        using (SolidBrush TTC = new SolidBrush(TitleColor))
        using (SolidBrush CC = new SolidBrush(ContentColor))
        {
            G.FillRectangle(BG, BGC);
            G.DrawRectangle(PG, BGC);
            G.FillRectangle(THC, ThumbnailBG);
            G.DrawString(TitleText, Font, TTC, ThumbnailBG.Width + 10, 7);
            G.DrawRectangle(PG, ThumbnailBG);
            if (Image != null)
            {G.DrawImage(Image, ThumbnailBG.X + 2, 3, 48, 47);}
            G.DrawString(ContentText, Font, CC, ThumbnailBG.Width + 10, 28);
        }


    }

    #endregion

}

#endregion

#region Metro Panel

public class SpinMetroPanel : ContainerControl
{

    #region Declarations

    private static readonly HelperMethods H = new HelperMethods();
    private Color _BaseColor = Color.FromArgb(30, 30, 30);
    private Color _BorderColor = Color.Silver;
    private Color _LineColor = Color.FromArgb(0, 164, 240);
    private string _HeadLine = "HeadLine";
    private LinePositions _LinePosition = LinePositions.Left;
    private int _HeadersLeftPadding = 15;
    private int _LineWidth = 3;
    private int _HeadersTopPadding = 15;
    private Color _HeaderColor = Color.Silver;
    private Color _ContentColor = Color.Silver;
    private int _ContentPadding = 11;
    private Font _HeadLineFont = new Font("Segoe UI Light", 14.0f);

    #endregion

    #region Properties

    [Category("Custom Properties"), Description("Gets or sets the background color.")]
    public Color BaseColor
    {
        get { return _BaseColor; }
        set
        {
            _BaseColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the background Border color.")]
    public Color BorderColor
    {
        get { return _BorderColor; }
        set
        {
            _BorderColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the Line color.")]
    public Color LineColor
    {
        get { return _LineColor; }
        set
        {
            _LineColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the headline color.")]
    public Color HeaderColor
    {
        get { return _HeaderColor; }
        set
        {
            _HeaderColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the content color.")]
    public Color ContentColor
    {
        get { return _ContentColor; }
        set
        {
            _ContentColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the left padding.")]
    public int HeadersLeftPadding
    {
        get { return _HeadersLeftPadding; }
        set
        {
            _HeadersLeftPadding = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the top padding.")]
    public int HeadersTopPadding
    {
        get { return _HeadersTopPadding; }
        set
        {
            _HeadersTopPadding = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the top content padding.")]
    public int ContentPadding
    {
        get { return _ContentPadding; }
        set
        {
            _ContentPadding = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the line width.")]
    public int LineWidth
    {
        get { return _LineWidth; }
        set
        {
            _LineWidth = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets wether headline be shown or not.")]
    public string HeadLine
    {
        get { return _HeadLine; }
        set
        {
            _HeadLine = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets panel line position.")]
    public LinePositions LinePosition
    {
        get { return _LinePosition; }
        set
        {
            _LinePosition = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets HeadLine Font.")]
    public Font HeadLineFont
    {
        get { return _HeadLineFont; }
        set
        {
            _HeadLineFont = value;
            Invalidate();
        }
    }

    #endregion

    #region Constructors

    public SpinMetroPanel()
    {
        SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
        DoubleBuffered = true;
        UpdateStyles();
        Font = new Font("Segoe UI", 9f);
    }

    #endregion

    #region Draw Control

    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics G = e.Graphics;
        G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
        Rectangle MainRect = new Rectangle(0, 0, Width - 1, Height - 1);
        Rectangle LineRect = new Rectangle(0, 1, LineWidth, Height - 2);

        if (LinePosition == LinePositions.Left)
        {
            LineRect = new Rectangle(0, 1, LineWidth, Height - 2);
        }
        else if (LinePosition == LinePositions.Top)
        {
            LineRect = new Rectangle(0, 1, Width - 1, LineWidth);
        }
        else if (LinePosition == LinePositions.Right)
        {
            LineRect = new Rectangle(Width - LineWidth, 1, LineWidth, Height - 2);
        }
        else
        {
            LineRect = new Rectangle(0, Height - LineWidth, Width - 1, LineWidth);
        }

        using (SolidBrush BG = new SolidBrush(BaseColor))
        using (Pen PG = new Pen(BorderColor))
        using (SolidBrush LineBrush = new SolidBrush(LineColor))
        using (SolidBrush HLC = new SolidBrush(HeaderColor))
        using (SolidBrush CTC = new SolidBrush(ContentColor))
        {
            G.FillRectangle(BG, MainRect);
            G.FillRectangle(LineBrush, LineRect);
            G.DrawRectangle(PG, MainRect);
            G.DrawString(HeadLine, HeadLineFont , HLC, HeadersLeftPadding, HeadersTopPadding);
            G.DrawString(Text, Font, CTC, HeadersLeftPadding + 1,
                G.MeasureString(HeadLine, HeadLineFont).Height + HeadersTopPadding + ContentPadding);
        }


    }

    #endregion

    #region Enumerators

    public enum LinePositions
    {
        Left,
        Top,
        Right,
        Bottom
    }

    #endregion

}

#endregion

#region PieChart

[DefaultProperty("Data")]
public class SpinPieChart : Control
{

	#region Declarations

    private static readonly HelperMethods H = new HelperMethods();
	private List<ChartData> _Data = new List<ChartData>();
	private bool _SeperateDatas = false;
	private int _SeperateThickness = 2;
	private bool _SegementsBorder = false;
	private int _SegmentBorderSize = 2;
	private int _PieSize = 200;
	private int _EffectSize = 14;
	private bool _ShowEffect = true;
	private Color _SeperationColor = SystemColors.Control;
    private readonly ToolTip _Tip = new ToolTip() { AutoPopDelay = 2000, ReshowDelay = 3000, UseFading = false, ShowAlways = true };

	#endregion

	#region Draw Control

	protected override void OnPaint(PaintEventArgs e)
	{
		Graphics G = e.Graphics;
		G.SmoothingMode = SmoothingMode.AntiAlias;
		G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

		Rectangle R = new Rectangle(Convert.ToInt32((Width / 2) - (PieSize / 2) - 1), 2, PieSize, PieSize);

		float Angle = 0;
		float Sweep = 0;
		ChartData SegData = null;
		int Sum = 0;

        for (int i = 0; i <= Data.Length - 1; i++)
        {
			SegData = Data[i];
			Sum += SegData.Value;
		}
		float startAngle = 0f;
		for (int i = 0; i <= Data.Length - 1; i++) 
        {
			SegData = Data[i];
			Sweep = 360f * SegData.Value / Sum;
            using (SolidBrush B = new SolidBrush(SegData.Color))
            using (SolidBrush B2 = new SolidBrush(SegData.HoverColor))
            using (GraphicsPath Gp = new GraphicsPath())
            {
                Gp.AddPie(R, startAngle, Sweep);
                if (Gp.IsVisible(_LocatedPosition))
                {
                    G.FillPath(B, Gp);
                    G.FillPath(B2, Gp);
                    _Tip.ToolTipTitle = SegData.Text;
                    _Tip.Show(SegData.Value.ToString(), this);
                }
                else
                {
                    G.FillPath(B, Gp);
                }
            }

                if (SeperateDatas) 
            {
				using (Pen B = new Pen(SeperationColor, SeperateThickness)) 
                {
					G.DrawPie(B, R, startAngle, Sweep);
				}
			} 
            else if (SegementsBorder) 
            {
				using (Pen B = new Pen(Data[i].BorderColor, SegmentBorderSize)) 
                {
					G.DrawPie(B, R, startAngle, Sweep);
				}
			}
			Angle += Sweep;
			startAngle = startAngle + Sweep;
		}

		if (ShowEffect) 
        {
			using (Pen P = new Pen(Color.FromArgb(50, Color.White), EffectSize)) 
            {
				G.SmoothingMode = SmoothingMode.HighQuality;
		        G.DrawEllipse(P, new Rectangle((int)Math.Round(Convert.ToInt32(Width / 2) - (PieSize / 2) + (EffectSize / 2) - 0.25), (EffectSize / 2) + 2, (PieSize - EffectSize) - 1, PieSize - EffectSize));
			}
		}

		SegmentAlign SegAlign = SegmentAlign.Left;
		using (Font F = new Font(Font.FontFamily, 10f, FontStyle.Regular, GraphicsUnit.Pixel)) 
        {
			int YMargin = 0;
			Rectangle SegRect = default(Rectangle);
            for (int i = 0; i <= Data.Length - 1; i++)
            {
				using (SolidBrush RT = new SolidBrush(Data[i].Color)) 
                using (SolidBrush TC = new SolidBrush(Data[i].TextColor))
                using (Pen P = new Pen(Data[i].BoxBorderColor))
                using (StringFormat SF = new StringFormat { LineAlignment = StringAlignment.Center })
                {
                    if (SegAlign == SegmentAlign.Left)
                    {
                        SegRect = new Rectangle(10, (int) Math.Round((PieSize*1.1) - 10 + YMargin), 10, 10);
                        if (Data[i].BorderRadius > 0)
                        {
                            G.FillPath(RT, H.RoundRec(SegRect, Data[i].BorderRadius));
                            G.DrawPath(P, H.RoundRec(SegRect, Data[i].BorderRadius));
                        }
                        else
                        {
                            G.FillPath(RT, H.RoundRec(SegRect, 1));
                            G.DrawPath(P, H.RoundRec(SegRect, 1));
                        }
                        G.DrawString(Data[i].Text, F, TC, SegRect.X + 15, SegRect.Y + 5,SF);
                        SegAlign = SegmentAlign.Center;
                    }
                    else
                    {
                        SegRect = new Rectangle(Convert.ToInt32(Width/2), (int) (PieSize*1.1 - 10 + YMargin),
                            10, 10);
                        if (Data[i].BorderRadius > 0)
                        {
                            G.FillPath(RT, H.RoundRec(SegRect, Data[i].BorderRadius));
                            G.DrawPath(P, H.RoundRec(SegRect, Data[i].BorderRadius));
                        }
                        else
                        {
                            G.FillPath(RT, H.RoundRec(SegRect, 1));
                            G.DrawPath(P, H.RoundRec(SegRect, 1));
                        }
                        G.DrawString(Data[i].Text, F, TC, SegRect.X + 15, SegRect.Y + 5,SF);
                        YMargin = YMargin + 20;
                        SegAlign = SegmentAlign.Left;
                    }
                }


            }
		}

	}

	#endregion

	#region Constructors

	public SpinPieChart()
	{
		SetStyle(ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
		DoubleBuffered = true;
		UpdateStyles();
		BackColor = Color.Transparent;
        Font = new Font("Segoe UI", 6f);
	}

	#endregion

	#region Properties

	[Category("Custom Properties"), TypeConverter(typeof(CollectionConverter)), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Description("Gets or sets the chart values.")]
	public ChartData[] Data 
    {
		get { return _Data.ToArray(); }
		set 
        {
			_Data = new List<ChartData>(value);
			Invalidate();
		}
	}

	[Category("Custom Properties"), Description("Gets or sets the whether the effect should be displayed or not.")]
	public bool ShowEffect 
    {
		get { return _ShowEffect; }
		set 
        {
				_ShowEffect = value;
				Invalidate();
        }
	}

	[Category("Custom Properties"), Description("Gets or sets the effect size.")]
	public int EffectSize 
    {
		get { return _EffectSize; }
		set 
        {
            _EffectSize = value;
            Invalidate();
		}
	}

	[Category("Custom Properties"), Description("Gets or sets whether the segments should be separated.")]
	public bool SeperateDatas 
    {
		get { return _SeperateDatas; }
		set 
        {
			_SeperateDatas = value;
			if (value) 
            {
				_SegementsBorder = false;
			} 
            else 
            {
				_SegementsBorder = true;
			}
			Invalidate();
		}
	}

	[Category("Custom Properties"), Description("Gets or sets the segments separation thickness.")]
	public int SeperateThickness 
    {
		get { return _SeperateThickness; }
		set 
        {
			_SeperateThickness = value;
			Invalidate();
		}
	}

	[Category("Custom Properties"), Description("Gets or sets whether the segments should be separated.")]
	public bool SegementsBorder 
    {
		get { return _SegementsBorder; }
		set 
        {
			_SegementsBorder = value;
			if (value) 
            {
				_SeperateDatas = false;
			} 
            else 
            {
				_SeperateDatas = true;
			}
			Invalidate();
		}
	}

	[Category("Custom Properties"), Description("Gets or sets the border size of the segments.")]
	public int SegmentBorderSize 
    {
		get { return _SegmentBorderSize; }
		set 
        {
            _SegmentBorderSize = value;
            Invalidate();

		}
	}

	[Category("Custom Properties"), Description("Gets or sets the size of Pie chart.")]
	public int PieSize 
    {
		get { return _PieSize; }
		set 
        {
            _PieSize = value;
            Invalidate();
        }
		
	}

	[Category("Custom Properties"), Description("Gets or sets the seperation color between values.")]
	public Color SeperationColor 
    {
		get { return _SeperationColor; }
		set 
        {
			_SeperationColor = value;
			Invalidate();
		}
	}

	#endregion

	#region Enumerators

	public enum SegmentAlign
	{
		Left,
		Center
	}

	#endregion

	#region Methods

	public void AddValue(int Value, string Name, Color C)
	{
		ChartData Item = new ChartData();
		Item.Text = Name;
		Item.Color = C;
		Item.Value = Value;
		_Data.Add(Item);
		Invalidate();
	}

	public void AddValues(int[] Value, string[] Name, Color[] C)
	{
		for (int I = 0; I <= Value.Length - 1; I++) 
        {
			ChartData Item = new ChartData();
			Item.Value = Value[I];
			Item.Text = Name[I];
			Item.Color = C[I];
			_Data.Add(Item);
		}
		Invalidate();
	}

	public void RemoveItem(ChartData item)
	{
		_Data.Remove(item);
		Invalidate();
	}

	public void RemoveItems(ChartData[] items)
	{
		foreach (ChartData I in items) 
        {
			_Data.Remove(I);
		}
		Invalidate();
	}

	public void Clear()
	{
		_Data.Clear();
		Invalidate();
	}

	#endregion

	#region Child Class

	[DefaultEvent("PropertyChanged")]
	public sealed class ChartData : INotifyPropertyChanged
	{

		#region Declarations

		private int _Value = 10;
		private Color _Colors = Color.Silver;
        private string _HexColor = ColorTranslator.ToHtml(Color.Silver);
		private Color _TextColor = Color.Black;
        private string _TextHexColor = ColorTranslator.ToHtml(Color.Black);
		private string _Text = "Series";
		private Color _BorderColor = Color.Gray;
        private string _BorderHexColor = ColorTranslator.ToHtml(Color.Gray);
		private Color _BoxBorderColor = Color.Black;
        private string _BoxBorderHexColor = ColorTranslator.ToHtml(Color.Black);
		private int _BorderRadius = 5;
        private Color _HoverColors = Color.FromArgb(70, 255, 255, 255);
        private string _HoverHexColor = ColorTranslator.ToHtml(Color.FromArgb(70, 255, 255, 255));

        #endregion

        #region Properties

        [Category("Appearance")]
        public Color HoverColor
        {
            get { return _HoverColors; }
            set
            {
                _HoverColors = value;
                try
                {
                    HoverHexColor = ColorTranslator.ToHtml(value);
                }
                catch
                {
                }
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("HoverColor"));
                    }
            }
        }

        [Category("Appearance")]
        public string HoverHexColor
        {
            get { return _HoverHexColor; }
            set
            {
                _HoverHexColor = value;
                try
                {
                    _HoverColors = ColorTranslator.FromHtml(value);
                }
                catch
                {
                }
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("HoverHexColor"));
                    }
                
            }
        }

        [Category("Design")]
		public string Name 
        {
			get { return Text; }
		}

		[Category("Appearance")]
		public Color BorderColor 
        {
			get { return _BorderColor; }
			set 
            {
				_BorderColor = value;
				try 
                {
					BorderHexColor = ColorTranslator.ToHtml(value);
				} 
                catch 
                {
				}
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BorderColor"));
            }
		}

		[Category("Appearance")]
		public string BorderHexColor 
        {
			get { return _BorderHexColor; }
			set 
            {
				_BorderHexColor = value;
				try 
                {
					_BorderColor = ColorTranslator.FromHtml(value);
				} 
                catch 
                {
				}
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BorderHexColor"));
            }
		}

		[Category("Appearance")]
		public Color BoxBorderColor 
        {
			get { return _BoxBorderColor; }
			set 
            {
				_BoxBorderColor = value;
				try 
                {
					BorderHexColor = ColorTranslator.ToHtml(value);
				} 
                catch 
                {
				}
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BoxBorderColor"));
            }
		}

		[Category("Appearance")]
		public string BoxBorderHexColor 
        {
			get { return _BoxBorderHexColor; }
			set 
            {
				_BoxBorderHexColor = value;
				try 
                {
					_BoxBorderColor = ColorTranslator.FromHtml(value);
				} 
                catch 
                {
				}
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BoxBorderHexColor"));
            }
		}

		[Category("Appearance")]
		public string Text 
        {
			get { return _Text; }
			set 
            {
				_Text = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Text"));
            }
		}

		[Category("Data")]
		public int Value 
        {
			get { return _Value; }
			set 
            {
				_Value = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Value"));
            }
		}

		[Category("Appearance")]
		public Color Color 
        {
			get { return _Colors; }
			set 
            {
				_Colors = value;
				try 
                {
					HexColor = ColorTranslator.ToHtml(value);
				} 
                catch 
                {
				}
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Color"));
            }
		}

		[Category("Appearance")]
		public string HexColor 
        {
			get { return _HexColor; }
			set 
            {
				_HexColor = value;
				try 
                {
					_Colors = ColorTranslator.FromHtml(value);
				} 
                catch 
                {
				}
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("HexColor"));
            }
		}

		[Category("Appearance")]
		public Color TextColor 
        {
			get { return _TextColor; }
			set 
            {
				_TextColor = value;
				try 
                {
					TextHexColor = ColorTranslator.ToHtml(value);
				} 
                catch 
                {
				}
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TextColor"));
            }
		}

		[Category("Appearance")]
		public string TextHexColor 
        {
			get { return _TextHexColor; }
			set 
            {
				_TextHexColor = value;
				try 
                {
					_TextColor = ColorTranslator.FromHtml(value);
				} 
                catch 
                {
				}
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TextHexColor"));
            }
		}

		[Category("Appearance"), Description("Gets or sets the border rounding value.")]
		public int BorderRadius 
        {
			get { return _BorderRadius; }
			set 
            {
				_BorderRadius = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BorderRadius"));
            }
		}

		#endregion

		#region Events

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        public delegate void PropertyChangedEventHandler(object sender, PropertyChangedEventArgs e);

		#endregion

	}

    #endregion

    #region Events

    private Point _LocatedPosition = new Point(-1, -1);
    protected override void OnMouseLeave(EventArgs e)
    {
        base.OnMouseLeave(e);
        _LocatedPosition = new Point(-1, -1);
        Invalidate();
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
        base.OnMouseMove(e);
        _LocatedPosition = e.Location;
        Invalidate();
    }

    #endregion

}

#endregion

#region DoughnutChart

[DefaultProperty("Data")]
public class SpinDoughnutChart : Control
{

	#region Declarations

    private static readonly HelperMethods H = new HelperMethods();
	private List<ChartData> _Data = new List<ChartData>();
	private int _Thickness = 70;
	private LineCap _EndStyle = LineCap.Custom;
	private LineCap _StartStyle = LineCap.Custom;
	private int _DoughnutSize = 200;

    #endregion

    #region Draw Control

    protected override void OnPaint(PaintEventArgs e)
	{
		Graphics G = e.Graphics;
		G.SmoothingMode = SmoothingMode.AntiAlias;
		G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

		RectangleF R = new RectangleF((Width / 2) - (DoughnutSize / 2) - 1, Thickness / 2, DoughnutSize, DoughnutSize);

		float Angle = 0;
		float Sweep = 0;
		ChartData SegData = null;
		int Sum = 0;

		for (int i = 0; i <= Data.Length - 1; i++) 
        {
			SegData = Data[i];
			Sum += SegData.Value;
		}

        for (int i = 0; i <= Data.Length - 1; i++)
        {
			SegData = Data[i];
			Sweep = 360f * SegData.Value / Sum;
            SpinToolTip _Tip = new SpinToolTip
            {
                ToolTipTitle = SegData.Name,
                AutoPopDelay = 2000,
                ReshowDelay = 3000,
                UseFading = false,
                ShowAlways = true
            };
            using (Pen SegC = new Pen(SegData.Color, Thickness) { StartCap = StartStyle, EndCap = EndStyle })
            using (Pen P2 = new Pen(SegData.HoverColor, Thickness) { StartCap = StartStyle, EndCap = EndStyle })
            using (GraphicsPath GP = new GraphicsPath())
            {
                GP.AddArc(R, Angle, Sweep + 2);
                if (GP.IsVisible(_LocatedPosition))
                {
                    G.DrawPath(SegC, GP);
                    G.DrawPath(P2, GP);
                    _Tip.Show(SegData.Value.ToString(), this);
                }
                else
                {
                    _Tip.Hide(this);
                    G.DrawPath(SegC, GP);
                }
            }
              
            Angle += Sweep;
        }

		SegmentAlign SegAlign = SegmentAlign.Left;
		using (Font F = new Font(Font.FontFamily, 10f, FontStyle.Regular, GraphicsUnit.Pixel)) 
        {
			int YMargin = 0;
			Rectangle SegRect = default(Rectangle);
			for (int i = 0; i <= Data.Length - 1; i++) 
            {
				using (SolidBrush RT = new SolidBrush(Data[i].Color)) 
                using (SolidBrush TC = new SolidBrush(Data[i].TextColor))
                using (Pen P = new Pen(Data[i].BorderColor))
                using (StringFormat SF = new StringFormat { LineAlignment = StringAlignment.Center })
                {
                    if (SegAlign == SegmentAlign.Left)
                    {
                        SegRect = new Rectangle(10, (DoughnutSize + Thickness) + 10 + YMargin, 10, 10);
                        if (Data[i].BorderRadius > 0)
                        {
                            G.FillPath(RT, H.RoundRec(SegRect, Data[i].BorderRadius));
                            G.DrawPath(P, H.RoundRec(SegRect, Data[i].BorderRadius));
                        }
                        else
                        {
                            G.FillPath(RT, H.RoundRec(SegRect, 1));
                            G.DrawPath(P, H.RoundRec(SegRect, 1));
                        }
                        G.DrawString(Data[i].Text, F, TC, SegRect.X + 15, SegRect.Y + 5,SF);
                        SegAlign = SegmentAlign.Center;
                    }
                    else
                    {
                        SegRect = new Rectangle(Convert.ToInt32(Width/2), (DoughnutSize + Thickness) + 10 + YMargin, 10,
                            10);
                        if (Data[i].BorderRadius > 0)
                        {
                            G.FillPath(RT, H.RoundRec(SegRect, Data[i].BorderRadius));
                            G.DrawPath(P, H.RoundRec(SegRect, Data[i].BorderRadius));
                        }
                        else
                        {
                            G.FillPath(RT, H.RoundRec(SegRect, 1));
                            G.DrawPath(P, H.RoundRec(SegRect, 1));
                        }
                        G.DrawString(Data[i].Text, F, TC, SegRect.X + 15, SegRect.Y + 5,SF);
                        YMargin = (YMargin + 20);
                        SegAlign = SegmentAlign.Left;
                    }
                }

            }
		}

	}

	#endregion

	#region Constructors

	public SpinDoughnutChart()
	{
		SetStyle(ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
		DoubleBuffered = true;
		UpdateStyles();
		BackColor = Color.Transparent;
        Font = new Font("Segoe UI", 6f);
	}

	#endregion

	#region Properties

	[Category("Custom Properties"), TypeConverter(typeof(CollectionConverter)), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Description("Gets or sets the chart values.")]
	public ChartData[] Data 
    {
		get { return _Data.ToArray(); }
		set 
        {
			_Data = new List<ChartData>(value);
			Invalidate();
		}
	}

	[Category("Custom Properties"), Description("Gets or sets the doughnut thickness.")]
	public int Thickness 
    {
		get { return _Thickness; }
		set 
        {
			_Thickness = value;
			Invalidate();
		}
	}

	[Category("Custom Properties"), Description("Gets or sets the end shape of progress.")]
	public LineCap EndStyle 
    {
		get { return _EndStyle; }
		set 
        {
			_EndStyle = value;
			Invalidate();
		}
	}

	[Category("Custom Properties"), Description("Gets or sets the start shape of progress.")]
	public LineCap StartStyle 
    {
		get { return _StartStyle; }
		set 
        {
			_StartStyle = value;
			Invalidate();
		}
	}

	[Category("Custom Properties"), Description("Gets or sets the size of Doughnut chart.")]
	public int DoughnutSize 
    {
		get { return _DoughnutSize; }
		set 
        {
				_DoughnutSize = value;
				Invalidate();
        }
	}

	#endregion

	#region Enumerators

	public enum SegmentAlign
	{
		Left,
		Center
	}

	#endregion

	#region Methods

	public void AddValue(int Value, string Name, Color C)
	{
		ChartData Item = new ChartData();
		Item.Text = Name;
		Item.Color = C;
		Item.Value = Value;
		_Data.Add(Item);
		Invalidate();
	}

	public void AddValues(int[] Value, string[] Name, Color[] C)
	{
		for (int I = 0; I <= Value.Length - 1; I++) 
        {
			ChartData Item = new ChartData();
			Item.Value = Value[I];
			Item.Text = Name[I];
			Item.Color = C[I];
			_Data.Add(Item);
		}
		Invalidate();
	}

	public void RemoveItem(ChartData item)
	{
		_Data.Remove(item);
		Invalidate();
	}

	public void RemoveItems(ChartData[] items)
	{
		foreach (ChartData I in items) 
        {
			_Data.Remove(I);
		}
		Invalidate();
	}

	public void Clear()
	{
		_Data.Clear();
		Invalidate();
	}

	#endregion

	#region Child Class

	[DefaultEvent("PropertyChanged")]
	public sealed class ChartData : INotifyPropertyChanged
	{

		#region Declarations

		private int _Value = 10;
		private Color _Colors = Color.Silver;
        private string _HexColor = ColorTranslator.ToHtml(Color.Silver);
		private Color _TextColor = Color.Black;
        private string _TextHexColor = ColorTranslator.ToHtml(Color.Black);
		private string _Text = "Series";
		private Color _BorderColor = Color.Black;
        private string _BorderHexColor = ColorTranslator.ToHtml(Color.Black);
		private int _BorderRadius = 5;
        private Color _HoverColors = Color.FromArgb(70, 255, 255, 255);
        private string _HoverHexColor = ColorTranslator.ToHtml(Color.FromArgb(70, 255, 255, 255));

        #endregion

        #region Properties

        [Category("Appearance")]
        public Color HoverColor
        {
            get { return _HoverColors; }
            set
            {
                _HoverColors = value;
                try
                {
                    HoverHexColor = ColorTranslator.ToHtml(value);
                }
                catch
                {
                }
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("HoverColor"));
                    }
            }
        }

        [Category("Appearance")]
        public string HoverHexColor
        {
            get { return _HoverHexColor; }
            set
            {
                _HoverHexColor = value;
                try
                {
                    _HoverColors = ColorTranslator.FromHtml(value);
                }
                catch
                {
                }
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("HoverHexColor"));
                    }
            }
        }

        [Category("Design")]
		public string Name 
        {
			get { return Text; }
		}

		[Category("Appearance")]
		public string Text 
        {
			get { return _Text; }
			set 
            {
				_Text = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Text"));
            }
		}

		[Category("Data")]
		public int Value 
        {
			get { return _Value; }
			set 
            {
				_Value = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Value"));
            }
		}

		[Category("Appearance")]
		public Color Color 
        {
			get { return _Colors; }
			set 
            {
				_Colors = value;
				try 
                {
					HexColor = ColorTranslator.ToHtml(value);
				} catch 
                {
				}
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Color"));
            }
		}

		[Category("Appearance")]
		public string HexColor 
        {
			get { return _HexColor; }
			set 
            {
				_HexColor = value;
				try 
                {
					_Colors = ColorTranslator.FromHtml(value);
				} catch 
                {
				}
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("HexColor"));
            }
		}

		[Category("Appearance")]
		public Color TextColor 
        {
			get { return _TextColor; }
			set 
            {
				_TextColor = value;
				try 
                {
					TextHexColor = ColorTranslator.ToHtml(value);
				} catch 
                {
				}
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TextColor"));

            }
		}

		[Category("Appearance")]
		public string TextHexColor 
        {
			get { return _TextHexColor; }
			set 
            {
				_TextHexColor = value;
				try 
                {
					_TextColor = ColorTranslator.FromHtml(value);
				} catch 
                {
				}
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TextHexColor"));

            }
		}

		[Category("Appearance"), Description("Gets or sets the border colors of value.")]
		public Color BorderColor 
        {
			get { return _BorderColor; }
			set 
            {
				_BorderColor = value;
				try 
                {
					BorderHexColor = ColorTranslator.ToHtml(value);
				} catch 
                {
				}

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BorderColor"));

            }
		}

		[Category("Appearance")]
		public string BorderHexColor 
        {
			get { return _BorderHexColor; }
			set 
            {
				_BorderHexColor = value;
				try 
                {
					_BorderColor = ColorTranslator.FromHtml(value);
				} catch 
                {
				}
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BorderHexColor"));

            }
		}

		[Category("Appearance"), Description("Gets or sets the border rounding value.")]
		public int BorderRadius 
        {
			get { return _BorderRadius; }
			set 
            {
				_BorderRadius = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BorderRadius"));

            }
		}

		#endregion

		#region Events

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        public delegate void PropertyChangedEventHandler(object sender, PropertyChangedEventArgs e);

		#endregion

	}

    #endregion

    #region Events

    private Point _LocatedPosition = new Point(-1, -1);
    protected override void OnMouseLeave(EventArgs e)
    {
        base.OnMouseLeave(e);
        _LocatedPosition = new Point(-1, -1);
        Invalidate();
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
        base.OnMouseMove(e);
        _LocatedPosition = e.Location;
        Invalidate();
    }

    #endregion

}

#endregion

#region Bar Chart

[DefaultProperty("Data")]
public class SpinBarChart : Control
{

	#region Declarations

    private static readonly HelperMethods H = new HelperMethods();
	private int _BarsSperation = 20;
	private GraphBorderStyle _BordersAlignment = GraphBorderStyle.LeftAndBottom;
	private List<ChartData> _Data = new List<ChartData>();
	private bool _ShowBorder = true;
	private Color _BorderColor = Color.Gray;
	private int _Maximum = 100;
	private int _Minimum = 0;
	private bool _ShowValues = true;
	private bool _ShowNames = true;
    private readonly ToolTip _Tip = new ToolTip() { AutoPopDelay = 2000, ReshowDelay = 3000, UseFading = false, ShowAlways = true };

    #endregion

    #region Constructors
    public SpinBarChart()
	{
		SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.SupportsTransparentBackColor | ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
		UpdateStyles();
		Size = new Size(380, 200);
		Font = new Font("Segoe UI", 6f);
		BackColor = Color.Transparent;
	}

	#endregion

	#region Draw Control
    
	protected override void OnPaint(PaintEventArgs e)
	{
		Graphics G = e.Graphics;
		G.SmoothingMode = SmoothingMode.AntiAlias;
		G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
		G.PixelOffsetMode = PixelOffsetMode.HighQuality;
		G.CompositingQuality = CompositingQuality.HighQuality;

		Rectangle Rect = default(Rectangle);
		List<int> LOPts = new List<int>();

		Point pts = new Point(1, Height - 20);
		LOPts.Clear();
		if (ShowNames) 
        {
			pts = new Point(1, Height - 20);
		} 
        else 
        {
			pts = new Point(1, Height - 2);
		}


		foreach (ChartData item in Data) 
        {
			int H = 0;

			int CurrPoint = 1;
			for (int i = 0; i <= item.Values.Length - 1; i++) 
            {
				CurrPoint += item.BarWidth;
			}
			CurrPoint += BarsSperation;
            using (SolidBrush B = new SolidBrush(item.NameColor))
            using (StringFormat SF = new StringFormat { Alignment = StringAlignment.Center })
            {
                if (ShowNames)
                {
                    G.DrawString(item.Name, Font, B, new Rectangle(pts.X + 5, pts.Y + 5, CurrPoint, CurrPoint), SF);
                }
            }

			pts = new Point(pts.X + BarsSperation, pts.Y);


			for (int i = 0; i <= item.Values.Length - 1; i++) 
            {
				H = (Height * (item.Values[i] - Minimum)) / (Maximum - Minimum);

				Point LOP = new Point(pts.X, (Height - 1) - H);

				LOPts.Add(LOP.Y);

				Rect = new Rectangle(LOP.X, LOP.Y, item.BarWidth, H);

				using (SolidBrush B = new SolidBrush(item.Colors[i])) 
                using (Pen P = new Pen(B, item.BarWidth){ StartCap = item.StartStyle, EndCap = item.EndStyle})
                using (SolidBrush HC = new SolidBrush(item.HoverColor))
                using (Pen P2 = new Pen(HC, item.BarWidth) { StartCap = item.StartStyle, EndCap = item.EndStyle })
                {
                    int Y = Convert.ToInt32(G.MeasureString(item.Values[i].ToString(), Font).Height*1.1);
                    if (!Rect.Contains(CurrPosition))
                    {
                        G.DrawLine(P, Rect.X, Rect.Y, Rect.X, pts.Y - 1);
                        if (ShowValues)
                        {
                            G.DrawString(item.Values[i].ToString(), Font, B, Rect.X - 4, (Rect.Y - Y),
                                StringFormat.GenericTypographic);
                        }
                    }
                    else
                    {
                        Cursor = Cursors.Hand;
                        G.DrawLine(P, Rect.X, Rect.Y, Rect.X, pts.Y - 1);
                        G.DrawLine(P2, Rect.X, Rect.Y, Rect.X, pts.Y - 1);
                        if (ShowValues)
                        {
                            G.DrawString(item.Values[i].ToString(), Font, B, Rect.X - 4, (Rect.Y - Y),
                                StringFormat.GenericTypographic);
                            G.DrawString(item.Values[i].ToString(), Font, HC, Rect.X - 4, (Rect.Y - Y),
                                StringFormat.GenericTypographic);
                        }
                        _Tip.ToolTipTitle = item.Name;
                        _Tip.Show(item.Values[i].ToString(), this);
                    }

                    pts = new Point((pts.X + item.BarWidth) + 1, pts.Y);

                }
            }
		}

		if (ShowBorder) 
        {
			G.PixelOffsetMode = PixelOffsetMode.Default;
			Point PP = new Point(1, 1);
			using (Pen P = new Pen(BorderColor)) 
            {
				switch (BordersAlignment) 
                {
					case GraphBorderStyle.None:
                        return;
					case GraphBorderStyle.LeftAndBottom:
						PP = new Point(1, 1);
						G.DrawLine(P, PP, new Point(1, pts.Y));
						PP = new Point(Width, pts.Y);
						G.DrawLine(P, new Point(1, pts.Y), PP);
						break;
					case GraphBorderStyle.Bottom:
						PP = new Point(Width, pts.Y);
						G.DrawLine(P, new Point(1, pts.Y), PP);
						break;
					case GraphBorderStyle.Left:
						PP = new Point(1, 1);
						G.DrawLine(P, PP, new Point(1, pts.Y));
						break;
					case GraphBorderStyle.Full:
						G.DrawRectangle(P, new Rectangle(0, 0, Width - 1, pts.Y));
					    break;
				}
			}
		}
	}

    #endregion

    #region Properties

    [Category("Custom Properties"), Description("Gets or sets space between the value groups.")]
	public int BarsSperation 
    {
		get { return _BarsSperation; }
		set 
        {
			_BarsSperation = value;
			Invalidate();
		}
	}

	[Category("Custom Properties"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Description("Gets or sets the border alignment style.")]
	public GraphBorderStyle BordersAlignment 
    {
		get { return _BordersAlignment; }
		set 
        {
			_BordersAlignment = value;
			Invalidate();
		}
	}

	[Category("Custom Properties"), Description("Gets or sets the whether the values show or not.")]
	public bool ShowValues 
    {
		get { return _ShowValues; }
		set 
        {
			_ShowValues = value;
			Invalidate();
		}
	}

	[Category("Custom Properties"), Description("Gets or sets the whether the names show or not.")]
	public bool ShowNames 
    {
		get { return _ShowNames; }
		set 
        {
			_ShowNames = value;
			Invalidate();
		}
	}

	[Category("Custom Properties"), TypeConverter(typeof(CollectionConverter)), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Description("Gets or sets the char data.")]
	public ChartData[] Data 
    {
		get { return _Data.ToArray(); }
		set 
        {
			_Data = new List<ChartData>(value);
			Invalidate();
		}
	}

	[Category("Custom Properties"), Description("Gets or sets whether border be shown or not.")]
	public bool ShowBorder 
    {
		get { return _ShowBorder; }
		set 
        {
			_ShowBorder = value;
			Invalidate();
		}
	}

	[Category("Custom Properties"), Description("Gets or sets the border color.")]
	public Color BorderColor 
    {
		get { return _BorderColor; }
		set 
        {
			_BorderColor = value;
			Invalidate();
		}
	}

	[Category("Custom Properties"), Description("Gets or sets the maximum value of the bar.")]
	public int Maximum 
    {
		get { return _Maximum; }
		set 
        {
			_Maximum = value;
			Invalidate();
		}
	}

	[Category("Custom Properties"), Description("Gets or sets the minimum value of the bar.")]
	public int Minimum 
    {
		get { return _Minimum; }
		set 
        {
			_Minimum = value;
			Invalidate();
		}
	}

	#endregion

	#region Enumerators
	public enum GraphBorderStyle
	{
		None,
		Bottom,
		Left,
		LeftAndBottom,
		Full
	}

	#endregion

	#region Events

	public void RemoveItem(string itemName)
	{
		for (int i = 0; i <= _Data.Count - 1; i++) 
        {
			if (_Data[i].Name == itemName) 
            {
				_Data.Remove(Data[i]);
			}
		}
		Invalidate();
	}
    
	public void AddData(int BarSize, Color[] Colors, string Name, int[] Values, LineCap StartStyle = LineCap.Custom, LineCap EndStyle = LineCap.Custom)
	{
		ChartData D = new ChartData();
		D.BarWidth = BarSize;
		D.Colors = Colors;
		D.Name = Name;
		D.Values = Values;
		D.StartStyle = StartStyle;
		D.EndStyle = EndStyle;
		_Data.Add(D);
		Invalidate();
	}

	public void Clear()
	{
		_Data.Clear();
		Invalidate();
	}

	public bool Contains(ChartData item)
	{
		return _Data.Contains(item);
	}

	public int Count()
	{
		return _Data.Count - 1;
	}


	private Point CurrPosition = new Point(1, 1);
	protected override void OnMouseMove(MouseEventArgs e)
	{
		base.OnMouseMove(e);
		CurrPosition = e.Location;
		Invalidate();
	}

    protected override void OnMouseLeave(EventArgs e)
    {
        base.OnMouseLeave(e);
        CurrPosition = new Point(-1, -1);
        Invalidate();
    }

	#endregion

	#region Child Class

	[DefaultEvent("PropertyChanged")]
	public sealed class ChartData : INotifyPropertyChanged
	{

		#region Declarations

	    private static readonly HelperMethods H = new HelperMethods();
		private int _BarWidth = 8;
		private Color[] _Colors;
		private string _Name;
		private Color _NameColor = Color.Black;
		private int[] _Values;
		private LineCap _StartStyle = LineCap.Custom;
		private LineCap _EndStyle = LineCap.Custom;
        private Color _HoverColors = Color.FromArgb(70, 255, 255, 255);
        private string _HoverHexColor = ColorTranslator.ToHtml(Color.FromArgb(70, 255, 255, 255));

        #endregion

        #region Events

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        public delegate void PropertyChangedEventHandler(object sender, PropertyChangedEventArgs e);

		#endregion

		#region Properties

		[Category("Layout"), Description("Gets or sets the width of values.")]
		public int BarWidth 
        {
			get { return _BarWidth; }
			set 
            {
				_BarWidth = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BarWidth"));

            }
		}

		[Category("Color"), Description("Gets or sets the colors of values.")]
		public Color[] Colors 
        {
			get { return _Colors; }
			set 
            {
				_Colors = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Colors"));

            }
		}

		[Category("Color"), Description("Gets or sets the color of values names.")]
		public Color NameColor 
        {
			get { return _NameColor; }
			set 
            {
				_NameColor = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NameColor"));

            }
		}

		[Category("Design"), Description("Gets or sets the name of current values.")]
		public string Name 
        {
			get { return _Name; }
			set 
            {
				if (_Name != value)
                {
					_Name = value;

                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Name"));
                }
			}
		}

		[Category("Data"), Description("Gets or sets the values.")]
		public int[] Values 
        {
			get { return _Values; }
			set 
            {
				_Values = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Values"));

            }
		}

		[Category("Appearance"), Description("Gets or sets the start style of values.")]
		public LineCap StartStyle 
        {
			get { return _StartStyle; }
			set 
            {
				_StartStyle = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("StartStyle"));

            }
		}

		[Category("Appearance"), Description("Gets or sets the End style of values.")]
		public LineCap EndStyle 
        {
			get { return _EndStyle; }
			set 
            {
				_EndStyle = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("EndStyle"));

            }
		}

        [Category("Appearance")]
        public Color HoverColor
        {
            get { return _HoverColors; }
            set
            {
                _HoverColors = value;
                try
                {
                    HoverHexColor = ColorTranslator.ToHtml(value);
                }
                catch
                {
                }
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("HoverColor"));
                }

            }
        }

        [Category("Appearance")]
        public string HoverHexColor
        {
            get { return _HoverHexColor; }
            set
            {
                _HoverHexColor = value;
                try
                {
                    _HoverColors = ColorTranslator.FromHtml(value);
                }
                catch
                {
                }
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("HoverHexColor"));
                }
            }
        }

        #endregion

    }

    #endregion

}

#endregion

#region Circle Chart

[DefaultProperty("Data")]
public class SpinCircleChart : Control
{

	#region Declarations

    private static readonly HelperMethods H = new HelperMethods();
	private int _OuterSize = 80;
	private int _InnerSize = 60;
	private Color _BaseColor = Color.WhiteSmoke;
	private List<ChartData> _Data = new List<ChartData>();
	private bool _ShowDataNames = true;
	private Color _InnerColor = Color.Transparent;

    #endregion

    #region Constructors

    public SpinCircleChart()
	{
		SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.SupportsTransparentBackColor | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
	    DoubleBuffered = true;
        UpdateStyles();
		Size = new Size(250, 250);
        Font = new Font("Segoe UI", 6f);
	    BackColor = Color.Transparent;
	}

	#endregion

	#region Draw Control

	protected override void OnPaint(PaintEventArgs e)
	{
		Graphics G = e.Graphics;
		G.SmoothingMode = SmoothingMode.HighQuality;
        G.InterpolationMode = InterpolationMode.HighQualityBicubic;

		RectangleF MainRect = new RectangleF(OuterSize, OuterSize, InnerSize, InnerSize);
		G.FillEllipse(new SolidBrush(InnerColor), MainRect);
		float startAngle = 90;


		if (Data.Length > 0) 
        {
			int Sum = Convert.ToInt32(MainRect.Y / Data.Length);

            for (int i = 0; i <= Data.Length - 1; i++)
            {
                Point pTs = new Point((int) (MainRect.X - (Sum*i)), (int) (MainRect.Y - (Sum*i)));
                Size S = new Size((int) (((MainRect.Width + (Sum*i)) + (Sum*i))),
                    (int) (MainRect.Height + (Sum*i) + (Sum*i)));
                float sweepAngle = Convert.ToSingle(3.6*Data[i].Value);
                using (Pen P = new Pen(Data[i].Color, Convert.ToSingle(Sum + 1)){StartCap = Data[i].StartStyle,EndCap = Data[i].EndStyle})
                using (Pen P2 = new Pen(BaseColor, Convert.ToSingle(Sum + 1)))
                using (Pen P3 = new Pen(Data[i].HoverColor, Convert.ToSingle(Sum + 1)) {StartCap = Data[i].StartStyle,EndCap = Data[i].EndStyle})
                using (GraphicsPath GP = new GraphicsPath())
                {
                    G.SmoothingMode = SmoothingMode.AntiAlias;
                    SpinToolTip _Tip = new SpinToolTip
                    {
                        ToolTipTitle = Data[i].Name,
                        AutoPopDelay = 2000,
                        ReshowDelay = 3000,
                        UseFading = false,
                        ShowAlways = true
                    };
                    G.DrawArc(P2, new Rectangle(pTs, S), (sweepAngle - startAngle), 360f - sweepAngle);
                    GP.AddArc(new Rectangle(pTs, S), -startAngle, sweepAngle);
                    if (GP.IsVisible(_LocatedPosition))
                    {
                        G.DrawPath(P, GP);
                        G.DrawPath(P3, GP);
                        _Tip.Show(Data[i].Value.ToString(), this);
                    }
                    else
                    {
                        G.DrawPath(P, GP);
                        //_Tip.Hide(this);
                    }
                }
            }

            if (ShowDataNames) 
            {
				int NM = Convert.ToInt32(MainRect.Y / Data.Length);
                Point pT = new Point(Convert.ToInt32(Math.Round((double)(MainRect.X - ((NM * this.Data.Length) - 1)))), Convert.ToInt32(Math.Round((double)(MainRect.Y - ((NM * this.Data.Length) - 1)))));
                Size S = new Size(Convert.ToInt32(Math.Round((double)((MainRect.Width + ((NM * this.Data.Length) - 1)) + ((NM * this.Data.Length) - 1)))), Convert.ToInt32(Math.Round((double)((MainRect.Height + ((NM * this.Data.Length) - 1)) + ((NM * this.Data.Length) - 1)))));
				Rectangle ValRect = default(Rectangle);
				Rectangle RX = new Rectangle(pT, S);
				SegmentAlign SegAlign = SegmentAlign.Left;
				int Y = 0;
				for (int i = 0; i <= Data.Length - 1; i++) 
                {
					using (SolidBrush BGB = new SolidBrush(Data[i].Color)) 
                    using (SolidBrush VTC = new SolidBrush(Data[i].NameColor)) 
                    using (Pen BC = new Pen(Data[i].BorderColor)) 
                    {
                        if (SegAlign == SegmentAlign.Left) 
                        {
                            ValRect = new Rectangle(5, (RX.Height + 10) + Y, 10, 10);
                            if (Data[i].BorderRadius > 0) 
                            {
                                G.FillPath(BGB, H.RoundRec(ValRect, Data[i].BorderRadius));
                                G.DrawPath(BC, H.RoundRec(ValRect, Data[i].BorderRadius));
                            } 
                            else 
                            {
                                G.FillPath(BGB, H.RoundRec(ValRect, 1));
                                G.DrawPath(BC, H.RoundRec(ValRect, 1));
                            }
                            G.DrawString(Data[i].Name, Font, VTC, new Rectangle(18, (RX.Height + 9) + Y, 80, 15));
                            SegAlign = SegmentAlign.Center;
                        } 
                        else 
                        {
                            ValRect = new Rectangle(Convert.ToInt32(Width / 1.5), (RX.Height + 10) + Y, 10, 10);
                            if (Data[i].BorderRadius > 0) 
                            {
                                G.FillPath(BGB, H.RoundRec(ValRect, Data[i].BorderRadius));
                                G.DrawPath(BC, H.RoundRec(ValRect, Data[i].BorderRadius));
                            } 
                            else 
                            {
                                G.FillPath(BGB, H.RoundRec(ValRect, 1));
                                G.DrawPath(BC, H.RoundRec(ValRect, 1));
                            }
                            G.DrawString(Data[i].Name, Font, VTC, new Rectangle(Convert.ToInt32(Width / 1.5) + 13, (RX.Height + 9) + Y, 80, 15));
                            Y += 20;
                            SegAlign = SegmentAlign.Left;
                        }
					}
				}
			}

		}
	}

	#endregion

	#region Enumerators

	public enum SegmentAlign
	{
		Left,
		Center
	}

	#endregion

	#region Properties

	[Category("Custom Properties"), Description("Gets or sets the outer size of circle chart.")]
	public int OuterSize 
    {
		get { return _OuterSize; }
		set 
        {
			_OuterSize = value;
			Invalidate();
		}
	}

	[Category("Custom Properties"), Description("Gets or sets the color of the base circle of chart.")]
	public Color BaseColor 
    {
		get { return _BaseColor; }
		set 
        {
			_BaseColor = value;
			Invalidate();
		}
	}

	[Category("Custom Properties"), TypeConverter(typeof(CollectionConverter)), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Description("Alle Werte, die momentan dem Diagramm zugeordnet sind.")]
	public ChartData[] Data 
    {
		get { return _Data.ToArray(); }
		set 
        {
			_Data = new List<ChartData>(value);
			Invalidate();
		}
	}

	[Category("Custom Properties"), Description("Gets or sets whether the data names should be displayed or not.")]
	public bool ShowDataNames 
    {
		get { return _ShowDataNames; }
		set 
        {
			_ShowDataNames = value;
			Invalidate();
		}
	}

	[Category("Custom Properties"), Description("Gets or sets color of the inner circle.")]
	public Color InnerColor 
    {
		get { return _InnerColor; }
		set 
        {
			_InnerColor = value;
			Invalidate();
		}
	}

	[Category("Custom Properties"), Description("Gets or sets the inner size of circle chart.")]
	public int InnerSize 
    {
		get { return _InnerSize; }
		set 
        {
			_InnerSize = value;
			Invalidate();
		}
	}

	#endregion

    #region Methods

    public void AddValue(int Value, string Name, Color C, Color BorderColor, Color NameColor, LineCap StartStyle = LineCap.Custom, LineCap EndStyle = LineCap.Custom,int RoundRadius = 5)
    {
        ChartData Item = new ChartData();
        Item.Value = Value;
        Item.Name = Name;
        Item.Color = C;
        Item.BorderColor = BorderColor;
        Item.NameColor = NameColor;
        Item.StartStyle = StartStyle;
        Item.EndStyle = EndStyle;
        Item.BorderRadius = RoundRadius;
        _Data.Add(Item);
        Invalidate();
    }

    public void RemoveItem(ChartData item)
    {
        _Data.Remove(item);
        Invalidate();
    }

    public void RemoveItems(ChartData[] items)
    {
        foreach (ChartData I in items)
        {
            _Data.Remove(I);
        }
        Invalidate();
    }

    public void Clear()
    {
        _Data.Clear();
        Invalidate();
    }

    #endregion

	#region Child Class

	[DefaultEvent("PropertyChanged")]
	public class ChartData : INotifyPropertyChanged
    {
        #region Declarations

        private Color _Color = Color.FromArgb(54, 116, 178);
		private Color _BorderColor = Color.Black;
		private string _Name = "Series";
		private Color _NameColor = Color.Black;
		private int _Value = 10;
		private LineCap _StartStyle = LineCap.Custom;
		private LineCap _EndStyle = LineCap.Custom;
		private int _BorderRadius = 5;
        private Color _HoverColors = Color.FromArgb(70, 255, 255, 255);
        private string _HoverHexColor = ColorTranslator.ToHtml(Color.FromArgb(70, 255, 255, 255));

        #endregion

        #region Events

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        public delegate void PropertyChangedEventHandler(object sender, PropertyChangedEventArgs e);

        #endregion

        #region Properties

        [Category("Appearance")]
        public Color HoverColor
        {
            get { return _HoverColors; }
            set
            {
                _HoverColors = value;
                try
                {
                    HoverHexColor = ColorTranslator.ToHtml(value);
                }
                catch
                {
                }
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("HoverColor"));
                    }
                
            }
        }

        [Category("Appearance")]
        public string HoverHexColor
        {
            get { return _HoverHexColor; }
            set
            {
                _HoverHexColor = value;
                try
                {
                    _HoverColors = ColorTranslator.FromHtml(value);
                }
                catch
                {
                }
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("HoverHexColor"));
                    }
            }
        }

        [Category("Circle Appearance"), Description("Gets or sets the colors of value.")]
		public Color Color 
        {
			get { return _Color; }
			set 
            {
				_Color = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Color"));

            }
		}

		[Category("Box Appearance"), Description("Gets or sets the border colors of value.")]
		public Color BorderColor 
        {
			get { return _BorderColor; }
			set 
            {
				_BorderColor = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BorderColor"));

            }
		}

		[Category("Name Appearance"), Description("Gets or sets the color of value name.")]
		public Color NameColor 
        {
			get { return _NameColor; }
			set 
            {
				_NameColor = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NameColor"));

            }
		}

		[Category("Design"), Description("Gets or sets the name of current value.")]
		public string Name 
        {
			get { return _Name; }
			set 
            {
				if (_Name != value)
                {
                    _Name = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Name"));

                }
			}
		}

        [Category("Box Appearance"), Description("Gets or sets the border rounding value.")]
		public int BorderRadius 
        {
			get { return _BorderRadius; }
			set 
            {
				_BorderRadius = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BorderRadius"));

            }
		}

		[Category("Data"), Description("Gets or sets the value.")]
		public int Value 
        {
			get { return _Value; }
			set 
            {
				_Value = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Value"));

            }
		}

        [Category("Circle Appearance"), Description("Gets or sets the start style of value.")]
		public LineCap StartStyle 
        {
			get { return _StartStyle; }
			set 
            {
				_StartStyle = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("StartStyle"));

            }
		}

        [Category("Circle Appearance"), Description("Gets or sets the End style of value.")]
		public LineCap EndStyle 
        {
			get { return _EndStyle; }
			set 
            {
				_EndStyle = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("EndStyle"));

            }
		}

		#endregion

	}

    #endregion

    #region Events
    
    private Point _LocatedPosition = new Point(-1, -1);
    protected override void OnMouseLeave(EventArgs e)
    {
        base.OnMouseLeave(e);
        _LocatedPosition = new Point(-1, -1);
        Invalidate();
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
        base.OnMouseMove(e);
        _LocatedPosition = e.Location;
        Invalidate();
    }

    #endregion

}

#endregion

#region ListView
public class SpinListView : ListView
{

    #region Declarations

    private static readonly HelperMethods H = new HelperMethods();
    private HelperMethods.MouseMode State = HelperMethods.MouseMode.Normal;
    private Point _MouseLocation = new Point(1, 1);
    private ListViewItem _HoveredItem;
    private Color _ColumnTextColor = Color.GhostWhite;
    private Color _ColumnColor = Color.FromArgb(26, 26, 26);
    private Color _HoverItemColor = Color.FromArgb(44, 151, 222);
    private Color _SelectedItemColor = Color.FromArgb(44, 151, 222);
    private Color _SeperatorColor = Color.FromArgb(26, 26, 26);
    private int _SeperatorThickness = 1;
    private Font _ColumnHeaderFont = new Font("Segoe UI", 14);
    private Font _ItemFont = new Font("Segoe UI", 10);

    #endregion

    #region Constructors

    public SpinListView()
    {
        SetDefaults();
        SetStyle(ControlStyles.UserMouse | ControlStyles.OptimizedDoubleBuffer, true);
        DoubleBuffered = true;
        Font = new Font("Segoe UI", 12);
        UpdateStyles();
    }

    private void SetDefaults()
    {
        GridLines = false;
        FullRowSelect = true;
        BackColor = Color.FromArgb(30, 30, 30);
        HeaderStyle = ColumnHeaderStyle.Nonclickable;
        View = View.Details;
        OwnerDraw = true;
        ResizeRedraw = true;
        BorderStyle = BorderStyle.None;
    }

    #endregion

    #region Events

    protected override void OnMouseLeave(EventArgs e)
    {
        base.OnMouseLeave(e);
        State = HelperMethods.MouseMode.Normal;
        _MouseLocation = new Point(1, 1);
        HoveredItem = null;
        Invalidate();
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        base.OnMouseDown(e);
        State = HelperMethods.MouseMode.Pushed;
        Invalidate();
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
        base.OnMouseMove(e);
        _MouseLocation = e.Location;
        if (!ReferenceEquals(HoveredItem, GetItemAt(_MouseLocation.X, _MouseLocation.Y)))
        {
            HoveredItem = GetItemAt(_MouseLocation.X, _MouseLocation.Y);
            Invalidate();
        }
    }

    protected override void OnMouseEnter(EventArgs e)
    {
        base.OnMouseEnter(e);
        State = HelperMethods.MouseMode.Hovered;
        Invalidate();
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
        base.OnMouseUp(e);
        State = HelperMethods.MouseMode.Hovered;
        Invalidate();
    }

    #endregion

    #region Properties

    [Browsable(false)]
    private ListViewItem HoveredItem
    {
        get { return _HoveredItem; }
        set
        {
            _HoveredItem = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the column headers colors.")]
    public Color ColumnColor
    {
        get { return _ColumnColor; }
        set
        {
            _ColumnColor = value;
            Invalidate();
        }
    }
    
    [Category("Custom Properties"), Description("Gets or sets the column header text color.")]
    public Color ColumnTextColor
    {
        get { return _ColumnTextColor; }
        set
        {
            _ColumnTextColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the hovered item color.")]
    public Color HoverItemColor
    {
        get { return _HoverItemColor; }
        set
        {
            _HoverItemColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the selected items color.")]
    public Color SelectedItemColor
    {
        get { return _SelectedItemColor; }
        set
        {
            _SelectedItemColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the the seperation lines color between.")]
    public Color SeperatorColor
    {
        get { return _SeperatorColor; }
        set
        {
            _SeperatorColor = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the the seperation lines thickness.")]
    public int SeperatorThickness
    {
        get { return _SeperatorThickness; }
        set
        {
            _SeperatorThickness = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the the colmun headers font.")]
    public Font ColumnHeaderFont
    {
        get { return _ColumnHeaderFont; }
        set
        {
            _ColumnHeaderFont = value;
            Invalidate();
        }
    }

    [Category("Custom Properties"), Description("Gets or sets the the items font.")]
    public Font ItemFont
    {
        get { return _ItemFont; }
        set
        {
            _ItemFont = value;
            Invalidate();
        }
    }

    #endregion

    #region Draw Control

    protected override void OnDrawColumnHeader(DrawListViewColumnHeaderEventArgs e)
    {
        Graphics G = e.Graphics;
        G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
        using (SolidBrush BG = new SolidBrush(ColumnColor))
        using (SolidBrush CLT = new SolidBrush(ColumnTextColor))
        using (StringFormat SF = new StringFormat{FormatFlags = StringFormatFlags.LineLimit,Trimming = StringTrimming.EllipsisCharacter,Alignment = StringAlignment.Near,LineAlignment = StringAlignment.Center})
        using (Pen P = new Pen(Color.FromArgb(ColumnColor.R - 6, ColumnColor.G - 6, ColumnColor.B - 6), 1))
        {
            G.FillRectangle(BG, e.Bounds);
            G.DrawString(e.Header.Text, ColumnHeaderFont, CLT, e.Bounds, SF);
            G.DrawLine(P, new Point(0, e.Bounds.Height - 1), new Point(Width - 1, e.Bounds.Height - 1));
        }
    }
    protected override void OnDrawItem(DrawListViewItemEventArgs e)
    {
        Graphics G = e.Graphics;
        Rectangle BB = new Rectangle(e.Item.Bounds.X, e.Bounds.Y + 1, e.Item.Bounds.Width, e.Item.Bounds.Height - 1);

        G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

        using (SolidBrush B = new SolidBrush(SelectedItemColor))
        using (SolidBrush H = new SolidBrush(HoverItemColor))
        {
            if (e.Item.Selected)
            {
                G.FillRectangle(B, BB);
            }
            else if (e.Bounds.Contains(_MouseLocation) && State == HelperMethods.MouseMode.Hovered)
            {
                G.FillRectangle(H, BB);
            }
        }
       
        using (Pen P = H.PenColor(SeperatorColor, SeperatorThickness))
        {
            for (int i = 0; i <= Items.Count - 1; i++)
            {
                G.DrawLine(P, Items[i].Bounds.Left, Items[i].Bounds.Bottom, Items[i].Bounds.Width, Items[i].Bounds.Bottom);
            }
        }
        using (Pen P = H.PenColor(SeperatorColor, SeperatorThickness))
        {
            G.DrawRectangle(P, new Rectangle(0, 0, Width - 1, Height - 1));
        }
    }
    protected override void OnDrawSubItem(DrawListViewSubItemEventArgs e)
    {
        base.OnDrawSubItem(e);
        e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
        using (SolidBrush B = new SolidBrush(ForeColor))
        {
            e.Graphics.DrawString(e.SubItem.Text, ItemFont, B, e.SubItem.Bounds.Left + 7, e.SubItem.Bounds.Y + 4);
        }
    }

    #endregion

}

#endregion
