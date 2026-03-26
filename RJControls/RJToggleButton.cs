using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace DocuFlow_Reg.RJControls
{
    public class RJToggleButton : CheckBox
    {
        // Fields with default values
        private Color onBackColor = Color.MediumSlateBlue;
        private Color onToggleColor = Color.WhiteSmoke;
        private Color offBackColor = Color.Gray;
        private Color offToggleColor = Color.Gainsboro;
        private bool solidStyle = true;

        // Properties
        [Category("RJ Code Advance")]
        public Color OnBackColor
        {
            get => onBackColor;
            set
            {
                if (onBackColor != value)
                {
                    onBackColor = value;
                    this.Invalidate();
                }
            }
        }

        [Category("RJ Code Advance")]
        public Color OnToggleColor
        {
            get => onToggleColor;
            set
            {
                if (onToggleColor != value)
                {
                    onToggleColor = value;
                    this.Invalidate();
                }
            }
        }

        [Category("RJ Code Advance")]
        public Color OffBackColor
        {
            get => offBackColor;
            set
            {
                if (offBackColor != value)
                {
                    offBackColor = value;
                    this.Invalidate();
                }
            }
        }

        [Category("RJ Code Advance")]
        public Color OffToggleColor
        {
            get => offToggleColor;
            set
            {
                if (offToggleColor != value)
                {
                    offToggleColor = value;
                    this.Invalidate();
                }
            }
        }

        [Browsable(false)]
        public override string Text
        {
            get => base.Text;
            set => base.Text = string.Empty; // Prevent text from being set
        }

        [Category("RJ Code Advance")]
        [DefaultValue(true)]
        public bool SolidStyle
        {
            get => solidStyle;
            set
            {
                if (solidStyle != value)
                {
                    solidStyle = value;
                    this.Invalidate();
                }
            }
        }

        // Constructor
        public RJToggleButton()
        {
            this.MinimumSize = new Size(45, 22);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                         ControlStyles.UserPaint |
                         ControlStyles.ResizeRedraw |
                         ControlStyles.OptimizedDoubleBuffer, true);
            base.Text = string.Empty; // Ensure no text is displayed
        }

        // Methods
        private GraphicsPath GetFigurePath()
        {
            try
            {
                if (this.Height <= 0 || this.Width <= 0)
                    return new GraphicsPath();

                int arcSize = Math.Max(this.Height - 1, 1);
                Rectangle leftArc = new Rectangle(0, 0, arcSize, arcSize);
                Rectangle rightArc = new Rectangle(this.Width - arcSize - 2, 0, arcSize, arcSize);

                GraphicsPath path = new GraphicsPath();
                path.StartFigure();
                path.AddArc(leftArc, 90, 180);
                path.AddArc(rightArc, 270, 180);
                path.CloseFigure();

                return path;
            }
            catch
            {
                return new GraphicsPath();
            }
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            if (pevent == null || pevent.Graphics == null)
                return;

            try
            {
                int toggleSize = Math.Max(this.Height - 5, 1);
                pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                // Use BackColor if Parent is null, otherwise use Parent's BackColor
                Color clearColor = this.Parent?.BackColor ?? this.BackColor;
                pevent.Graphics.Clear(clearColor);

                using (GraphicsPath path = GetFigurePath())
                {
                    if (this.Checked) // ON
                    {
                        // Draw the control surface
                        if (solidStyle)
                        {
                            using (Brush brush = new SolidBrush(onBackColor))
                            {
                                pevent.Graphics.FillPath(brush, path);
                            }
                        }
                        else
                        {
                            using (Pen pen = new Pen(onBackColor, 2))
                            {
                                pevent.Graphics.DrawPath(pen, path);
                            }
                        }

                        // Draw the toggle
                        int toggleX = Math.Max(this.Width - this.Height + 1, 2);
                        using (Brush brush = new SolidBrush(onToggleColor))
                        {
                            pevent.Graphics.FillEllipse(brush,
                                new Rectangle(toggleX, 2, toggleSize, toggleSize));
                        }
                    }
                    else // OFF
                    {
                        // Draw the control surface
                        if (solidStyle)
                        {
                            using (Brush brush = new SolidBrush(offBackColor))
                            {
                                pevent.Graphics.FillPath(brush, path);
                            }
                        }
                        else
                        {
                            using (Pen pen = new Pen(offBackColor, 2))
                            {
                                pevent.Graphics.DrawPath(pen, path);
                            }
                        }

                        // Draw the toggle
                        using (Brush brush = new SolidBrush(offToggleColor))
                        {
                            pevent.Graphics.FillEllipse(brush,
                                new Rectangle(2, 2, toggleSize, toggleSize));
                        }
                    }
                }
            }
            catch
            {
                // Fallback to default painting if custom painting fails
                base.OnPaint(pevent);
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        // Override to prevent text from being displayed
        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            this.Invalidate();
        }
    }
}