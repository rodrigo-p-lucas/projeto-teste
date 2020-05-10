using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoTeste.Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoTeste.Persistencia
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.Property(c => c.ProdutoDescricao)
                .HasColumnType("varchar(150)")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(c => c.ProdutoQtdEstoque)
                .HasColumnType("decimal(10,4)")
                .IsRequired();

            builder.Property(p => p.ProdutoValor)
                .HasColumnType("decimal(12,2)")
                .HasDefaultValue(0);
        }
    }
}
