using FtdiSharp;

namespace FtdiSharpDemo;

public partial class DeviceSelector : UserControl
{
    public readonly FtdiManager FTMan = new();

    readonly List<DeviceInfo> Devices = new();

    public event EventHandler DeviceOpened = delegate { }; // TODO: pass the ftman

    public event EventHandler DeviceClosed = delegate { };

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

        foreach (var device in FTMan.GetDevices())
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
        DeviceInfo device = Devices[cbDevices.SelectedIndex];
        FTMan.Open(device);
        DeviceOpened.Invoke(this, EventArgs.Empty);
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
        btnOpen.Enabled = true;
        btnClose.Enabled = false;
        cbDevices.Enabled = true;
        FTMan.Close();
        DeviceClosed.Invoke(this, EventArgs.Empty);
    }
}
