using FtdiSharp;

namespace FtdiSharpDemo;

public partial class DeviceSelector : UserControl
{
    readonly List<FtdiDevice> Devices = new();

    public event EventHandler<FtdiDevice> DeviceOpened = delegate { }; // TODO: pass the ftman

    public event EventHandler<FtdiDevice> DeviceClosed = delegate { };

    public DeviceSelector()
    {
        InitializeComponent();
        btnClose.Enabled = false;
        Scan();
    }

    public void Scan()
    {
        cbDevices.Items.Clear();
        Devices.Clear();

        foreach (var device in FtdiDevices.Scan())
        {
            Devices.Add(device);
            cbDevices.Items.Add(device.ToString());
        }

        if (cbDevices.Items.Count > 0 && cbDevices.SelectedIndex == -1)
        {
            cbDevices.SelectedIndex = 0;
        }
    }

    private void btnOpen_Click(object sender, EventArgs e)
    {
        btnOpen.Enabled = false;
        btnClose.Enabled = true;
        cbDevices.Enabled = false;
        FtdiDevice device = Devices[cbDevices.SelectedIndex];
        DeviceOpened.Invoke(this, device);
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
        btnOpen.Enabled = true;
        btnClose.Enabled = false;
        cbDevices.Enabled = true;
        FtdiDevice device = Devices[cbDevices.SelectedIndex];
        DeviceClosed.Invoke(this, device);
    }
}
