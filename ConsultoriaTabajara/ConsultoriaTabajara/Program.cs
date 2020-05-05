using System;
using System.Globalization;
using ConsultoriaTabajara.Entites;
using ConsultoriaTabajara.Entites.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultoriaTabajara
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Informe o nome do departamento: ");
            string deptName = Console.ReadLine();

            Console.WriteLine("Informe os dados do trabalhador ");

            Console.Write("Nome: ");
            string name = Console.ReadLine();

            Console.Write("Informe o nível (Junior, MidLevel ou Senior): ");
            WorkerLevel level = (WorkerLevel)Enum.Parse(typeof(WorkerLevel), Console.ReadLine());
            /*
             * não funciona na versão 2017 do vs#
             * WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());
             */
             
            Console.Write("Salário base: ");
            double baseSalary = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);

            Department dept = new Department(deptName);
            Worker worker = new Worker(name, level, baseSalary, dept);

            Console.Write("Informe a quant de contrato: ");
            int n = int.Parse(Console.ReadLine());

            for (int i=1; i <= n; i++)
            {
                /*
                 * é necessário usar o $ qdo usaremos a informação do contador
                 * #{i} necessário informar o nome da variaval tb
                */
                
                Console.WriteLine($"Informe os dados do #{i} contrato: ");

                Console.Write("Informe a data do contrato: ");
                DateTime date = DateTime.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Console.Write("Informe o valor hora: ");
                double ValuePerHour = double.Parse(Console.ReadLine());

                Console.Write("Informe a quant de horas: ");
                int hours = int.Parse(Console.ReadLine());

                HourContract contract = new HourContract(date, ValuePerHour, hours);
                worker.AddContract(contract);

                Console.WriteLine();
                Console.Write("Informe o mês e ano do contrato a ser calculado (mm/yyyy): ");

                string monthAndYear = Console.ReadLine();
                /*
                 * para obter apenas o mês que foi informado foi necessário usar o substring 
                 * onde será lido apenas do caracter 0 à 2
                 * para o ano iremos informar apenas o 3, onde irá verificar da posição três em diante
                 */
                int month = int.Parse(monthAndYear.Substring(0, 2));
                int year = int.Parse(monthAndYear.Substring(3));

                Console.WriteLine("Funcionário " + worker.Name);
                Console.WriteLine("Departamento " + worker.Department.Name);
                Console.WriteLine("Faturamento " + monthAndYear + ": " + worker.Income(year, month).ToString("F2", CultureInfo.InvariantCulture));





            }




        }
    }
}
