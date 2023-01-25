namespace FtdiSharpDemo;

public partial class MenuForm : Form
{
    public MenuForm()
    {
        InitializeComponent();
    }

    private void btnConnectedDevices_Click(object sender, EventArgs e) => new DeviceInfoForm().ShowDialog();
    private void btnAddressScanner_Click(object sender, EventArgs e) => new I2CScan().ShowDialog();
}
