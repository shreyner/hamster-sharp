// <auto-generated />
using System;
using MetricsManager.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MetricsManager.DB.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("MetricsManager.Entities.Agent", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<bool>("Enabled")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("Agents");
                });

            modelBuilder.Entity("MetricsManager.Entities.CpuMetric", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long>("AgentId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("Value")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AgentId");

                    b.ToTable("CpuMetrics");
                });

            modelBuilder.Entity("MetricsManager.Entities.DotNetMetric", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long>("AgentId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("Value")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AgentId");

                    b.ToTable("DotNetMetrics");
                });

            modelBuilder.Entity("MetricsManager.Entities.HddMetric", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long>("AgentId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("Value")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AgentId");

                    b.ToTable("HddMetrics");
                });

            modelBuilder.Entity("MetricsManager.Entities.NetworkMetric", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long>("AgentId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("Value")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AgentId");

                    b.ToTable("NetworkMetrics");
                });

            modelBuilder.Entity("MetricsManager.Entities.RamMetric", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long>("AgentId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("Value")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AgentId");

                    b.ToTable("RamMetrics");
                });

            modelBuilder.Entity("MetricsManager.Entities.CpuMetric", b =>
                {
                    b.HasOne("MetricsManager.Entities.Agent", "Agent")
                        .WithMany()
                        .HasForeignKey("AgentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Agent");
                });

            modelBuilder.Entity("MetricsManager.Entities.DotNetMetric", b =>
                {
                    b.HasOne("MetricsManager.Entities.Agent", "Agent")
                        .WithMany()
                        .HasForeignKey("AgentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Agent");
                });

            modelBuilder.Entity("MetricsManager.Entities.HddMetric", b =>
                {
                    b.HasOne("MetricsManager.Entities.Agent", "Agent")
                        .WithMany()
                        .HasForeignKey("AgentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Agent");
                });

            modelBuilder.Entity("MetricsManager.Entities.NetworkMetric", b =>
                {
                    b.HasOne("MetricsManager.Entities.Agent", "Agent")
                        .WithMany()
                        .HasForeignKey("AgentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Agent");
                });

            modelBuilder.Entity("MetricsManager.Entities.RamMetric", b =>
                {
                    b.HasOne("MetricsManager.Entities.Agent", "Agent")
                        .WithMany()
                        .HasForeignKey("AgentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Agent");
                });
#pragma warning restore 612, 618
        }
    }
}
