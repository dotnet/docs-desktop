using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace project
{
    public partial class Form2 : Form
    {
        private DateTime _lastClick;
        private bool _inDoubleClick;
        private Rectangle _doubleClickArea;
        private TimeSpan _doubleClickMaxTime;
        private Action _doubleClickAction;
        private Action _singleClickAction;
        private Timer _clickTimer;

        public Form2()
        {
            InitializeComponent();
            _doubleClickMaxTime = TimeSpan.FromMilliseconds(SystemInformation.DoubleClickTime);

            _clickTimer = new Timer();
            _clickTimer.Interval = SystemInformation.DoubleClickTime;
            _clickTimer.Tick += ClickTimer_Tick;

            _singleClickAction = () => MessageBox.Show("Single clicked");
            _doubleClickAction = () => MessageBox.Show("Double clicked");
        }

        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            if (_inDoubleClick)
            {
                _inDoubleClick = false;

                TimeSpan length = DateTime.Now - _lastClick;

                // If double click is valid, respond
                if (_doubleClickArea.Contains(e.Location) && length < _doubleClickMaxTime)
                {
                    _clickTimer.Stop();
                    _doubleClickAction();
                }

                return;
            }

            // Double click was invalid, restart 
            _clickTimer.Stop();
            _clickTimer.Start();
            _lastClick = DateTime.Now;
            _inDoubleClick = true;
            _doubleClickArea = new Rectangle(e.Location - (SystemInformation.DoubleClickSize / 2), 
                                             SystemInformation.DoubleClickSize);
        }

        private void ClickTimer_Tick(object sender, EventArgs e)
        {
            // Clear double click watcher and timer
            _inDoubleClick = false;
            _clickTimer.Stop();

            _singleClickAction();
        }
    }
}
