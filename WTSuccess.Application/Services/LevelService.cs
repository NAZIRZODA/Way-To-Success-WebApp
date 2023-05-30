using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTSuccess.Application.Common.Interfaces;
using WTSuccess.Application.Common.Interfaces.Repositories;
using WTSuccess.Application.Exceptions;
using WTSuccess.Application.Requests.LevelRequests;
using WTSuccess.Application.Responses.LevelResponses;
using WTSuccess.Domain.Models.GameScene;

namespace WTSuccess.Application.Services
{
    public class LevelService : BaseService<Level, LevelResponseModel, LevelRequestModel>, ILevelService
    {
        private readonly ILevelRepository _levelRepository;
        private readonly IMapper _mapper;

        public LevelService(ILevelRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _levelRepository = repository;
            _mapper = mapper;
        }

        public override void Add(LevelRequestModel request)
        {
            var entity = request as CreateLevelRequestModel;
            if (entity == null) throw new HttpStatusCodeException(System.Net.HttpStatusCode.NotFound);
            var mappedLevel = _mapper.Map<CreateLevelRequestModel, Level>(entity);
            _levelRepository.Add(mappedLevel);
            _levelRepository.SaveChanges();
        }

        public override LevelResponseModel Get(ulong id)
        {
            var entity = _levelRepository.FindById(id);
            if (entity == null) throw new HttpStatusCodeException(System.Net.HttpStatusCode.NotFound);
            var mappedToResponseLevel = _mapper.Map<Level, LevelResponseModel>(entity);
            return mappedToResponseLevel;
        }

        public override IEnumerable<LevelResponseModel> GetAll(int pageList, int pageNumber)
        {
            var entities = _levelRepository.GetAll(pageList, pageNumber);
            if (entities == null) throw new HttpStatusCodeException(System.Net.HttpStatusCode.NotFound);

            var mappedToLevelToResponse = _mapper.Map<IEnumerable<Level>, IEnumerable<LevelResponseModel>>(entities);
            return mappedToLevelToResponse;
        }

        public override LevelResponseModel Update(ulong id, LevelRequestModel request)
        {
            var entity = _levelRepository.FindById(id);
            if (entity == null) throw new HttpStatusCodeException(System.Net.HttpStatusCode.NotFound);

            var levelRequestToUpdate = request as UpdateLevelRequestModel;
            var updateRequestToLevel = _mapper.Map(levelRequestToUpdate, entity);
            _levelRepository.Update(entity);
            _levelRepository.SaveChanges();
            return _mapper.Map<Level, LevelResponseModel>(entity);
        }

        public override bool Delete(ulong id)
        {
            var entity = _levelRepository.FindById(id);
            if (entity == null) throw new HttpStatusCodeException(System.Net.HttpStatusCode.NotFound);

            _levelRepository.Delete(entity);
            _levelRepository.SaveChanges();
            return true;
        }
    }
}
