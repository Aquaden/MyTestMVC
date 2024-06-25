using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyTestMVC.Datas.Entities;

namespace MyTestMVC.Configs
{
    public class EventsConfig : IEntityTypeConfiguration<Events>
    {
        public void Configure(EntityTypeBuilder<Events> builder)
        {
            
            builder.Property(x => x.Title).IsRequired().HasMaxLength(255);
            builder.Property(x => x.CurrentDate).IsRequired();
            builder.Property(x => x.LastDate).IsRequired();

        }
    }
}
