using AutoMapper;
using PaymentService.Modules.Payments.Dto;
using PaymentService.Modules.Payments.Models;

namespace PaymentService.Modules.Payments.Profiles;

public class PaymentProfile : Profile
{
    public PaymentProfile()
    {
        CreateMap<Payment, PaymentReadDto>();
        CreateMap<PaymentCreateDto, Payment>();
    }
}