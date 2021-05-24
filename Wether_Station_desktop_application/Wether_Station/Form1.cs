using System;
using System.Windows.Forms;
using System.IO.Ports;

namespace Wether_Station
{
    public partial class Form1 : Form
    {
        private SerialPort port; //tworzenie portu szeregowego
        private string in_data; //zmiena string do trzymania prywatnych danych
        public Form1() // inicjalizacja programu okienkowego
        {
            InitializeComponent();
            string[] ports = SerialPort.GetPortNames(); //pobranie wejść USART z dostępnymi urządzeniami 
            comboBox1.DataSource = ports; //wyświetlenie dostępnych portów w comboboxie
        }
        private void Connect_Click(object sender, EventArgs e) //funkcja kliknięcia w przycisk connect
        {
            string portName = comboBox1.SelectedItem as string; //pobranie nazwy wybranego portu 
            port = new SerialPort(); //inicjalizacja nowego portu
            port.BaudRate = 38400; //ustawienie parametru USART
            port.PortName = portName;
            port.Parity = Parity.None;
            port.StopBits = StopBits.One;
            port.DataBits = 8;
            port.RtsEnable = true;
            port.Handshake = Handshake.None;
            port.DataReceived += port_DataReceived; // funkcja pobierania danych

            try
            {
                port.Open(); //rozpoczęcie komunikacji
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error"); //W przypadku błedu (np.: rozłączenie portu) wysyłana jest informacja o błędzie
            }

        }
        void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
                in_data = port.ReadLine(); //pobranie lini danch
                this.Invoke(new EventHandler(displaydata_event)); //Evend wyświetlania danych w textboxach
        }

        private void displaydata_event(object sender, EventArgs e)
        {
            string[] datas = in_data.Split(' '); //rozdzielenie danych

            try // W momencie chwilowego błędu transmisji program się nie wyłączy   
            {   // linie kodu naprawiające błąd odczytu
                datas[0] = datas[0].Substring(3);
                datas[2] = datas[2].Substring(0, datas[2].Length - 1);
                datas[3] = datas[4];

                for (int i = 0; i < 4; i++) //Przetwarzanie danych do odpowiedniego formatu
                {
                    double data_double = (double)Convert.ToInt32(datas[i]); //zmiana string na typ double
                    if(i != 3)
                        if (i == 1)
                            data_double = data_double / 10000; // zmiana cisnienia na hektopascale
                         else
                             data_double = data_double / 100; // ustawienie poprawnego przecinka (temperatura, wilgotność)
                    else
                        {
                        //konwersja cyfrowo pobranego napięcia na wartość natężenia światła
                        data_double = (data_double * 3.3)/4095; 
                        data_double = ((3.3 - data_double) * 680) / data_double;
                        data_double = 12500000 * Math.Pow(data_double, -1.4059);
                        }
                    //konwersja przetworzonych danych do typu string
                    datas[i] = Convert.ToString(data_double);
                }
                //wyświetlenie danych w aplikacji
                Temperature.Text = datas[0];
                Pressure.Text = datas[1];
                Humidity.Text = datas[2];
                Light_Intensity.Text = datas[3];
            }
            catch(Exception){}
        }
    }
}
