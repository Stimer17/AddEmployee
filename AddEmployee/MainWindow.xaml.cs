using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AddEmployee
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Entities entities = new Entities();
        public MainWindow()
        {
            InitializeComponent();
        }


        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Employee employee = new Employee();
                employee.FirstName = txtFName.Text;
                employee.LastName = txtLName.Text;
                employee.MiddleName = txtMName.Text;
                if (Convert.ToInt32(cbSpec.SelectedValue) != 0) employee.ID_Competence_FK = Convert.ToInt32(cbSpec.SelectedValue);
                if (Convert.ToInt32(cbWorkShift.SelectedValue) != 0) employee.ID_WorkShift_FK = Convert.ToInt32(cbWorkShift.SelectedValue);
                entities.Employee.Add(employee);
                entities.SaveChanges();
                dgEmployee.ItemsSource = entities.Employee.ToList();
                MessageBox.Show("Данные успешно добавлены");
            }
            catch
            {
                MessageBox.Show("Некорректные данные или ошибка связи с базой данных");
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dgEmployee.ItemsSource = entities.Employee.ToList();
            cbSpec.ItemsSource = entities.Competence.ToList();
            cbWorkShift.ItemsSource = entities.WorkShift.ToList();
        }
    }
}
