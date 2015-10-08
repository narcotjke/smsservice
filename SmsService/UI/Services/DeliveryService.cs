using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using BLL.Entities;
using BLL.Services;
using UI.Models;

namespace UI.Services
{
    public class DeliveryService
    {
        private readonly DeliveryManager _manager = new DeliveryManager();

        public DeliveryViewModel PrepareModel(string id)
        {
            Guid _id;

            return !Guid.TryParse(id, out _id) ? null : new DeliveryViewModel(_id);
        }

        public void SaveDelivery(DeliveryViewModel delivery)
        {
            Mapper.CreateMap<DeliveryViewModel, DeliveryDTO>();
            var d = Mapper.Map<DeliveryViewModel, DeliveryDTO>(delivery);

            _manager.SaveDelivery(d);
        }

        public List<DeliveryViewModel> GetDeliveries(DateTime? startDate, DateTime? endDate)
        {
            var del = _manager.GetDeliveries();

            Mapper.CreateMap<DeliveryDTO, DeliveryViewModel>()
                .ForMember(dest => dest.Id, n => n.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, n => n.MapFrom(src => src.Name))
                .ForMember(dest => dest.ServiceId, n => n.MapFrom(src => src.ServiceId))
                .ForMember(dest => dest.MessageText, n => n.MapFrom(src => src.MessageText))
                .ForMember(dest => dest.DeliveryRate, n => n.MapFrom(src => src.DeliveryRate))
                .ForMember(dest => dest.Date, n => n.MapFrom(src => src.Date))
                .ForMember(dest => dest.SmsServiceUserId, n => n.MapFrom(src => src.SmsServiceUserId))
                .ForMember(dest => dest.SubscribersBaseId, n => n.MapFrom(src => src.SubscribersBaseId));
            var deliveries = Mapper.Map<IEnumerable<DeliveryDTO>, IEnumerable<DeliveryViewModel>>(del);

            if (startDate.HasValue && endDate.HasValue)
            {
                return deliveries.Where(d => d.Date >= startDate && d.Date <= endDate).ToList();
            }

            return deliveries.ToList();
        } 
    }
}