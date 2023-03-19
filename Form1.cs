using System.Linq;
using System.Windows.Forms;

namespace WeatherApp
{
    public partial class WeatherForm : Form
    {
        private WeatherDatabase _weather;

        public WeatherForm()
        {
            InitializeComponent();

            _weather = new WeatherDatabase();
            _weather.Initialize();
            comboBox1.Items.AddRange(new object [4] {"Отсутствует",  MeasureUnits.Kelvin, MeasureUnits.Fahrenheit, MeasureUnits.Celsius });
            comboBox1.SelectedIndex = 0;

            WeatherDataGrid.DataSource = _weather.Weathers.ToList();
        }

        private void textBox1_TextChanged(object sender, System.EventArgs e)
        {

            if (string.IsNullOrEmpty(textBox1.Text))
            {
                WeatherDataGrid.DataSource = _weather.Weathers.ToList();
            }
            else
            {
                var cities = _weather.Weathers.Where(s => s.CityName.ToLower().Contains(textBox1.Text.ToLower())).ToList();
                WeatherDataGrid.DataSource = cities;
            }


        }

        private void label1_Click(object sender, System.EventArgs e)
        {

        }
      
        private void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                WeatherDataGrid.DataSource = _weather.Weathers.ToList();
                return;
            }

            MeasureUnits temp = new MeasureUnits();
            switch (comboBox1.SelectedItem)
            {
                case MeasureUnits.Celsius:
                    temp = MeasureUnits.Celsius;
                    break;
                case MeasureUnits.Kelvin:
                    temp = MeasureUnits.Kelvin;
                    break;
                case MeasureUnits.Fahrenheit:
                    temp = MeasureUnits.Fahrenheit;
                    break;
            }

            var cities = _weather.Weathers.Where(s => s.MeasureUnit == temp).ToList();
            WeatherDataGrid.DataSource = cities;
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            WeatherDataGrid.DataSource = _weather.Weathers.ToList();
            comboBox1.SelectedIndex = 0;
            textBox1.Clear();
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            var plus = _weather.Weathers.Where(s => s.Temperature > 0).ToList();
            WeatherDataGrid.DataSource = plus;
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            var sort = _weather.Weathers.OrderBy(s => s.Temperature).ToList();
            WeatherDataGrid.DataSource = sort;
        }
    }
}






