﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ConsoleApp.Models;

namespace ConsoleApp.Configurations
{
    public class BuildingConfiguration : IEntityTypeConfiguration<Building>
    {
        public void Configure(EntityTypeBuilder<Building> builder)
        {
            builder.HasKey(note => note.id);
            builder.HasIndex(note => note.id).IsUnique();
            builder.Property(note => note.name).HasMaxLength(50).IsRequired(true);
            builder.Property(note => note.email).HasMaxLength(20).IsRequired(true);
            builder.Property(note => note.floorCount).IsRequired(true);
            builder.Property(note => note.description).HasMaxLength(100).IsRequired(true);
        }
    }
}
