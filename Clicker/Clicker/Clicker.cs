using InputDeviceEventManager;
using System;
using System.Windows.Forms;

namespace Clicker
{
    public partial class Clicker : Form
    {
        private readonly DeviceListener deviceListener = new DeviceListener();

        private bool leftClick = false;
        private bool rightClick = false;

        public Clicker()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            deviceListener.StartListen();
            deviceListener.KeyboardKeyDown += DeviceListener_KeyboardKeyDown;
        }

        private void DeviceListener_KeyboardKeyDown(object sender, InputDeviceEventManager.Keyboard.KeyboardEventArgs keyboardEventArgs)
        {
            if(keyboardEventArgs.VirtualKeyCode == InputDeviceEventManager.Keyboard.VirtualKeyCodes.F8)
            {
                leftClick = !leftClick;
            }

            if(keyboardEventArgs.VirtualKeyCode == InputDeviceEventManager.Keyboard.VirtualKeyCodes.F9)
            {
                rightClick = !rightClick;
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            deviceListener.StopListen();

            base.OnFormClosing(e);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if(leftClick)
            {
                MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftDown);
                MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftUp);
            }

            if (rightClick)
            {
                MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.RightDown);
                MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.RightUp);
            }
        }
    }
}
