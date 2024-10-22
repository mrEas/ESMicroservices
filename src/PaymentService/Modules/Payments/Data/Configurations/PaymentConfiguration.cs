using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaymentService.Modules.Payments.Models;

namespace PaymentService.Modules.Payments.Data.Configurations;

public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
	public void Configure(EntityTypeBuilder<Payment> builder)
	{
		builder.ToTable("Payments");
		builder.HasKey(x => x.Id);
		builder.Property(x => x.Created);
		builder.Property(x => x.Price);
		builder.Property(x => x.Status);
		builder.Property(x => x.OrderId);
	}
}