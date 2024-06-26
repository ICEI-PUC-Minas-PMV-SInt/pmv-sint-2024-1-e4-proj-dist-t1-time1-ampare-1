﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ampare.api.Models;

#nullable disable

namespace ampare.api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240613215858_ProjetoVoluntariorRelation")]
    partial class ProjetoVoluntariorRelation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.28")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ampare.api.Models.Ong", b =>
                {
                    b.Property<int>("OngId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OngId"), 1L, 1);

                    b.Property<string>("Cnpj")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Endereco")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsComplete")
                        .HasColumnType("bit");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RazaoSocial")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OngId");

                    b.ToTable("Ongs");
                });

            modelBuilder.Entity("ampare.api.Models.ProjetoVoluntario", b =>
                {
                    b.Property<int>("ProjetoId")
                        .HasColumnType("int");

                    b.Property<int>("VoluntarioId")
                        .HasColumnType("int");

                    b.HasKey("ProjetoId", "VoluntarioId");

                    b.HasIndex("VoluntarioId");

                    b.ToTable("ProjetoVoluntario");
                });

            modelBuilder.Entity("ampare.api.Models.Voluntario", b =>
                {
                    b.Property<int>("VoluntarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VoluntarioId"), 1L, 1);

                    b.Property<string>("Cpf")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Endereco")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VoluntarioId");

                    b.ToTable("Voluntarios");
                });

            modelBuilder.Entity("Projeto", b =>
                {
                    b.Property<int>("ProjetoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProjetoId"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OngId")
                        .HasColumnType("int");

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProjetoId");

                    b.HasIndex("OngId");

                    b.ToTable("Projetos");
                });

            modelBuilder.Entity("ampare.api.Models.ProjetoVoluntario", b =>
                {
                    b.HasOne("Projeto", "Projeto")
                        .WithMany("ProjetoVoluntario")
                        .HasForeignKey("ProjetoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ampare.api.Models.Voluntario", "Voluntario")
                        .WithMany("ProjetoVoluntario")
                        .HasForeignKey("VoluntarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Projeto");

                    b.Navigation("Voluntario");
                });

            modelBuilder.Entity("Projeto", b =>
                {
                    b.HasOne("ampare.api.Models.Ong", null)
                        .WithMany("Projetos")
                        .HasForeignKey("OngId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ampare.api.Models.Ong", b =>
                {
                    b.Navigation("Projetos");
                });

            modelBuilder.Entity("ampare.api.Models.Voluntario", b =>
                {
                    b.Navigation("ProjetoVoluntario");
                });

            modelBuilder.Entity("Projeto", b =>
                {
                    b.Navigation("ProjetoVoluntario");
                });
#pragma warning restore 612, 618
        }
    }
}
