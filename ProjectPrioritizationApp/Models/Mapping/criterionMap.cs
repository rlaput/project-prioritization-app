using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectPrioritizationApp.Models.Mapping
{
    public class criterionMap : EntityTypeConfiguration<criterion>
    {
        public criterionMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.CriterionName)
                .IsRequired()
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("criterion", "ppa");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.CriterionName).HasColumnName("CriterionName");
            this.Property(t => t.Weight).HasColumnName("Weight");
        }
    }
}
