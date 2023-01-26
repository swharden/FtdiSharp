//#define FT232H                // Enable only one of these defines depending on your device type
#define FT2232H
//#define FT4232H

//###################################################################################################################################
// This code is provided as an example only and is not supported or guaranteed by FTDI
// It is the responsibility of the designer of the system incorporating any part of this code to ensure correct
// and safe operation of their overall system. By using this code, you agree that FTDI and its employees accept 
// no responsibility whatsoever for any consequences resulting from the use of this code. 

// Revision History
// Version  Date    Author  Comments
// ======== ======= ======= ==============================
// 1.0      Feb2017 G Brown  Initial release



using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FTD2XX_NET;
using System.Threading;

namespace SensorDemo
{
    public partial class Form1 : Form
    {


        //###################################################################################################################################
        //###################################################################################################################################
        //##################                                      Definitions                                           #####################
        //###################################################################################################################################
        //###################################################################################################################################

        // ###### Driver defines ######
        FTDI.FT_STATUS ftStatus = FTDI.FT_STATUS.FT_OK;

        // ###### I2C Library defines ######
        const byte I2C_Dir_SDAin_SCLin = 0x00;
        const byte I2C_Dir_SDAin_SCLout = 0x01;
        const byte I2C_Dir_SDAout_SCLout = 0x03;
        const byte I2C_Dir_SDAout_SCLin = 0x02;
        const byte I2C_Data_SDAhi_SCLhi = 0x03;
        const byte I2C_Data_SDAlo_SCLhi = 0x01;
        const byte I2C_Data_SDAlo_SCLlo = 0x00;
        const byte I2C_Data_SDAhi_SCLlo = 0x02;
        // MPSSE clocking commands
        const byte MSB_FALLING_EDGE_CLOCK_BYTE_IN = 0x24;
        const byte MSB_RISING_EDGE_CLOCK_BYTE_IN = 0x20;
        const byte MSB_FALLING_EDGE_CLOCK_BYTE_OUT = 0x11;
        const byte MSB_DOWN_EDGE_CLOCK_BIT_IN = 0x26;
        const byte MSB_UP_EDGE_CLOCK_BYTE_IN = 0x20;
        const byte MSB_UP_EDGE_CLOCK_BYTE_OUT = 0x10;
        const byte MSB_RISING_EDGE_CLOCK_BIT_IN = 0x22;
        const byte MSB_FALLING_EDGE_CLOCK_BIT_OUT = 0x13;
        // Clock
        const uint ClockDivisor = 49;      //          = 199;// for 100KHz
        // Sending and receiving
        static uint NumBytesToSend = 0;
        static uint NumBytesToRead = 0;
        uint NumBytesSent = 0;
        static uint NumBytesRead = 0;
        static byte[] MPSSEbuffer = new byte[500];
        static byte[] InputBuffer = new byte[500];   
        static byte[] InputBuffer2 = new byte[500];
        static uint BytesAvailable = 0;
        static bool I2C_Ack = false;
        static byte AppStatus = 0;
        static byte I2C_Status = 0;
        public bool Running = true;
        static bool DeviceOpen = false;
        // GPIO
        static byte GPIO_Low_Dat = 0;
        static byte GPIO_Low_Dir = 0;
        static byte ADbusReadVal = 0;
        static byte ACbusReadVal = 0;
        
        // ###### Proximity sensor defines ######
        static byte Command = 0x00;
        static byte[] ProxData = new byte[500];
        static UInt16 ProxiValue = 0; 
        static double ProxiValueD = 0;
        public const byte VCNL40x0_ADDRESS = 0x13;//0x13 is 7 bit address, 0x26 is 8bit address
        // registers
        public const byte REGISTER_COMMAND = 0x80;
        public const byte REGISTER_ID = 0x81;
        public const byte REGISTER_PROX_RATE = 0x82;
        public const byte REGISTER_PROX_CURRENT = 0x83;
        public const byte REGISTER_AMBI_PARAMETER = 0x84;
        public const byte REGISTER_AMBI_VALUE = 0x85;
        public const byte REGISTER_PROX_VALUE = 0x87;
        public const byte REGISTER_INTERRUPT_CONTROL = 0x89;
        public const byte REGISTER_INTERRUPT_LOW_THRES = 0x8a;
        public const byte REGISTER_INTERRUPT_HIGH_THRES = 0x8c;
        public const byte REGISTER_INTERRUPT_STATUS = 0x8e;
        public const byte REGISTER_PROX_TIMING = 0xf9;
        // Bits in the registers defined above
        public const byte COMMAND_SELFTIMED_MODE_ENABLE = 0x01;
        public const byte COMMAND_PROX_ENABLE = 0x02;
        public const byte COMMAND_AMBI_ENABLE = 0x04;
        public const byte COMMAND_MASK_PROX_DATA_READY = 0x20;
        public const byte PROX_MEASUREMENT_RATE_31 = 0x04;
        public const byte AMBI_PARA_AVERAGE_32 = 0x05; // DEFAULT
        public const byte AMBI_PARA_AUTO_OFFSET_ENABLE = 0x08; // DEFAULT enable
        public const byte AMBI_PARA_MEAS_RATE_2 = 0x10; // DEFAULT
        public const byte INTERRUPT_THRES_SEL_PROX = 0x00;
        public const byte INTERRUPT_THRES_ENABLE = 0x02;
        public const byte INTERRUPT_COUNT_EXCEED_1 = 0x00; // DEFAULT

        // ###### Colour sensor defines ######
        public const byte COLOR_ADDRESS = 0x29;
        public const byte _ENABLE = 0x80;                   //Enablestatusandinterrupts
        public const byte _ATIME = 0x81;                    //RGBCADCtime
        public const byte _CONTROL = 0x8F;                  //Gaincontrolregister
        public const byte _GAIN_x4 = 0x01;
        public const byte _GAIN_x16 = 0x10;
        public const byte _GAIN_x60 = 0x11;
        static byte Global_Red = 0;
        static byte Global_Green = 0;
        static byte Global_Blue = 0;
        uint devcount = 0;


        


        //###################################################################################################################################
        //###################################################################################################################################
        //##################                          Main Application Layer                                            #####################
        //###################################################################################################################################
        //###################################################################################################################################
        
        
        
        
        // Create new instance of the FTDI device class
        FTDI myFtdiDevice = new FTDI();
                
        public Form1()
        {
            InitializeComponent();
        }


        //###################################################################################################################################
        // When the form loads...

        private void Form1_Load(object sender, EventArgs e)
        {
            
            label4.Text = "Closed";
            label6.Text = "0";

            buttonInit.Enabled = true;
            buttonStart.Enabled = false;
            buttonClose.Enabled = true;

            // Print device type to remind user of type that it was compiled for
            // could auto detect based on device info instead of setting defines at top of code
#if (FT232H)
            {
                label8.Text = "FT232H";
            }
#elif (FT2232H)
            {
                label8.Text = "FT2232H";
            }
#elif (FT4232H)
            {
                label8.Text = "FT4232H";
            }
#else
            {
                label8.Text = "error - no define set";
            }
#endif

        }

        //###################################################################################################################################
        // Code for the INITIALISE button...
        
        private void button1_Click(object sender, EventArgs e)
        {
            bool DeviceInit = false;
            buttonInit.Enabled = false;
            
            try
            {
                ftStatus = myFtdiDevice.GetNumberOfDevices(ref devcount);
            }
            catch
            {
                label4.Text = "Driver not loaded";
                
                buttonInit.Enabled = false;
                buttonStart.Enabled = false;
                buttonClose.Enabled = true;
            }
            
            // e.g. open a UM232H Module by it's description
            //ftStatus = myFtdiDevice.OpenByDescription("UM232H");  // could replace line below
            ftStatus = myFtdiDevice.OpenByIndex(0);

            // Update the Status text line
            if (ftStatus == FTDI.FT_STATUS.FT_OK)
            {
                DeviceOpen = true;
                label4.Text = "Open";
            }
            else
            {
                DeviceOpen = false;
                label4.Text = "No Device Found";
            }

            Update(); 
            Application.DoEvents();

            // If the device opened successfully, initialise MPSSE and then configure prox and colour sensors over I2C 
            if (DeviceOpen == true)
            {
                DeviceInit = true;
                
                AppStatus = I2C_ConfigureMpsse();
                if (AppStatus != 0)
                {
                    label4.Text = "Failed Init";
                    DeviceInit = false;
                }

                if (DeviceInit == true)
                {
                    AppStatus = ProximitySensorConfig();
                    if (AppStatus != 0)
                    {
                        label4.Text = "Failed ProxInit";
                        DeviceInit = false;
                    }
                }

                if (DeviceInit == true)
                {
                    AppStatus = ColourSensorConfig();
                    if (AppStatus != 0)
                    {
                        label4.Text = "Failed ColorInit";
                        DeviceInit = false;
                    }
                }

                if (DeviceInit == true)
                {
                    // allow user to start or exit
                    buttonInit.Enabled = false;
                    buttonStart.Enabled = true;
                    buttonClose.Enabled = true;

                    label4.Text = "Ready";
                }
                else
                {
                    label4.Text = "Failed Init";
                    myFtdiDevice.Close();
                    // allow re-init or exit
                    buttonInit.Enabled = true;
                    buttonStart.Enabled = false;
                    buttonClose.Enabled = true;
                }
                
                Update();
                Application.DoEvents();
            }
            else
            {
                // allow re-init or exit
                buttonInit.Enabled = true;
                buttonStart.Enabled = false;
                buttonClose.Enabled = true;


            }
        }
        
        //###################################################################################################################################
        // Code for Start button...
        
        private void button2_Click(object sender, EventArgs e)
        {
            bool StatusLED = false;
            
            // Only allow user to stop/exit
            buttonInit.Enabled = false;
            buttonStart.Enabled = false;
            buttonClose.Enabled = true;
            buttonClose.Focus();

            Color col = new Color();
            
            Running = true;
            label4.Text = "Running";



            // Set the line AD3 as output driving low to turn off white LED on colour sensor
            // only upper 5 bits of these values have any effect as bits 2:0 are for the I2C lines
            GPIO_Low_Dat = 0x00;
            GPIO_Low_Dir = 0x08;
            AppStatus = I2C_SetLineStatesIdle();
            if (AppStatus != 0)
            {
                label4.Text = "Error";
                Running = false;
                buttonInit.Enabled = true;
                buttonStart.Enabled = false;
                buttonClose.Enabled = true;
            }
            

            // Main measurement loop runs whilst running == true
            while (Running == true)
            {
                
                // #####   LED CODE #####

                // Code to toggle LED on each reading
                if(StatusLED == false)      
                {
                    AppStatus = I2C_SetGPIOValuesHigh(0x40, 0x00);    // set direction of AC6 as output, value is 0 (low) for LED on
                    StatusLED = true;
                }
                else
                {
                    AppStatus = I2C_SetGPIOValuesHigh(0x40, 0x40);    // set direction of AC6 as output, value is 1 (high) for LED off
                    StatusLED = false;
                }
                //If write to MPSSE failed (e.g. device unplugged) then stop running
                if (AppStatus != 0)
                {
                    label4.Text = "Error";
                    Running = false;
                    buttonInit.Enabled = false;
                    buttonStart.Enabled = false;
                    buttonClose.Enabled = true;
                }

                // #####   PROX CODE #####

                // If running is true, take a proximity reading and print the value to the readout on the screen
                if (Running == true)
                {
                    AppStatus = ProximitySensorReading();   // blocks until reading available
                    if (AppStatus != 0)
                    {
                        label4.Text = "Error";
                        Running = false;
                        buttonInit.Enabled = false;
                        buttonStart.Enabled = false;
                        buttonClose.Enabled = true;
                    }
                }
                label6.Text = ProxiValue.ToString();
                // This code just makes the behaviour appear more linear and reduces jitter when no object close
                // sensor gives approx 2500 as a background value when no object near
                progressBar1.Maximum = 5000;
                // If object near...
                if (ProxiValue > 2500)              
                {
                   ProxiValueD = (double)ProxiValue - 2300;
                   ProxiValueD = (Math.Log10((double)ProxiValueD) * 1000);
                }
                // Or no object near, put to 0...
                else
                {
                   ProxiValueD = 0;
                }

                progressBar1.Value = (int)ProxiValueD;

                // #####   COLOR CODE #####

                // Check if an object is close enough to make colour sensing accurate
                if (ProxiValue > 10000)
                {
                    GPIO_Low_Dat = 0x08;        // turn on white LED on ACbus3 by writing logic 1
                                                // GPIO_Low_Dir was already set to 0x08 earlier in the code
                    if (Running == true)
                    {
                        AppStatus = ColourSensorReading();
                        if (AppStatus != 0)
                        {
                            label4.Text = "Error";
                            Running = false;
                            buttonInit.Enabled = false;
                            buttonStart.Enabled = false;
                            buttonClose.Enabled = true;
                        }
                        else
                        {
                            // display raw data and also set background colour of slider area of window
                            labelR.Text = Global_Red.ToString();
                            labelG.Text = Global_Green.ToString();
                            labelB.Text = Global_Blue.ToString();
                            textBox1.BackColor = Color.FromArgb(Global_Red, Global_Green, Global_Blue);
                        }
                    }
                }
                else
                {
                    // if no object close, blank the readings and set window background to default colour 
                    GPIO_Low_Dat = 0x0;
                    labelR.Text = "-";
                    labelG.Text = "-";
                    labelB.Text = "-";
                    textBox1.BackColor = SystemColors.ControlLight;
                }



                Update();
                Application.DoEvents();
            }
        }

        //###################################################################################################################################
        // Code for the STOP button
        
        private void button3_Click(object sender, EventArgs e)
        {

            Running = false;
            label4.Text = "Stopping";
            Update();
            Application.DoEvents();

            // Make sure the activity LED is off (high)
            AppStatus = I2C_SetGPIOValuesHigh(0x40, 0x40);    // set direction of AC6 as output, value is 1 (high) for LED off 
            if (AppStatus != 0)
            {
                label4.Text = "Error";
                buttonInit.Enabled = false;
                buttonStart.Enabled = false;
                buttonClose.Enabled = true;
            }

            // Make sure the white LED of the colour sensor is off (ADbus3 is high)
            GPIO_Low_Dat = 0x08;
            GPIO_Low_Dir = 0x08;
            AppStatus = I2C_SetLineStatesIdle();
            if (AppStatus != 0)
            {
                label4.Text = "Error";
                buttonInit.Enabled = false;
                buttonStart.Enabled = false;
                buttonClose.Enabled = true;
            }

            // Close the FTDI device and then close the window
            myFtdiDevice.Close();
            Thread.Sleep(1000);
            label4.Text = "Closed";
            this.Close();
        }
        




        //###################################################################################################################################
        //###################################################################################################################################
        //##################                          Sensor Layer                                                      #####################
        //###################################################################################################################################
        //###################################################################################################################################


        public byte ProximitySensorConfig()
        {
            // Write 20 to current setting register
            // VCNL_WrSingle(REGISTER_PROX_CURRENT, 20);
            AppStatus = I2C_SetStart();                                                     // I2C START
            if (AppStatus != 0) return 1;           
            AppStatus = I2C_SendDeviceAddrAndCheckACK((byte)(VCNL40x0_ADDRESS), false);     // I2C ADDRESS (for write)
            if (AppStatus != 0) return 1;
            if (I2C_Ack != true) { I2C_SetStop(); return 1; }                                 // if sensor NAKs then send stop and return
            AppStatus = I2C_SendByteAndCheckACK((byte)(REGISTER_PROX_CURRENT));             // SEND REGISTER ID
            if (AppStatus != 0) return 1;
            if (I2C_Ack != true) { I2C_SetStop(); return 1; }                                 // if sensor NAKs then send stop and return
            AppStatus = I2C_SendByteAndCheckACK((byte)(20));                                // SEND VALUE TO WRITE
            if (AppStatus != 0) return 1;
            if (I2C_Ack != true) { I2C_SetStop(); return 1; }                                 // if sensor NAKs then send stop and return
            AppStatus = I2C_SetStop();                                                      // I2C STOP
            if (AppStatus != 0) return 1;


            // VCNL_WrSingle(REGISTER_PROX_RATE, PROX_MEASUREMENT_RATE_31);
            AppStatus = I2C_SetStart();                                                     // I2C START
            if (AppStatus != 0) return 1;
            AppStatus = I2C_SendDeviceAddrAndCheckACK((byte)(VCNL40x0_ADDRESS), false);     // I2C ADDRESS (for write)
            if (AppStatus != 0) return 1;
            if (I2C_Ack != true) { I2C_SetStop(); return 1; }                                 // if sensor NAKs then send stop and return
            AppStatus = I2C_SendByteAndCheckACK((byte)(REGISTER_PROX_RATE));                // SEND REGISTER ID
            if (AppStatus != 0) return 1;
            if (I2C_Ack != true) { I2C_SetStop(); return 1; }                                 // if sensor NAKs then send stop and return
            AppStatus = I2C_SendByteAndCheckACK((byte)(PROX_MEASUREMENT_RATE_31));          // SEND VALUE TO WRITE
            if (AppStatus != 0) return 1;
            if (I2C_Ack != true) { I2C_SetStop(); return 1; }                                 // if sensor NAKs then send stop and return
            AppStatus = I2C_SetStop();                                                      // I2C STOP
            if (AppStatus != 0) return 1;


            // VCNL_WrSingle(REGISTER_COMMAND, COMMAND_PROX_ENABLE | COMMAND_AMBI_ENABLE | COMMAND_SELFTIMED_MODE_ENABLE);
            AppStatus = I2C_SetStart();                                                     // I2C START
            if (AppStatus != 0) return 1;
            AppStatus = I2C_SendDeviceAddrAndCheckACK((byte)(VCNL40x0_ADDRESS), false);     // I2C ADDRESS (for write)
            if (AppStatus != 0) return 1;
            if (I2C_Ack != true) { I2C_SetStop(); return 1; }                                 // if sensor NAKs then send stop and return
            AppStatus = I2C_SendByteAndCheckACK((byte)(REGISTER_COMMAND));                  // SEND REGISTER ID
            if (AppStatus != 0) return 1;
            if (I2C_Ack != true) { I2C_SetStop(); return 1; }                                 // if sensor NAKs then send stop and return
            AppStatus = I2C_SendByteAndCheckACK((byte)(COMMAND_PROX_ENABLE | COMMAND_AMBI_ENABLE | COMMAND_SELFTIMED_MODE_ENABLE)); // SEND VALUE TO WRITE
            if (AppStatus != 0) return 1;
            if (I2C_Ack != true) { I2C_SetStop(); return 1; }                                 // if sensor NAKs then send stop and return
            AppStatus = I2C_SetStop();                                                     // I2C STOP
            if (AppStatus != 0) return 1;


            // VCNL_WrSingle(REGISTER_INTERRUPT_CONTROL, INTERRUPT_THRES_SEL_PROX | INTERRUPT_THRES_ENABLE | INTERRUPT_COUNT_EXCEED_1);
            AppStatus = I2C_SetStart();                                                     // I2C START
            if (AppStatus != 0) return 1;
            AppStatus = I2C_SendDeviceAddrAndCheckACK((byte)(VCNL40x0_ADDRESS), false);     // I2C ADDRESS (for write)
            if (AppStatus != 0) return 1;
            if (I2C_Ack != true) { I2C_SetStop(); return 1; }                                 // if sensor NAKs then send stop and return
            AppStatus = I2C_SendByteAndCheckACK((byte)(REGISTER_INTERRUPT_CONTROL));        // SEND REGISTER ID
            if (AppStatus != 0) return 1;
            if (I2C_Ack != true) { I2C_SetStop(); return 1; }                                 // if sensor NAKs then send stop and return
            AppStatus = I2C_SendByteAndCheckACK((byte)(INTERRUPT_THRES_SEL_PROX | INTERRUPT_THRES_ENABLE | INTERRUPT_COUNT_EXCEED_1));// SEND VALUE TO WRITE
            if (AppStatus != 0) return 1;
            if (I2C_Ack != true) { I2C_SetStop(); return 1; }                                 // if sensor NAKs then send stop and return
            AppStatus = I2C_SetStop();                                                     // I2C STOP
            if (AppStatus != 0) return 1;


            // VCNL_WrSingle(REGISTER_AMBI_PARAMETER, AMBI_PARA_AVERAGE_32 | AMBI_PARA_AUTO_OFFSET_ENABLE | AMBI_PARA_MEAS_RATE_2);
            AppStatus = I2C_SetStart();                                                     // I2C START
            if (AppStatus != 0) return 1;
            AppStatus = I2C_SendDeviceAddrAndCheckACK((byte)(VCNL40x0_ADDRESS), false);     // I2C ADDRESS (for write)
            if (AppStatus != 0) return 1;
            if (I2C_Ack != true) { I2C_SetStop(); return 1; }                                 // if sensor NAKs then send stop and return
            AppStatus = I2C_SendByteAndCheckACK((byte)(REGISTER_AMBI_PARAMETER));           // SEND REGISTER ID
            if (AppStatus != 0) return 1;
            if (I2C_Ack != true) { I2C_SetStop(); return 1; }                                 // if sensor NAKs then send stop and return
            AppStatus = I2C_SendByteAndCheckACK((byte)(AMBI_PARA_AVERAGE_32 | AMBI_PARA_AUTO_OFFSET_ENABLE | AMBI_PARA_MEAS_RATE_2));// SEND VALUE TO WRITE
            if (AppStatus != 0) return 1;
            if (I2C_Ack != true) { I2C_SetStop(); return 1; }                                 // if sensor NAKs then send stop and return
            AppStatus = I2C_SetStop();                                                      // I2C STOP
            if (AppStatus != 0) return 1;

            return 0;

        }
        //###################################################################################################################################
        
        private byte ProximitySensorReading()
        {
            // wait on prox reading
            do
            {
                AppStatus = I2C_SetStart();                                                 // I2C START
                if (AppStatus != 0) return 1;
                AppStatus = I2C_SendDeviceAddrAndCheckACK((byte)(VCNL40x0_ADDRESS), false); // I2C ADDRESS (for write)
                if (AppStatus != 0) return 1;
                if (I2C_Ack != true) { I2C_SetStop(); return 1; }                                 // if sensor NAKs then send stop and return
                AppStatus = I2C_SendByteAndCheckACK((byte)(REGISTER_COMMAND));              // SEND REGISTER ID
                if (AppStatus != 0) return 1;
                if (I2C_Ack != true) { I2C_SetStop(); return 1; }                                 // if sensor NAKs then send stop and return
                AppStatus = I2C_SetStart();                                                 // REPEAT START
                if (AppStatus != 0) return 1;
                AppStatus = I2C_SendDeviceAddrAndCheckACK((byte)(VCNL40x0_ADDRESS), true);  // I2C ADDRESS (for read)
                if (AppStatus != 0) return 1;
                if (I2C_Ack != true) { I2C_SetStop(); return 1; }                                 // if sensor NAKs then send stop and return
                AppStatus = I2C_ReadByte(false);                                            // I2C READ (send Nak)
                if (AppStatus != 0) return 1;
                Command = InputBuffer2[0];                                                  // Get the byte read
                AppStatus = I2C_SetStop();                                                  // I2C STOP
                if (AppStatus != 0) return 1;
            } while ((Command & (COMMAND_MASK_PROX_DATA_READY)) == 0);

            // If prox data ready bit was set in byte above, take the reading

                //VCNL_RdSeq(REGISTER_PROX_VALUE, &data_, 2);
            AppStatus = I2C_SetStart();                                                     // I2C START
                if (AppStatus != 0) return 1;
                AppStatus = I2C_SendDeviceAddrAndCheckACK((byte)(VCNL40x0_ADDRESS), false); // I2C ADDRESS (for write)
                if (AppStatus != 0) return 1;
                if (I2C_Ack != true) { I2C_SetStop(); return 1; }                                 // if sensor NAKs then send stop and return
                AppStatus = I2C_SendByteAndCheckACK((byte)(REGISTER_PROX_VALUE));           // SEND REGISTER ID
                if (AppStatus != 0) return 1;
                if (I2C_Ack != true) { I2C_SetStop(); return 1; }                                 // if sensor NAKs then send stop and return
                AppStatus = I2C_SetStart();                                                 // REPEAT START
                if (AppStatus != 0) return 1;
                AppStatus = I2C_SendDeviceAddrAndCheckACK((byte)(VCNL40x0_ADDRESS), true);  // I2C ADDRESS (for read)
                if (AppStatus != 0) return 1;
                if (I2C_Ack != true) { I2C_SetStop(); return 1; }                                 // if sensor NAKs then send stop and return
                AppStatus = I2C_ReadByte(true);                                             // I2C READ (send Ack)
                if (AppStatus != 0) return 1;
                ProxData[0] = InputBuffer2[0];                                                // Get the byte read
                AppStatus = I2C_ReadByte(false);                                            // I2C READ (send Nak)
                if (AppStatus != 0) return 1;
                ProxData[1] = InputBuffer2[0];                                                // Get the byte read
                AppStatus = I2C_SetStop();                                                  // I2C STOP
                if (AppStatus != 0) return 1;
                ProxiValue = (UInt16)((ProxData[0] << 8) | ProxData[1]);
                //ProxiFlag = true;
                //Console.WriteLine("Prox Value      " + ProxiValue.ToString());
       

            return 0;
        }





        //###################################################################################################################################



        private byte ColourSensorConfig()
        {
            //Initialise Color sensor TCS3471

            // Write value 0x1B to ENABLE register
            AppStatus = I2C_SetStart();                                                     // I2C START
            if (AppStatus != 0) return 1;
            AppStatus = I2C_SendDeviceAddrAndCheckACK((byte)(COLOR_ADDRESS), false);        // I2C ADDRESS (for write)
            if (AppStatus != 0) return 1;
            if (I2C_Ack != true) { I2C_SetStop(); return 1; }                                 // if sensor NAKs then send stop and return
            AppStatus = I2C_SendByteAndCheckACK((byte)(_ENABLE));                           // SEND REGISTER ID
            if (AppStatus != 0) return 1;
            if (I2C_Ack != true) { I2C_SetStop(); return 1; }                                 // if sensor NAKs then send stop and return
            AppStatus = I2C_SendByteAndCheckACK((byte)(0x1B));                              // SEND VALUE TO WRITE    
            if (AppStatus != 0) return 1;
            if (I2C_Ack != true) { I2C_SetStop(); return 1; }                                 // if sensor NAKs then send stop and return
            AppStatus = I2C_SetStop();                                                      // I2C STOP
            if (AppStatus != 0) return 1;

            // Write value 0x to CONTROL register
            AppStatus = I2C_SetStart();                                                     // I2C START
            if (AppStatus != 0) return 1;
            AppStatus = I2C_SendDeviceAddrAndCheckACK((byte)(COLOR_ADDRESS), false);        // I2C ADDRESS (for write)
            if (AppStatus != 0) return 1;
            if (I2C_Ack != true) { I2C_SetStop(); return 1; }                                 // if sensor NAKs then send stop and return
            AppStatus = I2C_SendByteAndCheckACK((byte)(_CONTROL));                          // SEND REGISTER ID
            if (AppStatus != 0) return 1;
            if (I2C_Ack != true) { I2C_SetStop(); return 1; }                                 // if sensor NAKs then send stop and return
            AppStatus = I2C_SendByteAndCheckACK((byte)(_GAIN_x16));                         // SEND VALUE TO WRITE  
            if (AppStatus != 0) return 1;
            if (I2C_Ack != true) { I2C_SetStop(); return 1; }                                 // if sensor NAKs then send stop and return
            AppStatus = I2C_SetStop();                                                      // I2C STOP
            if (AppStatus != 0) return 1;

            // Write value 0x to ATIME register
            AppStatus = I2C_SetStart();                                                     // I2C START
            if (AppStatus != 0) return 1;
            AppStatus = I2C_SendDeviceAddrAndCheckACK((byte)(COLOR_ADDRESS), false);        // I2C ADDRESS (for write)
            if (AppStatus != 0) return 1;
            if (I2C_Ack != true) { I2C_SetStop(); return 1; }                                 // if sensor NAKs then send stop and return
            AppStatus = I2C_SendByteAndCheckACK((byte)(_ATIME));                            // SEND REGISTER ID
            if (AppStatus != 0) return 1;
            if (I2C_Ack != true) { I2C_SetStop(); return 1; }                                 // if sensor NAKs then send stop and return
            AppStatus = I2C_SendByteAndCheckACK((byte)(0x00));                              // SEND VALUE TO WRITE  
            if (AppStatus != 0) return 1;
            if (I2C_Ack != true) { I2C_SetStop(); return 1; }                                 // if sensor NAKs then send stop and return
            AppStatus = I2C_SetStop();                                                      // I2C STOP
            if (AppStatus != 0) return 1;

            return 0;    // can indicate other error codes if preferred

        }


        //###################################################################################################################################


       private byte ColourSensorReading()
        {

            byte ClearColorSensorL = 0;
            byte ClearColorSensorH = 0;
            ushort ClearColorSensor = 0;

            byte RedColorSensorL = 0;
            byte RedColorSensorH = 0;
            ushort RedColorSensor = 0;

            byte GreenColorSensorL = 0;
            byte GreenColorSensorH = 0;
            ushort GreenColorSensor = 0;

            byte BlueColorSensorL = 0;
            byte BlueColorSensorH = 0;
            ushort BlueColorSensor = 0;

           // Do a multi-byte read of all four colour value registers (8 bytes in total)
            AppStatus = I2C_SetStart();                                                     // I2C START
            if (AppStatus != 0) return 1;
            AppStatus = I2C_SendDeviceAddrAndCheckACK((byte)(COLOR_ADDRESS), false);        // I2C ADDRESS (for write)
            if (AppStatus != 0) return 1;
            if (I2C_Ack != true) { I2C_SetStop(); return 1; }                                 // if sensor NAKs then send stop and return
            AppStatus = I2C_SendByteAndCheckACK((byte)(0xB4));                              // SEND REGISTER ID
            if (AppStatus != 0) return 1;
            if (I2C_Ack != true) { I2C_SetStop(); return 1; }                                 // if sensor NAKs then send stop and return
            AppStatus = I2C_SetStart();                                                     // REPEAT START
            if (AppStatus != 0) return 1;
            AppStatus = I2C_SendDeviceAddrAndCheckACK((byte)(COLOR_ADDRESS), true);         // I2C ADDRESS (for read)
            if (AppStatus != 0) return 1;
            if (I2C_Ack != true) { I2C_SetStop(); return 1; }                                 // if sensor NAKs then send stop and return
            AppStatus = I2C_ReadByte(true);                                                 // I2C READ (send Ack)
            if (AppStatus != 0) return 1;
            ClearColorSensorL = InputBuffer2[0];                                              // Get the byte read
            AppStatus = I2C_ReadByte(true);                                                 // I2C READ (send Ack)
            if (AppStatus != 0) return 1;
            ClearColorSensorH = InputBuffer2[0];                                              // Get the byte read
            AppStatus = I2C_ReadByte(true);                                                 // I2C READ (send Ack)
            if (AppStatus != 0) return 1;
            RedColorSensorL = InputBuffer2[0];                                                // Get the byte read
            AppStatus = I2C_ReadByte(true);                                                 // I2C READ (send Ack)
            if (AppStatus != 0) return 1;
            RedColorSensorH = InputBuffer2[0];                                                // Get the byte read
            AppStatus = I2C_ReadByte(true);                                                 // I2C READ (send Ack)
            if (AppStatus != 0) return 1;
            GreenColorSensorL = InputBuffer2[0];                                              // Get the byte read
            AppStatus = I2C_ReadByte(true);                                                 // I2C READ (send Ack)
            if (AppStatus != 0) return 1;
            GreenColorSensorH = InputBuffer2[0];                                              // Get the byte read
            AppStatus = I2C_ReadByte(true);                                                 // I2C READ (send Ack)
            if (AppStatus != 0) return 1;
            BlueColorSensorL = InputBuffer2[0];                                               // Get the byte read
            AppStatus = I2C_ReadByte(false);                                                // I2C READ (send Nak)
            if (AppStatus != 0) return 1;
            BlueColorSensorH = InputBuffer2[0];                                               // Get the byte read
            AppStatus = I2C_SetStop();                                                      // I2C STOP
            if (AppStatus != 0) return 1;

            // Combine upper and lower values
            ClearColorSensor = (ushort)((ClearColorSensorH * 256) | ClearColorSensorL);     
            RedColorSensor = (ushort)((RedColorSensorH * 256) | RedColorSensorL);
            GreenColorSensor = (ushort)((GreenColorSensorH * 256) | GreenColorSensorL);
            BlueColorSensor = (ushort)((BlueColorSensorH * 256) | BlueColorSensorL);

           // this code adjusts the colour readings to make on-screen colour closer to the real object being measured
           // this could be improved or optimised depending on the application and environmental surroundings
            if (ClearColorSensor > 0)
            {
                //RedColorSensor = (ushort)(RedColorSensor / (0.002 * ClearColorSensor));
                //GreenColorSensor = (ushort)((0.768 * GreenColorSensor) / (0.002 * ClearColorSensor));
                //BlueColorSensor = (ushort)((0.852 * BlueColorSensor) / (0.002 * ClearColorSensor));

                RedColorSensor = (ushort)((RedColorSensor*1.0) / (0.002 * ClearColorSensor));
                GreenColorSensor = (ushort)((GreenColorSensor*1.0) / (0.002 * ClearColorSensor));
                BlueColorSensor = (ushort)((BlueColorSensor*1.2) / (0.002 * ClearColorSensor));
                
            }
            else
            {
                RedColorSensor = (ushort)(1.0 * (RedColorSensor >> 6));
                GreenColorSensor = (ushort)(1.0 * (GreenColorSensor >> 6));
                BlueColorSensor = (ushort)(1.0 * (BlueColorSensor >> 6));
            }


            Global_Red = (byte)(RedColorSensor < 255 ? RedColorSensor : 0xFF);
            Global_Green = (byte)(GreenColorSensor < 255 ? GreenColorSensor : 0xFF);
            Global_Blue = (byte)(BlueColorSensor < 255 ? BlueColorSensor : 0xFF);
           
            return 0;    
           
       }








       //###################################################################################################################################
       //###################################################################################################################################
       //##################                             I2C Layer                                                      #####################
       //###################################################################################################################################
       //###################################################################################################################################


        public byte I2C_ConfigureMpsse()
        {

            byte ADbusVal = 0;
            byte ADbusDir = 0;
            NumBytesToSend = 0;

            /***** Initial device configuration *****/

            ftStatus = FTDI.FT_STATUS.FT_OK;
            ftStatus |= myFtdiDevice.SetTimeouts(5000, 5000);
            ftStatus |= myFtdiDevice.SetLatency(16);
            ftStatus |= myFtdiDevice.SetFlowControl(FTDI.FT_FLOW_CONTROL.FT_FLOW_RTS_CTS, 0x00,0x00);
            ftStatus |= myFtdiDevice.SetBitMode(0x00, 0x00);
            ftStatus |= myFtdiDevice.SetBitMode(0x00, 0x02);         // MPSSE mode        

            if (ftStatus != FTDI.FT_STATUS.FT_OK)
                return 1; // error();

            /***** Flush the buffer *****/
            I2C_Status = FlushBuffer();

            /***** Synchronize the MPSSE interface by sending bad command 0xAA *****/
            NumBytesToSend = 0;
            MPSSEbuffer[NumBytesToSend++] = 0xAA;
            I2C_Status = Send_Data(NumBytesToSend);
            if (I2C_Status != 0) return 1; // error();
            NumBytesToRead = 2;
            I2C_Status = Receive_Data(2);
            if (I2C_Status !=0) return 1; //error();

            if ((InputBuffer2[0] == 0xFA) && (InputBuffer2[1] == 0xAA))
            {
                //Console.WriteLine("Bad Command Echo successful");
            }
            else
            {
                return 1;            //error();
            }
            
            /***** Synchronize the MPSSE interface by sending bad command 0xAB *****/
            NumBytesToSend = 0;
            MPSSEbuffer[NumBytesToSend++] = 0xAB;
            I2C_Status = Send_Data(NumBytesToSend);
            if (I2C_Status != 0) return 1; // error();
            NumBytesToRead = 2;
            I2C_Status = Receive_Data(2);
            if (I2C_Status !=0) return 1; //error();

            if ((InputBuffer2[0] == 0xFA) && (InputBuffer2[1] == 0xAB))
            {
                //Console.WriteLine("Bad Command Echo successful");
            }
            else
            {
                return 1;            //error();
            }

            NumBytesToSend = 0;
            MPSSEbuffer[NumBytesToSend++] = 0x8A; 	// Disable clock divide by 5 for 60Mhz master clock
            MPSSEbuffer[NumBytesToSend++] = 0x97;	// Turn off adaptive clocking
            MPSSEbuffer[NumBytesToSend++] = 0x8C; 	// Enable 3 phase data clock, used by I2C to allow data on both clock edges
            // The SK clock frequency can be worked out by below algorithm with divide by 5 set as off
            // SK frequency  = 60MHz /((1 +  [(1 +0xValueH*256) OR 0xValueL])*2)
            MPSSEbuffer[NumBytesToSend++] = 0x86; 	//Command to set clock divisor
            MPSSEbuffer[NumBytesToSend++] = (byte)(ClockDivisor & 0x00FF);	//Set 0xValueL of clock divisor
            MPSSEbuffer[NumBytesToSend++] = (byte)((ClockDivisor >> 8) & 0x00FF);	//Set 0xValueH of clock divisor
            MPSSEbuffer[NumBytesToSend++] = 0x85; 			// loopback off

#if (FT232H)
            MPSSEbuffer[NumBytesToSend++] = 0x9E;       //Enable the FT232H's drive-zero mode with the following enable mask...
            MPSSEbuffer[NumBytesToSend++] = 0x07;       // ... Low byte (ADx) enables - bits 0, 1 and 2 and ... 
            MPSSEbuffer[NumBytesToSend++] = 0x00;       //...High byte (ACx) enables - all off

            ADbusVal = (byte)(0x00 | I2C_Data_SDAhi_SCLhi | (GPIO_Low_Dat & 0xF8)); // SDA and SCL both output high (open drain)
            ADbusDir = (byte)(0x00 | I2C_Dir_SDAout_SCLout | (GPIO_Low_Dir & 0xF8));
#else
            ADbusVal = (byte)(0x00 | I2C_Data_SDAlo_SCLlo | (GPIO_Low_Dat & 0xF8));  	// SDA and SCL set low but as input to mimic open drain
            ADbusDir = (byte)(0x00 | I2C_Dir_SDAin_SCLin | (GPIO_Low_Dir & 0xF8));	//

#endif


            MPSSEbuffer[NumBytesToSend++] = 0x80; 	//Command to set directions of lower 8 pins and force value on bits set as output 
            MPSSEbuffer[NumBytesToSend++] = (byte)(ADbusVal);
            MPSSEbuffer[NumBytesToSend++] = (byte)(ADbusDir);


            I2C_Status = Send_Data(NumBytesToSend);
            if (I2C_Status != 0)
            {
                return 1;            //error();
            }
            else
            {
                return 0;
            }
        }

        //###################################################################################################################################
        // Reads a byte over I2C 

        public byte I2C_ReadByte(bool ACK)
        {
            byte ADbusVal = 0;
            byte ADbusDir = 0;
            NumBytesToSend = 0;
            
#if (FT232H)
            // Clock in one data byte
            MPSSEbuffer[NumBytesToSend++] = MSB_RISING_EDGE_CLOCK_BYTE_IN;      // Clock data byte in
            MPSSEbuffer[NumBytesToSend++] = 0x00;
            MPSSEbuffer[NumBytesToSend++] = 0x00;                               // Data length of 0x0000 means 1 byte data to clock in

            // clock out one bit as ack/nak bit
            MPSSEbuffer[NumBytesToSend++] = MSB_FALLING_EDGE_CLOCK_BIT_OUT;     // Clock data bit out
            MPSSEbuffer[NumBytesToSend++] = 0x00;                               // Length of 0 means 1 bit
            if (ACK == true)
                MPSSEbuffer[NumBytesToSend++] = 0x00;                           // Data bit to send is a '0'
            else
                MPSSEbuffer[NumBytesToSend++] = 0xFF;                           // Data bit to send is a '1'

            // I2C lines back to idle state 
            ADbusVal = (byte)(0x00 | I2C_Data_SDAhi_SCLlo | (GPIO_Low_Dat & 0xF8));
            ADbusDir = (byte)(0x00 | I2C_Dir_SDAout_SCLout | (GPIO_Low_Dir & 0xF8));
            MPSSEbuffer[NumBytesToSend++] = 0x80;                               //       ' Command - set low byte
            MPSSEbuffer[NumBytesToSend++] = ADbusVal;                            //      ' Set the values
            MPSSEbuffer[NumBytesToSend++] = ADbusDir;                             //     ' Set the directions
#else          
            // Ensure line is definitely an input since FT2232H and FT4232H don't have open drain
            ADbusVal = (byte)(0x00 | I2C_Data_SDAlo_SCLlo | (GPIO_Low_Dat & 0xF8));
            ADbusDir = (byte)(0x00 | I2C_Dir_SDAin_SCLout | (GPIO_Low_Dir & 0xF8)); // make data input
            MPSSEbuffer[NumBytesToSend++] = 0x80;                                   // command - set low byte
            MPSSEbuffer[NumBytesToSend++] = ADbusVal;                               // Set the values
            MPSSEbuffer[NumBytesToSend++] = ADbusDir;                               // Set the directions
            // Clock one byte of data in from the sensor
            MPSSEbuffer[NumBytesToSend++] = MSB_RISING_EDGE_CLOCK_BYTE_IN;      // Clock data byte in
            MPSSEbuffer[NumBytesToSend++] = 0x00;
            MPSSEbuffer[NumBytesToSend++] = 0x00;                               // Data length of 0x0000 means 1 byte data to clock in
            
            // Change direction back to output and clock out one bit. If ACK is true, we send bit as 0 as an acknowledge
            ADbusVal = (byte)(0x00 | I2C_Data_SDAlo_SCLlo | (GPIO_Low_Dat & 0xF8));
            ADbusDir = (byte)(0x00 | I2C_Dir_SDAout_SCLout | (GPIO_Low_Dir & 0xF8));    // back to output
            MPSSEbuffer[NumBytesToSend++] = 0x80;                               // Command - set low byte
            MPSSEbuffer[NumBytesToSend++] = ADbusVal;                           // set the values
            MPSSEbuffer[NumBytesToSend++] = ADbusDir;                           // set the directions

            MPSSEbuffer[NumBytesToSend++] = MSB_FALLING_EDGE_CLOCK_BIT_OUT;    // Clock data bit out
            MPSSEbuffer[NumBytesToSend++] = 0x00;                              // Length of 0 means 1 bit
            if (ACK == true)
            {
                MPSSEbuffer[NumBytesToSend++] = 0x00;                          // Data bit to send is a '0'
            }
            else
            {
                MPSSEbuffer[NumBytesToSend++] = 0xFF;                          // Data bit to send is a '1'
            }

            // Put line states back to idle with SDA open drain high (set to input) 
            ADbusVal = (byte)(0x00 | I2C_Data_SDAlo_SCLlo | (GPIO_Low_Dat & 0xF8));
            ADbusDir = (byte)(0x00 | I2C_Dir_SDAin_SCLout | (GPIO_Low_Dir & 0xF8));//make data input
            MPSSEbuffer[NumBytesToSend++] = 0x80;                               //       ' Command - set low byte
            MPSSEbuffer[NumBytesToSend++] = ADbusVal;                            //      ' Set the values
            MPSSEbuffer[NumBytesToSend++] = ADbusDir;                             //     ' Set the directions

            
#endif
            // This command then tells the MPSSE to send any results gathered back immediately
            MPSSEbuffer[NumBytesToSend++] = 0x87;                                  //    ' Send answer back immediate command

            // send commands to chip
            I2C_Status = Send_Data(NumBytesToSend);
            if (I2C_Status != 0)
            {
                return 1;
            }

            // get the byte which has been read from the driver's receive buffer
            I2C_Status = Receive_Data(1);
            if (I2C_Status != 0)
            {
                return 1;
            }
            
            // InputBuffer2[0] now contains the results

            return 0;
        }
         

        //###################################################################################################################################
        // Sends I2C address followed by reading 2 bytes
        
        public byte I2C_Read2BytesWithAddr(byte Address)
        {
            byte ADbusVal = 0;
            byte ADbusDir = 0;
            NumBytesToSend = 0;
            
            // ------------------------------------ Address ------------------------------------
            
            Address <<= 1;
            Address |= 0x01;

#if (FT232H)
            MPSSEbuffer[NumBytesToSend++] = MSB_FALLING_EDGE_CLOCK_BYTE_OUT;        // clock data byte out
            MPSSEbuffer[NumBytesToSend++] = 0x00;                                   // 
            MPSSEbuffer[NumBytesToSend++] = 0x00;                                   //  Data length of 0x0000 means 1 byte data to clock in
            MPSSEbuffer[NumBytesToSend++] = Address;// DataSend[0];          //  Byte to send

            // Put line back to idle (data released, clock pulled low)
            ADbusVal = (byte)(0x00 | I2C_Data_SDAhi_SCLlo | (GPIO_Low_Dat & 0xF8));
            ADbusDir = (byte)(0x00 | I2C_Dir_SDAout_SCLout | (GPIO_Low_Dir & 0xF8));// make data input
            MPSSEbuffer[NumBytesToSend++] = 0x80;                                   // Command - set low byte
            MPSSEbuffer[NumBytesToSend++] = ADbusVal;                               // Set the values
            MPSSEbuffer[NumBytesToSend++] = ADbusDir;                               // Set the directions

            // CLOCK IN ACK
            MPSSEbuffer[NumBytesToSend++] = MSB_RISING_EDGE_CLOCK_BIT_IN;           // clock data bits in
            MPSSEbuffer[NumBytesToSend++] = 0x00;                                   // Length of 0 means 1 bit
#else

            // Set directions of clock and data to output in preparation for clocking out a byte
            ADbusVal = (byte)(0x00 | I2C_Data_SDAlo_SCLlo | (GPIO_Low_Dat & 0xF8));
            ADbusDir = (byte)(0x00 | I2C_Dir_SDAout_SCLout | (GPIO_Low_Dir & 0xF8));// back to output
            MPSSEbuffer[NumBytesToSend++] = 0x80;                                   // Command - set low byte
            MPSSEbuffer[NumBytesToSend++] = ADbusVal;                               // Set the values
            MPSSEbuffer[NumBytesToSend++] = ADbusDir;                               // Set the directions
            // clock out one byte
            MPSSEbuffer[NumBytesToSend++] = MSB_FALLING_EDGE_CLOCK_BYTE_OUT;        // clock data byte out
            MPSSEbuffer[NumBytesToSend++] = 0x00;                                   // 
            MPSSEbuffer[NumBytesToSend++] = 0x00;                                   // Data length of 0x0000 means 1 byte data to clock in
            MPSSEbuffer[NumBytesToSend++] = Address;                         // Byte to send

            // Put line back to idle (data released, clock pulled low) so that sensor can drive data line
            ADbusVal = (byte)(0x00 | I2C_Data_SDAlo_SCLlo | (GPIO_Low_Dat & 0xF8));
            ADbusDir = (byte)(0x00 | I2C_Dir_SDAin_SCLout | (GPIO_Low_Dir & 0xF8)); // make data input
            MPSSEbuffer[NumBytesToSend++] = 0x80;                                   // Command - set low byte
            MPSSEbuffer[NumBytesToSend++] = ADbusVal;                               // Set the values
            MPSSEbuffer[NumBytesToSend++] = ADbusDir;                               // Set the directions

            // CLOCK IN ACK
            MPSSEbuffer[NumBytesToSend++] = MSB_RISING_EDGE_CLOCK_BIT_IN;           // clock data byte in
            MPSSEbuffer[NumBytesToSend++] = 0x00;                                   // Length of 0 means 1 bit

#endif

            // ------------------------------------ Clock in 1st byte and ACK ------------------------------------

#if (FT232H)
            MPSSEbuffer[NumBytesToSend++] = MSB_RISING_EDGE_CLOCK_BYTE_IN;      // Clock data byte in
            MPSSEbuffer[NumBytesToSend++] = 0x00;
            MPSSEbuffer[NumBytesToSend++] = 0x00;                               // Data length of 0x0000 means 1 byte data to clock in

            MPSSEbuffer[NumBytesToSend++] = MSB_FALLING_EDGE_CLOCK_BIT_OUT;    // Clock data bit out
            MPSSEbuffer[NumBytesToSend++] = 0x00;                              // Length of 0 means 1 bit
            MPSSEbuffer[NumBytesToSend++] = 0x00;                              // Sending 0 here as ACK

            ADbusVal = (byte)(0x00 | I2C_Data_SDAhi_SCLlo | (GPIO_Low_Dat & 0xF8));
            ADbusDir = (byte)(0x00 | I2C_Dir_SDAout_SCLout | (GPIO_Low_Dir & 0xF8));

            MPSSEbuffer[NumBytesToSend++] = 0x80;                               //       ' Command - set low byte
            MPSSEbuffer[NumBytesToSend++] = ADbusVal;                            //      ' Set the values
            MPSSEbuffer[NumBytesToSend++] = ADbusDir;                             //     ' Set the directions
#else          

            MPSSEbuffer[NumBytesToSend++] = MSB_RISING_EDGE_CLOCK_BYTE_IN;      // Clock data byte in
            MPSSEbuffer[NumBytesToSend++] = 0x00;
            MPSSEbuffer[NumBytesToSend++] = 0x00;                               // Data length of 0x0000 means 1 byte data to clock in
            
            // Send a 0 bit as an acknowledge
            ADbusVal = (byte)(0x00 | I2C_Data_SDAlo_SCLlo | (GPIO_Low_Dat & 0xF8));
            ADbusDir = (byte)(0x00 | I2C_Dir_SDAout_SCLout | (GPIO_Low_Dir & 0xF8));//back to output
            MPSSEbuffer[NumBytesToSend++] = 0x80;                               //       ' Command - set low byte
            MPSSEbuffer[NumBytesToSend++] = ADbusVal;                            //      ' Set the values
            MPSSEbuffer[NumBytesToSend++] = ADbusDir;                             //     ' Set the directions

            MPSSEbuffer[NumBytesToSend++] = MSB_FALLING_EDGE_CLOCK_BIT_OUT;    // Clock data bit out
            MPSSEbuffer[NumBytesToSend++] = 0x00;                              // Length of 0 means 1 bit
            MPSSEbuffer[NumBytesToSend++] = 0x00;                              // Sending 0 here as ACK
            
            ADbusVal = (byte)(0x00 | I2C_Data_SDAlo_SCLlo | (GPIO_Low_Dat & 0xF8));
            ADbusDir = (byte)(0x00 | I2C_Dir_SDAin_SCLout | (GPIO_Low_Dir & 0xF8));//make data input
            
            MPSSEbuffer[NumBytesToSend++] = 0x80;                               //       ' Command - set low byte
            MPSSEbuffer[NumBytesToSend++] = ADbusVal;                            //      ' Set the values
            MPSSEbuffer[NumBytesToSend++] = ADbusDir;                             //     ' Set the directions

            
#endif

            // ------------------------------------ Clock in 2nd byte and NAK ------------------------------------

#if (FT232H)
            MPSSEbuffer[NumBytesToSend++] = MSB_RISING_EDGE_CLOCK_BYTE_IN;      // Clock data byte in
            MPSSEbuffer[NumBytesToSend++] = 0x00;
            MPSSEbuffer[NumBytesToSend++] = 0x00;                               // Data length of 0x0000 means 1 byte data to clock in

            MPSSEbuffer[NumBytesToSend++] = MSB_FALLING_EDGE_CLOCK_BIT_OUT;    // Clock data bit out
            MPSSEbuffer[NumBytesToSend++] = 0x00;                              // Length of 0 means 1 bit
            MPSSEbuffer[NumBytesToSend++] = 0xFF;                              // Sending 1 here as NAK

            ADbusVal = (byte)(0x00 | I2C_Data_SDAhi_SCLlo | (GPIO_Low_Dat & 0xF8));
            ADbusDir = (byte)(0x00 | I2C_Dir_SDAout_SCLout | (GPIO_Low_Dir & 0xF8));

            MPSSEbuffer[NumBytesToSend++] = 0x80;                               //       ' Command - set low byte
            MPSSEbuffer[NumBytesToSend++] = ADbusVal;                            //      ' Set the values
            MPSSEbuffer[NumBytesToSend++] = ADbusDir;                             //     ' Set the directions
#else
            MPSSEbuffer[NumBytesToSend++] = MSB_RISING_EDGE_CLOCK_BYTE_IN;      // Clock data byte in
            MPSSEbuffer[NumBytesToSend++] = 0x00;
            MPSSEbuffer[NumBytesToSend++] = 0x00;                               // Data length of 0x0000 means 1 byte data to clock in
            
            // Send a 1 bit as a Nack
            ADbusVal = (byte)(0x00 | I2C_Data_SDAlo_SCLlo | (GPIO_Low_Dat & 0xF8));
            ADbusDir = (byte)(0x00 | I2C_Dir_SDAout_SCLout | (GPIO_Low_Dir & 0xF8));//back to output
            MPSSEbuffer[NumBytesToSend++] = 0x80;                               //       ' Command - set low byte
            MPSSEbuffer[NumBytesToSend++] = ADbusVal;                            //      ' Set the values
            MPSSEbuffer[NumBytesToSend++] = ADbusDir;                             //     ' Set the directions

            MPSSEbuffer[NumBytesToSend++] = MSB_FALLING_EDGE_CLOCK_BIT_OUT;    // Clock data bit out
            MPSSEbuffer[NumBytesToSend++] = 0x00;                              // Length of 0 means 1 bit
            MPSSEbuffer[NumBytesToSend++] = 0xFF;                              // Sending 1 here as NAK
                                   
            ADbusVal = (byte)(0x00 | I2C_Data_SDAlo_SCLlo | (GPIO_Low_Dat & 0xF8));
            ADbusDir = (byte)(0x00 | I2C_Dir_SDAin_SCLout | (GPIO_Low_Dir & 0xF8));//make data input
            
            MPSSEbuffer[NumBytesToSend++] = 0x80;                               //       ' Command - set low byte
            MPSSEbuffer[NumBytesToSend++] = ADbusVal;                            //      ' Set the values
            MPSSEbuffer[NumBytesToSend++] = ADbusDir;                             //     ' Set the directions
                        
#endif
            // This command then tells the MPSSE to send any results gathered back immediately
            MPSSEbuffer[NumBytesToSend++] = 0x87;                                //  ' Send answer back immediate command

            // Send off the commands
            I2C_Status = Send_Data(NumBytesToSend);
            if (I2C_Status != 0)
            {
                return 1;
            }

            // Read back the ack from the address phase and the 2 bytes read
            I2C_Status = Receive_Data(3);
            if (I2C_Status != 0)
            {
                return 1;
            }
            
            // Check if address phase was acked
            if ((InputBuffer2[0] & 0x01) == 0)
            {
                I2C_Ack = true;
            }
            else
            {
                I2C_Ack = false;
            }
            
            // Get the two data bytes to put back to the calling function - InputBuffer2[0..1] now contains the results
            InputBuffer2[0] = InputBuffer2[1];
            InputBuffer2[1] = InputBuffer2[2];            
                        
            return 0;
            
        }

        
        //###################################################################################################################################

        public byte I2C_SendDeviceAddrAndCheckACK(byte Address, bool Read)
        {


            byte ADbusVal = 0;
            byte ADbusDir = 0;
            NumBytesToSend = 0;

            Address <<= 1;
            if (Read == true)
                Address |= 0x01;

#if (FT232H)
            MPSSEbuffer[NumBytesToSend++] = MSB_FALLING_EDGE_CLOCK_BYTE_OUT;        // clock data byte out
            MPSSEbuffer[NumBytesToSend++] = 0x00;                                   // 
            MPSSEbuffer[NumBytesToSend++] = 0x00;                                   //  Data length of 0x0000 means 1 byte data to clock in
            MPSSEbuffer[NumBytesToSend++] = Address;           //  Byte to send

            // Put line back to idle (data released, clock pulled low)
            ADbusVal = (byte)(0x00 | I2C_Data_SDAhi_SCLlo | (GPIO_Low_Dat & 0xF8));
            ADbusDir = (byte)(0x00 | I2C_Dir_SDAout_SCLout | (GPIO_Low_Dir & 0xF8));// make data input
            MPSSEbuffer[NumBytesToSend++] = 0x80;                                   // Command - set low byte
            MPSSEbuffer[NumBytesToSend++] = ADbusVal;                               // Set the values
            MPSSEbuffer[NumBytesToSend++] = ADbusDir;                               // Set the directions

            // CLOCK IN ACK
            MPSSEbuffer[NumBytesToSend++] = MSB_RISING_EDGE_CLOCK_BIT_IN;           // clock data bits in
            MPSSEbuffer[NumBytesToSend++] = 0x00;                                   // Length of 0 means 1 bit
#else

            // Set directions of clock and data to output in preparation for clocking out a byte
            ADbusVal = (byte)(0x00 | I2C_Data_SDAlo_SCLlo | (GPIO_Low_Dat & 0xF8));
            ADbusDir = (byte)(0x00 | I2C_Dir_SDAout_SCLout | (GPIO_Low_Dir & 0xF8));// back to output
            MPSSEbuffer[NumBytesToSend++] = 0x80;                                   // Command - set low byte
            MPSSEbuffer[NumBytesToSend++] = ADbusVal;                               // Set the values
            MPSSEbuffer[NumBytesToSend++] = ADbusDir;                               // Set the directions
            // clock out one byte
            MPSSEbuffer[NumBytesToSend++] = MSB_FALLING_EDGE_CLOCK_BYTE_OUT;        // clock data byte out
            MPSSEbuffer[NumBytesToSend++] = 0x00;                                   // 
            MPSSEbuffer[NumBytesToSend++] = 0x00;                                   // Data length of 0x0000 means 1 byte data to clock in
            MPSSEbuffer[NumBytesToSend++] = Address;                         // Byte to send

            // Put line back to idle (data released, clock pulled low) so that sensor can drive data line
            ADbusVal = (byte)(0x00 | I2C_Data_SDAlo_SCLlo | (GPIO_Low_Dat & 0xF8));
            ADbusDir = (byte)(0x00 | I2C_Dir_SDAin_SCLout | (GPIO_Low_Dir & 0xF8)); // make data input
            MPSSEbuffer[NumBytesToSend++] = 0x80;                                   // Command - set low byte
            MPSSEbuffer[NumBytesToSend++] = ADbusVal;                               // Set the values
            MPSSEbuffer[NumBytesToSend++] = ADbusDir;                               // Set the directions

            // CLOCK IN ACK
            MPSSEbuffer[NumBytesToSend++] = MSB_RISING_EDGE_CLOCK_BIT_IN;           // clock data byte in
            MPSSEbuffer[NumBytesToSend++] = 0x00;                                   // Length of 0 means 1 bit

#endif
            // This command then tells the MPSSE to send any results gathered (in this case the ack bit) back immediately
            MPSSEbuffer[NumBytesToSend++] = 0x87;                                //  ' Send answer back immediate command

            // send commands to chip
            I2C_Status = Send_Data(NumBytesToSend);
            if (I2C_Status != 0)
            {
                return 1;
            }

            // read back byte containing ack
            I2C_Status = Receive_Data(1);
            if (I2C_Status != 0)
            {
                return 1;            // can also check NumBytesRead
            }

            // if ack bit is 0 then sensor acked the transfer, otherwise it nak'd the transfer
            if ((InputBuffer2[0] & 0x01) == 0)
            {
                I2C_Ack = true;
            }
            else
            {
                I2C_Ack = false;
            }

            return 0;

        }

        //###################################################################################################################################
        // Writes one byte to the I2C bus

        public byte I2C_SendByteAndCheckACK(byte DataByteToSend)
        {
            byte ADbusVal = 0;
            byte ADbusDir = 0;
            NumBytesToSend = 0;

#if (FT232H)
            MPSSEbuffer[NumBytesToSend++] = MSB_FALLING_EDGE_CLOCK_BYTE_OUT;        // clock data byte out
            MPSSEbuffer[NumBytesToSend++] = 0x00;                                   // 
            MPSSEbuffer[NumBytesToSend++] = 0x00;                                   //  Data length of 0x0000 means 1 byte data to clock in
            MPSSEbuffer[NumBytesToSend++] = DataByteToSend;// DataSend[0];          //  Byte to send

            // Put line back to idle (data released, clock pulled low)
            ADbusVal = (byte)(0x00 | I2C_Data_SDAhi_SCLlo | (GPIO_Low_Dat & 0xF8));
            ADbusDir = (byte)(0x00 | I2C_Dir_SDAout_SCLout | (GPIO_Low_Dir & 0xF8));// make data input
            MPSSEbuffer[NumBytesToSend++] = 0x80;                                   // Command - set low byte
            MPSSEbuffer[NumBytesToSend++] = ADbusVal;                               // Set the values
            MPSSEbuffer[NumBytesToSend++] = ADbusDir;                               // Set the directions

            // CLOCK IN ACK
            MPSSEbuffer[NumBytesToSend++] = MSB_RISING_EDGE_CLOCK_BIT_IN;           // clock data bits in
            MPSSEbuffer[NumBytesToSend++] = 0x00;                                   // Length of 0 means 1 bit
#else

            // Set directions of clock and data to output in preparation for clocking out a byte
            ADbusVal = (byte)(0x00 | I2C_Data_SDAlo_SCLlo | (GPIO_Low_Dat & 0xF8));
            ADbusDir = (byte)(0x00 | I2C_Dir_SDAout_SCLout | (GPIO_Low_Dir & 0xF8));// back to output
            MPSSEbuffer[NumBytesToSend++] = 0x80;                                   // Command - set low byte
            MPSSEbuffer[NumBytesToSend++] = ADbusVal;                               // Set the values
            MPSSEbuffer[NumBytesToSend++] = ADbusDir;                               // Set the directions
            // clock out one byte
            MPSSEbuffer[NumBytesToSend++] = MSB_FALLING_EDGE_CLOCK_BYTE_OUT;        // clock data byte out
            MPSSEbuffer[NumBytesToSend++] = 0x00;                                   // 
            MPSSEbuffer[NumBytesToSend++] = 0x00;                                   // Data length of 0x0000 means 1 byte data to clock in
            MPSSEbuffer[NumBytesToSend++] = DataByteToSend;                         // Byte to send

            // Put line back to idle (data released, clock pulled low) so that sensor can drive data line
            ADbusVal = (byte)(0x00 | I2C_Data_SDAlo_SCLlo | (GPIO_Low_Dat & 0xF8));
            ADbusDir = (byte)(0x00 | I2C_Dir_SDAin_SCLout | (GPIO_Low_Dir & 0xF8)); // make data input
            MPSSEbuffer[NumBytesToSend++] = 0x80;                                   // Command - set low byte
            MPSSEbuffer[NumBytesToSend++] = ADbusVal;                               // Set the values
            MPSSEbuffer[NumBytesToSend++] = ADbusDir;                               // Set the directions

            // CLOCK IN ACK
            MPSSEbuffer[NumBytesToSend++] = MSB_RISING_EDGE_CLOCK_BIT_IN;           // clock data byte in
            MPSSEbuffer[NumBytesToSend++] = 0x00;                                   // Length of 0 means 1 bit

#endif
            // This command then tells the MPSSE to send any results gathered (in this case the ack bit) back immediately
            MPSSEbuffer[NumBytesToSend++] = 0x87;                                //  ' Send answer back immediate command

            // send commands to chip
            I2C_Status = Send_Data(NumBytesToSend);
            if (I2C_Status != 0)
            {
                return 1;
            }

            // read back byte containing ack
            I2C_Status = Receive_Data(1);
            if (I2C_Status != 0)
            {
                return 1;            // can also check NumBytesRead
            }
       
            // if ack bit is 0 then sensor acked the transfer, otherwise it nak'd the transfer
            if ((InputBuffer2[0] & 0x01) == 0)
            {
                I2C_Ack = true;
            }
            else
            {
                I2C_Ack = false;
            }

            return 0;
                               
        }
        
        //###################################################################################################################################
        // Sets I2C Start condition

        public byte I2C_SetStart()
        {
            byte Count = 0;
            byte ADbusVal = 0;
            byte ADbusDir = 0;
            NumBytesToSend = 0;


#if (FT232H)
            // SDA high, SCL high
            ADbusVal = (byte)(0x00 | I2C_Data_SDAhi_SCLhi | (GPIO_Low_Dat & 0xF8));
            ADbusDir = (byte)(0x00 | I2C_Dir_SDAout_SCLout | (GPIO_Low_Dir & 0xF8));    // on FT232H lines always output

            for (Count = 0; Count < 6; Count++)
            {
                MPSSEbuffer[NumBytesToSend++] = 0x80;	    // ADbus GPIO command
                MPSSEbuffer[NumBytesToSend++] = ADbusVal;   // Set data value
                MPSSEbuffer[NumBytesToSend++] = ADbusDir;	// Set direction
            }

            // SDA lo, SCL high
            ADbusVal = (byte)(0x00 | I2C_Data_SDAlo_SCLhi | (GPIO_Low_Dat & 0xF8));

            for (Count = 0; Count < 6; Count++)	// Repeat commands to ensure the minimum period of the start setup time ie 600ns is achieved
            {
                MPSSEbuffer[NumBytesToSend++] = 0x80;	    // ADbus GPIO command
                MPSSEbuffer[NumBytesToSend++] = ADbusVal;   // Set data value
                MPSSEbuffer[NumBytesToSend++] = ADbusDir;	// Set direction
            }

            // SDA lo, SCL lo
            ADbusVal = (byte)(0x00 | I2C_Data_SDAlo_SCLlo | (GPIO_Low_Dat & 0xF8));

            for (Count = 0; Count < 6; Count++)	// Repeat commands to ensure the minimum period of the start setup time ie 600ns is achieved
            {
                MPSSEbuffer[NumBytesToSend++] = 0x80;	    // ADbus GPIO command
                MPSSEbuffer[NumBytesToSend++] = ADbusVal;   // Set data value
                MPSSEbuffer[NumBytesToSend++] = ADbusDir;	// Set direction
            }

            // Release SDA
            ADbusVal = (byte)(0x00 | I2C_Data_SDAhi_SCLlo | (GPIO_Low_Dat & 0xF8));

            MPSSEbuffer[NumBytesToSend++] = 0x80;	    // ADbus GPIO command
            MPSSEbuffer[NumBytesToSend++] = ADbusVal;   // Set data value
            MPSSEbuffer[NumBytesToSend++] = ADbusDir;	// Set direction


# else

            // Both SDA and SCL high (setting to input simulates open drain high)
            ADbusVal = (byte)(0x00 | I2C_Data_SDAlo_SCLlo | (GPIO_Low_Dat & 0xF8));
            ADbusDir = (byte)(0x00 | I2C_Dir_SDAin_SCLin | (GPIO_Low_Dir & 0xF8));

            for (Count = 0; Count < 6; Count++)
            {
                MPSSEbuffer[NumBytesToSend++] = 0x80;	    // ADbus GPIO command
                MPSSEbuffer[NumBytesToSend++] = ADbusVal;   // Set data value
                MPSSEbuffer[NumBytesToSend++] = ADbusDir;	// Set direction
            }

            // SDA low, SCL high (setting to input simulates open drain high)
            ADbusVal = (byte)(0x00 | I2C_Data_SDAlo_SCLlo | (GPIO_Low_Dat & 0xF8));
            ADbusDir = (byte)(0x00 | I2C_Dir_SDAout_SCLin | (GPIO_Low_Dir & 0xF8));

            for (Count = 0; Count < 6; Count++)	// Repeat commands to ensure the minimum period of the start setup time
            {
                MPSSEbuffer[NumBytesToSend++] = 0x80;	    // ADbus GPIO command
                MPSSEbuffer[NumBytesToSend++] = ADbusVal;   // Set data value
                MPSSEbuffer[NumBytesToSend++] = ADbusDir;	// Set direction
            }

            // SDA low, SCL low
            ADbusVal = (byte)(0x00 | I2C_Data_SDAlo_SCLlo | (GPIO_Low_Dat & 0xF8));//
            ADbusDir = (byte)(0x00 | I2C_Dir_SDAout_SCLout | (GPIO_Low_Dir & 0xF8));//as above

            for (Count = 0; Count < 6; Count++)	// Repeat commands to ensure the minimum period of the start setup time
            {
                MPSSEbuffer[NumBytesToSend++] = 0x80;	    // ADbus GPIO command
                MPSSEbuffer[NumBytesToSend++] = ADbusVal;   // Set data value
                MPSSEbuffer[NumBytesToSend++] = ADbusDir;	// Set direction
            }

            // Release SDA (setting to input simulates open drain high)
            ADbusVal = (byte)(0x00 | I2C_Data_SDAlo_SCLlo | (GPIO_Low_Dat & 0xF8));//
            ADbusDir = (byte)(0x00 | I2C_Dir_SDAin_SCLout | (GPIO_Low_Dir & 0xF8));//as above

            MPSSEbuffer[NumBytesToSend++] = 0x80;	    // ADbus GPIO command
            MPSSEbuffer[NumBytesToSend++] = ADbusVal;   // Set data value
            MPSSEbuffer[NumBytesToSend++] = ADbusDir;	// Set direction



# endif
            I2C_Status = Send_Data(NumBytesToSend);
            if (I2C_Status != 0)
                return 1;
            else
                return 0;

        }
        
        //###################################################################################################################################
        // Sets I2C Stop condition

        public byte I2C_SetStop()
        {
            byte Count = 0;
            byte ADbusVal = 0;
            byte ADbusDir = 0;
            NumBytesToSend = 0;

#if (FT232H)
            // SDA low, SCL low
            ADbusVal = (byte)(0x00 | I2C_Data_SDAlo_SCLlo | (GPIO_Low_Dat & 0xF8));
            ADbusDir = (byte)(0x00 | I2C_Dir_SDAout_SCLout | (GPIO_Low_Dir & 0xF8));    // on FT232H lines always output

            for (Count = 0; Count < 6; Count++)
            {
                MPSSEbuffer[NumBytesToSend++] = 0x80;	    // ADbus GPIO command
                MPSSEbuffer[NumBytesToSend++] = ADbusVal;   // Set data value
                MPSSEbuffer[NumBytesToSend++] = ADbusDir;	// Set direction
            }
           
            // SDA low, SCL high
            ADbusVal = (byte)(0x00 | I2C_Data_SDAlo_SCLhi | (GPIO_Low_Dat & 0xF8));
            ADbusDir = (byte)(0x00 | I2C_Dir_SDAout_SCLout | (GPIO_Low_Dir & 0xF8));    // on FT232H lines always output

            for (Count = 0; Count < 6; Count++)
            {
                MPSSEbuffer[NumBytesToSend++] = 0x80;	    // ADbus GPIO command
                MPSSEbuffer[NumBytesToSend++] = ADbusVal;   // Set data value
                MPSSEbuffer[NumBytesToSend++] = ADbusDir;	// Set direction
            }

            // SDA high, SCL high
            ADbusVal = (byte)(0x00 | I2C_Data_SDAhi_SCLhi | (GPIO_Low_Dat & 0xF8));
            ADbusDir = (byte)(0x00 | I2C_Dir_SDAout_SCLout | (GPIO_Low_Dir & 0xF8));        // on FT232H lines always output

            for (Count = 0; Count < 6; Count++)	
            {
                MPSSEbuffer[NumBytesToSend++] = 0x80;	    // ADbus GPIO command
                MPSSEbuffer[NumBytesToSend++] = ADbusVal;   // Set data value
                MPSSEbuffer[NumBytesToSend++] = ADbusDir;	// Set direction
            }
           
# else

            // SDA low, SCL low
            ADbusVal = (byte)(0x00 | I2C_Data_SDAlo_SCLlo | (GPIO_Low_Dat & 0xF8));
            ADbusDir = (byte)(0x00 | I2C_Dir_SDAout_SCLout | (GPIO_Low_Dir & 0xF8));

            for (Count = 0; Count < 6; Count++)
            {
                MPSSEbuffer[NumBytesToSend++] = 0x80;	    // ADbus GPIO command
                MPSSEbuffer[NumBytesToSend++] = ADbusVal;   // Set data value
                MPSSEbuffer[NumBytesToSend++] = ADbusDir;	// Set direction
            }


            // SDA low, SCL high (note: setting to input simulates open drain high)
            ADbusVal = (byte)(0x00 | I2C_Data_SDAlo_SCLlo | (GPIO_Low_Dat & 0xF8));
            ADbusDir = (byte)(0x00 | I2C_Dir_SDAout_SCLin | (GPIO_Low_Dir & 0xF8));

            for (Count = 0; Count < 6; Count++)
            {
                MPSSEbuffer[NumBytesToSend++] = 0x80;	    // ADbus GPIO command
                MPSSEbuffer[NumBytesToSend++] = ADbusVal;   // Set data value
                MPSSEbuffer[NumBytesToSend++] = ADbusDir;	// Set direction
            }

            // SDA high, SCL high (note: setting to input simulates open drain high)
            ADbusVal = (byte)(0x00 | I2C_Data_SDAlo_SCLlo | (GPIO_Low_Dat & 0xF8));
            ADbusDir = (byte)(0x00 | I2C_Dir_SDAin_SCLin | (GPIO_Low_Dir & 0xF8));

            for (Count = 0; Count < 6; Count++)	// Repeat commands to hold states for longer time
            {
                MPSSEbuffer[NumBytesToSend++] = 0x80;	    // ADbus GPIO command
                MPSSEbuffer[NumBytesToSend++] = ADbusVal;   // Set data value
                MPSSEbuffer[NumBytesToSend++] = ADbusDir;	// Set direction
            }
#endif
           // send the buffer of commands to the chip 
           I2C_Status = Send_Data(NumBytesToSend);
            if (I2C_Status != 0)
                return 1;
            else
                return 0;

        }
        


       //###################################################################################################################################
       // Sets GPIO values on low byte and puts I2C lines (bits 0, 1, 2) to idle outwith transaction state
       
        public byte I2C_SetLineStatesIdle()
       {
           byte ADbusVal = 0;
           byte ADbusDir = 0;
           NumBytesToSend = 0;
            
#if (FT232H)
           // '######## Combine the I2C line state for bits 2..0 with the GPIO for bits 7..3 ########
           ADbusVal = (byte)(0x00 | I2C_Data_SDAhi_SCLhi | (GPIO_Low_Dat & 0xF8));
           ADbusDir = (byte)(0x00 | I2C_Dir_SDAout_SCLout | (GPIO_Low_Dir & 0xF8));    // FT232H always output due to open drain capability    
           
# else
           ADbusVal = (byte)(0x00 | I2C_Data_SDAlo_SCLlo | (GPIO_Low_Dat & 0xF8));
           ADbusDir = (byte)(0x00 | I2C_Dir_SDAin_SCLin | (GPIO_Low_Dir & 0xF8));       // FT2232H/FT4232H use input to mimic open drain
# endif
            
           MPSSEbuffer[NumBytesToSend++] = 0x80;	    // ADbus GPIO command
           MPSSEbuffer[NumBytesToSend++] = ADbusVal;   // Set data value
           MPSSEbuffer[NumBytesToSend++] = ADbusDir;	// Set direction

           I2C_Status = Send_Data(NumBytesToSend);
           if (I2C_Status != 0)
               return 1;
           else
               return 0;
       }





       //###################################################################################################################################
       // Gets GPIO values from low byte

       public byte I2C_GetGPIOValuesLow()
       {
           NumBytesToSend = 0;

           MPSSEbuffer[NumBytesToSend++] = 0x81;	    // ADbus GPIO command for reading low byte
           MPSSEbuffer[NumBytesToSend++] = 0x87;        // Send answer back immediate command
                      
           I2C_Status = Send_Data(NumBytesToSend);
           if (I2C_Status != 0)
               return 1;

           I2C_Status = Receive_Data(1);
           if (I2C_Status != 0)
           {
               return 1;
           }

           ADbusReadVal = (byte)(InputBuffer2[0] & 0xF8); // mask the returned value to show only 5 GPIO lines (bits 0/1/2 are I2C)
               
           return 0;
       }



       //###################################################################################################################################
       // Sets GPIO values on high byte

       public byte I2C_SetGPIOValuesHigh(byte ACbusDir, byte ACbusVal)
       {
           NumBytesToSend = 0;
           
#if (FT4232H)

           return 1;
           
# else
           MPSSEbuffer[NumBytesToSend++] = 0x82;	    // ACbus GPIO command
           MPSSEbuffer[NumBytesToSend++] = ACbusVal;   // Set data value
           MPSSEbuffer[NumBytesToSend++] = ACbusDir;	// Set direction
                      
           I2C_Status = Send_Data(NumBytesToSend);
           if (I2C_Status != 0)
               return 1;
           else
               return 0;

# endif
       }



        //###################################################################################################################################
        // Gets GPIO values from high byte

       public byte I2C_GetGPIOValuesHigh()
       {
            NumBytesToSend = 0;

#if (FT4232H)
                return 1;       // no high byte on FT4232H
# else

           MPSSEbuffer[NumBytesToSend++] = 0x83;	        // ACbus read GPIO command
           MPSSEbuffer[NumBytesToSend++] = 0x87;            // Send answer back immediate command

           I2C_Status = Send_Data(NumBytesToSend);
           if (I2C_Status != 0)
               return 1;

           I2C_Status = Receive_Data(1);
           if (I2C_Status != 0)
               return 1;

           ACbusReadVal = (byte)(InputBuffer2[0]);      // Return via global variable for calling function to read

           return 0;
# endif
       }






        //###################################################################################################################################
        //###################################################################################################################################
        //##################                                          D2xx Layer                                        #####################
        //###################################################################################################################################
        //###################################################################################################################################
                

        // Read a specified number of bytes from the driver receive buffer

        private byte Receive_Data(uint BytesToRead)
        {
            uint NumBytesInQueue = 0;
            uint QueueTimeOut = 0;
            uint Buffer1Index = 0;
            uint Buffer2Index = 0;
            uint TotalBytesRead = 0;
            bool QueueTimeoutFlag = false;
            uint NumBytesRxd = 0;

            // Keep looping until all requested bytes are received or we've tried 5000 times (value can be chosen as required)
            while ((TotalBytesRead < BytesToRead) && (QueueTimeoutFlag == false))
            {
                ftStatus = myFtdiDevice.GetRxBytesAvailable(ref NumBytesInQueue);       // Check bytes available

                if ((NumBytesInQueue > 0) && (ftStatus == FTDI.FT_STATUS.FT_OK))
                {
                    ftStatus = myFtdiDevice.Read(InputBuffer, NumBytesInQueue, ref NumBytesRxd);  // if any available read them

                    if ((NumBytesInQueue == NumBytesRxd) && (ftStatus == FTDI.FT_STATUS.FT_OK))
                    {
                        Buffer1Index = 0;

                        while (Buffer1Index < NumBytesRxd)
                        {
                            InputBuffer2[Buffer2Index] = InputBuffer[Buffer1Index];     // copy into main overall application buffer
                            Buffer1Index++;
                            Buffer2Index++;
                        }
                        TotalBytesRead = TotalBytesRead + NumBytesRxd;                  // Keep track of total
                    }
                    else
                        return 1;

                    QueueTimeOut++;
                    if (QueueTimeOut == 5000)
                        QueueTimeoutFlag = true;
                    else
                        Thread.Sleep(0);                                                // Avoids running Queue status checks back to back
                }
            }
            // returning globals NumBytesRead and the buffer InputBuffer2
            NumBytesRead = TotalBytesRead;

            if (QueueTimeoutFlag == true)
                return 1;
            else
                return 0;
        }


        //###################################################################################################################################
        // Write a buffer of data and check that it got sent without error

        private byte Send_Data(uint BytesToSend)
        {

            NumBytesToSend = BytesToSend;

            // Send data. This will return once all sent or if times out
            ftStatus = myFtdiDevice.Write(MPSSEbuffer, NumBytesToSend, ref NumBytesSent);

            // Ensure that call completed OK and that all bytes sent as requested
            if ((NumBytesSent != NumBytesToSend) || (ftStatus != FTDI.FT_STATUS.FT_OK))
                return 1;   // error   calling function can check NumBytesSent to see how many got sent
            else
                return 0;   // success
        }
        

        //###################################################################################################################################
        // Flush drivers receive buffer - Get queue status and read everything available and discard data

        private byte FlushBuffer()
        {
            ftStatus = myFtdiDevice.GetRxBytesAvailable(ref BytesAvailable);	 // Get the number of bytes in the receive buffer
            if (ftStatus != FTDI.FT_STATUS.FT_OK)
                return 1;
            
            if(BytesAvailable > 0)
            {
                ftStatus = myFtdiDevice.Read(InputBuffer, BytesAvailable, ref NumBytesRead);  	//Read out the data from receive buffer
                if (ftStatus != FTDI.FT_STATUS.FT_OK)
                    return 1;       // error
                else
                    return 0;       // all bytes successfully read
            }
            else
            {
                return 0;           // there were no bytes to read
            }
        }







    }
}

