using Dbfirst_northwind.Model;
using Microsoft.Data.SqlClient;
using System.Data.SqlTypes;

namespace Dbfirst_northwind
{
    public partial class Form1 : Form
    {
        NorthwndContext _db;
        public Form1()
        {
            InitializeComponent();
            _db = new NorthwndContext();
            var x = _db.Regions.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var listEmployee = _db.Employees.ToList();

            //MessageBox.Show($"Soyad�:{_db.Employees.First().LastName.ToString()},\nAd�: {_db.Employees.First().FirstName.ToString()},\nDo�umTarihi: {Convert.ToDateTime(_db.Employees.First().BirthDate).ToString()}");

            //2.ci �ekil (daha iyi gibi)
            //var ad2 = _db.Employees.Where(x => x.EmployeeId == 1).Select(x => x.FirstName).FirstOrDefault();
            var ad = _db.Employees.Where(x => x.EmployeeId == 1).Select(x => x.FirstName).ToList();
            MessageBox.Show(ad[0]);

            //3.c� �ekil
            //var message2 = from Employee in _db.Employees where Employee.EmployeeId == 1 select Employee.FirstName;
            var message = (from Employee in _db.Employees where Employee.EmployeeId == 1 select Employee).ToList();
            MessageBox.Show(message[0].FirstName);

            //4.c� �ekil(bence en kral�)
            var message1 = _db.Employees.FirstOrDefault(x => x.EmployeeId == 1);
            MessageBox.Show(message1.FirstName);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var message2 = (from Employee in _db.Employees orderby Employee.FirstName descending select Employee).FirstOrDefault();
            MessageBox.Show(message2.FirstName);

            //2.ci �ekil
            Employee employee = _db.Employees.OrderBy(x => x.FirstName).LastOrDefault();
            MessageBox.Show(employee.FirstName);

            //3.c� �ekil
            Employee employee2 = _db.Employees.OrderByDescending(x => x.FirstName).FirstOrDefault();
            MessageBox.Show(employee2.FirstName);

            //firstOrDefault da bulamazsa null atar hata vermez,First bulamazsa hata mesaj� f�rlat�r.
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string text = " ";
            List<Employee> listEmployeewithFirstA = _db.Employees.Where(a => a.FirstName.StartsWith('A')).ToList();

            foreach (Employee item in listEmployeewithFirstA)
                text += $"{item.FirstName}, ";

            MessageBox.Show(text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string text = " ";
            List<Employee> listEmployeewithFirstA = _db.Employees.Where(a => a.FirstName.Contains('A')).ToList();
            
            foreach (Employee item in listEmployeewithFirstA)
                text += $"{item.FirstName}, ";

            MessageBox.Show(text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string text = " ";
            List<Employee> listEmployeewithFirstA = _db.Employees.ToList();
            foreach (Employee item in listEmployeewithFirstA)
            {
                if (item.FirstName.Equals("Andrew"))
                {
                    text += $"{item.FirstName} {item.LastName}, ";
                }

            }
            MessageBox.Show(text);
        }

        private void button6_Click(object sender, EventArgs e)
        {

            //var mostExpensiveProduct = _db.Products.OrderByDescending(x=>x.UnitPrice).First();
            //2. yol

            var mostExpensiveProduct = _db.Products.Max(x => x.UnitPrice);
            var theCheapestProduct = _db.Products.Min(x => x.UnitPrice);
            Product productExpensive = _db.Products.FirstOrDefault(x => x.UnitPrice.Equals(mostExpensiveProduct));
            Product productTheCheapest = _db.Products.FirstOrDefault(x => x.UnitPrice.Equals(theCheapestProduct));
            MessageBox.Show("En Pahall� �r�n = " + productExpensive.ProductName + " " + productExpensive.UnitPrice);
            MessageBox.Show("En Ucuz �r�n = " + productTheCheapest.ProductName + " " + productTheCheapest.UnitPrice);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string text1 = "";
            var AveragePrice = _db.Products.Average(x => x.UnitPrice);
            List<Product> listOfProducts = _db.Products.ToList();
            foreach (Product item in listOfProducts)
            {
                if (item.UnitPrice > AveragePrice)
                {
                    text1 += item.ProductName + " ,";
                }
            }
            MessageBox.Show(text1);

            //2. ��z�m        
            var moreThanAverage = _db.Products.Where(x => x.UnitPrice > _db.Products.Average(e => e.UnitPrice)).OrderBy(x => x.UnitPrice).ToList();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            string text3 = "";
            List<Product> listOfProducts = _db.Products.OrderBy(x => x.UnitsInStock).ToList();

            foreach (Product item in listOfProducts)
            {

                text3 += item.ProductName + " " + item.UnitsInStock + "\n";
            }
            MessageBox.Show(text3);
        }
    }
}