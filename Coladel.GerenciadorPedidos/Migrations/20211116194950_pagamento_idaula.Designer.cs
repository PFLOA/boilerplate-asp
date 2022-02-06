﻿// <auto-generated />
using System;
using Colade.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Coladel.GerenciadorAulas.Migrations
{
    [DbContext(typeof(UserDbContext))]
    [Migration("20211116194950_pagamento_idaula")]
    partial class pagamento_idaula
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.8");

            modelBuilder.Entity("Coladel.Domain.Entidades.Aluno", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasColumnName("id");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("data_cadastro");

                    b.Property<Guid>("Guid")
                        .HasColumnType("char(36)")
                        .HasColumnName("guid");

                    b.Property<string>("NomeCliente")
                        .HasColumnType("varchar(256)")
                        .HasColumnName("nome_cliente");

                    b.HasKey("Id");

                    b.ToTable("alunos");
                });

            modelBuilder.Entity("Coladel.Domain.Entidades.Aula", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasColumnName("id");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("data_cadastro");

                    b.Property<Guid>("Guid")
                        .HasColumnType("char(36)")
                        .HasColumnName("guid");

                    b.Property<short>("IdAluno")
                        .HasColumnType("smallint")
                        .HasColumnName("id_aluno_aulas");

                    b.Property<ulong>("IsPaga")
                        .HasColumnType("bit")
                        .HasColumnName("is_paga");

                    b.Property<string>("Materia")
                        .IsRequired()
                        .HasColumnType("varchar(128)")
                        .HasColumnName("materia");

                    b.Property<decimal>("TempoAula")
                        .HasColumnType("decimal(5,2)")
                        .HasColumnName("tempo_aula");

                    b.Property<decimal>("ValorHora")
                        .HasColumnType("decimal(10,2)")
                        .HasColumnName("valor_hora");

                    b.HasKey("Id");

                    b.HasIndex("IdAluno");

                    b.ToTable("aulas");
                });

            modelBuilder.Entity("Coladel.Domain.Entidades.Pagamento", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasColumnName("id");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("data_cadastro");

                    b.Property<Guid>("Guid")
                        .HasColumnType("char(36)")
                        .HasColumnName("guid");

                    b.Property<short>("IdAluno")
                        .HasColumnType("smallint")
                        .HasColumnName("id_aluno_pagamentos");

                    b.Property<short>("IdAula")
                        .HasColumnType("smallint")
                        .HasColumnName("id_aula_pagamentos");

                    b.Property<string>("Materia")
                        .IsRequired()
                        .HasColumnType("varchar(128)")
                        .HasColumnName("materia");

                    b.Property<short>("QuantidadeAulas")
                        .HasColumnType("smallint")
                        .HasColumnName("quantidade_aulas");

                    b.Property<decimal>("ValorHora")
                        .HasColumnType("decimal(5,2)")
                        .HasColumnName("valor_hora");

                    b.Property<decimal>("ValorPago")
                        .HasColumnType("decimal(5,2)")
                        .HasColumnName("valor_pago");

                    b.HasKey("Id");

                    b.HasIndex("IdAluno");

                    b.HasIndex("IdAula");

                    b.ToTable("pagamentos");
                });

            modelBuilder.Entity("Coladel.Domain.Entidades.Aula", b =>
                {
                    b.HasOne("Coladel.Domain.Entidades.Aluno", "Aluno")
                        .WithMany()
                        .HasForeignKey("IdAluno")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aluno");
                });

            modelBuilder.Entity("Coladel.Domain.Entidades.Pagamento", b =>
                {
                    b.HasOne("Coladel.Domain.Entidades.Aluno", "Aluno")
                        .WithMany()
                        .HasForeignKey("IdAluno")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Coladel.Domain.Entidades.Aula", "Aula")
                        .WithMany()
                        .HasForeignKey("IdAula")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aluno");

                    b.Navigation("Aula");
                });
#pragma warning restore 612, 618
        }
    }
}
