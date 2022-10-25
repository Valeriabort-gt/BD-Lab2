﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ConsoleApp.Models;

namespace ConsoleApp.Configurations
{
    public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.HasKey(note => note.id);
            builder.HasIndex(note => note.id).IsUnique();
            builder.Property(note => note.numOfRoom).HasMaxLength(10).IsRequired(true);
            builder.Property(note => note.buildingID).IsRequired(true);
            builder.Property(note => note.square).IsRequired(true);
            builder.Property(note => note.description).HasMaxLength(100).IsRequired(true);
        }
    }
}
