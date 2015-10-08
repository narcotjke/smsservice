using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using AutoMapper;
using BLL.Entities;
using DAL;
using DAL.Repositories;

namespace BLL.Services
{
    public class PhoneDatabaseService
    {
        private readonly List<string> _fileType = new List<string> {"xls", "xlsx", "csv", "txt"}; 
        private readonly IUnitOfWork _unitOfWork = new UnitOfWork();
        public bool Save(HttpPostedFileBase fileUpload, string directory, Guid userId, string derictory)
        {
            var fileName = fileUpload.FileName;

            if (!_fileType.Contains(GetFileType(fileName)))
            {
                return false;
            }

            var numbers = ReadFile(fileUpload);

            if (!SaveOnDisk(fileName, directory, userId, numbers))
            {
                return false;
            }

            var modelDto = PrepareModel(directory, fileName, numbers, userId);

            Mapper.CreateMap<SubscribersBaseDTO, SubscribersBase>();
            var model = Mapper.Map<SubscribersBaseDTO, SubscribersBase>(modelDto);

            _unitOfWork.SubscriberBaseRepository.Create(model);
            _unitOfWork.Save();

            return true;
        }

        public string GetFileType(string filename)
        {
            return !string.IsNullOrWhiteSpace(filename) ? filename.Split('.').LastOrDefault() : string.Empty;
        }

        public List<string> ReadFile(HttpPostedFileBase fileUpload)
        {
            var result = new List<string>();

            using (var stream = new StreamReader(fileUpload.InputStream))
            {
                while (stream.Peek() >= 0)
                {
                    var line = stream.ReadLine();
                    var number = FindNumber(line);

                    if (!string.IsNullOrEmpty(number))
                    {
                        result.Add(number);
                    }
                }
            }

            return result.Distinct().ToList();
        }

        public string FindNumber(string text)
        {
            Regex template = new Regex(@"^\+?(375)[0-9]{9}$", RegexOptions.IgnoreCase);
            MatchCollection matches = template.Matches(text);

            if (matches.Count > 0)
            {
                return matches[0].ToString().Replace("+", string.Empty);
            }

            return string.Empty;
        }

        public SubscribersBaseDTO PrepareModel(string directory, string filename, List<string> tpNumbers, Guid userId)
        {
            var subbase = new SubscribersBaseDTO
            {
                Name = filename,
                Subscribersnumber = tpNumbers.Count,
                CreationDate = DateTime.Now,
                FilePath = Path.Combine(directory, "Files", userId.ToString(), filename),
                SmsServiceUserId = userId
            };

            return subbase;
        }

        public List<SubscribersBaseDTO> GetAll(Guid ownerId)
        {
            Mapper.CreateMap<SubscribersBase, SubscribersBaseDTO>();
            var bases =
                Mapper.Map<IEnumerable<SubscribersBase>, IEnumerable<SubscribersBaseDTO>>(
                    _unitOfWork.SubscriberBaseRepository.GetAll().Where(x => x.SmsServiceUserId == ownerId));

            return bases.ToList();
        }

        public bool SaveOnDisk(string fileName, string directory, Guid userId, List<string> numbers)
        {
            try
            {
                var folder = userId.ToString();
                var pathString = Path.Combine(directory, "Files", folder);
                Directory.CreateDirectory(pathString);
                pathString = Path.Combine(pathString, fileName);

                if (File.Exists(pathString))
                {
                    return false;
                }

                File.WriteAllLines(pathString, numbers);

                return true;
            }
            catch (Exception exception)
            {
                return false;
            }
        }
    }
}
