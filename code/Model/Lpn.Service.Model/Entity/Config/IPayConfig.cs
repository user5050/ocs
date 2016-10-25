using OneCoin.Service.Model.Enum.Payment;

namespace OneCoin.Service.Model.Entity.Config
{
    public interface IPayConfig
    {
        PayConfig GetConfig(string parkCode, PaymentType platform, PaymentPurpose purpose);

        PayConfig GetWxConfig(PaymentPurpose purpose); 
    }
}
