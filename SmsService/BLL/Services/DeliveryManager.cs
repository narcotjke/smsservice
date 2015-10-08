using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Entities;
using DAL;
using DAL.Repositories;

namespace BLL.Services
{
    public class DeliveryManager
    {
        private readonly UnitOfWork _unitOfWork = new UnitOfWork();
        public void SaveDelivery(DeliveryDTO _delivery)
        {
            Mapper.CreateMap<DeliveryDTO, Delivery>();
            var delivery = Mapper.Map<DeliveryDTO, Delivery>(_delivery);

            _unitOfWork.DeliveryRepository.Create(delivery);
            _unitOfWork.Save();
        }

        public List<DeliveryDTO> GetDeliveries()
        {
            var del = _unitOfWork.DeliveryRepository.GetAll();
            Mapper.CreateMap<Delivery, DeliveryDTO>();
            var deliveries = Mapper.Map<IEnumerable<Delivery>, IEnumerable<DeliveryDTO>>(del);

            return deliveries.ToList();
        }
    }
}
