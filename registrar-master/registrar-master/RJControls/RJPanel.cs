using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace DocuFlow_Reg.RJControls
{
    [Flags]
    public enum BorderSides
    {
        None = 0,
        Left = 1,
        Top = 2,
        Right = 4,
        Bottom = 8,
        All = Left | Top | Right | Bottom
    }

    public partial class RJPanel : UserControl
    {
        // Fields
        private int _borderRadius = 15;
        private int _borderSize = 0;
        private Color _borderColor = Color.Gray;
        private Color _backgroundColor = Color.White;
        private Color _gradientColor1 = Color.Empty;
        private Color _gradientColor2 = Color.Empty;
        private LinearGradientMode _gradientMode = LinearGradientMode.Vertical;
        private bool _useGradient = false;

        // Per-side border fields
        private BorderSides _borderSides = BorderSides.All;
        private Color _borderLeftColor = Color.Empty;
        private Color _borderTopColor = Color.Empty;
        private Color _borderRightColor = Color.Empty;
        private Color _borderBottomColor = Color.Empty;

        // ── Existing properties (unchanged) ────────────────────────────────

        [Category("RJ Code Advance")]
        public int BorderRadius
        {
            get => _borderRadius;
            set { _borderRadius = Math.Max(0, value); Invalidate(); }
        }

        [Category("RJ Code Advance")]
        public int BorderSize
        {
            get => _borderSize;
            set { _borderSize = Math.Max(0, value); Invalidate(); }
        }

        [Category("RJ Code Advance")]
        public Color BorderColor
        {
            get => _borderColor;
            set { _borderColor = value; Invalidate(); }
        }

        [Category("RJ Code Advance")]
        public Color BackgroundColor
        {
            get => _backgroundColor;
            set { _backgroundColor = value; Invalidate(); }
        }

        [Category("RJ Code Advance")]
        public Color GradientColor1
        {
            get => _gradientColor1;
            set { _gradientColor1 = value; Invalidate(); }
        }

        [Category("RJ Code Advance")]
        public Color GradientColor2
        {
            get => _gradientColor2;
            set { _gradientColor2 = value; Invalidate(); }
        }

        [Category("RJ Code Advance")]
        public LinearGradientMode GradientMode
        {
            get => _gradientMode;
            set { _gradientMode = value; Invalidate(); }
        }

        [Category("RJ Code Advance")]
        public bool UseGradient
        {
            get => _useGradient;
            set { _useGradient = value; Invalidate(); }
        }

        // ── New per-side properties ─────────────────────────────────────────

        /// <summary>
        /// Choose which sides show a border. Individual side colors override
        /// BorderColor when set (i.e., not Color.Empty).
        /// </summary>
        [Category("RJ Code Advance")]
        public BorderSides BorderSides
        {
            get => _borderSides;
            set { _borderSides = value; Invalidate(); }
        }

        [Category("RJ Code Advance")]
        public Color BorderLeftColor
        {
            get => _borderLeftColor;
            set { _borderLeftColor = value; Invalidate(); }
        }

        [Category("RJ Code Advance")]
        public Color BorderTopColor
        {
            get => _borderTopColor;
            set { _borderTopColor = value; Invalidate(); }
        }

        [Category("RJ Code Advance")]
        public Color BorderRightColor
        {
            get => _borderRightColor;
            set { _borderRightColor = value; Invalidate(); }
        }

        [Category("RJ Code Advance")]
        public Color BorderBottomColor
        {
            get => _borderBottomColor;
            set { _borderBottomColor = value; Invalidate(); }
        }

        // ── Constructor ─────────────────────────────────────────────────────

        public RJPanel()
        {
            InitializeComponent();
            DoubleBuffered = true;
            ResizeRedraw = true;
            BackColor = Color.Transparent;
            ForeColor = Color.Black;
        }

        // ── Paint ───────────────────────────────────────────────────────────

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rectSurface = ClientRectangle;
            int smoothSize = _borderSize > 0 ? _borderSize : 2;

            if (_borderRadius > 2)
            {
                // ── Rounded mode ────────────────────────────────────────────
                using (GraphicsPath pathSurface = GetRoundedRectanglePath(rectSurface, _borderRadius))
                using (Pen penSmooth = new Pen(Parent?.BackColor ?? Color.White, smoothSize))
                {
                    // Anti-alias edge
                    g.DrawPath(penSmooth, pathSurface);

                    // Background fill
                    FillBackground(g, rectSurface, pathSurface);

                    // Full rounded border (only when BorderSides == All)
                    if (_borderSize > 0 && _borderSides == BorderSides.All)
                    {
                        Rectangle rectBorder = Rectangle.Inflate(rectSurface, -_borderSize, -_borderSize);
                        using (GraphicsPath pathBorder = GetRoundedRectanglePath(rectBorder, _borderRadius - _borderSize))
                        using (Pen penBorder = new Pen(_borderColor, _borderSize))
                            g.DrawPath(penBorder, pathBorder);
                    }
                }

                // Per-side lines drawn on top (clip to rounded shape for clean edges)
                if (_borderSize > 0 && _borderSides != BorderSides.All)
                {
                    using (GraphicsPath clip = GetRoundedRectanglePath(rectSurface, _borderRadius))
                    {
                        g.SetClip(clip);
                        DrawSideBorders(g, rectSurface);
                        g.ResetClip();
                    }
                }
            }
            else
            {
                // ── Rectangular mode ────────────────────────────────────────
                g.SmoothingMode = SmoothingMode.None;
                FillBackground(g, rectSurface, null);

                if (_borderSize > 0)
                    DrawSideBorders(g, rectSurface);
            }
        }

        // ── Helpers ─────────────────────────────────────────────────────────

        /// <summary>Fills the panel with a solid color or gradient.</summary>
        private void FillBackground(Graphics g, Rectangle rect, GraphicsPath path)
        {
            if (_useGradient && _gradientColor1 != Color.Empty && _gradientColor2 != Color.Empty)
            {
                using (var brush = new LinearGradientBrush(rect, _gradientColor1, _gradientColor2, _gradientMode))
                {
                    if (path != null) g.FillPath(brush, path);
                    else g.FillRectangle(brush, rect);
                }
            }
            else
            {
                using (var brush = new SolidBrush(_backgroundColor))
                {
                    if (path != null) g.FillPath(brush, path);
                    else g.FillRectangle(brush, rect);
                }
            }
        }

        /// <summary>
        /// Draws only the sides specified in BorderSides, using each side's
        /// own color if set, otherwise falling back to BorderColor.
        /// </summary>
        private void DrawSideBorders(Graphics g, Rectangle r)
        {
            float half = _borderSize / 2f;

            if (_borderSides.HasFlag(BorderSides.Left))
                using (var pen = new Pen(SideColor(_borderLeftColor), _borderSize))
                    g.DrawLine(pen, r.Left + half, r.Top, r.Left + half, r.Bottom);

            if (_borderSides.HasFlag(BorderSides.Top))
                using (var pen = new Pen(SideColor(_borderTopColor), _borderSize))
                    g.DrawLine(pen, r.Left, r.Top + half, r.Right, r.Top + half);

            if (_borderSides.HasFlag(BorderSides.Right))
                using (var pen = new Pen(SideColor(_borderRightColor), _borderSize))
                    g.DrawLine(pen, r.Right - half, r.Top, r.Right - half, r.Bottom);

            if (_borderSides.HasFlag(BorderSides.Bottom))
                using (var pen = new Pen(SideColor(_borderBottomColor), _borderSize))
                    g.DrawLine(pen, r.Left, r.Bottom - half, r.Right, r.Bottom - half);
        }

        /// <summary>Returns the override color if set, otherwise falls back to BorderColor.</summary>
        private Color SideColor(Color overrideColor) =>
            overrideColor != Color.Empty ? overrideColor : _borderColor;

        private GraphicsPath GetRoundedRectanglePath(Rectangle rect, int radius)
        {
            var path = new GraphicsPath();
            if (radius <= 0) { path.AddRectangle(rect); return path; }

            float curveSize = radius * 2F;
            path.StartFigure();
            path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
            path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
            path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
            path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
            path.CloseFigure();
            return path;
        }

        protected override void OnResize(EventArgs e) { base.OnResize(e); Invalidate(); }
        protected override void OnParentBackColorChanged(EventArgs e) { base.OnParentBackColorChanged(e); Invalidate(); }
    }
}