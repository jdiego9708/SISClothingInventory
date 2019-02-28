using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace CapaPresentacion
{
    public class GetValuePanel
    {
        public static string GetValue(Panel panel)
        {
            string rpta = "";
            try
            {
                foreach (Control control in panel.Controls)
                {
                    if (control is RadioButton rd)
                    {
                        if (rd.Checked)
                        {
                            rpta = rd.Text;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            return rpta;
        }
    }
}
