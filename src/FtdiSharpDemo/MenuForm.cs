namespace FtdiSharpDemo;

public partial class MenuForm : Form
{
    public MenuForm()
    {
        InitializeComponent();
    }

    private void btnConnectedDevices_Click(object sender, EventArgs e) => new DeviceInfoForm().ShowDialog();
    private void btnAddressScanner_Click(object sender, EventArgs e) => new I2C_Scan().ShowDialog();
    private void btnLM75A_Click(object sender, EventArgs e) => new I2C_LM75A().ShowDialog();
}
