using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesWebMvc.Models
{
    public class Department
    {
        public int Id{ get; set; }
        public string Name{ get; set; }

        //Associação: 1 departamento(Department) tem varios vendedores(seller)
        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();

        //Construtor Padrão
        public Department(){}

        //Construtor com argumentos
        //Sellers não entra como argumento pois é uma coleção
        public Department(int id, string name)
        {
            Id = id;
            Name = name;
        }
        //operação para Adicionar um vendedor(Seller) na lista de vendedores(Sellers)
        public void AddSeller(Seller seller)
        {
            Sellers.Add(seller);
        }
        //operação para Calcular o total de vendas(Sales) de um departamento em um intervalo de datas
        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sellers.Sum(seller => seller.TotalSales(initial, final));               
        }

    }
}
