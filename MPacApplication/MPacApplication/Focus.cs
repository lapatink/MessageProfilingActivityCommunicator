using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MPacApplication
{
    class Focus
    {
        Form f;
        Timer t;
        public bool active = true;

        public Focus(Form f)
        {
            this.f = f;
            this.f.TopMost = true;

            t = new Timer();
            t.Interval = 1;
            t.Tick += new EventHandler(t_Tick);

            this.f.Activated += new EventHandler(f_Activated);
            this.f.Deactivate += new EventHandler(f_Deactivate);
        }

        private void t_Tick(object sender, EventArgs e)
        {
            if (active)
                f.Activate();
        }
        private void f_Activated(object sender, EventArgs e)
        {
            t.Stop();
        }
        private void f_Deactivate(object sender, EventArgs e)
        {
            t.Start();
        }
    }
}
