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
    public class SubscribersService
    {
        private readonly PhoneDatabaseService _phoneDatabaseService = new PhoneDatabaseService();

        public bool SaveSubscribersBase(HttpPostedFileBase fileUpload, Guid userId, string directory)
        {
            return _phoneDatabaseService.Save(fileUpload, directory, userId, directory);
        }
        public List<SubscribersBaseViewModel> GetUserBases(Guid ownerId)
        {
            var result = new List<SubscribersBaseViewModel>();
            var _bases = _phoneDatabaseService.GetAll(ownerId);

            if (!_bases.Any())
            {
                return result;
            }

            Mapper.CreateMap<SubscribersBaseDTO, SubscribersBaseViewModel>();
            result = Mapper.Map<IEnumerable<SubscribersBaseDTO>, IEnumerable<SubscribersBaseViewModel>>(_bases).ToList();

            return result;
        }
    }
}