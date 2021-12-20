using CRUDMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDMVC.Data
{
    public class Contexto : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }  
        public DbSet<Endereco> Enderecos { get; set; }  
        public DbSet<Telefone> Telefones { get; set; } 
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-1EFRJE3\\MSSQLSERVER2021;Initial Catalog=Projeto3;Integrated Security=True");
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Cliente>(table => 
            {
                table.ToTable("Clientes");
                table.HasKey(prop => prop.Id);

                table.Property(prop => prop.Nome).HasMaxLength(40).IsRequired();
                table.Property(prop => prop.CPF).HasColumnType("char(11)").IsRequired();
                table.Property(prop => prop.Email).HasMaxLength(40).IsRequired();
                table.Property(prop => prop.Sexo).HasColumnType("char(2)").IsRequired();


            });

            modelBuilder.Entity<Endereco>(table => 
            {
                table.ToTable("Endereco");
                table.HasKey(prop =>prop.Id);

                table.Property(prop => prop.Rua).HasMaxLength(40).IsRequired();
                table.Property(prop => prop.Cidade).HasMaxLength(40).IsRequired();
                table.Property(prop => prop.Estado).HasMaxLength(50).IsRequired();
                table.Property(prop => prop.Bairro).HasMaxLength(50).IsRequired();
                table.Property(prop => prop.Numero).HasColumnType("char(6)").IsRequired();
                
                   
            });

            modelBuilder.Entity<Telefone>(table => {

                table.ToTable("Telefone");
                table.HasKey(prop => prop.Id);

                table.Property(prop => prop.TelNumero).HasMaxLength(20).IsRequired();
                table.Property(prop => prop.Tipo).HasMaxLength(10).IsRequired();    
            });
        }

    }
}
