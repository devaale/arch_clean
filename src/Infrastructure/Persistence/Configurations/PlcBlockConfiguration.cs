using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clean_Architecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clean_Architecture.Infrastructure.Persistence.Configurations
{
    public class PlcBlockConfiguration : IEntityTypeConfiguration<PlcBlock>
    {
        public void Configure(EntityTypeBuilder<PlcBlock> builder)
        {
            //TODO: ADD PROPER CONFIGURATIONS FOR PLC BLOCK
            builder.Property(p => p.OffsetBit)
                .IsRequired();
        }
    }
}
