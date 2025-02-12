using ErrorLoggerSM.Domain.Entities;

namespace ErrorLoggerSM.Application.AlertEmailReceivers.Queries;

public class AlertEmailReceiverDto
{
    public required string Name { get; set; }
    public required string Email { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<AlertEmailReceiver, AlertEmailReceiverDto>();       
        }
    }
}

