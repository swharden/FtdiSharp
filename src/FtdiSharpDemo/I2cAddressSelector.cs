namespace FtdiSharpDemo;

public partial class I2cAddressSelector : UserControl
{
    public byte Address
    {
        get => (byte)nudAddress.Value;
        set => nudAddress.Value = value;
    }

    public I2cAddressSelector()
    {
        InitializeComponent();
    }

    private void nudAddress_ValueChanged(object sender, EventArgs e)
    {
        lblAddress.Text = lblAddress.Text = "0x" + ((int)nudAddress.Value).ToString("X2");
    }
}
