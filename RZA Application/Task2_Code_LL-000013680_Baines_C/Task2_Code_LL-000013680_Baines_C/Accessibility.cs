using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task2_Code_LL_000013680_Baines_C
{
    public class Accessibility
    {
        public class AccessibilityHelper
        {
            public float? fontSize { get; set; }

            public User currentUser { get; set; } = null;

            public AccessibilityHelper() { }
            public AccessibilityHelper(float fontSize)
            {
                this.fontSize = fontSize;
            }

            public void UpdateFontSize(Control.ControlCollection controls)
            {
                if (fontSize == null) return;

                foreach (Control control in controls)
                {
                    control.Font = new System.Drawing.Font(control.Font.Name, (float)fontSize);
                }
            }


        }



    }
}
