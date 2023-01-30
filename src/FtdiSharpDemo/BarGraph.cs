using System.Diagnostics;

namespace FtdiSharpDemo;

public partial class BarGraph : UserControl
{
    public BarGraph()
    {
        InitializeComponent();

        bool isDesignMode = Process.GetCurrentProcess().ProcessName == "devenv";
        panel2.Width = isDesignMode ? panel1.Width / 2 : 0;
        panel2.Height = panel1.Height;
        label1.Text = isDesignMode ? "title" : string.Empty;
    }

    public void SetValue(double value, double max, string label, bool centerAtZero = true)
    {
        label1.Text = label;
        double span = centerAtZero ? max * 2 : max;
        int panelWidth = (int)(Math.Abs(value) / span * panel1.Width);
        int panelCenterX = panel1.Width / 2;

        if (centerAtZero)
        {
            panelWidth /= 2;
            panel2.Width = Math.Max(panelWidth, 1);

            if (value < 0)
            {
                panel2.Left = panelCenterX - panelWidth;
            }
            else
            {
                panel2.Left = panelCenterX;
            }
        }
        else
        {
            panel2.Width = panelWidth;
            panel2.Left = 0;
        }
    }
}
