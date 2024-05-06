using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFrameworkCore.Configurations
{
    public class ReportProductConfig : IEntityTypeConfiguration<ProductReport>
    {
        public void Configure(EntityTypeBuilder<ProductReport> builder)
        {
            builder.ToView("VW_PRODUCT_REPORT");
        }
    }
}
