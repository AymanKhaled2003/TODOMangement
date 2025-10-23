using ToDoMangament.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoMangament.Persistence.Configuration
{
    public class TodoConfiguration : IEntityTypeConfiguration<Todo>
    {
        public void Configure(EntityTypeBuilder<Todo> builder)
        {
            builder.ToTable("Todos");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Title)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(t => t.Description)
                   .HasMaxLength(500);

            builder.Property(t => t.Status)
                   .IsRequired()
                   .HasConversion<int>();

            builder.Property(t => t.Priority)
                   .IsRequired()
                   .HasConversion<int>();

            builder.Property(t => t.DueDate)
                   .HasColumnType("datetime2");

            builder.Property(t => t.CreatedAt)
                   .IsRequired();

            builder.Property(t => t.LastModifiedDate)
                   .IsRequired(false);
        }
    }
}
