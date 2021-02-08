using Clean_Architecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Architecture.Infrastructure.Persistence.Configurations
{
    public class PlcConfiguration : IEntityTypeConfiguration<Plc>
    {
        public void Configure(EntityTypeBuilder<Plc> builder)
        {
            //TODO: ADD PROPER CONFIGURATIONS FOR PLC
            builder.Property(p => p.IpAddress)
                .HasMaxLength(15)
                .IsRequired();
        }
    }
}
