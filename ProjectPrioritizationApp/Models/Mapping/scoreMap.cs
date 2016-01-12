using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectPrioritizationApp.Models.Mapping
{
    public class scoreMap : EntityTypeConfiguration<score>
    {
        public scoreMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("score", "ppa");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.CriterionId).HasColumnName("CriterionId");
            this.Property(t => t.ProjectId).HasColumnName("ProjectId");
            this.Property(t => t.Rate).HasColumnName("Rate");

            // Relationships
            this.HasRequired(t => t.criterion)
                .WithMany(t => t.scores)
                .HasForeignKey(d => d.CriterionId);
            this.HasRequired(t => t.project)
                .WithMany(t => t.scores)
                .HasForeignKey(d => d.ProjectId);

        }
    }
}
