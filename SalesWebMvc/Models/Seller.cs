using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SalesWebMvc.Models
{
    public class Seller
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} size should be between {2} and {1}")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [EmailAddress(ErrorMessage = "Enter a valid email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Birthdate { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [Range(100.0, 50000.0, ErrorMessage = "{0} must be from {1} to {2}")]
        [Display(Name = "Base Salary")]   
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double BaseSalary { get; set; }
        //Associação:1 vendedor(Seller) possui 1 Departmento
        public Department Department { get; set; }

        public int DepartmentId { get; set; }
        //Associação:1 vendedor(Seller) possui varios Registro de vendas(SalesRecord)
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        //Construtor Padrão
        public Seller() { }

        //Construtor com argumentos
        //Sales não entra como argumento pois é uma coleção
        public Seller(int id, string name, string email, DateTime birthdate, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            Birthdate = birthdate;
            BaseSalary = baseSalary;
            Department = department;
        }

        //operação para adicionar uma venda(SalesRecord) na lista de vendas
        public void AddSales(SalesRecord sr)
        {
            Sales.Add(sr);
        }
        //operação para Remover uma venda(SalesRecord) na lista de vendas
        public void RemoveSales(SalesRecord sr)
        {
            Sales.Remove(sr);
        }
        //operação para Mostrar o total de vendas(SalesRecord) de um vendedor(seller)em um determinado período
        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
        }
       
    }
}
