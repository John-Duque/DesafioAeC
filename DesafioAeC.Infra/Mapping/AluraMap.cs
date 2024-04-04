using DesafioAeC.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioAeC.Infra.Mapping
{
    public class AluraMap : IEntityTypeConfiguration<AluraEntity>
    {
        public void Configure(EntityTypeBuilder<AluraEntity> builder)
        {
            builder.ToTable("Alura");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Titulo)
                   .IsRequired();

            builder.Property(u => u.Professor)
                .IsRequired()
                .HasMaxLength(60);

            builder.Property(u => u.DescricaoProfessor)
                .IsRequired();

            builder.Property(u => u.CargaHoraria)
                .IsRequired();
            builder.Property(u => u.DescricaoProfessor)
                .IsRequired();
        }
    }
}

