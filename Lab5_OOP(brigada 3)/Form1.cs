using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ComboBox = System.Windows.Forms.ComboBox;
using TextBox = System.Windows.Forms.TextBox;

namespace Lab5_OOP_brigada_3_
{
    public partial class Form1 : Form
    {
        List<ITrainStation> ListTrainStations = new List<ITrainStation>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("������������");
            comboBox1.Items.Add("��������");
            comboBox1.SelectedIndex = 0;
            comboBox2.Items.Add("���");
            comboBox2.Items.Add("��");
            comboBox2.SelectedIndex = 0;
            ListTrainStations.Add(
                new PassengerTrainStation(
                    "���������� ������",
                    100,
                    1000,
                    "������ ��������",
                    12,
                    (decimal)1500.34,
                    true
                    )
                );
            ListTrainStations.Add(
               new CargoTrainStation(
                   "�����-����",
                   "�����",
                   20,
                   30,
                   10,
                   (decimal)123.43,
                   true
                   )
               );
            radioButton1.Checked = true;
            comboBox4.Enabled = false;
            button4.Enabled = false;

            PrintComboBox();
            PrintRichBox();
        }

        private void PrintRichBox()
        {
            richTextBox1.Clear();
            foreach (var station in ListTrainStations)
            {
                if (station is PassengerTrainStation)
                {
                    richTextBox1.SelectionColor = Color.Red;
                }
                else
                {
                    richTextBox1.SelectionColor = Color.Blue;
                }
                richTextBox1.AppendText(station.ToString());
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (validate())
            {
                if (comboBox1.SelectedIndex == 0)
                {
                    ListTrainStations.Add(
                        new PassengerTrainStation(
                            textBox1.Text,
                            Convert.ToInt32(numericUpDown1.Value),
                            Convert.ToInt32(numericUpDown2.Value),
                            textBox4.Text,
                            Convert.ToInt32(numericUpDown3.Value),
                            numericUpDown4.Value,
                            comboBox2.SelectedText == "��" ? true : false
                        )
                    );
                }
                else
                {
                    ListTrainStations.Add(
                        new CargoTrainStation(
                            textBox1.Text,
                            textBox4.Text,
                            Convert.ToInt32(numericUpDown2.Value),
                            Convert.ToInt32(numericUpDown1.Value),
                            Convert.ToInt32(numericUpDown3.Value),
                            numericUpDown4.Value,
                            comboBox2.SelectedText == "��" ? true : false
                        )
                    );
                }
                PrintRichBox();
                PrintComboBox();
            }
        }

        private bool validate()
        {
            Regex regexString = new(@"^\p{IsCyrillic}+\s*\p{IsCyrillic}*$", RegexOptions.IgnorePatternWhitespace);

            foreach (Control control in groupBox2.Controls)
            {
                if (control is TextBox textBox)
                {
                    if (!regexString.IsMatch(textBox.Text))
                    {
                        textBox.BackColor = Color.Red;
                        MessageBox.Show("������� ���������� (����������� ������ ������� ���������)!", "������");
                        return false;
                    } 
                    else
                    {
                        textBox.BackColor = Color.White;
                    }
                }

                if (control is NumericUpDown numUpDown)
                {
                    if (numUpDown.Value < 0m)
                    {
                        numUpDown.BackColor = Color.Red;
                        MessageBox.Show("������� ���������� �����(������ ����)!", "������");
                        return false;
                    }
                    else
                    {
                        numUpDown.BackColor = Color.White;
                    }
                }

            }

            if (comboBox2.SelectedIndex == -1)
            {
                comboBox2.BackColor = Color.Red;
                MessageBox.Show("�������� ���������� ���������� (�� ��� ���)!", "������");
                return false;
            }
            else
            {
                comboBox2.BackColor = Color.White;
            }

            return true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 1)
            {
                label3.Text = "��� �������:";
                label4.Text = "���-�� ���������:";
                label6.Text = "���-�� �����:";
                label7.Text = "����������� ���������:";
                label8.Text = "������� ������:";
            } 
            else
            {
                label3.Text = "����� ����:";
                label4.Text = "����� ��������� �������:";
                label6.Text = "���-�� ������� � ����:";
                label7.Text = "������� ��������� ������:";
                label8.Text = "������� WI-FI:";
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Enabled = true;
            button1.Enabled = true;
            comboBox4.Enabled = false;
            button4.Enabled = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Enabled = false;
            comboBox4.Enabled = true;
            button4.Enabled = true;
            button1.Enabled = false;
            PrintComboBox();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            var trainStation = ListTrainStations.FirstOrDefault(obj => obj.GetFieldString("�������� �������") == comboBox4.SelectedItem.ToString());
            if (trainStation is PassengerTrainStation)
            {
                label3.Text = "����� ����:";
                label4.Text = "����� ��������� �������:";
                label6.Text = "���-�� ������� � ����:";
                label7.Text = "������� ��������� ������:";
                label8.Text = "������� WI-FI:";
                textBox1.Text = trainStation.GetFieldString("�������� �������");
                numericUpDown1.Value = trainStation.GetFieldInt("����� ����");
                numericUpDown2.Value = trainStation.GetFieldInt("����� ��������� �������");
                textBox4.Text = trainStation.GetFieldString("��������������");
                numericUpDown3.Value = trainStation.GetFieldInt("���������� ������� � ����");
                numericUpDown4.Value = trainStation.GetFieldInt("������� ��������� ������");
                comboBox2.SelectedIndex = trainStation.GetFieldBool("WI-FI") ? 0 : 1;
            }
            else
            {
                label3.Text = "��� �������:";
                label4.Text = "���-�� ���������:";
                label6.Text = "���-�� �����:";
                label7.Text = "����������� ���������:";
                label8.Text = "������� ������:";
                textBox1.Text = trainStation.GetFieldString("�������� �������");
                numericUpDown1.Value = trainStation.GetFieldInt("��� �������");
                numericUpDown2.Value = trainStation.GetFieldInt("���-�� ���������");
                textBox4.Text = trainStation.GetFieldString("��������������");
                numericUpDown3.Value = trainStation.GetFieldInt("���-�� �����");
                numericUpDown4.Value = trainStation.GetFieldInt("����������� ���������");
                comboBox2.SelectedIndex = trainStation.GetFieldBool("�����") ? 1 : 0;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var trainStation = ListTrainStations.FirstOrDefault(obj => obj.GetFieldString("�������� �������") == comboBox4.SelectedItem.ToString());
            if (validate())
            {
                if (trainStation is PassengerTrainStation)
                {
                    PassengerTrainStation passengerTrainStation = (PassengerTrainStation)trainStation;
                    passengerTrainStation.StationName = textBox1.Text;
                    passengerTrainStation.SeatsNumber = Convert.ToInt32(numericUpDown1.Value);
                    passengerTrainStation.TicketsSold = Convert.ToInt32(numericUpDown2.Value);
                    passengerTrainStation.Location = textBox4.Text;
                    passengerTrainStation.TrainsPerDay = Convert.ToInt32(numericUpDown3.Value);
                    passengerTrainStation.AverageTicketPrice = (decimal)numericUpDown4.Value;
                    passengerTrainStation.HasWiFi = comboBox2.SelectedText == "��" ? true : false;
                    
                }
                else
                {
                    CargoTrainStation cargoTrainStation = (CargoTrainStation)trainStation;
                    cargoTrainStation.StationName = textBox1.Text;
                    cargoTrainStation.StationCode = Convert.ToInt32(numericUpDown1.Value);
                    cargoTrainStation.NumberOfSegments = Convert.ToInt32(numericUpDown2.Value);
                    cargoTrainStation.Location = textBox4.Text;
                    cargoTrainStation.NumberOfTracks = Convert.ToInt32(numericUpDown3.Value);
                    cargoTrainStation.CargoStorageCapacity = (decimal)numericUpDown4.Value;
                    cargoTrainStation.HasCranes = comboBox2.SelectedText == "��" ? true : false;
                    
                }
                PrintRichBox();
                PrintComboBox();
            }
        }

        private void PrintComboBox()
        {
            comboBox4.Items.Clear();
            foreach (var station in ListTrainStations)
            {
                comboBox4.Items.Add(station.GetFieldString("�������� �������"));
            }
            comboBox4.SelectedIndex = 0;

            comboBox3.Items.Clear();
            foreach (var item in comboBox4.Items)
            {
                comboBox3.Items.Add(item);
            }
            comboBox3.SelectedIndex = 0;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var trainStation = ListTrainStations.FirstOrDefault(obj => obj.GetFieldString("�������� �������") == comboBox3.SelectedItem.ToString());
            ListTrainStations.Add(trainStation.Clone());
            PrintRichBox();
            PrintComboBox();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (ListTrainStations.Count >= 0)
            {
                var trainStation = ListTrainStations.FirstOrDefault(obj => obj.GetFieldString("�������� �������") == comboBox3.SelectedItem.ToString());
                ListTrainStations.Remove(trainStation);
                PrintRichBox();
                PrintComboBox();
            }
            else
            {
                MessageBox.Show("�� �� ������ ������� ������ ���, ��� �� ������ ���", "������");
            }
        }
    }
}