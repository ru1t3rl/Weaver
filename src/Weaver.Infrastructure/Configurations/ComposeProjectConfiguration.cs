using Humanizer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Weaver.Domain.Entities;

namespace Weaver.Infrastructure.Configurations;

public class ComposeProjectConfiguration : IEntityTypeConfiguration<ComposeProject>
{
    public void Configure(EntityTypeBuilder<ComposeProject> builder)
    {
        builder.ToTable(nameof(ComposeProject).Pluralize());
        
        builder
            .HasMany<Tag>(p => p.Tags)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);
    }
}