using System;
using System.Drawing;
using System.Windows.Forms;

public static class StyleHelper
{
    public static Color PrimaryColor = Color.FromArgb(0, 122, 204);
    public static Color SecondaryColor = Color.FromArgb(240, 242, 245);

    public static void ApplyFormStyle(Form form)
    {
        form.BackColor = SecondaryColor;

        foreach (Control c in form.Controls)
        {
            ApplyControlStyle(c);
        }
    }

    private static void ApplyControlStyle(Control c)
    {
        if (c is NumericUpDown) return;

        if (c.HasChildren)
        {
            foreach (Control child in c.Controls)
            {
                ApplyControlStyle(child);
            }
        }

        if (c is Button btn)
        {
            btn.Cursor = Cursors.Hand;
            btn.FlatStyle = FlatStyle.Standard;
            btn.UseVisualStyleBackColor = true;
        }
        else if (c is Label lbl && lbl.Name.Contains("Title"))
        {
            lbl.ForeColor = PrimaryColor;
        }
        else if (c is DataGridView dgv)
        {
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = PrimaryColor;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }
    }
}