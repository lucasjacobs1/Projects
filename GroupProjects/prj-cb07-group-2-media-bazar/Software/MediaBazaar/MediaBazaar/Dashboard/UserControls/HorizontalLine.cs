﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaBazaarSoftware.Dashboard.UserControls
{
    public partial class HorizontalLine : Control
    {
        private Color _lineColor = Color.Black;

        public Color LineColor
        {
            get { return _lineColor; }
            set { _lineColor = value; }
        }

        public HorizontalLine()
        {
            InitializeComponent();

            this.MaximumSize = new Size(1000, 2);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.DrawLine(new Pen(_lineColor), 0, 0, 0, this.Height);
        }
    }
}
