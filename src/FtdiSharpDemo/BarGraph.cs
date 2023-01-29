namespace FtdiSharpDemo;

public partial class BarGraph : UserControl
{
    public bool CenterAtZero = true;

    public BarGraph()
    {
        InitializeComponent();
        panel2.Width = panel1.Width / 2;
        panel2.Height = panel1.Height;
    }

    public void SetValue(double value, double max)
    {
        label1.Text = value.ToString();
        double span = CenterAtZero ? max * 2 : max;
        int panelWidth = (int)(Math.Abs(value) / span * panel1.Width);
        int panelCenterX = panel1.Width / 2;

        if (CenterAtZero)
        {
            panelWidth /= 2;
            panel2.Width = panelWidth;

            if (value == 0)
            {
                panel2.Width = 0;
            }
            else if (value < 0)
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
