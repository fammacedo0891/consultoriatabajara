using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//informado o endereço da classe que o workerLevel esta
using ConsultoriaTabajara.Entites.Enums;
//parametro utlizado pela lista


namespace ConsultoriaTabajara.Entites
{
    class Worker
    {
        public string Name { get; set; }

        //necessrio add a classe que pertence no using
        public WorkerLevel Level { get; set; }

        public double BaseSalary { get; set; }

        //faz associacao entre as classes, informa o nome da classe e atribui um apelido/nome
        public Department Department { get; set; }

        //adicionar uma lista de opções e dois instancia para receber os valores
        public List<HourContract> Contracts { get; set; } = new List<HourContract>();

        //construtor
        public Worker()
        {

        }

        /*
         * construtor com vários parametros
         * por padrão não add no construtor uma lista
        */
        public Worker(string name, WorkerLevel level, double baseSalary, Department department)
        {
            Name = name;
            Level = level;
            BaseSalary = baseSalary;
            Department = department;
        }

        /*
         * add a lista de contrato um novo valor
         * void permite apenas alterar valores a partir de parametros info
         * HourContract receberá o parametro do contract
         * add o contrato
         */

        public void AddContract(HourContract contract)
        {
            Contracts.Add(contract);
        }
         
        public void RemoveContract(HourContract contract)
        {
            Contracts.Remove(contract);
        }

        public double Income(int year, int month)
        {
            double sum = BaseSalary;

            //procura dentro da lista de contrato os contratos existentes
            foreach (HourContract contract in Contracts)
            {
                if (contract.Date.Year == year && contract.Date.Month == month)
                {
                    sum += contract.TotalValue();
                }
                               
            }

            return sum;
                       
        }

    }

}
