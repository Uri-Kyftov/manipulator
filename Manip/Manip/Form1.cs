using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;

namespace Manip
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames(); // Инициализация переменной для хранения инфорации о портах
            comboBox1.Text = ""; // Отчистка информации о существующих портах
            comboBox1.Items.Clear();
            if (ports.Length != 0) // Проверка присутсвия информации о портах
            {
                comboBox1.Items.AddRange(ports); // Внесение всей информации о доступных портах в комбобокс
                comboBox1.SelectedIndex = 0;
            }
        }

        private void button2_Click(object sender, EventArgs e) // Инициализация кнопки "Подключиться/Отключиться"
        {
            if (button2.Text == "Подключиться") // Далее при подключении доступа к порту
            {
                try
                {
                    serialPort1.PortName = comboBox1.Text; // Подключение к порту выбранному из списка доступных
                    serialPort1.BaudRate = 115200; // Инициализация скорости передачи данных
                    serialPort1.Open(); // Запуск передачи данных по выбранному порту
                    serialPort1.WriteLine("$G"); // Инициализация режима работы CNC Shield
                    serialPort1.WriteLine("$$"); // Запуск стандартых настроек G-code
                    comboBox1.Enabled = false; // Отключение комбобокса для выбора порта
                    button2.Text = "Отключиться"; // Смена названия кнопки
                    groupBox1.Enabled = true; // Включить доступ к ручному управлению
                    button14.Enabled = true; // Включить доступ к кнопке запуска автономной работы
                }
                catch
                {
                    MessageBox.Show("Ошибка подключения"); // Выводится при ошибке подключение к порту
                }
            }
            else if (button2.Text == "Отключиться") // Далее при отключении доступа к порту
            {
                comboBox1.Enabled = true; // Включение комбобокса для выбора порта
                serialPort1.Close(); // Прервать передачу данных по выбранному порту
                button2.Text = "Подключиться"; // Смена названия кнопки
                button14.Enabled = false; // Отключение доступа к кнопке запуска автономной работы
                groupBox1.Enabled = false; // Отключение доступа к ручному управлению
            }
        }

        private void button3_Click(object sender, EventArgs e) // Отправить команду на движение по оси X
        {
            if (checkBox1.Checked == true) // При ручном управлении
            {
                textBox3.AppendText("G91" + Environment.NewLine + "G0 F" + textBox1.Text + Environment.NewLine + "G01 X-" + textBox2.Text + Environment.NewLine);
            }
            else // При автономном управлении
            {
                serialPort1.WriteLine("G91"); // Режим работы по относительным координатам
                serialPort1.WriteLine("G0 F" + textBox1.Text); // Скорость вращения указанного двигателя 
                serialPort1.WriteLine("G01 X-" + textBox2.Text); // Отправка команды движения для указанного двигателя на указанное количество шагов
            }
        }

        private void button4_Click(object sender, EventArgs e) // Отправить команду на движение по оси X
        {
            if (checkBox1.Checked == true) // При ручном управлении
            {
                textBox3.AppendText("G91" + Environment.NewLine + "G0 F" + textBox1.Text + Environment.NewLine + "G01 X" + textBox2.Text + Environment.NewLine);
            }
            else // При автономном управлении
            {
                serialPort1.WriteLine("G91"); // Режим работы по относительным координатам
                serialPort1.WriteLine("G0 F" + textBox1.Text); // Скорость вращения указанного двигателя 
                serialPort1.WriteLine("G01 X" + textBox2.Text); // Отправка команды движения для указанного двигателя на указанное количество шагов
            }
        }

        private void button6_Click(object sender, EventArgs e) // Отправить команду на движение по оси Y
        {
            if (checkBox1.Checked == true) // При ручном управлении
            {
                textBox3.AppendText("G91" + Environment.NewLine + "G0 F" + textBox1.Text + Environment.NewLine + "G01 Y" + textBox2.Text + Environment.NewLine);
            }
            else // При автономном управлении
            {
                serialPort1.WriteLine("G91"); // Режим работы по относительным координатам
                serialPort1.WriteLine("G0 F" + textBox1.Text); // Скорость вращения указанного двигателя 
                serialPort1.WriteLine("G01 Y" + textBox2.Text); // Отправка команды движения для указанного двигателя на указанное количество шагов
            }
        }

        private void button5_Click(object sender, EventArgs e) // Отправить команду на движение по оси Y
        {
            if (checkBox1.Checked == true) // При ручном управлении
            {
                textBox3.AppendText("G91" + Environment.NewLine + "G0 F" + textBox1.Text + Environment.NewLine + "G01 Y-" + textBox2.Text + Environment.NewLine);
            }
            else // При автономном управлении
            {
                serialPort1.WriteLine("G91"); // Режим работы по относительным координатам
                serialPort1.WriteLine("G0 F" + textBox1.Text); // Скорость вращения указанного двигателя 
                serialPort1.WriteLine("G01 Y-" + textBox2.Text); // Отправка команды движения для указанного двигателя на указанное количество шагов
            }
        }

        private void button8_Click(object sender, EventArgs e) // Отправить команду на движение по оси Z
        {
            if (checkBox1.Checked == true) // При ручном управлении
            {
                textBox3.AppendText("G91" + Environment.NewLine + "G0 F" + textBox1.Text + Environment.NewLine + "G01 Z-" + textBox2.Text + Environment.NewLine);
            }
            else // При автономном управлении
            {
                serialPort1.WriteLine("G91"); // Режим работы по относительным координатам
                serialPort1.WriteLine("G0 F" + textBox1.Text); // Скорость вращения указанного двигателя 
                serialPort1.WriteLine("G01 Z-" + textBox2.Text); // Отправка команды движения для указанного двигателя на указанное количество шагов
            }
        }

        private void button7_Click(object sender, EventArgs e) // Отправить команду на движение по оси Z
        { 
            if (checkBox1.Checked == true) // При ручном управлении
            {
                textBox3.AppendText("G91" + Environment.NewLine + "G0 F" + textBox1.Text + Environment.NewLine + "G01 Z" + textBox2.Text + Environment.NewLine);
            }
            else // При автономном управлении
            {
                serialPort1.WriteLine("G91"); // Режим работы по относительным координатам
                serialPort1.WriteLine("G0 F" + textBox1.Text); // Скорость вращения указанного двигателя 
                serialPort1.WriteLine("G01 Z" + textBox2.Text); // Отправка команды движения для указанного двигателя на указанное количество шагов
            }
        }
        private void button10_Click(object sender, EventArgs e) // Отправить команду на движение по оси X и Y
        {
            if (checkBox1.Checked == true) // При ручном управлении
            {
                textBox3.AppendText("G91" + Environment.NewLine + "G0 F" + textBox1.Text + Environment.NewLine + "G01 X-" + textBox2.Text + " Y" + textBox2.Text + Environment.NewLine);
            }
            else // При автономном управлении
            {
                serialPort1.WriteLine("G91"); // Режим работы по относительным координатам
                serialPort1.WriteLine("G0 F" + textBox1.Text); // Скорость вращения указанного двигателя 
                serialPort1.WriteLine("G01 X-" + textBox2.Text + " Y" + textBox2.Text); // Отправка команды движения для указанного двигателя на указанное количество шагов
            }
        }

        private void button12_Click(object sender, EventArgs e) // Отправить команду на движение по оси X и Y
        {
            if (checkBox1.Checked == true) // При ручном управлении
            {
                textBox3.AppendText("G91" + Environment.NewLine + "G0 F" + textBox1.Text + Environment.NewLine + "G01 X" + textBox2.Text + " Y" + textBox2.Text + Environment.NewLine);
            }
            else // При автономном управлении
            {
                serialPort1.WriteLine("G91"); // Режим работы по относительным координатам
                serialPort1.WriteLine("G0 F" + textBox1.Text); // Скорость вращения указанного двигателя 
                serialPort1.WriteLine("G01 X" + textBox2.Text + " Y" + textBox2.Text); // Отправка команды движения для указанного двигателя на указанное количество шагов
            }
        }

        private void button11_Click(object sender, EventArgs e) // Отправить команду на движение по оси X и Y
        {
            if (checkBox1.Checked == true) // При ручном управлении
            {
                textBox3.AppendText("G91" + Environment.NewLine + "G0 F" + textBox1.Text + Environment.NewLine + "G01 X-" + textBox2.Text + " Y-" + textBox2.Text + Environment.NewLine);
            }
            else // При автономном управлении
            {
                serialPort1.WriteLine("G91"); // Режим работы по относительным координатам
                serialPort1.WriteLine("G0 F" + textBox1.Text); // Скорость вращения указанного двигателя 
                serialPort1.WriteLine("G0 X-" + textBox2.Text + " Y-" + textBox2.Text); // Отправка команды движения для указанного двигателя на указанное количество шагов
            }
        }

        private void button13_Click(object sender, EventArgs e) // Отправить команду на движение по оси X и Y
        {
            if (checkBox1.Checked == true) // При ручном управлении
            {
                textBox3.AppendText("G91" + Environment.NewLine + "G0 F" + textBox1.Text + Environment.NewLine + "G01 X" + textBox2.Text + " Y-" + textBox2.Text + Environment.NewLine);
            }
            else // При автономном управлении
            {
                serialPort1.WriteLine("G91"); // Режим работы по относительным координатам
                serialPort1.WriteLine("G0 F" + textBox1.Text); // Скорость вращения указанного двигателя 
                serialPort1.WriteLine("G0 X" + textBox2.Text + " Y-" + textBox2.Text); // Отправка команды движения для указанного двигателя на указанное количество шагов
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar; // Проверка на ввод символов
            if (!Char.IsDigit(number) && number != 8 && number != 46)
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (checkBox1.Checked == true)
            {

            }
            else
            {

            }
            char number = e.KeyChar; // Проверка на ввод символов
            if (!Char.IsDigit(number) && number != 8 && number != 46) e.Handled = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            serialPort1.WriteLine(textBox3.Text); // Отправить список команд из монитора вывода в микроконтроллер
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox3.Text = ""; // Отчистка монитора вывода
        }

        private void button15_Click(object sender, EventArgs e)
        {
            textBox3.Text = File.ReadAllText(@"Auto.NC"); // Сохранение списка команд в файл Auto.NC
        }

        private void button16_Click(object sender, EventArgs e)
        {
            File.WriteAllText(@"Auto.NC", textBox3.Text); // Загрузка списка команд из файл Auto.NC
        }
    }
}
