using System;
using DelegatesEvents.Events;

namespace DelegatesEvents.Events.v1 {
    public delegate void ClickEventHandler(object sender, ClickEventArgs e);

    public class ClickEventArgs : EventArgs {
        public string MouseButton { get; set; }
    }

    public class Button {
        public event ClickEventHandler OnClick;
    }

    public class Usage {
        public void Test() {
            Button b = new Button();
            b.OnClick += OnClick;
        }

        private void OnClick(object sender, ClickEventArgs eventArgs) {
        }
    }
}

namespace DelegatesEvents.Events.v2 {
    public delegate void ClickEventHandler(object sender, ClickEventArgs e);

    public class ClickEventArgs : EventArgs {
        public string MouseButton { get; set; }
        public Point MousePosition { get; set; }
    }

    public class Button {
        public event ClickEventHandler OnClick;
    }

    public class Usage {
        public void Test() {
            Button b = new Button();
            b.OnClick += OnClick;
        }

        private void OnClick(object sender, ClickEventArgs eventArgs) {
        }
    }
}

namespace DelegatesEvents.Events {
    public class Point {
    }
}