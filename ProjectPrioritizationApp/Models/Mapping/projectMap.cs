using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectPrioritizationApp.Models.Mapping
{
    public class projectMap : EntityTypeConfiguration<project>
    {
        public projectMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.ProjectName)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.Description)
                .HasMaxLength(65535);

            // Table & Column Mappings
            this.ToTable("project", "ppa");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.ProjectName).HasColumnName("ProjectName");
            this.Property(t => t.Description).HasColumnName("Description");
        }
    }
}
