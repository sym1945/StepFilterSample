using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace StepFilterSample
{
    public partial class Form1 : Form
    {
        private StepFilter<DataModel> _StepFilter;


        public Form1()
        {
            InitializeComponent();

            Load += Form1_Load;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            var datasSource = new DataRepo().Datas;

            _StepFilter = new StepFilter<DataModel>(
                datasSource,
                (item) => item.FirstValue,
                (item) => item.SecondValue,
                (item) => item.ThirdValue,
                (item) => item.FourthValue
            );

            SetComboBoxItemsSource(comboBox1, _StepFilter.GetFilterValues(0));
            SetComboBoxItemsSource(comboBox2, _StepFilter.GetFilterValues(1));
            SetComboBoxItemsSource(comboBox3, _StepFilter.GetFilterValues(2));
            SetComboBoxItemsSource(comboBox4, _StepFilter.GetFilterValues(3));

            dataModelBindingSource.DataSource = _StepFilter.GetResultDatas();
        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender.Equals(comboBox1))
            {
                _StepFilter.SetFilterValue(0, comboBox1.SelectedItem);
            }
            else if (sender.Equals(comboBox2))
            {
                _StepFilter.SetFilterValue(1, comboBox2.SelectedItem);
            }
            else if (sender.Equals(comboBox3))
            {
                _StepFilter.SetFilterValue(2, comboBox3.SelectedItem);
            }
            else if (sender.Equals(comboBox4))
            {
                _StepFilter.SetFilterValue(3, comboBox4.SelectedItem);
            }


            if (sender.Equals(comboBox1))
            {
                SetComboBoxItemsSource(comboBox2, _StepFilter.GetFilterValues(1));
            }
            if (sender.Equals(comboBox1)
                || sender.Equals(comboBox2))
            {
                SetComboBoxItemsSource(comboBox3, _StepFilter.GetFilterValues(2));
            }
            if (sender.Equals(comboBox1)
                || sender.Equals(comboBox2)
                || sender.Equals(comboBox3))
            {
                SetComboBoxItemsSource(comboBox4, _StepFilter.GetFilterValues(3));
            }


            dataModelBindingSource.DataSource = _StepFilter.GetResultDatas();
        }

        private void SetComboBoxItemsSource(ComboBox comboBox, List<object> items)
        {
            comboBox.SelectedIndexChanged -= comboBox_SelectedIndexChanged;

            comboBox.Items.Clear();
            comboBox.Items.AddRange(items.ToArray());
            comboBox.SelectedItem = items.FirstOrDefault();

            comboBox.SelectedIndexChanged += comboBox_SelectedIndexChanged;
        }

    }

}
